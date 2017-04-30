using System;
using System.Security.Principal;
using WebBank.Business.Models;

namespace WebBank.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private UserAccountModel user { get; set; }

        public CustomPrincipal(UserAccountModel model)
        {
            user = model;
            Identity = new GenericIdentity(model.Email);
        }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public bool IsAdmin()
        {
            return user.IsAdmin;
        }
    }
}