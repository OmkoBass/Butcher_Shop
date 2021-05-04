using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Models
{
    public class Butcher
    {
        public Butcher() => this.ButcherStores = new HashSet<ButcherStore>();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

        public ICollection<ButcherStore> ButcherStores { get; set; }
    }
}
