using System;
using System.Windows.Forms;
using HstarSyncForQiniu.Model;

namespace HstarSyncForQiniu
{
    public partial class ConfigFrm : Form
    {
        public ConfigFrm()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                this.BindSpaceConfigData();
            }
        }

        private void BindSpaceConfigData()
        {
            var list = new[] {new SpaceConfig
            {
                SystemPath = "D:/",
                RemoteSpaceName = "autoupload"
            }, new SpaceConfig
            {
                SystemPath = "C:/",
                RemoteSpaceName = "private"
            }};
            DgvSpaceConfig.DataSource = list;
        }

    }
}
