using System;
using System.Threading.Tasks;
using Nancy;
using Nancy.Hosting.Self;

namespace EventStreamingService.SubscribeApi
{
    class Program
    {
        private const string HostUrl = "http://localhost:1234";
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri(HostUrl)))
            {
                host.Start();
                
                Console.WriteLine("Host started on " + HostUrl);
                Console.ReadKey();
            }
        }
    }

    public class RoutingModule : NancyModule
    {
        public RoutingModule()
        {
            Get("/ping", _ => "Okay");

            Get("/", async (args, ct) => await Task.FromResult(200));
        }
    }
}
