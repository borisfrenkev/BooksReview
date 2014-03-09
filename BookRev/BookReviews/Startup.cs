using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookReviews.Startup))]
namespace BookReviews
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
