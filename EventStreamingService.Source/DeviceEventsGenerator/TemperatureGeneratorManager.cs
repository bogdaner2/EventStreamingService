using System;
using System.Linq;
using System.Threading.Tasks;
using EventStreamingService.DAL.ELK;

namespace EventStreamingService.Source.DeviceEventsGenerator
{
    public class TemperatureGeneratorManager
    {

        public void Execute()
        {
            var startDay = DateTime.Today;
            var r = new Random();
            var value = r.Next(-5, 24);

            foreach (var i in Enumerable.Range(0, 10))
            {
                var day = startDay;
                Task.Run(() =>
                {
                    var temperatureManager = new TemperatureDeviceEventsGenerator();
                    temperatureManager.BuildDayStats(day);
                    var context = new ELKContext("temperature");

                    var dayValues = value + new Random().Next(-5, 5);

                    foreach (var _ in Enumerable.Range(0, 24))
                    {
                        var @event = temperatureManager.Generate(dayValues);

                        context.WriteDynamicAsync(@event);
                    }

                    temperatureManager.Reset();
                    context.Dispose();

                });
                startDay = startDay.AddDays(1);
            }

        }
    }
}
