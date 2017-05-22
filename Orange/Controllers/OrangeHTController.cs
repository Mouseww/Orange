using Orange.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Orange.Controllers
{
    public class OrangeHTController : Controller
    {
        // GET: OrangeHT
        public ActionResult SelectType2(string id, string typename)
        {
            int type1_id = int.Parse(id);
            var res = new biz().bizSelectType2(type1_id, typename);
            //ViewBag.res = res;
            //return View("../OrangeHT/Commodity1");
            return Json(res, JsonRequestBehavior.AllowGet);

        }
        public ActionResult SelectType3(string id2, string typename2)
        {
            int type1_id = int.Parse(id2);
            var res = new biz().bizSelectType3(type1_id, typename2);
            return Json(res, JsonRequestBehavior.AllowGet);


        }

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 商品管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Commodity()
        {
           
            return View("../OrangeHT/Commodity");
        }
        /// <summary>
        /// 商品添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Commodity1()
        {
            var res = new biz().bizGetCommodityCategory();
            ViewBag.ComType = res;
            return View();
        }
        /// <summary>
        /// 商品信息修改
        /// </summary>
        /// <returns></returns>
        public ActionResult Commodity2()
        {
            return View();
        }
        /// <summary>
        /// 分类管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Commodity3()
        {
            return View();
        }
        /// <summary>
        /// 商品下架
        /// </summary>
        /// <returns></returns>
        public ActionResult Commodity4()
        {
            return View("../OrangeHT/Commodity4");
        }
      /// <summary>
      /// 商品添加ajax
      /// </summary>
      /// <param name="Commodity_name"></param>
      /// <param name="Commodity_typec"></param>
      /// <param name="jianjie"></param>
      /// <param name="option"></param>
      /// <returns></returns>
        public ActionResult submit(string Commodity_name,string Commodity_typec,string jianjie,string option)

        {
            var arry=option.Split(',');
            string img = ((List<string>)Session["filename"])[0];
            Session["filename"] = null;
            var flag = new biz().AddCommodity(Commodity_name,Commodity_typec,jianjie,arry,img);
            return Json(flag);
        }
        /// <summary>
        /// 图片上传至路径
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public ActionResult dropzone(HttpPostedFileBase file)
        {

            if (file == null)
            {
                return Content("没有文件！", "text/plain");
            }
            var time = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ","");
            
            var fileName = Path.Combine(Request.MapPath("../images"), Path.GetFileName(file.FileName)).Replace(".jpg",time+".jpg");
            if (Session["filename"] != null)
            {
                var listfile = (List<string>)Session["filename"];
                listfile.Add(Path.GetFileName(file.FileName).Replace(".jpg", time + ".jpg"));
                Session["filename"] = listfile;
            }
            else
            {
                var listfile = new List<string>();
                listfile.Add(Path.GetFileName(file.FileName).Replace(".jpg", time + ".jpg"));
                Session["filename"] = listfile;
            }
            try
            {
               // ViewBag.filename = Path.GetFileName(file.FileName) + time;
                file.SaveAs(fileName);
               
                //tm.AttachmentPath = fileName;//得到全部model信息

                return View("../OrangeHT/Commodity1");
            }
            catch
            {
                return Content("上传异常 ！", "text/plain");
            }
        }
      
        }
    
}