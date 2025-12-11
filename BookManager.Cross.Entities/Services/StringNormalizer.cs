using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Cross.Entities.Services
{
    internal class StringNormalizer : IStringNormalizer
    {
        readonly IEnumerable<INormalizationRule> Rules;

        public StringNormalizer(IEnumerable<INormalizationRule> rules)
        {
            Rules = rules;
        }

        public string Normalize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            string result = input;
            foreach (var rule in Rules)
            {
                result = rule.Apply(result);
            }

            return result.Trim();
        }
    }
}
