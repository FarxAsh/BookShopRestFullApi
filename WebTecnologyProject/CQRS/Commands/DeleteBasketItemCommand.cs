using MediatR;
using System.Collections.Generic;
using WebTechnologyProjectCore.Entities;

namespace WebTecnologyProjectApi.CQRS.Commands
{
    public class DeleteBasketItemCommand : IRequest<BasketItem>
    {
        public int Id { get; }

        public DeleteBasketItemCommand(int id)
        {
            this.Id = id;
        }
    }
}
