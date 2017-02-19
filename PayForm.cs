using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPOS
{
    public partial class PayForm : Form
    {
        Database1Entities dbe = new Database1Entities();

        public delegate void PayedEvent();

        public event PayedEvent PayedEv;
        String mycurrency;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= 0x08000000;
                return param;
            }
        }
        public PayForm()
        {
            InitializeComponent();
        }

        private decimal amountToPay;
        public decimal AmountToPay
        {
            get { return amountToPay; }
            set
            {
                amountToPay = value;
                txtAmountToPay.Text = amountToPay.ToString();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPaymentAmount.Text == "")
                {
                    MessageBox.Show("Fill out the given amount");
                    return;
                }
                decimal total = 0;
                string RemovedCurrency = (txtAmountToPay.Text).Remove(txtAmountToPay.Text.Length - 3);
                total = decimal.Parse(RemovedCurrency) - decimal.Parse(txtPaymentAmount.Text);

                if (-total < 0)
                {
                    MessageBox.Show("Insufficient amount");
                    this.Close();
                    //return;
                }

                if (total > 0)
                {
                    txtAmountToPay.Text = total.ToString();
                }
                else
                {
                    var ri = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
                    mycurrency = ri.ISOCurrencySymbol + ". ";
                    label2.Text = String.Format("{0:c}", -total);
                    btnOk.Enabled = false;
                    MessageBox.Show("Transaction Sucessful");
                    PayedEv();
                    this.Close();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void PayForm_Load(object sender, EventArgs e)
        {
            var ri = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
            mycurrency = ri.ISOCurrencySymbol + ". ";
            //label2.Text = String.Format("{0:c}",".");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPaymentAmount.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPaymentAmount.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPaymentAmount.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtPaymentAmount.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPaymentAmount.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtPaymentAmount.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtPaymentAmount.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtPaymentAmount.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtPaymentAmount.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtPaymentAmount.Text += "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtPaymentAmount.Text = txtPaymentAmount.Text.Substring(0, txtPaymentAmount.Text.Length - 1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtPaymentAmount.Text = "";
        }

        private void PayForm_Shown(object sender, EventArgs e)
        {
            txtPaymentAmount.Focus();
        }

        private void lblAmountToPay_Click(object sender, EventArgs e)
        {

        }

        private void lblPaymentAmount_Click(object sender, EventArgs e)
        {

        }
    }
    
}
