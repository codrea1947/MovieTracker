using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTracker.Models.Dto;
using MovieTracker.Models.Entities;
using MovieTracker.Services.Interfaces;

namespace MovieTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserController(
            IMapper mapper,
            IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("Register")]
        public ActionResult<string> Register(UserRegister userRegister)
        {
            var user = _mapper.Map<User>(userRegister);

            var authToken = _userService.RegisterUser(user);

            return Ok(authToken);
        }

        [HttpPost("LogIn")]
        public ActionResult<string> LogIn(UserLogIn userLogIn)
        {
            return Ok(_userService.LogIn(userLogIn.EmailAddress, userLogIn.Password));
        }
    }
}
