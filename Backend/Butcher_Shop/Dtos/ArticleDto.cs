using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Dtos
{
    public class ArticleDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        public int StorageId { get; set; }
    }
}
