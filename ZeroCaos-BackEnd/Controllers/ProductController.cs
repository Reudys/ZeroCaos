using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZeroCaos_BackEnd.Interfaces;
using ZeroCaos_BackEnd.Models;

namespace ZeroCaos_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service) { _service = service; }

        #region Crud Methods
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _service.CreateProductAsync(product);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var products = await _service.GetProductAsync();
            return Ok(products);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            var updatedProduct = await _service.UpdateProductAsync(id, product);
            if (updatedProduct == null) return NotFound();
            return Ok(updatedProduct);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _service.DeleteProductAsync(id);
            if (!result) return NotFound();
            return Ok();
        }
        #endregion

        #region Custom Methods
        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var product = await _service.GetProductByNameAsync(name);
            if (product == null) return NotFound();
            return Ok(product);
        }
        #endregion
    }
}