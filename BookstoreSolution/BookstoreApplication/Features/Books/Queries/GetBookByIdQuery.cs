using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreDomain.Entities;
using BookstoreApplication.Features.Books.DTOs;
using System.ComponentModel;

namespace BookstoreApplication.Features.Books.Queries
{
    public class GetBookByIdQuery : IRequest<BookDTO>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public decimal Price { get; set; }
    }
}
