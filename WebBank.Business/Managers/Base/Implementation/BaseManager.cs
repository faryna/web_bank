using WebBank.Business.Models.Base;
using WebBank.Data.Entities.Base.Interfaces;
using WebBank.Data.Repository.Base.Interfaces;
using WebBank.Data.Repository.Interfaces;

namespace WebBank.Business.Managers.Base.Implementation
{
    public class BaseManager<TModel, TEntity>
        where TModel : class, IModel
        where TEntity : class, IEntity
    {
        public IApplicationUnitOfWork UnitOfWork { get; set; }
        protected IRepository<TEntity> _repository;

        public BaseManager(IApplicationUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            UnitOfWork = unitOfWork;
            _repository = repository;
        }
    }
}
