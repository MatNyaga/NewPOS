using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Data.SqlClient;
using System.IO;

namespace NewPOS
{
    
    public partial class editproducts : Form
    {
        DataTable csvData = new DataTable();
        Boolean updatepending = false;
        String ImagefileName = "";
        public editproducts()
        {
            InitializeComponent();
        }

        private void editproducts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.tblProduct' table. You can move, or remove it, as needed.
            this.tblProductTableAdapter1.Fill(this.database1DataSet.tblProduct);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tblCategoryTableAdapter1.FillBy(this.database1DataSet.tblCategory);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.tblProductTableAdapter1.FillBy(this.database1DataSet.tblProduct);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tblProductTableAdapter1.FillBy1(this.database1DataSet.tblProduct);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_DataMemberChanged(object sender, EventArgs e)
        {
            tblProductTableAdapter1.Update(this.database1DataSet.tblProduct);
        }

        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
            tblProductTableAdapter1.Update(this.database1DataSet.tblProduct);
        }

        private void dataGridView1_Validated(object sender, EventArgs e)
        {
            tblProductTableAdapter1.Update(this.database1DataSet.tblProduct);
        }

        public byte[] imageToByteArray(System.Drawing.Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void CSVImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowserDialog = new OpenFileDialog();
            folderBrowserDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            folderBrowserDialog.FilterIndex = 2;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string foldername = folderBrowserDialog.FileName;
                Image myimage = Image.FromFile(ImagefileName);
                byte[] myimg = imageToByteArray(myimage);
                csvData = GetDataTabletFromCSVFile(foldername);
                csvData.Columns.Add("productImage", typeof(byte[]));
                foreach (DataRow dr in csvData.Rows)
                {
                    dr["productImage"] = myimg;
                }
                InsertDataIntoSQLServerUsingSQLBulkCopy(csvData);
                MessageBox.Show(this, "Imported CSV from: " + foldername + " successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void InsertDataIntoSQLServerUsingSQLBulkCopy(DataTable csvFileData)
        {
            dataGridView1.DataSource = csvFileData;
            
            /* this.tblProductTableAdapter1.Fill(csvFileData);
            foreach (var column in csvFileData.Columns)
                s.ColumnMappings.Add(column.ToString(), column.ToString());
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

            using (SqlConnection dbConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                dbConnection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                {
                    s.DestinationTableName = "Your table name";

                    foreach (var column in csvFileData.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());

                    s.WriteToServer(csvFileData);
                }
            }*/
        }


        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return csvData;
        }

        private void image_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowserDialog = new OpenFileDialog();
            folderBrowserDialog.Filter = "Image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            folderBrowserDialog.FilterIndex = 2;
            //folderBrowserDialog.InitialDirectory = System.Environment.SpecialFolder.MyComputer;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ImagefileName = folderBrowserDialog.FileName;
                MessageBox.Show(this, "Imported CSV from: " + ImagefileName + " successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static string GetConnectionString()
        // To avoid storing the connection string in your code, 
        // you can retrieve it from a configuration file. 
        {
            return Properties.Settings.Default.Database1ConnectionString.ToString();
            //return "Data Source=(local); " + " Integrated Security=true;" + "Initial Catalog=AdventureWorks;";
        }
        
        private void save_Click(object sender, EventArgs e)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Perform an initial count on the destination table.
                SqlCommand commandRowCount = new SqlCommand(
                    "SELECT COUNT(*) FROM " +"dbo.tblProduct;",connection);
                long countStart = System.Convert.ToInt32(commandRowCount.ExecuteScalar());
                //MessageBox.Show("Starting row count = {0}" + countStart);

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "dbo.tblProduct";

                    try
                    {
                        // Write from the source to the destination.
                        SqlBulkCopyColumnMapping productId = new SqlBulkCopyColumnMapping("productId", "productId");
                        bulkCopy.ColumnMappings.Add(productId);

                        SqlBulkCopyColumnMapping productName = new SqlBulkCopyColumnMapping("productName", "productName");
                        bulkCopy.ColumnMappings.Add(productName);

                        SqlBulkCopyColumnMapping productPrice = new SqlBulkCopyColumnMapping("productPrice", "productPrice");
                        bulkCopy.ColumnMappings.Add(productPrice);

                        SqlBulkCopyColumnMapping categoryId = new SqlBulkCopyColumnMapping("categoryId", "categoryId");
                        bulkCopy.ColumnMappings.Add(categoryId);

                        SqlBulkCopyColumnMapping openingstock = new SqlBulkCopyColumnMapping("openingstock", "openingstock");
                        bulkCopy.ColumnMappings.Add(openingstock);

                        SqlBulkCopyColumnMapping productImage = new SqlBulkCopyColumnMapping("productImage", "productImage");
                        bulkCopy.ColumnMappings.Add(productImage);

                        bulkCopy.WriteToServer(csvData);

                        MessageBox.Show("Saved");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                long countEnd = System.Convert.ToInt32(commandRowCount.ExecuteScalar());
                //Console.WriteLine("Ending row count = {0}", countEnd);
                MessageBox.Show("{0} rows were added."+ (countEnd - countStart));
            }
               
        }
    } 


}
