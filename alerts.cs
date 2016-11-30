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
    public partial class alerts : Form
    {
        public alerts()
        {
            InitializeComponent();
        }

        private void alerts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.tblProduct' table. You can move, or remove it, as needed.
            this.tblProductTableAdapter1.Fill(this.database1DataSet.tblProduct);
            // TODO: This line of code loads data into the 'summaryreport.tblProduct' table. You can move, or remove it, as needed.
            this.tblProductTableAdapter.Fill(this.summaryreport.tblProduct);

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
