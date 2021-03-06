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
        public ButcherStore() {
            this.Employees = new HashSet<Employee>();
            this.Storages = new HashSet<Storage>();
            this.Customers = new HashSet<Customer>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(64)]
        public string Address { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int Area { get; set; }

        [Required]
        public int ButcherId { get; set; }
        public virtual Butcher Butcher { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Storage> Storages { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
