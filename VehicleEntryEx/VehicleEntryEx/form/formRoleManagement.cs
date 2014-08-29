using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VehicleEntryEx
{
    public partial class formRoleManagement : Form
    {
        public formRoleManagement()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string pwd=DateTime.Now.ToString("yyMMddHHmm");
            if (txtPwd.Text.Equals(pwd))
            {
                plRole.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboRoles.SelectedItem == null)
                return;
            var dec = new DES();
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\myconfig.xml";
            ConfigMethod._config.RoleName = dec.Encrypt(cboRoles.SelectedItem.ToString());
            ConfigMethod.Serialize<MyConfig>(ConfigMethod._config, path);
            MessageBox.Show("修改完成!请重新启动程序","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button1);
            Application.Exit();
        }
    }
}