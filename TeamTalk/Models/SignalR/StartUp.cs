using Microsoft.Owin;
using Owin;
using TeamTalk;


[assembly: OwinStartupAttribute(typeof(TeamTalk.Models.SignalR.Startup))]
namespace TeamTalk.Models.SignalR
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}