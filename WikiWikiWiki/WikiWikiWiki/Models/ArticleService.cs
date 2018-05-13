using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WikiWikiWiki.Data;

namespace WikiWikiWiki.Models
{
    public class ArticleService : IArticleService
    {
        private readonly WkDbContext _wkDbContext;
        private readonly ILogger<ArticleService> _logger;
        private readonly Random _random;

        public ArticleService(WkDbContext wkDbContext, ILogger<ArticleService> logger)
        {
            _wkDbContext = wkDbContext;
            _logger = logger;
            _random = new Random();
        }

        protected async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _wkDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not save database changes for article.", args: null);
                return false;
            }

            return true;
        }

        #region IArticleService Implementation

        public DbSet<Article> Articles => _wkDbContext.Articles;

        public async Task<bool> AddAsync(Article article)
        {
            if (article != null)
            {
                await Articles.AddAsync(article);
                return await SaveChangesAsync();
            }

            return false;
        }

        public async Task<Article> FindAsync(long? id) =>
            id.HasValue ? await Articles.FindAsync(id.Value) : null;

        public async Task<Article> GetRandomAsync() =>
            await Articles.Skip(_random.Next(await Articles.CountAsync()))
                          .FirstOrDefaultAsync();

        public async Task<bool> RemoveAsync(Article article)
        {
            if (article != null)
            {
                Articles.Remove(article);
                return await SaveChangesAsync();
            }

            return false;
        }

        public async Task<bool> UpdateAsync(Article article)
        {
            if (article != null)
            {
                Articles.Update(article);
                return await SaveChangesAsync();
            }

            return false;
        }

        #endregion
    }
}
