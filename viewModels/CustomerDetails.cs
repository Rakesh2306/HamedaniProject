using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HamedaniProject.viewModels
{
    public class CustomerDetails
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime birthDate { get; set; }

        public MembershipTypeTable membershipTypeTable { get; set; }
    }
}