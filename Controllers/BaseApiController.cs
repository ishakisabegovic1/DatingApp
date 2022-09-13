using DatingAppServer.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppServer.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : Controller
    {
        
    }
}
