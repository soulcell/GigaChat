using GigaChatApi.Models;
using Microsoft.AspNetCore.SignalR;
using Redis.OM;
using Redis.OM.Contracts;
using Redis.OM.Searching;

namespace GigaChatApi.Hubs
{
    public class LiveHub: Hub
    {
        private readonly IRedisConnectionProvider _provider;
        private readonly IRedisConnection _connection;
        private readonly IRedisCollection<Live> _lives;

        public LiveHub(IRedisConnectionProvider provider)
        {
            _provider = provider;
            _connection = _provider.Connection;
            _lives = _provider.RedisCollection<Live>();
        }

        public async Task AddLive()
        {
            await _lives.InsertAsync(new Live());
        }
    }
}
