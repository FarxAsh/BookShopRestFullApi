using System;
using System.Collections.Generic;
using System.Text;
using WebTechnologyProjectCore.Enums;

namespace WebTechnologyProjectCore.Entities
{
    public class Book: BaseEntity
    {      
        public string Title { get; set; }      
        public int Year { get; set; }     
        public int Pages { get; set; }
        public string ImagePath { get; set; }      
        public string Description { get; set; }
        public Genre Genre { get; set; }   
        public int Price { get; set; }  
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public List<BookFeedBack> FeedBacks { get; set; }

       
     
    }
}
