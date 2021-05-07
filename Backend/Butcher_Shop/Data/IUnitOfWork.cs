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
    public interface IUnitOfWork
    {
        IButcherRepo IButcherRepo { get; set; }
        IButcherStoreRepo IButcherStoreRepo { get; set; }
        IArticleRepo IArticleRepo { get; set; }
        IStorageRepo IStorageRepo { get; set; }
        IAuthRepo IAuthRepo { get; set; }
        IEmployeeRepo IEmployeeRepo { get; set; }

        Task<bool> Complete();
    }
}
