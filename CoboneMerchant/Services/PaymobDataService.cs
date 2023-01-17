using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public class PaymobDataService : IPaymentGatewayDataService
    {
        private readonly HttpClient httpClient;

        public PaymobDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient??throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> AuthenticationRequest()
        {
            try
            {
                var resposne = await JsonSerializer.DeserializeAsync<BaseResponse<PaymobAccountDetails>>(
                    (await httpClient.PostAsync("index.php?route=rest/payment_method/payMobAuth", null)).Content.ReadAsStream(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return resposne?.Data?.token??"";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<PaymobOrderRegisterResponse> OrderRegister(PaymobOrderRegisterRequest request)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(request),Encoding.UTF8,"application/json");
                var response = await httpClient.PostAsync("index.php?route=rest/payment_method/payMobOrderRegistration", content);
                response.EnsureSuccessStatusCode();
                var responseBodyObject = await JsonSerializer.DeserializeAsync<BaseResponse<PaymobOrderRegisterResponse>>(response.Content.ReadAsStream(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive=true});
                return responseBodyObject?.Data ?? new PaymobOrderRegisterResponse();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<PaymobPaymentResponse> PaymentRequest(PaymobPaymentRequest request)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("index.php?route=rest/payment_method/payMobPaymentKey", content);
                response.EnsureSuccessStatusCode();
                var responseBodyObject = await JsonSerializer.DeserializeAsync<BaseResponse<PaymobPaymentResponse>>(response.Content.ReadAsStream(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return responseBodyObject?.Data ?? new PaymobPaymentResponse();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
