using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiWikiWiki.Models;

namespace WikiWikiWiki.Data
{
    public class WkDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public WkDbContext(DbContextOptions<WkDbContext> options) : base(options)
        {
        }
    }
}
