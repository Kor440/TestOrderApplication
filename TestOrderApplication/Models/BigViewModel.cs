using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestOrderApplication.Models
{
    public class BigViewModel
    {
        public Order Order { get; set; }
        public OrderItem OrderItem { get; set; }
        public Provider Provider { get; set; }
        public List<OrderItem> orderItemsList { get; set; }
    }
}