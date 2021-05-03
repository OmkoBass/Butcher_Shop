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

        public async Task<Article> AddArticle(Article Article)
        {
            var AddedArticle = await _context.Articles.AddAsync(Article);

            if (AddedArticle != null)
            {
                await _context.SaveChangesAsync();
                return AddedArticle.Entity;
            }
            return null;
        }

        public async Task<bool> DeleteArticle(int Id)
        {
            var FoundArticle = await _context.Articles.FindAsync(Id);

            if (FoundArticle != null)
            {
                _context.Articles.Remove(FoundArticle);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<Article>> GetAllArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article> GetArticle(int Id)
        {
            var FoundArticle = await _context.Articles.FindAsync(Id);

            if (FoundArticle != null)
            {
                return FoundArticle;
            }

            return null;
        }

        public async Task<Article> UpdateArticle(Article Article)
        {
            var FoundArticle = await _context.Articles.FindAsync(Article.Id);

            if (FoundArticle != null)
            {
                var UpdatedArticle = _context.Articles.Update(FoundArticle);
                await _context.SaveChangesAsync();

                return UpdatedArticle.Entity;
            }

            return null;
        }
    }
}
