using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreDomain.Entities;

namespace BookstoreApplication.Features.Authors.Queries
{
    public class GetAuthorByIdQuery : IRequest<Author?>
    {
        public int Id { get; set; }

        public GetAuthorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
