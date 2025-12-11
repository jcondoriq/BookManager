using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Cross.Entities.Services
{
    internal class UpperCaseRule : INormalizationRule
    {
        public string Apply(string input) => input.ToUpperInvariant();
    }
}
