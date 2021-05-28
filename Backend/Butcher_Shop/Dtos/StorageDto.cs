using Butcher_Shop.Migrations;
using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Dtos
{
    public class StorageDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Area { get; set; }
        public int ButcherStoreId { get; set; }
        public ICollection<ArticleDto> Articles { get; set; }
    }
}
