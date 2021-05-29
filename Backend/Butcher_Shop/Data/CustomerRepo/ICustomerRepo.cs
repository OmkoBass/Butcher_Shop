using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.CustomerRepo
{
    public interface ICustomerRepo
    {
        public Task<List<Customer>> GetAllCustomers();
        public Task<Customer> GetCustomer(int Id);
        public Task<Customer> GetCustomerByInfo(string Name, string Lastname, string Address);
        public Task<bool> AddCustomer(Customer Customer);
        public bool UpdateCustomer(Customer Customer);
        public bool DeleteCustomer(Customer Customer);
    }
}
