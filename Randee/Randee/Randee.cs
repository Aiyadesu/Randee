using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Randee
{
    public partial class Randee : Form
    {
        public Randee()
        {
            InitializeComponent();
        }

        private void Randee_Load(object sender, EventArgs e)
        {

        }

        private void titleBar_Click(object sender, EventArgs e)
        {

        }

        private void generateNumber_Click(object sender, EventArgs e)
        {
            numberDisplay.Text = ShuffleHeaven.GenerateNumber((byte)rangeInput.Value).ToString();
        }

        private void numberDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void rangeInput_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
