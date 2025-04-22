using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApplication.Features.Books.DTOs
{
    public class BookBasicDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public string Language { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public DateTime? DatePublished { get; set; }
        public string? ImageUrl { get; set; }
    }
}
