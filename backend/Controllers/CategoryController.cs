using backend.DTO;
using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task AddCategory([FromBody] CategoryDTO category)
        {
            await _service.AddCategory(category);
        }
        [HttpPut("{id}")]
        public async Task UpdateCategory(int id, [FromBody] CategoryDTO category)
        {
            await _service.UpdateCategory(category, id);
        }
        [HttpDelete("{id}")]
        public async Task DeleteCategory(int id)
        {
            await _service.DeleteCategory(id);
        }
        [HttpGet("{id}")]
        public async Task<CategoryDTO> GetCategory(int id)
        {
            return await _service.GetCategory(id);
        }
        [HttpGet("all")]
        public async Task<List<CategoryDTO>> GetAllCategory()
        {
            return await _service.GetAllCategory();
        }
    }
}