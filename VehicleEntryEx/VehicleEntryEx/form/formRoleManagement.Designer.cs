namespace VehicleEntryEx
{
    partial class formRoleManagement
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.plRole = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRoles = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.plRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // plRole
            // 
            this.plRole.Controls.Add(this.label2);
            this.plRole.Controls.Add(this.cboRoles);
            this.plRole.Controls.Add(this.button1);
            this.plRole.Location = new System.Drawing.Point(7, 103);
            this.plRole.Name = "plRole";
            this.plRole.Size = new System.Drawing.Size(226, 104);
            this.plRole.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(42, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.Text = "请选择当前设备的角色";
            // 
            // cboRoles
            // 
            this.cboRoles.Items.Add("门卫");
            this.cboRoles.Items.Add("业务员");
            this.cboRoles.Items.Add("管理员");
            this.cboRoles.Location = new System.Drawing.Point(42, 41);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Size = new System.Drawing.Size(137, 22);
            this.cboRoles.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "确定";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "请输入管理密码";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(161, 70);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(67, 21);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(13, 70);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(142, 21);
            this.txtPwd.TabIndex = 2;
            // 
            // formRoleManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.plRole);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtPwd);
            this.Menu = this.mainMenu1;
            this.Name = "formRoleManagement";
            this.Text = "角色管理";
            this.plRole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRoles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtPwd;

    }
}