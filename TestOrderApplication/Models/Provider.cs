using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestOrderApplication.Models
{
    public class Provider
    {
        // ID 
        [Key]
        public int Id { get; set; }

        // 
        public string Name { get; set; }

        public ICollection<Order> Order { get; set; }

    }
}