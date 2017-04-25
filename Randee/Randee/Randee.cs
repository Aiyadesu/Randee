﻿using System;
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

        /* Other Pages/Forms */
        private Settings settingsForm = new Settings();

        /* Randee Members */
        private string historyPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\history.txt";
        private string dateTimeAppOpened = "Numbers generated history from: " + DateTime.Now.ToString() + "\r\n";
        private string generatedNumbers;



        /* Externally implemented functions (i.e from 'user32.dll') */
        [DllImport("user32.dll")] 
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();



        // Default Constructor
        public Randee()
        {
            InitializeComponent();

            Console.WriteLine(dateTimeAppOpened);
        }



        /* Event Handlers */
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
                string number = ShuffleHeaven.GenerateNumber((int)minRangeInput.Value, (int)maxRangeInput.Value).ToString();

                numberDisplay.Text = "Your random number is " + number;

                AddToLog(number);

                Console.WriteLine("Current log is: " + generatedNumbers);
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



        private void settingsButton_Click(object sender, EventArgs e)
        {
            settingsForm.Location = Location;

            settingsForm.Show(this);
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
            generatedNumbers += number + settingsForm.GetSeperator();
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
    }
}
