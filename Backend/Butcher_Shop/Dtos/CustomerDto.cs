using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public bool Sex { get; set; }

        public ICollection<ArticleDto> BoughtArticles { get; set; }
    }
}
