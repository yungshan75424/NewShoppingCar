using ShoppingCar.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ShoppingCar.Models
{

    
public class OrderModel
    {
        [AutoKey]
        [DisplayName("訂單編號")]
        public int OrderId { get; set; }
        [DisplayName("帳號")]
        public string Account { get; set; }
        [DisplayName("收件人姓名")]
        public string ReceiverName { get; set; }
        [DisplayName("收件人電話")]
        public string ReceiverPhone { get; set; }
        [DisplayName("收件人地址")]
        public string ReceiverAddress { get; set; }
        [DisplayName("訂單時間")]
        public DateTime OrderDate { get; set; }
        [DisplayName("訂單狀態")]
        public string OrderState { get; set; }

    }

  

}