using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;
using System.Threading;
using MessageBox = System.Windows.Forms.MessageBox;

namespace AutoUpd
{
    public partial class Launcher : Form
    {

        private IList<BackgroundWorker> BGworkersWithData = new List<BackgroundWorker>();
        public bool completed = false;
        public static string name = "\\SmartSellUPD.zip";
        public static string name2 = "SmartSellUPD.zip";
        public string path = Directory.GetCurrentDirectory();
        public string _localPath;
        public Launcher()
        {
            InitializeComponent();
            this.LauncherPB.Minimum = 0;
            this.LauncherPB.Maximum = 100;
            this.LauncherPB.Value = 0;
        }
    
        private void Launcher_Load(object sender, EventArgs e)
        {
            V.Text = "0 bytes / 0 bytes";
            Versja.Text = "Auto Updater";
            lbProgress.Text = "0 %";
        }
        //Metoda, która może zostać wykorzystana w przyszłości, ponawiająca połączenie.
        /*public static class Retry
        {
            public static void Do(
                Action action,
                TimeSpan retryInterval,
                int retryCount = 3)
            {
                Do<object>(() =>
                {
                    action();
                    return null;
                }, retryInterval, retryCount);
            }

            public static T Do<T>(
                Func<T> action,
                TimeSpan retryInterval,
                int retryCount = 3)
            {
                var exceptions = new List<Exception>();

                for (int retry = 0; retry < retryCount; retry++)
                {
                    try
                    {
                        if (retry > 0)
                            Thread.Sleep(retryInterval);
                        return action();
                    }
                    catch (Exception ex)
                    {
                        exceptions.Add(ex);
                    }
                }

                throw new AggregateException(exceptions);
            }
        }
        *
        Metoda sprawdzająca wersje aplikacji.
        */
        private void VersionChecking()
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(path + "\\SmartSell.exe");
            string ver = versionInfo.ProductVersion;
            DownloadCompletedtxt.Visible = false;
            WebClient request = new WebClient();
            string url = "ftp://serwer1585870.home.pl/SB/" + "wersja.txt";
            request.Credentials = new NetworkCredential("pz1-isk1-sggw", "ppz1-isk1-sggw");
            try
            {
                byte[] newFileData = request.DownloadData(url);
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                if (ver != fileString)
                {
                    /*DialogResult dialog = MessageBox.Show("Istnije nowsza wersja: " + fileString +
                                             "\n Czy pobrać ją teraz ?", "Aktualizacja", MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Information);
                    if (dialog == DialogResult.Yes)
                    {*/
                    BGworkersWithData.Add(BackgroungWorker);
                    BackgroungWorker.RunWorkerAsync();
                    CheckAllThreadsHaveFinishedWorking();
                }
                else
                {
                    CHCKUPD.Text = "Your version is up to date!";
                    UpToDateRun.Start();
                }
            }
            catch (WebException)
            {
                MessageBox.Show("Sprwadź połączenie sieciowe, nie ma możliwości połączenia się z hostem!");
            }
        }
        /*
        *
        Metoda wwypakowująca pobraną paczkę z aktualizacjami.
        */
        private void Installing()
        {
                if (!File.Exists(path + name))
                {
                    throw new FileNotFoundException();
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                else
                {
                    UnZip(path + name, path);
                }

                WaitToInstall.Start();
            CHCKUPD.Text = "Successfully installed ! ";
        }
        /*
        *
        Metoda wyodrębniania plików z formatu .zip.
        */
        public static void UnZip(string zipFile, string folderPath)
        {
                Shell32.Shell objShell = new Shell32.Shell();
                Shell32.Folder destinationFolder = objShell.NameSpace(folderPath);
                Shell32.Folder sourceFile = objShell.NameSpace(zipFile);

                foreach (var file in sourceFile.Items())
                {
                    destinationFolder.CopyHere(file, 4 | 16);
                }
        }
        /*
        *
        Metoda uruchamiająca aplikacje po poprawnym pobraniu i zaintalowaniu poprawek, 
        a następnie zamykająca program aktualizujący.
        */
        private void RunApp()
        {
            System.Diagnostics.Process updateProcess = new System.Diagnostics.Process();
            updateProcess.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "SmartSell.exe";
            updateProcess.StartInfo.Arguments = AppDomain.CurrentDomain.BaseDirectory;
            // (File.Exists(updateProcess.StartInfo.FileName))
                while (updateProcess.Start() == true)
                {
                    File.Delete(path + name);
                    Process.GetCurrentProcess().Kill();
                }
        }
        private void Version_Click(object sender, EventArgs e)
        {

        }
        private void Versja_TextChanged(object sender, EventArgs e)
        {

        }
        private void LauncherPB_Click(object sender, EventArgs e)
        {

        }
        private void lbProgress_TextChanged(object sender, EventArgs e)
        {

        }
        private void Launcher_Shown(object sender, EventArgs e)
        {
            CHCKUPD.Text = "Checking for updates...";
            WhenStart.Start();
        }
        /*
        *
        Metoda pobierająca aktualizacje z serwera ftp.
        */
        private void BackgroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                    String strAppDir = Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().GetName().CodeBase);
                    this._localPath = strAppDir;
                    FileInfo fileInfo = new FileInfo(name2);

                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://serwer1585870.home.pl/SB/" + name2);
                    request.Credentials = new NetworkCredential("pz1-isk1-sggw", "ppz1-isk1-sggw");
                    Boolean UsePassive = true;
                    Boolean UseBinary = true;
                    request.Method = WebRequestMethods.Ftp.GetFileSize;
                    request.Proxy = null;
                    request.KeepAlive = true;
                    request.UsePassive = UsePassive;
                    request.UseBinary = UseBinary;
                    long fileSize;
                    using (WebResponse resp = request.GetResponse())
                        fileSize = resp.ContentLength;

