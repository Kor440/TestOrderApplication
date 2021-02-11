using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestOrderApplication.Models
{
    public class OrderSearchModel
    {
        public string OrderNumber { get; set; }
        public DateTime? OrderDateFrom { get; set; }
        public DateTime? OrderDateTo { get; set; }
        public string OrderItemName { get; set; }
        public string OrderItemUnit { get; set; }
        public string ProviderName { get; set; }
    }
}
