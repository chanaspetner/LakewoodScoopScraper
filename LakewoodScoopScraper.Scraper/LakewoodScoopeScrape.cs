using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace LakewoodScoopScraper.Scraper
{
    public class LakewoodScoopeScrape
    {
        public static List<LakewoodScoopPost> Scrape()
        {
            var html = GetLakewoodScoopHtml();
            return ParseLakewoodScoopHtml(html);
        }

        private static List<LakewoodScoopPost> ParseLakewoodScoopHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            var resultDivs = document.QuerySelectorAll(".td-module-container.td-category-pos-image");
            var posts = new List<LakewoodScoopPost>();
            foreach (var div in resultDivs)
            {

                var post = new LakewoodScoopPost();
                var linkTitle = div.QuerySelector(".entry-title.td-module-title").QuerySelector("a");
                if (linkTitle != null)
                {
                    post.Title = linkTitle.TextContent;
                }
                                
                var imageUrlDiv = div.QuerySelector(".td-module-thumb");
                if(imageUrlDiv != null)
                {
                   post.ImageUrl = imageUrlDiv.QuerySelector("span").Attributes["data-img-url"].Value;
                }


                var blurb = div.QuerySelector(".td-excerpt");
                if (blurb != null)
                {
                    post.Blurb = blurb.TextContent;
                }

                var commentsCountSpan = div.QuerySelector("span.td-module-comments").QuerySelector("a");
                if(commentsCountSpan != null)
                {
                    post.CommentsCount = int.Parse(commentsCountSpan.TextContent);
                }

                var link = div.QuerySelector(".td-read-more").QuerySelector("a");
                if(link != null)
                {
                    post.Link = link.Attributes["href"].Value;
                }
                posts.Add(post);
            }
            return posts;
        }

        private static string GetLakewoodScoopHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
            };
            using var client = new HttpClient(handler);
            var url = "https://thelakewoodscoop.com/";
            var html = client.GetStringAsync(url).Result;
            return html; 
        }
    }
}
