using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Dtos
{
    public class ButcherStoreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Area { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; }
        public ICollection<StorageDto> Storages { get; set; }
        public ICollection<CustomerDto> Customers { get; set; }
    }
}
