using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebTechnologyProjectCore.Entities;

namespace WebTecnologyProjectApi.CQRS.Queries
{
    public class GetBasketItemsQuery: IRequest<List<BasketItem>>
    {
    }
}
