using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTechnologyProjectCore.Enums;
using WebTechnologyProjectCore.Entities;
using MediatR;

namespace WebTecnologyProjectApi.CQRS.Queries
{
    public class GetFilteredAuthorsQuery: IRequest<List<Author>>
    {
        public GetFilteredAuthorsQuery(Genre? genre)
        {
            this.Genre = genre;
        }

        public Genre? Genre { get; }
    }
}
