using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XmlModifier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigMethod.GetWebServiceUrl();
            try
            {
                txtIP.Text = ConfigMethod._config.IP.Split(':')[0];
                txtPort.Text = ConfigMethod._config.IP.Split(':')[1];
                cboCom.SelectedItem = ConfigMethod._config.COM;
            }
            catch(Exception ex) {
                MessageBox.Show("Xml文件中的设置有误!\r\n" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigMethod._config.IP = txtIP.Text + ":" + txtPort.Text;
                ConfigMethod._config.COM = cboCom.SelectedItem.ToString();

                if (ConfigMethod.SetWebServiceUrl())
                    MessageBox.Show("保存成功~!!!");
                else
                    MessageBox.Show("保存失败~!!!");
            }
            catch { }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            plSet.Visible = txtPwd.Text == DateTime.Now.ToString("yyMMddHHmmh");
        }
    }
}