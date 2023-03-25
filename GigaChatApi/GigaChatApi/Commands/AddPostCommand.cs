using GigaChatApi.Models;
using MediatR;

namespace GigaChatApi.Commands
{
    public record AddPostCommand(Post post) : IRequest<Post>;
}
