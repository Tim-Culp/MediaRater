using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediaRater.Startup))]
namespace MediaRater
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
