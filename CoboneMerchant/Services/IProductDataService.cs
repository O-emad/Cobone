using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public interface IProductDataService
    {
        Task<FullProductInfo> GetProductById(int id);
        Task<List<Product>> GetProductsByCategoryId(int id);
    }
}
