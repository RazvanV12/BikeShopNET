using Microsoft.AspNetCore.Mvc;
using BikeShopNET.Services.ProductService;
using BikeShopNET.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeShopNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly BikeShopContext _context;

        public ProductController(IProductService productService, BikeShopContext context)
        {
            _productService = productService;
            _context = context;
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            try
            {
                _productService.AddProduct(product);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return Problem("Something went wrong", statusCode: 500);
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product, string productId)
        {
            try
            {
                _productService.UpdateProduct(product, productId);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return Problem("Something went wrong", statusCode: 500);
            }
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] string productId)
        {
            try
            {
                _productService.DeleteProduct(productId);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return Problem("Something went wrong", statusCode: 500);
            }
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception)
            {
                return Problem("Something went wrong", statusCode: 500);
            }
        }
    }
}
