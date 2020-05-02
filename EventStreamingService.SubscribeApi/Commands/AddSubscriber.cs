using MediatR;

namespace EventStreamingService.SubscribeApi.Commands
{
    public class AddSubscriber: IRequest<int>
    {
        public string Name { get; set; }
        public string IP { get; set; }
        public string Type { get; set; }
    }
}