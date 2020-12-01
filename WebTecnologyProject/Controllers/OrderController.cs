using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebTechnologyProjectCore.Entities;
using WebTecnologyProjectApi.ViewModels;
using MediatR;
using AutoMapper;
using WebTecnologyProjectApi.CQRS.Commands;


namespace WebTecnologyProjectApi.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController: ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderViewModel orderViewModel)
        {
            var order = mapper.Map<Order>(orderViewModel);
            order.Byer = User.Identity.Name;
            var createdOrder = await mediator.Send(new CreateOrderCommand(order));
            return Ok(createdOrder);
        }

    }
}
