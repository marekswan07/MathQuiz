using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        //Adding randomizer obejet
        Random randomizer = new Random();

        //int vars for all the problems
        int addend1;
        int addend2;

        //timer variable
        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        public void StartTheQuiz()
        {
            //values assinged to the math problems
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //converts ints to Strings and displays
            addLeftLabel.Text = addend1.ToString();
            addRightLabel.Text = addend2.ToString();

            //ensures clear values before adding to it
            sumAdd.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // event handler /listener for when the button is pressed
            StartTheQuiz();
            btnStart.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //handler for the timer
            if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sumAdd.Value = addend1 + addend2;
                btnStart.Enabled = true;
            }
        }
    }
}
