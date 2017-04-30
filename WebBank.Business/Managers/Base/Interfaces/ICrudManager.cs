using WebBank.Business.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebBank.Data.Repository.Interfaces;

namespace WebBank.Business.Managers.Base.Interfaces
{
    public interface ICrudManager<TModel>
        where TModel : class, IModel
    {
        IApplicationUnitOfWork UnitOfWork { get; set; }

        Task<int> AddAsync(TModel model);
        Task<List<TModel>> GetAsync();
        Task<TModel> GetAsync(int id);
        Task UpdateAsync(TModel model);
        Task DeleteAsync(int id);
    }
}
