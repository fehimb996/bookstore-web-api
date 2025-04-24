using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreDomain.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string CustomerId { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public string Comment { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
