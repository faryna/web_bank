using WebBank.Business.Managers.Base.Interfaces;
using WebBank.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBank.Business.Managers.Interfaces
{
    public interface IUserAccountManager : ICrudManager<UserAccountModel>
    {
        Task<UserAccountModel> GetByEmailAndPassword(string login, string password);
        Task<UserAccountModel> GetByEmail(string login);
    }
}