                    request = (FtpWebRequest)WebRequest.Create("ftp://serwer1585870.home.pl/SB/" + name2);
                    request.Credentials = new NetworkCredential("pz1-isk1-sggw", "ppz1-isk1-sggw");
                    using (FtpWebResponse responseFileDownload = (FtpWebResponse)request.GetResponse())
                    using (Stream responseStream = responseFileDownload.GetResponseStream())
                    using (FileStream writeStream = new FileStream(name2, FileMode.Create))
                    {
                        long length = responseFileDownload.ContentLength;
                        int Length = 2048;
                        Byte[] buffer = new Byte[2048];
                        int bytesRead = responseStream.Read(buffer, 0, Length);
                        int bytes = 0;

                        while (bytesRead > 0)
                        {
                            writeStream.Write(buffer, 0, bytesRead);
                            bytesRead = responseStream.Read(buffer, 0, Length);
                            bytes += bytesRead;
                            int totalSize = (int)(fileSize) / 1000; // Kbytes
                            BackgroungWorker.ReportProgress((bytes / 1000) * 100 / totalSize, totalSize);
                        }
                        responseFileDownload.Close();
                        writeStream.Close();
                    }
            }
            catch (Exception)
            {
                    MessageBox.Show("Nie udało się ustalić połączenia z hostem.");
                    Process.GetCurrentProcess().Kill();
            }
            finally
            {
                completed = true;
                lbProgress.Text = "100 %";
            }
        }
        /*
        *
        Aktualizacja paska progressbar.
        */
        private void BackgroungWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Debug.WriteLine(e.ProgressPercentage * (int)e.UserState / 100 + " KBytes / " + e.UserState + " KBytes" + " % = " + e.ProgressPercentage);
            lbProgress.Text = e.ProgressPercentage + " %";
            LauncherPB.Value = e.ProgressPercentage;
            V.Text = e.ProgressPercentage * (int)e.UserState / 100 + " KBytes / " + e.UserState + " KBytes";
        }
        private void BackgroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Download has been canceled.");
                completed = false;
            }
            else
            {
                DownloadCompletedtxt.Visible = true;
            }
        }
        private void V_Click(object sender, EventArgs e)
        {
        }
        private void DownloadCompletedtxt_TextChanged(object sender, EventArgs e)
        {
        }
        private void Versja_Click(object sender, EventArgs e)
        {

        }
        private void CHCKUPD_Click(object sender, EventArgs e)
        {

        }
        private void CheckAllThreadsHaveFinishedWorking()
        {
            bool hasAllThreadsFinished = false;
            while (!hasAllThreadsFinished)
            {
                hasAllThreadsFinished = (from worker in BGworkersWithData
                                         where worker.IsBusy
                                         select worker).ToList().Count == 0;
                Application.DoEvents();
                Thread.Sleep(100);
            }
            BGworkersWithData.Clear();
        }
        /*
        *
        Metoda deklarująca warunki, które muszą zostać spełnione aby aktualizacja zostałą rozpoczęta.
        */
        public void doIT()
        {
            if (File.Exists(path + "\\SmartSell.exe"))
            {
                if (completed == false)
                {
                    VersionChecking();
                }
                WaitToUnzip.Start();
            }
            else if (!File.Exists(path + "\\SmartSell.exe"))
            {
                if(completed == false)
                {
                    BGworkersWithData.Add(BackgroungWorker);
                    BackgroungWorker.RunWorkerAsync();
                    CheckAllThreadsHaveFinishedWorking();
                }
                    WaitToUnzip.Start();
            }
        }
        private void WhenStart_Tick(object sender, EventArgs e)
        {
            WhenStart.Stop();
            CHCKUPD.Text = "Update found! downloading...";
            doIT();
        }
        private void WaitToUnzip_Tick(object sender, EventArgs e)
        {
            WaitToUnzip.Stop();
            DownloadCompletedtxt.Visible = false;
            CHCKUPD.Text = "Installing... ";
            Installing();
        }

        private void WaitToInstall_Tick(object sender, EventArgs e)
        {
            WaitToInstall.Stop();
            WaintToRun.Start();
            CHCKUPD.Text = "Running SmartSell... ";
        }

        private void WaintToRun_Tick(object sender, EventArgs e)
        {
            WaintToRun.Stop();
            RunApp();
        }

        private void UpToDateRun_Tick(object sender, EventArgs e)
        {
            UpToDateRun.Stop();
            CHCKUPD.Text = "Running SmartSell...";
            RunApp();
        }
    }
}