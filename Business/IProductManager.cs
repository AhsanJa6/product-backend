using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IProductsManager
    {
        Task<bool> DeleteByIdAsync(Guid id);
        Task<Product> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> CreateOrUpdateAsync(Product product);
    }
}
