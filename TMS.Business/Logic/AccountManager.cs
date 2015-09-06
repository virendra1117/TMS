using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Business.Interface;
using TMS.Data.EntityModel;
using TMS.Data.Repository;
using TMS.Model;

namespace TMS.Business.Logic
{
    public class AccountManager : IAccountManager
    {
        AccountRepository objAccountRepository = new AccountRepository();
        public tblLogin AuthenticateUser(LoginModel objLoginModel)
        {
            return objAccountRepository.AuthenticateUser(objLoginModel);
        }

        public bool CustomerRegistration(LoginModel objmodel)
        {
            return objAccountRepository.CustomerRegistration(objmodel);
        }
    }
}
