using Br.Com.Fiap.Api.DTO;
using Br.Com.Fiap.Api.Extensions;
using Br.Com.Fiap.Application.Interfaces;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Api.Controllers
{
    [ApiController]
    [Route("login")]
    public class AccountController(IUserService userService, ITokenService tokenService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly ITokenService _tokenService = tokenService;        

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userService.FindByUsernameAndPassword(loginDto.Login, loginDto.Senha);

                if (user is null)
                    return BadRequest("Invalid credential.");

                var token = _tokenService.GetToken(user);

                var authenticatedUser = new { loginDto.Login, Token = token };

                return Ok(authenticatedUser);
            }
            catch (Exception exception)
            {
                
                return BadRequest(exception.Message);
            }            
        }
    }
}
