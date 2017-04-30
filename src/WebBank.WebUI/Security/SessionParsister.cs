using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using WebBank.Business.Models;
using WebBank.WebUI.Models;

namespace WebBank.Security
{
    public static class SessionParsister
    {
        private const string emailKey = "email";
        public static HttpContext HttpContext { get; set; }

        static SessionParsister()
        {

        }

        public static void Configure(LoginViewModel model, HttpContext httpContext)
        {
            Email = model.Email;
            HttpContext = httpContext;
        }

        public static string Email
        {
            get
            {
                if (HttpContext != null && HttpContext.Session.Keys.SingleOrDefault(x => x == emailKey) != null)
                {
                    var tmp = HttpContext.Session.GetString(emailKey);
                    return HttpContext.Session.GetString(emailKey);
                }
                else
                {
                    return String.Empty;
                }
            }
            private set
            {
                if (HttpContext != null)
                {
                    HttpContext.Session.SetString(emailKey, value);
                }
            }
        }

        public static void Destroy()
        {
            Email = String.Empty;

            HttpContext.Session.Remove(emailKey);
        }
    }
}