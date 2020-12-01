using System;
using System.Collections.Generic;
using System.Text;

namespace WebTechnologyProjectCore.Entities
{
    public class BookFeedBack: BaseEntity
    {     
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}
