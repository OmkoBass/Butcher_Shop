using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Dtos
{
    public class StorageArticleDto
    {
        public int StorageId { get; set; }
        public int ArticleId { get; set; }
        public int Quantity { get; set; }
    }
}
