using WebTechnologyProjectCore.Enums;
using System.Collections.Generic;


namespace WebTecnologyProjectApi.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public Genre Genre { get; set; }
        public int Price { get; set; }
        public string AuthorsName { get; set; }

    }
}
