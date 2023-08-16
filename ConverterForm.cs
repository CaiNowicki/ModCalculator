using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class ConverterForm : Form
    {
        //this segment of the code creates a dictionary 
        //of all the letters A-Za-z to cover all bases up to 62
        private static Dictionary<char, int> digitValues = GenerateDigitValuesDictionary();

        private static Dictionary<char, int> GenerateDigitValuesDictionary()
        {
            Dictionary<char, int> values = new Dictionary<char, int>();

            // Digits 0-9
            for (int i = 0; i <= 9; i++)
            {
                values.Add(i.ToString()[0], i);
            }

            // Uppercase letters A-Z (starting from 10)
            for (char c = 'A'; c <= 'Z'; c++)
            {
                values.Add(c, c - 'A' + 10);
            }

            // Lowercase letters a-z (starting from 36)
            for (char c = 'a'; c <= 'z'; c++)
            {
                values.Add(c, c - 'a' + 36);
            }

            return values;
        }

        public ConverterForm()
        {
            InitializeComponent();
        }

        private void ConverterForm_FormClosed(object sender, FormClosedEventArgs e)
            //this section of code re-opens the menu screen if the converter is closed
        {
            if (Application.OpenForms["OpenScreen"]  != null)
            {
                Form openScreenForm = Application.OpenForms["OpenScreen"];
                openScreenForm.Show();

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)

        {
           //need to add error checking here to ensure that the  value in inputBox isn't greater than inputBase
            
        }

        private void ConverterForm_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
            //this checks that the user input is within acceptable charset
            //will have to do further checks to see if it matches the charset for the chosen base
        {
            if (Regex.IsMatch(textBox1.Text, "^[0-9A-Za-z]*$"))
            {
                
            }
            else
            {
                MessageBox.Show("Allowed characters for input are digits 0-9 and letters A-Z or a-z.");
            }
        }


        private int ConvertDigitToValue(char digit)
        {
            if (digitValues.ContainsKey(digit))
                return digitValues[digit];

            throw new ArgumentException("Invalid digit: " + digit);
        }
        public int ConvertBase10(string inputValue, int inputBase)
        {
            //calculations go here
            //need to get baseValue and inputValue
            //then convert to Base 10
            //give this result back to outputBox
            //error handling for invalid input of value > base goes here

            int result = 0;
            int power = 0;

            for (int i = inputValue.Length - 1; i >= 0; i--)
            {
                int digitValue = ConvertDigitToValue(inputValue[i]);
                if (AllDigitsLessThanBase(digitValue, inputBase))
                    {
                    result += digitValue * (int)Math.Pow(inputBase, power);
                    power++;
                }
                else
                {
                    MessageBox.Show("Error: Input value invalid for input base. Please try again.");
                    textBox1.Text = "";
                }
            }

            return result;

        }
        public bool AllDigitsLessThanBase(int inputValue, int inputBase)
            //this method confirms that input values are within parameters for the base selected
        {
            string inputValueStr = inputValue.ToString();
            foreach (char x in inputValueStr)
            {
                int digitValue = (int)char.GetNumericValue(x);
                if (digitValue > inputBase)
                {
                    return false;
                }
            }
            return true;
            }
       
        private void convertButton_Click(object sender, EventArgs e)
        {
            string inputValue = textBox1.Text;
            int inputBase = listBox1.SelectedIndex + 2;
            try
            {
                
                int base10Value = ConvertBase10(inputValue, inputBase);
                string convertedValue = Convert.ToString(base10Value);
                textBox2.Text = convertedValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Calculations - Please Try Again");
                textBox2.Text = "";
                textBox1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
