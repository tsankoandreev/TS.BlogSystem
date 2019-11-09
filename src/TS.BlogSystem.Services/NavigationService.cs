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
    public class NavigationService : INavigationService
    {
        private readonly IAsyncRepository<NavItem> _navItemRepository;

        public NavigationService(IAsyncRepository<NavItem> navItemRepository)
        {
            this._navItemRepository = navItemRepository;
        }

        public async Task<NavItem> GetById(Guid entityId)
        {
            return await _navItemRepository.GetByIdAsync(entityId);
        }

        public async Task<List<NavItem>> GetAll()
        {
            return await _navItemRepository.ListAllAsync();
        }

        public async Task Insert(NavItem entity)
        {
            await _navItemRepository.AddAsync(entity);
        }

        public async Task Update(NavItem entity)
        {
            await _navItemRepository.UpdateAsync(entity);
        }
        public async Task Delete(NavItem entity)
        {
            await _navItemRepository.DeleteAsync(entity);
        }

    }
}
