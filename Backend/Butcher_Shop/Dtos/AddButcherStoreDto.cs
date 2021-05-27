using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Butcher_Shop.Models;

namespace Butcher_Shop.Dtos
{
    public class AddButcherStoreDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(64)]
        public string Address { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Area { get; set; }
    }
}
