using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Repositories.EFCore.Entities
{
    public class Author
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
