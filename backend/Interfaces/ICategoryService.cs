using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.DB.DTO;

namespace Back_end.Interface
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