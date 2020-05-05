using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using EventStreamingService.Core.Domain;
using Nest;

namespace EventStreamingService.DAL.ELK
{
    public class ELKContext: IDisposable
    {
        private ElasticClient _client;
        public ELKContext()
        {
            var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
            var connectionSetting = new ConnectionSettings(pool)
                .DefaultIndex("streaming");
            _client = new ElasticClient(connectionSetting);
        }

        public async Task LogAsync(Log logModel)
        {
            var indexResponse = await _client.IndexDocumentAsync(logModel);
        }


        public void Dispose()
        {
            _client = null;
        }
    }
}