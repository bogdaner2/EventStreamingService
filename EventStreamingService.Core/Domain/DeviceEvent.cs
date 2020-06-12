using System;

namespace EventStreamingService.Core.Domain
{
    public class DeviceEvent: Event
    {
        public string Measure { get; set; }
        public DateTime Time { get; set; }
    }

    public class TemperatureDeviceEvent : DeviceEvent
    {
        public TemperatureValue Value { get; set; }
    }
}
