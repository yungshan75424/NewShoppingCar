using ShoppingCar.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCar.Models
{
    public class BaseModel
    {
        [AutoKey]
        public int Id { get; set; }
        public string Creater { get; set; }

        public DateTime CreateTime { get; set; }

        public string Updater { get; set; }

        public DateTime UpdateTime { get; set; }


    }


}