using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTechnologyProjectCore.Interfaces;
using WebTechnologyProjectCore.Entities;
using WebTecnologyProjectApi.CQRS.Commands;
using MediatR;
using System.Threading;

namespace WebTecnologyProjectApi.CQRS.Handlers
{
    public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderService orderService;

        public CreateOrderCommandHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            request.Order.orderDateTime = DateTime.Now;
            return await orderService.CreateOrderAsync(request.Order);
        }
    }
}
