using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonSaysGame
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            //prints the player's score / final pattern length
            outputLabel.Text = "Your final pattern length was: " + Form1.patternLength;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //proceeds to main menu
            Form f = this.FindForm();
            f.Controls.Remove(this);

            MainScreen main = new MainScreen();
            f.Controls.Add(main);
        }
    }
}
