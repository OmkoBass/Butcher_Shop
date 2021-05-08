using AutoMapper;
using Butcher_Shop.Data;
using Butcher_Shop.Dtos;
using Butcher_Shop.Dtos.Butcher;
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
    public class ButcherController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ButcherController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var AllButchers = await _unitOfWork.IButcherRepo.GetAllButchers();

            return Ok(_mapper.Map<List<ButcherDto>>(AllButchers));
        }

        [HttpGet]
        [Route("loggedIn")]
        public async Task<IActionResult> GetLoggedIn()
        {
            var Id = User.FindFirst("Id").Value;

            var Butcher = await _unitOfWork.IButcherRepo.GetButcher(Int32.Parse(Id));

            return Ok(_mapper.Map<ButcherDto>(Butcher));
        }

        [HttpGet(":id")]
        public async Task<IActionResult> Get(int Id)
        {
            var Butcher = await _unitOfWork.IButcherRepo.GetButcher(Id);

            if (Butcher != null)
            {
                return Ok(_mapper.Map<ButcherDto>(Butcher));
            }

            return NotFound(new { Message = $"Butcher with Id:{Id} not found." });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddButcherDto Butcher)
        {
            if(ModelState.IsValid)
            {
                var AddedButcher = _mapper.Map<Butcher>(Butcher);

                await _unitOfWork.IButcherRepo.AddButcher(AddedButcher);
                await _unitOfWork.Complete();

                return Ok(AddedButcher);
            }

            return BadRequest(new { Message = "Invalid info!" });
        }

        [HttpPut(":id")]
        public async Task<IActionResult> Put(int Id, [FromBody] AddButcherDto Butcher)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid info!" });
            }

            var OldButcher = await _unitOfWork.IButcherRepo.GetButcher(Id, false);

            if(OldButcher == null)
            {
                return NotFound(new { Message = $"Butcher with Id:{Id} not found." });
            }

            _mapper.Map<AddButcherDto, Butcher>(Butcher, OldButcher);

            await _unitOfWork.Complete();

            return Ok(OldButcher);
        }

        [HttpDelete(":id")]
        public async Task<IActionResult> Delete(int Id)
        {
            var Butcher = await _unitOfWork.IButcherRepo.GetButcher(Id);

            if(Butcher != null)
            {
                _unitOfWork.IButcherRepo.DeleteButcher(Butcher);
                await _unitOfWork.Complete();

                return Ok(_mapper.Map<ButcherDto>(Butcher));
            }

            return NotFound(new { Message = $"Butcher with Id:{Id} not found." });
        }
    }
}
