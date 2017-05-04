using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orange.Models;
using Orange.ViewModel;

namespace Orange.Controllers
{
    public class CommodityController : Controller
    {
        public ActionResult top_two()
        {
            return View();
        }
        public ActionResult Soure(string Name)
        {
            ViewBag.Soure = new biz().GetSoure(Name);
            return View();
        }
        // GET: Commodity
        public ActionResult top()
        {
            var user = (VMUser)Session["User"];
            if (user != null)
            {
                var res = new biz().shopcart_number(user);
                ViewBag.res = res;
            }
            return View();
        }
        public ActionResult right()
        {
            var user = (VMUser)Session["User"];
            if (user != null) {
                var res = new biz().shopcart_number(user);
                ViewBag.res = res;
                    }
            return View();
        }
        public ActionResult top_Catalog()
        {
            var user = (VMUser)Session["User"];
            if (user != null)
            {
                var res = new biz().shopcart_number(user);
                ViewBag.res = res;
            }
            return View();
        }
        public ActionResult Index(string remove_user)
        {
            if (remove_user =="1")//如果点击了注销，退出登录状态
            {
                Session["User"] = null;
            }
            ///页面展示部分
            ViewBag.Carousel = new biz().GETIMG("Carousel");///轮播图片
            ViewBag.Recommend = new biz().GETIMG("Recommend");//推荐子项
            ViewBag.Recommends = new biz().GETIMG("Recommends");
            ViewBag.huodong = new biz().GETIMG("huodong");
            ViewBag.tianpinfirst = new biz().GETIMG("tianpinfirst");
         
            ViewBag.tianpin = new biz().GetMoK("tianpin");

            
            List <Commodity_type> Commodity_type = new biz().GetCommodity_type();//取A级目录
            ViewBag.Commodity_type = Commodity_type;
            
            var Commodity_1= Details(Commodity_type);//取B级目录
            ViewBag.Commodity_1 = Commodity_1;

            var Commodity = Details1(Commodity_1);//c
            ViewBag.Commodity = Commodity;

            var Comm1 = new biz().GetCommodityTD(6);//取第一模块top标题
            ViewBag.Comm1 = Comm1;
            

            var Comm = Details5(Comm1);//
            ViewBag.Comm = Comm;

            var Comm2 = Details2(Comm1,Comm);//取模块的每个目录的首个商品
            ViewBag.Comm2 = Comm2;


            var Commm2 = new biz().GetCommodityTD(7);
            ViewBag.Commm2 = Commm2;
            var Commm = Details5(Commm2);//
            ViewBag.Commm= Commm;


            return View();
        }
        /// <summary>
        /// 单独取C级目录(用于主页模块)
        /// </summary>
        /// <param name="comm1"></param>
        /// <returns></returns>
        private List<Commodity_2> Details5(Commodity_1 comm1)
        {
            var Commod = new biz().GetCommodityTT(comm1.ID);
            return Commod;
        }
        /// <summary>
        /// 取C级目录
        /// </summary>
        /// <param name="Comname"></param>
        /// <returns></returns>
        public List<List<List<Commodity_2>>> Details1(List<List<Commodity_1>> Comname)
        {
            List<List<List<Commodity_2>>> Commodity3 = new List<List<List<Commodity_2>>>();

            foreach (var abc in Comname)
            {
                List<List<Commodity_2>> Commodity = new List<List<Commodity_2>>();
                foreach (var cba in abc)
                {
                    int id = cba.ID;

                    var Commodity2 = new biz().GetCommodityTT(id);
                    Commodity.Add(Commodity2);
                }
                Commodity3.Add(Commodity);
               
            }
            return Commodity3;
        }
        /// <summary>
        /// 每个子集目录的首个商品
        /// </summary>
        /// <param name="Commodity_1"></param>
        /// <param name="Commod"></param>
        /// <returns></returns>
        public List<Commodity> Details2(Commodity_1 Commodity_1,List<Commodity_2> Commod)
        {
            var Comm1 = new List<Commodity>();
           
            foreach(var com in Commod) { 
            var Comm=new biz().GetCommodityTT1(com.ID);
                if (Comm.Count != 0) { 
                Comm1.Add(Comm[0]);
                }
            }
            return Comm1;
        }
     
        public Commodity_1 Details3()
        {
            var Comm = new biz().GetCommodityTD(6);
            return Comm;
        }

        // GET: Commodity/Details/5
        public List<List<Commodity_1>> Details(List<Commodity_type> Comname)
        {
            List<List<Commodity_1>> Commodity = new List<List<Commodity_1>>();



            foreach (var abc in Comname)
            {

                int id = abc.ID;


                var Commodity2 = new biz().GetCommodityT(id);
                Commodity.Add(Commodity2);


            }

            return Commodity;
        }

        // GET: Commodity/Create
      
      
    }
}
