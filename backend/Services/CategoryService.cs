using backend.Data;
using backend.DTO;
using backend.Interfaces;
using backend.Utilities;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class CategoryService : ICategoryService
    {
        private MyDbContext _context;
        public CategoryService(MyDbContext context)
        {
            _context = context;
        }
        public async Task AddCategory(CategoryDTO category)
        {
            await _context.Categories.AddAsync(category.CategoryDTOToEntity());
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCategory(CategoryDTO category, int id)
        {
            var categoryToUpdate = await _context.Categories.FindAsync(id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate = category.CategoryDTOToEntity();
                categoryToUpdate.CategoryId = id;
                _context.Categories.Update(categoryToUpdate);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteCategory(int id)
        {
            var categoryToDelete = await _context.Categories.FindAsync(id);
            if (categoryToDelete != null)
            {
                _context.Categories.Remove(categoryToDelete);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<CategoryDTO> GetCategory(int id)
        {
            var foundCategory = await _context.Categories.FindAsync(id);
            if (foundCategory != null)
                return foundCategory.CategoryEntityToDTO();
            return null;
        }
        public async Task<List<CategoryDTO>> GetAllCategory()
        {
            return await _context.Categories.Select(category => category.CategoryEntityToDTO()).ToListAsync();
        }
    }
}