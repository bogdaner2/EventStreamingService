using System;
using Cassandra;
using Cassandra.Mapping;
using EventStreamingService.Core.Domain;

namespace EventStreamingService.DAL.Cassandra
{
    public class CassandraContext: IDisposable
    {
        private readonly ISession _session;
        public CassandraContext()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1").Build();

            _session = cluster.Connect("streaming");
        }

        public void CreateSubscription(Subscriber subscriber)
        {
/*            var mapper = new Mapper(_session);
            
            mapper.Insert(subscriber);*/
            
            var query =
                $"INSERT INTO subscriber (id, ip, name, type) VALUES (uuid(), '{subscriber.IP}', '{subscriber.Name}', '{subscriber.Type}')";
            
            Console.WriteLine(query);
            
            _session.Execute(query);
        }

        public void Dispose()
        {
            _session?.Dispose();
        }
    }
}