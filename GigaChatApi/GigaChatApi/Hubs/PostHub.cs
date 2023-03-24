using GigaChatApi.Commands;
using GigaChatApi.Models;
using GigaChatApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Redis.OM.Modeling;
using System.Security.Claims;

namespace GigaChatApi.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PostHub : Hub
    {
        private readonly ISender _sender;

        public PostHub(ISender sender)
        {
            _sender = sender;
        }
        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var posts = await _sender.Send(new GetPostsQuery());
            return posts;
        }

        public async Task AddPostAsync(string text, GeoLoc location)
        {
            var userId = Context.UserIdentifier;
            Post post = new Post
            {
                AuthorId = Guid.Parse(userId),
                Text = text,
                Location = location
            };
            await _sender.Send(new AddPostCommand(post));
        }
    }
}
