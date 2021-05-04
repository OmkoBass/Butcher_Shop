using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.AuthRepo
{
    public class MockAuthRepo : IAuthRepo
    {
        private readonly DatabaseContext _context;

        public MockAuthRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<string> Authenticate(string username, string password)
        {
            var Butcher = await _context.Butchers.FirstOrDefaultAsync(b => b.Username == username && b.Password == password);

            if(Butcher != null)
            {
                // Yes i know, i'm not gonna deploy this, don't worry
                var key = "Testing12 qwe qwkej qiowejio qjweioj ioqjweoi 3";

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("Id", Butcher.Id.ToString()),
                        new Claim("Username", Butcher.Username)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }

            return null;
        }
    }
}
