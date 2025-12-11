using BookManager.BusinessObjects.Interfaces.ExternalServices;
using ISBNService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ISBNService.SBNServiceSoapTypeClient;

namespace BookManager.ExternalServices.SoapClient
{
    internal class ValidateIsbnExternalService : IValidateIsbnExternalService
    {
        public async ValueTask<bool> ValidateIsbn(string isbn)
        {
            bool IsIsnValid = false;
            var client = new SBNServiceSoapTypeClient(EndpointConfiguration.ISBNServiceSoap);

            if (isbn.Length == 13)
            {
                var Response = await client.IsValidISBN13Async(isbn);
                IsIsnValid = Response.Body.IsValidISBN13Result;
            }
            else if (isbn.Length == 10)
            {
                var Response = await client.IsValidISBN10Async(isbn);
                IsIsnValid = Response.Body.IsValidISBN10Result;
            }

            return IsIsnValid;
        }
    }
}
