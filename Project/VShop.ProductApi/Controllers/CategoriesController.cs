using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoryDto = await _categoryService.GetCategories();
            if(categoryDto is null)
                return NotFound("Categories not found, sorry ):");

            return Ok(categoryDto);
        }


        [HttpGet("Products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            var categoryProductsDto = await _categoryService.GetCategoriesProducts();
            if (categoryProductsDto is null)
                return NotFound("Categories not found, sorry ):");

            return Ok(categoryProductsDto);
        }

        [HttpGet ("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);
            if (categoryDto is null)
                return NotFound("Categories not found, sorry ):");

            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
                return BadRequest("Invalid data");

            await _categoryService.AddCategory(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new {id = categoryDto.CategoryId}, categoryDto);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto is null)
                return BadRequest("Invalid data");

            if (id != categoryDto.CategoryId)
                return BadRequest(id + " Not found");

            await _categoryService.UpdateCategory(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Delete(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);

            if (categoryDto is null)
                return NotFound();

            await _categoryService.DeleteCategory(id);

            return Ok(categoryDto);
        }
    }
}
