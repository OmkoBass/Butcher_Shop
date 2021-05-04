using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.ButcherStoreRepo
{
    public interface IButcherStoreRepo
    {
        public Task<List<ButcherStore>> GetAllButcherStores();
        public Task<ButcherStore> GetButcherStore(int Id);
        public Task<ButcherStore> AddButcherStore(ButcherStore ButcherStore);
        public Task<ButcherStore> UpdateButcherStore(int Id, ButcherStore ButcherStore);
        public Task<bool> DeleteButcherStore(int Id);
        public Task<List<ButcherStore>> GetAllButcherStoresByButcher(int Id);
    }
}
