using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookManager.Cross.Entities.Services
{
    internal class RemoveNumbersRule : INormalizationRule
    {
        public string Apply(string input) => Regex.Replace(input, "[0-9]", "");
    }
}
