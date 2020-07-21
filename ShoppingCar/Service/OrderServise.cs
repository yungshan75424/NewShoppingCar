using ShoppingCar.Models;
using ShoppingCar.Repository;
using ShoppingCar.Utility.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCar.Service
{
    public class OrderServise
    {
        public OrderRepository OrderRepository = new OrderRepository();
        public OrderDetailsRepository OrderDetailsRepository = new OrderDetailsRepository();
        public ShoppingCarRepository ShoppingCarRepository = new ShoppingCarRepository();

        public ResultModel OrderCreate(OrderModel model, string account)
        {
            List<ShoppingCarModel> shoppingcarlist = ShoppingCarRepository.GetCarList(account);
            if (shoppingcarlist != null)
            {
                var order = new OrderModel
                {
                    Account = account,
                    ReceiverName = model.ReceiverName,
                    ReceiverPhone = model.ReceiverPhone,
                    ReceiverAddress = model.ReceiverAddress,
                    OrderDate = DateTimeHelper.GetNowTime(),
                    OrderState = "未出貨",
                };
                var orderid = OrderRepository.CreateAndResultIdentity<int>(order);
                /*
                 var orderdetails = new List<OrderDetailsModel>();
                    foreach (var e in shoppingcarlist)
                {
                    orderdetails.Add(new OrderDetailsModel
                    {
                        OrderId = orderid,
                        ProductID = e.ProductID,
                        ProductName = e.ProductName,
                        Price = e.Price,
                        Qry = e.Qry,
                    );
                }
                */
                var orderdetails = shoppingcarlist.Select(e => new OrderDetailsModel
                {
                    OrderId = orderid,
                    ProductID = e.ProductID,
                    ProductName = e.ProductName,
                    Price = e.Price,
                    Qry = e.Qry,
                }).ToList();
                OrderDetailsRepository.Create(orderdetails);

                var car2orderdeletelist = shoppingcarlist.Select(e => e.CarId).ToList();

                ShoppingCarRepository.Delete<int>(car2orderdeletelist);
                return new ResultModel
                {
                    IsSuccess = true,
                    Message = "成功下單"
                };
            }

            return new ResultModel
            {
                IsSuccess = false,
                Message = "購物車空無一物"
            };
        }
        public List<OrderModel> OrderList(string account)
        {
            return OrderRepository.GetOrderList(account);
        }


    }
}