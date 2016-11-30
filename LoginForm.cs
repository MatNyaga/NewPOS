using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPOS
{
    public partial class LoginForm : Form
    {
        Database1Entities dbe = new Database1Entities();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter Phone Number and password.");
                return;
            }

            tblUsers l = new tblUsers();

            foreach (var p in dbe.tblUsers)
            {
                if (p.userName == txtUserName.Text && p.password == txtPassword.Text)
                {
                    MessageBox.Show("Successfully Logged In");

                    Form1 f1 = new Form1();

                    //f1.lblHello.Text = "User: " + p.userName;

                    f1.Show();
                    this.Hide();

                    return;
                }
            }
            foreach (var p in dbe.tblUsers)
            {
                if (p.userName != txtUserName.Text || p.password != txtPassword.Text)
                {
                    MessageBox.Show("Wrong Username and/or Password.");
                    return;
                }
            }
        }

        private void llblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm rf1 = new RegisterForm();

            rf1.Show();
        }

        private void lblMessageLogin_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignIn_Click(this, new EventArgs());
            }
        }

        private static DialogResult ShowInputDialog(ref string input, string type, string Title)
        {
            System.Drawing.Size size = new System.Drawing.Size(250, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = Title;

            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("The Caps Lock key is ON.");
            }
            System.Windows.Forms.TextBox textBox = new TextBox();
            if (type == "password")
            {
                textBox.PasswordChar = '*';
            }
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string pass = ".";
            ShowInputDialog(ref pass, "password", "Admin Password Input");
            if (pass == "terra")
            {
                MessageBox.Show("Successfully Logged In");

                Form1 f1 = new Form1();

                f1.lblHello.Text = "Admin";

                f1.Show();
                this.Hide();

                return;
            }
        }
    }
}
