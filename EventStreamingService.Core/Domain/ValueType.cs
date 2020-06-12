namespace EventStreamingService.Core.Domain
{
    public class TemperatureValue
    {
        public int Val { get; set; }
        public string Type => "number";
    }
}
