using GigaChatApi.Commands;
using GigaChatApi.Dtos;
using GigaChatApi.Models;
using GigaChatApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GigaChatApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender) {
            _sender = sender;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> SignInAsync(SignInQuery query)
        {
            return await _sender.Send(query);
        }

        [HttpPost("signup")]
        public async Task<ActionResult<UserDTO>> SignUpAsync(SignUpCommand command)
        {
            return await _sender.Send(command);
        }

    }
}
