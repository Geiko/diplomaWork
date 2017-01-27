using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookArt.Startup))]
namespace BookArt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
