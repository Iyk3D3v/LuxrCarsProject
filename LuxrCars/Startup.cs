using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Security.Cookies;
using LuxrCars.Infrastructure;

[assembly: OwinStartup(typeof(LuxrCars.Startup))]

namespace LuxrCars
{
    public class Startup 
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //app.Use(async (context, next) =>
            //{
            //    context.Response.Write("Hello world");
            //    await next();
            //});
            //to intercept response and play with it

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = Constants.AuthenticationType,
                LoginPath = new PathString(Constants.path)
            });
        }
    }
}
