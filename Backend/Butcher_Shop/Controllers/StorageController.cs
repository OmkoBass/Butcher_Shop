using AutoMapper;
using Butcher_Shop.Data.StorageRepo;
using Butcher_Shop.Dtos;
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
    public class StorageController : ControllerBase
    {
        private readonly IStorageRepo _storageRepo;
        private readonly IMapper _mapper;
        public StorageController(IStorageRepo storageRepo, IMapper mapper)
        {
            _storageRepo = storageRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStorages()
        {
            var AllStorages = await _storageRepo.GetAllStorages();

            return Ok(_mapper.Map<List<StorageDto>>(AllStorages));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetStorage(int Id)
        {
            var Storage = await _storageRepo.GetStorage(Id);

            if (Storage != null)
            {
                return Ok(_mapper.Map<StorageDto>(Storage));
            }

            return NotFound(new { Message = $"Storage with Id:{Id} not found!" });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Storage Storage)
        {
            if (ModelState.IsValid)
            {
                var AddedStorage = await _storageRepo.AddStorage(_mapper.Map<Storage>(Storage));

                if (AddedStorage != null)
                {
                    return Ok(AddedStorage);
                }
                else
                {
                    return BadRequest(new { Message = "Something went wrong!" });
                }
            }

            return BadRequest(new { Message = "Not valid!" });
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int Id, [FromBody] Storage Storage)
        {
            if (ModelState.IsValid)
            {
                var UpdatedStorage = await _storageRepo.UpdateStorage(Id, Storage);

                if (UpdatedStorage != null)
                {
                    return Ok(UpdatedStorage);
                }

                return BadRequest(new { Message = "Something went wrong!" });
            }

            return BadRequest(new { Message = "Not valid!" });
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int Id)
        {
            var DeletedStorage = await _storageRepo.DeleteStorage(Id);

            if (DeletedStorage)
            {
                return Ok(new { Message = "Storage deleted!" });
            }

            return NotFound(new { Message = "Storage not found!" });
        }
    }
}
