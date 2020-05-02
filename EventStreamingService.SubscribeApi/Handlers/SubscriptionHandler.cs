using System;
using System.Threading;
using System.Threading.Tasks;
using EventStreamingService.SubscribeApi.Commands;
using MediatR;

namespace EventStreamingService.SubscribeApi.Handlers
{
    public class SubscriptionHandler: IRequestHandler<AddSubscriber, int>
    {
        public Task<int> Handle(AddSubscriber request, CancellationToken cancellationToken)
        {
            Console.WriteLine("TEST");

            return Task.FromResult(0);
        }
    }
}