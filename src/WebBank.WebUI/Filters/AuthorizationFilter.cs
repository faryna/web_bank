using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using WebBank.Security;

namespace WebBank.WebUI.Filters
{
    public class AccountRequirement : IAuthorizationRequirement { }

    public class AccountHandler : AuthorizationHandler<AccountRequirement>
    {
        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            AccountRequirement requirement)
        {
            if (SessionParsister.Email != string.Empty)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }












    //public class AuthorizationFilter : AuthorizeAttribute
    //{
    //    public override void OnAuthorization(AuthorizationContext filterContext)
    //    {
    //        if(string.IsNullOrEmpty(SessionParsister.Login))
    //        {
    //            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "Index" }));
    //        }
    //        else
    //        {
    //            UserManager manager = new UserManager();
    //            var user = Mapper.Map<UserModel>(manager.GetByLogin(SessionParsister.Login).Result);
    //        }
    //    }
    //}
}