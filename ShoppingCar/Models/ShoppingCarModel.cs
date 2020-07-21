using ShoppingCar.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ShoppingCar.Models
{

    
public class ShoppingCarModel
  {
    [AutoKey]
    public int CarId { get; set; }

    public string Account { get; set; }

    public int ProductID { get; set; }
    [DisplayName("產品名稱")]
    public string ProductName { get; set; }
    [DisplayName("產品價格(NTD)")]
    public decimal Price { get; set; }
    [DisplayName("價格")]
    public int Qry { get; set; }

}

  

}