using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCar.Utility.Extensions
{
    public class DateTimeHelper
    {
        public static DateTime GetNowTime()
        {
            return DateTime.UtcNow.AddHours(8);
        }
    }
}