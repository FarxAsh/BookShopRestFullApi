using System;
using System.Collections.Generic;
using System.Text;
using WebTechnologyProjectCore.Enums;

namespace WebTechnologyProjectCore.Entities
{
    public class Order: BaseEntity
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double TotalPrice { get; set; }
        public string Byer { get; set; }     
        public string Adress { get; set; }      
        public string ContactPhone { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime deleveryDateTime { get; set; }
        public DateTime orderDateTime { get; set; }
        public OrderDetails OrderDetails { get; set; }

    }
}
