using Butcher_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.StorageRepo
{
    public class MockStorageRepo : IStorageRepo
    {
        private readonly DatabaseContext _context;

        public MockStorageRepo(DatabaseContext context) => _context = context;

        public async Task<Storage> AddStorage(Storage Storage)
        {
            var AddedStorage = await _context.Storages.AddAsync(Storage);

            if (AddedStorage != null)
            {
                await _context.SaveChangesAsync();
                return AddedStorage.Entity;
            }
            return null;
        }

        public async Task<bool> DeleteStorage(int Id)
        {
            var FoundStorage = await _context.Storages.FindAsync(Id);

            if (FoundStorage != null)
            {
                _context.Storages.Remove(FoundStorage);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<Storage>> GetAllStorages()
        {
            return await _context.Storages.Include(s => s.StorageArticles).ToListAsync();
        }

        public async Task<Storage> GetStorage(int Id)
        {
            var FoundStorage = await _context.Storages.FindAsync(Id);

            if (FoundStorage != null)
            {
                return await _context.Storages.Include(s => s.StorageArticles).FirstOrDefaultAsync(i => i.Id == Id);
            }

            return null;
        }

        public async Task<Storage> UpdateStorage(int Id, Storage Storage)
        {
            var FoundStorage = await _context.Storages.FindAsync(Id);

            if (FoundStorage != null)
            {
                var UpdatedStorage = _context.Storages.Update(Storage);
                await _context.SaveChangesAsync();

                return UpdatedStorage.Entity;
            }

            return null;
        }
    }
}
