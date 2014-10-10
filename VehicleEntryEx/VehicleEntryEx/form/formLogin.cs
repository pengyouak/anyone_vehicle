using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VehicleEntryEx
{
    public partial class formLogin : Form
    {
        WebReference.EnterService _service = new VehicleEntryEx.WebReference.EnterService();

        public formLogin()
        {
            InitializeComponent();
        }

        public void Init()
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == string.Empty || txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("账号或密码不能为空","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button1);
                return;
            }
            Login(txtUserName.Text.Trim().ToLower(),txtPassword.Text.Trim());
        }

        private void Login(string username,string pwd)
        {
            panel1.Enabled = false;
            try
            {
                string result = _service.LoginCheck(username, pwd);
                var json = (JObject)JsonConvert.DeserializeObject(result);
                if (json["status"] != null && json["status"].ToString().Contains("true"))
                {
                    ConfigMethod._isConnected = true;
                    this.BackColor = Color.Green;
                    switch (json["code"].ToString().Trim('\"'))
                    {
                        case "1":
                            {
                                ConfigMethod._config.DisplayName = json["Name"].ToString().Trim('\"');
                                ConfigMethod._config.UserID = json["UserId"].ToString().Trim('\"');
                                ConfigMethod._config.RoleCode = json["RoleCode"].ToString().Trim('\"');
                                ConfigMethod._config.RoleName = json["Role"].ToString().Trim('\"');
                                ConfigMethod._config.UserName = txtUserName.Text;
                                ConfigMethod._config.Password = txtPassword.Text;
                                break;
                            }
                        default:
                            {
                                MessageBox.Show(json["info"].ToString().Trim('\"'));
                                break;
                            }
                    }
                    switch (ConfigMethod._config.RoleCode)
                    {
                        case "0":
                            {
                                break;
                            }
                        case "1"://门卫
                            {
                                this.txtPassword.Text = string.Empty;
                                this.txtUserName.Text = string.Empty;
                                var keeper = new formKeeper();
                                keeper.ShowDialog();
                                //this.Hide();
                                break;
                            }
                        case "2"://业务员
                            {
                                this.txtPassword.Text = string.Empty;
                                this.txtUserName.Text = string.Empty;
                                var sale = new formSale();
                                sale.ShowDialog();
                                //this.Hide();
                                break;
                            }
                        default: { break; }
                    }
                }
                else
                {
                    MessageBox.Show("接口LoginCheck异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                this.BackColor = Color.Green;
            }
            catch (Exception ex) { 
                ConfigMethod._isConnected = false;
                this.BackColor = Color.Red;
                MessageBox.Show("接口LoginCheck调用异常\r\n" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally { panel1.Enabled = true; }
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            try
            {
                _service = new WebReference.EnterService();
                //string tmp = System.Text.RegularExpressions.Regex.Match(_service.Url, @"\d+\.\d+\.\d+\.\d+:\d+").Value;
                //_service.Url = _service.Url.Replace(tmp, ConfigMethod._config.IP);
                _service.Url = ConfigMethod._config.IP;
                string conStr = _service.TestConnection();
                if (conStr.Equals("A-A"))
                {
                    this.Text = "车辆入场登记";
                    ConfigMethod._isConnected = true;
                    this.BackColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("服务器连接失败!");
                }
            }
            catch (Exception ee)
            {
                ConfigMethod._isConnected = false;
                this.BackColor = Color.Red;
                MessageBox.Show("服务器连接失败!\r\n"+ee.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}