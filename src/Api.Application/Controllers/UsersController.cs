using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IUserService service)
        {
            try
            {
                return Ok(await service.GetAll());
            }
            catch (ArgumentException e)
            {                
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}