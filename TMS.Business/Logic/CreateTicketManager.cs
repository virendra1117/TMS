using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Business.Interface;
using TMS.Data.Repository;
using TMS.Model;

namespace TMS.Business.Logic
{
    public class CreateTicketManager : ICreateTicketManager
    {
        TicketRepository objCreateTicketRepo = new TicketRepository();
        public bool CreateTicket(CreateTicketModel _createTicketModel)
        {
            return objCreateTicketRepo.CreateTicket(_createTicketModel);
        }
    }
}
