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
    public partial class editproducts : Form
    {
        Boolean updatepending = false;
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
    }
}
