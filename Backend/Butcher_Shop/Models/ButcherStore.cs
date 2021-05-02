using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Models
{
    public class ButcherStore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(64)]
        public string Address { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Area { get; set; }

        public int ButcherId { get; set; }
        public virtual Butcher Butcher { get; set; }
    }
}
