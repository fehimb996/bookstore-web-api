using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreDomain.Entities;

namespace BookstoreApplication.Features.Authors.Queries
{
    public class GetAllAuthorsQuery : IRequest<List<Author>>
    {

    }
}
