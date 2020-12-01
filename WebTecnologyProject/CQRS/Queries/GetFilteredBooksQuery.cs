using MediatR;
using System.Collections.Generic;
using WebTechnologyProjectCore.Enums;
using WebTechnologyProjectCore.Entities;


namespace WebTecnologyProjectApi.CQRS.Queries
{
    public class GetFilteredBooksQuery: IRequest<List<Book>>
    {
        public GetFilteredBooksQuery(Genre? genre, string author)
        {
            this.Genre = genre;
            this.Author = author;
        }

        public Genre? Genre { get; }
        public string Author { get; }
    }
}
