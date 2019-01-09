using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RADChristmasExam.Startup))]
namespace RADChristmasExam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
