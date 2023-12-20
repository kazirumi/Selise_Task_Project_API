using BusinessLogicLayer.ApplicationSettingsOptions;
using BusinessLogicLayer.Services.Authentication.DTOs;
using BusinessLogicLayer.Services.Authentication.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SeliseTaskProject.Controllers
{
    [AllowAnonymous]
    [Route("api/Auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [HttpPost("Register")]
        //Post: api/ApplicationUsers/Register
        public async Task<IActionResult> ApplicationUserRegister(AuthRegisterDTO model)
        {

            try
            {
                var result = await _authenticationService.Register(model);

                
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPost("Login")]
        //Post: api/ApplicationUsers/Login
        public async Task<IActionResult> Login(AuthLoginDTO model)
        {
            var result = await _authenticationService.Login(model);

            if (result.Success)
            { 

                return Ok(result);

            }
            else
            {
                return BadRequest(new { message = "User Name or Password is Incorrect" });
            }
        }

    }
}
