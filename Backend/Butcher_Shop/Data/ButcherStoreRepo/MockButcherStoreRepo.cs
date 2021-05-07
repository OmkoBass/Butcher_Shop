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
            return await _context.ButcherStores.ToListAsync();
        }

        public async Task<ButcherStore> GetButcherStore(int Id)
        {
            return await _context.ButcherStores.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public bool UpdateButcherStore(ButcherStore ButcherStore)
        {
            _context.ButcherStores.Update(ButcherStore);
            return true;
        }
    }
}
