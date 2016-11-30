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
    public partial class RegisterForm : Form
    {
        Database1Entities dbe = new Database1Entities();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnSubmitReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserNameReg.Text == "" || txtPasswordReg.Text == "")
                {
                    MessageBox.Show("Username and password must be filled out.");
                    return;
                }

                tblUsers l = new tblUsers();
                foreach (var p in dbe.tblUsers)
                {
                    if (p.userName == txtUserNameReg.Text)
                    {
                        MessageBox.Show("Username already exists, please pick another one.");
                        return;
                    }
                }
                l.userName = txtUserNameReg.Text;
                l.password = txtPasswordReg.Text;
                l.name = txtNameReg.Text;
                l.surname = txtSurnameReg.Text;
                l.email = txtEmailReg.Text;

                dbe.tblUsers.Add(l);

                dbe.SaveChanges();

                MessageBox.Show("Successfully registered");

                /*
                Form1 f1 = new Form1();

                f1.lblHello.Text = "User: " + l.userName;

                f1.Show();

                this.Close();*/
            }
            catch { }
        }

        private void txtNameReg_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNameReg_Click(object sender, EventArgs e)
        {

        }
    }
}
