using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreDomain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Language {  get; set; }
        public string ISBN { get; set; }
        public DateOnly? DatePublished { get; set; }

        [Range(0.01,99999)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Available stock value can not be negative.")]
        public int AvailableStock { get; set; }

        public string? ImageUrl { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
