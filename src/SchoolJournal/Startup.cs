using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolJournal.Startup))]
namespace SchoolJournal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
