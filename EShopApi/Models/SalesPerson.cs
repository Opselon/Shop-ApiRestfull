using System;
using System.Collections.Generic;

namespace EShopApi.Models
{
    public partial class SalesPerson
    {
        public SalesPerson()
        {
            Orders = new HashSet<Orders>();
        }

        public int SalesPersonalid { get; set; }
        public string PersonalFirstName { get; set; }
        public string PersonalLastName { get; set; }
        public string PersonalEmail { get; set; }
        public string PersonalPhone { get; set; }
        public string PersonalAdress { get; set; }
        public string PersonalCity { get; set; }
        public string PersonalState { get; set; }
        public string PersonalZipCode { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
