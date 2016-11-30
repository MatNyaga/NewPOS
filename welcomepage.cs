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
    public partial class welcomepage : Form
    {
        public welcomepage()
        {
            InitializeComponent();
        }

        private void next_Click(object sender, EventArgs e)
        {
            merchantlogin merch = new merchantlogin();
            merch.Show();
            this.Hide();

        }

        private void welcomepage_Load(object sender, EventArgs e)
        {

        }
    }
}