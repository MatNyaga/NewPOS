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
    public partial class LCDText : Form
    {
        public LCDText()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LCD1_1 = FSL1Txt.Text;
            Properties.Settings.Default.LCD1_2 = FSL2Txt.Text;
            Properties.Settings.Default.LCD2_1 = SSL1Txt.Text;
            Properties.Settings.Default.LCD2_2 = SSL2Txt.Text;
            Properties.Settings.Default.LCD3_1 = TSL1Txt.Text;
            Properties.Settings.Default.LCD3_2 = TSL2Txt.Text;
            this.Close();
        }

        private void LCDText_Load(object sender, EventArgs e)
        {
            FSL1Txt.Text = Properties.Settings.Default.LCD1_1;
            FSL2Txt.Text = Properties.Settings.Default.LCD1_2;
            SSL1Txt.Text = Properties.Settings.Default.LCD2_1;
            SSL2Txt.Text = Properties.Settings.Default.LCD2_2;
            TSL1Txt.Text = Properties.Settings.Default.LCD3_1;
            TSL2Txt.Text = Properties.Settings.Default.LCD3_2;
        }
    }
}
