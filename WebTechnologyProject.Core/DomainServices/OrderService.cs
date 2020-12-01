using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebTechnologyProjectCore.Interfaces;
using Ardalis.GuardClauses;
using WebTechnologyProjectCore.Entities;

namespace WebTechnologyProjectCore.DomainServices
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IBasketService basketService;
        private readonly IAsyncRepository<OrderDetails> orderDetailsRepository;
        public OrderService(IOrderRepository orderRepository, IBasketService basketService, IAsyncRepository<OrderDetails> orderDetailsRepository)
        {
            this.orderRepository = orderRepository;
            this.basketService = basketService;
            this.orderDetailsRepository = orderDetailsRepository;
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            Guard.Against.Null(order, nameof(Order));

            order.TotalPrice = await GetTotalPrice(order);

            await orderRepository.AddAsync(order);

            await CreateOrderDetailsAsync(order);

            await basketService.RemoveAllBasketItemsAsync();
            
            return order;

        }

        async Task CreateOrderDetailsAsync(Order order)
        {
            List<Book> books = new List<Book>();
            foreach(var item in await basketService.GetAllBasketItemsAsync())
            {
                books.Add(item.Book);
            }

            var orderDetails = new OrderDetails()
            {
                OrderID = order.Id,
                Books = books
            };
        }
        async Task<double> GetTotalPrice(Order order)
        {
            double totalPrice = 0;
            foreach(var item in await basketService.GetAllBasketItemsAsync())
            {
                totalPrice += GetDiscountForBook(item.Book);
            }

            return GetCommonDiscount(totalPrice, order);
        }

        double GetDiscountForBook(Book book)
        {
            if (book.Genre == Enums.Genre.Science) return book.Price * 0.8;
            if (book.Genre == Enums.Genre.Fantasy) return book.Price * 0.7;
            return book.Price;
        }

        double GetCommonDiscount(double totalPrice, Order order)
        {
            if (order.PaymentType == Enums.PaymentType.cardOnline) return totalPrice * 0.95;
            return totalPrice;
        }
    }
}
