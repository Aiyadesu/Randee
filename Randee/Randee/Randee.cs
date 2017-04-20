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
        /* Move Window without 'Titlebar' in C# 
         * Source: https://www.codeproject.com/Articles/11114/Move-window-form-without-Titlebar-in-C
         */
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public const string API_KEY = "RANDOM_ORG_API";

        private string appDirectory = Path.GetDirectoryName(Application.ExecutablePath);

        /* Externally implemented functions (i.e from 'user32.dll') */
        [DllImport("user32.dll")] 
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();



        // Default Constructor
        public Randee()
        {
            InitializeComponent();
            CreateSettingsFile();
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



        /* 
         * Creates a file to store settings if there is no settings currently set, otherwise read from the current settings
         * Source: https://msdn.microsoft.com/en-us/library/d62kzs03(v=vs.110).aspx
         */
        private void CreateSettingsFile()
        {
            // The path to create or find the settings file
            string settingsPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\settings.txt";

            // Used to store the settings
            string settings = "";

            /* Current settings already exist */
            // Check if settings are already set
            if(File.Exists(settingsPath))
            {

                // Open the 'settings.txt' file and then store the contents of the file in a string
                using (StreamReader streamReader = File.OpenText(settingsPath))
                {

                    string currentLine = "";
                    settings = "";

                    while ((currentLine = streamReader.ReadLine()) != null)
                    {
                        settings += currentLine;
                    }

                }

                return;

            }



            /* No current settings detected */
            // Adds whether the "RANDOM_ORG_API" environment variable is found or not to the settings
            settings = "RANDOM_ORG_API = " + (Environment.GetEnvironmentVariable(API_KEY, EnvironmentVariableTarget.User) == null ? "0" : "1") + "\r\n";

            // Create a 'settings.txt' file that stores the users settings
            using (FileStream fileStream = File.Create(settingsPath))
            {
                Byte[] settingsData = new UTF8Encoding(true).GetBytes(settings);
                fileStream.Write(settingsData, 0, settingsData.Length);
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();

            settingsForm.Location = Location;

            settingsForm.Show(this);
        }
    }
}
