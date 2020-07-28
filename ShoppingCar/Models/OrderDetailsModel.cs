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
        [DisplayName("訂單編號")]
        public int OrderId { get; set; }
        [DisplayName("產品ID")]
        public int ProductID { get; set; }
        [DisplayName("名稱")]
        public string ProductName { get; set; }
        [DisplayName("單價")]
        public decimal Price { get; set; }
        [DisplayName("數量")]
        public int Qry { get; set; }

    }

  

}