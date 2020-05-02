using System;
using System.Collections.Generic;
using EventStreamingService.Core.Domain;
using MediatR;

namespace EventStreamingService.SubscribeApi.Queries
{
    public class GetScheduleForSpecificDay: IRequest<List<Event>>
    {
        public DateTime Date { get; set; }
    }
}