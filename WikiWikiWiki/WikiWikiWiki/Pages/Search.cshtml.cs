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

        public async Task OnGetAsync(string searchString, int? count)
        {
            IQueryable<Article> articleQuery = 
                _articleService.Articles.OrderByDescending(a => a.LastUpdated);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                foreach (string keyword in searchString.Split(' ', '\t', '\n'))
                {
                    articleQuery = articleQuery.Where(a => a.Title.Contains(keyword));
                }
            }

            if (count.HasValue)
            {
                articleQuery = articleQuery.Take(count.Value);
            }

            Articles = await articleQuery.ToListAsync();
        }
    }
}