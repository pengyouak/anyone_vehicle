namespace VehicleEntryEx
{
    partial class formEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEdit));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mainMenu2 = new System.Windows.Forms.MainMenu();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtWholeWeight = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGrossWeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.txtTrafficId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShopId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCharges = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.cboDetail = new System.Windows.Forms.ComboBox();
            this.cboOrigin = new System.Windows.Forms.ComboBox();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.cboSubType = new System.Windows.Forms.ComboBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Green;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(240, 268);
            // 
            // txtWholeWeight
            // 
            this.txtWholeWeight.Location = new System.Drawing.Point(54, 156);
            this.txtWholeWeight.MaxLength = 10;
            this.txtWholeWeight.Name = "txtWholeWeight";
            this.txtWholeWeight.Size = new System.Drawing.Size(64, 21);
            this.txtWholeWeight.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(5, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 14);
            this.label8.Text = "毛重";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 14);
            this.label7.Text = "整重";
            // 
            // txtGrossWeight
            // 
            this.txtGrossWeight.Location = new System.Drawing.Point(54, 181);
            this.txtGrossWeight.MaxLength = 10;
            this.txtGrossWeight.Name = "txtGrossWeight";
            this.txtGrossWeight.Size = new System.Drawing.Size(64, 21);
            this.txtGrossWeight.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 14);
            this.label6.Text = "产地";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 14);
            this.label9.Text = "数量";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(54, 206);
            this.txtQuantity.MaxLength = 10;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(64, 21);
            this.txtQuantity.TabIndex = 11;
            this.txtQuantity.LostFocus += new System.EventHandler(this.txtQuantity_LostFocus);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 14);
            this.label5.Text = "品牌";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(120, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 14);
            this.label10.Text = "押金";
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(165, 159);
            this.txtDeposit.MaxLength = 10;
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(62, 21);
            this.txtDeposit.TabIndex = 13;
            this.txtDeposit.LostFocus += new System.EventHandler(this.txtDeposit_LostFocus);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 14);
            this.label4.Text = "品种";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(120, 184);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 14);
            this.label11.Text = "应收费";
            // 
            // txtFees
            // 
            this.txtFees.Location = new System.Drawing.Point(165, 184);
            this.txtFees.MaxLength = 10;
            this.txtFees.Name = "txtFees";
            this.txtFees.ReadOnly = true;
            this.txtFees.Size = new System.Drawing.Size(62, 21);
            this.txtFees.TabIndex = 14;
            this.txtFees.LostFocus += new System.EventHandler(this.txtFees_LostFocus);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(120, 209);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 14);
            this.label12.Text = "实收费";
            // 
            // lblOwner
            // 
            this.lblOwner.Location = new System.Drawing.Point(121, 5);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(103, 14);
            this.lblOwner.Text = "经营户名称";
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
            // txtShopId
            // 
            this.txtShopId.Location = new System.Drawing.Point(54, 2);
            this.txtShopId.MaxLength = 50;
            this.txtShopId.Name = "txtShopId";
            this.txtShopId.Size = new System.Drawing.Size(64, 21);
            this.txtShopId.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 14);
            this.label3.Text = "单位";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnSave.Location = new System.Drawing.Point(132, 231);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 22);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "保  存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.Text = "门店号";
            // 
            // txtCharges
            // 
            this.txtCharges.Location = new System.Drawing.Point(165, 207);
            this.txtCharges.MaxLength = 10;
            this.txtCharges.Name = "txtCharges";
            this.txtCharges.ReadOnly = true;
            this.txtCharges.Size = new System.Drawing.Size(62, 21);
            this.txtCharges.TabIndex = 15;
            this.txtCharges.LostFocus += new System.EventHandler(this.txtCharges_LostFocus);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cboUnit);
            this.panel1.Controls.Add(this.cboDetail);
            this.panel1.Controls.Add(this.cboOrigin);
            this.panel1.Controls.Add(this.cboBrand);
            this.panel1.Controls.Add(this.cboSubType);
            this.panel1.Controls.Add(this.cboType);
            this.panel1.Controls.Add(this.txtCharges);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtShopId);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTrafficId);
            this.panel1.Controls.Add(this.lblOwner);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtFees);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDeposit);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtQuantity);
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
            // cboUnit
            // 
            this.cboUnit.Location = new System.Drawing.Point(54, 231);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(64, 22);
            this.cboUnit.TabIndex = 12;
            // 
            // cboDetail
            // 
            this.cboDetail.Location = new System.Drawing.Point(54, 78);
            this.cboDetail.Name = "cboDetail";
            this.cboDetail.Size = new System.Drawing.Size(173, 22);
            this.cboDetail.TabIndex = 4;
            this.cboDetail.Visible = false;
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
            // cboSubType
            // 
            this.cboSubType.Location = new System.Drawing.Point(132, 52);
            this.cboSubType.Name = "cboSubType";
            this.cboSubType.Size = new System.Drawing.Size(95, 22);
            this.cboSubType.TabIndex = 3;
            this.cboSubType.SelectedIndexChanged += new System.EventHandler(this.cboSubType_SelectedIndexChanged);
            // 
            // cboType
            // 
            this.cboType.Location = new System.Drawing.Point(54, 52);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(77, 22);
            this.cboType.TabIndex = 2;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // formEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "formEdit";
            this.Text = "编辑";
            this.Load += new System.EventHandler(this.formEdit_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtWholeWeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGrossWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.TextBox txtTrafficId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtShopId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCharges;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboDetail;
        private System.Windows.Forms.ComboBox cboOrigin;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.ComboBox cboSubType;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.ComboBox cboUnit;
    }
}