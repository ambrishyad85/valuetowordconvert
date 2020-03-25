using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCValueToWord.Startup))]
namespace MVCValueToWord
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
