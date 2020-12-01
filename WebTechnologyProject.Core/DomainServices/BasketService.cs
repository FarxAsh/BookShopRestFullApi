using System;
using WebTechnologyProjectCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using WebTechnologyProjectCore.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using WebTechnologyProjectCore.Specifications;

namespace WebTechnologyProjectCore.DomainServices
{
    public class BasketService : IBasketService
    {

        public BasketService(IBasketItemRepository basketItemRepository, string basketGuid)
        {
            this.basketItemRepository = basketItemRepository;
            this.basketGuid = basketGuid;
        }

        public string basketGuid { get; set; }
        IBasketItemRepository basketItemRepository;
        public static IBasketService GetBasket(IServiceProvider services)
        {

            var basketItemRepository = services.GetRequiredService<IBasketItemRepository>();
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var basketGuid = session.GetString("basketGuid") ?? new Guid().ToString();
            session.SetString("basketGuid", basketGuid);

            return new BasketService(basketItemRepository, basketGuid);
            
        }

        public async Task<BasketItem> AddBasketItemAsync(Book book)
        {
            Guard.Against.Null(book, nameof(Book));
            Guard.Against.Negative(book.Price, nameof(Book.Price));

            var basketItem = new BasketItem()
            {
                Book = book,
                basketGuid = this.basketGuid
            };

           return await basketItemRepository.AddAsync(basketItem);
        }

        public async Task<BasketItem> RemoveBasketItemAsync(BasketItem basketItem)
        {
            Guard.Against.Null(basketItem, nameof(BasketItem));
            Guard.Against.Null(basketItem.Book, nameof(BasketItem.Book));

            return await basketItemRepository.DeleteAsync(basketItem);
        }

        public async Task<IEnumerable<BasketItem>> GetAllBasketItemsAsync()
        {
            var items = await basketItemRepository.ListAsync(new BasketItemIncludeBookSpecification(basketGuid));

            return items;
        }

        public async Task RemoveAllBasketItemsAsync()
        {
            await basketItemRepository.RemoveAllBasketItems(basketGuid);
        }
    }
}
