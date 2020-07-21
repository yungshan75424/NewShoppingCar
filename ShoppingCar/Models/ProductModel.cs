using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ShoppingCar.Models
{

    
    public class ProductModel :BaseModel
    {
        

        [DisplayName("產品名稱")]
        public string Name { get; set; }
        [DisplayName("產品價格")]
        public decimal Price { get; set; }
        [DisplayName("產品分類")]
        public int ProductTypeID { get; set; }

    }

}