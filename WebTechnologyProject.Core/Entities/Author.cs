using System;
using System.Collections.Generic;
using System.Text;
using WebTechnologyProjectCore.Enums;

namespace WebTechnologyProjectCore.Entities
{
    public class Author: BaseEntity
    {
        public Genre? Genre { get; set; }       
        public string FirstName { get; set; }        
        public string LastName { get; set; }       
        public string ImagePath { get; set; }      
        public string Biography { get; set; }
        public List<Book> Books { get; set; }
    }
}
