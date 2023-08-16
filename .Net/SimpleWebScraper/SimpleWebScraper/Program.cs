using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using SimpleWebScraper.Data;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Workers;

namespace SimpleWebScraper
{
    class Program
    {
        private const string Method = "search";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please Enter which city you would like to scrape informaion from:");
                var city = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Please Enter the category you would like to scrape:");
                var category = Console.ReadLine() ?? string.Empty;
                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString($"https://{city.Replace(" ", string.Empty)}.craigslist.org/{Method}/{category}");

                    ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                        .WithData(content)
                        .WithRegex(@"<li(.*?)<\/li>")
                        .WithRegexOption(RegexOptions.ExplicitCapture)
                        .WithPart(new ScrapeCriteriaPartBuilder()
                            .WithRegex(@"<div class=""title"">(.*?)<\/div>")
                            .WithRegexOption(RegexOptions.Singleline)
                            .Build())
                        .WithPart(new ScrapeCriteriaPartBuilder()
                            .WithRegex(@"href=""(.*?)""")
                            .WithRegexOption(RegexOptions.Singleline)
                            .Build())
                        .Build();

                    Scraper scraper = new Scraper();

                    var scraptedElements = scraper.Scrape(scrapeCriteria);

                    if (scraptedElements.Any())
                    {
                        foreach (var scraptedElement in scraptedElements)
                        {
                            Console.WriteLine(scraptedElement);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There were no matches for the specified scrape criteria.");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}