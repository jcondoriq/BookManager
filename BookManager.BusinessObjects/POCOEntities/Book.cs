using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.POCOEntities
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Isbn { get; set; }  // Validado por servicio SOAP

        public string Title { get; set; }
        public string NormalizedTitle { get; set; }

        public string CoverUrl { get; set; }  // Obtenido desde la API REST de Open Library

        public int PublicationYear { get; set; }
        public int PageNumber { get; set; }

        public Guid AuthorId { get; set; }     // Relación con Author
    }
}
