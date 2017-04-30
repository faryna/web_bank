using WebBank.Business.Managers.Base.Interfaces;
using WebBank.Business.Models;
using System.Threading.Tasks;

namespace WebBank.Business.Managers.Interfaces
{
    public interface ICashAccountManager : ICrudManager<CashAccountModel>
    {
        Task<bool> Transfer(int clientId, int receiverId, double amount);
    }
}
