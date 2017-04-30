using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBank.WebUI.Models;
using WebBank.Business.Managers.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebBank.WebUI.Controllers
{
    [Authorize]
    public class CashAccountController : Controller
    {
        public ICashAccountManager CashAccountManager { get; set; }
        public IClientManager ClientManager { get; set; }

        public CashAccountController(ICashAccountManager cashAccountManager, IClientManager clientManager)
        {
            CashAccountManager = cashAccountManager;
            ClientManager = clientManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<string> Transfer(TransferMoneyViewModel model)
        {
            var client = await ClientManager.GetByEmail(User.Claims.Single(x => x.Type == ClaimTypes.Email).Value);
            try
            {
                if (await CashAccountManager.Transfer(client.Id, model.ReceiverId, model.Amount))
                {
                    return "Success";
                }
                else
                {
                    return "Unhandled exception";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
