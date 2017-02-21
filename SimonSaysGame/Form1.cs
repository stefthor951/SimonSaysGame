//Stefan A Thorburn
//Simon Says Game
//completed February 21 2017
//Color-based memorization program

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonSaysGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //makes the patternLength global so it can be used in multiple screens
        public static int  patternLength = 1;

        //loads the main menu
        private void Form1_Load(object sender, EventArgs e)
        {
            MainScreen ms = new MainScreen();
            this.Controls.Add(ms);
        }
    }
}
