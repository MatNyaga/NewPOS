using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using usbNfcReader;
using Flurl.Http;

namespace NewPOS
{
    public partial class swypepayform : Form
    {
        public usbNfcReader.nfcReader nfcreader1 = new usbNfcReader.nfcReader();
        public List<string> myListOfReaders;
        BackgroundWorker myPollThread = new BackgroundWorker();
        public string UID = string.Empty;
        public string telephonenumber = string.Empty;
        public string cardbalance = string.Empty;
        string merchantcode = string.Empty;
        string[] stringArr;
        int cashlesslimit = 0;
        int crdbalance = 0;
        Boolean pass = true;
        DataTable mycompany = new DataTable();
        summaryreportTableAdapters.tblCompanyDetailsTableAdapter summarytableadapter = new summaryreportTableAdapters.tblCompanyDetailsTableAdapter();
        

        Database1Entities dbe = new Database1Entities();

        public delegate void PayedEvent();

        public event PayedEvent PayedEv;

        Timer mytimer = new Timer();
        private decimal amountToPay;
        public decimal AmountToPay
        {
            get { return amountToPay; }
            set
            {
                amountToPay = value;
            }
        }



        public async void StartPoll(object sender, DoWorkEventArgs e)
        {
            if (myListOfReaders.Count <= 0) return;

            string Reader = myListOfReaders[0];
            nfcreader1.connect(myListOfReaders[0]);

            try
            {
                string uid = string.Empty;
                while (true)
                {
                    uid = nfcreader1.getData(false).ToString();
                    uid = uid.Replace(" ", "");
                    uid = nfcreader1.getData(false).ToString();
                    uid = uid.Replace(" ", "");

                    if (uid.Length == 1)
                    {
                        nfcreader1.connect(myListOfReaders[0]);
                    }
                    else
                        e.Result = uid;
                    if (uid.Equals("1"))
                    {
                        return;
                    }
                    else
                    {
                        cardid.Text = uid;
                    }
                    
                    return;
                }


            }

            catch (Exception ex)
            {}
        }
        public void TaskCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                if (e.Result == null) goto Run;

                UID = e.Result.ToString();
                cardid.Text = UID;

