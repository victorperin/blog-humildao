using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(blog_humilde.Startup))]
namespace blog_humilde
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
