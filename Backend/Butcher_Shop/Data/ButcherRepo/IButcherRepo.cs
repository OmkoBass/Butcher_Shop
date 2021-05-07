using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.ButcherRepo
{
    public interface IButcherRepo
    {
        public Task<List<Butcher>> GetAllButchers(bool IncludeAll = true);
        public Task<Butcher> GetButcher(int Id, bool IncludeAll = true);
        public Task<bool> AddButcher(Butcher Butcher);
        public bool UpdateButcher(Butcher Butcher);
        public bool DeleteButcher(Butcher Butcher);
    }
}
