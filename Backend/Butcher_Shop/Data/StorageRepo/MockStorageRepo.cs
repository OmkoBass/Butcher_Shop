﻿using Butcher_Shop.Models;
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

        public async Task<bool> AddStorage(Storage Storage)
        {
            await _context.Storages.AddAsync(Storage);
            return true;
        }

        public bool DeleteStorage(Storage Storage)
        {
            _context.Storages.Remove(Storage);
            return true;
        }

        public async Task<List<Storage>> GetAllStorages()
        {
            return await _context.Storages.ToListAsync();
        }

        public async Task<Storage> GetStorage(int Id)
        {
            return await _context.Storages.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public bool UpdateStorage(Storage Storage)
        {
            _context.Storages.Update(Storage);
            return true;
        }
    }
}
