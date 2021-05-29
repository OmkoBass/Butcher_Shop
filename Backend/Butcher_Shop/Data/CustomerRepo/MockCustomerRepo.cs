using Butcher_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.CustomerRepo
{
    public class MockCustomerRepo : ICustomerRepo
    {
        private readonly DatabaseContext _context;

        public MockCustomerRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCustomer(Customer Customer)
        {
            await _context.Customers.AddAsync(Customer);
            return true;
        }

        public bool DeleteCustomer(Customer Customer)
        {
            _context.Customers.Remove(Customer);
            return true;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(int Id)
        {
            return await _context.Customers.Include(c => c.BoughtArticles).FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<Customer> GetCustomerByInfo(string Name, string Lastname, string Address)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Name == Name
                && c.Lastname == Lastname
                && c.Address == Address
            );
        }

        public bool UpdateCustomer(Customer Customer)
        {
            _context.Customers.Update(Customer);
            return true;
        }
    }
}
