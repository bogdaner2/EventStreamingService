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
        public ELKContext(string index = "streaming")
        {
            var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
            var connectionSetting = new ConnectionSettings(pool)
                .DefaultIndex(index);
            _client = new ElasticClient(connectionSetting);
        }

        public async Task LogAsync(Log logModel)
        {
            var indexResponse = await _client.IndexDocumentAsync(logModel);
        }

        public IndexResponse WriteDynamic<T>(T model) where T: class
        {
            return _client.IndexDocument(model);
        }

        public Task<IndexResponse> WriteDynamicAsync<T>(T model) where T : class
        {
            return _client.IndexDocumentAsync(model);
        }

        public void Dispose()
        {
            _client = null;
        }
    }
}