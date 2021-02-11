using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestOrderApplication.ViewModels
{
    public class OrderVM
    {
        public string ProviderName { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderItemName { get; set; }
        public string OrderItemUnit { get; set; }
    }
}