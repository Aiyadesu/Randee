using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Randee
{
    public partial class Settings : Form
    {
        /* Class Constants */
        private const string SETTINGS_API_KEY = "RANDOM_ORG_API = ";

        private const string SETTINGS_OFF = "0";
        private const string SETTINGS_ON = "1";

        /* Class Members */
        private string settingsPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\settings.txt";



        public Settings()
        {
            InitializeComponent();



            /* Create the 'settings.txt' if it does not already exist */
            if (!File.Exists(settingsPath))
            {
                CreateSettingsFile();
            }



            /* Prepare the labels based on whether the user environment variable for the API Key exists */
            labelSaveStatus.Text = "";

            if(Environment.GetEnvironmentVariable(Randee.API_KEY, EnvironmentVariableTarget.User) == null)
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

            ChangeSaveStatusLabel(0, 0, Color.Black, "");
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



        /* Main Functions */



        /// <summary>
        /// Convenience function to write to the 'settings.txt' file.
        /// "Writes a block of bytes to the file stream".
        /// </summary>
        private void WriteToSettingsFile(string settings)
        {
            using (FileStream fileStream = File.Create(settingsPath))
            {
                Byte[] settingsData = new UTF8Encoding(true).GetBytes(settings);
                fileStream.Write(settingsData, 0, settingsData.Length);
            }
        }



        /// <summary>
        /// Creates a file to store settings in text format ('settings.txt').
        /// </summary>
        private void CreateSettingsFile()
        {
            // Adds whether the "RANDOM_ORG_API" environment variable is found or not to the settings
            string settings = "RANDOM_ORG_API = " + (Environment.GetEnvironmentVariable(Randee.API_KEY, EnvironmentVariableTarget.User) == null ? "0" : "1") + "\r\n";

            WriteToSettingsFile(settings);
        }



        /// <summary>
        /// Reads the settings text file ('settings.txt').
        /// </summary>
        /// <returns>A string with the contents of the settings file.</returns>
        private string ReadSettingsFile()
        {
            string settings = "";

            // Open the 'settings.txt' file and then store the contents of the file in a string
            using (StreamReader streamReader = File.OpenText(settingsPath))
            {

                string currentLine = "";

                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    settings += currentLine;
                }

            }

            return settings;
        }



        /// <summary>
        /// Updates the settings text file ('settings.txt') with the provided changes.
        /// </summary>
        /// 
        /// <param name="settingChanges">
        /// A string containing the required changes for the settings file. 
        /// 
        /// Example: "RANDOM_ORG_API = 0";
        /// This string indicates that the user environment variable for the API Key does not exist anymore.
        /// </param>
        public void UpdateSettings(string settingChanges)
        {
            string settings = ReadSettingsFile();

            int count = settingChanges.Length;
            int startIndex = settings.LastIndexOf(settingChanges.Substring(0, count - 1)); // Finds the index of the setting being updated

            // Update the settings string to reflect the changes made
            settings = settings.Remove(startIndex, count); // Removes the current setting
            settings = settings.Insert(startIndex, settingChanges); // Inserts the requested change

            // Write the updated settings to the file
            WriteToSettingsFile(settings);
        }


        /// <summary>
        /// Changes the position, colour and text of the 'Save Status' label.
        /// </summary>
        /// 
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="colour"></param>
        /// <param name="labelText"></param>
        private void ChangeSaveStatusLabel(int x, int y, Color colour, string labelText)
        {
            labelSaveStatus.Location = new Point(x, y);
            labelSaveStatus.ForeColor = colour;
            labelSaveStatus.Text = labelText;
        }



        /// <summary>
        /// Sets an environment variable which contains the Random.org API key.
        /// 
        /// Pre-condition: The user clicks the 'Save' key or presses 'Enter' while within the 'TextboxAPIKey'.
        /// Post-condition: 
        /// If a valid key is provided, the key is saved as an environment variable and the user is notified.
        /// If an invalid key is provided, the user is notified.
        /// </summary>
        private void SaveKey()
        {
            /* Check for null input */
            if(textboxAPIKey.Text.Trim() == "")
            {
                ChangeSaveStatusLabel(115, 124, Color.Red, "Please enter your key.");

                return;
            }



            /* Check for valid input */
            if(IsInputValid(textboxAPIKey.Text))
            {
                // Sets the environment variable
                Environment.SetEnvironmentVariable(Randee.API_KEY, textboxAPIKey.Text, EnvironmentVariableTarget.User);

                UpdateSettings(SETTINGS_API_KEY + SETTINGS_ON);

                ChangeSaveStatusLabel(115, 124, Color.Black, "Key successfully saved!");

                return;
            }

            ChangeSaveStatusLabel(60, 114, Color.Red, "Invalid key!\r\nOnly letters, digits and hyphens (-) allowed!");
        }



        /* Validates the API Key.
         * Returns true if the key contains only letters, digits and the hyphen (-) symbol.
         * Otherwise, returns false.
         */
        /// <summary>
        /// Validates the input provided for the 'TextboxAPIKey'.
        /// </summary>
        /// 
        /// <param name="givenInput"> 
        /// The text for 'TextboxAPIKey'. 
        /// </param>
        /// 
        /// <returns>
        /// If the input is valid: true.
        /// If the input is invalid: false.
        /// </returns>
        private bool IsInputValid(string givenInput)
        {
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
