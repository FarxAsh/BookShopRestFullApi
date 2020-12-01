using MediatR;
using System.Collections.Generic;
using WebTechnologyProjectCore.Entities;

namespace WebTecnologyProjectApi.CQRS.Commands
{
    public class CreateBookCommand: IRequest<Book>
    {
        public CreateBookCommand(Book book)
        {
            this.Book = book;
        }

        public Book Book { get; }
    }
}
