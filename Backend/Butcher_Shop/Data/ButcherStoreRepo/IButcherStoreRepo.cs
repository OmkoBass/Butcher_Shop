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
        public Task<bool> AddButcherStore(ButcherStore ButcherStore);
        public bool UpdateButcherStore(ButcherStore ButcherStore);
        public bool DeleteButcherStore(ButcherStore ButcherStore);
        public Task<List<ButcherStore>> GetButcherStoresByButcher(int ButcherId);
    }
}
