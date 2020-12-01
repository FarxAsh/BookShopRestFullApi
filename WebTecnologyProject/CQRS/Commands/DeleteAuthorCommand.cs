using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebTechnologyProjectCore.Entities;

namespace WebTecnologyProjectApi.CQRS.Commands
{
    public class DeleteAuthorCommand: IRequest<Author>
    {
        public DeleteAuthorCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; }
    }
}
