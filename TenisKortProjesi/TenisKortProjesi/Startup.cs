using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TenisKortProjesi.Startup))]
namespace TenisKortProjesi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
