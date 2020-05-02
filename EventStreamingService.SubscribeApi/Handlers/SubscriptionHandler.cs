using System.Threading;
using System.Threading.Tasks;
using EventStreamingService.Core.Domain;
using EventStreamingService.DAL.Cassandra;
using EventStreamingService.SubscribeApi.Commands;
using MediatR;

namespace EventStreamingService.SubscribeApi.Handlers
{
    public class SubscriptionHandler: IRequestHandler<AddSubscriber, int>
    {
        public Task<int> Handle(AddSubscriber request, CancellationToken cancellationToken)
        {
            using (var db = new CassandraContext())
            {
                db.CreateSubscription(new Subscriber
                {
                    IP = request.IP,
                    Name = request.Name,
                    Type = request.Type
                });
            }

            return Task.FromResult(0);
        }
    }
}