using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Confluent.Kafka;

namespace EventStreamingService.Core.Messaging
{
    public class KafkaConsumer: IDisposable
    {
        private readonly IConsumer<Ignore, string> _consumer;
        private static readonly ConsumerConfig DefaultConfig = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            EnableAutoCommit = true,
            AutoCommitIntervalMs = 5000,
            FetchWaitMaxMs = 5000,
            FetchMinBytes = 4000,
            ApiVersionRequest = true,
            GroupId = "Football"
            
            /*AutoOffsetReset = AutoOffsetReset.Earliest*/
        };
        public KafkaConsumer(string groupId): this(DefaultConfig)
        {
            DefaultConfig.GroupId = groupId;
        }

        public KafkaConsumer(ConsumerConfig config)
        {
            _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        }
        
        public void SubscribeOnTopic(string topic, Action<string> action, CancellationToken cancellationToken = default)
        {
            _consumer.Subscribe(topic);

            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                var message = _consumer.Consume(cancellationToken);
                action(message.Value);
            }
        }
    
        public void Dispose()
        {
            _consumer?.Dispose();
        }
    }
}