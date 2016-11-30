namespace NewPOS
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.lblNameReg = new System.Windows.Forms.Label();
            this.txtNameReg = new System.Windows.Forms.TextBox();
            this.txtSurnameReg = new System.Windows.Forms.TextBox();
            this.lblSurnameReg = new System.Windows.Forms.Label();
            this.txtEmailReg = new System.Windows.Forms.TextBox();
            this.lblEmailReg = new System.Windows.Forms.Label();
            this.txtUserNameReg = new System.Windows.Forms.TextBox();
            this.lblUserNameReg = new System.Windows.Forms.Label();
            this.txtPasswordReg = new System.Windows.Forms.TextBox();
            this.lblPasswordReg = new System.Windows.Forms.Label();
            this.btnSubmitReg = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNameReg
            // 
            this.lblNameReg.AutoSize = true;
            this.lblNameReg.Location = new System.Drawing.Point(21, 107);
            this.lblNameReg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameReg.Name = "lblNameReg";
            this.lblNameReg.Size = new System.Drawing.Size(43, 17);
            this.lblNameReg.TabIndex = 0;
            this.lblNameReg.Text = "Name";
            this.lblNameReg.Click += new System.EventHandler(this.lblNameReg_Click);
            // 
            // txtNameReg
            // 
            this.txtNameReg.Location = new System.Drawing.Point(82, 104);
            this.txtNameReg.Margin = new System.Windows.Forms.Padding(4);
            this.txtNameReg.Name = "txtNameReg";
            this.txtNameReg.Size = new System.Drawing.Size(162, 25);
            this.txtNameReg.TabIndex = 1;
            this.txtNameReg.TextChanged += new System.EventHandler(this.txtNameReg_TextChanged);
            // 
            // txtSurnameReg
            // 
            this.txtSurnameReg.Location = new System.Drawing.Point(82, 153);
            this.txtSurnameReg.Margin = new System.Windows.Forms.Padding(4);
            this.txtSurnameReg.Name = "txtSurnameReg";
            this.txtSurnameReg.Size = new System.Drawing.Size(162, 25);
            this.txtSurnameReg.TabIndex = 3;
            // 
            // lblSurnameReg
            // 
            this.lblSurnameReg.AutoSize = true;
            this.lblSurnameReg.Location = new System.Drawing.Point(21, 156);
            this.lblSurnameReg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSurnameReg.Name = "lblSurnameReg";
            this.lblSurnameReg.Size = new System.Drawing.Size(59, 17);
            this.lblSurnameReg.TabIndex = 2;
            this.lblSurnameReg.Text = "Surname";
            // 
            // txtEmailReg
            // 
            this.txtEmailReg.Location = new System.Drawing.Point(82, 198);
            this.txtEmailReg.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailReg.Name = "txtEmailReg";
            this.txtEmailReg.Size = new System.Drawing.Size(162, 25);
            this.txtEmailReg.TabIndex = 5;
            // 
            // lblEmailReg
            // 
            this.lblEmailReg.AutoSize = true;
            this.lblEmailReg.Location = new System.Drawing.Point(37, 201);
            this.lblEmailReg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmailReg.Name = "lblEmailReg";
            this.lblEmailReg.Size = new System.Drawing.Size(39, 17);
            this.lblEmailReg.TabIndex = 4;
            this.lblEmailReg.Text = "Email";
            // 
            // txtUserNameReg
            // 
            this.txtUserNameReg.Location = new System.Drawing.Point(82, 242);
            this.txtUserNameReg.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserNameReg.Name = "txtUserNameReg";
            this.txtUserNameReg.Size = new System.Drawing.Size(162, 25);
            this.txtUserNameReg.TabIndex = 7;
            // 
            // lblUserNameReg
            // 
            this.lblUserNameReg.AutoSize = true;
            this.lblUserNameReg.Location = new System.Drawing.Point(14, 245);
            this.lblUserNameReg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserNameReg.Name = "lblUserNameReg";
            this.lblUserNameReg.Size = new System.Drawing.Size(67, 17);
            this.lblUserNameReg.TabIndex = 6;
            this.lblUserNameReg.Text = "Username";
            // 
            // txtPasswordReg
            // 
            this.txtPasswordReg.Location = new System.Drawing.Point(82, 291);
            this.txtPasswordReg.Margin = new System.Windows.Forms.Padding(4);
            this.txtPasswordReg.Name = "txtPasswordReg";
            this.txtPasswordReg.Size = new System.Drawing.Size(162, 25);
            this.txtPasswordReg.TabIndex = 9;
            this.txtPasswordReg.UseSystemPasswordChar = true;
            // 
            // lblPasswordReg
            // 
            this.lblPasswordReg.AutoSize = true;
            this.lblPasswordReg.Location = new System.Drawing.Point(17, 294);
            this.lblPasswordReg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPasswordReg.Name = "lblPasswordReg";
            this.lblPasswordReg.Size = new System.Drawing.Size(64, 17);
            this.lblPasswordReg.TabIndex = 8;
            this.lblPasswordReg.Text = "Password";
            // 
            // btnSubmitReg
            // 
            this.btnSubmitReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSubmitReg.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSubmitReg.Location = new System.Drawing.Point(102, 324);
            this.btnSubmitReg.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitReg.Name = "btnSubmitReg";
            this.btnSubmitReg.Size = new System.Drawing.Size(116, 58);
            this.btnSubmitReg.TabIndex = 10;
            this.btnSubmitReg.Text = "Create Account";
            this.btnSubmitReg.UseVisualStyleBackColor = false;
            this.btnSubmitReg.Click += new System.EventHandler(this.btnSubmitReg_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(44, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 69);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(304, 388);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSubmitReg);
            this.Controls.Add(this.txtPasswordReg);
            this.Controls.Add(this.lblPasswordReg);
            this.Controls.Add(this.txtUserNameReg);
            this.Controls.Add(this.lblUserNameReg);
            this.Controls.Add(this.txtEmailReg);
            this.Controls.Add(this.lblEmailReg);
            this.Controls.Add(this.txtSurnameReg);
            this.Controls.Add(this.lblSurnameReg);
            this.Controls.Add(this.txtNameReg);
            this.Controls.Add(this.lblNameReg);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegisterForm";
            this.Text = "SwypePOS | Designed for Businesses/Merchants";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNameReg;
        private System.Windows.Forms.TextBox txtNameReg;
        private System.Windows.Forms.TextBox txtSurnameReg;
        private System.Windows.Forms.Label lblSurnameReg;
        private System.Windows.Forms.TextBox txtEmailReg;
        private System.Windows.Forms.Label lblEmailReg;
        private System.Windows.Forms.TextBox txtUserNameReg;
        private System.Windows.Forms.Label lblUserNameReg;
        private System.Windows.Forms.TextBox txtPasswordReg;
        private System.Windows.Forms.Label lblPasswordReg;
        private System.Windows.Forms.Button btnSubmitReg;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}