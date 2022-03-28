using backend.DTO;

namespace backend.Interfaces
{
    public interface ICategoryService
    {
        public Task AddCategory(CategoryDTO category);
        public Task UpdateCategory(CategoryDTO category, int id);
        public Task DeleteCategory(int id);
        public Task <CategoryDTO> GetCategory(int id);
        public Task<List<CategoryDTO>> GetAllCategory();
    }
}