using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator;
namespace Calculator
{
    public partial class OpenScreen : Form
    {
        public OpenScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculator calculatorForm = new Calculator();
            calculatorForm.Show();
            this.Hide();
        }

        private void OpenScreen_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConverterForm converterForm = new ConverterForm();
            converterForm.Show();
            this.Hide();
        }
    }
}
