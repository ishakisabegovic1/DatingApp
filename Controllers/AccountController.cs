using AutoMapper;
using DatingAppServer.Data;
using DatingAppServer.DTos;
using DatingAppServer.Entities;
using DatingAppServer.Interfaces;
using DatingAppServer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;

namespace DatingAppServer.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(AppDbContext context, ITokenService tokenService, IMapper mapper)
        {
            _context = context;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public ActionResult<UserDto> Register(RegisterDto registerDto)
        {
            if (UserExists(registerDto.Username)) return BadRequest("Username is taken");

            var user = _mapper.Map<AppUser>(registerDto);

            using var hmac = new HMACSHA512();


            user.userName = registerDto.Username;
            user.PaswwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
            user.PaswwordSalt = hmac.Key;
            

            _context.Users.Add(user);

            _context.SaveChanges();

            return new UserDto
            {
                Username = user.userName,
                Token = _tokenService.CreateToken(user),
                KnownAs = user.KnownAs,
                Gender = user.Gender
            };
        }

        [HttpPost("login")]
        public ActionResult<UserDto> Login(LoginDto loginDto)
        {
            var user = _context.Users.SingleOrDefault(x => x.userName == loginDto.Username);
            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PaswwordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int i=0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PaswwordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDto
            {
                Username = user.userName,
                Token = _tokenService.CreateToken(user),
                KnownAs = user.KnownAs
            };
        }

        private bool UserExists(string username)
        {
            return _context.Users.Any(x => x.userName == username);
        }
    }
}
