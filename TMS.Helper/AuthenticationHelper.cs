using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace TMS.Helper
{
   public class AuthenticationHelper
    {
       public static int CurrentRole()
       {
           return Convert.ToInt32((FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData.Split('_'))[0], CultureInfo.CurrentCulture);
       }
        public static int CurrentLoginId()
        {
            return Convert.ToInt32(FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name, CultureInfo.CurrentCulture);

        }
    }
}
