using AutoMapper;
using Butcher_Shop.Data.ButcherStoreRepo;
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
    public class ButcherStoreController : ControllerBase
    {
        private readonly IButcherStoreRepo _butcherStoreRepo;
        private readonly IMapper _mapper;
        public ButcherStoreController(IButcherStoreRepo butcherStoreRepo, IMapper mapper)
        {
            _butcherStoreRepo = butcherStoreRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllButcherStores()
        {
            return Ok(await _butcherStoreRepo.GetAllButcherStores());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetButcherStore(int Id)
        {
            var ButcherStore = await _butcherStoreRepo.GetButcherStore(Id);

            if (ButcherStore != null)
            {
                return Ok(ButcherStore);
            }

            return NotFound(new { Message = $"Butcher Store with Id:{Id} not found!" });
        }

        [HttpGet("ButcherId")]
        public async Task<IActionResult> GetButcherStoreByButcher(int ButcherId)
        {
            var ButcherStores = await _butcherStoreRepo.GetAllButcherStoresByButcher(ButcherId);

            if (ButcherStores != null)
            {
                return Ok(_mapper.Map<List<ButcherStoreDto>>(ButcherStores));
            }

            return NotFound(new { Message = $"Butcher Store with Butcher Id:{ButcherId} not found!" });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ButcherStore ButcherStore)
        {
            if (ModelState.IsValid)
            {
                var AddedButcherStore = await _butcherStoreRepo.AddButcherStore(ButcherStore);

                if (AddedButcherStore != null)
                {
                    return Ok(AddedButcherStore);
                }
                else
                {
                    return BadRequest(new { Message = "Something went wrong!" });
                }
            }

            return BadRequest(new { Message = "Something went wrong!" });
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int Id, [FromBody] ButcherStore ButcherStore)
        {
            if (ModelState.IsValid && (Id == ButcherStore.Id))
            {
                var UpdatedButcherStore = await _butcherStoreRepo.UpdateButcherStore(Id, ButcherStore);

                if (UpdatedButcherStore != null)
                {
                    return Ok(UpdatedButcherStore);
                }

                return BadRequest(new { Message = "Something went wrong!" });
            }

            return BadRequest(new { Message = "Not valid!" });
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int Id)
        {
            var DeletedButcherStore = await _butcherStoreRepo.DeleteButcherStore(Id);

            if(DeletedButcherStore)
            {
                return Ok(new { Message = "Butcher Store deleted!" });
            }

            return NotFound(new { Message = "Butcher Store not found!" });
        }
    }
}
