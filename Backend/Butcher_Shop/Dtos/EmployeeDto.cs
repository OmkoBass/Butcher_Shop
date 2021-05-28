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
        public int Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public bool Sex { get; set; }

        public string Address { get; set; }

        public JobType Job { get; set; }

        public int ButcherStoreId { get; set; }
    }
}
