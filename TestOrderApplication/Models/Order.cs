using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestOrderApplication.Models
{
    public class Order
    {
        // ID 
        [Key]
        public int Id { get; set; }

        // 
        public string Number { get; set; }

        //
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        //[ForeignKey("Provider")]
        public int ProviderId { get; set; }

        public Provider Provider { get; set; }

        public ICollection<OrderItem> OrderItem { get; set; }
    }
}