using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreDomain.Entities
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
