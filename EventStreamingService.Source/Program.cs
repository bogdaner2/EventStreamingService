using System;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using EventStreamingService.Core.Messaging;
using Newtonsoft.Json;

namespace EventStreamingService.Source
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
        }

        public class Event
        {
            public Guid Id { get; set; }
            public string Type { get; set; }
            public string Value { get; set; }
        }

        private static void Execute()
        {

            foreach (var i in Enumerable.Range(0, 3))
            {
                Task.Run(() =>
                {
                    var producer = new KafkaProducer("Football");
                    var guid = Guid.NewGuid();

                    var random = new Random();
                    Timer timer = null;

                    timer = new Timer((state) =>
                        {
                            var model = new Event
                            {
                                Id = guid,
                                Type = "Card",
                                Value = "Red Card"
                            };
                            producer.SendMessage(JsonConvert.SerializeObject(model));
                            timer.Change(random.Next(1000, 3000), Timeout.Infinite);
                        },
                        null, random.Next(1000, 3000), Timeout.Infinite);
                });
            }

            Console.ReadLine();
            
        }
    }
}
