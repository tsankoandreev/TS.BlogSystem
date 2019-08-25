using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Entities;

namespace TS.BlogSystem.Core.Interfaces.Services
{
    public interface ICategoryService:IPagedService<Category>
    {
        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="category">Category</param>
        Task DeleteCategory(Category category);
        /// <summary>
        /// Gets a category
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>Category</returns>
        Category GetCategoryById(Guid categoryId);

        /// <summary>
        /// Inserts category
        /// </summary>
        /// <param name="category">Category</param>
        Task InsertCategory(Category category);

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <param name="category">Category</param>
        Task UpdateCategory(Category category);

        /// <summary>
        /// retrieves all Categories
        /// </summary>
        /// <returns></returns>
        Task<List<Category>> GetAll();
    }
}
