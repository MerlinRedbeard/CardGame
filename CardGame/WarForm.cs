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
    public partial class WarForm : Form
    {
        public int returnNumberOfPlayers { get; set; }

        public int returnAceHighLow { get; set; }

        public WarForm()
        {
            InitializeComponent();
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            WarOptionForm optionForm = new WarOptionForm();
            var result = optionForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                returnAceHighLow = optionForm.returnAceHighLow;
            }
        }

        private void NumberOfPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnNumberOfPlayers = numberOfPlayers.SelectedIndex + 2;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void WarForm_Load(object sender, EventArgs e)
        {
            // Set default number of players to 2 (which is the first value in the array, so "0")
            numberOfPlayers.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
