using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreDomain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Language {  get; set; }
        public string ISBN { get; set; }
        public DateTime? DatePublished { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
