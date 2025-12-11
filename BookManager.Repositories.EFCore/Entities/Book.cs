using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Repositories.EFCore.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string NormalizedTitle { get; set; }
        public string CoverUrl { get; set; }
        public int PublicationYear { get; set; }
        public int PageNumber { get; set; }

        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
