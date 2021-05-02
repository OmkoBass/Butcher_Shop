﻿using Butcher_Shop.Data.ButcherRepo;
using Butcher_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Butcher_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ButcherController : ControllerBase
    {
        private readonly IButcherRepo _butcherRepo;
        public ButcherController(IButcherRepo butcherRepo) => _butcherRepo = butcherRepo;

        [HttpGet]
        public async Task<IActionResult> GetAllButchers()
        {
            return Ok(await _butcherRepo.GetAllButchers());
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int Id)
        {
            var Butcher = await _butcherRepo.GetButcher(Id);

            if(Butcher != null)
            {
                return Ok(Butcher);
            }

            return NotFound(new { Message = $"Butcher with Id:{Id} not found!" });
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Butcher Butcher)
        {
            if (ModelState.IsValid)
            {
                var AddedButcher = await _butcherRepo.AddButcher(Butcher);

                if (AddedButcher != null)
                {
                    return Ok(AddedButcher);
                } else
                {
                    return BadRequest(new { Message = "Something went wrong!" });
                }
            }

            return BadRequest(new { Message = "Something went wrong!" });
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int Id, [FromBody] Butcher Butcher)
        {
            if (ModelState.IsValid)
            {
                var UpdatedButcher = await _butcherRepo.UpdateButcher(Butcher);

                if(UpdatedButcher != null)
                {
                    return Ok(UpdatedButcher);
                }

                return BadRequest(new { Message = "Something went wrong!" });
            }

            return BadRequest(new { Message = "Something went wrong!" });
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int Id)
        {
            var DeletedButcher = await _butcherRepo.DeleteButcher(Id);

            if (DeletedButcher)
            {
                return Ok(new { Message = "Butcher deleted!" });
            }

            return BadRequest(new { Message = "Something went wrong!" });
        }
    }
}