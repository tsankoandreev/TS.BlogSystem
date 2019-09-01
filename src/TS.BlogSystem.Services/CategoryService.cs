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
    public class CategoryService : ICategoryService
    {
        private readonly IAsyncRepository<Category> _categoryRepository;

        public CategoryService(IAsyncRepository<Category> categoryRepository)
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

        public Task<Category> GetById(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IPagedList<Category>> GetPagedResult(int pageIndex, int pageSize, string orderProperty = "", bool asc = true)
        {
            var totalCount = await _categoryRepository.CountAll();
            var filteredCount = totalCount;//filtered == total
            IPagedList<Category> result = new PagedList<Category>(
                    _categoryRepository.Query().OrderBy(x => x.Name)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize),
                    pageIndex,
                    pageSize,
                    filteredCount,
                    totalCount);

            return result;
        }

        public async Task<IPagedList<Category>> GetPagedResult(int pageIndex, int pageSize, Expression<Func<Category, bool>> filter, string orderProperty = "", bool asc = true)
        {
            var totalCount = await _categoryRepository.CountAll();
            var filteredCount = totalCount;//filtered == total
            IPagedList<Category> result = new PagedList<Category>(
                    _categoryRepository.Query().OrderBy(x => x.Name)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize),
                    pageIndex,
                    pageSize,
                    filteredCount,
                    totalCount);

            return result;
        }

        public async Task<IPagedList<Category>> GetPagedResult(int pageIndex, int pageSize, Expression<Func<Category, bool>> filter, Expression<Func<Category, object>> orderLambda, bool asc = true)
        {

            var totalCount = await _categoryRepository.CountAll();
            var filteredCount = totalCount;//filtered == total
            IPagedList<Category> result = new PagedList<Category>(
                    _categoryRepository.Query().OrderBy(x => x.Name)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize),
                    pageIndex,
                    pageSize,
                    filteredCount,
                    totalCount);

            return result;
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
