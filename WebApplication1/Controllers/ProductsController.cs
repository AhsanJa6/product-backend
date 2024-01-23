using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductsManager productManager;

        public ProductsController(IProductsManager productManager)
        {
            this.productManager = productManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await this.productManager.GetAllAsync();
            return Ok(response);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = await this.productManager.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateAsync(Product product)
        {

            var response = await this.productManager.CreateOrUpdateAsync(product);
            return Ok(response);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {

            var response = await this.productManager.DeleteByIdAsync(id);
            return Ok(response);
        }
    }
}
