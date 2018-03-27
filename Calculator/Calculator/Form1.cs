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

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button wasPressed = sender as Button;
            string digit = wasPressed.Text;
            curNumber += digit;
            label1.Text = curNumber;
        }

        private void buttonOperation(object sender, EventArgs e)
        {
            Button wasPressed = sender as Button;
            operation = wasPressed.Text;
            double convertB = 0;
            if(curNumber != "")
            {
                convertB = double.Parse(curNumber);
            } else
            {
                convertB = curRes;
            }
            double resultOfCalc = 0;
            switch(operation)
            {
                case "√":
                    resultOfCalc = Math.Sqrt(convertB);
                    Clear(resultOfCalc,0);
                    label1.Text = resultOfCalc.ToString();
                    break;
                case "x ^ 2":
                    resultOfCalc = convertB * convertB;
                    Clear(resultOfCalc, 0);
                    label1.Text = resultOfCalc.ToString();
                    break;
                case "1/x":
                    resultOfCalc = (1 / convertB);
                    Clear(resultOfCalc, 0);
                    label1.Text = resultOfCalc.ToString();
                    break;
                case "log":
                    resultOfCalc = Math.Log(convertB);
                    Clear(resultOfCalc, 0);
                    label1.Text = resultOfCalc.ToString();
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
            label1.Text = "0";
        }

        private void Data(object sender, EventArgs e)
        {
            Button wasPressed = sender as Button;
            string name = wasPressed.Text;

            FileStream fs = new FileStream(@"dataCalc.bin",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            FileStream fs1 = new FileStream(@"dataCalc.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs1);

            switch (name)
            {
                case "mc":
                    fs = new FileStream(@"data.bin", FileMode.Create, FileAccess.ReadWrite);
                    break;
                case "m":
                    string res = sr.ReadToEnd();
                    label1.Text = res;
                    break;
                case "+m":
                    sw.WriteLine(curRes);
                    break;
                case "-m":
                    break;
            }
            fs.Close();
            fs1.Close();
            sw.Close();
            sr.Close();
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
            switch(operation)
            {
                case "+":
                    resultOfCalc = convertA + convertB;
                    Clear(resultOfCalc,convertB);
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

            label1.Text = resultOfCalc.ToString();
        }
        public static void Clear(double x,double xB)
        {
            contentA = "";

            contentB = xB.ToString();
            curNumber = "";

            curRes = x;
        }
    }
}
