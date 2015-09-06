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
        public tblLogin AuthenticateUser(LoginModel objLoginModel)
        {
            tblLogin objLogin = null;
            using (ticketmanagmentEntities dbobj = new ticketmanagmentEntities())
            {
               objLogin= dbobj.tblLogins.Where(x =>
                    x.UserName == objLoginModel.UserName &&
                    x.Password == objLoginModel.Password &&
                    x.RoleId == objLoginModel.UserRole && x.IsActive == true
                    ).FirstOrDefault();
            }
            return objLogin;

        }
        public static tblCustomerInfo CurrentUser()
        {
            tblCustomerInfo userInfo = null;
            using (ticketmanagmentEntities db = new ticketmanagmentEntities())
            {
                var userid = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                userInfo = db.tblCustomerInfoes.Where(x =>
                    x.CustomerId == userid
                   ).FirstOrDefault();
            }
            return userInfo;
        }
        public bool CustomerRegistration(LoginModel objmodel)
        {
            tblCustomerInfo custtblobj = new tblCustomerInfo();
            tblLogin objlogin = new tblLogin();
            objlogin.UserName = objmodel._objcustdetails.EmailId;
            objlogin.Password = objmodel.Password;
            objlogin.CreatedDate = DateTime.Now;
            objlogin.IsActive = true;
            dbobj.tblLogins.Add(objlogin);
            dbobj.SaveChanges();

            custtblobj.FirstName = objmodel._objcustdetails.FirstName;
            custtblobj.LastName = objmodel._objcustdetails.LastName;
            custtblobj.EmailId = objmodel._objcustdetails.EmailId;
            custtblobj.CustomerId = objlogin.LoginId;
            custtblobj.IsActive = true;
            custtblobj.CreatedDate = DateTime.Now;
            dbobj.tblCustomerInfoes.Add(custtblobj);
            dbobj.SaveChanges();
            return true;
        }
    }
}
