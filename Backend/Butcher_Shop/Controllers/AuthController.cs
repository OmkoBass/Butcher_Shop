using Butcher_Shop.Data.AuthRepo;
using Butcher_Shop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;
        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("/authenticate")]
        public async Task<IActionResult> Login([FromBody] AuthButcher Butcher)
        {
            var token = await _authRepo.Authenticate(Butcher.Username, Butcher.Password);

            if (token != null)
                return Ok(new { Token = token });
            return Unauthorized(new { Message = "Unauthorized!" });
        }
    }
}
