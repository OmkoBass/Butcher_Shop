using Butcher_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.ButcherStoreRepo
{
    public class MockButcherStoreRepo : IButcherStoreRepo
    {
        private readonly DatabaseContext _context;
        public MockButcherStoreRepo(DatabaseContext context) => _context = context;

        public async Task<bool> AddButcherStore(ButcherStore ButcherStore)
        {
            await _context.ButcherStores.AddAsync(ButcherStore);
            return true;
        }

        public bool DeleteButcherStore(ButcherStore ButcherStore)
        {
            _context.ButcherStores.Remove(ButcherStore);
            return true;
        }

        public async Task<List<ButcherStore>> GetAllButcherStores()
        {
            return await _context.ButcherStores.Include(bs => bs.Employees).ToListAsync();
        }

        public async Task<ButcherStore> GetButcherStore(int Id)
        {
            return await _context.ButcherStores
                .Include(bs => bs.Employees)
                .Include(bs => bs.Storages)
                .ThenInclude(s => s.Articles)
                .Include(bs => bs.Customers)
                .FirstOrDefaultAsync(i => i.Id == Id);
        }

        public async Task<List<ButcherStore>> GetButcherStoresByButcher(int ButcherId, bool includeStorages, bool includeCustomers)
        {
            if (includeStorages && includeCustomers)
            {
                return await _context.ButcherStores
                .Where(i => i.ButcherId == ButcherId)
                .Include(bs => bs.Employees)
                .Include(bs => bs.Storages)
                .ThenInclude(s => s.Articles)
                .Include(bs => bs.Customers)
                .ToListAsync();
            }

            return await _context.ButcherStores
                .Where(i => i.ButcherId == ButcherId)
                .Include(bs => bs.Employees)
                .ToListAsync();
        }

        public bool UpdateButcherStore(ButcherStore ButcherStore)
        {
            _context.ButcherStores.Update(ButcherStore);
            return true;
        }
    }
}
