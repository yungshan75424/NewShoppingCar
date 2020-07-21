using ShoppingCar.Da.Repository;
using ShoppingCar.Models;
using System.Collections.Generic;

namespace ShoppingCar.Repository
{
    public class ProductRespoistory : BaseConnectRepository<ProductModel>
       
    {
        public List<ProductModel> OrderByPriceASC()
        {
            string querySQL = "ORDER BY Price";
            return GetListByWhereSQL(querySQL);
        }
        public List<ProductModel> OrderByPriceDESC()
        {
            string querySQL = "Order BY Price DESC";
            return GetListByWhereSQL(querySQL);
        }
    }
}