using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebTechnologyProjectCore.Interfaces;
using WebTechnologyProjectCore.Entities;
using MediatR;
using WebTecnologyProjectApi.CQRS.Queries;
using WebTecnologyProjectApi.CQRS.Commands;
using WebTechnologyProjectCore.Enums;
using AutoMapper;
using WebTecnologyProjectApi.ViewModels;
using Microsoft.AspNetCore.Http;

namespace WebTecnologyProjectApi.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public BookController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookViewModel>>> GetAllBooks()
        {
            var bookList = await mediator.Send(new GetAllBooksQuery());
            var response = mapper.Map<List<BookViewModel>>(bookList);
   
            return Ok(response);
        }

        [HttpGet]
        [Route("filters")]
        public async Task<ActionResult<IEnumerable<BookViewModel>>> GetFilteredBooks([FromQuery] Genre? genre, [FromQuery] string author)
        {
            var filteredBookList = await mediator.Send(new GetFilteredBooksQuery(genre, author));
            var response = mapper.Map<List<BookViewModel>>(filteredBookList);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Book>> GetBook([FromQuery] int id)
        {
            var book = await mediator.Send(new GetBookByIdQuery(id));

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Book>> CreateBook([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            var createdBook = await mediator.Send(new CreateBookCommand(book));

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut]
        public async Task<ActionResult<Book>> UpdateBook([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            var response = await mediator.Send(new UpdateBookCommand(book));
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id})")]
        public async Task<ActionResult<Book>> DeleteBook([FromQuery] int id)
        {
            var deletedBook = await mediator.Send(new DeleteBookCommand(id));

            return Ok(deletedBook);
        }
    }
}
