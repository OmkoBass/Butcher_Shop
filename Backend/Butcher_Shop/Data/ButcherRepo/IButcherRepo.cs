using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.ButcherRepo
{
    public interface IButcherRepo
    {
        public Task<List<Butcher>> GetAllButchers();
        public Task<Butcher> GetButcher(int Id);
        public Task<Butcher> AddButcher(Butcher Butcher);
        public Task<Butcher> UpdateButcher(Butcher Butcher);
        public Task<bool> DeleteButcher(int Id);
    }
}
