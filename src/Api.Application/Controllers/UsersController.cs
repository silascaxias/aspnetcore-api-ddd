using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Controllers.Base;
using Api.Application.Controllers.Extensions;
using Api.Application.ViewModels.Response;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private IUserService service;
        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
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

        [HttpGet]
        [Route("{id}", Name = "GetById")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await service.Get(id));
            }
            catch (ArgumentException e)
            {                
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserEntity user)
        {
            try
            {
                if (!user.Email.IsEmail())
                {
                    return UnprocessableEntity(false.AsUnprocessableResponse("Por favor entre com um e-mail válido."));
                }
                
                if(!await service.IsValidEmail(user.Email, user.Id)) {
                    return Conflict(false.AsConflictResponse("E-mail já cadastrado."));
                }

                if (await service.Post(user) == null) {
                    return BadRequest();                    
                }
                return Ok(true.AsSuccessResponse("Usuário registrado com sucesso."));
            }
             catch (ArgumentException e)
            {                
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserEntity user)
        {
            try
            {
                if(!await service.Exist(user.Id)) {
                    return NotFound(false.AsNotFoundResponse("Usuário não encontrado."));
                }
                if (!user.Email.IsEmail())
                {
                    return UnprocessableEntity(false.AsUnprocessableResponse("Por favor entre com um e-mail válido."));
                }
                
                if(!await service.IsValidEmail(user.Email, user.Id)) {
                    return Conflict(false.AsConflictResponse("E-mail já cadastrado."));
                }

                var result = await service.Put(user);

                if (result == null) {
                    return BadRequest();                   
                }
                return Ok(true.AsSuccessResponse("Usuário alterado com sucesso."));
            }
            catch (ArgumentException e)
            {                
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
