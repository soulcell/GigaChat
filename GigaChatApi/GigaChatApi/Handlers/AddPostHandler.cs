using GigaChatApi.Commands;
using GigaChatApi.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Redis.OM;
using Redis.OM.Contracts;
using Redis.OM.Searching;

namespace GigaChatApi.Handlers
{
    public class AddPostHandler : IRequestHandler<AddPostCommand, Post>
    {
        private readonly IRedisConnectionProvider _provider;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRedisCollection<Post> _posts;

        public AddPostHandler(IRedisConnectionProvider provider, UserManager<AppUser> userManager)
        {
            _provider = provider;
            _posts = _provider.RedisCollection<Post>();
            _userManager = userManager;
        }
        public async Task<Post> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            Post post = request.post;
            AppUser? author = await _userManager.FindByIdAsync(post.AuthorId.ToString());
            if (author != null)
            {
                post.AuthorName = author.UserName!;
                var key = await _posts.InsertAsync(request.post);
                return _provider.Connection.Get<Post>(key);
            }
            return null;
        }
    }
}
