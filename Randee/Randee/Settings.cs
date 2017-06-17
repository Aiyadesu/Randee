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
        private const string SETTINGS_HISTORY = "NUMBER_HISTORY = ";

        private const char SETTINGS_OFF = '0';
        private const char SETTINGS_ON = '1';

        /* Class Members */
        private string settingsPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\settings.txt";

        private bool keepHistory;
        private string seperator;



        public Settings()
        {
            InitializeComponent();


            labelAPIKey.ForeColor = Randee.TEXT_COLOUR;
            labelSaveStatus.ForeColor = Randee.TEXT_COLOUR;

            
            textboxAPIKey.BackColor = Randee.WINDOW_BACK_COLOUR;
            textboxAPIKey.ForeColor = Randee.TEXT_COLOUR;

            checkBoxKeepHistory.ForeColor = Randee.TEXT_COLOUR;
            labelSeperator.ForeColor = Randee.TEXT_COLOUR;
            labelSeperatorExample.ForeColor = Randee.TEXT_COLOUR;

            comboBoxSeperator.BackColor = Randee.WINDOW_BACK_COLOUR;
            comboBoxSeperator.ForeColor = Randee.INPUT_COLOUR;

            buttonSaveKey.BackColor = Randee.WINDOW_BACK_COLOUR;
            buttonSaveKey.ForeColor = Randee.INPUT_COLOUR;

            /* Initialise class members */
            seperator = " "; 



            /* Prepare the labels based on whether the user environment variable for the API Key exists */
            labelSaveStatus.Text = String.Empty;



            /* Create the 'settings.txt' if it does not already exist */
            if (!File.Exists(settingsPath))
            {
                CreateSettingsFile();
            }



            ReadSettingsFile();

            /* Setup the GUI */
            checkBoxKeepHistory.Checked = keepHistory;

            if (!IsAPIKeySet())
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
            textboxAPIKey.Text = String.Empty;

            ChangeSaveStatusLabel(0, 0, Randee.TEXT_COLOUR, String.Empty);
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



        // Updates the 'keepHistory' field based on the user preference
        private void checkBoxKeepHistory_CheckedChanged(object sender, EventArgs e)
        {
            SetKeepHistory(checkBoxKeepHistory.Checked);

            labelSeperator.Visible = keepHistory;
            comboBoxSeperator.Visible = keepHistory;
            labelSeperatorExample.Visible = keepHistory;

            UpdateSettings(SETTINGS_HISTORY + (GetKeepHistory() ? SETTINGS_ON : SETTINGS_OFF));
        }




        private void comboBoxSeperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSeperator(comboBoxSeperator.Text);

            labelSeperatorExample.Text = "Example Output) 1" + seperator + "2" + seperator + "3" + seperator + "4.";
        }



        /* Main Functions */



        /// <summary>
        /// Creates a file to store settings in text format ('settings.txt').
        /// </summary>
        private void CreateSettingsFile()
        {
            // Adds whether the "RANDOM_ORG_API" environment variable is found or not to the settings
            string settings = SETTINGS_API_KEY + (IsAPIKeySet() ? SETTINGS_ON : SETTINGS_OFF) + "\r\n" 
                            + SETTINGS_HISTORY + (GetKeepHistory() ? SETTINGS_ON : SETTINGS_OFF) + "\r\n";

            WriteToSettingsFile(settings);
        }



        /// <summary>
        /// Reads the settings text file ('settings.txt').
        /// </summary>
        /// <returns>A string with the contents of the settings file.</returns>
        private string ReadSettingsFile()
        {
            string settings = String.Empty;

            // Open the 'settings.txt' file and then store the contents of the file in a string
            using (StreamReader streamReader = File.OpenText(settingsPath))
            {

                string currentLine = String.Empty;

                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    // Store the current line
                    settings += currentLine + "\r\n";

                    /* Set the members based on the previous settings */
                    // Retrives the previous settings for whether or not to keep a history or generated numbers
                    if(currentLine.Contains(SETTINGS_HISTORY))
                    {
                        SetKeepHistory(settings[settings.Length - 1] == SETTINGS_ON);
                        continue;
                    }
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
            if(textboxAPIKey.Text.Trim() == String.Empty)
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

                ChangeSaveStatusLabel(115, 124, Randee.TEXT_COLOUR, "Key successfully saved!");

                return;
            }

            ChangeSaveStatusLabel(60, 114, Color.Red, "Invalid key!\r\nOnly letters, digits and hyphens (-) allowed!");
        }



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



        /* Convenience Functions */



        /// <summary>
        /// Checks whether the API Key is set as user environment variable.
        /// </summary>
        /// <returns>
        /// True, if the key is set as an environment variable. 
        /// False, otherwise.
        /// </returns>
        public bool IsAPIKeySet()
        {
            return Environment.GetEnvironmentVariable(Randee.API_KEY, EnvironmentVariableTarget.User) != null;
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



        /* Getters & Setters */



        public bool GetKeepHistory()
        {
            return keepHistory;
        }

        public void SetKeepHistory(bool keepHistory)
        {
            this.keepHistory = keepHistory;
        }

        public string GetSeperator()
        {
            return seperator;
        }

        public void SetSeperator(string seperator)
        {
            this.seperator = seperator;
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
