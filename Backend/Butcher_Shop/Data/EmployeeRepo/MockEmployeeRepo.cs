using Butcher_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.EmployeeRepo
{
    public class MockEmployeeRepo : IEmployeeRepo
    {
        private readonly DatabaseContext _context;

        public MockEmployeeRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee Employee)
        {
            var AddedEmployee = await _context.Employees.AddAsync(Employee);

            if (AddedEmployee != null)
            {
                await _context.SaveChangesAsync();
                return AddedEmployee.Entity;
            }
            return null;
        }

        public Task<bool> AddEmployeeToButcherStore(int ButcherStoreId, Employee Employee)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteEmployee(int Id)
        {
            var FoundEmployee = await _context.Employees.FindAsync(Id);

            if (FoundEmployee != null)
            {
                _context.Employees.Remove(FoundEmployee);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int Id)
        {
            var FoundEmployee = await _context.Employees.FindAsync(Id);

            if (FoundEmployee != null)
            {
                return FoundEmployee;
            }

            return null;
        }

        public async Task<Employee> UpdateEmployee(int Id, Employee Employee)
        {
            var UpdatedEmployee = _context.Employees.Update(Employee);
            await _context.SaveChangesAsync();

            return UpdatedEmployee.Entity;
        }
    }
}
