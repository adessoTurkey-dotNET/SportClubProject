using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VolleyballClub.Application.Dtos;
using VolleyballClubProject.Core.Entities;
using VolleyballClubProject.Infrastructure.Context;
using VolleyballClubProject.Infrastructure.JwtToken;

namespace VolleyballClubProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _configuration;
        private IMapper _mapper;
        public LoginController(ApplicationDbContext content, IConfiguration configuration, IMapper mapper)
        {
            _context = content;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<bool> CreateUser([FromForm] UserInfoDto user)
        {
            _context.UserInfo.Add(_mapper.Map<UserInfo>(user));
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpPost]
        public async Task<Token> CreateToken([FromForm] UserDto userLogin)
        {
            var user = _context.UserInfo.FirstOrDefault(x => x.Email == userLogin.Email && x.Password == userLogin.Password);
            if (user != null)
            {
                //generate token
                var tokenHandler = new JwtTokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                //RefreshToken updating
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(30);
                await _context.SaveChangesAsync();

                return token;
            }
            return null;
        }

        [HttpGet]
        public async Task<Token> RefreshTokenLogin([FromForm] string refreshToken)
        {
            var user = _context.UserInfo.FirstOrDefault(x => x.RefreshToken == refreshToken);
            if (user != null && user.RefreshTokenEndDate > DateTime.Now)
            {
                var tokenHandler = new JwtTokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                await _context.SaveChangesAsync();

                return token;
            }
            return null;
        }
    }
}
