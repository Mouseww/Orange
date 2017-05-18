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
            return View("../OrangeHT/Commodity1");
        }
        /// <summary>
        /// 商品信息修改
        /// </summary>
        /// <returns></returns>
        public ActionResult Commodity2()
        {
            return View("../OrangeHT/Commodity2");
        }
        /// <summary>
        /// 分类管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Commodity3()
        {
            return View("../OrangeHT/Commodity3");
        }
        /// <summary>
        /// 商品下架
        /// </summary>
        /// <returns></returns>
        public ActionResult Commodity4()
        {
            return View("../OrangeHT/Commodity4");
        }
      
        public ActionResult submit(string Commodity_name,string Commodity_typec,string jianjie,string option)
        {
            var arry=option.Split(',');


            var flag = new biz().AddCommodity(Commodity_name,Commodity_typec,jianjie,arry);
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
            ViewBag.filepath = Path.GetFileName(file.FileName)+time;
            try
            {
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