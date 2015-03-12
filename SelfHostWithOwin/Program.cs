using System;
using Nancy;

using Owin;
using Nowin;
using Microsoft.Owin.Builder;
using System.Net;
using Microsoft.Owin.Hosting;
using System.Threading;

namespace SelfHostWithOwin
{
    class MainClass
    {
        public static void Main(string[] args)
        {


            var options = new StartOptions("http://127.0.0.1:1999")
            {
                ServerFactory = "Nowin",
            };

            using (WebApp.Start<Startup>(options))
            {
                Console.WriteLine("Running a http server on port 1999");
                do
                {
                    Thread.Sleep(60000);
                } while (!Console.KeyAvailable);
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Hi";
        }
    }
}
