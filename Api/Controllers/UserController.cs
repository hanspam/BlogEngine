using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.EventHandler.Commands;
using Services.Queries;
using Services.Queries.DTOs;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserQueryService _userQueryService;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IUserQueryService userQueryService, IMediator mediator)
        {
            _logger = logger;
            _userQueryService = userQueryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<UserDto>> GetAll()
        {
            return await _userQueryService.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }
    }
}
