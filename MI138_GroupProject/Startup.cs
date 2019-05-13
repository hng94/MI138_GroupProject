using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MI138_GroupProject.Startup))]
namespace MI138_GroupProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
