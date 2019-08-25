using System;
using System.Collections.Generic;
using TS.BlogSystem.Core.Entities;
using TS.BlogSystem.Core.Interfaces.Repository;
using TS.BlogSystem.Core.Interfaces.Services;

namespace TS.BlogSystem.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IAsyncRepository<Category> _categoryRepository;

        public CategoryService(IAsyncRepository<Category> categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return  _categoryRepository.ListAllAsync().Result;
        }

        public Category GetCategoryById(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public void InsertCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
