using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.EntityModel;
using TMS.Model;

namespace TMS.Data.Repository
{
    public class TicketRepository
    {
        ticketmanagmentEntities db = new ticketmanagmentEntities();

        public bool CreateTicket(CreateTicketModel createTicketModel)
        {
            int loggedinId = TMS.Helper.AuthenticationHelper.CurrentLoginId();
            tblTicket _objtblTicket = (createTicketModel.ticketid == 0) ? new tblTicket() : db.tblTickets.Where(x => x.ticketid == createTicketModel.ticketid).FirstOrDefault();
            if (loggedinId != null)
            {
                _objtblTicket.CustomerId = loggedinId;
            }
            else
            {
                _objtblTicket.CustomerId = 0;
            }
            _objtblTicket.Categoryid = createTicketModel._categoryModel.CategoryId;
            _objtblTicket.Prority = createTicketModel.Prority;
            _objtblTicket.Subject = createTicketModel.Subject;
            _objtblTicket.Message = createTicketModel.Message;
            _objtblTicket.FullName = createTicketModel.FullName;
            _objtblTicket.Email = createTicketModel.Email;
            _objtblTicket.Phone = createTicketModel.Phone;
            _objtblTicket.CreateDate = DateTime.Now;
            _objtblTicket.ResolveStatus = false;
            _objtblTicket.ResolveDate = null;
            if (createTicketModel.ticketid == 0)
            {
                _objtblTicket.IsActive = true;
                db.tblTickets.Add(_objtblTicket);
            }
            db.SaveChanges();

            return true;
        }
        public List<CreateTicketModel> GetAllTicketsByUser(int userId)
        {
            List<CreateTicketModel> getTicketList = new List<CreateTicketModel>();
            var getTickets = (from t in db.tblTickets
                                  join user in db.tblUsers on t.Categoryid equals user.userId
                                  join cat in db.tblCategories on t.Categoryid equals cat.CategoryId
                                  where t.CustomerId == userId
                                  select new { user.FirstName,t.Message, cat.CatgoryName, t.Prority }).ToList();
            foreach (var tList in getTickets)
            {

                CreateTicketModel obj = new CreateTicketModel();
                obj._categoryModel = new CategoryModel();
                obj.FullName = tList.FirstName;
                obj.Message = tList.Message;
                obj._categoryModel.CatgoryName = tList.CatgoryName;
                obj.Prority = tList.Prority;

                getTicketList.Add(obj);
            }
            return getTicketList;
        }


    }
}
