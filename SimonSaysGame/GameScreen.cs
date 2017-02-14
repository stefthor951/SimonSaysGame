using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SimonSaysGame
{
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {

            InitializeComponent();

        }

        int patternLength = 10;
        Random randNum = new Random();
        List<int> playerGuess = new List<int>();

        private void GameScreen_Load(object sender, EventArgs e)
        {
            Thread.Sleep(2500);
            Refresh();
            patternGenerate();
        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            playerGuess.Add(0);
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            playerGuess.Add(1);
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            playerGuess.Add(2);
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            playerGuess.Add(3);
        }

        public void patternGenerate()
        {
            greenButton.Enabled = false;
            redButton.Enabled = false;
            blueButton.Enabled = false;
            yellowButton.Enabled = false;

            for (int i = 0; i < patternLength; i++)
            {
                Form1.buttonPattern.Add(randNum.Next(0, 4));
            }
            for (int i = 0; i < Form1.buttonPattern.Count; i++)
            {
                if (Form1.buttonPattern[i] == 0)
                {
                    greenButton.BackColor = Color.LimeGreen;
                    Refresh();
                    Thread.Sleep(650);
                    greenButton.BackColor = Color.Green;
                    Refresh();
                }
                if (Form1.buttonPattern[i] == 1)
                {
                    redButton.BackColor = Color.Red;
                    Refresh();
                    Thread.Sleep(650);
                    redButton.BackColor = Color.DarkRed;
                    Refresh();
                }
                if (Form1.buttonPattern[i] == 2)
                {
                    blueButton.BackColor = Color.SkyBlue;
                    Refresh();
                    Thread.Sleep(650);
                    blueButton.BackColor = Color.DodgerBlue;
                    Refresh();

                }
                if (Form1.buttonPattern[i] == 3)
                {
                    yellowButton.BackColor = Color.Khaki;
                    Refresh();
                    Thread.Sleep(650);
                    yellowButton.BackColor = Color.Gold;
                    Refresh();
                }
            }

            greenButton.Enabled = true;
            redButton.Enabled = true;
            blueButton.Enabled = true;
            yellowButton.Enabled = true;
        }


    }
}
