using GigaChatApi.Dtos;
using MediatR;

namespace GigaChatApi.Queries
{
    public record SignInQuery(string Username, string Password) : IRequest<UserDTO>;
}
