using System;
using System.Windows.Forms;

namespace HstarSyncForQiniu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Startup.Init();//初始化各种配置
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrm());
        }
    }
}
