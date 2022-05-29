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
            button16.Enabled = true; // .

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


            //отключаем не нужные кнопки
            button28.Enabled = false; //10
            button29.Enabled = false; //11
            button30.Enabled = false; //12
            button31.Enabled = false; //13
            button32.Enabled = false; //14
            button33.Enabled = false; //15
            button16.Enabled = false; // .

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


            //отключаем не нужные кнопки
            button28.Enabled = false; //10
            button29.Enabled = false; //11
            button30.Enabled = false; //12
            button31.Enabled = false; //13
            button32.Enabled = false; //14
            button33.Enabled = false; //15
            button16.Enabled = false; // .

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

        private void button3_Click(object sender, EventArgs e) // MS
        {
            control.DoCommand(27);
            RefreshText();
            button1.Enabled = true;
            button2.Enabled = true;
            button24.Text = control.processor.savedNumber.ToString();

        }

        private void button4_Click(object sender, EventArgs e) //M+
        {
            control.DoCommand(26);
            RefreshText();
            button24.Text = control.processor.savedNumber.ToString();
        }

        private void button2_Click(object sender, EventArgs e) // MR
        {
            control.DoCommand(28);
            RefreshText();
        }

        private void button1_Click(object sender, EventArgs e) // MC
        {
            control.DoCommand(29);
            RefreshText();
            button1.Enabled = false;
            button2.Enabled = false;
            button24.Text = "";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            int BaseNumber = trackBar1.Value;
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.D0:
                        control.AddDigit('0');
                        break;
                    case Keys.D1:
                        if (BaseNumber > 1)
                            control.AddDigit(1);
                        break;
                    case Keys.D2:
                        if (BaseNumber > 2)
                            control.AddDigit(2);
                        break;
                    case Keys.D3:
                        if (BaseNumber > 3)
                            control.AddDigit(3);
                        break;
                    case Keys.D4:
                        if (BaseNumber > 4)
                            control.AddDigit(4);
                        break;
                    case Keys.D5:
                        if (BaseNumber > 5)
                            control.AddDigit(5);
                        break;
                    case Keys.D6:
                        if (BaseNumber > 6)
                            control.AddDigit(6);
                        break;
                    case Keys.D7:
                        if (BaseNumber > 7)
                            control.AddDigit(7);
                        break;
                    case Keys.D8:
                        if (BaseNumber > 8)
                            control.AddDigit(8);
                        break;
                    case Keys.D9:
                        if (BaseNumber > 9)
                            control.AddDigit(9);
                        break;
                    case Keys.A:
                        if (BaseNumber > 10)
                            control.AddDigit(10);
                        break;
                    case Keys.B:
                        if (BaseNumber > 11)
                            control.AddDigit(11);
                        break;
                    case Keys.C:
                        if (BaseNumber > 12)
                            control.AddDigit(12);
                        break;
                    case Keys.D:
                        if (BaseNumber > 13)
                            control.AddDigit(13);
                        break;
                    case Keys.E:
                        if (BaseNumber > 14)
                            control.AddDigit(14);
                        break;
                    case Keys.F:
                        if (BaseNumber > 15)
                            control.AddDigit(15);
                        break;

                }
                RefreshText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            control.AddDigit(10);
            RefreshText();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            control.AddDigit(12);
            RefreshText();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            control.AddDigit(11);
            RefreshText();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            control.AddDigit(13);
            RefreshText();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            control.AddDigit(14);
            RefreshText();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            control.AddDigit(15);
            RefreshText();
        }
    }
    }
