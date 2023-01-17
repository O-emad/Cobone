using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public interface ICategoryDataService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetCategoriesToDepth(int depth);
        Task<IEnumerable<Category>> GetCategoriesByParentId(int parentId);
    }
}
