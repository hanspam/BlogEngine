using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.EventHandler.Commands;
using Services.Queries;
using Services.Queries.DTOs;

namespace Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("posts")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostQueryService _postQueryService;
        private readonly IMediator _mediator;

        public PostController(ILogger<PostController> logger, IPostQueryService postQueryService, IMediator mediator)
        {
            _logger = logger;
            _postQueryService = postQueryService;
            _mediator = mediator;
        }

        //[AllowAnonymous]
        //posts
        [HttpGet]
        public async Task<List<PostDto>> GetAll()
        {
            return await _postQueryService.GetAllAsync();
        }

        //[Authorize(Roles = "PowerUser")]
        //posts/1
        [HttpGet("{id}")]
        public async Task<PostDto> Get(int id)
        {
            return await _postQueryService.GetAsync(id);
        }

        //posts/1
        [HttpPost]
        public async Task<IActionResult> Create(PostCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }
    }
}