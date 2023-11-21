using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cursos0._0.Startup))]
namespace Cursos0._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
