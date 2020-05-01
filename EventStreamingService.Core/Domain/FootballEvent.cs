using System;

namespace EventStreamingService.Core.Domain
{
    public class FootballEvent : Event
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime Time { get; set; }
    }
}