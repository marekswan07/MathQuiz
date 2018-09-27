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
        int minuend;
        int subtrahend;
        int multVal1;
        int multVal2;
        int divVal1;
        int divVal2;

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

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(0, minuend);

            multVal1 = randomizer.Next(2, 11);
            multVal2 = randomizer.Next(2, 11);

            divVal1 = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            divVal2 = divVal1 * temporaryQuotient;


            //converts ints to Strings and displays
            addLeftLabel.Text = addend1.ToString();
            addRightLabel.Text = addend2.ToString();

            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();

            multLeftLabel.Text = multVal1.ToString();
            multRightLabel.Text = multVal2.ToString();

            divLeftLabel.Text = divVal2.ToString();
            divRightLabel.Text = divVal1.ToString();

            //ensures clear values before adding to it
            sumAdd.Value = 0;
            sumMinus.Value = 0;
            sumDiv.Value = 0;
            sumMult.Value = 0;


            //start the timer
            timeLeft = 30;
            timeLabel.Text = "30 Seconds";
            timer1.Start();
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
            if (checkTheAnswer())
            {
                //every second checks the answers, if true then stops the quiz and displays message
                timer1.Stop();
                MessageBox.Show("You got all the answers right!","Congratulations!");
                btnStart.Enabled = true;


            }
            else if (timeLeft > 0){
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";

                //added this nested if for hightlighting the time left when close to finish
                if (timeLeft < 10)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }


            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sumAdd.Value = addend1 + addend2;
                sumMinus.Value = minuend - subtrahend;
                sumMult.Value = multVal1 * multVal2;
                sumDiv.Value = divVal2 / divVal1;
                btnStart.Enabled = true;
                timeLabel.BackColor = Color.Empty; // reset the color
            }
        }


        private bool checkTheAnswer()
        {
            if ((addend1 + addend2 == sumAdd.Value)
                &&(minuend - subtrahend == sumMinus.Value)
                &&(multVal1 * multVal2 == sumMult.Value)
                &&(divVal2 / divVal1 == sumDiv.Value))
            {
                return true;
            }

            else{
                return false;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }


        //custom event created for displaying a date in a specified form, event activated on form load
        private void display_Date(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            lblCurrentDate.Text = (currentDate.ToString("MMMM dd, yyyy") + ".");
        }

    }


}
