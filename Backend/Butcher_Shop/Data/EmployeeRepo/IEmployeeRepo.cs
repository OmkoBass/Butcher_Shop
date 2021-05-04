using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.EmployeeRepo
{
    public interface IEmployeeRepo
    {
        public Task<List<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployee(int Id);
        public Task<Employee> AddEmployee(Employee Employee);
        public Task<Employee> UpdateEmployee(int Id, Employee Employee);
        public Task<bool> DeleteEmployee(int Id);
        public Task<bool> AddEmployeeToButcherStore(int ButcherStoreId, Employee Employee);
    }
}
