
using AutoMapper;
using WebBank.Business.Managers.Base.Interfaces;
using WebBank.Business.Models.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBank.Data.Entities.Base.Interfaces;
using WebBank.Data.Repository.Base.Interfaces;
using WebBank.Data.Repository.Interfaces;

namespace WebBank.Business.Managers.Base.Implementation
{
    public class CrudManager<TModel, TEntity> : BaseManager<TModel, TEntity>, ICrudManager<TModel>
        where TModel : class, IModel
        where TEntity : class, IEntity
    {
        public CrudManager(IApplicationUnitOfWork unitOfWork, IRepository<TEntity> repository)
            : base(unitOfWork, repository)
        {
        }

        public virtual async Task<int> AddAsync(TModel model)
        {
            var dataModel = Mapper.Map<TEntity>(model);
            await _repository.AddAsync(dataModel);
            await UnitOfWork.SaveChanges();
            return dataModel.Id;
        }

        public virtual async Task UpdateAsync(TModel model)
        {
            await _repository.Update(Mapper.Map<TEntity>(model));
            await UnitOfWork.SaveChanges();
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _repository.Delete(id);
            await UnitOfWork.SaveChanges();
        }

        public virtual async Task<TModel> GetAsync(int id)
        {
            return Mapper.Map<TModel>(await _repository.GetById(id));
        }

        public virtual async Task<List<TModel>> GetAsync()
        {
            return Mapper.Map<List<TModel>>(await _repository.GetAsync());
        }
    }
}
