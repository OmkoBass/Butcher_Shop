using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Dtos
{
    public class EmployeeDto
    {
        public enum JobType
        {
            Cashier = 0,
            Administration = 1
        }

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

        public JobType Job { get; set; }

        [Required]
        public int ButcherStoreId { get; set; }
    }
}
