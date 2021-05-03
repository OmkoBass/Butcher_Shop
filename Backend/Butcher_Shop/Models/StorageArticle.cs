using Butcher_Shop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Models
{
    public class StorageArticle
    {
        public int StorageId { get; set; }
        public virtual Storage Storage { get; set; }

        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public int Quantity { get; set; }
    }
}
