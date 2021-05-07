using Butcher_Shop.Data.ArticleRepo;
using Butcher_Shop.Data.AuthRepo;
using Butcher_Shop.Data.ButcherRepo;
using Butcher_Shop.Data.ButcherStoreRepo;
using Butcher_Shop.Data.EmployeeRepo;
using Butcher_Shop.Data.StorageRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data
{
    public class MockUnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public IButcherRepo IButcherRepo { get; set; }
        public IButcherStoreRepo IButcherStoreRepo { get; set; }
        public IArticleRepo IArticleRepo { get; set; }
        public IStorageRepo IStorageRepo { get; set; }
        public IAuthRepo IAuthRepo { get; set; }
        public IEmployeeRepo IEmployeeRepo { get; set; }

        public MockUnitOfWork(DatabaseContext context, 
            IButcherRepo butcherRepo,
            IButcherStoreRepo butcherStoreRepo,
            IArticleRepo articleRepo,
            IStorageRepo storageRepo,
            IAuthRepo authRepo,
            IEmployeeRepo employeeRepo
            )
        {
            _context = context;
            IButcherRepo = butcherRepo;
            IButcherStoreRepo = butcherStoreRepo;
            IArticleRepo = articleRepo;
            IStorageRepo = storageRepo;
            IAuthRepo = authRepo;
            IEmployeeRepo = employeeRepo;
        }

        public async Task<bool> Complete()
        {
            var save = await _context.SaveChangesAsync();

            if (save == 1)
                return true;
            return false;
        }
    }
}
