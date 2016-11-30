namespace NewPOS
{
    partial class stockreporttxns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stockreporttxns));
            this.productname = new System.Windows.Forms.ComboBox();
            this.tblProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.summaryreport = new NewPOS.summaryreport();
            this.filter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblProductTableAdapter = new NewPOS.summaryreportTableAdapters.tblProductTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openingstcklbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSalesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thisWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pdfexport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.summaryreport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // productname
            // 
            this.productname.DataSource = this.tblProductBindingSource;
            this.productname.DisplayMember = "productName";
            this.productname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productname.FormattingEnabled = true;
            this.productname.Location = new System.Drawing.Point(24, 101);
            this.productname.Name = "productname";
            this.productname.Size = new System.Drawing.Size(172, 25);
            this.productname.TabIndex = 0;
            // 
            // tblProductBindingSource
            // 
            this.tblProductBindingSource.DataMember = "tblProduct";
            this.tblProductBindingSource.DataSource = this.summaryreport;
            // 
            // summaryreport
            // 
            this.summaryreport.DataSetName = "summaryreport";
            this.summaryreport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // filter
            // 
            this.filter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.filter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.filter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filter.Location = new System.Drawing.Point(202, 96);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(125, 31);
            this.filter.TabIndex = 1;
            this.filter.Text = "Search Stock";
            this.filter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filter.UseVisualStyleBackColor = false;
            this.filter.Click += new System.EventHandler(this.filter_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(494, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "0pcs";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 178);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(673, 547);
            this.dataGridView1.TabIndex = 3;
            // 
            // tblProductTableAdapter
            // 
            this.tblProductTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Product Item";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total Items Sold";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Opening Stock";
            // 
            // openingstcklbl
            // 
            this.openingstcklbl.AutoSize = true;
            this.openingstcklbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openingstcklbl.Location = new System.Drawing.Point(369, 106);
            this.openingstcklbl.Name = "openingstcklbl";
            this.openingstcklbl.Size = new System.Drawing.Size(63, 32);
            this.openingstcklbl.TabIndex = 7;
            this.openingstcklbl.Text = "0pcs";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(610, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Available Stock";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(618, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 32);
            this.label7.TabIndex = 9;
            this.label7.Text = "-pcs";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label8.Location = new System.Drawing.Point(449, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 65);
            this.label8.TabIndex = 10;
            this.label8.Text = "|";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label9.Location = new System.Drawing.Point(572, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 65);
            this.label9.TabIndex = 11;
            this.label9.Text = "|";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Stock Sale Records";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Location = new System.Drawing.Point(284, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(182, 25);
            this.label11.TabIndex = 13;
            this.label11.Text = "General Stock Status";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.filterResultsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(723, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateReportToolStripMenuItem,
            this.emailReportToolStripMenuItem,
            this.printSalesReportToolStripMenuItem,
            this.asPDFToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // generateReportToolStripMenuItem
            // 
            this.generateReportToolStripMenuItem.Image = global::NewPOS.Properties.Resources.success;
            this.generateReportToolStripMenuItem.Name = "generateReportToolStripMenuItem";
            this.generateReportToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.generateReportToolStripMenuItem.Text = "Generate Report";
            // 
            // emailReportToolStripMenuItem
            // 
            this.emailReportToolStripMenuItem.Image = global::NewPOS.Properties.Resources.success;
            this.emailReportToolStripMenuItem.Name = "emailReportToolStripMenuItem";
            this.emailReportToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.emailReportToolStripMenuItem.Text = "Email Report";
            // 
            // printSalesReportToolStripMenuItem
            // 
            this.printSalesReportToolStripMenuItem.Image = global::NewPOS.Properties.Resources.success;
            this.printSalesReportToolStripMenuItem.Name = "printSalesReportToolStripMenuItem";
            this.printSalesReportToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.printSalesReportToolStripMenuItem.Text = "Print Stock Report";
            this.printSalesReportToolStripMenuItem.Click += new System.EventHandler(this.printSalesReportToolStripMenuItem_Click);
            // 
            // asPDFToolStripMenuItem
            // 
            this.asPDFToolStripMenuItem.Image = global::NewPOS.Properties.Resources.success;
            this.asPDFToolStripMenuItem.Name = "asPDFToolStripMenuItem";
            this.asPDFToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.asPDFToolStripMenuItem.Text = "As PDF";
            this.asPDFToolStripMenuItem.Click += new System.EventHandler(this.asPDFToolStripMenuItem_Click);
            // 
            // filterResultsToolStripMenuItem
            // 
            this.filterResultsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todayToolStripMenuItem,
            this.thisWeekToolStripMenuItem,
            this.monthlyToolStripMenuItem,
            this.yearlyToolStripMenuItem});
            this.filterResultsToolStripMenuItem.Name = "filterResultsToolStripMenuItem";
            this.filterResultsToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.filterResultsToolStripMenuItem.Text = "Filter Results";
            // 
            // todayToolStripMenuItem
            // 
            this.todayToolStripMenuItem.Image = global::NewPOS.Properties.Resources.success1;
            this.todayToolStripMenuItem.Name = "todayToolStripMenuItem";
            this.todayToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.todayToolStripMenuItem.Text = "Today";
            // 
            // thisWeekToolStripMenuItem
            // 
            this.thisWeekToolStripMenuItem.Image = global::NewPOS.Properties.Resources.success1;
            this.thisWeekToolStripMenuItem.Name = "thisWeekToolStripMenuItem";
            this.thisWeekToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.thisWeekToolStripMenuItem.Text = "This Week";
            // 
            // monthlyToolStripMenuItem
            // 
            this.monthlyToolStripMenuItem.Image = global::NewPOS.Properties.Resources.success1;
            this.monthlyToolStripMenuItem.Name = "monthlyToolStripMenuItem";
            this.monthlyToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.monthlyToolStripMenuItem.Text = "Monthly";
            // 
            // yearlyToolStripMenuItem
            // 
            this.yearlyToolStripMenuItem.Image = global::NewPOS.Properties.Resources.success1;
            this.yearlyToolStripMenuItem.Name = "yearlyToolStripMenuItem";
            this.yearlyToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.yearlyToolStripMenuItem.Text = "Yearly";
            // 
            // pdfexport
            // 
            this.pdfexport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pdfexport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pdfexport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pdfexport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pdfexport.Location = new System.Drawing.Point(569, 27);
            this.pdfexport.Name = "pdfexport";
            this.pdfexport.Size = new System.Drawing.Size(125, 31);
            this.pdfexport.TabIndex = 16;
            this.pdfexport.Text = "PDF Export";
            this.pdfexport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.pdfexport.UseVisualStyleBackColor = false;
            this.pdfexport.Click += new System.EventHandler(this.pdfexport_Click);
            // 
            // stockreporttxns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(723, 733);
            this.Controls.Add(this.pdfexport);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.openingstcklbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.productname);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "stockreporttxns";
            this.Text = "SwypePOS | Designed for Businesses/Merchants";
            this.Load += new System.EventHandler(this.stockreporttxns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.summaryreport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox productname;
        private System.Windows.Forms.Button filter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private summaryreport summaryreport;
        private System.Windows.Forms.BindingSource tblProductBindingSource;
        private summaryreportTableAdapters.tblProductTableAdapter tblProductTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label openingstcklbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printSalesReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thisWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yearlyToolStripMenuItem;
        private System.Windows.Forms.Button pdfexport;
        private System.Windows.Forms.ToolStripMenuItem asPDFToolStripMenuItem;
    }
}