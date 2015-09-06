using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Business.Interface;
using TMS.Business.Logic;
using TMS.Data.Repository;
using TMS.Model;

namespace ticketmanagmentsystem.Controllers
{
    public class TicketController : Controller
    {
        private ICreateTicketManager _ticketmanager = null;
        public TicketController()
        {
            this._ticketmanager = new CreateTicketManager();
        }
        public TicketController(ICreateTicketManager ticketmanager)
        {
            this._ticketmanager = ticketmanager;
        }
        // GET: /Ticket/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateTicket()
        {
            return View();
        }
       
         [HttpPost]
        public ActionResult CreateTicketbyUser(CreateTicketModel _createTicketModel)
        {
            var result = _ticketmanager.CreateTicket(_createTicketModel);
            return RedirectToAction("CreateTicket");
        }

        public ActionResult GetAllUserTicket()
        {
            return PartialView("_AllUserTicket");
        }
        public ActionResult GetListByUser(int userId=1)
        {
            //int userId=Convert.ToInt32(AccountRepository.CurrentUser());
            TicketRepository ticketRepo= new TicketRepository();
            var list = ticketRepo.GetAllTicketsByUser(userId);
            return PartialView("_UserTickets", list);
        }
	}
}