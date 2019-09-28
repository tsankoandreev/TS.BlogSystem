using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Common;
using TS.BlogSystem.Core.Entities;
using TS.BlogSystem.Core.Interfaces;
using TS.BlogSystem.Core.Interfaces.Repository;
using TS.BlogSystem.Core.Interfaces.Services;

namespace TS.BlogSystem.Services
{
    public class CategoryService : PagedService<Category>, ICategoryService
    {
        private readonly IAsyncRepository<Category> _categoryRepository;

        public CategoryService(IAsyncRepository<Category> categoryRepository)
            : base(categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task Delete(Category category)
        {
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categoryRepository.ListAllAsync();
        }

        public async Task<Category> GetById(Guid categoryId)
        {
            return await _categoryRepository.GetByIdAsync(categoryId);
        }

        public async Task Insert(Category category)
        {
            await _categoryRepository.AddAsync(category);
        }

        public async Task Update(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
