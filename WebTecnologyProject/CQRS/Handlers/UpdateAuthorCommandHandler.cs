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
    public class UpdateAuthorCommandHandler: IRequestHandler<UpdateAuthorCommand, Author>
    {
        private readonly IAuthorRepository authorRepository;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            return await authorRepository.UpdateAsync(request.Author);
        }
    }
}
