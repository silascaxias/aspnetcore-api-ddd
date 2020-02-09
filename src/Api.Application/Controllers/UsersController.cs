using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Controllers.Base;
using Api.Application.Controllers.Extensions;
using Api.Application.ViewModels.Response;
using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    public class UsersController: BaseController
    {
        private IUserService service;
        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [Authorize("Bearer")]
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

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var result = await service.Get(id);
                if(result == null) {
                    return NotFound(false.AsNotFoundResponse("Usuário não encontrado."));
                }
                return Ok(result);
            }
            catch (ArgumentException e)
            {                
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDtoCreate user)
        {
            try
            {
                if (!user.Email.IsEmail())
                {
                    return UnprocessableEntity(false.AsUnprocessableResponse("Por favor entre com um e-mail válido."));
                }
                
                if(!await service.IsValidEmail(user.Email, Guid.Empty)) {
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
        
        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserDtoUpdate user)
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

                if ( await service.Put(user) == null) {
                    return BadRequest();                   
                }
                return Ok(true.AsSuccessResponse("Usuário alterado com sucesso."));
            }
            catch (ArgumentException e)
            {                
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                if(!await service.Exist(id)) {
                    return NotFound(false.AsNotFoundResponse("Usuário não encontrado."));
                }
                if(await service.Delete(id)) {
                    return Ok(true.AsSuccessResponse("Usuário deletado com sucesso.")); 
                }    
                return BadRequest();                
            }
            catch (ArgumentException e)
            {                
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
