using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyDatabase.StartupOwin))]

namespace MyDatabase
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
