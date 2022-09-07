using DatingAppServer.Data;
using DatingAppServer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace DatingAppServer.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class UsersController : Controller
    {
        private readonly AppDbContext _dbContext;

        public UsersController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }


    }
}
