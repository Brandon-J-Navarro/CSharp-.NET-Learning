using SimpleWebScraper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScraper.Builders
{
    internal class ScrapeCriteriaBuilder
    {
        private string _data;
        private string _regex;
        private RegexOptions _regexOptions;
        private List<ScrapeCriteriaPart> _parts;

        public ScrapeCriteriaBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _data = string.Empty;
            _regex = string.Empty;
            _regexOptions = RegexOptions.None;
            _parts = new List<ScrapeCriteriaPart>();
        }
        public ScrapeCriteriaBuilder WithData(string data)
        {
            _data = data;
            return this;
        }
        public ScrapeCriteriaBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }
        public ScrapeCriteriaBuilder WithRegexOption(RegexOptions regexOption)
        {
            _regexOptions = regexOption;
            return this;
        }
        public ScrapeCriteriaBuilder WithPart(ScrapeCriteriaPart scrapeCriteriaPart)
        {
            _parts.Add(scrapeCriteriaPart);
            return this;
        }
        public ScrapeCriteria Build()
        {
            ScrapeCriteria scrapeCriteria = new ScrapeCriteria();
            scrapeCriteria.Data = _data;
            scrapeCriteria.Regex = _regex;
            scrapeCriteria.RegexOptions = _regexOptions;
            scrapeCriteria.Parts = _parts;
            return scrapeCriteria;
        }
    }
}
