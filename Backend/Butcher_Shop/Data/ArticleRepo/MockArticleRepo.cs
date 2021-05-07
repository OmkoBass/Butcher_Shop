using Butcher_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Data.ArticleRepo
{
    public class MockArticleRepo : IArticleRepo
    {
        private readonly DatabaseContext _context;

        public MockArticleRepo(DatabaseContext context) => _context = context;

        public async Task<bool> AddArticle(Article Article)
        {
            await _context.Articles.AddAsync(Article);
            return true;
        }

        public bool DeleteArticle(Article Article)
        {
            _context.Articles.Remove(Article);
            return true;
        }

        public async Task<List<Article>> GetAllArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article> GetArticle(int Id)
        {
            return await _context.Articles.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public bool UpdateArticle(Article Article)
        {
            _context.Articles.Update(Article);
            return true;
        }
    }
}
