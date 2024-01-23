using Data.Context;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductsRepository : IProductsRepository
    {
        readonly ProductContext context;
        public ProductsRepository(ProductContext context)
        {
            this.context = context;
        }
        public async Task<Product> CreateOrUpdateAsync(Product product)
        {
            var isExisting = this.context.Products.Any(el => el.Id == product.Id);
            if (!isExisting)
            {
                product.Id = Guid.NewGuid();
                this.context.Products.Add(product);
            }
            else
            {
                this.context.Entry(product).State = EntityState.Modified;
            }

            var rowsUpdated = await this.context.SaveChangesAsync();

            return rowsUpdated > 0 ? product : null;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var products = new Product
            {
                Id = id
            };

            this.context.Remove(products);

            var rowsUpdated = await this.context.SaveChangesAsync();

            return rowsUpdated > 0;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var query = (from x in this.context.Products
                         orderby x.Name
                         select x);

            var response = await query.ToListAsync();

            return response;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var query = (from x in this.context.Products
                         where x.Id == id
                         select x);
            var response = await query.FirstOrDefaultAsync();


            return response;
        }

    
    }
}
