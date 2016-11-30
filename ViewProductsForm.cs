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

namespace NewPOS
{
    public partial class ViewProductsForm : Form
    {
        public delegate void AddToViewProductsForm();

        public event AddToViewProductsForm AddProductsEvent;

        public event AddToViewProductsForm AddCategoryEvent;

        public event AddToViewProductsForm AddButtonsOnClosingViewProductsFormEvent; // add category buttons to main form when view products form is closed

        Database1Entities dbe = new Database1Entities();

        summaryreportTableAdapters.tblProductTableAdapter productsstableadapter = new summaryreportTableAdapters.tblProductTableAdapter();

        summaryreport.tblProductDataTable productdatatable = new summaryreport.tblProductDataTable();

        private DataRow LastDataRow = null;

        byte[] dataProduct;

        byte[] dataCategory;
        public ViewProductsForm()
        {
            InitializeComponent();

            dataGridView1.DataSource = dbe.tblProduct.ToList();
         
            dataGridView1.Columns["categoryId"].Visible = false;
            dataGridView1.Columns["tblCategory"].Visible = false;
            dataGridView1.Columns["tblTransactionItem"].Visible = false;
            dataGridView1.Columns["productId"].Visible = false;

            cmbFilterCategory.DataSource = dbe.tblCategory.ToList();
            cmbFilterCategory.DisplayMember = "CategoryName";
            cmbFilterCategory.ValueMember = "categoryId";

            cmbSelectCategoryAddProduct.DataSource = dbe.tblCategory.ToList();
            cmbSelectCategoryAddProduct.DisplayMember = "CategoryName";
            cmbSelectCategoryAddProduct.ValueMember = "categoryId";

            productsstableadapter.Fill(productdatatable);
            // resize the column once, but allow the
            // users to change it.
            this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnViewAllProducts_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbe.tblProduct.ToList();
        }

        private void cmbFilterCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var data = from p in dbe.tblProduct where p.categoryId == (int)cmbFilterCategory.SelectedIndex + 1 select p;

            var dataList = data.ToList();

            dataGridView1.DataSource = dataList;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                tblProduct pro = new tblProduct();

                pro.productName = txtProductName.Text;

                pro.productPrice = decimal.Parse(txtProductPrice.Text);

                pro.categoryId = (int)cmbSelectCategoryAddProduct.SelectedValue;

                pro.productImage = dataProduct;

                pro.openingstock = Convert.ToInt32(stckamnttxt.Text);

                dbe.tblProduct.Add(pro);

                dbe.SaveChanges();

                MessageBox.Show("Product Saved");

                AddProductsEvent += ViewProductsForm_AddProductsEvent;

                AddProductsEvent();
            }
            catch
            {
                MessageBox.Show("Something went wrong. Please, fill out all of the fields.");
            }
        }

        void ViewProductsForm_AddProductsEvent()
        {
            dataGridView1.DataSource = dbe.tblProduct.ToList();
        }

        private void btnUploadProductImage_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                dataProduct = new byte[fs.Length];

                fs.Read(dataProduct, 0, dataProduct.Length);

                fs.Close();

                MemoryStream ms = new MemoryStream(dataProduct);

                try
                {

                    pbProductImage.Image = Image.FromStream(ms);
                }
                catch (Exception ioe) { MessageBox.Show("Invalid Image!"); return; }

                pbProductImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryName.Text == "")
                {
                    MessageBox.Show("Please fill out all the fields");
                    return;
                }

                tblCategory cat = new tblCategory();

                cat.CategoryName = txtCategoryName.Text;

                cat.categoryImage = dataCategory;

                dbe.tblCategory.Add(cat);

                dbe.SaveChanges();

                MessageBox.Show("Category Saved");

                AddCategoryEvent += ViewProductsForm_AddCategoryEvent;

                AddCategoryEvent();
            }
            catch { }

        }

        void ViewProductsForm_AddCategoryEvent()
        {
            cmbFilterCategory.DataSource = dbe.tblCategory.ToList();
            cmbSelectCategoryAddProduct.DataSource = dbe.tblCategory.ToList();
        }

        private void btnUIploadCategoryImage_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                dataCategory = new byte[fs.Length];

                fs.Read(dataCategory, 0, dataCategory.Length);

                fs.Close();

                MemoryStream ms = new MemoryStream(dataCategory);

                try
                {
                    pbCategoryImage.Image = Image.FromStream(ms);
                }
                catch (Exception ioe) { MessageBox.Show("Invalid Image!"); return; }

                pbCategoryImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void ViewProductsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddButtonsOnClosingViewProductsFormEvent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void gbAddCategory_Enter(object sender, EventArgs e)
        {

        }

        private void ViewProductsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'summaryreport.tblProduct' table. You can move, or remove it, as needed.
            this.tblProductTableAdapter.Fill(this.summaryreport.tblProduct);

        }

        private void regionBindingSource_PositionChanged(object sender, EventArgs e)
        {
            // if the user moves to a new row, check if the 
            // last row was changed
            BindingSource thisBindingSource =
              (BindingSource)sender;
            DataRow ThisDataRow =
              ((DataRowView)thisBindingSource.Current).Row;
            if (ThisDataRow == LastDataRow)
            {
                // we need to avoid to write a datarow to the 
                // database when it is still processed. Otherwise
                // we get a problem with the event handling of 
                //the DataTable.
                throw new ApplicationException("It seems the" +
                  " PositionChanged event was fired twice for" +
                  " the same row");
            }

            UpdateRowToDatabase();
            // track the current row for next 
            // PositionChanged event
            LastDataRow = ThisDataRow;
        }

        private void UpdateRowToDatabase()
        {
            if (LastDataRow != null)
            {
                if (LastDataRow.RowState ==
                    DataRowState.Modified)
                {
                    productsstableadapter.Update(LastDataRow);
                }
            }
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


        private void editmode_Click(object sender, EventArgs e)
        {
            
            string pass = ".";
            ShowInputDialog(ref pass, "password", "Admin Password Input");
            if (pass == "terra")
            {
                MessageBox.Show("Successfully Logged In");

                editproducts edit1 = new editproducts();
                edit1.Show();
                return;
            }
        }

        private void dataGridView1_ColumnDividerDoubleClick(object sender, DataGridViewColumnDividerDoubleClickEventArgs e)
        {
            AddProductsEvent += ViewProductsForm_AddProductsEvent;

            AddProductsEvent();
        }
    }
}
