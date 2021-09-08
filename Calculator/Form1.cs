using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Calculator
{
    public partial class Form1 : Form
    {
        Double valueA = 0;
        Double valueB = 0;
        Double valueC = 0;
        Double resultValue = 0;
        bool addition = false;
        bool subtraction = false;
        bool multiplication = false;
        bool division = false;
        bool performOperation = true;

        AboutBox1 myAboutBox = new AboutBox1();

        public Form1()
        {
            InitializeComponent();
        }
 

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)               //Events för siffer-knappar
        {
            if (textBox_Result.Text == "0")
            {
                textBox_Result.Clear();
            }

            if (label_Result.Text != "= ")
            {
                label_Result.Text = "= ";
            }

            if (!performOperation)
            {
                label_stored_value.Text = "";
            }

            performOperation = true;            
            Button button = (Button)sender;            
            textBox_Result.Text = textBox_Result.Text + button.Text;
            
            


        }

        private void operator_Click(object sender, EventArgs e)     //Events för operanderna
        {
            Button button = (Button)sender;
                        
            if (textBox_Result.Text == "")      //För att en bugg inte ska uppstå genom att försöka pars:a ett nullvärde i textrutan.
            {
                textBox_Result.Text = "0";
                    
            }


            if (valueA == 0)
            {
                valueA = Convert.ToDouble(textBox_Result.Text);
            }
            else
            {
                valueB = Convert.ToDouble(textBox_Result.Text);
            }

            if (label_stored_value.Text == "")
            {
                label_stored_value.Text = "" + valueA;
            }


            if (addition)       //Genomför addition av de tidigare två angivna talen.
            {
                valueC = valueA + valueB;
                valueA = valueC;
                valueB = 0;
                label_stored_value.Text = "" + valueA;
            }

            if (subtraction)       //Genomför subtraktion av de tidigare två angivna talen.
            {
                valueC = valueA - valueB;
                valueA = valueC;
                valueB = 0;
                label_stored_value.Text = "" + valueA;
            }

            if (multiplication)       //Genomför multiplikation av de tidigare två angivna talen.
            {
                valueC = valueA * valueB;
                valueA = valueC;
                valueB = 0;
                label_stored_value.Text = "" + valueA;
            }

            if (division)       //Genomför division av de tidigare två angivna talen.
            {
                valueC = valueA / valueB;
                valueA = valueC;
                valueB = 0;
                label_stored_value.Text = "" + valueA;
            }


            if (button.Text == "+")                                                          //Anger ett nytt boolvärde för nästa operation//
            {
                addition = true;
                subtraction = false;
                multiplication = false;
                division = false;
                label_stored_value.Text = label_stored_value.Text + "+";
                textBox_Result.Clear();
            }
            if (button.Text == "-") 
            {
                addition = false;
                subtraction = true;
                multiplication = false;
                division = false;
                label_stored_value.Text = label_stored_value.Text + "-";
                textBox_Result.Clear();
            } 
            if (button.Text == "*")
            {
                addition = false;
                subtraction = false;
                multiplication = true;
                division = false;
                label_stored_value.Text = label_stored_value.Text + "*";
                textBox_Result.Clear();
            }
            if (button.Text == "/")
            {
                addition = false;
                subtraction = false;
                multiplication = false;
                division = true;
                label_stored_value.Text = label_stored_value.Text + "/";
                textBox_Result.Clear();
            }                                                                           ///////////////////////////////////////////////////////////////
        }
        private void buttonEquals_Click(object sender, EventArgs e)     //Events för Är-Lika-Med-Knappen.
        {
            valueB = double.Parse(textBox_Result.Text);
            if (addition)
            {
                resultValue = valueA + valueB;
                label_Result.Text = label_Result.Text + " " + resultValue;
                addition = false;
                subtraction = false;
                multiplication = false;
                division = false;
            }
            else
                if (subtraction)
            {
                resultValue = valueA - valueB;
                label_Result.Text = label_Result.Text + " " + resultValue;
                addition = false;
                subtraction = false;
                multiplication = false;
                division = false;
            }
            else
                if (multiplication)
                {
                resultValue = valueA * valueB; ;
                label_Result.Text = label_Result.Text + " " + resultValue;
                addition = false;
                subtraction = false;
                multiplication = false;
                division = false;
                }
            else
                if (division)
                {
                resultValue = valueA / valueB;
                label_Result.Text = label_Result.Text + " " + resultValue;
                addition = false;
                subtraction = false;
                multiplication = false;
                division = false;
                }

            label_stored_value.Text = label_stored_value.Text + valueB;
            textBox_Result.Text = "";
            performOperation = false;

        }
        private void buttonClearEntry_Click(object sender, EventArgs e)     //Events för CE-knappen
        {
            textBox_Result.Text = "0";
            label_Result.Text = "= ";
            valueA = 0;
        }
        private void buttonClear_Click(object sender, EventArgs e)      //Events för C-knappen.
        {
            textBox_Result.Text = "0";
            label_stored_value.Text = "";
            label_Result.Text = "= ";
            valueA = 0;
            valueB = 0;
            valueC = 0;
        }

        private void About_Click(object sender, EventArgs e)
        {
            myAboutBox.ShowDialog();
        }
    }
}
