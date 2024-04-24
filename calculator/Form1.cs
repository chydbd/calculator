using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public string numinput;
        public double numtem = 0;

        public double num1 = 0;
        public double num2 = 0;
        public double result = 0;
        public double memory = 0;
        public int a = 1;

        public int calc = 0;
        
        public bool num2using = false;
        public bool calced = false;

        public Form1()
        {
            InitializeComponent();
            label1.Text = result.ToString();
        }
        public void numprint()
        {
            if (num2using)
            {
                label1.Text = num2.ToString();
            }
            else
            {
                label1.Text = num1.ToString();
            }
        }

        public void numchange()
        {
            if (num2using)
            {
                num2 = double.Parse(numinput);
            }
            else
            {
                num1 = double.Parse(numinput);
            }
            numprint();
        }

        public void numrechange()
        {
            if (num2using)
            {
                numinput = num2.ToString();
            }
            else
            {
                numinput = num1.ToString();
            }
            numprint();
        }

        public void numadd(char input)
        {
            numinput += input;
            numchange();
        }

        public void labelprint(string calc)
        {
            if (calced)
            {
                label2.Text = result.ToString() + calc;
            }
            else
            {
                label2.Text = num1.ToString() + calc;
            }
            calced = true;
        }

        public void equal()
        {
            switch (calc)
            {
                case 1:
                    result = num1 + num2;
                    num1 = result;
                    break;
                case 2:
                    result = num1 - num2;
                    num1 = result;
                    break;
                case 3:
                    result = num1 * num2;
                    num1 = result;
                    break;
                case 4:
                    if(num2 == 0)
                    {
                        MessageBox.Show("除数不能为0");
                        break;
                    }
                    result = num1 / num2;
                    num1 = result;
                    break;
                case 5:
                    result = Math.Pow(num1,num2);
                    num1 = result;
                    break;
                case 6:
                    result = Math.Pow(num2, 1/num1);
                    num1 = result;
                    break;
                case 7:
                    result = Math.Log(num1, num2);
                    num1 = result;
                    break;
                case 8:
                    result = num1 % num2;
                    num1 = result;
                    break;
            }
        }

        private double factorial(double n)
        {
            if(n != (int)n)
            {
                return n;
            }
            else
            {
                if (n <= 1 && n >= 0)
                {
                    return 1;
                }
                else
                {
                    try
                    {
                        return n * factorial(n - 1);
                    }
                    catch (StackOverflowException)
                    {
                        MessageBox.Show("溢出");
                        return n;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numadd('1');
        }

        private void button0_Click(object sender, EventArgs e)
        {
            numadd('0');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numadd('2');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numadd('3');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numadd('4');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numadd('5');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numadd('6');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numadd('7');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            numadd('8');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            numadd('9');
        }

        private void buttondot_Click(object sender, EventArgs e)
        {
            numadd('.');
            buttondot.Enabled = false;
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            numinput = "";
            if (num2using)
            {
                num2 = 0;
            }
            else
            {
                num1 = 0;
            }
            buttondot.Enabled = true;
            numprint();
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            result = 0;
            numinput = "";
            buttondot.Enabled = true;
            num2using = false;
            calced = false;
            numprint();
            label2.Text = "";
        }

        private void buttonbackspace_Click(object sender, EventArgs e)
        {
            try
            {
                numinput = numinput.Substring(0, numinput.Length - 1);
                if (numinput[numinput.Length - 1] == '.')
                {
                    numinput = numinput.Substring(0, numinput.Length - 1);
                    buttondot.Enabled = true;
                }
            }
            catch (IndexOutOfRangeException)
            {
                numinput = "0";
            }
            numchange();
        }

        private void buttonnegative_Click(object sender, EventArgs e)
        {
            if (num2using) num2 = -1 * num2;
            else num1 = -1 * num1;
            numrechange();
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            num2using = true;
            if (calced)
            {
                equal();
            }
            num2 = 0;
            numinput = "";
            buttondot.Enabled = true;
            labelprint("+");
            numprint();
            calc = 1;
        }

        private void buttonsubtract_Click(object sender, EventArgs e)
        {
            num2using = true;
            if (calced)
            {
                equal();
            }
            num2 = 0;
            numinput = "";
            buttondot.Enabled = true;
            labelprint("-");
            numprint();
            calc = 2;
        }

        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            num2using = true;
            if (calced)
            {
                equal();
            }
            num2 = 0;
            numinput = "";
            buttondot.Enabled = true;
            labelprint("*");
            numprint();
            calc = 3;
        }

        private void buttondivide_Click(object sender, EventArgs e)
        {   
            num2using = true;
            if (calced)
            {
                equal();
            }
            num2 = 0;
            numinput = "";
            buttondot.Enabled = true;
            labelprint("/");
            numprint();
            calc = 4;
        }

        private void buttonequal_Click(object sender, EventArgs e)
        {
            equal();
            calced = false;
            label1.Text = result.ToString();
            label2.Text = "";
        }

        private void buttoninverse_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                num2 = 1 / num2;
            }
            else
            {
                num1 = 1 / num1;
            }
            numrechange();
        }

        private void buttonpercent_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                num2 = num2 / 100;
            }
            else
            {
                num1 = num1 / 100;
            }
            numrechange();
        }

        private void buttonsqrt_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                num2 = Math.Sqrt(num2);
            }
            else
            {
                num1 = Math.Sqrt(num1);
            }
            numrechange();
        }

        private void buttonsquare_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                num2 = num2 * num2;
            }
            else
            {
                num1 = num1 * num1;
            }
            numrechange();
        }

        private void buttonfactorial_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                num2 = factorial(num2);
            }
            else
            {
                num1 = factorial(num1);
            }
            numrechange();
        }

        private void buttoncube_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                num2 = Math.Pow(num2,3);
            }
            else
            {
                num1 = Math.Pow(num1, 3);
            }
            numrechange();
        }

        private void button3sqrt_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                num2 = Math.Pow(num2, 1/3);
            }
            else
            {
                num1 = Math.Pow(num1, 1/3);
            }
            numrechange();
        }

        private void button10x_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                num2 = Math.Pow(10, num2);
            }
            else
            {
                num1 = Math.Pow(10, num1);
            }
            numrechange();
        }

        private void buttonln_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                num2 = Math.Log(num2);
            }
            else
            {
                num1 = Math.Log(num1);
            }
            numrechange();
        }

        private void buttonsin_Click(object sender, EventArgs e)
        {
            if (a == 1)
            {
                if (num2using)
                {
                    double angle;
                    angle = num2 * Math.PI / 180;
                    num2 = Math.Sin(angle);
                }
                else
                {
                    double angle;
                    angle = num1 * Math.PI / 180;
                    num1 = Math.Sin(angle);
                    
                }
                numrechange();
            }
            if(a==2)
            {
                if (num2using)
                {      
                     num2 = Math.Sin(num2);
                    num2 = Math.Round(num2, 8);
                }
                else
                {
                     num1 = Math.Sin(num1);
                    num1 = Math.Round(num1, 8);
                }
                numrechange();

            }
            if(a==3)
            {
                if (num2using)
                {
                    double angle;
                    angle = num2 * Math.PI / 200;
                    num2 = Math.Sin(angle);
                }
                else
                {
                    double angle;
                    angle = num1 * Math.PI / 200;
                    num1 = Math.Sin(angle);

                }
                numrechange();
            }
        }

        private void buttoncos_Click(object sender, EventArgs e)
        {
            if (a == 2)
            {
                if (num2using)
                {
                    num2 = Math.Cos(num2);
                }
                else
                {
                    num1 = Math.Cos(num1);
                }
                numrechange();

            }
            if(a==1)
            {
                if (num2using)
                {
                    double angle;
                    angle = num2 * Math.PI / 180;
                    num2 = Math.Cos(angle);
                }
                else
                {
                    double angle;
                    angle = num1 * Math.PI / 180;
                    num1 = Math.Cos(angle);
                }
                numrechange();
            }
            if(a==3)
            {
                if (num2using)
                {
                    double angle;
                    angle = num2 * Math.PI / 200;
                    num2 = Math.Cos(angle);
                }
                else
                {
                    double angle;
                    angle = num1 * Math.PI / 200;
                    num1 = Math.Cos(angle);
                }
                numrechange();
            }
        }

        private void buttontan_Click(object sender, EventArgs e)
        {
            if (a == 2)
            {
                if (num2using)
                {
                    num2 = Math.Tan(num2);
                }
                else
                {
                    num1 = Math.Tan(num1);
                }
                numrechange();
            }
            if(a==1)
            {
                if (num2using)
                {
                    double angle;
                    angle = num2 * Math.PI / 180;
                    num2 = Math.Tan(angle);
                }
                else
                {
                    double angle;
                    angle = num1 * Math.PI / 180;
                    num1 = Math.Tan(angle);
                }
                numrechange();
            }
            if(a==3)
            {
                if (num2using)
                {
                    double angle;
                    angle = num2 * Math.PI / 200;
                    num2 = Math.Tan(angle);
                }
                else
                {
                    double angle;
                    angle = num1 * Math.PI / 200;
                    num1 = Math.Tan(angle);
                }
                numrechange();
            }
        }

        private void buttonsinh_Click(object sender, EventArgs e)
        {
            if(a==2)
            {
                if (num2using)
                {
                    num2 = Math.Sinh(num2);
                }
                else
                {
                    num1 = Math.Sinh(num1);
                }
                numrechange();
            }
            if(a==1)
            {
                if (num2using)
                {
                    double angle;
                    angle = num2 * Math.PI / 180;
                    num2 = Math.Sinh(angle);
                }
                else
                {
                    double angle;
                    angle = num1 * Math.PI / 180;
                    num1 = Math.Sinh(angle);
                }
                numrechange();
            }
            if(a==3)
            {
                if (num2using)
                {
                    double angle;
                    angle = num2 * Math.PI / 200;
                    num2 = Math.Sinh(angle);
                }
                else
                {
                    double angle;
                    angle = num1 * Math.PI / 200;
                    num1 = Math.Sinh(angle);
                }
                numrechange();
            }
        }

        private void buttoncosh_Click(object sender, EventArgs e)
        {
           if(a==2)
            {
                if (num2using)
                {
                    num2 = Math.Cosh(num2);
                }
                else
                {
                    num1 = Math.Cosh(num1);
                }
                numrechange();
            }
           if(a==1)
            {
                if (num2using)
                {
                    double angle;
                    angle = num2 * Math.PI / 180;
                    num2 = Math.Cosh(angle);
                }
                else
                {
                    double angle;
                    angle = num1 * Math.PI / 180;
                    num1 = Math.Cosh(angle);
                }
                numrechange();
            }
           if(a==3)
            {
                if (num2using)
                {
                    double angle;
                    angle = num2 * Math.PI / 200;
                    num2 = Math.Cosh(angle);
                }
                else
                {
                    double angle;
                    angle = num1 * Math.PI / 200;
                    num1 = Math.Cosh(angle);
                }
                numrechange();
            }
        }

        private void buttontanh_Click(object sender, EventArgs e)
        {
            if(a==2)
            {
                if (num2using)
                {
                    num2 = Math.Tanh(num2);
                }
                else
                {
                    num1 = Math.Tanh(num1);
                }
                numrechange();
            }
            if(a==1)
            {
                if (num2using)
                {
                    double angle;
                    angle = num2 * Math.PI / 180;
                    num2 = Math.Tanh(angle);
                }
                else
                {
                    double angle;
                    angle = num1 * Math.PI / 180;
                    num1 = Math.Tanh(angle);
                }
                numrechange();
            }
            if(a==3)
            {
                if (num2using)
                {
                    double angle;
                    angle = num2 * Math.PI / 200;
                    num2 = Math.Tanh(angle);
                }
                else
                {
                    double angle;
                    angle = num1 * Math.PI / 200;
                    num1 = Math.Tanh(angle);
                }
                numrechange();
            }
        }

        private void buttonpi_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                num2 = num2 * Math.PI;
            }
            else
            {
                num1 = num1 * Math.PI;
            }
            numrechange();
        }

        private void buttonExp_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                num2 = Math.Pow(Math.E,num2);
            }
            else
            {
                num1 = Math.Pow(Math.E,num1);
            }
            numrechange();
        }

        private void buttonpower_Click(object sender, EventArgs e)
        {
            num2using = true;
            if (calced)
            {
                equal();
            }
            num2 = 0;
            numinput = "";
            buttondot.Enabled = true;
            labelprint("^");
            numprint();
            calc = 5;
        }

        private void buttonexraction_Click(object sender, EventArgs e)
        {
            num2using = true;
            if (calced)
            {
                equal();
            }
            num2 = 0;
            numinput = "";
            buttondot.Enabled = true;
            labelprint("√");
            numprint();
            calc = 6;
        }

        private void buttonlog_Click(object sender, EventArgs e)
        {
            num2using = true;
            if (calced)
            {
                equal();
            }
            num2 = 0;
            numinput = "";
            buttondot.Enabled = true;
            labelprint("log");
            numprint();
            calc = 7;
        }

        private void buttonMod_Click(object sender, EventArgs e)
        {
            num2using = true;
            if (calced)
            {
                equal();
            }
            num2 = 0;
            numinput = "";
            buttondot.Enabled = true;
            labelprint("Mod");
            numprint();
            calc = 8;
        }

        private void buttonInt_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                num2 = Math.Floor(num2);
            }
            else
            {
                num1 = Math.Floor(num1);
            }
            numrechange();
        }

        private void buttonFE_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                label1.Text = num2.ToString("e");
            }
            else
            {
                label1.Text = num1.ToString("e"); ;
            }
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        private void buttonMS_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                memory = num2;
            }
            else
            {
                memory = num1;
            }
        }

        private void buttonMR_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                num2 = memory;
            }
            else
            {
                num1 = memory;
            }
            numrechange();
        }

        private void buttonMp_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                memory += num2;
            }
            else
            {
                memory += num1;
            }
        }

        private void buttonMm_Click(object sender, EventArgs e)
        {
            if (num2using)
            {
                memory -= num2;
            }
            else
            {
                memory -= num1;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            { a = 1; }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            { a = 2; }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton3.Checked)
            {
                a = 3;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttondms_Click(object sender, EventArgs e)
        {



            int deg = (int)num1;
            double min = (num1 - deg) * 60;
            int minInt = (int)min;
            double sec = (min - minInt) * 60;
            sec = Math.Round(sec, 8);
            label1.Text = $"{deg}°{minInt}'{sec}\"".ToString(); 

        }
    }
}
