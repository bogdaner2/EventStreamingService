using System.Collections.Generic;
using EventStreamingService.Core.Domain;
using MediatR;

namespace EventStreamingService.SubscribeApi.Queries
{
    public class GetScheduleForCurrentDay: IRequest<List<Event>>
    {
        
    }
}