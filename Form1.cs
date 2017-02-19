using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Threading;
using System.Globalization;

namespace NewPOS
{
    public partial class Form1 : Form
    {
        Database1Entities dbe = new Database1Entities();

        BindingList<tblProduct> products = new BindingList<tblProduct>();

        byte[] dataProduct;

        byte[] dataCategory;

        int openingstock = 0, alertthreshold = 0;

        public Form1()
        {
            InitializeComponent();

            lbProductsToBuy.DataSource = products;

            AddButtons();
        }

        private decimal total;

        public decimal Total
        {
            get { return total; }
            set
            {
                total = value;
                var ri = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
                String mycurrency = ri.ISOCurrencySymbol + ". ";
                txtTotal.Text = String.Format("{0:c}" ,total);
            }
        }

        private void AddButtons()
        {
            try
            {
                foreach (tblCategory cat in dbe.tblCategory)
                {
                    Button btn = new Button();
                    btn.Text = cat.CategoryName;
                    btn.Size = new System.Drawing.Size(100, 100);
                    btn.ForeColor = Color.BlueViolet;
                    

                    dataCategory = cat.categoryImage;
                    MemoryStream ms = new MemoryStream(dataCategory);
                    btn.Image = Image.FromStream(ms);
                    btn.Image = ResizeImage(btn.Image, btn.Size);

                    btn.Tag = cat.categoryId;
                    flpCategories.Controls.Add(btn);
                    this.Controls.Add(flpCategories);
                    btn.Click += btn_Click;
                }
            }
            catch 
            {
            }

        }

        private static Image ResizeImage(Image image, Size size)
        {
            Image img = new Bitmap(image, size);

            return img;
        }




        void btn_Click(object sender, EventArgs e)
        {
            try
            {
                List<Control> listControls = flpProducts.Controls.Cast<Control>().ToList();

                foreach (Control control in listControls)
                {
                    flpProducts.Controls.Remove(control);
                    control.Dispose();
                }

                Button b = (Button)sender;

                int categoryID = (int)b.Tag;

                var query = from p in dbe.tblProduct where p.categoryId == categoryID select p;

                var queryList = query.ToList();

                if (query == null)
                {
                    MessageBox.Show("Test");
                }
                else
                {
                    foreach (tblProduct pro in queryList)
                    {
                        Button btn = new Button();
                        btn.Text = pro.productName;
                        btn.Size = new System.Drawing.Size(100, 100);
                        btn.ForeColor = Color.BlueViolet;

                        dataProduct = pro.productImage;
                        MemoryStream ms = new MemoryStream(dataProduct);
                        btn.Image = Image.FromStream(ms);
                        btn.Image = ResizeImage(btn.Image, btn.Size);

                        flpProducts.Controls.Add(btn);
                        this.Controls.Add(flpProducts);
                        btn.Click += btn_Click2;
                        btn.Tag = pro;
                    }
                }
            }
            catch { }
        }

        void btn_Click2(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;

                tblProduct tp = (tblProduct)b.Tag;

                string product = tp.productName;

                txtDisplay.Text = product;

                openingstock = tp.openingstock.GetValueOrDefault();

                alertthreshold = tp.alertthreshold.GetValueOrDefault();

                if (Properties.Settings.Default.Alerts == "Yes")
                {
                    try
                    {
                        if (openingstock <= alertthreshold)
                        {
                            showballon(tp.productName + " is running out, please be sure to restock.        Current Stock: " + openingstock, 1);
                        }
                    }
                    catch (Exception ex) { }
                }

                try
                {
                    if (openingstock <= 0)
                    {
                        MessageBox.Show(tp.productName + " stock is down to zero");
                        //return;
                    }
                }
                catch (Exception ex) { }

                products.Add(tp);

                total += (decimal)tp.productPrice;
                var ri = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
                String mycurrency = ri.ISOCurrencySymbol + ". ";

                txtTotal.Text = String.Format("{0:c}", total);
            }
            catch { }
        }

