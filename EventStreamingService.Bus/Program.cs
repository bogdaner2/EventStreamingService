using System;
using System.Threading;
using System.Threading.Tasks;
using EventStreamingService.Core.Messaging;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace EventStreamingService.Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            var consumer = new KafkaConsumer("Football");
            Console.WriteLine("Consumer started...");

            Task.Run(() =>
            {
                consumer.SubscribeOnTopic("Football", Console.WriteLine);
            });

            Console.ReadLine();
            consumer.Dispose();
/*

            
            var serviceProvider = new ServiceCollection()
                .AddStackExchangeRedisCache(opt =>
                {
                    opt.Configuration = "localhost";
                    opt.InstanceName = "master";
                });

            var consumerConfig = new ConsumerConfig
            {
                GroupId = "banana-consumers",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
            
            consumer.Dispose();
                
            using (var scope = serviceProvider.BuildServiceProvider())
            {
                var cache = scope.GetService<IDistributedCache>();
                cache.Set("items", Encoding.UTF8.GetBytes("item"));
                var items = cache.Get("items");
            }
*/

            Console.ReadLine();
        }
        
    }
}
