using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PublicTransport.SignalR
{
    public class NotificationHub : Hub
    {
        private static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        [HubMethodName("sendMessages")]
        public static void SendMessages()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.updateMessages();
        }


    }
}