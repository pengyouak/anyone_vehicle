namespace VehicleEntryEx
{
    partial class formKeeper
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
            this.mnuManagement = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuReConnect = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShopId = new System.Windows.Forms.TextBox();
            this.txtTrafficId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboOrigin = new System.Windows.Forms.ComboBox();
            this.txtWholeWeight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGrossWeight = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboSub = new System.Windows.Forms.ComboBox();
            this.lblCharges = new System.Windows.Forms.Label();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboDetail = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuManagement);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // mnuManagement
            // 
            this.mnuManagement.MenuItems.Add(this.mnuExit);
            this.mnuManagement.MenuItems.Add(this.menuItem1);
            this.mnuManagement.MenuItems.Add(this.menuItem3);
            this.mnuManagement.MenuItems.Add(this.mnuReConnect);
            this.mnuManagement.Text = "管理";
            // 
            // mnuExit
            // 
            this.mnuExit.Text = "退出";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "查询修改";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // mnuReConnect
            // 
            this.mnuReConnect.Text = "重新连接";
            this.mnuReConnect.Click += new System.EventHandler(this.mnuReConnect_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "重打管理";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnPrint.Location = new System.Drawing.Point(132, 231);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 22);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "打  印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.Text = "门店号";
            // 
            // txtShopId
            // 
            this.txtShopId.Location = new System.Drawing.Point(54, 2);
            this.txtShopId.MaxLength = 50;
            this.txtShopId.Name = "txtShopId";
            this.txtShopId.Size = new System.Drawing.Size(64, 21);
            this.txtShopId.TabIndex = 0;
            this.txtShopId.LostFocus += new System.EventHandler(this.txtShopId_LostFocus);
            // 
            // txtTrafficId
            // 
            this.txtTrafficId.Location = new System.Drawing.Point(54, 27);
            this.txtTrafficId.MaxLength = 50;
            this.txtTrafficId.Name = "txtTrafficId";
            this.txtTrafficId.Size = new System.Drawing.Size(173, 21);
            this.txtTrafficId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 14);
            this.label2.Text = "车船号";
            // 
            // lblOwner
            // 
            this.lblOwner.Location = new System.Drawing.Point(121, 5);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(103, 14);
            this.lblOwner.Text = "经营户名称";
            // 
            // cboType
            // 
            this.cboType.Location = new System.Drawing.Point(54, 52);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(64, 22);
            this.cboType.TabIndex = 2;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 14);
            this.label4.Text = "品种";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 14);
            this.label5.Text = "品牌";
            // 
            // cboBrand
            // 
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboBrand.Location = new System.Drawing.Point(54, 104);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(173, 22);
            this.cboBrand.TabIndex = 5;
            this.cboBrand.Text = "请选择或输入品牌";
            this.cboBrand.LostFocus += new System.EventHandler(this.cboBrand_LostFocus);
            this.cboBrand.GotFocus += new System.EventHandler(this.cboBrand_GotFocus);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 14);
            this.label6.Text = "产地";
            // 
            // cboOrigin
            // 
            this.cboOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboOrigin.Location = new System.Drawing.Point(54, 130);
            this.cboOrigin.Name = "cboOrigin";
            this.cboOrigin.Size = new System.Drawing.Size(173, 22);
            this.cboOrigin.TabIndex = 6;
            this.cboOrigin.Text = "请选择或输入产地";
            this.cboOrigin.LostFocus += new System.EventHandler(this.cboOrigin_LostFocus);
            this.cboOrigin.GotFocus += new System.EventHandler(this.cboOrigin_GotFocus);
            // 
            // txtWholeWeight
            // 
            this.txtWholeWeight.Location = new System.Drawing.Point(54, 156);
            this.txtWholeWeight.MaxLength = 10;
            this.txtWholeWeight.Name = "txtWholeWeight";
            this.txtWholeWeight.ReadOnly = true;
            this.txtWholeWeight.Size = new System.Drawing.Size(64, 21);
            this.txtWholeWeight.TabIndex = 7;
            this.txtWholeWeight.LostFocus += new System.EventHandler(this.txtWholeWeight_LostFocus);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(7, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 14);
            this.label7.Text = "整重";
            // 
            // txtGrossWeight
            // 
            this.txtGrossWeight.Location = new System.Drawing.Point(54, 181);
            this.txtGrossWeight.MaxLength = 10;
            this.txtGrossWeight.Name = "txtGrossWeight";
            this.txtGrossWeight.ReadOnly = true;
            this.txtGrossWeight.Size = new System.Drawing.Size(64, 21);
            this.txtGrossWeight.TabIndex = 8;
            this.txtGrossWeight.LostFocus += new System.EventHandler(this.txtGrossWeight_LostFocus);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(5, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 14);
            this.label8.Text = "毛重";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(54, 206);
            this.txtQuantity.MaxLength = 10;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(64, 21);
            this.txtQuantity.TabIndex = 9;
            this.txtQuantity.LostFocus += new System.EventHandler(this.txtQuantity_LostFocus);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 14);
            this.label9.Text = "数量";
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(165, 156);
            this.txtDeposit.MaxLength = 10;
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(62, 21);
            this.txtDeposit.TabIndex = 11;
            this.txtDeposit.LostFocus += new System.EventHandler(this.txtDeposit_LostFocus);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(119, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 14);
            this.label10.Text = "押金";
            // 
            // txtFees
            // 
            this.txtFees.Location = new System.Drawing.Point(165, 181);
            this.txtFees.MaxLength = 10;
            this.txtFees.Name = "txtFees";
            this.txtFees.ReadOnly = true;
            this.txtFees.Size = new System.Drawing.Size(62, 21);
            this.txtFees.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(118, 184);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 14);
            this.label11.Text = "应收费";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(119, 210);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 14);
            this.label12.Text = "实收费";
            // 
            // cboSub
            // 
            this.cboSub.Location = new System.Drawing.Point(124, 52);
            this.cboSub.Name = "cboSub";
            this.cboSub.Size = new System.Drawing.Size(103, 22);
            this.cboSub.TabIndex = 3;
            this.cboSub.SelectedIndexChanged += new System.EventHandler(this.cboSub_SelectedIndexChanged);
            // 
            // lblCharges
            // 
            this.lblCharges.Location = new System.Drawing.Point(162, 210);
            this.lblCharges.Name = "lblCharges";
            this.lblCharges.Size = new System.Drawing.Size(62, 14);
            this.lblCharges.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboUnit
            // 
            this.cboUnit.Location = new System.Drawing.Point(54, 231);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(64, 22);
            this.cboUnit.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 14);
            this.label3.Text = "单位";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Red;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(240, 268);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboDetail);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtShopId);
            this.panel1.Controls.Add(this.cboUnit);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTrafficId);
            this.panel1.Controls.Add(this.cboSub);
            this.panel1.Controls.Add(this.lblOwner);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lblCharges);
            this.panel1.Controls.Add(this.txtFees);
            this.panel1.Controls.Add(this.cboType);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDeposit);
            this.panel1.Controls.Add(this.cboBrand);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtQuantity);
            this.panel1.Controls.Add(this.cboOrigin);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtGrossWeight);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtWholeWeight);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 262);
            // 
            // cboDetail
            // 
            this.cboDetail.Location = new System.Drawing.Point(54, 78);
            this.cboDetail.Name = "cboDetail";
            this.cboDetail.Size = new System.Drawing.Size(173, 22);
            this.cboDetail.TabIndex = 4;
            this.cboDetail.Visible = false;
            // 
            // formKeeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblStatus);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "formKeeper";
            this.Text = "车辆入场登记";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShopId;
        private System.Windows.Forms.TextBox txtTrafficId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboOrigin;
        private System.Windows.Forms.TextBox txtWholeWeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGrossWeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboSub;
        private System.Windows.Forms.Label lblCharges;
        private System.Windows.Forms.MenuItem mnuManagement;
        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.MenuItem mnuReConnect;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.ComboBox cboDetail;
    }
}

