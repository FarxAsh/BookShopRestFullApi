using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTechnologyProjectCore.Interfaces;
using WebTechnologyProjectInfrastructure.Data;
using WebTechnologyProjectCore.DomainServices;
using WebTechnologyProjectCore.Entities;

namespace WebTecnologyProjectApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped(typeof(IBookRepository), typeof(BookRepository));
            services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped(sp => BasketService.GetBasket(sp));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepository<>));

            return services;
        }
    }
}