                Run: myPollThread.RunWorkerAsync();


            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error " + ex.Message);
            }

        }


        public swypepayform()
        {
            InitializeComponent();
            mycompany = summarytableadapter.GetData();
            try
            {
                stringArr = mycompany.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
                cashlesslimit = Convert.ToInt32(stringArr[10]);
                int amounttopay = Convert.ToInt32(txtPaymentAmount.Text);
                if (AmountToPay < cashlesslimit)
                {
                    MessageBox.Show(pass.ToString());
                    pass = false;
                    label1.Visible = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    button5.Visible = false;
                    button6.Visible = false;
                    button7.Visible = false;
                    button8.Visible = false;
                    button9.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    button13.Visible = false;
                    btnOk.Visible = false;
                }
            }
            catch (Exception ioe) { }
        }

        private void swypepayform_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'summaryreport.tblCompanyDetails' table. You can move, or remove it, as needed.
            this.tblCompanyDetailsTableAdapter.Fill(this.summaryreport.tblCompanyDetails);
            // TODO: This line of code loads data into the 'summaryreport.tblUsers' table. You can move, or remove it, as needed.
            this.tblUsersTableAdapter.Fill(this.summaryreport.tblUsers);
            string uid = string.Empty;
            merchantcode = merchantcodecombo.Text;
            try
            {
                stringArr = mycompany.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
                cashlesslimit = Convert.ToInt32(stringArr[10]);
                if (AmountToPay < cashlesslimit)
                {
                    pass = false;
                }
            }
            catch (Exception io) { }
            nfcreader1.initialize();
            myListOfReaders = nfcreader1.getFoundReaders();
            myPollThread.RunWorkerAsync();

            myPollThread.DoWork += new DoWorkEventHandler(StartPoll);
            myPollThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TaskCompleted);

            mytimer.Enabled = true;
            mytimer.Interval = 2000;
            mytimer.Tick += new EventHandler(Mytimer_Tick);

            
        }

        private async void Mytimer_Tick(object sender, EventArgs e)
        {
            if (cardid.Text != "Card ID" && pass == true)
            {
                //BackgroundImage = System.Drawing.Image.FromFile("");
                label1.Text = "Enter SwypePay 4 digit PIN";
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                button9.Visible = true;
                button10.Visible = true;
                button11.Visible = true;
                button13.Visible = true;
                btnOk.Visible = true;
                txtPaymentAmount.Visible = true;
                txtPaymentAmount.Focus();
            }
            if (cardid.Text != "Card ID" && pass == false)
            {
                //BackgroundImage = System.Drawing.Image.FromFile("");
                label1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button13.Visible = false;
                btnOk.Visible = true;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            try
            {
                txtPaymentAmount.Text = txtPaymentAmount.Text.Substring(0, txtPaymentAmount.Text.Length - 1);
            }
            catch (Exception io) { }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtPaymentAmount.Text = "";
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            try
            {   
                statuslabl.Text = "Processing...";
                btnOk.Enabled = false;
                var responseString = "";
                if (txtPaymentAmount.Text == "")
                {
                    responseString = await "http://swypepay.co.ke/sandbox/frontend/web/index.php?r=user-profile/check-card-balance-without-password".PostUrlEncodedAsync(new { carduid = UID }).ReceiveString();
                    int index = responseString.IndexOf("telephone");
                    int balindex = responseString.IndexOf("amount");
                    String Temp = responseString.Substring(index + 12);
                    int tempindex = Temp.IndexOf("amount");
                    telephonenumber = Temp.Remove(tempindex - 3);
                    String amnttemp = responseString.Substring(balindex + 8);
                    cardbalance = amnttemp.Remove(amnttemp.Length - 1);
                    responseString = await "http://swypepay.co.ke/sandbox/frontend/web/index.php?r=user-profile/check-out-without-password".PostUrlEncodedAsync(new { phone = telephonenumber, amount = amountToPay, transactiontype = "iscard", paytophone = "QUI647" }).ReceiveString();

                    statuslabl.Text = responseString;
                }
                else {
                    responseString = await "http://swypepay.co.ke/sandbox/frontend/web/index.php?r=user-profile/card-check-out".PostUrlEncodedAsync(new { paytophone = stringArr[8], amount = amountToPay, password = txtPaymentAmount.Text, transactiontype = "iscard", carduid = UID }).ReceiveString();
                }
                    if (responseString.Contains("ERROR"))
                {
                    statuslabl.Text = responseString;
                    return;
                }
                PayedEv();
                statuslabl.Text = "TRANSACTION SUCCESSFUL";
                cardid.Text = "Card ID";
                MessageBox.Show("TRANSACTION SUCCESSFUL");
                
                mytimer.Stop();
                
                
            }
            catch (Exception ex) { statuslabl.Text = "Cannot connect to the server...."; cardid.Text = "Card ID"; }
        }

        private async void nyagauid_Click(object sender, EventArgs e)
        {
            UID = "D44A8BD0";
            txtPaymentAmount.Text = "";

                statuslabl.Text = "Processing...";
                btnOk.Enabled = false;
                String responseString = "";
                var list ="";
                if (txtPaymentAmount.Text == "")
                {
                
                    list = await "http://swypepay.co.ke/sandbox/frontend/web/index.php?r=user-profile/check-card-balance-without-password".PostUrlEncodedAsync(new { carduid = UID }).ReceiveString();
                    int index = list.IndexOf("telephone");
                    int balindex = list.IndexOf("amount");
                String Temp = list.Substring(index + 12);
                int tempindex = Temp.IndexOf("amount");
                telephonenumber = Temp.Remove(tempindex-3);
                String amnttemp = list.Substring(balindex + 8);
                cardbalance = amnttemp.Remove(amnttemp.Length - 1);


                //list = await "http://swypepay.co.ke/sandbox/frontend/web/index.php?r=user-profile/check-out-without-password".PostUrlEncodedAsync(new { phone = telephonenumber, amount = amountToPay, transactiontype = "iscard", paytophone = stringArr[8] }).ReceiveString();
                list = await "http://swypepay.co.ke/sandbox/frontend/web/index.php?r=user-profile/check-out-without-password".PostUrlEncodedAsync(new { phone = telephonenumber, amount = amountToPay, transactiontype = "iscard", paytophone = "QUI647" }).ReceiveString();

                statuslabl.Text = list;
                    
                
                //responseString = await "http://swypepay.co.ke/sandbox/frontend/web/index.php?r=user-profile/card-check-out".PostUrlEncodedAsync(new { paytophone = stringArr[8], amount = amountToPay, password = "", transactiontype = "iscard", carduid = UID }).ReceiveString();
                //statuslabl.Text = responseString;
            }/*
                else
                {
                    responseString = await "http://swypepay.co.ke/sandbox/frontend/web/index.php?r=user-profile/card-check-out".PostUrlEncodedAsync(new { paytophone = stringArr[8], amount = amountToPay, password = txtPaymentAmount.Text, transactiontype = "iscard", carduid = UID }).ReceiveString();
                }
                if (responseString.Contains("ERROR"))
                {
                    statuslabl.Text = responseString;
                    return;
                }
                PayedEv();
                statuslabl.Text = "TRANSACTION SUCCESSFUL";
                cardid.Text = "Card ID";
                MessageBox.Show("TRANSACTION SUCCESSFUL");
                
                mytimer.Stop();
                if (statuslabl.Text == "TRANSACTION SUCCESSFUL")
                {
                    this.Close();
                    return;
                }*/
           }
    }
}
