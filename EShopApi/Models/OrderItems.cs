﻿using System;
using System.Collections.Generic;

namespace EShopApi.Models
{
    public partial class OrderItems
    {
        public int OrderItemId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Qauntity { get; set; }

        public Orders OrderItem { get; set; }
        public Products Product { get; set; }
    }
}
