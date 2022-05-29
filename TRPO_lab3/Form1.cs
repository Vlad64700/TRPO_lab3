using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRPO_lab3
{
    public partial class Form1 : Form
    {
        Control control = new Control(1);
        int Type_number = 1;

        private void SetDefaultTrackBar()
        {
            label1.Text = "Основание: 10";
            trackBar1.Value = 10;
        }
        private void RefreshText()
        {
            label2.Text = control.Text;
        }
        public Form1()
        {
            InitializeComponent();

            вещественныеЧислаToolStripMenuItem1.Checked = true;
            дробныеЧислаToolStripMenuItem.Checked = false;
            комплексныеЧислаToolStripMenuItem.Checked = false;

            radioButton1.Visible = false;
            radioButton2.Visible = false;
            trackBar1.Visible = true;
            SetDefaultTrackBar();
            control.State = 10;

        }

        private void вещественныеЧислаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            вещественныеЧислаToolStripMenuItem1.Checked = true;
            дробныеЧислаToolStripMenuItem.Checked = false;
            комплексныеЧислаToolStripMenuItem.Checked = false;
            label2.Text = "0";
            Type_number = 1;
            control = new Control(Type_number);

            //перестраиваем интерфейс
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            trackBar1.Visible = true;
            SetDefaultTrackBar();

            control.State = 10;
        }

        private void дробныеЧислаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            вещественныеЧислаToolStripMenuItem1.Checked = false;
            дробныеЧислаToolStripMenuItem.Checked = true;
            комплексныеЧислаToolStripMenuItem.Checked = false;
            label2.Text = "0";
            Type_number = 3;
            control = new Control(Type_number);

            //перестраиваем интерфейс
            radioButton1.Text = "Числ.";
            radioButton2.Text = "Знам.";
            radioButton1.Checked = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            trackBar1.Visible = false;

            control.State = -1; 
        }

        private void комплексныеЧислаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            вещественныеЧислаToolStripMenuItem1.Checked = false;
            дробныеЧислаToolStripMenuItem.Checked = false;
            комплексныеЧислаToolStripMenuItem.Checked = true;
            label2.Text = "0";
            Type_number = 2;
            control = new Control(Type_number);

            //перестраиваем интерфейс
            radioButton1.Text = "Re";
            radioButton2.Text = "Im";
            radioButton1.Checked = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            trackBar1.Visible = false;

            control.State = -1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            control.AddDigit(1);
            RefreshText();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //меняем только если у нас вещественные числа
            label1.Text = "Основание: " + trackBar1.Value.ToString();
            control = new Control(Type_number);
            control.State = trackBar1.Value;
            RefreshText();


            var baseNumber = trackBar1.Value;
            switch (baseNumber)
            {
                case 2:
                    button11.Enabled = false; //2
                    button15.Enabled = false; //3
                    button6.Enabled = false; //4
                    button10.Enabled = false; //5
                    button14.Enabled = false; //6
                    button5.Enabled = false; //7
                    button9.Enabled = false; //8
                    button13.Enabled = false; //9
                    button28.Enabled = false; //10
                    button29.Enabled = false; //11
                    button30.Enabled = false; //12
                    button31.Enabled = false; //13
                    button32.Enabled = false; //14
                    button33.Enabled = false; //15
                    break;
                case 3:
                    button11.Enabled = true; //2
                    button15.Enabled = false; //3
                    button6.Enabled = false; //4
                    button10.Enabled = false; //5
                    button14.Enabled = false; //6
                    button5.Enabled = false; //7
                    button9.Enabled = false; //8
                    button13.Enabled = false; //9
                    button28.Enabled = false; //10
                    button29.Enabled = false; //11
                    button30.Enabled = false; //12
                    button31.Enabled = false; //13
                    button32.Enabled = false; //14
                    button33.Enabled = false; //15
                    break;
                case 4:
                    button11.Enabled = true; //2
                    button15.Enabled = true; //3
                    button6.Enabled = false; //4
                    button10.Enabled = false; //5
                    button14.Enabled = false; //6
                    button5.Enabled = false; //7
                    button9.Enabled = false; //8
                    button13.Enabled = false; //9
                    button28.Enabled = false; //10
                    button29.Enabled = false; //11
                    button30.Enabled = false; //12
                    button31.Enabled = false; //13
                    button32.Enabled = false; //14
                    button33.Enabled = false; //15
                    break;
                case 5:
                    button11.Enabled = true; //2
                    button15.Enabled = true; //3
                    button6.Enabled = true; //4
                    button10.Enabled = false; //5
                    button14.Enabled = false; //6
                    button5.Enabled = false; //7
                    button9.Enabled = false; //8
                    button13.Enabled = false; //9
                    button28.Enabled = false; //10
                    button29.Enabled = false; //11
                    button30.Enabled = false; //12
                    button31.Enabled = false; //13
                    button32.Enabled = false; //14
                    button33.Enabled = false; //15
                    break;
                case 6:
                    button11.Enabled = true; //2
                    button15.Enabled = true; //3
                    button6.Enabled = true; //4
                    button10.Enabled = true; //5
                    button14.Enabled = false; //6
                    button5.Enabled = false; //7
                    button9.Enabled = false; //8
                    button13.Enabled = false; //9
                    button28.Enabled = false; //10
                    button29.Enabled = false; //11
                    button30.Enabled = false; //12
                    button31.Enabled = false; //13
                    button32.Enabled = false; //14
                    button33.Enabled = false; //15
                    break;
                case 7:
                    button11.Enabled = true; //2
                    button15.Enabled = true; //3
                    button6.Enabled = true; //4
                    button10.Enabled = true; //5
                    button14.Enabled = true; //6
                    button5.Enabled = false; //7
                    button9.Enabled = false; //8
                    button13.Enabled = false; //9
                    button28.Enabled = false; //10
                    button29.Enabled = false; //11
                    button30.Enabled = false; //12
                    button31.Enabled = false; //13
                    button32.Enabled = false; //14
                    button33.Enabled = false; //15
                    break;
                case 8:
                    button11.Enabled = true; //2
                    button15.Enabled = true; //3
                    button6.Enabled = true; //4
                    button10.Enabled = true; //5
                    button14.Enabled = true; //6
                    button5.Enabled = true; //7
                    button9.Enabled = false; //8
                    button13.Enabled = false; //9
                    button28.Enabled = false; //10
                    button29.Enabled = false; //11
                    button30.Enabled = false; //12
                    button31.Enabled = false; //13
                    button32.Enabled = false; //14
                    button33.Enabled = false; //15
                    break;
                case 9:
                    button11.Enabled = true; //2
                    button15.Enabled = true; //3
                    button6.Enabled = true; //4
                    button10.Enabled = true; //5
                    button14.Enabled = true; //6
                    button5.Enabled = true; //7
                    button9.Enabled = true; //8
                    button13.Enabled = false; //9
                    button28.Enabled = false; //10
                    button29.Enabled = false; //11
                    button30.Enabled = false; //12
                    button31.Enabled = false; //13
                    button32.Enabled = false; //14
                    button33.Enabled = false; //15
                    break;
                case 10:
                    button11.Enabled = true; //2
                    button15.Enabled = true; //3
                    button6.Enabled = true; //4
                    button10.Enabled = true; //5
                    button14.Enabled = true; //6
                    button5.Enabled = true; //7
                    button9.Enabled = true; //8
                    button13.Enabled = true; //9
                    button28.Enabled = false; //10
                    button29.Enabled = false; //11
                    button30.Enabled = false; //12
                    button31.Enabled = false; //13
                    button32.Enabled = false; //14
                    button33.Enabled = false; //15
                    break;
                case 11:
                    button11.Enabled = true; //2
                    button15.Enabled = true; //3
                    button6.Enabled = true; //4
                    button10.Enabled = true; //5
                    button14.Enabled = true; //6
                    button5.Enabled = true; //7
                    button9.Enabled = true; //8
                    button13.Enabled = true; //9
                    button28.Enabled = true; //10
                    button29.Enabled = false; //11
                    button30.Enabled = false; //12
                    button31.Enabled = false; //13
                    button32.Enabled = false; //14
                    button33.Enabled = false; //15
                    break;
                case 12:
                    button11.Enabled = true; //2
                    button15.Enabled = true; //3
                    button6.Enabled = true; //4
                    button10.Enabled = true; //5
                    button14.Enabled = true; //6
                    button5.Enabled = true; //7
                    button9.Enabled = true; //8
                    button13.Enabled = true; //9
                    button28.Enabled = true; //10
                    button29.Enabled = true; //11
                    button30.Enabled = false; //12
                    button31.Enabled = false; //13
                    button32.Enabled = false; //14
                    button33.Enabled = false; //15
                    break;
                case 13:
                    button11.Enabled = true; //2
                    button15.Enabled = true; //3
                    button6.Enabled = true; //4
                    button10.Enabled = true; //5
                    button14.Enabled = true; //6
                    button5.Enabled = true; //7
                    button9.Enabled = true; //8
                    button13.Enabled = true; //9
                    button28.Enabled = true; //10
                    button29.Enabled = true; //11
                    button30.Enabled = true; //12
                    button31.Enabled = false; //13
                    button32.Enabled = false; //14
                    button33.Enabled = false; //15
                    break;
                case 14:
                    button11.Enabled = true; //2
                    button15.Enabled = true; //3
                    button6.Enabled = true; //4
                    button10.Enabled = true; //5
                    button14.Enabled = true; //6
                    button5.Enabled = true; //7
                    button9.Enabled = true; //8
                    button13.Enabled = true; //9
                    button28.Enabled = true; //10
                    button29.Enabled = true; //11
                    button30.Enabled = true; //12
                    button31.Enabled = true; //13
                    button32.Enabled = false; //14
                    button33.Enabled = false; //15
                    break;
                case 15:
                    button11.Enabled = true; //2
                    button15.Enabled = true; //3
                    button6.Enabled = true; //4
                    button10.Enabled = true; //5
                    button14.Enabled = true; //6
                    button5.Enabled = true; //7
                    button9.Enabled = true; //8
                    button13.Enabled = true; //9
                    button28.Enabled = true; //10
                    button29.Enabled = true; //11
                    button30.Enabled = true; //12
                    button31.Enabled = true; //13
                    button32.Enabled = true; //14
                    button33.Enabled = false; //15
                    break;
                case 16:
                    button11.Enabled = true; //2
                    button15.Enabled = true; //3
                    button6.Enabled = true; //4
                    button10.Enabled = true; //5
                    button14.Enabled = true; //6
                    button5.Enabled = true; //7
                    button9.Enabled = true; //8
                    button13.Enabled = true; //9
                    button28.Enabled = true; //10
                    button29.Enabled = true; //11
                    button30.Enabled = true; //12
                    button31.Enabled = true; //13
                    button32.Enabled = true; //14
                    button33.Enabled = true; //15
                    break;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            control.AddDigit(0);
            RefreshText();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            control.AddDigit(2);
            RefreshText();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            control.AddDigit(3);
            RefreshText();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            control.AddDigit(4);
            RefreshText();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            control.AddDigit(5);
            RefreshText();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            control.AddDigit(6);
            RefreshText();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            control.AddDigit(7);
            RefreshText();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            control.AddDigit(8);
            RefreshText();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            control.AddDigit(9);
            RefreshText();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            control.DoCommand(16);
            RefreshText();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            control.DoCommand(33);
            RefreshText();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            control.DoCommand(17);
            RefreshText();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            control.DoCommand(18);
            RefreshText();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            control.DoCommand(19);
            RefreshText();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            control.DoCommand(32);
            RefreshText();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            control.DoCommand(25);
            RefreshText();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            control.DoCommand(31);
            RefreshText();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            control.DoCommand(24, 21);
            RefreshText();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            control.DoCommand(20);
            RefreshText();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            control.DoCommand(24,22);
            RefreshText();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            control.DoCommand(24, 23);
            RefreshText();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            control.State = -2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            control.State = -1;
        }
    }
}
