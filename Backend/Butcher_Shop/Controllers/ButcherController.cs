using AutoMapper;
using Butcher_Shop.Data.ButcherRepo;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ButcherController : ControllerBase
    {
        private readonly IButcherRepo _butcherRepo;
        private readonly IMapper _mapper;
        public ButcherController(IButcherRepo butcherRepo, IMapper mapper)
        {
            _butcherRepo = butcherRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllButchers()
        {
            var AllButchers = await _butcherRepo.GetAllButchers();

            return Ok(_mapper.Map<List<ButcherDto>>(AllButchers));
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int Id)
        {
            var Butcher = await _butcherRepo.GetButcher(Id);

            if(Butcher != null)
            {
                return Ok(_mapper.Map<ButcherDto>(Butcher));
            }

            return NotFound(new { Message = $"Butcher with Id:{Id} not found!" });
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ButcherDto Butcher)
        {
            if (ModelState.IsValid)
            {
                var AddedButcher = await _butcherRepo.AddButcher(_mapper.Map<Butcher>(Butcher));

                if (AddedButcher != null)
                {
                    return Ok(AddedButcher);
                } else
                {
                    return BadRequest(new { Message = "Something went wrong!" });
                }
            }

            return BadRequest(new { Message = "Not valid!" });
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int Id, [FromBody] Butcher Butcher)
        {
            if (ModelState.IsValid && (Id == Butcher.Id))
            {
                var UpdatedButcher = await _butcherRepo.UpdateButcher(Id, Butcher);

                if(UpdatedButcher != null)
                {
                    return Ok(UpdatedButcher);
                }

                return BadRequest(new { Message = "Something went wrong!" });
            }

            return BadRequest(new { Message = "Not valid!" });
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int Id)
        {
            var DeletedButcher = await _butcherRepo.DeleteButcher(Id);

            if (DeletedButcher)
            {
                return Ok(new { Message = "Butcher deleted!" });
            }

            return NotFound(new { Message = "Butcher not found!" });
        }
    }
}
