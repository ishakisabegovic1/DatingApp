using DatingAppServer.Data;
using DatingAppServer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DatingAppServer.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly AppDbContext _dbcontext;

        public BuggyController(AppDbContext context)
        {
            _dbcontext = context;
        }

        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<string> GetNotFound()
        {
            var thing = _dbcontext.Users.Find(-1);

            if (thing == null) return NotFound();

            return Ok(thing);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
                var thing = _dbcontext.Users.Find(-1);

                var thingToReturn = thing.ToString();

                return thingToReturn;
         
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }

       



    }
}
