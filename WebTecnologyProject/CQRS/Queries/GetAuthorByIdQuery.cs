using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTechnologyProjectCore.Entities;
using MediatR;

namespace WebTecnologyProjectApi.CQRS.Queries
{
    public class GetAuthorByIdQuery: IRequest<Author>
    {
        public GetAuthorByIdQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; }
    }
}
