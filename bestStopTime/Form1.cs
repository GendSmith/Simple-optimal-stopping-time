using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bestStopTime
{
    public partial class Form1 : Form
    {
        static double c = 0;//当前局收益
        static double m = 0;//总收益
        static double n = 0;//下一局的期望
        static double g = 0;//玩一局的成本
        static double p = 0;//折现率
        static int count = 0;//玩了多少局
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            count = 0;
            m = 0;
            c = 0;
            n = 0;
            count = 0;

            label7.Text = c.ToString();

            label9.Text = m.ToString();

            label10.Text = n.ToString();

            label18.Text = count.ToString();

          //  MessageBox.Show("重置成功！");
        }

        private void button6666_Click(object sender, EventArgs e)
        {


            if (textBox2.Text.Trim() == String.Empty)
            {
                MessageBox.Show("请填写每一局的成本");
                return;
            }
            if (textBox1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("请填写折现率");
                return;
            }
            g = double.Parse(textBox2.Text.ToString());
            p = double.Parse(textBox1.Text.ToString());
            if (g < 0 || g > 1100)
            {
                MessageBox.Show("每一局的成本要在[0,1100)这个区间内！");
                return;
            }

            if (p <= 0 || p > 1)
            {
                MessageBox.Show("折现率要在(0,1]这个区间内！");
                return;
            }

            if (count > 0 && m < g)
            {
                MessageBox.Show("成本不足，无法继续游戏！");
                return;
            }

            /*
                static double c = 0;//当前局收益
                static double m = 0;//总收益
                static double n = 0;//下一局的期望
                static double g = 0;//玩一局的成本
                static double p = 0;//折现率
                static bool next = true;//策略提示
                static int count = 0;//玩了多少局
             */
            count++;//玩了多少局

            Random rNumber = new Random();
            int a = rNumber.Next(1, 13);

            if (a == 12)
            {

                c = (-1) * m;

                m = 0;

                label7.Text = c.ToString();

                label9.Text = "抽到12，总收益清零！！";

                label10.Text = n.ToString();

                label18.Text = count.ToString();

                return;
            }

            c = a * 100;//当前局收益

            if (count == 1)
            {
                m = m * p + c;//总收益，第一局不需要成本
            }
            else
            {
                m = m * p + c - g;//总收益
            }


            n = (-1) * m * (1 - p) - m / 12 + 550 - g;//下一局的期望

            label7.Text = c.ToString();

            label9.Text = m.ToString();

            label10.Text = n.ToString();

            label18.Text = count.ToString();

            if (n >= 0)//策略提示
            {
                label11.Text = "扣除成本和折现，下一局期望为正，可以继续玩！";
            }
            else
            {
                label11.Text = "扣除成本和折现，下一局期望为负，建议停止游戏！";
                MessageBox.Show("下一局期望为负，建议停止游戏！！！");
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
