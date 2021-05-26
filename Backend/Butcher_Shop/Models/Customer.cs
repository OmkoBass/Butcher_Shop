using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Models
{
    public class Customer
    {
        public Customer()
        {
            this.BoughtArticles = new HashSet<Article>(); 
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(16)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public string Lastname { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(64)]
        public string Address { get; set; }

        [Required]
        public bool Sex { get; set; }

        public ICollection<Article> BoughtArticles{ get; set; }
    }
}
