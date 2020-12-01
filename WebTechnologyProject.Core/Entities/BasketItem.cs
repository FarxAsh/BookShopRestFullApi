using System;
using System.Collections.Generic;
using System.Text;

namespace WebTechnologyProjectCore.Entities
{
    public class BasketItem: BaseEntity
    {
        public Book Book { get; set; }
        public string basketGuid { get; set; }
    }
}
