using ShoppingCar.Models;
using ShoppingCar.Service;
using System.Web.Mvc;
using System.Web.Security;

namespace ShoppingCar.Controllers
{
    public class MemberController : Controller
    {
        MemberService MemberService = new MemberService();
        ShoppingCarServise ShoppingCarServise = new ShoppingCarServise();
        OrderServise OrderServise = new OrderServise();
        
        public ActionResult Register()
        {
            return View(new MemberViewModel());
        }
        [HttpPost]
        public ActionResult Register(MemberViewModel model)
        {

            var result = MemberService.Create(model);

            ViewBag.Result = result;

            return View(model);
        }
        [Authorize]
        public ActionResult MemberEdit()
        {
            string account = User.Identity.Name;
            var e = MemberService.GetAccount(account);
            return View(e);
        }
        [Authorize]
        [HttpPost]
        public ActionResult MemberEdit(MemberViewModel model)
        {
            var result = MemberService.MemberEdit(model);
            ViewBag.Result = result;
            return View(model);
        }

        public ActionResult Login()
        {
            return View(new MemberModel());
        }
        [HttpPost]
        public ActionResult Login(MemberModel model)
        {
            var result = MemberService.Login(model);

            ViewBag.Result = result;

            if (result.IsSuccess)
            {
                FormsAuthentication.RedirectFromLoginPage(model.Account, true);
                return RedirectToAction("Index", "Product");
            }
                ViewBag.Msg = result.Message;
            

            return View(model);
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Member");
        }
        [Authorize]
        public ActionResult ShoppingCarList()
        {
            string account = User.Identity.Name;
            var shoppingcar = ShoppingCarServise.ShoppingCarList(account);
            return View(shoppingcar);
        }
        [Authorize]
        public ActionResult AddToShoppingCar(int Id)
        {
            string account = User.Identity.Name;
            ShoppingCarServise.ShoppingCarCreate(Id, account);
            return RedirectToAction("ShoppingCarList", "Member");
        }
        [Authorize]
        public ActionResult ShoppingCarAddQty(int Id)
        {
            string account = User.Identity.Name;
            ShoppingCarServise.ShoppingCarAddQry(Id, account);
            return RedirectToAction("ShoppingCarList", "Member");
        }
        [Authorize]
        public ActionResult ShoppingCarSubQty(int Id)
        {
            string account = User.Identity.Name;
            ShoppingCarServise.ShoppingCarSubQry(Id, account);
            return RedirectToAction("ShoppingCarList", "Member");
        }
        [Authorize]
        public ActionResult ShoppingCarDelete(int Id)
        {
            string account = User.Identity.Name;
            ShoppingCarServise.ShoppingCarDelete(Id, account);
            return RedirectToAction("ShoppingCarList", "Member");
        }
        [Authorize]
        public ActionResult OrderCreate(OrderModel model)
        {
            string account = User.Identity.Name;
            OrderServise.OrderCreate(model, account);
            return RedirectToAction("OrderList", "Member");
        }
        [Authorize]
        public ActionResult OrderList()
        {
            string account = User.Identity.Name;
            var orderlist = OrderServise.OrderList(account);
            return View(orderlist);
        }
        [Authorize]
        public ActionResult OrderDetailsList(int orderid)
        {
            var orderdetailslist = OrderServise.orderDetailsList(orderid);
            return View(orderdetailslist);
        }
    }

}
