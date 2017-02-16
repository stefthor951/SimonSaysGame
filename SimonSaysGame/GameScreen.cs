﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace SimonSaysGame
{
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {

            InitializeComponent();

        }

        int numGuess = 0;
        SoundPlayer[] sounds = new SoundPlayer[5];
        Random randNum = new Random();
        List<int> playerGuess = new List<int>();
        List<int> buttonPattern = new List<int>();

        private void GameScreen_Load(object sender, EventArgs e)
        {
            sounds[0] =  new SoundPlayer(Properties.Resources.green);
            sounds[1] = new SoundPlayer(Properties.Resources.red);
            sounds[2] = new SoundPlayer(Properties.Resources.yellow);
            sounds[3] = new SoundPlayer(Properties.Resources.blue);
            sounds[4] = new SoundPlayer(Properties.Resources.mistake);

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

            for (int i = 0; i < Form1.patternLength; i++)
            {
                buttonPattern.Add(randNum.Next(0, 4));
            }
            for (int i = 0; i < buttonPattern.Count; i++)
            {
                if (buttonPattern[i] == 0)
                {
                    greenButton.BackColor = Color.LimeGreen;
                    Refresh();
                    sounds[0].Play();
                    Thread.Sleep(650);
                    greenButton.BackColor = Color.Green;
                    Refresh();
                    Thread.Sleep(650);
                }
                if (buttonPattern[i] == 1)
                {
                    redButton.BackColor = Color.Red;
                    Refresh();
                    sounds[1].Play();
                    Thread.Sleep(650);
                    redButton.BackColor = Color.DarkRed;
                    Refresh();
                    Thread.Sleep(650);
                }
                if (buttonPattern[i] == 2)
                {
                    yellowButton.BackColor = Color.Khaki;
                    Refresh();
                    sounds[2].Play();
                    Thread.Sleep(650);
                    yellowButton.BackColor = Color.Gold;
                    Refresh();
                    Thread.Sleep(650);
                }
                if (buttonPattern[i] == 3)
                {
                    blueButton.BackColor = Color.SkyBlue;
                    Refresh();
                    sounds[3].Play();
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

               

                //this will check all of the player's guesses against the actual pattern, if any are incorrect then the player loses
                if (playerGuess[i] != buttonPattern[i])
                {
                    //TODO play losing sound effect and go to gameover screen
                    sounds[4].Play();
                    Thread.Sleep(1500);
                    Form f = this.FindForm();
                    f.Controls.Remove(this);

                    GameOverScreen lose = new GameOverScreen();
                    f.Controls.Add(lose);

                }
                if (playerGuess[i] == buttonPattern[i])
                {

                    //TODO play sound effect and proceed
                    sounds[playerGuess[i]].Play();
                    Refresh();

                }
            }

            if (numGuess == buttonPattern.Count)
            {
                buttonPattern.Clear();
                playerGuess.Clear();
                Form1.patternLength++;
                numGuess = 0;

                Thread.Sleep(1000);
                patternGenerate();

            }
        }
    }
}
