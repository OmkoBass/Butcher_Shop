using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Models
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int Price { get; set; }

        [Required]
        public int StorageId { get; set; }
        public virtual Storage Storage { get; set; }

        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
