using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Controllers.Base;
using Api.Application.ViewModels.Response;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class LoginController: BaseController
    {
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService services)
        {
            if (loginDto == null) 
            {
                return BadRequest(BadRequest());
            }
            
            try
            {
                var result = await services.Authenticate(loginDto);
                return result;
            }
            catch (ArgumentException e)
            {                
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}