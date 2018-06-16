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
    public partial class Frm4 : Form
    {
        double[] xa;
        double[] ya;
        public Frm4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
            xa = list.ToArray();

            if (textBox2.Text.Trim() == string.Empty) return;
            string[] numbersy = textBox2.Text.Split(',');
            List<double> listy = new List<double>();
            foreach (var s in numbersy)
            {
                double v;
                if (double.TryParse(s, out v))
                {
                    listy.Add(v);
                }
            }
            ya = listy.ToArray();

            if (textBox3.Text.Trim() == String.Empty || textBox4.Text.Trim() == String.Empty)    //未填写最小分度值进行提醒
            {
                MessageBox.Show("请先填入测量仪器的最小分度值");
                return;//是返回哦。不再运行下面的代码
            }

            int n = xa.Length;
            int i; double sum = 0; double he = 0;
            for (i = 0; i <= n - 1; i++)
            {
                sum = sum + xa[i];
            }
            double ave = sum / n;
            textBox5.Text = ave.ToString();     //x的平均值

            for (i = 0; i <= n - 1; i++)
            {
                he = he + (xa[i] - ave) * (xa[i] - ave);
            }
            double me = he / (n * (n - 1));
            double Alei = Math.Pow(me, 0.5);
            textBox6.Text = Alei.ToString();        //x的A类不确定度

            double wurui = double.Parse(textBox3.Text);
            double Blei = wurui / 1.7320508;
            textBox7.Text = Blei.ToString();        //x的B类不确定度

            double A2 = Alei * Alei;
            double B2 = Blei * Blei;
            B2 = A2 + B2;
            double Clei = Math.Pow(B2, 0.5);
            textBox8.Text = Clei.ToString();        //x的C类不确定度


            int ny = ya.Length;
            int iy; double sumy = 0; double hey = 0;
            for (iy = 0; iy <= ny - 1; iy++)
            {
                sumy = sumy + ya[iy];
            }
            double avey = sumy / ny;
            textBox9.Text = avey.ToString();        //y的平均值

            for (iy = 0; iy <= ny - 1; iy++)
            {
                hey = hey + (ya[iy] - avey) * (ya[iy] - avey);
            }
            double mey = hey / (ny * (ny - 1));
            double Aleiy = Math.Pow(mey, 0.5);
            textBox10.Text = Aleiy.ToString();      //y的A类不确定度

            double wuruiy = double.Parse(textBox4.Text);
            double Bleiy = wuruiy / 1.7320508;
            textBox11.Text = Bleiy.ToString();      //y的B类不确定度

            double A2y = Aleiy * Aleiy;
            double B2y = Bleiy * Bleiy;
            B2y = A2y + B2y;
            double Cleiy = Math.Pow(B2y, 0.5);
            textBox12.Text = Cleiy.ToString();      //y的C类不确定度

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Trim() == String.Empty || textBox12.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }

            double xc = double.Parse(textBox8.Text);
            double yc = double.Parse(textBox12.Text);
            double xk = 2 * xc;
            double yk = 2 * yc;
            double xp = double.Parse(textBox5.Text);        //从这里不确定传递
            double yp = double.Parse(textBox9.Text);
            xk = xk / xp; xk = Math.Pow(xk, 2);
            yk = yk / yp; yk = Math.Pow(yk, 2);
            double nk = xk + yk;
            nk = Math.Pow(nk, 0.5);
            textBox13.Text = xk.ToString();
            textBox14.Text = yk.ToString();
            textBox15.Text = nk.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到x和y的C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            if (textBox12.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到x和y的C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            double xc = double.Parse(textBox8.Text);
            double yc = double.Parse(textBox12.Text);
            double xk = 0.675 * xc;
            double yk = 0.675 * yc;
            double xp = double.Parse(textBox5.Text);        //从这里不确定传递
            double yp = double.Parse(textBox9.Text);
            xk = xk / xp; xk = Math.Pow(xk, 2);
            yk = yk / yp; yk = Math.Pow(yk, 2);
            double nk = xk + yk;
            nk = Math.Pow(nk, 0.5);
            textBox13.Text = xk.ToString();
            textBox14.Text = yk.ToString();
            textBox15.Text = nk.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到x和y的C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            if (textBox12.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到x和y的C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            double xc = double.Parse(textBox8.Text);
            double yc = double.Parse(textBox12.Text);
            double xk = xc;
            double yk = yc;
            double xp = double.Parse(textBox5.Text);        //从这里不确定传递
            double yp = double.Parse(textBox9.Text);
            xk = xk / xp; xk = Math.Pow(xk, 2);
            yk = yk / yp; yk = Math.Pow(yk, 2);
            double nk = xk + yk;
            nk = Math.Pow(nk, 0.5);
            textBox13.Text = xk.ToString();
            textBox14.Text = yk.ToString();
            textBox15.Text = nk.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到x和y的C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            if (textBox12.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到x和y的C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            double xc = double.Parse(textBox8.Text);
            double yc = double.Parse(textBox12.Text);
            double xk = 1.65*xc;
            double yk = 1.65*yc;
            double xp = double.Parse(textBox5.Text);        //从这里不确定传递
            double yp = double.Parse(textBox9.Text);
            xk = xk / xp; xk = Math.Pow(xk, 2);
            yk = yk / yp; yk = Math.Pow(yk, 2);
            double nk = xk + yk;
            nk = Math.Pow(nk, 0.5);
            textBox13.Text = xk.ToString();
            textBox14.Text = yk.ToString();
            textBox15.Text = nk.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到x和y的C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            if (textBox12.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到x和y的C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            double xc = double.Parse(textBox8.Text);
            double yc = double.Parse(textBox12.Text);
            double xk = 1.96 * xc;
            double yk = 1.96 * yc;
            double xp = double.Parse(textBox5.Text);        //从这里不确定传递
            double yp = double.Parse(textBox9.Text);
            xk = xk / xp; xk = Math.Pow(xk, 2);
            yk = yk / yp; yk = Math.Pow(yk, 2);
            double nk = xk + yk;
            nk = Math.Pow(nk, 0.5);
            textBox13.Text = xk.ToString();
            textBox14.Text = yk.ToString();
            textBox15.Text = nk.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到x和y的C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            if (textBox12.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到x和y的C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            double xc = double.Parse(textBox8.Text);
            double yc = double.Parse(textBox12.Text);
            double xk = 2.58 * xc;
            double yk = 2.58 * yc;
            double xp = double.Parse(textBox5.Text);        //从这里不确定传递
            double yp = double.Parse(textBox9.Text);
            xk = xk / xp; xk = Math.Pow(xk, 2);
            yk = yk / yp; yk = Math.Pow(yk, 2);
            double nk = xk + yk;
            nk = Math.Pow(nk, 0.5);
            textBox13.Text = xk.ToString();
            textBox14.Text = yk.ToString();
            textBox15.Text = nk.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到x和y的C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            if (textBox12.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到x和y的C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }
            double xc = double.Parse(textBox8.Text);
            double yc = double.Parse(textBox12.Text);
            double xk = 3 * xc;
            double yk = 3 * yc;
            double xp = double.Parse(textBox5.Text);        //从这里不确定传递
            double yp = double.Parse(textBox9.Text);
            xk = xk / xp; xk = Math.Pow(xk, 2);
            yk = yk / yp; yk = Math.Pow(yk, 2);
            double nk = xk + yk;
            nk = Math.Pow(nk, 0.5);
            textBox13.Text = xk.ToString();
            textBox14.Text = yk.ToString();
            textBox15.Text = nk.ToString();
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Frm4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= 48 && e.KeyChar <= 58) || (e.KeyChar == 8) || e.KeyChar == 44 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= 48 && e.KeyChar <= 58) || (e.KeyChar == 8) || e.KeyChar == 44 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
        }
    }
}
