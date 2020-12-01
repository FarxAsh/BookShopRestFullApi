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
    public class DeleteAuthorCommandHandler: IRequestHandler<DeleteAuthorCommand, Author>
    {
        private readonly IAuthorRepository authorRepository;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<Author> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await authorRepository.GetByIdAsync(request.Id);
            return await authorRepository.DeleteAsync(author);
        }
    }
}
