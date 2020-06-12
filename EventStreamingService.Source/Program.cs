using System;
using System.Linq;
using System.Threading.Tasks;
using EventStreamingService.Core.Domain;
using EventStreamingService.DAL.ELK;
using EventStreamingService.Source.DeviceEventsGenerator;
using Newtonsoft.Json;

namespace EventStreamingService.Source
{
    class Program
    {
        static void Main(string[] args)
        {

            Execute();
        }
        
        private static void Execute()
        {
            TemperatureGeneratorManager manager = new TemperatureGeneratorManager();

            manager.Execute();

            Console.ReadLine();
        }
    }
}


//using (var producer = new KafkaProducer("Temperature"))
//{

//}
////var guid = Guid.NewGuid();

//var random = new Random();
//Timer timer = null;

//timer = new Timer((state) =>
//    {
//        var model = new FootballEvent
//        {
//            Id = guid,
//            Type = "Card",
//            HomeTeam = "New",
//            AwayTeam = "Old",
//            Time = DateTime.Now
//        };
//        producer.SendMessage(JsonConvert.SerializeObject(model));
//        timer.Change(random.Next(1000, 3000), Timeout.Infinite);
//    },
//    null, random.Next(1000, 3000), Timeout.Infinite);



//var r = new Random();

//foreach (var _ in Enumerable.Range(0, 100))
//{
//var log = new Log
//{
//    Id = Guid.NewGuid(),
//    ServiceName = "Source",
//    Time = DateTime.Now
//};

//var a = r.Next(0, 10);
//    if (a >= 0 && a< 2)
//{
//    log.Severity = "Warning";
//}

//if (a == 2)
//{
//    log.Severity = "Error";
//}

//if (a > 2)
//{
//    log.Severity = "Info";
//}

//log.Severity = "Info";

//var context = new ELKContext("streaming_logs");

//context.WriteDynamicAsync(log);

//context.Dispose();