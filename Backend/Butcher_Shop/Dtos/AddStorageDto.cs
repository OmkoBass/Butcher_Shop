using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Dtos.Storage
{
    public class AddStorageDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(64)]
        public string Address { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int Area { get; set; }

        [Required]
        public int ButcherStoreId { get; set; }
    }
}
