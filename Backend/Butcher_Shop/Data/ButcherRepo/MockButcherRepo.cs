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

        public async Task<bool> AddButcher(Butcher Butcher)
        {
            await _context.Butchers.AddAsync(Butcher);
            return true;
        }

        public bool DeleteButcher(Butcher Butcher)
        {
            _context.Butchers.Remove(Butcher);
            return true;
        }

        public async Task<List<Butcher>> GetAllButchers(bool IncludeAll)
        {
            if(IncludeAll)
            {
                return await _context.Butchers.Include(b => b.ButcherStores).ToListAsync();
            }
            return await _context.Butchers.ToListAsync();
        }

        public async Task<Butcher> GetButcher(int Id, bool IncludeAll)
        {
            if (IncludeAll)
            {
                return await _context.Butchers.Include(b => b.ButcherStores).FirstOrDefaultAsync(i => i.Id == Id);
            }

            return await _context.Butchers.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public bool UpdateButcher(Butcher Butcher)
        {
            _context.Butchers.Update(Butcher);
            return true;
        }
    }
}
