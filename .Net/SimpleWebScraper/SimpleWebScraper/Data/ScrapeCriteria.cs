using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScraper.Data
{
    internal class ScrapeCriteria
    {
        public ScrapeCriteria()
        {
            Parts = new List<ScrapeCriteriaPart>();
        }
        public string Data { get; set; }
        public string Regex { get; set; }
        public RegexOptions RegexOptions { get; set; }
        public List<ScrapeCriteriaPart> Parts { get; set; }
    }
}
