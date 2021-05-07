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
        public Task<bool> AddEmployee(Employee Employee);
        public bool UpdateEmployee(Employee Employee);
        public bool DeleteEmployee(Employee Employee);
    }
}
