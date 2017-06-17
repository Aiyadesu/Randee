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
        public static Color WINDOW_BACK_COLOUR    = Color.FromArgb(128, 128, 128);
        public static Color TEXT_COLOUR           = Color.FromArgb(230, 230, 230);
        public static Color INPUT_COLOUR          = Color.FromArgb(255, 255, 255);
        public static Color RESULTS_COLOUR        = Color.FromArgb(0, 153, 0);
        public static Color ERROR_COLOUR          = Color.FromArgb(204, 0, 0);



        /* Externally implemented functions (i.e from 'user32.dll') */
        [DllImport("user32.dll")] 
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();



        public Randee()
        {
            InitializeComponent();

            /* Set the "dark" theme of the application */
            BackColor = TITLE_BAR_BACK_COLOUR;

            // Set the display colours
            labelNumberDisplay.ForeColor   = TEXT_COLOUR;
            labelTitle.ForeColor           = TEXT_COLOUR;
            labelCustomRange.ForeColor     = TEXT_COLOUR;
            labelFrom.ForeColor            = TEXT_COLOUR;
            labelTo.ForeColor              = TEXT_COLOUR;
            labelNumberOfNumbers.ForeColor = TEXT_COLOUR;
            labelQuotaTitle.ForeColor      = TEXT_COLOUR;
            labelBitsLeft.ForeColor        = TEXT_COLOUR;
            labelRequestsLeft.ForeColor    = TEXT_COLOUR;

            // Set the input colours
            inputMinRange.BackColor        = WINDOW_BACK_COLOUR;
            inputMinRange.ForeColor        = INPUT_COLOUR;

            inputMaxRange.BackColor        = WINDOW_BACK_COLOUR;
            inputMaxRange.ForeColor        = INPUT_COLOUR;

            inputNumberOfNumbers.BackColor = WINDOW_BACK_COLOUR;
            inputNumberOfNumbers.ForeColor = INPUT_COLOUR;

            buttonGenerateNumber.BackColor = WINDOW_BACK_COLOUR;
            buttonGenerateNumber.ForeColor = INPUT_COLOUR;

            buttonCheckQuota.BackColor     = WINDOW_BACK_COLOUR;
            buttonCheckQuota.ForeColor     = INPUT_COLOUR;

            // Set the result colours
            labelNumberDisplay.ForeColor   = RESULTS_COLOUR;
            labelMultipleNumbers.ForeColor = RESULTS_COLOUR;

            // Set the error message colour
            labelErrorMessage.ForeColor    = ERROR_COLOUR;

            // Clear the default text
            HideOutputScreen();

            // Set the 'Title' text
            UpdateTitle(TITLE_HOME);

            // Set the 'Check Quota' button default properties if necessary
            if(settingsForm.IsAPIKeySet())
            {
                buttonCheckQuota.Visible = true;
            } else
            {
                buttonGenerateNumber.Location = new Point(165, 377);
            }
        }



        /* Event Handlers */



        /*
         * Generates a true or pseudo random number 
         * depending on whether the Random.org API Key has been set.
         */
        private void buttonGenerateNumber_Click(object sender, EventArgs e)
        {
            ChangeCursor();
            HideOutputScreen();
            buttonGenerateNumber.Enabled = false; // Lock the button

            string number;

            /* Generates a true random number */
            if(settingsForm.IsAPIKeySet())
            {
                number = ShuffleHeaven.GetTrueRandomNumber((int)inputNumberOfNumbers.Value, (int)inputMinRange.Value, (int)inputMaxRange.Value);

                labelNumberDisplay.Text = 
                    inputNumberOfNumbers.Value > 1 ? 
                    "Your random numbers are: " : "Your random number is: " + number;

                labelMultipleNumbers.Text =
                    inputNumberOfNumbers.Value > 1 ?
                    number : String.Empty;

                // Shows an error message if 'ShuffleHeaven' throws an exception
                if(ShuffleHeaven.GetExceptionThrown())
                {
                    labelErrorMessage.Text = "An issue with the connectivity was detected. \r\nNumber provided is not true random";
                }

                ShowNumber();

                AddToLog(number);

                buttonGenerateNumber.Enabled = true; // Unlock the button

                return;
            }



            /* Generates a pseudo random number */
            number = ShuffleHeaven.GenerateNumber((int) inputNumberOfNumbers.Value, (int)inputMinRange.Value, (int)inputMaxRange.Value).ToString();

            labelNumberDisplay.Text =
                inputNumberOfNumbers.Value > 1 ?
                "Your random numbers are: " : "Your random number is: " + number;

            labelMultipleNumbers.Text =
                inputNumberOfNumbers.Value > 1 ?
                number : String.Empty;
            ShowNumber();

            AddToLog(number);

            buttonGenerateNumber.Enabled = true; // Unlock the button
        }



        private void buttonCheckQuota_Click(object sender, EventArgs e)
        {
            ChangeCursor();
            HideOutputScreen();

            ShuffleHeaven.GetUsage();

            if (ShuffleHeaven.GetExceptionThrown())
            {
                labelErrorMessage.Text = "An issue with the connectivity was detected. \r\nCannot retrieve the Daily Quota.";

                return;
            }

            labelBitsLeft.Text = "Bits Left: " + ShuffleHeaven.GetBitsLeft();
            labelRequestsLeft.Text = "Requests Left: " + ShuffleHeaven.GetRequestsLeft();

            ShowQuota();
        }



        /* 
         * Moves the 'Randee' window around
         * if the user is holding down the left
         * mouse button in the title bar area 
         */
        private void Randee_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }



        /*
         * Moves the 'other' forms along with the 'Randee' window
         */
        private void Randee_LocationChanged(object sender, EventArgs e)
        {
            Point window = Location;
            window.Offset(0, 42);

            settingsForm.Location = window;
        }



        /*
         * Changes the buttons colour. Default is colour is 'c0c0c0'.
         * Changes to 'FFFFFF' if the button is hovered.
         * Changes back to the default colour when no longer hovered.
         */

        /* 'Close' button functions */
        private void buttonClose_Click(object sender, EventArgs e)
        {
            if(settingsForm.GetKeepHistory())
            {
                OutputLogFile();
            }

            Application.Exit();
        }

        private void buttonClose_MouseOver(object sender, EventArgs e)
        {
            buttonClose.BackgroundImage = Properties.Resources.close_button_FFFFFF;
        }

        private void buttonClose_Leave(object sender, EventArgs e)
        {
            buttonClose.BackgroundImage = Properties.Resources.close_button_c0c0c0;
        }



        /* 'Home' button functions */
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

        private void buttonHome_Leave(object sender, EventArgs e)
        {
            buttonHome.BackgroundImage = Properties.Resources.home_button_c0c0c0;
        }



        /* 'Settings' button functions */
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            HideOutputScreen();
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

        private void buttonSettings_MouseOver(object sender, EventArgs e)
        {
            buttonSettings.BackgroundImage = Properties.Resources.settings_button_FFFFFF;
        }

        private void buttonSettings_Leave(object sender, EventArgs e)
        {
            buttonSettings.BackgroundImage = Properties.Resources.settings_button_c0c0c0;
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

        /* Support Functions */

        private void UpdateTitle(string newTitle)
        {
            labelTitle.Text = newTitle;
        }



        private void HideErrorMessage()
        {
            labelErrorMessage.Visible = false;
        }



        private void HideQuota()
        {
            labelQuotaTitle.Visible = false;
            labelBitsLeft.Visible = false;
            labelRequestsLeft.Visible = false;
        }



        private void ShowQuota()
        {
            labelQuotaTitle.Visible = true;
            labelBitsLeft.Visible = true;
            labelRequestsLeft.Visible = true;
        }



        private void HideNumber()
        {
            labelNumberDisplay.Visible = false;
            labelMultipleNumbers.Visible = false;
        }



        private void ShowNumber()
        {
            labelNumberDisplay.Visible = true;
            labelMultipleNumbers.Visible = true;
        }



        private void HideOutputScreen()
        {
            HideQuota();
            HideNumber();
            HideErrorMessage();
        }



        private void ChangeCursor()
        {
            Cursor.Current = 
                Cursor.Current == Cursors.Default ? 
                Cursors.WaitCursor : Cursors.Default;
        }
    }
}
