using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Dtos
{
    public class AddArticleDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int Price { get; set; }

        [Required]
        public int StorageId { get; set; }
    }
}
