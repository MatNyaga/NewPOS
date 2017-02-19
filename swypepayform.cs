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
using Acs;

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
        Acr1222L acr1222SmartCardReader = new Acr1222L();
        DataTable mycompany = new DataTable();
        summaryreportTableAdapters.tblCompanyDetailsTableAdapter summarytableadapter = new summaryreportTableAdapters.tblCompanyDetailsTableAdapter();
        

        Database1Entities dbe = new Database1Entities();

        public delegate void PayedEvent(String uid);

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
        private string SubstringIx(string value, int startIndex, int endIndex)
        {
            if (value == null) throw new ArgumentNullException();
            if (endIndex > value.Length) throw new IndexOutOfRangeException("End index must be less than or equal to the length of the string.");
            if (startIndex < 0 || startIndex > value.Length + 1) throw new IndexOutOfRangeException("Start index must be between zero and the length of the string minus one");
            if (startIndex >= endIndex) throw new ArgumentOutOfRangeException("Start index must be less then end index");

            var length = endIndex - startIndex;
            return value.Substring(startIndex, length);
        }



        public async void StartPoll(object sender, DoWorkEventArgs e)
        {/*
            using (var context = contextFactory.Establish(SCardScope.System))
            {

                var readerNames = context.GetReaders();
                if (NoReaderFound(readerNames))
                {
                    label1.Text = ("You need at least one reader in order to run this example.");
                    return;
                }

                var readerName = ChooseRfidReader(readerNames);
                if (readerName == null)
                {
                    return;
                }

                // 'using' statement to make sure the reader will be disposed (disconnected) on exit
                using (var rfidReader = new SCardReader(context))
                {
                    var sc = rfidReader.Connect(readerName, SCardShareMode.Shared, SCardProtocol.Any);
                    if (sc != SCardError.Success)
                    {
                        label1.Text = ("Could not connect to reader {0}:\n{1}" + readerName + SCardHelper.StringifyError(sc));
                        return;
                    }

                    var apdu = new CommandApdu(IsoCase.Case2Short, rfidReader.ActiveProtocol)
                    {
                        CLA = 0xFF,
                        Instruction = InstructionCode.GetData,
                        P1 = 0x00,
                        P2 = 0x00,
                        Le = 0 // We don't know the ID tag size
                    };

                    sc = rfidReader.BeginTransaction();
                    if (sc != SCardError.Success)
                    {
                        label1.Text = ("Could not begin transaction.");
                        return;
                    }

                    label1.Text = ("Retrieving the UID .... ");

                    var receivePci = new SCardPCI(); // IO returned protocol control information.
                    var sendPci = SCardPCI.GetPci(rfidReader.ActiveProtocol);

                    var receiveBuffer = new byte[256];
                    var command = apdu.ToArray();

                    sc = rfidReader.Transmit(
                        sendPci, // Protocol Control Information (T0, T1 or Raw)
                        command, // command APDU
                        receivePci, // returning Protocol Control Information
                        ref receiveBuffer); // data buffer

                    if (sc != SCardError.Success)
                    {
                        label1.Text = ("Error: " + SCardHelper.StringifyError(sc));
                    }

                    var responseApdu = new ResponseApdu(receiveBuffer, IsoCase.Case2Short, rfidReader.ActiveProtocol);
                    label1.Text = ("SW1: {0:X2}, SW2: {1:X2}\nUid: {2}" + responseApdu.SW1 + responseApdu.SW2);

                    if (responseApdu.HasData)
                    {
                        label2.Text = BitConverter.ToString(responseApdu.GetData());
                    }
                    else
                    {
                        label2.Text = "No uid received";
                    }
                    rfidReader.EndTransaction(SCardReaderDisposition.Leave);
                    rfidReader.Disconnect(SCardReaderDisposition.Reset);

                }

            }
            */

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
                nfcreader1.stopPoll();

                if (cardid.Text == UID) {

                    if (myListOfReaders[0].Contains("ACR1222"))
                    {
                        acr1222lreader(true, Properties.Settings.Default.LCD2_1, " ", "blue");
                    }
                   
                    
                    
                }
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

        private async void swypepayform_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'summaryreport.tblCompanyDetails' table. You can move, or remove it, as needed.
            this.tblCompanyDetailsTableAdapter.Fill(this.summaryreport.tblCompanyDetails);
            // TODO: This line of code loads data into the 'summaryreport.tblUsers' table. You can move, or remove it, as needed.
            this.tblUsersTableAdapter.Fill(this.summaryreport.tblUsers);
            string uid = string.Empty;
            payamnt.Text = String.Format("{0:c} ", amountToPay);
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
            if (myListOfReaders[0].Contains("ACR1222"))
            {
            acr1222lreader(true, Properties.Settings.Default.LCD2_2, "   "+payamnt.Text,"none");
            await Task.Delay(2000);
            //Timer timer = new Timer(new TimerCallback(timerCb), null, 1000, 0);
            acr1222lreader(true, Properties.Settings.Default.LCD3_1, Properties.Settings.Default.LCD3_2, "none");
            }
            
            
            
            mytimer.Enabled = true;
            mytimer.Interval = 2000;
            mytimer.Tick += new EventHandler(Mytimer_Tick);
            
        }
        /*
        private void timerCb(object state)
        {
            Dispatcher.Invoke(() =>
            {
                label1.Content = "Foo!";
            });
        }
        */
        private void acr1222lreader (Boolean Backlight, string firstlinemessage, string secondlinemessage, string led)
        { 
            try
            {
                string Reader = myListOfReaders[0];
                acr1222SmartCardReader.readerName = Reader;
                acr1222SmartCardReader.connectDirect();
                if (Backlight)
                {
                    acr1222SmartCardReader.backlight(true);
                }
                else
                {
                    acr1222SmartCardReader.backlight(false);
                }
                //MessageBox.Show( acr1222SmartCardReader.getTagUID());
                //text on screen
                acr1222SmartCardReader.clearLcd();
                LedStatus myled = new LedStatus();
                LcdDisplayParameter parameter = new LcdDisplayParameter();

                if (led == "none")
                {
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off, LedStateSwitch.Off);

                }
                if (led == "blue")
                {
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off, LedStateSwitch.Off);
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off);
                }
                if (led == "orange")
                {
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.On, LedStateSwitch.Off);
                }
                if (led == "red")
                {
                    acr1222SmartCardReader.ledControl(LedStateSwitch.On, LedStateSwitch.Off, LedStateSwitch.Off, LedStateSwitch.On);
                }
                parameter.message = firstlinemessage;
                //parameter.boldFont = CheckBoxBoldFont.Checked;
                parameter.positionLineNumber = (byte)(0 + 1);
                parameter.positionOffset = (byte)(0);
                parameter.fontSet = FontSet.SetA;
                acr1222SmartCardReader.displayLcd(parameter);

                parameter.message = secondlinemessage;
                //parameter.boldFont = CheckBoxBoldFont.Checked;
                parameter.positionLineNumber = (byte)(0 + 2);
                parameter.positionOffset = (byte)(0);
                parameter.fontSet = FontSet.SetA;
                acr1222SmartCardReader.displayLcd(parameter);
                acr1222SmartCardReader.disconnect();
            }

            catch (PcscException acr1222Ex)
            {
                //showPcscException(acr1222Ex.Message);
            }
            catch (Exception ex)
            {
                //showSystemException(ex.Message);
            }
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
        public String errormessagesline1(string input)
        {
            if (input.Contains("ERROR_CARD_INACTIVE"))
            {
                return "PAYMENT DECLINED"; 
            }
            if (input.Contains("ERROR_INSUFFICIENT_BALANCE"))
            {
                return "Balance Too Low";
            }
            if (input.Contains("ERROR_CUSTOMER_ACCOUNT_NONEXISTENT"))
            {
                return "NO CUSTOMER";
            }
            if (input.Contains("SUCCESS"))
            {
                return "PAYMENT COMPLETE";
            }
            if (input.Contains("ERROR_WRONG_PASSWORD"))
            {
                return "WRONG PIN";
            }

            return "ERROR";
        }

        public String errormessagesline2(string input)
        {
            if (input.Contains("ERROR_CARD_INACTIVE"))
            {
                return "INACTIVE CARD";
            }
            if (input.Contains("ERROR_INSUFFICIENT_BALANCE"))
            {
                int balindex = input.IndexOf("balance") + 9;
                //String amnttemp = responseString.Substring(balindex + 8);
                int amountindex = input.IndexOf("amount") - 2;
                cardbalance = SubstringIx(input, balindex, amountindex);
                return "Bal: "+ String.Format("{0:c}", Convert.ToDecimal(cardbalance));
            }

            if (input.Contains("SUCCESS"))
            {
                int balindex = input.IndexOf("balance") + 9;
                //String amnttemp = responseString.Substring(balindex + 8);
                int amountindex = input.IndexOf("idMerchant") - 2;
                cardbalance = SubstringIx(input, balindex, amountindex);
                return "Bal: " + String.Format("{0:c}", Convert.ToDecimal(cardbalance));
            }

            return "    ERROR";
        }
        private async void btnOk_Click(object sender, EventArgs e)
        {
            var responseString = "";
            try
            {   
                statuslabl.Text = "Processing...";
                btnOk.Enabled = false;
                
                if (txtPaymentAmount.Text == "")
                {
                    if (Properties.Settings.Default.Live == "Yes")
                    {
                        responseString = await Properties.Settings.Default.checkcardbalancewopasswordLive.PostUrlEncodedAsync(new { carduid = UID }).ReceiveString();
                    }
                    else
                    {
                        responseString = await Properties.Settings.Default.checkcardbalancewopassword.PostUrlEncodedAsync(new { carduid = UID }).ReceiveString();
                    }
                    int index = responseString.IndexOf("telephone");
                    int balindex = responseString.IndexOf("amount");
                    String Temp = responseString.Substring(index + 12);
                    int tempindex = Temp.IndexOf("amount");
                    telephonenumber = Temp.Remove(tempindex - 3);
                    String amnttemp = responseString.Substring(balindex + 8);
                    cardbalance = amnttemp.Remove(amnttemp.Length - 1);

                    if (Properties.Settings.Default.Live == "Yes")
                    {
                        responseString = await Properties.Settings.Default.checkcardbalancewopasswordLive.PostUrlEncodedAsync(new { phone = telephonenumber, amount = amountToPay, transactiontype = "iscard", paytophone = stringArr[8] }).ReceiveString();
                    }
                    else
                    {
                        responseString = await Properties.Settings.Default.checkoutwopassword.PostUrlEncodedAsync(new { phone = telephonenumber, amount = amountToPay, transactiontype = "iscard", paytophone = stringArr[8] }).ReceiveString();
                    }
                    if (myListOfReaders[0].Contains("ACR1222"))
                    {

                        acr1222lreader(true, errormessagesline1(responseString), Properties.Settings.Default.LCD1_2 + " " + String.Format("{0:c}", Convert.ToDecimal(cardbalance)), "orange");
                    
                    }
                    
                    //acr1222lreader(true, "Balance : "+cardbalance," ");
                    
                    //acr1222lreader(true, errormessagesline1(responseString), "Bal : " + (String.Format("{0:c}", cardbalance)));
                }
                else
                {
                    if (Properties.Settings.Default.Live == "Yes")
                    {
                        responseString = await Properties.Settings.Default.cardcheckoutLive.PostUrlEncodedAsync(new { paytophone = stringArr[8], amount = amountToPay, password = txtPaymentAmount.Text, transactiontype = "iscard", carduid = UID }).ReceiveString();
                    }
                    else
                    {
                        responseString = await Properties.Settings.Default.cardcheckout.PostUrlEncodedAsync(new { paytophone = stringArr[8], amount = amountToPay, password = txtPaymentAmount.Text, transactiontype = "iscard", carduid = UID }).ReceiveString();
                    }
                    //idMerchant
                    int balindex = responseString.IndexOf("balance") + 9;
                    //String amnttemp = responseString.Substring(balindex + 8);
                    int amountindex = responseString.IndexOf("idMerchant") - 2;
                    cardbalance = SubstringIx(responseString, balindex, amountindex);
                    if (myListOfReaders[0].Contains("ACR1222"))
                    {

                        acr1222lreader(true, errormessagesline1(responseString), Properties.Settings.Default.LCD1_2+" " + (String.Format("{0:c}", Convert.ToDecimal( cardbalance))),"orange");
                    
                    }
                    
                    
                }

                if (responseString.Contains("ERROR"))
                {
                    statuslabl.Text = responseString;
                    return;
                }
                PayedEv(UID);

                statuslabl.Text = "TRANSACTION SUCCESSFUL";
                cardid.Text = "Card ID";
                MessageBox.Show("TRANSACTION SUCCESSFUL");
                
                    acr1222lreader(false, Properties.Settings.Default.LCD1_1, " ", "none");
                
                
                mytimer.Stop();
                this.Close();     //"Cannot connect to the server...."           
            }
            catch (Exception ex) { statuslabl.Text = responseString;
                if (myListOfReaders[0].Contains("ACR1222"))
                {

                    acr1222lreader(true, errormessagesline1(responseString), errormessagesline2(responseString),"red");
                
                }
                
                
                cardid.Text = "Card ID"; }
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

        private void swypepayform_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                mytimer.Stop();
            }
            catch (Exception ioe) { }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            swypepayform pf1 = new swypepayform();
            pf1.AmountToPay = AmountToPay;
            pf1.PayedEv += PayedEv;
            
            pf1.ShowDialog();
            this.Close();

        }

        private void swypepayform_FormClosed(object sender, FormClosedEventArgs e)
        {
            mytimer.Stop();

            if (myListOfReaders[0].Contains("ACR1222"))
            {

                acr1222lreader(false, "Welcome to Swype", " ", "none");
            }
            
            
        }

        private async void VoucherBtn_Click(object sender, EventArgs e)
        {
            try
            {
                statuslabl.Text = "Processing...";
                VoucherBtn.Enabled = false;
                var responseString = "";
                   
                    if (Properties.Settings.Default.Live == "Yes")
                    {
                        responseString = await Properties.Settings.Default.VoucherLive.PostUrlEncodedAsync(new { phone = telephonenumber, amount = amountToPay, id = txtPaymentAmount.Text, merchant = stringArr[8] }).ReceiveString();
                    }
                    else
                    {
                        responseString = await Properties.Settings.Default.Voucher.PostUrlEncodedAsync(new { phone = telephonenumber, amount = amountToPay, id = txtPaymentAmount.Text, merchant = stringArr[8] }).ReceiveString();
                    }
                
                    //statuslabl.Text = responseString;
                
                if (responseString.Contains("ERROR"))
                {
                    statuslabl.Text = responseString;
                    return;
                }
                PayedEv("Voucher");
                statuslabl.Text = "TRANSACTION SUCCESSFUL";
                MessageBox.Show("TRANSACTION SUCCESSFUL");

                mytimer.Stop();

                if (myListOfReaders[0].Contains("ACR1222"))
                {
                    acr1222lreader(false, "Welcome to Swype", " ", "none");
                }
                
                
                
                this.Close();
                //"Cannot connect to the server...."
            }
            catch (Exception ex) { statuslabl.Text = ex.Message; cardid.Text = "Card ID"; }
        }

        private void cardid_Click(object sender, EventArgs e)
        {

        }
    }
}
