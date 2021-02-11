using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestOrderApplication.Models
{
    public class OrderItem
    {
        // ID 
        [Key]
        public int Id { get; set; }

        // 
        public string Name { get; set; }

        //
        public decimal Quantity { get; set; }
 
        // 
        public string Unit { get; set; }
        
        //
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}