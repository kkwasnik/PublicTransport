namespace DesktopApplication.SignalRSupport
{
    public class LoginData
    {
        public bool LoginSucceeded { get; set; }

        public bool RememberMe { get; set; }

        public string Domain { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }                

        public string BrowserPath { get; set; }
    }
}
