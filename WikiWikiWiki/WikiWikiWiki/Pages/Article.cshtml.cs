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