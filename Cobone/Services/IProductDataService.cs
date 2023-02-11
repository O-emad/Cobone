using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public interface IProductDataService
    {
        Task<FullProductInfo> GetProductById(int id);
        Task<List<Product>> GetProductsByCategoryId(int id);
        Task<List<ProductSearch>> GetProductByName(string name);
    }
}
