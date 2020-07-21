using ShoppingCar.Models;
using ShoppingCar.Repository;
using ShoppingCar.Utility.Extensions;
using System;
using System.Collections.Generic;

namespace ShoppingCar.Service
{
    public class ProductService
    {
        public ProductRespoistory  ProductRespoistory = new ProductRespoistory();

        public List<ProductModel> GetList()
        {
            return ProductRespoistory.GetList();
        }

        public ProductModel Get(int id)
        {
           return ProductRespoistory.Get(id);

        }

        public void  Create(ProductModel model) 
            // 新增動作方法  "新增 ProductModel內有的資料並使用 model回傳值"
        {
            var NowTime = DateTimeHelper.GetNowTime();
            model.CreateTime = NowTime;
            model.UpdateTime = NowTime;
            model.Creater = "System";
            model.Updater = "Syatem";
            ProductRespoistory.Create(model);
        }
        public void Update(ProductModel model)
        {
            var e = ProductRespoistory.Get(model.Id);
            if (e == null)
            {
                return;
            }
            e.Name = model.Name;
            e.Price = model.Price;
            e.ProductTypeID = model.ProductTypeID;
            e.Updater = "System";
            e.UpdateTime = DateTimeHelper.GetNowTime();
            ProductRespoistory.Update(e);
        }
        public void Delete(int id)
        {
            ProductRespoistory.Delete(id);
        }

    }

}