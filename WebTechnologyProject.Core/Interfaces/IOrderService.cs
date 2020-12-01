using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebTechnologyProjectCore.Entities;
using Ardalis.GuardClauses;

namespace WebTechnologyProjectCore.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);   
    }
}
