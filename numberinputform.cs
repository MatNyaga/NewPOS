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
    public partial class numberinputform : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= 0x08000000;
                return param;
            }
        }
        public numberinputform()
        {
            InitializeComponent();
        }

        private void numberinputform_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendKeys.Send("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendKeys.Send("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendKeys.Send("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SendKeys.Send("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SendKeys.Send("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SendKeys.Send("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SendKeys.Send("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SendKeys.Send("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SendKeys.Send("9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SendKeys.Send("0");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{Enter}");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{Backspace}");
        }
    }
}
