using Orange.Models;
using Orange.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orange.Controllers
{
    public class IntroductionController : Controller
    {
        /// <summary>
        /// 订单页
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Commodity_id"></param>
        /// <param name="attr"></param>
        /// <param name="attr2"></param>
        /// <param name="number"></param>
        /// <param name="remove_user"></param>
        /// <param name="img"></param>
        /// <param name="Commodity_name"></param>
        /// <returns></returns>
        public ActionResult Order(int id, string Commodity_id, string op_type, string op_type2, string attr, string attr2, string number, string remove_user, string img, string Commodity_name)
        {
            var user = (VMUser)Session["User"];
            if (user != null)
            {
                if (id != null && Commodity_id != null)
                {
                    var Commodity = new ShopCars();
                    Commodity.Commodity_id = int.Parse(Commodity_id);
                    Commodity.option1_name = attr;
                    Commodity.option2_name = attr2;
                    Commodity.option2 = op_type2;
                    Commodity.option1 = op_type2;
                    Commodity.Number = int.Parse(number);
                    Commodity.img = img;
                    Commodity.shop_name = Commodity_name;
                    ViewBag.Commodity = Commodity;
                    var ress = new biz().SelectRess(user.ID);
                    ViewBag.ress = ress;

                }
            }
            else
            {
                ViewBag.msg = "请先登录";
                return View("../Login/Login");
            }
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Commodity_id"></param>
        /// <param name="attr"></param>
        /// <param name="attr2"></param>
        /// <param name="number"></param>
        /// <returns></returns>
            // GET: Introduction
        public ActionResult Index(int id, string Commodity_id, string attr, string attr2, string number, string remove_user)
        {
            var user = (VMUser)Session["User"];



            if (Commodity_id != null)
            {
                if (user != null)
                {
                    var fl = new biz().AddShopcart(Commodity_id, attr, attr2, number, user.username);
                    if (fl)
                    {
                        ViewBag.msg = "添加成功";
                    }
                    else
                    {
                        ViewBag.msg = "添加失败";
                    }

                }
                else
                {
                    ViewBag.msg = "请先登录";
                }
            }


            var Introduction = new biz().GetCommodityTD1(id);
            ViewBag.Introduction = Introduction;
            var attr_option1 = new biz().show_option1(id);

            var attr_option2 = new biz().show_option2(id);

            ViewBag.attr = attr_option2;
            ViewBag.attribute = attr_option1;
            return View();
        }

        public ActionResult ChangePrice(string kouwei, string guige)
        {
            int attr_option1 = int.Parse(kouwei);
            int attr_option2 = int.Parse(guige);
            var price1 = new biz().bizChangePrice(attr_option1, attr_option2);
            var price = price1[0];
            return Json(price, JsonRequestBehavior.AllowGet);
        }
    }
}