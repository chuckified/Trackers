using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LogTracker.Startup))]
namespace LogTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
