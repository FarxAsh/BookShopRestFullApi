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
    public class GetFilteredBooksQueryHandler : IRequestHandler<GetFilteredBooksQuery, IEnumerable<Book>>
    {
        private readonly IBookRepository bookRepository;

        public GetFilteredBooksQueryHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>> Handle(GetFilteredBooksQuery request, CancellationToken cancellationToken)
        {
            var specification = new FilteredBooksSpecification(request.Genre, request.Author);
            var dbRequestResult = await bookRepository.ListAsync(specification);
            return dbRequestResult;
            
        }
    }
}
