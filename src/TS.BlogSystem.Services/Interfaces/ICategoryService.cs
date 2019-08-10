using System;
using System.Collections.Generic;
using System.Text;
using TS.BlogSystem.Core.Entities;

namespace TS.BlogSystem.Services.Interfaces
{
    public interface ICategoryService
    {
        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="category">Category</param>
        void DeleteCategory(Category category);
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
        void InsertCategory(Category category);

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <param name="category">Category</param>
        void UpdateCategory(Category category);

        /// <summary>
        /// retrieves all Categories
        /// </summary>
        /// <returns></returns>
        List<Category> GetAll();
    }
}
