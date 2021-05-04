using Butcher_Shop.Data.EmployeeRepo;
using Butcher_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var AllEmployees = await _employeeRepo.GetAllEmployees();

            return Ok(AllEmployees);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetEmployeeById(int Id)
        {
            var Employee = await _employeeRepo.GetEmployee(Id);

            if (Employee != null)
            {
                return Ok(Employee);
            }

            return NotFound(new { Message = $"Employee with Id:{Id} not found!" });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee Employee)
        {
            if (ModelState.IsValid)
            {
                var AddedEmployee = await _employeeRepo.AddEmployee(Employee);

                if (AddedEmployee != null)
                {
                    return Ok(AddedEmployee);
                }
                else
                {
                    return BadRequest(new { Message = "Something went wrong!" });
                }
            }

            return BadRequest(new { Message = "Not valid!" });
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int Id, [FromBody] Employee Employee)
        {
            if (ModelState.IsValid && (Id == Employee.Id))
            {
                var UpdatedEmployee = await _employeeRepo.UpdateEmployee(Id, Employee);

                if (UpdatedEmployee != null)
                {
                    return Ok(UpdatedEmployee);
                }

                return BadRequest(new { Message = "Something went wrong!" });
            }

            return BadRequest(new { Message = "Not valid!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var DeletedEmployee = await _employeeRepo.DeleteEmployee(Id);

            if (DeletedEmployee)
            {
                return Ok(new { Message = "Employee deleted!" });
            }

            return NotFound(new { Message = "Employee not found!" });
        }
    }
}
