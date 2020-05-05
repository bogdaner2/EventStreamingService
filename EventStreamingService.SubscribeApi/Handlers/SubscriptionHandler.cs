using System;
using System.Threading;
using System.Threading.Tasks;
using EventStreamingService.Core.Domain;
using EventStreamingService.DAL.Cassandra;
using EventStreamingService.DAL.ELK;
using EventStreamingService.SubscribeApi.Commands;
using MediatR;

namespace EventStreamingService.SubscribeApi.Handlers
{
    public class SubscriptionHandler: IRequestHandler<AddSubscriber, int>
    {
        public async Task<int> Handle(AddSubscriber request, CancellationToken cancellationToken)
        {
            var sub = new Subscriber
            {
                IP = request.IP,
                Name = request.Name,
                Type = request.Type
            };

            using var db = new CassandraContext();
            using var logStore = new ELKContext();
                
            // db.CreateSubscription(sub);
            await logStore.LogAsync(new Log
            {
                Id = Guid.NewGuid(),
                Severity = "Info",
                Message = $"Sub has been created: {sub.Name} IP: {sub.IP}",
                Time = DateTime.UtcNow,
                ServiceName = "SubscribeAPI"
            });

            return 0;
        }
    }
}