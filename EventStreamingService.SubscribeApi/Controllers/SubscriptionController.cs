using System.Net;
using System.Threading.Tasks;
using EventStreamingService.SubscribeApi.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventStreamingService.SubscribeApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class SubscriptionController: ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddSubscriber command)
        {
            var result = await _mediator.Send(command);
            
            return Accepted(result);
        }
    }
}