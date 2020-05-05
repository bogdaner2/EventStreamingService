using System;

namespace EventStreamingService.Core.Domain
{
    public class Log
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string Severity { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}