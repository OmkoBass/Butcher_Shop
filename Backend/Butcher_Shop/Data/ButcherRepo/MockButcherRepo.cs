using Butcher_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.ButcherRepo
{
    public class MockButcherRepo : IButcherRepo
    {
        private readonly DatabaseContext _context;
        public MockButcherRepo(DatabaseContext context) => _context = context;

        public async Task<Butcher> AddButcher(Butcher Butcher)
        {
            var AddedButcher = await _context.Butchers.AddAsync(Butcher);

            if (AddedButcher != null)
            {
                await _context.SaveChangesAsync();
                return AddedButcher.Entity;
            }
            return null;
        }

        public async Task<bool> DeleteButcher(int Id)
        {
            var FoundButcher = await _context.Butchers.FindAsync(Id);

            if(FoundButcher != null)
            {
                _context.Butchers.Remove(FoundButcher);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<Butcher>> GetAllButchers()
        {
            return await _context.Butchers.Include(b => b.ButcherStores).ToListAsync();
        }

        public async Task<Butcher> GetButcher(int Id)
        {
            var FoundButcher = await _context.Butchers.FindAsync(Id);

            if (FoundButcher != null)
            {
                return await _context.Butchers.Include(b => b.ButcherStores).FirstOrDefaultAsync(i => i.Id == Id);
            }

            return null;
        }

        public async Task<Butcher> UpdateButcher(int ButcherId, Butcher Butcher)
        {
            var UpdatedButcher = _context.Butchers.Update(Butcher);
            await _context.SaveChangesAsync();

            return UpdatedButcher.Entity;
        }
    }
}
