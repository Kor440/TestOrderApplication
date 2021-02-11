using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestOrderApplication.ViewModels
{
    public class CreateOrderVM
    {
        public int Id { get; set; }

        // 
        public string Number { get; set; }

        public DateTime Date { get; set; }

        public int ProviderId { get; set; }
        public string Name { get; set; }

        //
        public decimal Quantity { get; set; }

        // 
        public string Unit { get; set; }

    }
}