using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models.User;
using AutoMapper;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> repository;
        private readonly IMapper mapper;
        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<bool> Exist(Guid id)
        {
            return await repository.ExistAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await repository.SelectAsync(id);
            return mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var entities = await repository.SelectAsync();
            return mapper.Map<IEnumerable<UserDto>>(entities);
        }

        public async Task<bool> IsValidEmail(string email, Guid userId)
        {
            var user = await repository.SelectAsync(userId);
            if(user != null) {
                return user.Email == email;
            }
            var users = await repository.SelectAsync();
            return users.Where(x => x.Email.Equals(email)).Count() == 0;
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var model = mapper.Map<UserModel>(user);
            var entity = mapper.Map<UserEntity>(model);
            var result = await repository.InsertAsync(entity);
            return mapper.Map<UserDtoCreateResult>(result);    
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var model = mapper.Map<UserModel>(user);
            var entity = mapper.Map<UserEntity>(model);
            var result = await repository.UpdateAsync(entity);
            return mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}
