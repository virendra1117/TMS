using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.EntityModel;
using TMS.Model;
using System.Web;

namespace TMS.Data.Repository
{
    public class AccountRepository
    {
        ticketmanagmentEntities dbobj = new ticketmanagmentEntities();
        public tblUser AuthenticateUser(LoginModel objLoginModel)
        {
            tblUser objLogin = null;
            using (ticketmanagmentEntities dbobj = new ticketmanagmentEntities())
            {
               objLogin= dbobj.tblUsers.Where(x =>
                    x.userName == objLoginModel.UserName &&
                    x.Password == objLoginModel.Password &&
                    x.RoleId == objLoginModel.UserRole && x.IsActive == true
                    ).FirstOrDefault();
            }
            return objLogin;

        }
        public static tblUser CurrentUser()
        {
            tblUser userInfo = null;
            using (ticketmanagmentEntities db = new ticketmanagmentEntities())
            {
                var userid = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                userInfo = db.tblUsers.Where(x =>
                    x.userId == userid
                   ).FirstOrDefault();
            }
            return userInfo;
        }
        public bool CustomerRegistration(LoginModel objLoginModel)
        {

            tblUser objUser = (objLoginModel.LoginId == 0) ? new tblUser() : dbobj.tblUsers.Where(x => x.userId == objLoginModel.LoginId).FirstOrDefault();
            objUser.userName = objLoginModel.UserName;
            objUser.Password = objLoginModel.Password;
            objUser.CreatedDate = DateTime.Now;
            objUser.FirstName = objLoginModel.FirstName;
            objUser.LastName = objLoginModel.LastName;
            objUser.IsActive = true;
            objUser.RoleId = 3;
            if (objLoginModel.LoginId == 0)
            {
                dbobj.tblUsers.Add(objUser);
            }
            dbobj.SaveChanges();
            return true;
        }
    }
}
