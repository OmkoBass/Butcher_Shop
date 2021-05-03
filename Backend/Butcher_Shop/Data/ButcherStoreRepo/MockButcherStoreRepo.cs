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
        public async Task<ButcherStore> AddButcherStore(ButcherStore ButcherStore)
        {
            var AddedButcherStore = await _context.ButcherStores.AddAsync(ButcherStore);

            if(AddedButcherStore != null)
            {
                await _context.SaveChangesAsync();

                return AddedButcherStore.Entity;
            }
            return null;
        }

        public async Task<bool> DeleteButcherStore(int Id)
        {
            var FoundButhcer = await _context.ButcherStores.FindAsync(Id);

            if (FoundButhcer != null)
            {
                _context.ButcherStores.Remove(FoundButhcer);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<ButcherStore>> GetAllButcherStores()
        {
            return await _context.ButcherStores.ToListAsync();
        }

        public async Task<ButcherStore> GetButcherStore(int Id)
        {
            var FoundButcherStore = await _context.ButcherStores.FindAsync(Id);

            if(FoundButcherStore != null)
            {
                return FoundButcherStore;
            }

            return null;
        }

        public async Task<ButcherStore> UpdateButcherStore(int Id, ButcherStore ButcherStore)
        {
            var FoundButcherStore = await _context.ButcherStores.FindAsync(ButcherStore.Id);

            if (FoundButcherStore != null)
            {
                var UpdatedButcherStores = _context.ButcherStores.Update(FoundButcherStore);
                await _context.SaveChangesAsync();

                return UpdatedButcherStores.Entity;
            }

            return null;
        }
    }
}
