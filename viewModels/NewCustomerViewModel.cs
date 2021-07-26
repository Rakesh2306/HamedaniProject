using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HamedaniProject.viewModels
{
    public class NewCustomerViewModel
    {
        public List<MembershipTypeTable> Membershiptable { get; set; }

        public CustomerTable Customer { get; set; }
    }
}