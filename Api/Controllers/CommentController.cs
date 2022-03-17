using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.EventHandler.Commands;
using Services.Queries;
using Services.Queries.DTOs;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ILogger<CommentController> _logger;
        private readonly ICommentQueryService _commentQueryService;
        private readonly IMediator _mediator;

        public CommentController(ILogger<CommentController> logger, ICommentQueryService commentQueryService, IMediator mediator)
        {
            _logger = logger;
            _commentQueryService = commentQueryService;
            _mediator = mediator;
        }

        //[AllowAnonymous]
        //posts
        [HttpGet]
        public async Task<List<CommentDto>> GetAll()
        {
            return await _commentQueryService.GetAllAsync();
        }

        //[Authorize(Roles = "PowerUser")]
        //posts/1
        [HttpGet("{id}")]
        public async Task<CommentDto> Get(int id)
        {
            return await _commentQueryService.GetAsync(id);
        }

        //posts/1
        [HttpPost]
        public async Task<IActionResult> Create(CommentCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CommentUpdateCommand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }
    }
}
