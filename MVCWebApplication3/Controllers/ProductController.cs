using Microsoft.AspNetCore.Mvc;
using MVCWebApplication3.Models;
using MVCWebApplication3.Repository;

namespace MVCWebApplication3.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _Pro;
        //  private readonly ProDbContext _context;

        public ProductController(IProductRepository productRepository, ProDbContext context)
        {
            _Pro = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetALL(int Pageno, int paSize)
        {
            var GetAll = await _Pro.GetProductsAsync(Pageno, paSize);   // ToListAsync()
            return Ok(GetAll);
        }
        [HttpGet("id")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var Get = await _Pro.GetProductByIdAsync(id);  //
            return Ok(Get);
        }
        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            await _Pro.AddProductAsync(product);

            return Ok(product);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _Pro.UpdateProductAsync(id, product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _Pro.DeleteProductAsync(id);
            return Ok();
        }


        [HttpPost("{id}/activate")]
        public async Task<ActionResult> ActivateProduct(int id)
        {
            await _Pro.ActivateProductAsync(id);
            return Ok();
        }

        [HttpPost("{id}/deactivate")]
        public async Task<ActionResult> DeactivateProduct(int id)
        {
            await _Pro.DeactivateProductAsync(id);
            return Ok();
        }



        [HttpGet("active")]
        public async Task<ActionResult<List<Category>>> GetallActiveProducts(int pageNumber, int pageSize)
        {
            var Prod = await _Pro.GetAllActivateProductAsync(pageNumber, pageSize);
            return Ok(Prod);
        }

        [HttpGet("deactivated")]
        public async Task<ActionResult<List<Category>>> GetallDeactivatedProducts(int pageNumber, int pageSize)
        {
            var Prod = await _Pro.GetAllDeactiveProAsync(pageNumber, pageSize);
            return Ok(Prod);
        }
    }
}
