using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WikiWikiWiki.Models;

namespace WikiWikiWiki.Pages
{
    public class EditModel : PageModel
    {
        private readonly IArticleService _articleService;

        [BindProperty]
        public Article Article { get; set; }
        [BindProperty]
        public bool IsNewArticle { get; set; }

        public EditModel(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task OnGetAsync(long? id)
        {
            Article = await _articleService.FindAsync(id);
            IsNewArticle = Article is null;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Article.LastUpdated = DateTime.UtcNow;
                bool success;

                if (IsNewArticle)
                {
                    success = await _articleService.AddAsync(Article);
                }
                else
                {
                    success = await _articleService.UpdateAsync(Article);
                }

                if (success)
                {
                    return RedirectToPage("Article", new { id = Article.Id });
                }
            }

            return RedirectToPage();
        }
    }
}