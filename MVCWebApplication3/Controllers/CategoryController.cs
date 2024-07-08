using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCWebApplication3.Models;
using MVCWebApplication3.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCWebApplication3.Controllers
{
    [Route("Category/[Action]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: /Category/GetCategories?pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories(int pageNumber = 1, int pageSize = 10)
        {
            var categories = await _categoryRepository.GetCategoriesAsync(pageNumber, pageSize);
            return View(categories); // Assumes you have a view for displaying a list of categories
        }

        // GET: /Category/GetCategoryById/4
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound(); // Returns 404 Not Found if category with the specified id is not found
            }

            return View(category); // Assumes you have a view named CategoryDetails.cshtml
        }

        // GET: /Category/CreateCategory
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View(); // Returns the view for creating a new category
        }

        // POST: Category/CreateCategory
        [HttpPost]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.CreateCategoryAsync(category);
                return RedirectToAction("GetCategories"); // Redirect to the Index action of HomeController after successful creation
            }
            return View(category); // Returns the view with validation errors if ModelState is not valid
        }

        // GET: /Category/UpdateCategory/3
        [HttpGet("{id}")]
        public async Task<ActionResult> UpdateCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category); // Returns the view for updating the category
        }

        // PUT: /Category/UpdateCategory/3
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryRepository.UpdateCategoryAsync(id, category);
                }
                catch (Exception)
                {
                    // Handle exception, e.g., logging
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the category");
                }
                return Ok();
            }

            return View(category); // Return the view with validation errors if ModelState is not valid
        }
      
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound(); // Optionally handle not found case
            }

            await _categoryRepository.DeleteCategoryAsync(id);

            return RedirectToAction("GetCategories"); // Redirects to the action that lists categories
        }





        // POST: Category/ActivateCategory/{id}
        [HttpPost("{id}/activate")]
        public async Task<ActionResult> ActivateCategory(int id)
        {
            await _categoryRepository.ActivateCategoryAsync(id);
            return Ok();
        }

        // POST: Category/DeactivateCategory/{id}
        [HttpPost("{id}/deactivate")]
        public async Task<ActionResult> DeactivateCategory(int id)
        {
            await _categoryRepository.DeactivateCategoryAsync(id);
            return Ok();
        }

        // GET: Category/active?pageNumber=1&pageSize=10
        [HttpGet("active")]
        public async Task<ActionResult<List<Category>>> GetActiveCategories(int pageNumber = 1, int pageSize = 10)
        {
            var categories = await _categoryRepository.GetActiveCategoriesAsync(pageNumber, pageSize);
            return Ok(categories);
        }

        // GET: Category/deactivated?pageNumber=1&pageSize=10
        [HttpGet("deactivated")]
        public async Task<ActionResult<List<Category>>> GetDeactivatedCategories(int pageNumber = 1, int pageSize = 10)
        {
            var categories = await _categoryRepository.GetDeactivatedCategoriesAsync(pageNumber, pageSize);
            return Ok(categories);
        }
    }
}
