
using Microsoft.AspNetCore.Mvc;
using WebShare.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace WebShare.Controllers
{
    [Route("")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        private IHubContext<ShareHub> _shareHubContext;

        public ShareController(IHubContext<ShareHub> shareHubContext)
        {
            _shareHubContext = shareHubContext;
        }

        [HttpGet]
        [Route($"{nameof(Share)}")]
        public void Share([FromQuery] string id, [FromQuery] string url)
        {
            _shareHubContext.Clients.Client(id).SendAsync("ReceiveMessage", url);
        }
    }
}
