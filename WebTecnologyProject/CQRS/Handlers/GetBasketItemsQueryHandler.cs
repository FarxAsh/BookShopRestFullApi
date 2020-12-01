using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTechnologyProjectCore.Entities;
using WebTecnologyProjectApi.CQRS.Queries;
using MediatR;
using WebTechnologyProjectCore.Interfaces;
using System.Threading;

namespace WebTecnologyProjectApi.CQRS.Handlers
{
    public class GetBasketItemsQueryHandler: IRequestHandler<GetBasketItemsQuery, IEnumerable<BasketItem>>
    {
        private readonly IBasketService basketService;

        public GetBasketItemsQueryHandler(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        public async Task<IEnumerable<BasketItem>> Handle(GetBasketItemsQuery request, CancellationToken cancellationToken)
        {
            return await basketService.GetAllBasketItemsAsync();
        }
    }
}
