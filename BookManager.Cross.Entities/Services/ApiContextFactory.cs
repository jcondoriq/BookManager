using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Cross.Entities.Services
{
    internal class ApiContextFactory : IApiContextFactory
    {
        readonly IHttpClientFactory ClientFactory;

        public ApiContextFactory(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public IApiContext Create(string clientName)
        {
            var client = ClientFactory.CreateClient(clientName);
            return new ApiContext(client);
        }
    }
}
