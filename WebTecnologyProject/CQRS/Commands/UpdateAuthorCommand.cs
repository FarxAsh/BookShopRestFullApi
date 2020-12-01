using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebTechnologyProjectCore.Entities;

namespace WebTecnologyProjectApi.CQRS.Commands
{
    public class UpdateAuthorCommand: IRequest<Author>
    {
        public UpdateAuthorCommand(Author author)
        {
            this.Author = author;
        }

        public Author Author { get; }
    }
}
