using GigaChatApi.Models;
using GigaChatApi.Queries;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace GigaChatApi.Hubs
{
    public class PostHub : Hub
    {
        private readonly ISender _sender;

        public PostHub(ISender sender)
        {
            _sender = sender;
        }
        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _sender.Send(new GetPostsQuery());
        }

        public async Task AddPostAsync(string text)
        {
            Post post = new Post() { Text = text }; 
        }
    }
}