        private void lbProductsToBuy_Format(object sender, ListControlConvertEventArgs e)
        {
            try
            {
                string ProductName = ((tblProduct)e.ListItem).productName;

                var ri = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
                String mycurrency = ri.ISOCurrencySymbol + ". ";
                string Price = String.Format("{0:c}", ((tblProduct)e.ListItem).productPrice);

                //string Price = mycurrency + ((tblProduct)e.ListItem).productPrice;

                string ProductNamePadded = ProductName.PadRight(45);

                e.Value = ProductNamePadded + Price;
            }
            catch
            {
            }
        }

        private void lbProductsToBuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedItem = lbProductsToBuy.GetItemText(lbProductsToBuy.SelectedItem);
                txtDisplay.Text = selectedItem.Remove(selectedItem.Length - 15);
            }
            catch
            { 
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                tblProduct selected = (tblProduct)(lbProductsToBuy.SelectedItem);

                Total -= (decimal)selected.productPrice;

                products.Remove(selected);
            }
            catch
            {
                MessageBox.Show("Sorry, Your Payment Cart is Empty. Please select a product first!");
            }
        }

        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            ViewProductsForm vpf1 = new ViewProductsForm();

            vpf1.AddButtonsOnClosingViewProductsFormEvent += vpf1_AddButtonsOnClosingViewProductsFormEvent;

            vpf1.Show();
        }

        void vpf1_AddButtonsOnClosingViewProductsFormEvent()
        {
            List<Control> listControls = flpCategories.Controls.Cast<Control>().ToList();

            foreach (Control control in listControls)
            {
                flpCategories.Controls.Remove(control);
                control.Dispose();
            }

            AddButtons();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (Total == 0)
                {
                    MessageBox.Show("Sorry, Your Payment Cart is Empty. Please select a product first!");
                    return;
                }
                PayForm pf1 = new PayForm();

                pf1.AmountToPay = Total;

                pf1.PayedEv += pf1_PayedEv;

                pf1.ShowDialog();

                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        tblProduct selected = (tblProduct)(lbProductsToBuy.SelectedItem);

                        Total -= (decimal)selected.productPrice;

                        products.Remove(selected);
                    }
                    catch
                    {
                        //MessageBox.Show("Nothing to delete !");
                    }
                }
            }
            catch { }
        }

        void pf1_cashlessPayedEv(String myuid)
        {
            tblTransaction transaction = new tblTransaction();
            stockitem mystock = new stockitem();

            transaction.transactionDate = System.DateTime.Now;
            transaction.cashless = "SwypePay";
            transaction.uid = myuid;

            foreach (tblProduct prod in products)
            {
                transaction.tblTransactionItem.Add(new tblTransactionItem() { productId = prod.productId });
                mystock.UpdateStock(prod.productId, 1);
                mystock.SaveStock(prod.productId);
            }

            dbe.tblTransaction.Add(transaction);

            dbe.SaveChanges();

            //MessageBox.Show("Success");

            if (Properties.Settings.Default.Printer == "Yes")
            {
                Print();
            }
            if (Properties.Settings.Default.Printer == "No")
            {
               
            }
            
        }

        void pf1_PayedEv()
        {
            tblTransaction transaction = new tblTransaction();
            stockitem mystock = new stockitem();

            transaction.transactionDate = System.DateTime.Now;
            transaction.cashless = "Cash";
            transaction.uid = "cash";

            foreach (tblProduct prod in products)
            {
                transaction.tblTransactionItem.Add(new tblTransactionItem() { productId = prod.productId });
                mystock.UpdateStock(prod.productId, 1);
                //MessageBox.Show("" + mystock.currentstock);
                mystock.SaveStock(prod.productId);
            }
            
            //MessageBox.Show(""+mystock.currentstock);

            dbe.tblTransaction.Add(transaction);

            dbe.SaveChanges();

            //MessageBox.Show("Success");

            if (Properties.Settings.Default.Printer == "Yes")
            {
                Print();
            }
            if (Properties.Settings.Default.Printer == "No")
            {

            }

        }

        private void Print()
        {
            try
            {
                PrintDialog pDialog = new PrintDialog();

                PrintDocument pDocument = new PrintDocument();

                pDialog.Document = pDocument;

                pDocument.PrintPage += pDocument_PrintPage;

                DialogResult dr = pDialog.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    pDocument.Print();
                }
            }
            catch { }
        }


        void pDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                var ri = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
                String mycurrency = ri.ISOCurrencySymbol + ". ";
                Graphics graph = e.Graphics;

                Font fontWelcome = new Font("Segoe UI", 18);

                Font fontProducts = new Font("Segoe UI", 12);

                SolidBrush sb = new SolidBrush(Color.DarkGray);

                int x = 10;
                int y = 10;
                int spacing = 40;

                graph.DrawString("SwypePay Sale Receipt", fontWelcome, sb, x, y);

                string message = lblHello.Text;

                graph.DrawString(message, fontProducts, sb, x, y + 30);

                foreach (tblProduct pr in products)
                {
                    string product = pr.productName.PadRight(30);
                    string price = String.Format("{0:c}", pr.productPrice);
                    string together = product + price;

                    graph.DrawString(together, fontProducts, sb, x, y + spacing + 30);

                    spacing = spacing + 20;
                }

                spacing = spacing + 20;

                string totalToPay = ("Total:".PadRight(30) + String.Format("{0:c}", Total));

                graph.DrawString(totalToPay, fontProducts, sb, x, y + spacing + 20);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                try
                {
                    tblProduct selected = (tblProduct)(lbProductsToBuy.SelectedItem);

                    Total -= (decimal)selected.productPrice;

                    products.Remove(selected);
                }
                catch
                {
                    //MessageBox.Show("Nothing to delete !");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void swypepaybtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Total == 0)
                {
                    MessageBox.Show("Sorry, Your Payment Cart is Empty. Please select a product first!");
                    return;
                }
                swypepayform pf1 = new swypepayform();
                pf1.AmountToPay = Total;
                pf1.PayedEv += pf1_cashlessPayedEv;
                pf1.ShowDialog();

                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        tblProduct selected = (tblProduct)(lbProductsToBuy.SelectedItem);

                        Total -= (decimal)selected.productPrice;

                        products.Remove(selected);
                    }
                    catch
                    {
                        //MessageBox.Show("Nothing to delete !");
                    }
                }

            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void systemSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewProductsForm vpf1 = new ViewProductsForm();

            vpf1.AddButtonsOnClosingViewProductsFormEvent += vpf1_AddButtonsOnClosingViewProductsFormEvent;

            vpf1.Show();
        }

        private void salesReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            summarytxns pf1 = new summarytxns();
            pf1.Show();
        }

        private void summary2_Click(object sender, EventArgs e)
        {
            summarytxns pf1 = new summarytxns();
            pf1.Show();
        }

        private void taxationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tax manager
            

        }

        private void showballon(string text, int length)
        {
            var notification = new System.Windows.Forms.NotifyIcon()
            {
                Visible = true,
                Icon = System.Drawing.SystemIcons.Information,
                // optional - BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info,
                BalloonTipTitle = "Product Alert",
                BalloonTipText = text,
            };

            // Display for 5 seconds.
            notification.ShowBalloonTip(length);

            // This will let the balloon close after it's 5 second timeout
            // for demonstration purposes. Comment this out to see what happens
            // when dispose is called while a balloon is still visible.
            Thread.Sleep(10000);

            // The notification should be disposed when you don't need it anymore,
            // but doing so will immediately close the balloon if it's visible.
            notification.Dispose();
        }
        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void flpProducts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void stockReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stockreporttxns vpf1 = new stockreporttxns();

            //vpf1.AddButtonsOnClosingViewProductsFormEvent += vpf1_AddButtonsOnClosingViewProductsFormEvent;

            vpf1.Show();
        }

        private void salesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            summarytxns pf1 = new summarytxns();
            pf1.Show();
        }

        private void systemSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void companyDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.swypepay.co.ke");
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
        private void adminSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string pass = ".";
            ShowInputDialog(ref pass, "password", "Admin Password Input");
            if (pass == "terra")
            {
                MessageBox.Show("Successfully Logged In");

                Adminsettings f1 = new Adminsettings();

                f1.Show();


                return;
            }
        }

        private void lbProductsToBuy_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void alertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pass = ".";
            ShowInputDialog(ref pass, "password", "Admin Password Input");
            if (pass == "terra")
            {
                alerts f1 = new alerts();
                f1.Show();

                return;
            }
            
        }
    }
}
