using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PlitkaCalc
{
    public partial class TForm : Form
    {
        public TForm()
        {
            InitializeComponent();
        }

        private void tWi_TextChanged(object sender, EventArgs e)
        {
            if (!tLe.Enabled) tLe.Text = tWi.Text;
        }
    }
}