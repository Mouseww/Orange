using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Orange.Models
{
    // 可以通过向 ApplicationUser 类添加更多属性来为用户添加配置文件数据。若要了解详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=317594。
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在此处添加自定义用户声明
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Commodity> Commodity { get; set; }
        public DbSet<Commodity_type> Commodity_type { get; set; }
        public DbSet<Commodity_1> Commodity_1 { get; set; }
        public DbSet<Commodity_2> Commodity_2 { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_IN> UsersIN { get; set; }
        public DbSet<Commodity_attribute> Commodity_attribute { get; set; }
        public DbSet<Shopcart> Shopcart { get; set; }
        public DbSet<IMG> IMG { get; set; }
        public DbSet<Ress> Ress { get; set; }
        public DbSet<Commodity_option1> Commodity_option1 { get; set; }
        public DbSet<Commodity_option2> Commodity_option2 { get; set; }
        public DbSet<Order> Order { get; set; }
    }
    
}