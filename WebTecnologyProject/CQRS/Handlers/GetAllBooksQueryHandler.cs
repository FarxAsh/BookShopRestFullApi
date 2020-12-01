using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebTechnologyProjectCore.Entities;
using WebTecnologyProjectApi.CQRS.Queries;
using WebTechnologyProjectCore.Interfaces;
using WebTechnologyProjectCore.Specifications;

namespace WebTecnologyProjectApi.CQRS.Handlers
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly IBookRepository bookRepository;

        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var specification = new AllBooksIncludeAuthorsSpecification();
            return await bookRepository.ListAsync(specification);
                     
        }
    }
}
