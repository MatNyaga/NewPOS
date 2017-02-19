using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPOS
{
    public partial class stockreporttxns : Form
    {
        Database1Entities dbe = new Database1Entities();
        DataTable stock = new DataTable();
        DataTable products = new DataTable();
        DataTable transactions = new DataTable();
        DataTable transactionIDs = new DataTable();
        summaryreportTableAdapters.tblTransactionItemTableAdapter transactionstableadapter = new summaryreportTableAdapters.tblTransactionItemTableAdapter();
        summaryreportTableAdapters.tblTransactionTableAdapter transactionproducttableadapter = new summaryreportTableAdapters.tblTransactionTableAdapter();

        public stockreporttxns()
        {
            InitializeComponent();
            transactions = transactionproducttableadapter.GetData();
            products = tblProductTableAdapter.GetData();
            transactionIDs = transactionstableadapter.GetData();
        }

        private void filter_Click(object sender, EventArgs e)
        {
            stock = transactionstableadapter.stockreportDT(productname.Text);
            products = tblProductTableAdapter.GetData();
            
            foreach (DataRow dr in products.Rows)
            {
                if (dr[1].ToString() == productname.Text)
                {
                    openingstcklbl.Text = dr[5].ToString() + " pcs";
                    availablestock.Text = dr[7].ToString() + " pcs";
                }
            }

            label1.Text = stock.Rows.Count.ToString();
            dataGridView1.DataSource = stock;
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[2].Visible = false;
            this.dataGridView1.Columns[3].Visible = false;

        }

        private void stockreporttxns_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'summaryreport.tblProduct' table. You can move, or remove it, as needed.
            this.tblProductTableAdapter.Fill(this.summaryreport.tblProduct);
        }

        public void ExportToPdf(DataTable dt, string path, string productname)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path + "\\Swype Pay stock report.pdf", FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10);

            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[] { 4f, 4f, 4f, 4f, 4f, 4f, 4f };
            table.SetTotalWidth(widths);
            table.WidthPercentage = 100;
            int iCol = 0;
            string colname = "";
            PdfPCell cell = new PdfPCell(new Phrase("Products"));
            cell.Colspan = dt.Columns.Count;
            var map = new Dictionary<string, string>();
            map.Add("transactionItemId", "Product Name");
            map.Add("transactionId", "Reference ID");
            map.Add("productName", productname);
            map.Add("productId", "Transaction ID");
            map.Add("openingstock", "Opening Stock");
            map.Add("amountsold", "Amount Sold");

            foreach (DataColumn c in dt.Columns)
            {
                try
                {
                    table.AddCell(new Phrase(map[c.ColumnName], font5));
                }
                catch (Exception notmapped) { table.AddCell(new Phrase(c.ColumnName, font5)); }
            }

            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    table.AddCell(new Phrase(r[0].ToString(), font5));
                    table.AddCell(new Phrase(r[1].ToString(), font5));
                    table.AddCell(new Phrase(r[2].ToString(), font5));
                    table.AddCell(new Phrase(r[3].ToString(), font5));
                    table.AddCell(new Phrase(r[4].ToString(), font5));
                }
            }
            document.Add(table);
            document.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void printSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pdfexport_Click(object sender, EventArgs e)
        {
            try
            {
                XLWorkbook wb = new XLWorkbook();
                transactions.Columns.Add("Gender");
                transactions.Columns.Add("PNumber");
                foreach (DataRow dr in transactions.Rows)
                {
                    if (dr["cashless"].ToString().Trim() == "cash")
                        dr["PNumber"] = "N/A";
                }
                wb.Worksheets.Add(transactions, "Transactions");
                wb.Worksheets.Add(products, "Products");
                wb.Worksheets.Add(transactionIDs, "Transaction IDs");
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.ShowNewFolderButton = true;
                folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string foldername = folderBrowserDialog.SelectedPath;
                    //
                    wb.SaveAs(foldername + "\\StockReport.xlsx");
                    MessageBox.Show(this, "Excel Sheet exported to: " + foldername + " successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception io) {
                MessageBox.Show(io.Message);
            }
            

        }

        private void asPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stock = transactionstableadapter.stockreportDT(productname.Text);
            //stock.Columns.Remove("userId");
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string foldername = folderBrowserDialog.SelectedPath;
                //
                ExportToPdf(stock, foldername, productname.Text);
                MessageBox.Show(this, "Report exported to: " + foldername + " successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
