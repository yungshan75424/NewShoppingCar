using ShoppingCar.Da.Repository;
using ShoppingCar.Models;
using System.Collections.Generic;

namespace ShoppingCar.Repository
{
    public class ShoppingCarRepository : BaseConnectRepository<ShoppingCarModel>
    {
        public ShoppingCarModel GetCar(string account,int productid)
        {
            string whereSQL = "Where Account = @Account" +
                " AND ProductID = @ProductId";
            return GetByWhereSQL(whereSQL, new { Account = account , ProductId = productid });
        }
        public List<ShoppingCarModel> GetCarList(string account)
        {
            string whereSQL = "Where Account = @Account";
            return GetListByWhereSQL(whereSQL, new { Account = account});
        }
    }
}