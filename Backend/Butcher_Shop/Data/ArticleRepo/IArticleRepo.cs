using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.ArticleRepo
{
    public interface IArticleRepo
    {
        public Task<List<Article>> GetAllArticles();
        public Task<Article> GetArticle(int Id);
        public Task<bool> AddArticle(Article Article);
        public bool UpdateArticle(Article Article);
        public bool DeleteArticle(Article Article);
    }
}
