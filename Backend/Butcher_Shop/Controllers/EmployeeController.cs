using AutoMapper;
using Butcher_Shop.Data;
using Butcher_Shop.Dtos;
using Butcher_Shop.Models;
using Butcher_Shop.Migrations;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var AllEmployees = await _unitOfWork.IEmployeeRepo.GetAllEmployees();

            return Ok(AllEmployees);
        }

        [HttpGet(":id")]
        public async Task<IActionResult> Get(int Id)
        {
            var Employee = await _unitOfWork.IEmployeeRepo.GetEmployee(Id);

            if (Employee != null)
            {
                return Ok(Employee);
            }

            return NotFound(new { Message = $"Employee Store with Id:{Id} not found." });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllEmployeesForButcherStore()
        {
            int ButcherStoreId = int.Parse(User.FindFirst("Id").Value);

            var ButcherStores = await _unitOfWork.IButcherStoreRepo.GetButcherStoresByButcher(ButcherStoreId);

            List<Models.Employee> Employees = new List<Models.Employee>();

            foreach(var ButcherStore in ButcherStores)
            {
                foreach(var Employee in ButcherStore.Employees)
                {
                    Employees.Add(Employee);
                }
            }

            return Ok(Employees);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDto Employee)
        {
            if (ModelState.IsValid)
            {
                var AddedEmployee = _mapper.Map<Butcher_Shop.Models.Employee>(Employee);

                await _unitOfWork.IEmployeeRepo.AddEmployee(AddedEmployee);
                await _unitOfWork.Complete();

                return Ok(AddedEmployee);
            }

            return BadRequest(new { Message = "Invalid info!" });
        }

        [HttpPut(":id")]
        public async Task<IActionResult> Put(int Id, [FromBody] EmployeeDto Employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid info!" });
            }

            var OldEmployee = await _unitOfWork.IEmployeeRepo.GetEmployee(Id);

            if (OldEmployee == null)
            {
                return NotFound(new { Message = $"Employee with Id:{Id} not found." });
            }

            _mapper.Map<EmployeeDto, Butcher_Shop.Models.Employee>(Employee, OldEmployee);

            await _unitOfWork.Complete();

            return Ok(OldEmployee);
        }

        [HttpDelete(":id")]
        public async Task<IActionResult> Delete(int Id)
        {
            var Employee = await _unitOfWork.IEmployeeRepo.GetEmployee(Id);

            if (Employee != null)
            {
                _unitOfWork.IEmployeeRepo.DeleteEmployee(Employee);
                await _unitOfWork.Complete();

                return Ok(Employee);
            }

            return NotFound(new { Message = $"Employee with Id:{Id} not found." });
        }
    }
}
