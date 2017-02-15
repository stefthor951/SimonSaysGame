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

        int patternLength = 1;
        int numGuess = 0;
        Random randNum = new Random();
        List<int> playerGuess = new List<int>();

        private void GameScreen_Load(object sender, EventArgs e)
        {
            Thread.Sleep(2500);
            Refresh();
            Thread.Sleep(500);
            patternGenerate();
        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            playerGuess.Add(0);
            playerAction();
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            playerGuess.Add(1);
            playerAction();
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            playerGuess.Add(2);
            playerAction();
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            playerGuess.Add(3);
            playerAction();
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
                    Thread.Sleep(650);
                }
                if (Form1.buttonPattern[i] == 1)
                {
                    redButton.BackColor = Color.Red;
                    Refresh();
                    Thread.Sleep(650);
                    redButton.BackColor = Color.DarkRed;
                    Refresh();
                    Thread.Sleep(650);
                }
                if (Form1.buttonPattern[i] == 2)
                {
                    yellowButton.BackColor = Color.Khaki;
                    Refresh();
                    Thread.Sleep(650);
                    yellowButton.BackColor = Color.Gold;
                    Refresh();
                    Thread.Sleep(650);
                }
                if (Form1.buttonPattern[i] == 3)
                {
                    blueButton.BackColor = Color.SkyBlue;
                    Refresh();
                    Thread.Sleep(650);
                    blueButton.BackColor = Color.DodgerBlue;
                    Refresh();
                    Thread.Sleep(650);

                }
                
            }

            greenButton.Enabled = true;
            redButton.Enabled = true;
            blueButton.Enabled = true;
            yellowButton.Enabled = true;
        }

        public void playerAction()
        {
            numGuess++;
            for (int i = 0; i < numGuess; i++)
            {
                //int q = playerGuess[i];
                //int e = Form1.buttonPattern[i];

                //if (playerGuess[i] == Form1.buttonPattern[i])
                //{

                //    //TODO play sound effect and proceed
                //    greenButton.Visible = false;
                //    Refresh();

                //}
                
                //this will check all of the player's guesses against the actual pattern, if any are incorrect then the player loses
                if (playerGuess[i] != Form1.buttonPattern[i])
                {
                    //TODO play losing sound effect and go to gameover screen
                    Form f = this.FindForm();
                    f.Controls.Remove(this);

                    GameOverScreen lose = new GameOverScreen();
                    f.Controls.Add(lose);

                }
            
            }

            if (numGuess == Form1.buttonPattern.Count)
            {
                Form1.buttonPattern.Clear();
                playerGuess.Clear();
                patternLength++;
                numGuess = 0;

                patternGenerate();
            }
        }
    }
}
