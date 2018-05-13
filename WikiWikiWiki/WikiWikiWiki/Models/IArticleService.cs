using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WikiWikiWiki.Models
{
    public interface IArticleService
    {
        Task<bool> AddAsync(Article article);
        Task<bool> UpdateAsync(Article article);
        Task<bool> RemoveAsync(Article article);

        Task<Article> FindAsync(long? id);

        DbSet<Article> Articles { get; }
    }
}
