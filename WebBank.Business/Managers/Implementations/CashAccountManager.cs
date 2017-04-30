using WebBank.Business.Managers.Base.Implementation;
using WebBank.Business.Managers.Interfaces;
using WebBank.Business.Models;
using System;
using System.Threading.Tasks;
using WebBank.Data.Repository.Interfaces;
using WebBank.Data.Entities;

namespace WebBank.Business.Managers.Implementations
{
    public class CashAccountManager : CrudManager<CashAccountModel, CashAccount>, ICashAccountManager
    {
        public CashAccountManager(IApplicationUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.CashAccounts)
        { }

        #region Interface Members

        public async Task<bool> Transfer(int clientId, int receiverId, double amount)
        {
            using (var transaction = await UnitOfWork.BeginTransactionAsync())
            {
                try
                {
                    var client = await UnitOfWork.Clients.GetByIdWithCashAccount(clientId);
                    var receiver = await UnitOfWork.Clients.GetByIdWithCashAccount(receiverId);

                    if(client.CashAccount.Balance<amount)
                    {
                        throw new Exception("Insufficient funds in the account");
                    }
                    if (receiver == null)
                    {
                        throw new Exception("Receiver does not exist");
                    }
                    client.CashAccount.Balance -= amount;
                    receiver.CashAccount.Balance += amount;

                    await UnitOfWork.CashAccounts.Update(client.CashAccount);
                    await UnitOfWork.CashAccounts.Update(receiver.CashAccount);

                    await UnitOfWork.SaveChanges();

                    transaction.Commit();

                    TransferTransaction trans = new TransferTransaction()
                    {
                        Amount = amount,
                        ClientId = clientId,
                        Date = DateTime.Now,
                        Receiver = receiverId
                    };

                    await UnitOfWork.TransferTransactions.AddAsync(trans);
                    await UnitOfWork.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        #endregion
    }
}
