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
        public ActionResult index_f()
        {
            return View();
        }
        // GET: Person
       public ActionResult footer()
        {
            return View();
        }
        public ActionResult password(string oldpsw,string newpsw)
        {
            var user = (VMUser)Session["User"];

            if (user == null)
            {
                ViewBag.Result = "请先登录";
                return View("../Login/Login");
            }
            if (oldpsw!=null&&newpsw!= null)
            {
                var flag = new biz().Uppsw(user.username,oldpsw,newpsw);

                if (flag)
                {
                    ViewBag.msg = "修改成功";
                }
                else
                {
                    ViewBag.msg = "原密码错误";
                }
            }
            return View();
        }
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
        public ActionResult address(string user_name, string user_phone, string sheng, string city, string quyu,string xiangxi,string id,string caozuo)
        {
            var user = (VMUser)Session["User"];
            if (caozuo != null)
            {
                try
                {
                    var end = new biz().DelectAddress(caozuo);
                    if (end)
                    {
                        ViewBag.msg = "操作成功";
                    }
                }
                catch { }
            }
            if (user_name != null) {
                if (id!=null)
                {
                    var end = new biz().UpAddress(user_name, user_phone, sheng, city, quyu, xiangxi, id);
                    if (end)
                    {
                        ViewBag.msg = "操作成功";
                    }
                }
                else { 
            var end = new biz().Addaddress(user_name, user_phone, sheng, city, quyu, xiangxi,user.ID);
                if (end)
                {
                    ViewBag.msg = "操作成功";
                }
                }
            }
            var ress = new biz().SelectRess(user.ID);
          
            ViewBag.ress = ress;
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
            public ActionResult information(string name1,string name2,string telephone,string birthday,string sex)
        {
            var user = (VMUser)Session["User"];

            if (user == null)
            {
                ViewBag.Result = "请先登录";
                return View("../Login/Login");
            }
            ViewBag.VMUser = user;
            if (name1!=null)
            {
               ViewBag.flag = new biz().UpUSer_IN(name1, name2, telephone, birthday, sex,user.username);
                Session["User"] = new biz().refresh(user.username);
                ViewBag.VMUser = (VMUser)Session["User"];
            }
            return View();
        }
        /// <summary>
        /// 个人中心主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string Id)
        {
            var user = (VMUser)Session["User"];
            if (Id == null)
            {
                Id = "1";
            }
            ViewBag.ID = Id;
            if (user == null)
            {
                ViewBag.Result = "请先登录";
                return View("../Login/Login");
            }
            return View();
        }
        public ActionResult address_ajax(string id)
        {
            var flag = new biz().UpRess(int.Parse(id));
            return Json(flag);
        }
    }
}