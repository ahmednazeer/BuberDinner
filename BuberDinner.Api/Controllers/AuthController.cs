using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BuberDinner.Contracts.Authentication;
using BuberDinner.Application.Services.Authentication;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserRequest model){
            var result= _authService.Register(model.FirstName,model.LastName,model.Email,model.Password);
            var responseModel=new AuthenticationResponse(result.Id,result.FirstName,result.LastName,result.Email,result.Token);
            return Ok(responseModel);
        }
        
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model){
            var result= _authService.Login(model.Email,model.Password);
            var responseModel=new AuthenticationResponse(result.Id,result.FirstName,result.LastName,result.Email,result.Token);
            return Ok(responseModel);
        }
    }
}