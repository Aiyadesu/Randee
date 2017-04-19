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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            if(Environment.GetEnvironmentVariable(Randee.API_KEY) == null)
            {
                labelAPIKey.Text = "Enter a Random.org API key!";
                labelAPIKey.Location = new Point(80, 43); // Empirically acquired

                return;
            }

            labelAPIKey.Text = "Overwrite your current API key?";
            labelAPIKey.Location = new Point(69, 43); // Empirically acquired
        }



        /* Validates the user input when focus is lost */
        private void textboxAPIKey_Leave(object sender, EventArgs e)
        {
            if(IsInputValid(textboxAPIKey.Text))
            {
                Environment.SetEnvironmentVariable(Randee.API_KEY, textboxAPIKey.Text);
                return;
            }

            textboxAPIKey.ForeColor = Color.Red;
            textboxAPIKey.Text = "Invalid key detected! Please check your key and then again!";


           
        }



        private bool IsInputValid(string givenInput)
        {
            string userInput = givenInput;

            foreach(char character in userInput)
            {

                if(!Char.IsLetterOrDigit(character))
                {
                    if(character != '-')
                    {
                        return false;
                    }
                }
               
            }

            return true;
        }



        private void textboxAPIKey_Enter(object sender, EventArgs e)
        {
            textboxAPIKey.ForeColor = Color.Black;
            textboxAPIKey.Text = "";
        }

        private void textboxAPIKey_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                labelAPIKey.Focus();
            }
        }
    }
}
