using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 不确定度计算器
{
    public partial class FrmZhijie : Form
    {
        double[] a;
        public FrmZhijie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)      //以下这些都是不同置信概率对应的扩展不确定度
        {
            if (textBox6.Text.Trim() == String.Empty)    //没有c类不确定度时的提醒
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            double uc = double.Parse(textBox6.Text);
            double kuo = 1.96 * uc;
            textBox7.Text = kuo.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Trim() == String.Empty)    //没有c类不确定度时的提醒
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            double uc = double.Parse(textBox6.Text);
            double kuo = 0.675 * uc;
            textBox7.Text = kuo.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Trim() == String.Empty)    //没有c类不确定度时的提醒
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            double uc = double.Parse(textBox6.Text);
            double kuo = uc;
            textBox7.Text = kuo.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Trim() == String.Empty)    //没有c类不确定度时的提醒
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            double uc = double.Parse(textBox6.Text);
            double kuo = 1.65 * uc;
            textBox7.Text = kuo.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Trim() == String.Empty)    //没有c类不确定度时的提醒
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            double uc = double.Parse(textBox6.Text);
            double kuo = 2* uc;
            textBox7.Text = kuo.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Trim() == String.Empty)    //没有c类不确定度时的提醒
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            double uc = double.Parse(textBox6.Text);
            double kuo = 2.58 * uc;
            textBox7.Text = kuo.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Trim() == String.Empty)    //没有c类不确定度时的提醒
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            double uc = double.Parse(textBox6.Text);
            double kuo = 3 * uc;
            textBox7.Text = kuo.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty) return;
            string[] numbers = textBox1.Text.Split(',');
            List<double> list = new List<double>();
            foreach (var s in numbers)
            {
                double v;
                if (double.TryParse(s, out v))
                {
                    list.Add(v);
                }
            }
            a = list.ToArray();         //文本框变为数组

            if (textBox2.Text.Trim() == String.Empty )    //未填写最小分度值进行提醒
            {
                MessageBox.Show("请先填入测量仪器的最小分度值");
                return;//是返回哦。不再运行下面的代码
            }

            int n = a.Length;           //数组维数
            int i; double sum=0; double he=0;
            for(i=0;i<=n-1;i++)
            {
                sum = sum + a[i];
            }
            double ave = sum / n;
            textBox3.Text = ave.ToString();     //平均值输出到文本框

            for(i=0;i<=n-1;i++)
            {
                he = he + (a[i] - ave)* (a[i] - ave);
            }
            double me = he / (n * (n - 1));
            double Alei = Math.Pow(me , 0.5);
            textBox4.Text = Alei.ToString();        //A类不确定度输出

            double wurui = double.Parse(textBox2.Text);
            double Blei = wurui / 1.7320508;
            textBox5.Text = Blei.ToString();       // B类不确定度输出

            double A2 = Alei * Alei;
            double B2 = Blei * Blei;
            B2 = A2 + B2;
            double Clei = Math.Pow(B2, 0.5);
            textBox6.Text = Clei.ToString();        //C类不确定度输出


        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)  //一下是禁止一些文本框有输入
        {
            e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FrmZhijie_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= 48 && e.KeyChar <= 58) || (e.KeyChar == 8) || e.KeyChar == 44 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= 48 && e.KeyChar <= 58) || (e.KeyChar == 8) || e.KeyChar == 44 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
        }
    }
}
