using WebBank.Business.Managers.Base.Interfaces;
using WebBank.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebBank.Business.Managers.Interfaces
{
    public interface ITransferTransactionManager : ICrudManager<TransferTransactionModel>
    {
        Task<List<TransferTransactionModel>> GetByClientId(int id);
    }
}
