using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Dtos
{
    public class ArticleDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int CustomerId { get; set; }

        public int StorageId { get; set; }
    }
}
