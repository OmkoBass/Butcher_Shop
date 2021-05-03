using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.ArticleRepo
{
    interface IArticleRepo
    {
        public Task<List<Article>> GetAllArticles();
        public Task<Article> GetArticle(int Id);
        public Task<Article> AddArticle(Article Article);
        public Task<Article> UpdateArticle(Article Article);
        public Task<bool> DeleteArticle(int Id);
    }
}
