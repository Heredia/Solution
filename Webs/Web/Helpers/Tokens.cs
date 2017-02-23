using Model.Models;
using System.Web.Mvc;

namespace Webs.Web.Helpers
{
    public static class Tokens
    {
        public static AuthenticationModel Authentication
        {
            get { return JsonWebTokenHeaderHelper.Get<AuthenticationModel>(nameof(Authentication)); }
            set { JsonWebTokenHeaderHelper.Set(nameof(Authentication), value); }
        }
    }
}