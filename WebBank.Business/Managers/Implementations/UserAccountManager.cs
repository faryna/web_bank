using WebBank.Business.Managers.Base.Implementation;
using WebBank.Business.Managers.Interfaces;
using WebBank.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBank.Business.Models;
using WebBank.Data.Repository.Interfaces;
using WebBank.Data.Entities;
using AutoMapper;

namespace WebBank.Business.Managers.Implementations
{
    public class UserAccountManager : CrudManager<UserAccountModel, UserAccount>, IUserAccountManager
    {
        public UserAccountManager(IApplicationUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.UserAccounts)
        {
        }

        public async Task<UserAccountModel> GetByEmailAndPassword(string email, string password)
        {
            return Mapper.Map<UserAccountModel>(await UnitOfWork.UserAccounts.GetByEmailAndPassword(email, password));
        }

        public async Task<UserAccountModel> GetByEmail(string email)
        {
            return Mapper.Map<UserAccountModel>(await UnitOfWork.UserAccounts.GetByEmail(email));
        }
    }
}
