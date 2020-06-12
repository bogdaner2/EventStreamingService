using System;
using System.Linq;
using System.Threading.Tasks;
using EventStreamingService.DAL.ELK;
using EventStreamingService.Source.DeviceEventsGenerator;
using NBomber.Contracts;
using NBomber.CSharp;

namespace EventStreamingService.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var step = Step.Create("Send temperature events", async context =>
            {
                var startDay = DateTime.Today;
                var r = new Random();
                var value = r.Next(-5, 24);

                var day = startDay;
                    var temperatureManager = new TemperatureDeviceEventsGenerator();
                    temperatureManager.BuildDayStats(day);
                    var ctx = new ELKContext("temperature");

                    var dayValues = value + new Random().Next(-5, 5);

                    var data = Enumerable.Range(0, 24)
                        .Select(x => temperatureManager.Generate(dayValues));

                    await Task.WhenAll(
                    data.Select(x => ctx.WriteDynamicAsync(x))
                    );

                    temperatureManager.Reset();
                    // ctx.Dispose();

                //// you can do any logic here: go to http, websocket etc
                //await Task.Delay(TimeSpan.FromSeconds(0.1));
                return Response.Ok();
            }, 5);

            // after creating a step you should add it to Scenario.
            var scenario = ScenarioBuilder
                .CreateScenario("Testing Temperature Source", new[] {step})
                .WithLoadSimulations(new [] { LoadSimulation.NewKeepConcurrentScenarios(50, TimeSpan.FromSeconds(60))});

            NBomberRunner.RegisterScenarios(new[] { scenario })
                .RunInConsole();
        }
    }
}
