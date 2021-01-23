using System;
using System.Collections.Generic;

namespace EShopApi.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public int? CustomerId { get; set; }
        public int? SalesPersonId { get; set; }

        public Customer Customer { get; set; }
        public SalesPerson SalesPerson { get; set; }
        public OrderItems OrderItems { get; set; }
    }
}
