using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Dtos.Butcher
{
    public class AddButcherDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(16)]
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(64)]
        public string Password { get; set; }
    }
}
