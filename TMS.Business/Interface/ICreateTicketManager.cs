using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;

namespace TMS.Business.Interface
{
   public interface ICreateTicketManager
    {
        bool CreateTicket(CreateTicketModel _createTicketModel);
    }
}
