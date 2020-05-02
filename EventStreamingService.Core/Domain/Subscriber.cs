namespace EventStreamingService.Core.Domain
{
    public class Subscriber: Base
    {
        public string Name { get; set; }
        public string IP { get; set; }
        public string Type { get; set; }
    }
}