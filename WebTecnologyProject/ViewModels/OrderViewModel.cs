using System;
using WebTechnologyProjectCore.Enums;

namespace WebTecnologyProjectApi.ViewModels
{
    public class OrderViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string ContactPhone { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime deleveryDateTime { get; set; }
    }
}
