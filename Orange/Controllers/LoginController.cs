using Orange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orange.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult register(string email, string password)
        {
            if (email != null){ 
            var flag = new biz().AddUser(email, password);
            if (flag)
            {
                    ViewBag.flagzc = flag;
                return View();
            }
        }
            return View();
        }
        /// 登录页
        public ActionResult Login(string user,string password)
        {
            
            if (user == null)
            {
                return View();
            }
            try {
                User user1 = new Models.User();
                user1.username = user;
                user1.password = password;
                var User = new biz().Login(user1);

                if (User.Count!= 0) { 
                        ViewBag.flag = true;
                        Session["User"] = User[0];
                        return View();
                }
                else
                    {
                        ViewBag.flag = false;
                        ViewBag.Result = "用户名或密码错误";
                        return View();
                        
                    }
                


              

            }
            catch { return View(); }
           
        }
       
    }
}