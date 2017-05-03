using Orange.Models;
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Commodity_id"></param>
        /// <param name="attr"></param>
        /// <param name="attr2"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        // GET: Introduction
        public ActionResult Index(int id, string Commodity_id, string attr, string attr2, string number,string remove_user)
        {
            User user = (User)Session["User"];

            if (remove_user == "1")//如果点击了注销，退出登录状态
            {
                Session["User"] = null;
            }

            if (Commodity_id != null)
            {
                if (user != null)
                {
                    var fl = new biz().AddShopcart(Commodity_id, attr, attr2, number, user.username);
                    if (fl)
                    {
                        ViewBag.msg = "添加成功";
                    }
                    else {
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
            //var attribute = new biz().show(id);
            //var attribute1 = new List<Commodity_attribute>();
            //var attribute2 = new biz().show(id);
            //var attribute3 = new List<Commodity_attribute>();

            //for (int i = 0; i < attribute.Count; i++)//遍历数组成员
            //{
            //    for(int j =i+1; j<attribute.Count; j++)
            //    {
            //        if (attribute[j] !=null && attribute[i]!=null&&attribute[i].Commodity_option2.option == attribute[j].Commodity_option2.option)
            //        {
            //            attribute[i] = null;


            //            if (i ==attribute.Count-1)
            //            {
            //                break;
            //            }
            //            continue;
            //        }
            //    }

            //}
            //for (int i = 0; i < attribute.Count; i++)
            //{
            //    if (attribute[i] != null)
            //    {
            //        attribute1.Add(attribute[i]);
            //    }
            //}
            ////选项1
            //for (int i = 0; i < attribute2.Count; i++)//遍历数组成员
            //{
            //    for (int j = i + 1; j < attribute2.Count; j++)
            //    {
            //        if (attribute2[j] != null && attribute2[i] != null && attribute2[i].Commodity_option1.option == attribute2[j].Commodity_option1.option)
            //        {
            //            attribute2[i] = null;


            //            if (i == attribute2.Count - 1)
            //            {
            //                break;
            //            }
            //            continue;
            //        }
            //    }

            //}
            //for (int i = 0; i < attribute2.Count; i++)
            //{
            //    if (attribute2[i] != null)
            //    {
            //        attribute3.Add(attribute2[i]);
            //    }
            //}
            ViewBag.attr = attr_option2;
            ViewBag.attribute = attr_option1;
            return View();
        }
        
    
    }
}