using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public static string contentA = "", contentB = "", operation = null;
        public static string curNumber = "";
        public static double curRes = 0;
        public static double memorySave = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button wasPressed = sender as Button;
            string digit = wasPressed.Text;
            curNumber += digit;
            Output.Text = curNumber;
        }

        private void buttonOperation(object sender, EventArgs e)
        {
            Button wasPressed = sender as Button;
            operation = wasPressed.Text;
            double convertB = 0;
            if (curNumber != "")
            {
                convertB = double.Parse(curNumber);
            }
            else
            {
                convertB = curRes;
            }
            double resultOfCalc = 0;
            switch (operation)
            {
                case "√":
                    resultOfCalc = Math.Sqrt(convertB);
                    Clear(resultOfCalc, 0);
                    Output.Text = resultOfCalc.ToString();
                    break;
                case "x ^ 2":
                    resultOfCalc = convertB * convertB;
                    Clear(resultOfCalc, 0);
                    Output.Text = resultOfCalc.ToString();
                    break;
                case "1/x":
                    resultOfCalc = (1 / convertB);
                    Clear(resultOfCalc, 0);
                    Output.Text = resultOfCalc.ToString();
                    break;
                case "log":
                    resultOfCalc = Math.Log(convertB);
                    Clear(resultOfCalc, 0);
                    Output.Text = resultOfCalc.ToString();
                    break;
                case "sin":
                    resultOfCalc = Math.Sin(convertB);
                    Clear(resultOfCalc, 0);
                    Output.Text = resultOfCalc.ToString();
                    break;
                case "cos":
                    resultOfCalc = Math.Cos(convertB);
                    Clear(resultOfCalc, 0);
                    Output.Text = resultOfCalc.ToString();
                    break;
                default:
                    contentA = curNumber;
                    curNumber = "";
                    break;
            }
        }

        private void ClearData(object sender, EventArgs e)
        {
            curNumber = "";
            curRes = 0;
            contentA = "";
            contentB = "";
            Output.Text = "0";
        }

        private void Data(object sender, EventArgs e)
        {
            Button wasPressed = sender as Button;
            string name = wasPressed.Text;

            switch (name)
            {
                case "MC":
                    memorySave = 0;
                    break;
                case "MR":
                    string res = memorySave.ToString();
                    Output.Text = res;
                    break;
                case "M+":
                    memorySave += int.Parse(Output.Text);
                    break;
                case "M-":
                    memorySave -= int.Parse(Output.Text);
                    break;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Output.Text = Output.Text.Remove(Output.Text.Length - 1);
            if (Output.Text.Length <= 0)
                Output.Text = "0";
        }

        private void buttonOutput(object sender, EventArgs e)
        {
            double resultOfCalc = 0, convertA = 0, convertB = 0;
            if (contentA == "")
            {
                convertA = curRes;
            }
            else convertA = double.Parse(contentA);
            if (curNumber == "") convertB = double.Parse(contentB);
            else convertB = double.Parse(curNumber);
            switch (operation)
            {
                case "+":
                    resultOfCalc = convertA + convertB;
                    Clear(resultOfCalc, convertB);
                    break;
                case "-":
                    resultOfCalc = convertA - convertB;
                    Clear(resultOfCalc, convertB);
                    break;
                case "/":
                    resultOfCalc = convertA / convertB;
                    Clear(resultOfCalc, convertB);
                    break;
                case "*":
                    resultOfCalc = convertA * convertB;
                    Clear(resultOfCalc, convertB);
                    break;
                case "√":
                    resultOfCalc = Math.Sqrt(convertB);
                    Clear(resultOfCalc, convertB);
                    break;
                case "x ^ 2":
                    resultOfCalc = convertB * convertB;
                    Clear(resultOfCalc, convertB);
                    break;
                case "1/x":
                    resultOfCalc = (1 / convertB);
                    Clear(resultOfCalc, convertB);
                    break;
            }

            Output.Text = resultOfCalc.ToString();
        }
        public static void Clear(double x, double xB)
        {
            contentA = "";

            contentB = xB.ToString();
            curNumber = "";

            curRes = x;
        }
    }
}
