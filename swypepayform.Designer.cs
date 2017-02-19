namespace NewPOS
{
    partial class swypepayform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(swypepayform));
            this.label1 = new System.Windows.Forms.Label();
            this.cardid = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statuslabl = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPaymentAmount = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.merchantcodecombo = new System.Windows.Forms.ComboBox();
            this.tblCompanyDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.summaryreport = new NewPOS.summaryreport();
            this.tblUsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblUsersTableAdapter = new NewPOS.summaryreportTableAdapters.tblUsersTableAdapter();
            this.tblCompanyDetailsTableAdapter = new NewPOS.summaryreportTableAdapters.tblCompanyDetailsTableAdapter();
            this.nyagauid = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.VoucherBtn = new System.Windows.Forms.Button();
            this.payamnt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblCompanyDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.summaryreport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblUsersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(87, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tap Your SwypePay Card";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cardid
            // 
            this.cardid.AutoSize = true;
            this.cardid.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.cardid.ForeColor = System.Drawing.Color.LimeGreen;
            this.cardid.Location = new System.Drawing.Point(420, 297);
            this.cardid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cardid.Name = "cardid";
            this.cardid.Size = new System.Drawing.Size(87, 30);
            this.cardid.TabIndex = 1;
            this.cardid.Text = "Card ID";
            this.cardid.Click += new System.EventHandler(this.cardid_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(460, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Card/Wristband:";
            // 
            // statuslabl
            // 
            this.statuslabl.AutoSize = true;
            this.statuslabl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statuslabl.Location = new System.Drawing.Point(12, 328);
            this.statuslabl.Name = "statuslabl";
            this.statuslabl.Size = new System.Drawing.Size(55, 15);
            this.statuslabl.TabIndex = 3;
            this.statuslabl.Text = "waiting...";
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.OrangeRed;
            this.button13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button13.Location = new System.Drawing.Point(196, 262);
            this.button13.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(65, 51);
            this.button13.TabIndex = 36;
            this.button13.Text = "C";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Visible = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.OrangeRed;
            this.button11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button11.Location = new System.Drawing.Point(337, 262);
            this.button11.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(65, 51);
            this.button11.TabIndex = 35;
            this.button11.Text = "<";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Visible = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(267, 262);
            this.button10.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(65, 51);
            this.button10.TabIndex = 34;
            this.button10.Text = "0";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Visible = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(338, 206);
            this.button9.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(65, 51);
            this.button9.TabIndex = 33;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(267, 206);
            this.button8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(65, 51);
            this.button8.TabIndex = 32;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(196, 206);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(65, 51);
            this.button7.TabIndex = 31;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(338, 150);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(65, 51);
            this.button6.TabIndex = 30;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(267, 150);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(65, 51);
            this.button5.TabIndex = 29;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(196, 150);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 51);
            this.button4.TabIndex = 28;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(338, 94);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 51);
            this.button3.TabIndex = 27;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(267, 94);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 51);
            this.button2.TabIndex = 26;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 94);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 51);
            this.button1.TabIndex = 25;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.Location = new System.Drawing.Point(430, 134);
            this.txtPaymentAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.Size = new System.Drawing.Size(147, 29);
            this.txtPaymentAmount.TabIndex = 37;
            this.txtPaymentAmount.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOk.Location = new System.Drawing.Point(430, 171);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(147, 86);
            this.btnOk.TabIndex = 38;
            this.btnOk.Text = "&Complete Payment";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // merchantcodecombo
            // 
            this.merchantcodecombo.DataSource = this.tblCompanyDetailsBindingSource;
            this.merchantcodecombo.DisplayMember = "swypecode";
            this.merchantcodecombo.FormattingEnabled = true;
            this.merchantcodecombo.Location = new System.Drawing.Point(12, 184);
            this.merchantcodecombo.Name = "merchantcodecombo";
            this.merchantcodecombo.Size = new System.Drawing.Size(83, 29);
            this.merchantcodecombo.TabIndex = 39;
            this.merchantcodecombo.Visible = false;
            // 
            // tblCompanyDetailsBindingSource
            // 
            this.tblCompanyDetailsBindingSource.DataMember = "tblCompanyDetails";
            this.tblCompanyDetailsBindingSource.DataSource = this.summaryreport;
            // 
            // summaryreport
            // 
            this.summaryreport.DataSetName = "summaryreport";
            this.summaryreport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblUsersBindingSource
            // 
            this.tblUsersBindingSource.DataMember = "tblUsers";
            this.tblUsersBindingSource.DataSource = this.summaryreport;
            // 
            // tblUsersTableAdapter
            // 
            this.tblUsersTableAdapter.ClearBeforeFill = true;
            // 
            // tblCompanyDetailsTableAdapter
            // 
            this.tblCompanyDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // nyagauid
            // 
            this.nyagauid.Location = new System.Drawing.Point(20, 219);
            this.nyagauid.Name = "nyagauid";
            this.nyagauid.Size = new System.Drawing.Size(75, 37);
            this.nyagauid.TabIndex = 40;
            this.nyagauid.Text = "UID";
            this.nyagauid.UseVisualStyleBackColor = true;
            this.nyagauid.Visible = false;
            this.nyagauid.Click += new System.EventHandler(this.nyagauid_Click);
            // 
            // button12
            // 
            this.button12.Image = global::NewPOS.Properties.Resources.Cycle_recycle_refresh_repeat_arrow_512;
            this.button12.Location = new System.Drawing.Point(12, 12);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 37);
            this.button12.TabIndex = 41;
            this.button12.Text = "Refresh";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // VoucherBtn
            // 
            this.VoucherBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.VoucherBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.VoucherBtn.Location = new System.Drawing.Point(4, 56);
            this.VoucherBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.VoucherBtn.Name = "VoucherBtn";
            this.VoucherBtn.Size = new System.Drawing.Size(91, 49);
            this.VoucherBtn.TabIndex = 42;
            this.VoucherBtn.Text = "&Voucher";
            this.VoucherBtn.UseVisualStyleBackColor = false;
            this.VoucherBtn.Visible = false;
            this.VoucherBtn.Click += new System.EventHandler(this.VoucherBtn_Click);
            // 
            // payamnt
            // 
            this.payamnt.AutoSize = true;
            this.payamnt.Location = new System.Drawing.Point(436, 94);
            this.payamnt.Name = "payamnt";
            this.payamnt.Size = new System.Drawing.Size(19, 21);
            this.payamnt.TabIndex = 43;
            this.payamnt.Text = "...";
            // 
            // swypepayform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(622, 370);
            this.Controls.Add(this.payamnt);
            this.Controls.Add(this.VoucherBtn);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.nyagauid);
            this.Controls.Add(this.merchantcodecombo);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtPaymentAmount);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statuslabl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cardid);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "swypepayform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SwypePOS | Designed for Businesses/Merchants";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.swypepayform_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.swypepayform_FormClosed);
            this.Load += new System.EventHandler(this.swypepayform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblCompanyDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.summaryreport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblUsersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label cardid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label statuslabl;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPaymentAmount;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox merchantcodecombo;
        private summaryreport summaryreport;
        private System.Windows.Forms.BindingSource tblUsersBindingSource;
        private summaryreportTableAdapters.tblUsersTableAdapter tblUsersTableAdapter;
        private System.Windows.Forms.BindingSource tblCompanyDetailsBindingSource;
        private summaryreportTableAdapters.tblCompanyDetailsTableAdapter tblCompanyDetailsTableAdapter;
        private System.Windows.Forms.Button nyagauid;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button VoucherBtn;
        private System.Windows.Forms.Label payamnt;
    }
}