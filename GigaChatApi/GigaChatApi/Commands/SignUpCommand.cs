using GigaChatApi.Dtos;
using MediatR;

namespace GigaChatApi.Commands
{
    public record SignUpCommand(string Username, string Password) : IRequest<UserDTO>;
}
