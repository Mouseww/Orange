using Orange.Models;
using Orange.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orange.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        /// <summary>
        /// 安全设置
        /// </summary>
        /// <returns></returns>
        public ActionResult saftey()
        {
            return View();
        }
        /// <summary>
        /// 退款售后
        /// </summary>
        /// <returns></returns>
        public ActionResult change()
        {
            return View();
        }
        /// <summary>
        /// 优惠券
        /// </summary>
        /// <returns></returns>
        public ActionResult coupon()
        {
            return View();
        }
        /// <summary>
        /// 红包
        /// </summary>
        /// <returns></returns>
        public ActionResult bonus()
        {
            return View();
        }
        /// <summary>
        /// 账单明细
        /// </summary>
        /// <returns></returns>
        public ActionResult bill()
        {
            return View();
        }
        /// <summary>
        /// 收藏
        /// </summary>
        /// <returns></returns>
        public ActionResult collection()
        {
            return View();
        }
        /// <summary>
        /// 足迹
        /// </summary>
        /// <returns></returns>
        public ActionResult foot()
        {
            return View();
        }
        /// <summary>
        /// 评价
        /// </summary>
        /// <returns></returns>
        public ActionResult comment()
        {
            return View();
        }
        /// <summary>
        /// 消息
        /// </summary>
        /// <returns></returns>
        public ActionResult news()
        {
            return View();
        }
        /// <summary>
        /// 订单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult order()
        {
            return View();
        }
        /// <summary>
        /// 地址管理
        /// </summary>
        /// <returns></returns>
        public ActionResult address()
        {
            return View();
        }
        /// <summary>
        /// 左侧导航栏
        /// </summary>
        /// <returns></returns>
        public ActionResult left()
        {
            return View();
        }
        /// <summary>
        /// 个人信息
        /// </summary>
        /// <returns></returns>
            public ActionResult information()
        {
            return View();
        }
        /// <summary>
        /// 个人中心主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var user = (VMUser)Session["User"];

            if (user == null)
            {
                ViewBag.Result = "请先登录";
                return View("../Login/Login");
            }
            return View();
        }
    }
}