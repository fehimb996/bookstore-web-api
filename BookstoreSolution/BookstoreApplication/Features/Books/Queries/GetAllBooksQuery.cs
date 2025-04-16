using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreDomain.Entities;
using BookstoreApplication.Features.Books.DTOs;

namespace BookstoreApplication.Features.Books.Queries
{
    public class GetAllBooksQuery : IRequest<List<BookDTO>>
    {

    }
}
