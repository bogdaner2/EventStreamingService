using System;
using Confluent.Kafka;

namespace EventStreamingService.Core.Messaging
{
    public class KafkaProducer: IDisposable
    {
        private readonly IProducer<Null, string> _producer;
        private static readonly ProducerConfig DefaultConfig = new ProducerConfig
        {
            BootstrapServers = "localhost:9092",
            BatchNumMessages = 50000,
            QueueBufferingMaxMessages = 300,
            CompressionType = CompressionType.Snappy
        };

        private readonly string _topic;
        
        public KafkaProducer(): this(DefaultConfig)
        {
        }
        
        public KafkaProducer(string topic): this(DefaultConfig)
        {
            _topic = topic;
        }

        public KafkaProducer(ProducerConfig config)
        {
            _producer = new ProducerBuilder<Null, string>(config)
                .SetStatisticsHandler((_, json) => Console.WriteLine($"Stats: {json}"))
                .Build();
        }

        public void SendMessage(string topic, string message)
        {
            _producer.Produce(topic, new Message<Null, string>
            {
                Value = message
            });
        }
        
        public void SendMessage(string message)
        {
            if(string.IsNullOrEmpty(_topic))
                throw new ArgumentException("Topic is null. Provide topic by constructor or overloaded method.");
            
            _producer.Produce(_topic, new Message<Null, string>
            {
                Value = message
            });
        }
        
        public void Dispose()
        {
            _producer?.Dispose();
        }
    }
}