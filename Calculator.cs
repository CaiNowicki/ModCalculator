using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Calculator
{
    // Cai Nowicki
    // GUI assignment
    // started working at 10:45 PM on 7/19
    // following a tutorial on Microsoft website
    // https://learn.microsoft.com/en-us/visualstudio/designers/walkthrough-windows-forms-designer?view=vs-2022
    // I expect the finished product to take about half an hour

    // 11:25, completed the tutorial but it only covers the UI portion
    // will need to implement actual functionality on my own
    // additional tutorial found, adjusted to fit my code
    // https://tutorialslink.com/Articles/Calculator-in-Windows-Form-using-Csharp/1446

    // 12:15, finished coding but need to debug
    // checked code with help of ChatGPT and corrected errors
    // 12:30, code complete and functional! 
    // could definitely use some additional functionality to display the numbers as you go
    // also want user to be able to enter numbers directly into the calculator
    // but it works now

    //adding History box functionality 

    //TODO: Convert all the different number buttons into a single method
    //which is called whenever the button is pushed
    //with a parameter of the appropriate number/operation sent to method


    public partial class Calculator : Form
    {
        private int count;
        private float num;
        private float ans;
        private List<string> history;

        public Calculator()
        {
            InitializeComponent();
            history = new List<string>();
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        // I will need to add a line of code to each button to display it in the 
        //"History" box and then move down as the next value is entered
        //and a way to erase it from view when it gets to the bottom
        //(or replace the box with a scrolling type to keep everything)

        //all buttons need exception handling to prevent bad characters from crashing the whole program

        private void sevenButton_Click(object sender, EventArgs e)
            // each number button just adds the correct number to the inputBox value
        {
            inputBox.Text = inputBox.Text + 7;
            history.Add(sevenButton.Text);
            UpdateHistoryBox();

        }


        private void eightButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = inputBox.Text + 8;
            history.Add(eightButton.Text);
            UpdateHistoryBox();
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = inputBox.Text + 9;
            history.Add(nineButton.Text);
            UpdateHistoryBox();
        }

        private void divisionButton_Click(object sender, EventArgs e)
        {
            // the arithmetic buttons tell the compute method what to do with the numbers
            // during the compute step
            try
            {
                num = float.Parse(inputBox.Text);
                inputBox.Clear();
                inputBox.Focus();
                count = 4;
                if (!string.IsNullOrEmpty(inputBox.Text) )
                {
                    history.Add(inputBox.Text);
                    history.Add(divisionButton.Text);
                    inputBox.Clear();
                    inputBox.Focus();
                    UpdateHistoryBox();
                }
                    }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Input, please try again.");
                inputBox.Clear();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // this resets the value of the inputBox string
            inputBox.Text = "";
            //TODO: add "clear history" button to clear the history box too
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            compute();
            history.Add("=" + inputBox.Text);
            UpdateHistoryBox();

        }

        private void additionButton_Click(object sender, EventArgs e)
        {
            try
            {
                num = float.Parse(inputBox.Text);
                inputBox.Clear();
                inputBox.Focus();
                count = 1;
                if (!string.IsNullOrEmpty(inputBox.Text))
                {
                    history.Add(inputBox.Text);
                    history.Add(additionButton.Text);
                    inputBox.Clear();
                    inputBox.Focus();
                    UpdateHistoryBox();
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Input, please try again.");
                inputBox.Clear();
            }
        }

        private void subtractionButton_Click(object sender, EventArgs e)
        {
            try
            {
                num = float.Parse(inputBox.Text);
                inputBox.Clear();
                inputBox.Focus();
                count = 2;
                if (!string.IsNullOrEmpty(inputBox.Text)) 
                { history.Add(inputBox.Text);
                history.Add(subtractionButton.Text);
                    inputBox.Clear();
                    inputBox.Focus();
                    UpdateHistoryBox();
                }
            }
            catch (FormatException )
            {
                MessageBox.Show("Invalid Input, please try again.");
                inputBox.Clear();
            }
        }

        private void multiplicationButton_Click(object sender, EventArgs e)
        {
            try
            {
                num = float.Parse(inputBox.Text);
                inputBox.Clear();
                inputBox.Focus();
                count = 3;
                if (!string.IsNullOrEmpty(inputBox.Text))
                { history.Add(inputBox.Text);
                history.Add(multiplicationButton.Text);
                inputBox.Clear();
                inputBox.Focus();
                    UpdateHistoryBox();
                }
            }
            catch (FormatException)
            {

                MessageBox.Show("Invalid Input, please try again.");
                inputBox.Clear();
            }
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = inputBox.Text + 6;
            history.Add(sixButton.Text);
            UpdateHistoryBox();

        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = inputBox.Text + 3;
            history.Add(threeButton.Text);
            UpdateHistoryBox();
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = inputBox.Text + ".";
        }

        private void changeSignButton_Click(object sender, EventArgs e)
        {
            //this changes a positive number to negative or negative number to positive
            //no exception handling needed here, this accounts for positive, negative, and 0
            //this broke after the random number input - why 

            //fixing this bug by changing the way I attack this line
            //if (char.Parse(inputBox.Text.Substring(0)) == char.Parse("-"))

            //TODO: figure out how this affects the history box
            if (inputBox.Text.StartsWith("-"))
            {
                inputBox.Text = inputBox.Text.Substring(1);
            }
            else if (inputBox.Text == "0")
            {
                inputBox.Text = "0";
            }
            else
            {
                inputBox.Text = "-" + inputBox.Text;
            }
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = inputBox.Text + 2;
            history.Add(twoButton.Text);
            UpdateHistoryBox();
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = inputBox.Text + 5;
            history.Add(fiveButton.Text);
            UpdateHistoryBox();
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = inputBox.Text + 4;
            history.Add(fourButton.Text);
            UpdateHistoryBox();
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = inputBox.Text + 1;
            history.Add(oneButton.Text);
            UpdateHistoryBox();
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = inputBox.Text + 0;
            history.Add(zeroButton.Text);
            UpdateHistoryBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // to include here - user can enter numbers directly into textbox
            // requires exception handling for non-numeric characters
        }

        public void compute()
        {
            float inputValue = float.Parse(inputBox.Text);
            // this method checks the value of the "count" variable, which tells it which case to follow
            // then change the value of the inputBox to the result
            try
            {
                switch (count)
                {
                    case 1:
                        ans = num + inputValue;
                        break;
                    case 2:
                        ans = num - inputValue;
                        break;
                    case 3:
                        ans = num * inputValue;
                        break;
                    case 4:
                        ans = num / inputValue;
                        break;
                    default:
                        break;

                }
            }
            //exception handling here
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Cannot divide by zero");
                inputBox.Text = "";
            }
            //adding more exception handling here
            catch (FormatException)
            {
                MessageBox.Show("Invalid Input, please try again");
                inputBox.Text = "";
            }
            catch (OverflowException)
            {
                MessageBox.Show("Value outside acceptable range, please try again");
                inputBox.Text = "";
            }
            inputBox.Text = ans.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 1000000);
            // this gives me a random number between -1000000 and 1000000
            // with a 50% chance  of it being negative
            // and displays it in the text box

            if (random.Next(2) == 0)
            {
                randomNumber *= -1;
            }
            inputBox.Text = randomNumber.ToString();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void Calculator_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["OpenScreen"] != null)
            {
                Form openScreenForm = Application.OpenForms["OpenScreen"];
                openScreenForm.Show();

            }
        }

        private void label1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void UpdateHistoryBox()
            //this feature still isn't working even with added method calls

        {
            historyBox.Text = string.Join(" ", history);
        }
    }
}
