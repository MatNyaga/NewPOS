namespace NewPOS
{
    partial class Adminsettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Adminsettings));
            this.llblRegister = new System.Windows.Forms.LinkLabel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cashlesspass = new System.Windows.Forms.TextBox();
            this.adminpass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ResettodefaultBtn = new System.Windows.Forms.Button();
            this.print = new System.Windows.Forms.CheckBox();
            this.acr1222llcdtxt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // llblRegister
            // 
            this.llblRegister.AutoSize = true;
            this.llblRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.llblRegister.Location = new System.Drawing.Point(187, 71);
            this.llblRegister.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblRegister.Name = "llblRegister";
            this.llblRegister.Size = new System.Drawing.Size(87, 15);
            this.llblRegister.TabIndex = 9;
            this.llblRegister.TabStop = true;
            this.llblRegister.Text = "Register here !";
            this.llblRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRegister_LinkClicked);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(29, 71);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(119, 15);
            this.lblMessage.TabIndex = 8;
            this.lblMessage.Text = "Register New Users:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(323, 352);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 38);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save and Exit";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Settings";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabel1.Location = new System.Drawing.Point(187, 108);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(62, 15);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Edit here !";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Edit Company Details:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Cashless Password Limit:";
            // 
            // cashlesspass
            // 
            this.cashlesspass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashlesspass.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cashlesspass.Location = new System.Drawing.Point(190, 145);
            this.cashlesspass.Name = "cashlesspass";
            this.cashlesspass.Size = new System.Drawing.Size(117, 21);
            this.cashlesspass.TabIndex = 14;
            // 
            // adminpass
            // 
            this.adminpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminpass.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.adminpass.Location = new System.Drawing.Point(190, 185);
            this.adminpass.Name = "adminpass";
            this.adminpass.PasswordChar = '*';
            this.adminpass.Size = new System.Drawing.Size(117, 21);
            this.adminpass.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 186);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Set Admin Pass:";
            // 
            // ResettodefaultBtn
            // 
            this.ResettodefaultBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ResettodefaultBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ResettodefaultBtn.Location = new System.Drawing.Point(190, 265);
            this.ResettodefaultBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ResettodefaultBtn.Name = "ResettodefaultBtn";
            this.ResettodefaultBtn.Size = new System.Drawing.Size(117, 38);
            this.ResettodefaultBtn.TabIndex = 17;
            this.ResettodefaultBtn.Text = "First Time Set Up";
            this.ResettodefaultBtn.UseVisualStyleBackColor = false;
            this.ResettodefaultBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // print
            // 
            this.print.AutoSize = true;
            this.print.Location = new System.Drawing.Point(190, 320);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(92, 17);
            this.print.TabIndex = 18;
            this.print.Text = "Print Receipts";
            this.print.UseVisualStyleBackColor = true;
            this.print.CheckedChanged += new System.EventHandler(this.print_CheckedChanged);
            // 
            // acr1222llcdtxt
            // 
            this.acr1222llcdtxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.acr1222llcdtxt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.acr1222llcdtxt.Location = new System.Drawing.Point(190, 217);
            this.acr1222llcdtxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.acr1222llcdtxt.Name = "acr1222llcdtxt";
            this.acr1222llcdtxt.Size = new System.Drawing.Size(117, 38);
            this.acr1222llcdtxt.TabIndex = 19;
            this.acr1222llcdtxt.Text = "ACR1222L LCD Text";
            this.acr1222llcdtxt.UseVisualStyleBackColor = false;
            this.acr1222llcdtxt.Click += new System.EventHandler(this.acr1222llcdtxt_Click);
            // 
            // Adminsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(486, 404);
            this.Controls.Add(this.acr1222llcdtxt);
            this.Controls.Add(this.print);
            this.Controls.Add(this.ResettodefaultBtn);
            this.Controls.Add(this.adminpass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cashlesspass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llblRegister);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Adminsettings";
            this.Text = "Admin Settings";
            this.Load += new System.EventHandler(this.Adminsettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llblRegister;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cashlesspass;
        private System.Windows.Forms.TextBox adminpass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ResettodefaultBtn;
        private System.Windows.Forms.CheckBox print;
        private System.Windows.Forms.Button acr1222llcdtxt;
    }
}