using WebBank.Business.Managers.Base.Implementation;
using WebBank.Business.Managers.Interfaces;
using WebBank.Business.Models;
using System.Threading.Tasks;
using WebBank.Data.Repository.Interfaces;
using WebBank.Data.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace WebBank.Business.Managers.Implementations
{
    public class TransferTransactionManager : CrudManager<TransferTransactionModel, TransferTransaction>, ITransferTransactionManager
    {
        public TransferTransactionManager(IApplicationUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.TransferTransactions)
        { }

        #region Interface Members

        public async Task<List<TransferTransactionModel>> GetByClientId(int id)
        {
            return Mapper.Map<List<TransferTransactionModel>>(await UnitOfWork.TransferTransactions.GetByClientId(id));
        }

        #endregion
    }
}
