using AutoMapper;
using Butcher_Shop.Data;
using Butcher_Shop.Dtos;
using Butcher_Shop.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ButcherStoreController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ButcherStoreController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var AllButcherStores = await _unitOfWork.IButcherStoreRepo.GetAllButcherStores();

            return Ok(_mapper.Map<List<ButcherStoreDto>>(AllButcherStores));
        }

        [HttpGet]
        [Route("loggedIn")]
        public async Task<IActionResult> ButcherStores()
        {
            var Id = Int32.Parse(User.FindFirst("Id").Value);

            var ButcherStores = await _unitOfWork.IButcherStoreRepo.GetButcherStoresByButcher(Id);

            return Ok(ButcherStores);
        }

        [HttpGet("complete/butcherStores")]
        public async Task<IActionResult> GetCompleteButcherStores()
        {
            var Id = Int32.Parse(User.FindFirst("Id").Value);

            var ButcherStores = await _unitOfWork.IButcherStoreRepo.GetButcherStoresByButcher(Id, true, true);

            int ButcherStoresCount = ButcherStores.Count;
            int EmployeeCount = 0;
            int StorageCount = 0;
            int CustomerCount = 0;
            int ArticleCount = 0;

            foreach(ButcherStore bs in ButcherStores)
            {
                EmployeeCount += bs.Employees.Count;
                StorageCount += bs.Storages.Count;
                CustomerCount += bs.Customers.Count;

                foreach(Storage s in bs.Storages)
                    ArticleCount += s.Articles.Count;
            }

            return Ok(new Object[] {
                new
                {
                    Name = "butcherStores",
                    Value = ButcherStoresCount
                },
                new
                {
                    Name = "employees",
                    Value = EmployeeCount
                },
                new
                {
                    Name = "storages",
                    Value = StorageCount
                },
                new
                {
                    Name = "customers",
                    Value = CustomerCount
                },
                new
                {
                    Name = "articles",
                    Value = ArticleCount
                },
            });
        }

        [HttpGet(":id")]
        public async Task<IActionResult> Get(int Id)
        {
            var ButcherStore = await _unitOfWork.IButcherStoreRepo.GetButcherStore(Id);

            if (ButcherStore != null)
            {
                return Ok(_mapper.Map<ButcherStoreDto>(ButcherStore));
            }

            return NotFound(new { Message = $"Butcher Store with Id:{Id} not found." });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddButcherStoreDto ButcherStore)
        {
            if(ModelState.IsValid)
            {
                int ButcherStoreId = int.Parse(User.FindFirst("Id").Value);

                var AddedButcherStore = _mapper.Map<ButcherStore>(ButcherStore);
                AddedButcherStore.ButcherId = ButcherStoreId;

                await _unitOfWork.IButcherStoreRepo.AddButcherStore(AddedButcherStore);
                await _unitOfWork.Complete();

                return Ok(AddedButcherStore);
            }

            return BadRequest(new { Message = "Invalid info!" });
        }

        [HttpPut(":id")]
        public async Task<IActionResult> Put(int Id, [FromBody] AddButcherStoreDto ButcherStore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid info!" });
            }

            var OldButcherStore = await _unitOfWork.IButcherStoreRepo.GetButcherStore(Id);

            if(OldButcherStore == null)
            {
                return NotFound(new { Message = $"Butcher Store with Id:{Id} not found." });
            }

            _mapper.Map<AddButcherStoreDto, ButcherStore>(ButcherStore, OldButcherStore);

            await _unitOfWork.Complete();

            return Ok(OldButcherStore);
        }

        [HttpDelete(":id")]
        public async Task<IActionResult> Delete(int Id)
        {
            var ButcherStore = await _unitOfWork.IButcherStoreRepo.GetButcherStore(Id);

            if (ButcherStore != null)
            {
                _unitOfWork.IButcherStoreRepo.DeleteButcherStore(ButcherStore);
                await _unitOfWork.Complete();

                return Ok(ButcherStore);
            }

            return NotFound(new { Message = $"Butcher Store with Id:{Id} not found." });
        }
    }
}
