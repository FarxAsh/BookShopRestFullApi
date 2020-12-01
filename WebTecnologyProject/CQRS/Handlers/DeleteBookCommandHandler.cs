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
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Book>
    {
        private readonly IBookRepository bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public async Task<Book> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await bookRepository.GetByIdAsync(request.Id);
            return await bookRepository.DeleteAsync(book);
        }
    }
}
