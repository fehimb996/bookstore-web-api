using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreDomain.Entities;
using BookstoreApplication.Features.Authors.DTOs;

namespace BookstoreApplication.Features.Authors.Queries
{
    public class GetAllAuthorsQuery : IRequest<List<AuthorDTO>>
    {

    }
}
