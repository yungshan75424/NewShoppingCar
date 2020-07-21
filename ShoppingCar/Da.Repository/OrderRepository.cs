using ShoppingCar.Da.Repository;
using ShoppingCar.Models;
using System.Collections.Generic;

namespace ShoppingCar.Repository
{
    public class OrderRepository : BaseConnectRepository<OrderModel>
    {
        public List<OrderModel> GetOrderList(string account)
        {
            string whereSQL = "Where Account = @Account";
            return GetListByWhereSQL(whereSQL, new { Account = account });
        }
    }
}