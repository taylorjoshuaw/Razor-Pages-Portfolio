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

        /// <summary>
        /// A flag to distinguish whether we are creating a brand new article
        /// or if we are simply editing an existing one.
        /// </summary>
        [BindProperty]
        public bool IsNewArticle { get; set; }

        public EditModel(IArticleService articleService)
        {
            _articleService = articleService;
        }

        /// <summary>
        /// GET /Edit/{id?}
        /// Prepares the view model for either creating a new article or editing
        /// and existing one. If no id has been provided, then set the IsNewArticle
        /// flag.
        /// </summary>
        /// <param name="id">If provided, specifies which article the user would
        /// like to edit. If null, a new article will be created.</param>
        /// <returns>Asynchronous Task instance for synchronization</returns>
        public async Task OnGetAsync(long? id)
        {
            Article = await _articleService.FindAsync(id);
            IsNewArticle = Article is null;
        }

        /// <summary>
        /// POST /Edit/{id?}
        /// Handler for POST requests from the /Edit form. Checks for valid model
        /// state, updates the LastUpdated field, creates/edits the article, and
        /// then redirects to the Article page to view the new/edited article.
        /// </summary>
        /// <returns>Asynchronous Task instance for an IActionResult. If the view
        /// model's state is valid then this should be a RedirectToPageResult to
        /// /Article for the new/edited article; otherwise, the page is rendered
        /// again to allow the user to correct the model state.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Use UTC time to maintain consistency when load balancing occurs
                Article.LastUpdated = DateTime.UtcNow;
                // Signifies whether the database modifications were successful
                bool success;

                if (IsNewArticle)
                {
                    success = await _articleService.AddAsync(Article);
                }
                else
                {
                    success = await _articleService.UpdateAsync(Article);
                }

                // If the database was modified successfully, redirect to the
                // new article.
                if (success)
                {
                    return RedirectToPage("Article", new { id = Article.Id });
                }
            }

            // A validation error has occurred. Re-render the page with the
            // existing view model to allow the user a chance to correct
            // their input for validation.
            return Page();
        }

        /// <summary>
        /// POST /Edit for the Delete page handler
        /// Removes the view model's article from the database and redirects to
        /// the index of the application.
        /// </summary>
        /// <returns>Asynchronous Task instance for IActionResult. Should be
        /// a RedirectToPageResult to the Index upon successful removal of the
        /// view model's article from the database.</returns>
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            await _articleService.RemoveAsync(Article);
            return RedirectToPage("Index");
        }
    }
}