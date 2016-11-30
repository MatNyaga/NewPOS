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
    public partial class confirmdetailsfrm : Form
    {
        companydetailsclass companytosave = new companydetailsclass();
        public confirmdetailsfrm(companydetailsclass mycompany)
        {
            InitializeComponent();
            companytosave = mycompany;
        }

        private void confirmdetailsfrm_Load(object sender, EventArgs e)
        {
            label2.Text = companytosave.merchantcode;
            label4.Text = companytosave.email;
            label6.Text = companytosave.role;
            label8.Text = companytosave.type;
            label10.Text = companytosave.phone;
        }

        private void save_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Do you wish to Save these Details?", "Confirm Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                companytosave.savedetails();
                companytosave.DefaultUser();
                MessageBox.Show(this,"Default User Created","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
