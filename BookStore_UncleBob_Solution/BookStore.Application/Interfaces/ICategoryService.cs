using BookStore.Application.DTOs;
using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<Category> AddCategoryAsync(CategoryDto category);
        Task UpdateCategoryAsync(CategoryDto category);
        Task DeleteCategory(int id);
    }
}
