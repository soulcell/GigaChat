using GigaChatApi.Models;
using Redis.OM;
using Redis.OM.Contracts;

namespace GigaChatApi.Services
{
    public class IndexCreationService : IHostedService
    {
        private readonly IRedisConnectionProvider _redis;

        public IndexCreationService(IRedisConnectionProvider redis)
        {
            _redis = redis;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _redis.Connection.CreateIndexAsync(typeof(Post));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
