using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;

namespace NewPOS
{
    public partial class merchantlogin : Form
    {
        String phonenumber, pass, response;
        String merchantcode, email, role, type, phone;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void merchantlogin_Load(object sender, EventArgs e)
        {

        }

        private void oscheck_Click(object sender, EventArgs e)
        {
            compatibilitycheck form1 = new compatibilitycheck();
            form1.Show();
            this.Hide();
        }

        companydetailsclass mycompanyclass = new companydetailsclass();
        public merchantlogin()
        {
            InitializeComponent();
        }

        private async void login_Click(object sender, EventArgs e)
        {
            phonenumber = pnumber.Text;
            pass = password.Text;
            try
            {
                response = await "http://swypepay.co.ke/sandbox/frontend/web/index.php?r=user-profile/login-user".PostUrlEncodedAsync(new { phone = phonenumber, password = pass }).ReceiveString();
            }
            catch (Exception connectionerror) { MessageBox.Show(connectionerror.Message); }
            if (response.Contains("SUCCESS"))
            {
                int merchantindex = response.IndexOf("merchantCode");
                int emailindex = response.IndexOf("email");
                int passindex = response.IndexOf("password");
                int roleindex = response.IndexOf("role");
                int typeindex = response.IndexOf("type");
                int phoneindex = response.IndexOf("Telephone");
                int transtatusindex = response.IndexOf("transactionStatus");
                oscheck.Visible = true;

                //obtain values from string
                merchantcode = response.Substring(merchantindex + 15);
                merchantcode = merchantcode.Remove(merchantcode.IndexOf(",")-1);
                email = response.Substring(emailindex + 8);
                email = email.Remove(email.IndexOf(",")-1);
                role = response.Substring(roleindex + 7);
                role = role.Remove(role.IndexOf(",")-1);
                type = response.Substring(typeindex + 7);
                type = type.Remove(type.IndexOf(",")-1);
                phone = response.Substring(phoneindex + 12);
                phone = phone.Remove(phone.IndexOf(",")-1);


                mycompanyclass.insertdetails(merchantcode, email, role, type, phone, pass);
                confirmdetailsfrm newfrm = new confirmdetailsfrm(mycompanyclass);
                newfrm.ShowDialog();
                //this.Hide();


            }
            else
            {
                MessageBox.Show("Invalid PhoneNumber/Password");
            }
        }
    }
}
