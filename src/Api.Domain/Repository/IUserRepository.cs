using Api.Domain.Interfaces;
using Api.Domain.Entities;
using System.Threading.Tasks;

namespace Api.Domain.Repository
{
    public interface IUserRepository: IRepository<UserEntity>
    {
         Task<UserEntity> FindByLogin(string email);
    }
}