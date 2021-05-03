using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Dtos
{
    public class ArticleDto
    {
        public string Naziv { get; set; }

        public virtual ICollection<StorageArticle> StorageArticles { get; set; }
    }
}
