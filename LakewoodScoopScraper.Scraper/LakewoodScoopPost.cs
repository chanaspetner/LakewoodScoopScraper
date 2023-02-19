using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LakewoodScoopScraper.Scraper
{
    public class LakewoodScoopPost
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string? ImageUrl { get; set; }
        public string Blurb { get; set; }
        public int CommentsCount { get; set; }
    }
}
