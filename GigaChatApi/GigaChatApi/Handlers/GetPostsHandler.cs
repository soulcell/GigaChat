using GigaChatApi.Models;
using GigaChatApi.Queries;
using MediatR;
using Redis.OM;
using Redis.OM.Contracts;
using Redis.OM.Searching;

namespace GigaChatApi.Handlers
{
    public class GetPostsHandler : IRequestHandler<GetPostsQuery, IEnumerable<Post>>
    {
        private readonly IRedisConnectionProvider _provider;
        private readonly IRedisCollection<Post> _posts;

        public GetPostsHandler(IRedisConnectionProvider provider)
        {
            _provider = provider;
            _posts = _provider.RedisCollection<Post>();
        }
        public async Task<IEnumerable<Post>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            return await _posts.ToListAsync();
        }
    }
}
