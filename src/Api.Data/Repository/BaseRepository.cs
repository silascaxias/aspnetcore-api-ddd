using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext context;
        private DbSet<T> dataset;
        public BaseRepository(MyContext context)
        {
            this.context = context;
            dataset = context.Set<T>();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                 var result = await dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));
                 
                 if (result == null)
                    return false;

                dataset.Remove(result);

                await context.SaveChangesAsync();
                
                return true;       

            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                if (entity.Id == Guid.Empty) 
                {
                    entity.Id = Guid.NewGuid();
                }

                entity.CreateAt = DateTime.UtcNow;
                dataset.Add(entity);
                await context.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex) 
            {                
                throw ex;
            }
        }

        public async Task<bool> ExistAsync (Guid id) 
        {
            return await dataset.AnyAsync(X => X.Id.Equals(id));
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception ex)            {
                
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await dataset.ToListAsync();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await dataset.SingleOrDefaultAsync(x => x.Id.Equals(entity.Id));
                
                if (result == null)
                    return null;
                
                entity.UpdateAt = DateTime.UtcNow;
                entity.CreateAt = result.CreateAt;           

                context.Entry(result).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}