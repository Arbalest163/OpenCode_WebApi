

namespace AccessControlService.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/users")]
    public class AccessControlController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AccessControlController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserListVm>> Get(string? name)
        {
            var request = new GetUserListQuery
            { 
                Query = name 
            };
            var vm = await _mediator.Send(request);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserVm>> Get(int id)
        {
            var request = new GetUserQuery
            {
                Id = id
            };
            var vm = await _mediator.Send(request);
            return Ok(vm);
        }

        [HttpPost("actions/create")]
        public async Task<ActionResult<int>> Create([FromForm] CreateUserDto createUser)
        {
            var command = _mapper.Map<CreateUserCommand>(createUser);
            var userId = await _mediator.Send(command);
            return Ok(userId);
        }

        [HttpPut("{id}/actions/update")]
        public async Task<IActionResult> Update([FromForm] UpdateUserDto updateUser)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUser);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}/actions/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand
            {
                Id = id
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
