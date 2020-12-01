using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTechnologyProjectCore.Enums;
using WebTechnologyProjectCore.Entities;
using WebTecnologyProjectApi.ViewModels;
using Microsoft.AspNetCore.Http;
using WebTecnologyProjectApi.CQRS.Queries;
using WebTecnologyProjectApi.CQRS.Commands;

namespace WebTecnologyProjectApi.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController: ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public AuthorController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorViewModel>>> GetAllAuthors()
        {
            var authorsList = await mediator.Send(new GetAllAuthorsQuery());
            var response = mapper.Map<List<AuthorViewModel>>(authorsList);

            return Ok(response);
        }

        [HttpGet]
        [Route("filters")]
        public async Task<ActionResult<IEnumerable<AuthorViewModel>>> GetFilteredAuthors([FromQuery] Genre? genre)
        {
            var filteredAuthorsList = await mediator.Send(new GetFilteredAuthorsQuery(genre));
            var response = mapper.Map<List<AuthorViewModel>>(filteredAuthorsList);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Author>> GetAuthor([FromQuery] int id)
        {
            var author = await mediator.Send(new GetAuthorByIdQuery(id));

            return Ok(author);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Author>> CreateAuthor([FromBody] Author author)
        {
            if (author == null) return BadRequest();
            var createdAuthor = await mediator.Send(new CreateAuthorCommand(author));

            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        [HttpPut]
        public async Task<ActionResult<Author>> UpdateAuthor([FromBody] Author author)
        {
            if (author == null) return BadRequest();
            var response = await mediator.Send(new UpdateAuthorCommand(author));
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id})")]
        public async Task<ActionResult<Author>> DeleteAuthor([FromQuery] int id)
        {
            var deletedAuthor = await mediator.Send(new DeleteAuthorCommand(id));

            return Ok(deletedAuthor);
        }
    }
}
