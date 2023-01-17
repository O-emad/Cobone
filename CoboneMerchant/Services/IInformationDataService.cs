using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public interface IInformationDataService
    {
        Task<List<Information>> GetSiteInformation();
        Task<InformationDetails> GetInformationDetails(int id);
    }
}
