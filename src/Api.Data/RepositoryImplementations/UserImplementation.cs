using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UserImplementation: BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> dataset;

        public UserImplementation(MyContext context) : base(context)
        {
            dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await dataset.FirstOrDefaultAsync(x => x.Email.Equals(email));
        }
    }
}