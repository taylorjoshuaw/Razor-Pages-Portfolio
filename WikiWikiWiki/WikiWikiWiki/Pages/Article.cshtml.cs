using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WikiWikiWiki.Models;

namespace WikiWikiWiki.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly IArticleService _articleService;

        [BindProperty]
        public Article Article { get; set; }

        public ArticleModel(IArticleService articleService)
        {
            _articleService = articleService;
        }

        /// <summary>
        /// GET /Article/{id?}
        /// If an id is provided then sets the Article property of the view model
        /// to the Article entity corresponding to that id via IArticleService.
        /// Otherwise, retrieve a random article for the view model via the
        /// IArticleService.
        /// </summary>
        /// <param name="id">The id of the specific article to display</param>
        /// <returns></returns>
        public async Task OnGetAsync(long? id)
        {
            if (id.HasValue)
            {
                Article = await _articleService.FindAsync(id);
            }
            else
            {
                Article = await _articleService.GetRandomAsync();
            }
        }
    }
}