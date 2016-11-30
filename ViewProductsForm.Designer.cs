namespace NewPOS
{
    partial class ViewProductsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewProductsForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gbAddProducts = new System.Windows.Forms.GroupBox();
            this.stckamnttxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnUploadProductImage = new System.Windows.Forms.Button();
            this.pbProductImage = new System.Windows.Forms.PictureBox();
            this.cmbSelectCategoryAddProduct = new System.Windows.Forms.ComboBox();
            this.lblUploadProductImage = new System.Windows.Forms.Label();
            this.lblSelectCategory = new System.Windows.Forms.Label();
            this.txtProductPrice = new System.Windows.Forms.TextBox();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.gbAddCategory = new System.Windows.Forms.GroupBox();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnUIploadCategoryImage = new System.Windows.Forms.Button();
            this.pbCategoryImage = new System.Windows.Forms.PictureBox();
            this.lblUploadCategoryImage = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.cmbFilterCategory = new System.Windows.Forms.ComboBox();
            this.btnViewAllProducts = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.editmode = new System.Windows.Forms.Button();
            this.summaryreport = new NewPOS.summaryreport();
            this.tblProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblProductTableAdapter = new NewPOS.summaryreportTableAdapters.tblProductTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbAddProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            this.gbAddCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCategoryImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.summaryreport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(491, 498);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.ColumnDividerDoubleClick += new System.Windows.Forms.DataGridViewColumnDividerDoubleClickEventHandler(this.dataGridView1_ColumnDividerDoubleClick);
            // 
            // gbAddProducts
            // 
            this.gbAddProducts.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbAddProducts.Controls.Add(this.stckamnttxt);
            this.gbAddProducts.Controls.Add(this.label2);
            this.gbAddProducts.Controls.Add(this.btnAddProduct);
            this.gbAddProducts.Controls.Add(this.btnUploadProductImage);
            this.gbAddProducts.Controls.Add(this.pbProductImage);
            this.gbAddProducts.Controls.Add(this.cmbSelectCategoryAddProduct);
            this.gbAddProducts.Controls.Add(this.lblUploadProductImage);
            this.gbAddProducts.Controls.Add(this.lblSelectCategory);
            this.gbAddProducts.Controls.Add(this.txtProductPrice);
            this.gbAddProducts.Controls.Add(this.lblProductPrice);
            this.gbAddProducts.Controls.Add(this.txtProductName);
            this.gbAddProducts.Controls.Add(this.lblProductName);
            this.gbAddProducts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAddProducts.Location = new System.Drawing.Point(521, 23);
            this.gbAddProducts.Name = "gbAddProducts";
            this.gbAddProducts.Size = new System.Drawing.Size(401, 302);
            this.gbAddProducts.TabIndex = 1;
            this.gbAddProducts.TabStop = false;
            this.gbAddProducts.Text = "Add New Products";
            // 
            // stckamnttxt
            // 
            this.stckamnttxt.Location = new System.Drawing.Point(153, 105);
            this.stckamnttxt.Name = "stckamnttxt";
            this.stckamnttxt.Size = new System.Drawing.Size(167, 25);
            this.stckamnttxt.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Stock Amount";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAddProduct.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddProduct.Location = new System.Drawing.Point(153, 263);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(167, 33);
            this.btnAddProduct.TabIndex = 9;
            this.btnAddProduct.Text = "+ Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnUploadProductImage
            // 
            this.btnUploadProductImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUploadProductImage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUploadProductImage.Location = new System.Drawing.Point(72, 208);
            this.btnUploadProductImage.Name = "btnUploadProductImage";
            this.btnUploadProductImage.Size = new System.Drawing.Size(75, 49);
            this.btnUploadProductImage.TabIndex = 8;
            this.btnUploadProductImage.Text = "Upload";
            this.btnUploadProductImage.UseVisualStyleBackColor = false;
            this.btnUploadProductImage.Click += new System.EventHandler(this.btnUploadProductImage_Click);
            // 
            // pbProductImage
            // 
            this.pbProductImage.BackColor = System.Drawing.Color.Turquoise;
            this.pbProductImage.Location = new System.Drawing.Point(153, 136);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(167, 121);
            this.pbProductImage.TabIndex = 7;
            this.pbProductImage.TabStop = false;
            // 
            // cmbSelectCategoryAddProduct
            // 
            this.cmbSelectCategoryAddProduct.FormattingEnabled = true;
            this.cmbSelectCategoryAddProduct.Location = new System.Drawing.Point(153, 79);
            this.cmbSelectCategoryAddProduct.Name = "cmbSelectCategoryAddProduct";
            this.cmbSelectCategoryAddProduct.Size = new System.Drawing.Size(167, 25);
            this.cmbSelectCategoryAddProduct.TabIndex = 6;
            // 
            // lblUploadProductImage
            // 
            this.lblUploadProductImage.AutoSize = true;
            this.lblUploadProductImage.Location = new System.Drawing.Point(25, 148);
            this.lblUploadProductImage.Name = "lblUploadProductImage";
            this.lblUploadProductImage.Size = new System.Drawing.Size(109, 17);
            this.lblUploadProductImage.TabIndex = 5;
            this.lblUploadProductImage.Text = "Upload an image";
            // 
            // lblSelectCategory
            // 
            this.lblSelectCategory.AutoSize = true;
            this.lblSelectCategory.Location = new System.Drawing.Point(36, 82);
            this.lblSelectCategory.Name = "lblSelectCategory";
            this.lblSelectCategory.Size = new System.Drawing.Size(99, 17);
            this.lblSelectCategory.TabIndex = 4;
            this.lblSelectCategory.Text = "Select Category";
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.Location = new System.Drawing.Point(153, 53);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.Size = new System.Drawing.Size(167, 25);
            this.txtProductPrice.TabIndex = 3;
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Location = new System.Drawing.Point(53, 56);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(85, 17);
            this.lblProductPrice.TabIndex = 2;
            this.lblProductPrice.Text = "Product Price";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(153, 27);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(167, 25);
            this.txtProductName.TabIndex = 1;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(42, 23);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(92, 17);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Product Name";
            // 
            // gbAddCategory
            // 
            this.gbAddCategory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbAddCategory.Controls.Add(this.btnAddCategory);
            this.gbAddCategory.Controls.Add(this.btnUIploadCategoryImage);
            this.gbAddCategory.Controls.Add(this.pbCategoryImage);
            this.gbAddCategory.Controls.Add(this.lblUploadCategoryImage);
            this.gbAddCategory.Controls.Add(this.txtCategoryName);
            this.gbAddCategory.Controls.Add(this.lblCategoryName);
            this.gbAddCategory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAddCategory.Location = new System.Drawing.Point(521, 331);
            this.gbAddCategory.Name = "gbAddCategory";
            this.gbAddCategory.Size = new System.Drawing.Size(401, 252);
            this.gbAddCategory.TabIndex = 2;
            this.gbAddCategory.TabStop = false;
            this.gbAddCategory.Text = "Add New Category of Products";
            this.gbAddCategory.Enter += new System.EventHandler(this.gbAddCategory_Enter);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAddCategory.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddCategory.Location = new System.Drawing.Point(153, 205);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(167, 33);
            this.btnAddCategory.TabIndex = 12;
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnUIploadCategoryImage
            // 
            this.btnUIploadCategoryImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUIploadCategoryImage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUIploadCategoryImage.Location = new System.Drawing.Point(72, 150);
            this.btnUIploadCategoryImage.Name = "btnUIploadCategoryImage";
            this.btnUIploadCategoryImage.Size = new System.Drawing.Size(75, 49);
            this.btnUIploadCategoryImage.TabIndex = 11;
            this.btnUIploadCategoryImage.Text = "Upload";
            this.btnUIploadCategoryImage.UseVisualStyleBackColor = false;
            this.btnUIploadCategoryImage.Click += new System.EventHandler(this.btnUIploadCategoryImage_Click);
            // 
            // pbCategoryImage
            // 
            this.pbCategoryImage.BackColor = System.Drawing.Color.Turquoise;
            this.pbCategoryImage.Location = new System.Drawing.Point(153, 71);
            this.pbCategoryImage.Name = "pbCategoryImage";
            this.pbCategoryImage.Size = new System.Drawing.Size(167, 128);
            this.pbCategoryImage.TabIndex = 10;
            this.pbCategoryImage.TabStop = false;
            // 
            // lblUploadCategoryImage
            // 
            this.lblUploadCategoryImage.AutoSize = true;
            this.lblUploadCategoryImage.Location = new System.Drawing.Point(25, 71);
            this.lblUploadCategoryImage.Name = "lblUploadCategoryImage";
            this.lblUploadCategoryImage.Size = new System.Drawing.Size(109, 17);
            this.lblUploadCategoryImage.TabIndex = 9;
            this.lblUploadCategoryImage.Text = "Upload an image";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(153, 35);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(167, 25);
            this.txtCategoryName.TabIndex = 3;
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(34, 38);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(100, 17);
            this.lblCategoryName.TabIndex = 2;
            this.lblCategoryName.Text = "Category Name";
            // 
            // cmbFilterCategory
            // 
            this.cmbFilterCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterCategory.FormattingEnabled = true;
            this.cmbFilterCategory.Location = new System.Drawing.Point(12, 39);
            this.cmbFilterCategory.Name = "cmbFilterCategory";
            this.cmbFilterCategory.Size = new System.Drawing.Size(253, 24);
            this.cmbFilterCategory.TabIndex = 7;
            this.cmbFilterCategory.SelectionChangeCommitted += new System.EventHandler(this.cmbFilterCategory_SelectionChangeCommitted);
            // 
            // btnViewAllProducts
            // 
            this.btnViewAllProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnViewAllProducts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAllProducts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnViewAllProducts.Location = new System.Drawing.Point(283, 12);
            this.btnViewAllProducts.Name = "btnViewAllProducts";
            this.btnViewAllProducts.Size = new System.Drawing.Size(154, 54);
            this.btnViewAllProducts.TabIndex = 9;
            this.btnViewAllProducts.Text = "&View All Products";
            this.btnViewAllProducts.UseVisualStyleBackColor = false;
            this.btnViewAllProducts.Click += new System.EventHandler(this.btnViewAllProducts_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(32, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select a Category of Products";
            // 
            // editmode
            // 
            this.editmode.BackColor = System.Drawing.Color.Red;
            this.editmode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editmode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.editmode.Location = new System.Drawing.Point(863, 7);
            this.editmode.Name = "editmode";
            this.editmode.Size = new System.Drawing.Size(76, 33);
            this.editmode.TabIndex = 11;
            this.editmode.Text = "&Edit";
            this.editmode.UseVisualStyleBackColor = false;
            this.editmode.Click += new System.EventHandler(this.editmode_Click);
            // 
            // summaryreport
            // 
            this.summaryreport.DataSetName = "summaryreport";
            this.summaryreport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblProductBindingSource
            // 
            this.tblProductBindingSource.DataMember = "tblProduct";
            this.tblProductBindingSource.DataSource = this.summaryreport;
            // 
            // tblProductTableAdapter
            // 
            this.tblProductTableAdapter.ClearBeforeFill = true;
            // 
            // ViewProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(951, 595);
            this.Controls.Add(this.editmode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnViewAllProducts);
            this.Controls.Add(this.cmbFilterCategory);
            this.Controls.Add(this.gbAddCategory);
            this.Controls.Add(this.gbAddProducts);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewProductsForm";
            this.Text = "SwypePOS | Designed for Businesses/Merchants";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewProductsForm_FormClosed);
            this.Load += new System.EventHandler(this.ViewProductsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbAddProducts.ResumeLayout(false);
            this.gbAddProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            this.gbAddCategory.ResumeLayout(false);
            this.gbAddCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCategoryImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.summaryreport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox gbAddProducts;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnUploadProductImage;
        private System.Windows.Forms.PictureBox pbProductImage;
        private System.Windows.Forms.ComboBox cmbSelectCategoryAddProduct;
        private System.Windows.Forms.Label lblUploadProductImage;
        private System.Windows.Forms.Label lblSelectCategory;
        private System.Windows.Forms.TextBox txtProductPrice;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.GroupBox gbAddCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnUIploadCategoryImage;
        private System.Windows.Forms.PictureBox pbCategoryImage;
        private System.Windows.Forms.Label lblUploadCategoryImage;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
        private System.Windows.Forms.Button btnViewAllProducts;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox stckamnttxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button editmode;
        private summaryreport summaryreport;
        private System.Windows.Forms.BindingSource tblProductBindingSource;
        private summaryreportTableAdapters.tblProductTableAdapter tblProductTableAdapter;
    }
}