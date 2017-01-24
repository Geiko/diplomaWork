using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookArt2.Startup))]
namespace BookArt2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
