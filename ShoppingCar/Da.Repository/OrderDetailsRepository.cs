using ShoppingCar.Da.Repository;
using ShoppingCar.Models;
using System.Collections.Generic;

namespace ShoppingCar.Repository
{
    public class OrderDetailsRepository : BaseConnectRepository<OrderDetailsModel>
    {
        public List<OrderDetailsModel> GetOrderDetailsList(int orderid)
        {
            string whereSQL = "Where OrderId = @OrderId";
            return GetListByWhereSQL(whereSQL, new { OrderId = orderid });
        }
    }
}