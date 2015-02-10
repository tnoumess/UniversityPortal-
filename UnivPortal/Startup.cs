using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnivPortal.Startup))]
namespace UnivPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
