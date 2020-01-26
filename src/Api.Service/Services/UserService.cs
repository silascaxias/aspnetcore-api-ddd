using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> repository;
        public UserService(IRepository<UserEntity> repository)
        {
            this.repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await repository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await repository.SelectAsync();
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            return await repository.InsertAsync(user);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await repository.UpdateAsync(user);
        }
    }
}
