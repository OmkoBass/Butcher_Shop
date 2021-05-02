using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Dtos
{
    public class ButcherDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public ICollection<ButcherStoreDto> ButcherStores { get; set; }
    }
}
