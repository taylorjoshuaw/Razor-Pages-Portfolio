using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WikiWikiWiki.Models;

namespace WikiWikiWiki.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IArticleService _articleService;

        [BindProperty]
        public List<Article> Articles { get; set; }

        public SearchModel(IArticleService articleService)
        {
            _articleService = articleService;
        }

        /// <summary>
        /// Fills the Articles list of the view model with articles matching the specified
        /// search criteria. If the searchString is not blank, will filter articles by titles
        /// which contain all of the words contained in the searchString. If count is provided,
        /// only the specified number of articles will be stored in the list. All results are
        /// returned in descending order by the articles' LastUpdated property.
        /// </summary>
        /// <param name="searchString">Optional search string that will be split by whitespace
        /// to form AND-combined keywords to search on article titles.</param>
        /// <param name="count">Optional count of articles to be included in the view model</param>
        /// <returns>Asynchronous Task instance for synchronization</returns>
        public async Task OnGetAsync(string searchString, int? count)
        {
            // Start the query for articles on the Articles table by specifying that results
            // are to be returned in descending order
            IQueryable<Article> articleQuery = 
                _articleService.Articles.OrderByDescending(a => a.LastUpdated);

            // If a searchString has been provided then search for articles which contain each
            // if the words from the searchString (in any order)
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                foreach (string keyword in searchString.Split(' ', '\t', '\n'))
                {
                    articleQuery = articleQuery.Where(a => a.Title.Contains(keyword));
                }
            }

            // If a count has been provided, only take that number of articles for the results
            if (count.HasValue)
            {
                articleQuery = articleQuery.Take(count.Value);
            }

            // Fill the Articles list for the view model with the results of the search
            Articles = await articleQuery.ToListAsync();
        }
    }
}