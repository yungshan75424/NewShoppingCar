using ShoppingCar.Models;
using ShoppingCar.Repository;
using System.Collections.Generic;

namespace ShoppingCar.Service
{
    public class ShoppingCarServise
    {
        
        public ShoppingCarRepository ShoppingCarRepository = new ShoppingCarRepository();
        public ProductRespoistory ProductRespoistory = new ProductRespoistory();
                    
        public void ShoppingCarCreate(int productid, string account)
        {
            var searchshoppingCar = ShoppingCarRepository.GetCar(account, productid);
            if(searchshoppingCar != null)
            {
                searchshoppingCar.Qry += 1;
                ShoppingCarRepository.Update(searchshoppingCar);
            }
            else 
            {

            var product = ProductRespoistory.Get(productid);
            var newcar =new ShoppingCarModel
              {
                Account = account,
                ProductID = product.Id,
                ProductName = product.Name,
                Price=product.Price,
                Qry=1
              };          
                ShoppingCarRepository.Create(newcar);
            }

        }
        public List<ShoppingCarModel> ShoppingCarList(string account)
        {
            return ShoppingCarRepository.GetCarList(account);
             
        }
        /// <summary>
        /// 修改購物車數量"+"
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="account"></param>
        public void ShoppingCarAddQry(int productid, string account)
        {
            var searchshoppingCar = ShoppingCarRepository.GetCar(account, productid);
            searchshoppingCar.Qry += 1;
            ShoppingCarRepository.Update(searchshoppingCar);
        }
        /// <summary>
        /// 修改購物車數量"-"
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="account"></param>
        public void ShoppingCarSubQry(int productid, string account)
        {
            var searchshoppingCar = ShoppingCarRepository.GetCar(account, productid);
            searchshoppingCar.Qry -= 1;
            if (searchshoppingCar.Qry == 0)
            {
                ShoppingCarRepository.Delete(searchshoppingCar.CarId);
            }
            else
            {
                ShoppingCarRepository.Update(searchshoppingCar);
            }
        }
        public void ShoppingCarDelete(int productid, string account)
        {
            var searchshoppingCar = ShoppingCarRepository.GetCar(account, productid);
            ShoppingCarRepository.Delete(searchshoppingCar.CarId);
        }


    }

}