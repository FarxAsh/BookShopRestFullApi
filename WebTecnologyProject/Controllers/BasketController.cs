using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using WebTechnologyProjectCore.Entities;
using WebTecnologyProjectApi.CQRS.Queries;
using WebTecnologyProjectApi.CQRS.Commands;
using Microsoft.AspNetCore.Http;

namespace WebTecnologyProjectApi.Controllers
{
    [ApiController]
    [Route("api/basket")]
    public class BasketController : ControllerBase
    {
        private readonly IMediator mediator;

        public BasketController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketItem>>> GetBasketItems()
        {
            var basketItems = await mediator.Send(new GetBasketItemsQuery());

            return Ok(basketItems);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<BasketItem>> AddBasketItem([FromQuery] int id)
        {
            var basketItem = await mediator.Send(new CreateBasketItemCommand(id));

            return Ok(basketItem);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<BasketItem>> DeleteBasketItem([FromQuery] int id)
        {
            var deletedBasketItem = await mediator.Send(new DeleteBasketItemCommand(id));
            return Ok(deletedBasketItem);
        }

        [HttpDelete]
        public async Task<ActionResult> ClearBasket()
        {
            await mediator.Send(new ClearBasketCommand());
            return Ok();
        }
    }
}
