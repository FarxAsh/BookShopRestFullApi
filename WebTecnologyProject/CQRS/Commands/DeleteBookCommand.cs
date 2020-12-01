using MediatR;
using System.Collections.Generic;
using WebTechnologyProjectCore.Entities;

namespace WebTecnologyProjectApi.CQRS.Commands
{
    public class DeleteBookCommand: IRequest<Book>
    {
        public DeleteBookCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; }
    }
}
