using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductManager : IProductsManager
    {
        readonly IProductsRepository repository;

        public ProductManager(IProductsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Product> CreateOrUpdateAsync(Product product)
        {
            var response = await this.repository.CreateOrUpdateAsync(product);
            return response;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var response = await this.repository.DeleteByIdAsync(id);
            return response;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var response = await this.repository.GetAllAsync();
            return response;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var response = await this.repository.GetByIdAsync(id);
            return response;
        }
    }
}
