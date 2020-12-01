using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebTechnologyProjectCore.Entities;
using WebTecnologyProjectApi.CQRS.Commands;
using WebTechnologyProjectCore.Interfaces;
using WebTechnologyProjectCore.Specifications;

namespace WebTecnologyProjectApi.CQRS.Handlers
{
    public class CreateAuthorCommandHandler: IRequestHandler<CreateAuthorCommand, Author>
    {
        private readonly IAuthorRepository authorRepository;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            return await authorRepository.AddAsync(request.Author);
        }
    }
}
