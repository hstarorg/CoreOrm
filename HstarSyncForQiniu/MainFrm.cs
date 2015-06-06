using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using HstarSyncForQiniu.Helper;
using Qiniu.IO;
using Qiniu.RS;

namespace HstarSyncForQiniu
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int a = 12;
            a += (a -= a);

            FileSystemWatcherHelper.StartNewWatcher("D:/test", null, null, null, (s4, e4) =>
            {
                Console.WriteLine("Deleted");
                Console.WriteLine(e4.FullPath);
            });



            //var policy = new PutPolicy("autoupload", 3600);
            //string upToken = policy.Token();
            //PutExtra extra = new PutExtra();
            //IOClient client = new IOClient {Proxy = WebRequest.GetSystemWebProxy()};
            //client.Proxy.Credentials = CredentialCache.DefaultCredentials;
            //var s=client.PutFile(upToken, "1.png", "1.png", extra);
            //MessageBox.Show(s.Exception.Message);
        }

        private void MainFrm_Shown(object sender, EventArgs e)
        {
            ConfigFrm cf = new ConfigFrm();
            cf.ShowDialog(this);
        }
    }
}
