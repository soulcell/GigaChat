using GigaChatApi.Models;
using MediatR;

namespace GigaChatApi.Queries
{
    public record GetPostsQuery: IRequest<IEnumerable<Post>>;
}
