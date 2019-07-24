using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewBid_Admin.Startup))]
namespace NewBid_Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
