namespace VehicleEntryEx
{
    partial class formSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSale));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.lblStatus = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.btnChargeEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lsvDataList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtShopId = new System.Windows.Forms.TextBox();
            this.lblStatus.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem6);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.MenuItems.Add(this.menuItem3);
            this.menuItem1.MenuItems.Add(this.menuItem4);
            this.menuItem1.MenuItems.Add(this.menuItem5);
            this.menuItem1.Text = "管理";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "退出";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click_1);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "重新连接";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Text = "新建单据";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Text = "重打管理";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Red;
            this.lblStatus.Controls.Add(this.panel1);
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(240, 268);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.chkDate);
            this.panel1.Controls.Add(this.btnChargeEdit);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.lsvDataList);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.txtShopId);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 262);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtStart);
            this.panel2.Controls.Add(this.dtEnd);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(7, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 56);
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(62, 3);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(154, 22);
            this.dtStart.TabIndex = 65;
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(62, 31);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(154, 22);
            this.dtEnd.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.Text = "截止日期";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.Text = "起始日期";
            // 
            // chkDate
            // 
            this.chkDate.Location = new System.Drawing.Point(6, 82);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(120, 20);
            this.chkDate.TabIndex = 69;
            this.chkDate.Text = "使用时间筛选";
            this.chkDate.CheckStateChanged += new System.EventHandler(this.chkDate_CheckStateChanged);
            // 
            // btnChargeEdit
            // 
            this.btnChargeEdit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnChargeEdit.Location = new System.Drawing.Point(164, 235);
            this.btnChargeEdit.Name = "btnChargeEdit";
            this.btnChargeEdit.Size = new System.Drawing.Size(62, 22);
            this.btnChargeEdit.TabIndex = 61;
            this.btnChargeEdit.Text = "编辑金额";
            this.btnChargeEdit.Click += new System.EventHandler(this.btnChargeEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnDel.Location = new System.Drawing.Point(59, 235);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(51, 22);
            this.btnDel.TabIndex = 59;
            this.btnDel.Text = "删  除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnEdit.Location = new System.Drawing.Point(112, 235);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(51, 22);
            this.btnEdit.TabIndex = 57;
            this.btnEdit.Text = "编  辑";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lsvDataList
            // 
            this.lsvDataList.Columns.Add(this.columnHeader1);
            this.lsvDataList.Columns.Add(this.columnHeader2);
            this.lsvDataList.Columns.Add(this.columnHeader3);
            this.lsvDataList.Columns.Add(this.columnHeader4);
            this.lsvDataList.Columns.Add(this.columnHeader5);
            this.lsvDataList.Columns.Add(this.columnHeader6);
            this.lsvDataList.Columns.Add(this.columnHeader7);
            this.lsvDataList.Columns.Add(this.columnHeader8);
            this.lsvDataList.Columns.Add(this.columnHeader9);
            this.lsvDataList.Columns.Add(this.columnHeader10);
            this.lsvDataList.Columns.Add(this.columnHeader11);
            this.lsvDataList.Columns.Add(this.columnHeader12);
            this.lsvDataList.Columns.Add(this.columnHeader13);
            this.lsvDataList.Columns.Add(this.columnHeader14);
            this.lsvDataList.Columns.Add(this.columnHeader15);
            this.lsvDataList.FullRowSelect = true;
            this.lsvDataList.Location = new System.Drawing.Point(7, 103);
            this.lsvDataList.Name = "lsvDataList";
            this.lsvDataList.Size = new System.Drawing.Size(219, 126);
            this.lsvDataList.TabIndex = 47;
            this.lsvDataList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "登记日期";
            this.columnHeader1.Width = 60;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "批号";
            this.columnHeader2.Width = 60;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "门店号";
            this.columnHeader3.Width = 60;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "经营户名称";
            this.columnHeader4.Width = 60;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "车船号";
            this.columnHeader5.Width = 60;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "品种";
            this.columnHeader6.Width = 60;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "品牌";
            this.columnHeader7.Width = 60;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "产地";
            this.columnHeader8.Width = 60;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "整重";
            this.columnHeader9.Width = 60;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "毛重";
            this.columnHeader10.Width = 60;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "数量";
            this.columnHeader11.Width = 60;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "单位";
            this.columnHeader12.Width = 60;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "押金";
            this.columnHeader13.Width = 60;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "应收费";
            this.columnHeader14.Width = 60;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "实收费";
            this.columnHeader15.Width = 60;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnSearch.Location = new System.Drawing.Point(156, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 22);
            this.btnSearch.TabIndex = 46;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.Text = "门店号";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnPrint.Location = new System.Drawing.Point(7, 235);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(51, 22);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "打  印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtShopId
            // 
            this.txtShopId.Location = new System.Drawing.Point(57, 2);
            this.txtShopId.MaxLength = 50;
            this.txtShopId.Name = "txtShopId";
            this.txtShopId.Size = new System.Drawing.Size(96, 21);
            this.txtShopId.TabIndex = 0;
            // 
            // formSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.lblStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "formSale";
            this.Text = "车辆入场登记";
            this.Load += new System.EventHandler(this.formSale_Load);
            this.lblStatus.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel lblStatus;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtShopId;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lsvDataList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnChargeEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuItem menuItem5;
    }
}