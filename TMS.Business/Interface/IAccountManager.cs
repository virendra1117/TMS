using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.EntityModel;
using TMS.Model;

namespace TMS.Business.Interface
{
    public interface IAccountManager
    {
        tblUser AuthenticateUser(LoginModel objLoginModel);
        bool CustomerRegistration(LoginModel objmodel);
    }
}
