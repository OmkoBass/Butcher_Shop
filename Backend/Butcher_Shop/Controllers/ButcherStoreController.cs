using Butcher_Shop.Data.ButcherStoreRepo;
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
        public ButcherStoreController(IButcherStoreRepo butcherStoreRepo)
        {
            _butcherStoreRepo = butcherStoreRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _butcherStoreRepo.GetAllButcherStores());
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int Id)
        {
            var ButcherStore = await _butcherStoreRepo.GetButcherStore(Id);

            if (ButcherStore != null)
            {
                return Ok(ButcherStore);
            }

            return NotFound(new { Message = $"Butcher Store with Id:{Id} not found!" });
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
        public async Task<IActionResult> Put(int id, [FromBody] ButcherStore ButcherStore)
        {
            if (ModelState.IsValid)
            {
                var UpdatedButcherStore = await _butcherStoreRepo.UpdateButcherStore(ButcherStore);

                if (UpdatedButcherStore != null)
                {
                    return Ok(UpdatedButcherStore);
                }

                return BadRequest(new { Message = "Something went wrong!" });
            }

            return BadRequest(new { Message = "Something went wrong!" });
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
