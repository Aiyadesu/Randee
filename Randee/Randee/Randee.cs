using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Randee
{
    public partial class Randee : Form
    {
        /* Move Window without 'Titlebar' in C# 
         * Source: https://www.codeproject.com/Articles/11114/Move-window-form-without-Titlebar-in-C
         */
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        /* Externally implemented functions (i.e from 'user32.dll') */
        [DllImport("user32.dll")] 
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Default Constructor
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

        // The main event function to be called
        private void generateNumber_Click(object sender, EventArgs e)
        {
            if (minRangeInput.Value > Byte.MaxValue || maxRangeInput.Value > Byte.MaxValue)
            {
                numberDisplay.Text = "Your random number is " + ShuffleHeaven.GenerateNumber((int)minRangeInput.Value, (int)maxRangeInput.Value).ToString();
                /* The called function is commented out */
                //ShuffleHeaven.GetTrueRandomNumber(10, (int)minRangeInput.Value, (int)maxRangeInput.Value);
            }
            else
            {
                numberDisplay.Text = "Your random number is " + ShuffleHeaven.GenerateNumber((byte)minRangeInput.Value, (byte)maxRangeInput.Value).ToString();
            }
        }

        private void rangeInput_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numberDisplay_Click(object sender, EventArgs e)
        {

        }

        private void minRangeInput_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Randee_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
