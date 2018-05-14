using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WikiWikiWiki.Data;

namespace WikiWikiWiki.Models
{
    /// <summary>
    /// Reference implementation of the IArticleService interface for
    /// an Entity Framework database context.
    /// </summary>
    public class ArticleService : IArticleService
    {
        private readonly WkDbContext _wkDbContext;
        private readonly ILogger<ArticleService> _logger;
        // Used to support the GetRandomAsync() implementation
        private readonly Random _random;

        public ArticleService(WkDbContext wkDbContext, ILogger<ArticleService> logger)
        {
            _wkDbContext = wkDbContext;
            _logger = logger;
            _random = new Random();
        }

        /// <summary>
        /// Saves all queued changes to the database, returning true or false to indicate
        /// success or failure.
        /// </summary>
        /// <returns>Asynchronous task for a boolean flag signifying a successful commit
        /// of pending changes to the database or a failure.</returns>
        protected async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _wkDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // Log whatever is preventing the changes from being committed and return false
                // to indicate to the caller that the changes were not committed successfully
                _logger.LogError(e, "Could not save database changes for article.", args: null);
                return false;
            }

            // Success!
            return true;
        }

        #region IArticleService Implementation

        /// <summary>
        /// Provides a means of directly interfacing with the Articles table
        /// </summary>
        public DbSet<Article> Articles => _wkDbContext.Articles;

        /// <summary>
        /// Adds a new Article entity to the database
        /// </summary>
        /// <param name="article">The Article entity to add</param>
        /// <returns>Asynchronous task for a boolean flag indicating success
        /// or failure</returns>
        public async Task<bool> AddAsync(Article article)
        {
            if (article != null)
            {
                await Articles.AddAsync(article);
                return await SaveChangesAsync();
            }

            return false;
        }

        /// <summary>
        /// Tries to find the Article object corresponding to the specified id.
        /// Returns null if the id was null or no entities exist with the specified id.
        /// </summary>
        /// <param name="id">Nullable long of the id corresponding to the Article
        /// entity to find in the database</param>
        /// <returns>Asynchronous Task instance for an Article corresponding to the
        /// specified id or null if one could not be found.</returns>
        public async Task<Article> FindAsync(long? id) =>
            id.HasValue ? await Articles.FindAsync(id.Value) : null;

        /// <summary>
        /// Retrieves a random Article from the database by skipping a random
        /// number of Article entities and then retrieving that Article entity.
        /// </summary>
        /// <returns>A random Article entity from the database (or null if the
        /// Article table was empty)</returns>
        public async Task<Article> GetRandomAsync() =>
            await Articles.Skip(_random.Next(await Articles.CountAsync()))
                          .FirstOrDefaultAsync();

        /// <summary>
        /// Removes the specified Article entity from the databsae
        /// </summary>
        /// <param name="article">The article to remove from the database</param>
        /// <returns>Asynchronous Task instance for a boolean flag indicating
        /// success or failure</returns>
        public async Task<bool> RemoveAsync(Article article)
        {
            if (article != null)
            {
                Articles.Remove(article);
                return await SaveChangesAsync();
            }

            return false;
        }

        /// <summary>
        /// Updates an existing Article with the information from the provided
        /// Article instance
        /// </summary>
        /// <param name="article">The new state of the Article entity corresponding
        /// to the Id property.</param>
        /// <returns>Asynchronous Task instance for a boolean flag indicating success
        /// or failure</returns>
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
