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

            // Set the 'API Key' label text depending on whether the environment variable for the API Key already exists.
            if(Environment.GetEnvironmentVariable(Randee.API_KEY) == null)
            {
                labelAPIKey.Text = "Enter a Random.org API key!";
                labelAPIKey.Location = new Point(80, 43); // Empirically acquired

                return;
            }

            labelAPIKey.Text = "Overwrite your current API key?";
            labelAPIKey.Location = new Point(69, 43); // Empirically acquired
        }




        /* Event Handlers */
        


        // Resets the text box colour
        private void textboxAPIKey_Enter(object sender, EventArgs e)
        {
            textboxAPIKey.ForeColor = Color.Black;
            textboxAPIKey.Text = "";
        }



        // Attempts to save the API Key when the 'Enter' key is pressed from within the textbox 
        private void textboxAPIKey_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                SaveKey();
            }
        }



        // Attempts to save the API Key when the user presses the 'Save Key' button
        private void buttonSaveKey_Click(object sender, EventArgs e)
        {
            SaveKey();
        }



        /* Support functions */



        /* Attempts to save the API Key.
         * Sets an environment variable which contains the Random.org API key.
         * Prompts the user if the key given is not a valid key.
         */
        private void SaveKey()
        {
            if(IsInputValid(textboxAPIKey.Text))
            {
                Environment.SetEnvironmentVariable(Randee.API_KEY, textboxAPIKey.Text);
                return;
            }

            textboxAPIKey.ForeColor = Color.Red;
            textboxAPIKey.Text = "Invalid key detected! Please check your key and try again!";
        }



        /* Validates the API Key.
         * Returns true if the key contains only letters, digits and the hyphen (-) symbol.
         * Otherwise, returns false.
         */
        private bool IsInputValid(string givenInput)
        {
            string userInput = givenInput;

            foreach (char character in givenInput)
            {

                if (!Char.IsLetterOrDigit(character))
                {
                    if (character != '-')
                    {
                        return false;
                    }
                }

            }

            return true;
        }
    }
}
