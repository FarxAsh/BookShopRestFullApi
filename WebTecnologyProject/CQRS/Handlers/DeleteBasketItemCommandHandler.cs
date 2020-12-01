using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebTechnologyProjectCore.Entities;
using WebTecnologyProjectApi.CQRS.Commands;
using WebTechnologyProjectCore.Interfaces;
using WebTechnologyProjectCore.Specifications;

namespace WebTecnologyProjectApi.CQRS.Handlers
{
    public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommand, BasketItem>
    {

        private readonly IBasketItemRepository basketItemRepository;
        
        public DeleteBasketItemCommandHandler(IBasketItemRepository basketItemRepository)
        {
            this.basketItemRepository = basketItemRepository;
        }

        public async Task<BasketItem> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basketItem = await basketItemRepository.GetByIdAsync(request.Id);
            return await basketItemRepository.DeleteAsync(basketItem);
        }
    }
}
