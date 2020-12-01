using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebTechnologyProjectCore.Entities;

namespace WebTecnologyProjectApi.CQRS.Commands
{
    public class CreateOrderCommand: IRequest<Order>
    {
        public CreateOrderCommand(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}
