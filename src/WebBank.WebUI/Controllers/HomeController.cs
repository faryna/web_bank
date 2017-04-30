using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBank.Business.Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using WebBank.Data.Infrastructure.Enums;
using System.Security.Claims;
using WebBank.WebUI.Models;
using WebBank.Business.Models.Base;

namespace WebBank.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IUserAccountManager UserAccountManager { get; set; }
        public IClientManager ClientManager { get; set; }
        public ICashAccountManager CashAccountManager { get; set; }
        public ITransferTransactionManager TransferTransactionManager { get; set; }

        public HomeController(IUserAccountManager userAccountManager, IClientManager clientManager, ICashAccountManager cashAccountManager,
            ITransferTransactionManager transferTransactionManager)
        {
            UserAccountManager = userAccountManager;
            ClientManager = clientManager;
            CashAccountManager = cashAccountManager;
            TransferTransactionManager = transferTransactionManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            if(User.IsInRole(Enum.GetName(typeof(UserRole), UserRole.Client)))
            {
                var client = await ClientManager.GetByEmail(User.Claims.Single(x => x.Type == ClaimTypes.Email).Value);
                if (client!=null)
                {
                    var model = new ClientDashboardViewModel()
                    {
                        Client = client,
                        Transactions = new List<TransactionModel>()
                    };

                    model.Transactions.AddRange(await TransferTransactionManager.GetByClientId(client.Id));

                    return View("ClientDashboard", model);
                }
                
            }
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
