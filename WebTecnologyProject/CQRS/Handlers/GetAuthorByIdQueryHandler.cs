using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebTechnologyProjectCore.Entities;
using WebTechnologyProjectCore.Enums;
using WebTechnologyProjectCore.Interfaces;
using WebTechnologyProjectCore.Specifications;
using WebTecnologyProjectApi.CQRS.Queries;

namespace WebTecnologyProjectApi.CQRS.Handlers
{
    public class GetAuthorByIdQueryHandler: IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IAuthorRepository authorRepository;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await authorRepository.GetByIdAsync(request.Id);
        }
    }
}
