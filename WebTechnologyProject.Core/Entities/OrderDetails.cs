using System;
using System.Collections.Generic;
using System.Text;

namespace WebTechnologyProjectCore.Entities
{
    public class OrderDetails: BaseEntity
    {
        public int OrderID { get; set; }
        public List<Book> Books { get; set; }
        public Order Order { get; set; }

    }
}
