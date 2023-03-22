using GigaChatApi.Commands;
using GigaChatApi.Models;
using MediatR;
using Redis.OM.Contracts;
using Redis.OM.Searching;

namespace GigaChatApi.Handlers
{
    public class AddPostHandler : IRequestHandler<AddPostCommand>
    {
        private readonly IRedisConnectionProvider _provider;
        private readonly IRedisCollection<Post> _posts;

        public AddPostHandler(IRedisConnectionProvider provider)
        {
            _provider = provider;
            _posts = _provider.RedisCollection<Post>();
        }
        public async Task Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            await _posts.InsertAsync(request.post);
        }
    }
}
