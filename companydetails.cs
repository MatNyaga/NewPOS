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
    public partial class companydetails : Form
    {
        DataTable mycompany = new DataTable();
        summaryreportTableAdapters.tblCompanyDetailsTableAdapter summarytableadapter = new summaryreportTableAdapters.tblCompanyDetailsTableAdapter();
        public companydetails()
        {
            InitializeComponent();
        }

        private void companydetails_Load(object sender, EventArgs e)
        {
            mycompany = summarytableadapter.GetData();
            try
            {
                var stringArr = mycompany.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
                companyname.Text = stringArr[1];
                email.Text = stringArr[2];
                TaxPin.Text = stringArr[3];
                Address.Text = stringArr[4];
                phonenumber.Text = stringArr[5];
                Logo.Text = stringArr[6];
                country.Text = stringArr[7];
                swypecode.Text = stringArr[8];
            }
            catch (Exception ioe){}
            
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            summarytableadapter.InsertCompanyDetails(companyname.Text, email.Text, TaxPin.Text, Address.Text, phonenumber.Text, Logo.Text, country.Text, swypecode.Text);
            MessageBox.Show("Company Details Inserted Successfully");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            companyname.ReadOnly = false;
            email.ReadOnly = false;
            TaxPin.ReadOnly = false;
            Address.ReadOnly = false;
            Logo.ReadOnly = false;
            country.ReadOnly = false;
            swypecode.ReadOnly = false;
        }

        private void search_Click(object sender, EventArgs e)
        {
            //search phone bumber
        }

        private void button2_Click(object sender, EventArgs e)
        {
            companyname.ReadOnly = false;
            email.ReadOnly = false;
            TaxPin.ReadOnly = false;
            Address.ReadOnly = false;
            Logo.ReadOnly = false;
            country.ReadOnly = false;
            swypecode.ReadOnly = false;
            companyname.Text = "";
            email.Text = "";
            TaxPin.Text = "";
            Address.Text = "";
            Logo.Text = "";
            country.Text = "";
            swypecode.Text = "";
        }
    }
}
