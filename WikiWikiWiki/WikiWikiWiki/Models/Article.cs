using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WikiWikiWiki.Models
{
    public class Article
    {
        public long Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        public string Content { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
