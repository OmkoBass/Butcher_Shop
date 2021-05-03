using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.StorageRepo
{
    public interface IStorageRepo
    {
        public Task<List<Storage>> GetAllStorages();
        public Task<Storage> GetStorage(int Id);
        public Task<Storage> AddStorage(Storage Storage);
        public Task<Storage> UpdateStorage(int Id, Storage Storage);
        public Task<bool> DeleteStorage(int Id);
    }
}
