using MediatR;
using System.Collections.Generic;
using WebTechnologyProjectCore.Entities;

namespace WebTecnologyProjectApi.CQRS.Queries
{
    public class GetAllBooksQuery: IRequest<IEnumerable<Book>>
    {

    }
}
