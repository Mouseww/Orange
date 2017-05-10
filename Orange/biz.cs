using Orange.Models;
using Orange.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orange
{
    public class biz
    {
        ApplicationDbContext db = new ApplicationDbContext();
        internal List<Ress> SelectRess(int id)
        {
            return db.Ress.Where(a => a.User.ID == id).ToList();
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="name1"></param>
        /// <param name="name2"></param>
        /// <param name="telephone"></param>
        /// <param name="birthday"></param>
        /// <param name="sex"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        internal Boolean UpUSer_IN(string name1, string name2, string telephone, string birthday, string sex, string username)
        {
                var user_in = db.UsersIN.First(a => a.username==username);
                user_in.name = name2;
                user_in.nikename = name1;
                user_in.birthday = birthday;
                user_in.telephone = telephone;
                user_in.sex = (Gender)Enum.Parse(typeof(Gender), sex);
          int res =db.SaveChanges();
            if (res == 1) { return true; }
            return false;
            
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldpsw"></param>
        /// <param name="newpsw"></param>
        /// <returns></returns>
        internal Boolean Uppsw(string username, string oldpsw, string newpsw)
        {
            var User = db.Users.First(a => a.username == username && a.password == oldpsw);
            if (User==null)
            {
                return false;
            }
            User.password = newpsw;
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal Boolean AddUser(string username,string password)
        {
            User_IN user_in = new User_IN();
            user_in.username = username;
            
            
            db.UsersIN.Add(user_in);
            
            int res = db.SaveChanges();
            if (res == 1) {
                int ID = db.UsersIN.First(a => a.username == username).ID;
                User user = new User();
                user.username = username;
                user.password = password;
                user.User_IN_Id = ID;
                db.Users.Add(user);
                int res1 = db.SaveChanges();
                if (res1 == 1) { return true; }
                return false;
            }
            return false;
        }

        /// <summary>
        /// 添加到购物车
        /// </summary>
        /// <param name="Commodity_id"></param>
        /// <param name="attr"></param>
        /// <param name="attr2"></param>
        /// <param name="number"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        internal Boolean AddShopcart(string Commodity_id, string attr, string attr2, string number, string username)
        {

            Shopcart shopcart = new Shopcart();
            shopcart.Number = int.Parse(number);
            shopcart.Commodity_option1_Id = int.Parse(attr);
            shopcart.Commodity_option2_Id = int.Parse(attr2);
            shopcart.Commodity_Id = int.Parse(Commodity_id);
            shopcart.Username = username;

            db.Shopcart.Add(shopcart);
            int res = db.SaveChanges();
            if (res == 1) { return true; }
            return false;



         
        }
        internal bool DelectShopcartAll(Array arry1)
        { 
            foreach(string arry in arry1)
            {
                int id = Int32.Parse(arry);
                var item=db.Shopcart.Where(a => a.Id == id).ToList();
                db.Shopcart.Remove(item[0]);
            }
            int res = db.SaveChanges();
            if (res == 1) { return true; }
            return false;
        }
        /// <summary>
        /// 根据类型取图片
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal List<IMG> GETIMG(string type)
        {

            return db.IMG.Where(a => a.type == type).ToList();
        }
        /// <summary>
        /// 删除购物车单个商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal Boolean DelectShopcart(int id)
        {
            Shopcart shopcart = new Shopcart();

           var item= db.Shopcart.Where(a => a.Id == id).ToList();
            db.Shopcart.Remove(item[0]);
            int res = db.SaveChanges();
            if (res == 1) { return true; }
            return false;
        }

        internal List<Commodity> GetCommodity()
        {

            return db.Commodity.ToList();
        }
        /// <summary>
        /// 获取A级目录
        /// </summary>
        /// <returns></returns>
        internal List<Commodity_type> GetCommodity_type()
        {

            return db.Commodity_type.ToList();

        }
        /// <summary>
        /// 获取B级目录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal List<Commodity_1> GetCommodityT(int id)
        {

            if (id != null && id != 0)
            {
                return db.Commodity_1.Where(a => a.ID_1.ID == id).ToList();
            }
            return db.Commodity_1.ToList();
        }
        /// <summary>
        /// 获取单个B级目录对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal Commodity_1 GetCommodityTD(int id)
        {


            return db.Commodity_1.Where(a => a.ID == id).ToList()[0];

        }
        /// <summary>
        /// 根据商品id获取商品对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal Commodity GetCommodityTD1(int id)//详情页
        {


            return db.Commodity.Where(a =>a.Id == id).ToList()[0];

        }
        /// <summary>
        /// 获取C级目录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal List<Commodity_2> GetCommodityTT(int id)
        {
            if (id != null && id != 0)
            {
                return db.Commodity_2.Where(a => a.ID_1.ID == id).ToList();
            }
            return db.Commodity_2.ToList();
        }
        internal List<VMCommodity> GetMoK(string type)
        {
            var db1= db.IMG.Where(a => a.type == type)
                .Select(a => new VMCommodity
                {
                    Id=a.Commodity.Id,
                    Name=a.Commodity.Name,
                    img=a.Commodity.img,
                    jieshao=a.Commodity.jieshao,
                    Price=a.Commodity.Price,
                }
            ).ToList();
            return db1;
        }
        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal List<Commodity> GetCommodityTT1(int id)//
        {
            if (id != null && id != 0)
            {
                return db.Commodity.Where(a => a.ID.ID == id).ToList();
            }
            
            return db.Commodity.ToList();
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="user1"></param>
        /// <returns></returns>
        internal List<VMUser> Login(User user1)//login
        {
            return db.Users.Where(a => a.username == user1.username && a.password == user1.password)
                .Select(a=>new VMUser
                {name=a.User_IN.name,
                birthday=a.User_IN.birthday,
                sex=a.User_IN.sex.ToString(),
                telephone=a.User_IN.telephone,
                username=a.username,
                password=a.password,
                nikename=a.User_IN.nikename,
                ID=a.ID
                })
                .ToList();
        }
        /// <summary>
        /// 获得商品选项1属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal List<Commodity_option1> show_option1(int id)
        {
            return db.Commodity_option1.Where(a => a.Commodity.Id == id).ToList();
        }
        /// <summary>
        /// 获得商品选项1属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal List<Commodity_option2> show_option2(int id)
        {
            return db.Commodity_option2.Where(a => a.Commodity.Id == id).ToList();
        }
        /// <summary>
        /// 获取用户的购物车
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        internal List<ShopCars> shopcart(VMUser user)
        {

            return db.Shopcart.Where(a => a.Username == user.username)
                .Select(a => new ShopCars
                {
                    Id = a.Id,
                    shop_name = a.Commodity_id.Name,
                    option1 = a.Commodity_option1.option,
                    option1_id = a.Commodity_option1.Id,
                    option1_name = a.Commodity_option1.type_name,
                    option2 = a.Commodity_option2.option,
                    option2_id = a.Commodity_option2.Id,
                    option2_name = a.Commodity_option2.type_name,
                    Commodity_id = a.Commodity_id.Id,
                    img = a.Commodity_id.img,
                    img_small=a.Commodity_id.img_small,
                    Number = a.Number
                }).ToList();
        }
        /// <summary>
        /// 获取购物车已有商品数量
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        internal int shopcart_number(VMUser user)
        {
            var a = db.Shopcart.Where(ab => ab.Username == user.username).ToList();
            return a.Count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        internal List<VMSoure> GetSoure(string Name)
        {
            if (Name == null)
            {
                return db.Commodity.Select(b => new VMSoure
                {
                    id = b.Id,
                    Price = b.Price,
                    img = b.img,
                    Name = b.Name,
                    Ynumber = b.Number

                }).ToList();
            }
            return db.Commodity.Where(a => a.Name.Contains(Name) || a.ID.Name.Contains(Name) || a.ID.ID_1.Name.Contains(Name)||a.ID.ID_1.ID_1.Type_Name.Contains(Name))
                .Select(b => new VMSoure
                {
                    id = b.Id,
                    Price = b.Price,
                    img = b.img,
                    Name = b.Name,
                    Ynumber = b.Number

                }).ToList();
        }


        internal IList<Commodity_attribute> bizChangePrice(int attr_option1, int attr_option2)
        {
            var price = db.Commodity_attribute.Where(a => a.Commodity_option1.Id == attr_option1 && a.Commodity_option2.Id == attr_option2).ToList();
           
            return price;
        }
    }
}