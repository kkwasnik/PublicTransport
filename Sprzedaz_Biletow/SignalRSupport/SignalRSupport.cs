
using Microsoft.AspNet.SignalR.Client;      

namespace DesktopApplication.SignalRSupport
{
    public sealed class SignalRSupport
    {
        private readonly byte[] entropy = { 1, 2, 3, 4, 5, 6 };

        private readonly LoginForm loginWindow;

        private HubConnection hubConnection;

        private IHubProxy statusHubProxy;

        public SignalRSupport(string address, LoginForm loginWindow, LoginData loginData)
        {
        }
    }
}
