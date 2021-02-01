using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Simon.Startup))]
namespace Simon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
