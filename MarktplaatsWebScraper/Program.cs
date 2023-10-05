using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScraper
{
    class Program
    {
        private const string Method = "q";

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter what Marktplaats category you want to search for: ");
                var marktplaatsCategory = Console.ReadLine() ?? string.Empty;

                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString($"https://www.marktplaats.nl/{Method}/{marktplaatsCategory}/");

                    ScrapeCriteria criteria = new ScrapeCriteriaBuilder()
                        .WithData(content)
                        .WithRegex(@"<a class=\""hz-Link hz-Link--block hz-Listing-coverLink\"" href=\""(.*?)\"">(.*?)</a>")
                        .WithRegexOptions(RegexOptions.ExplicitCapture)
                        .WithPart(new ScrapeCriteriaPartBuilder()
                        .WithRegex(@"<h3 class=\""hz-Listing-title\"">(.*?)</h3>")
                        .WithRegexOptions(RegexOptions.Singleline)
                        .Build())
                        .WithPart(new ScrapeCriteriaPartBuilder()
                        .WithRegex(@"<a class=\""hz-Link hz-Link--block hz-Listing-coverLink\"" href=\""(.*?)\"">(.*?)</a>")
                        .WithRegexOptions(RegexOptions.Singleline)
                        .Build())
                        .Build();

                    Scraper scraper = new Scraper();
                    var scrapedElements = scraper.Scrape(criteria);

                    if (scrapedElements.Any())
                    {
                        foreach (var scrapedElement in scrapedElements)
                        {
                            Console.WriteLine(scrapedElement);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There were no matches for the specified scrape criteria.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}