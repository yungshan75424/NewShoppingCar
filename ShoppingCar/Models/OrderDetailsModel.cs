using ShoppingCar.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ShoppingCar.Models
{

    
public class OrderDetailsModel
    {
        [AutoKey]
        public int OrderDetailsId { get; set; }

        public int OrderId { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Qry { get; set; }

    }

  

}