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
using System.IO;

namespace Randee
{
    public partial class Randee : Form
    {
        /* Windows Constants */
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        /* Randee Constants */
        public const string API_KEY = "RANDOM_ORG_API";
        private const string TITLE_HOME = "Randee - Home";
        private const string TITLE_SETTINGS = "Randee - Settings";

        /* Other Pages/Forms */
        private Settings settingsForm = new Settings();

        /* Randee Members */
        private string historyPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\history.txt";
        private string dateTimeAppOpened = "Numbers generated history from: " + DateTime.Now.ToString() + "\r\n";
        private string generatedNumbers;

        /* Colours */
        public static Color TITLE_BAR_BACK_COLOUR = Color.FromArgb(64, 64, 64);
        public static Color WINDOW_BACK_COLOUR = Color.FromArgb(128, 128, 128);
        public static Color TEXT_COLOUR = Color.FromArgb(230, 230, 230);
        public static Color INPUT_COLOUR = Color.FromArgb(255, 255, 255);
        public static Color RESULTS_COLOUR = Color.FromArgb(0, 153, 0);



        /* Externally implemented functions (i.e from 'user32.dll') */
        [DllImport("user32.dll")] 
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();



        // Default Constructor
        public Randee()
        {
            InitializeComponent();

            /* Set the "dark" theme of the application */
            BackColor = TITLE_BAR_BACK_COLOUR;

            // Set the display colours
            numberDisplay.ForeColor = TEXT_COLOUR;
            titleText.ForeColor = TEXT_COLOUR;
            customRangeLabel.ForeColor = TEXT_COLOUR;
            fromLabel.ForeColor = TEXT_COLOUR;
            toLabel.ForeColor = TEXT_COLOUR;
            numberOfNumbersLabel.ForeColor = TEXT_COLOUR;

            // Set the input colours
            minRangeInput.BackColor = WINDOW_BACK_COLOUR;
            minRangeInput.ForeColor = INPUT_COLOUR;

            maxRangeInput.BackColor = WINDOW_BACK_COLOUR;
            maxRangeInput.ForeColor = INPUT_COLOUR;

            numberOfNumbersInput.BackColor = WINDOW_BACK_COLOUR;
            numberOfNumbersInput.ForeColor = INPUT_COLOUR;

            generateNumber.BackColor = WINDOW_BACK_COLOUR;
            generateNumber.ForeColor = INPUT_COLOUR;

            // Set the result colours
            numberDisplay.ForeColor = RESULTS_COLOUR;
            labelMultipleNumbers.ForeColor = RESULTS_COLOUR;

            // Clear the default text
            ClearNumbers();

            UpdateTitle(TITLE_HOME);
        }



        /* Event Handlers */



        // The main event function to be called
        private void generateNumber_Click(object sender, EventArgs e)
        {
            generateNumber.Enabled = false; // Lock the button

            /* Generates a true random number */
            if(settingsForm.IsAPIKeySet())
            {
                string number = ShuffleHeaven.GetTrueRandomNumber((int)numberOfNumbersInput.Value, (int)minRangeInput.Value, (int)maxRangeInput.Value);

                numberDisplay.Text = numberOfNumbersInput.Value > 1 ? "Your random numbers are: " : "Your random number is: " + number;
                labelMultipleNumbers.Text = numberOfNumbersInput.Value > 1 ? number : "";

                AddToLog(number);

                generateNumber.Enabled = true; // Unlock the button

                return;
            }



            /* Generates a pseudo random number */
            if (minRangeInput.Value > Byte.MaxValue || maxRangeInput.Value > Byte.MaxValue)
            {
                string number = ShuffleHeaven.GenerateNumber((int) numberOfNumbersInput.Value, (int)minRangeInput.Value, (int)maxRangeInput.Value).ToString();

                numberDisplay.Text = numberOfNumbersInput.Value > 1 ? "Your random numbers are: " : "Your random number is: " + number;
                labelMultipleNumbers.Text = numberOfNumbersInput.Value > 1 ? number : "";

                AddToLog(number);
            }

            generateNumber.Enabled = true; // Unlock the button
        }



        private void Randee_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }



        private void Randee_LocationChanged(object sender, EventArgs e)
        {
            Point window = Location;
            window.Offset(0, 42);

            settingsForm.Location = window;
        }



        private void buttonClose_MouseOver(object sender, EventArgs e)
        {
            buttonClose.BackgroundImage = Properties.Resources.close_button_FFFFFF;
        }



        private void buttonClose_Leave(object sender, EventArgs e)
        {
            buttonClose.BackgroundImage = Properties.Resources.close_button_c0c0c0;
        }



        private void buttonHome_Click(object sender, EventArgs e)
        {
            if(settingsForm.Visible)
            {
                settingsForm.Hide();
            }

            UpdateTitle(TITLE_HOME);
        }



        private void buttonHome_MouseOver(object sender, EventArgs e)
        {
            buttonHome.BackgroundImage = Properties.Resources.home_button_FFFFFFF;
        }



        private void buttonSettings_Click(object sender, EventArgs e)
        {
            ClearNumbers();
            UpdateTitle(TITLE_SETTINGS);

            settingsForm.BackColor = BackColor;

            Point window = Location;
            window.Offset(0, 42);

            settingsForm.Location = window;

            if (!settingsForm.Visible)
            {
                settingsForm.Show(this);
            }
        }



        private void buttonHome_Leave(object sender, EventArgs e)
        {
            buttonHome.BackgroundImage = Properties.Resources.home_button_c0c0c0;
        }



        private void buttonSettings_MouseOver(object sender, EventArgs e)
        {
            buttonSettings.BackgroundImage = Properties.Resources.settings_button_FFFFFF;
        }

        private void buttonSettings_Leave(object sender, EventArgs e)
        {
            buttonSettings.BackgroundImage = Properties.Resources.settings_button_c0c0c0;
        }



        /* 
         * Closes the application.
         * Add "clean up" code here!
         */
        private void buttonClose_Click(object sender, EventArgs e)
        {
            OutputLogFile();

            Application.Exit();
        }



        /* Main Functions */
        private void AddToLog(string number)
        {
            generatedNumbers += number + settingsForm.GetSeperator() + "\r\n";
        }



        /// <summary>
        /// Outputs the history of generated numbers by "session". 
        /// i.e Everytime the application is closed a "session" is ended.
        /// </summary>
        private void OutputLogFile()
        {
            string history = dateTimeAppOpened + generatedNumbers;



            if(!settingsForm.GetKeepHistory())
            {
                return;
            }



            if(!File.Exists(historyPath))
            {
                using (FileStream fileStream = File.Create(historyPath))
                {
                    Byte[] historyData = new UTF8Encoding(true).GetBytes(history + "\r\n\r\n");
                    fileStream.Write(historyData, 0, historyData.Length);
                }
                return;
            }



            using (StreamWriter streamWriter = File.AppendText(historyPath))
            {
                streamWriter.WriteLine(history + "\r\n\r\n");
            }
        }



        private void UpdateTitle(string newTitle)
        {
            titleText.Text = newTitle;
        }



        private void ClearNumbers()
        {
            numberDisplay.Text = "";
            labelMultipleNumbers.Text = "";
        }
    }
}
