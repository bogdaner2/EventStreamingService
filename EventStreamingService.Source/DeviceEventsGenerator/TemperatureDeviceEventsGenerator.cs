using System;
using EventStreamingService.Core.Domain;
using Nest;

namespace EventStreamingService.Source.DeviceEventsGenerator
{
    public class TemperatureDeviceEventsGenerator
    {
        private DateTime _currentDate;
        public void BuildDayStats(DateTime day)
        {
            if (_currentDate != DateTime.MinValue)
            {
                return;
            }

            if (day == DateTime.MinValue)
            {
                _currentDate = DateTime.Today;
                return;
            }

            _currentDate = day;
        }

        public void Reset()
        {
            _currentDate = DateTime.MinValue;
        }
        public TemperatureDeviceEvent Generate(int value)
        {
            _currentDate = _currentDate.AddHours(1);
            var r = new Random();

            return new TemperatureDeviceEvent
            {
                Id = Guid.NewGuid(),
                Type = "Temperature Monitor",
                Time = _currentDate,
                Measure = "C",
                Value = new TemperatureValue
                {
                    Val = CalculateValue(value + r.Next(-2, 2))
                }
            };
        }

        private int CalculateValue(int value)
        {
            var r = new Random();

            if (DateTime.Today.AddHours(18) <= _currentDate)
            {
                return value - r.Next(0, 4);
            }

            return value;
        }
    }
}
