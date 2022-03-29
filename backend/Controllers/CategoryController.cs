using backend.DTO;
using backend.Interfaces;
using backend.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Enums;

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
        [Authorize(Role.Admin)]
        [HttpPost]
        public async Task AddCategory([FromBody] CategoryDTO category)
        {
            await _service.AddCategory(category);
        }
        [Authorize(Role.Admin)]
        [HttpPut("{id}")]
        public async Task UpdateCategory(int id, [FromBody] CategoryDTO category)
        {
            await _service.UpdateCategory(category, id);
        }
        [Authorize(Role.Admin)]
        [HttpDelete("{id}")]
        public async Task DeleteCategory(int id)
        {
            await _service.DeleteCategory(id);
        }
        [Authorize(Role.Admin)]
        [HttpGet("{id}")]
        public async Task<CategoryDTO> GetCategory(int id)
        {
            return await _service.GetCategory(id);
        }
        [Authorize(Role.Admin)]
        [HttpGet("all")]
        public async Task<List<CategoryDTO>> GetAllCategory()
        {
            return await _service.GetAllCategory();
        }
    }
}