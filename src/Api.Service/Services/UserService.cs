using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> Exist(Guid id)
        {
            return await repository.ExistAsync(id);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await repository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await repository.SelectAsync();
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
