using WebBank.Data.Entities.Base.Interfaces;
using WebBank.Data.Repository.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebBank.Data.Repository.Base.Implementation
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {

        protected DbSet<T> DbSet { get; set; }
        protected DbContext Context { get; set; }

        public Repository(DbContext context)
        {
            if(context == null)
            {
                throw new Exception("Context can`t be null"); //NEED CHANGE
            }

            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual async Task<IQueryable<T>> GetAsync()
        {
            return DbSet;
        }

        public virtual async Task<int> AddAsync(T entity)
        {
           DbSet.Add(entity);
           return entity.Id;
        }

        public virtual async Task Delete(int id)
        {
            DbSet.Remove(await DbSet.FirstOrDefaultAsync(x => x.Id == id));
        }

        public virtual async Task Update(T entity)
        {
            var model = await DbSet.SingleOrDefaultAsync(x => x.Id == entity.Id);
            if (model != null)
            {
                Context.Entry(model).CurrentValues.SetValues(entity);
            }
        }

        public void Dispose()
        {
            if(Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }

        public virtual async Task<T> GetById(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
