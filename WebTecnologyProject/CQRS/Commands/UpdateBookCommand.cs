using MediatR;
using System.Collections.Generic;
using WebTechnologyProjectCore.Entities;

namespace WebTecnologyProjectApi.CQRS.Commands
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public UpdateBookCommand(Book book)
        {
            this.Book = book;
        }

        public Book Book { get; }
    }
}
