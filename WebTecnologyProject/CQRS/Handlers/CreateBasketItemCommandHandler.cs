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
    public class CreateBasketItemCommandHandler: IRequestHandler<CreateBasketItemCommand, BasketItem>
    {
        private readonly IBasketService basketService;
        private readonly IBookRepository bookRepository;

        public CreateBasketItemCommandHandler(IBasketService basketService, IBookRepository bookRepository)
        {
            this.basketService = basketService;
            this.bookRepository = bookRepository;
        }

        public async Task<BasketItem> Handle(CreateBasketItemCommand request, CancellationToken cancellationToken)
        {
            var book = await bookRepository.GetByIdAsync(request.Id);
            return await basketService.AddBasketItemAsync(book);
        }
    }
}
