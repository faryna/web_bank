using WebBank.Data.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBank.Data.Repository.Base.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class, IEntity
    {
        Task<int> AddAsync(T entity);
        Task<IQueryable<T>> GetAsync();
        Task<T> GetById(int id);
        Task Delete(int id);
        Task Update(T entity);
    }
}
