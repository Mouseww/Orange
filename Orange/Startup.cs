using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Orange.Startup))]
namespace Orange
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
