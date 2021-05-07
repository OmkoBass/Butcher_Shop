using AutoMapper;
using Butcher_Shop.Data;
using Butcher_Shop.Dtos.Storage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Butcher_Shop.Models;

namespace Butcher_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StorageController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var AllStorages = await _unitOfWork.IStorageRepo.GetAllStorages();

            return Ok(AllStorages);
        }

        [HttpGet(":id")]
        public async Task<IActionResult> Get(int Id)
        {
            var Storage = await _unitOfWork.IStorageRepo.GetStorage(Id);

            if (Storage != null)
            {
                return Ok(Storage);
            }

            return NotFound(new { Message = $"Storage with Id:{Id} not found." });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddStorageDto Storage)
        {
            if (ModelState.IsValid)
            {
                var AddedStorage = _mapper.Map<Storage>(Storage);

                await _unitOfWork.IStorageRepo.AddStorage(AddedStorage);
                await _unitOfWork.Complete();

                return Ok(AddedStorage);
            }

            return BadRequest(new { Message = "Invalid info!" });
        }

        [HttpPut(":id")]
        public async Task<IActionResult> Put(int Id, [FromBody] AddStorageDto Storage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid info!" });
            }

            var OldStorage = await _unitOfWork.IStorageRepo.GetStorage(Id);

            if (OldStorage == null)
            {
                return NotFound(new { Message = $"Storage with Id:{Id} not found." });
            }

            _mapper.Map<AddStorageDto, Storage>(Storage, OldStorage);

            await _unitOfWork.Complete();

            return Ok(OldStorage);
        }

        [HttpDelete(":id")]
        public async Task<IActionResult> Delete(int Id)
        {
            var Storage = await _unitOfWork.IStorageRepo.GetStorage(Id);

            if (Storage != null)
            {
                _unitOfWork.IStorageRepo.DeleteStorage(Storage);
                await _unitOfWork.Complete();

                return Ok(Storage);
            }

            return NotFound(new { Message = $"Storage with Id:{Id} not found." });
        }
    }
}
