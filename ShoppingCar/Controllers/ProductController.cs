using ShoppingCar.Models;
using ShoppingCar.Service;
using System.Web.Mvc;

namespace ShoppingCar.Controllers
{
    public class ProductController : Controller
    {
        ProductService ProductService = new ProductService();
        public ActionResult Index()
        {
            var result = ProductService.GetList();
            return View(result);
        }
        public ActionResult Create()
        {

            return View(new ProductModel());
        }
        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            ProductService.Create(model);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var model = ProductService.Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            ProductService.Update(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ProductService.Delete(id);
            return RedirectToAction("Index");
        }
    }

}
