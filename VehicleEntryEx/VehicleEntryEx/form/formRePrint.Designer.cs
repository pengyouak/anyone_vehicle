namespace VehicleEntryEx
{
    partial class formRePrint
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
            this.lstDocuments = new System.Windows.Forms.ListBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDocuments
            // 
            this.lstDocuments.Location = new System.Drawing.Point(3, 3);
            this.lstDocuments.Name = "lstDocuments";
            this.lstDocuments.Size = new System.Drawing.Size(234, 226);
            this.lstDocuments.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(157, 236);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 24);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "打 印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(71, 236);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 24);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "加 载";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // formRePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lstDocuments);
            this.Menu = this.mainMenu1;
            this.Name = "formRePrint";
            this.Text = "重打管理";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDocuments;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnLoad;
    }
}