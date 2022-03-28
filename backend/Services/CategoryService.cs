using backend.Data;
using backend.DTO;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class CategoryService : ICategoryService
    {
        private MyDbContext _service;
        public CategoryService(MyDbContext service)
        {
            _service = service;
        }
        public async Task AddCategory(CategoryDTO category)
        {
            await _service.Categories.AddAsync(category.CategoryDTOToEntity());
            await _service.SaveChangesAsync();
        }
        public async Task UpdateCategory(CategoryDTO category, int id)
        {
            var categoryToUpdate = await _service.Categories.FindAsync(id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate = category.CategoryDTOToEntity();
                categoryToUpdate.CategoryId = id;
                _service.Categories.Update(categoryToUpdate);
                await _service.SaveChangesAsync();
            }
        }
        public async Task DeleteCategory(int id)
        {
            var categoryToDelete = await _service.Categories.FindAsync(id);
            if (categoryToDelete != null)
            {
                _service.Categories.Remove(categoryToDelete);
                await _service.SaveChangesAsync();
            }
        }
        public async Task<CategoryDTO> GetCategory(int id)
        {
            var foundCategory = await _service.Categories.FindAsync(id);
            if (foundCategory != null)
                return foundCategory.CategoryEntityToDTO();
            return null;
        }
        public async Task<List<CategoryDTO>> GetAllCategory()
        {
            return await _service.Categories.Select(category => category.CategoryEntityToDTO()).ToListAsync();
        }
    }
}