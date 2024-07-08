using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;    // for dependency injection

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]                               //<List<Categories ani kudaa vadochu but edi flexible
        public async Task<ActionResult<List<Category>>> GetCategories(int pageNumber, int pageSize)
        {
            var categories = await _categoryRepository.GetCategoriesAsync(pageNumber, pageSize);
            return Ok(categories);
        }

        [HttpGet("active")]
        public async Task<ActionResult<List<Category>>> GetActiveCategories(int pageNumber, int pageSize)
        {
            var categories = await _categoryRepository.GetActiveCategoriesAsync(pageNumber, pageSize);
            return Ok(categories);
        }

        [HttpGet("deactivated")]
        public async Task<ActionResult<List<Category>>> GetDeactivatedCategories(int pageNumber, int pageSize)
        {
            var categories = await _categoryRepository.GetDeactivatedCategoriesAsync(pageNumber, pageSize);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            await _categoryRepository.CreateCategoryAsync(category);
            return Ok(category);
           // return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, Category category)
        {
            await _categoryRepository.UpdateCategoryAsync(id,category);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            return Ok();
        }

        [HttpPost("{id}/activate")]
        public async Task<ActionResult> ActivateCategory(int id)
        {
            await _categoryRepository.ActivateCategoryAsync(id);
            return Ok();
        }

        [HttpPost("{id}/deactivate")]
        public async Task<ActionResult> DeactivateCategory(int id)
        {
            await _categoryRepository.DeactivateCategoryAsync(id);
            return Ok();
        }
    }
}
