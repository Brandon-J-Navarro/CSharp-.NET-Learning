﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScraper.Data
{
    internal class ScrapeCriteriaPart
    {
        public string Regex { get; set; }
        public RegexOptions RegexOptions { get; set; }
    }
}
