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