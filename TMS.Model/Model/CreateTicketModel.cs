using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
public class CreateTicketModel
    {
        public int ticketid { get; set; }
        public string Prority { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ResolveDate { get; set; }
        public Nullable<bool> ResolveStatus { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<System.DateTime> IsActive { get; set; }
        public CategoryModel _categoryModel { get; set; }
        public CustomerDetails _customerDetails { get; set; }
    }
}
