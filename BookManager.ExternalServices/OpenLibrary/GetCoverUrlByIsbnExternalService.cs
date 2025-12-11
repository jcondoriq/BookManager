using BookManager.BusinessObjects.Interfaces.ExternalServices;
using BookManager.Cross.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookManager.ExternalServices.OpenLibrary
{
    internal class GetCoverUrlByIsbnExternalService : IGetCoverUrlByIsbnExternalService
    {
        readonly IApiContext _context;

        public GetCoverUrlByIsbnExternalService(IApiContextFactory contextFactory)
        {
            _context = contextFactory.Create("OpenLibrary");
        }

        public async Task<string?> GetCoverUrlByIsbn(string isbn)
        {
            string url = $"api/books?bibkeys=ISBN:{isbn}&format=json";

            string json = await _context.GetStringAsync(url);

            if (string.IsNullOrWhiteSpace(json))
                return string.Empty;

            using var doc = JsonDocument.Parse(json);

            var root = doc.RootElement;

            var item = root.EnumerateObject().FirstOrDefault();
            if (item.Value.ValueKind == JsonValueKind.Undefined)
                return string.Empty;

            if (item.Value.TryGetProperty("thumbnail_url", out var thumbElement))
                return thumbElement.GetString();

            return string.Empty;
        }
    }
}
