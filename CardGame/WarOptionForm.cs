using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class WarOptionForm : Form
    {
        public int returnAceHighLow { get; set; }

        public WarOptionForm()
        {
            InitializeComponent();
            returnAceHighLow = 0;
        }

        private void aceLow_CheckedChanged(object sender, EventArgs e)
        {
            returnAceHighLow = 1;
        }

        private void aceHigh_CheckedChanged(object sender, EventArgs e)
        {
            returnAceHighLow = 0;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
