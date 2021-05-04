using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Models
{
    public class Employee
    {
        public enum JobType
        {
            Cashier,
            Administration
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
        public bool Sex { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(64)]
        public string Address { get; set; }

        public JobType Job {get; set;}

        [Required]
        public int ButcherStoreId { get; set; }
        public virtual ButcherStore ButcherStore { get; set; }
    }
}
