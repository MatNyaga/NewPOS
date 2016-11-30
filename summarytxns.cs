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
    public partial class summarytxns : Form
    {
        DataTable mydata = new DataTable();
        DataTable cash = new DataTable();
        DataTable cashless = new DataTable();
        DataTable total = new DataTable();
        DataTable sumdata = new DataTable();
        summaryreportTableAdapters.tblCategoryTableAdapter summarytableadapter = new summaryreportTableAdapters.tblCategoryTableAdapter();
        summaryreportTableAdapters.tblTransactionTableAdapter transactionstableadapter = new summaryreportTableAdapters.tblTransactionTableAdapter();

        public summarytxns()
        {
            InitializeComponent();
        }

        private void summarytxns_Load(object sender, EventArgs e)
        {
            mydata = summarytableadapter.FullSummaryDT();
            sumdata = summarytableadapter.sumtotalDT();
            cash = transactionstableadapter.cashDT();
            cashless = transactionstableadapter.cashlessDT();
            total = transactionstableadapter.totalDT();
            dataGridView1.DataSource = mydata;
            object sum = sumdata.Rows[0][3];
            button1.Text = sum.ToString();
            button2.Text = total.Rows.Count.ToString();
            button3.Text = cash.Rows.Count.ToString();
            button4.Text = cashless.Rows.Count.ToString();
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[2].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sumdata = summarytableadapter.sumtotalDT();
            dataGridView1.DataSource = mydata;
            object sum = sumdata.Rows[0][3];
            button1.Text = sum.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void ExportToPdf(DataTable dt, string path)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path + "\\Swype Pay General Transactions Report.pdf", FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10);
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[] { 4f, 4f, 4f, 4f, 4f, 4f,4f , 4f };
            table.SetTotalWidth(widths);
            table.WidthPercentage = 100;
            int iCol = 0;
            string colname = "";
            PdfPCell cell = new PdfPCell(new Phrase("Products"));
            cell.Colspan = dt.Columns.Count;
            var map = new Dictionary<string, string>();
            map.Add("transactionItemId", "Product Name");
            map.Add("CategoryName", "Category Name");
            map.Add("categoryId", "Reference ID");
            map.Add("productId", "Transaction ID");
            map.Add("productName", "Product Name");
            map.Add("productPrice", "Product Price");
            map.Add("transactionDate", "Transaction Date");

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
                    table.AddCell(new Phrase(r[5].ToString(), font5));
                    table.AddCell(new Phrase(r[6].ToString(), font5));
                    table.AddCell(new Phrase(r[7].ToString(), font5));
                }
            }
            document.Add(table);
            document.Close();
        }

        private void pdfexport_Click(object sender, EventArgs e)
        {
            mydata = summarytableadapter.FullSummaryDT();
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string foldername = folderBrowserDialog.SelectedPath;
                //MessageBox.Show(foldername + "report.pdf");
                ExportToPdf(mydata, foldername);
                MessageBox.Show(this, "Report exported to: " + foldername + " successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void asPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mydata = summarytableadapter.FullSummaryDT();
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string foldername = folderBrowserDialog.SelectedPath;
                //MessageBox.Show(foldername + "report.pdf");
                ExportToPdf(mydata, foldername);
                MessageBox.Show(this, "Report exported to: " + foldername + " successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
