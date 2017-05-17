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
        public ActionResult SavePicture(string picString)
        {
            bool isOk = false;
            string msg = string.Empty;
            //其他操作
            //.........
            //.........
            return Json(new { suc = isOk, msg = msg });
        }

        public ActionResult dropzone(HttpPostedFileBase file)
        {

            if (file == null)
            {
                return Content("没有文件！", "text/plain");
            }
            var fileName = Path.Combine(Request.MapPath("../images"), Path.GetFileName(file.FileName));
            ViewBag.filepath = Path.GetFileName(file.FileName);
            try
            {
                file.SaveAs(fileName);
                //tm.AttachmentPath = fileName;//得到全部model信息

                return View("上传成功 ！", "text/plain");
            }
            catch
            {
                return Content("上传异常 ！", "text/plain");
            }
        }
      
        }
    
}