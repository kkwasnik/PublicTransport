using System;
using System.Windows.Forms;
using ApplicationDatabase.DataServices;

namespace DesktopApplication
{
    static class Program
    {                                                           
        public static string lv = Application.ProductVersion;           
        [STAThread]
        static void Main()
        {
            /*
             Sprawdzanie wersji aplikacji z wersją zamieszczoną na serwerze ftp,
             jeżeli jest nieaktualna, włącza się AutoUpdater.exe.
             */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(new DataService()));
            ////try
            ////{
            ////    WebClient request = new WebClient();
            ////    string url = "ftp://serwer1585870.home.pl/SB/" + "wersja.txt";
            ////    request.Credentials = new NetworkCredential("pz1-isk1-sggw", "ppz1-isk1-sggw");
            ////    byte[] newFileData = request.DownloadData(url);
            ////    string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
            ////    if (lv != fileString)
            ////    {
            ////        System.Diagnostics.Process updateProcess = new System.Diagnostics.Process();
            ////        updateProcess.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "AutoUpdater.exe";
            ////        updateProcess.StartInfo.Arguments = AppDomain.CurrentDomain.BaseDirectory;
            ////        while (updateProcess.Start() == true)
            ////        {
            ////            Process.GetCurrentProcess().Kill();
            ////        }
            ////    }
            ////    else
            ////    {
            ////        Application.EnableVisualStyles();
            ////        Application.SetCompatibleTextRenderingDefault(false);
            ////        Application.Run(new Form1());
            ////    }
            ////}
            ////catch (WebException)
            ////{
            ////    MessageBox.Show(@"Sprwadź połączenie sieciowe, nie ma możliwości połączenia się z hostem!");
            ////}
        }
    }
}

