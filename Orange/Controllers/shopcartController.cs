using Orange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using Orange.ViewModel;

namespace Orange.Controllers
{
    public class shopcartController : Controller
    {
        public ActionResult ChangeNumber(string number,int id)
        {
            var num = new biz().UpNumber(int.Parse(number),id);
            return Json(num, JsonRequestBehavior.AllowGet);
        }
        // GET: shopcart
        public ActionResult Index(string delect_id,string arry)
        {
            var user = (VMUser)Session["User"];

            if (user == null)
            {
                ViewBag.Result = "请先登录";
                return View("../Login/Login");
            }
            Array arry1 = null;
            if (arry != null)
            {
                arry = arry.Replace("check_", "");
                arry1 = arry.Split(',');
                var flag = new biz().DelectShopcartAll(arry1);
                ViewBag.msg = "删除成功";
            }
            
            
            if (delect_id != null)
            {
                int delect_id1 = int.Parse(delect_id);
                var flag = new biz().DelectShopcart(delect_id1);
                ViewBag.msg = "删除成功";
            }
            ViewBag.ShopCar = new biz().shopcart(user);

            return View();
        }
    }
}