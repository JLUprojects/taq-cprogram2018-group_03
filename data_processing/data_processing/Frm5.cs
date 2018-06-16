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
    public partial class Frm5 : Form
    {
        double[] ax;
        double[] ay;
        double[] az;
        public Frm5()
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
            ax = list.ToArray();        //ax数组

            if (textBox2.Text.Trim() == string.Empty) return;
            string[] numbersy = textBox2.Text.Split(',');
            List<double> listy = new List<double>();
            foreach (var s in numbersy)
            {
                double vy;
                if (double.TryParse(s, out vy))
                {
                    listy.Add(vy);
                }
            }
            ay = listy.ToArray();       //ay数组

            if (textBox3.Text.Trim() == string.Empty) return;
            string[] numbersz = textBox3.Text.Split(',');
            List<double> listz = new List<double>();
            foreach (var s in numbersz)
            {
                double vz;
                if (double.TryParse(s, out vz))
                {
                    listz.Add(vz);
                }
            }
            az = listz.ToArray();       //az数组
            if (textBox4.Text.Trim() == String.Empty || textBox5.Text.Trim() == String.Empty
                    || textBox6.Text.Trim() == String.Empty)    //未填写最小分度值进行提醒
            {
                MessageBox.Show("请先填入测量仪器的最小分度值");
                return;//是返回哦。不再运行下面的代码
            }

            int n = ax.Length;
            int i; double sum = 0; double he = 0;
            for (i = 0; i <= n - 1; i++)
            {
                sum = sum + ax [i];
            }
            double ave = sum / n;
            textBox10.Text = ave.ToString();     //x的平均值

            for (i = 0; i <= n - 1; i++)
            {
                he = he + (ax[i] - ave) * (ax[i] - ave);
            }
            double me = he / (n * (n - 1));
            double Alei = Math.Pow(me, 0.5);
            textBox11.Text = Alei.ToString();        //x的A类不确定度

            double wurui = double.Parse(textBox4.Text);
            double Blei = wurui / 1.7320508;
            textBox12.Text = Blei.ToString();        //x的B类不确定度

            double A2 = Alei * Alei;
            double B2 = Blei * Blei;
            B2 = A2 + B2;
            double Clei = Math.Pow(B2, 0.5);
            textBox13.Text = Clei.ToString();        //x的C类不确定度


            int ny = ay.Length;
            int iy; double sumy = 0; double hey = 0;
            for (iy = 0; iy <= ny - 1; iy++)
            {
                sumy = sumy + ay[iy];
            }
            double avey = sumy / ny;
            textBox15.Text = avey.ToString();        //y的平均值

            for (iy = 0; iy <= ny - 1; iy++)
            {
                hey = hey + (ay[iy] - avey) * (ay[iy] - avey);
            }
            double mey = hey / (ny * (ny - 1));
            double Aleiy = Math.Pow(mey, 0.5);
            textBox16.Text = Aleiy.ToString();      //y的A类不确定度

            double wuruiy = double.Parse(textBox5.Text);
            double Bleiy = wuruiy / 1.7320508;
            textBox17.Text = Bleiy.ToString();      //y的B类不确定度

            double A2y = Aleiy * Aleiy;
            double B2y = Bleiy * Bleiy;
            B2y = A2y + B2y;
            double Cleiy = Math.Pow(B2y, 0.5);
            textBox18.Text = Cleiy.ToString();      //y的C类不确定度

            int nz = az.Length;
            int iz; double sumz = 0; double hez = 0;
            for (iz = 0; iz <= nz - 1; iz++)
            {
                sumz = sumz + az[iz];
            }
            double avez = sumz / nz;
            textBox20.Text = avez.ToString();        //z的平均值

            for (iz = 0; iz <= nz - 1; iz++)
            {
                hez = hez + (az[iz] - avez) * (az[iz] - avez);
            }
            double mez = hez / (nz * (nz - 1));
            double Aleiz = Math.Pow(mez, 0.5);
            textBox21.Text = Aleiz.ToString();      //z的A类不确定度

            double wuruiz = double.Parse(textBox6.Text);
            double Bleiz = wuruiz / 1.7320508;
            textBox22.Text = Bleiz.ToString();      //z的B类不确定度

            double A2z = Aleiz * Aleiz;
            double B2z = Bleiz * Bleiz;
            B2z = A2z + B2z;
            double Cleiz = Math.Pow(B2z, 0.5);
            textBox23.Text = Cleiz.ToString();      //z的C类不确定度




        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Trim() == String.Empty )           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }

            double xc = double.Parse(textBox13.Text);
            double yc = double.Parse(textBox18.Text);
            double zc = double.Parse(textBox23.Text);
            double xk = 2 * xc;
            double yk = 2 * yc;
            double zk = 2 * zc;
            textBox14.Text = xk.ToString();
            textBox19.Text = yk.ToString();
            textBox24.Text = zk.ToString();

            double k = double.Parse(textBox7.Text);     //不确定度传递
            double m = double.Parse(textBox8.Text);
            double n = double.Parse(textBox9.Text);
            double xp = double.Parse(textBox10.Text);
            double yp = double.Parse(textBox15.Text);
            double zp = double.Parse(textBox20.Text);
            double xtk = Math.Pow(xp, k);
            double ytm = Math.Pow(yp, m);
            double ztn = Math.Pow(zp, n);
            double N = xtk * ytm * ztn;
            xk = xk * xk / xp / xp;
            yk = yk * yk / yp / yp;
            zk = zk * zk / zp / zp;
            double un = (k * k * xk) + (m * m * yk) + (n * n * zk);
            un = Math.Pow(un, 0.5);
            un = N * un;
            textBox25.Text = un.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }

            double xc = double.Parse(textBox13.Text);
            double yc = double.Parse(textBox18.Text);
            double zc = double.Parse(textBox23.Text);
            double xk = 0.675 * xc;
            double yk = 0.675 * yc;
            double zk = 0.675 * zc;
            textBox14.Text = xk.ToString();
            textBox19.Text = yk.ToString();
            textBox24.Text = zk.ToString();

            double k = double.Parse(textBox7.Text);     //不确定度传递
            double m = double.Parse(textBox8.Text);
            double n = double.Parse(textBox9.Text);
            double xp = double.Parse(textBox10.Text);
            double yp = double.Parse(textBox15.Text);
            double zp = double.Parse(textBox20.Text);
            double xtk = Math.Pow(xp, k);
            double ytm = Math.Pow(yp, m);
            double ztn = Math.Pow(zp, n);
            double N = xtk * ytm * ztn;
            xk = xk * xk / xp / xp;
            yk = yk * yk / yp / yp;
            zk = zk * zk / zp / zp;
            double un = (k * k * xk) + (m * m * yk) + (n * n * zk);
            un = Math.Pow(un, 0.5);
            un = N * un;
            textBox25.Text = un.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }

            double xc = double.Parse(textBox13.Text);
            double yc = double.Parse(textBox18.Text);
            double zc = double.Parse(textBox23.Text);
            double xk =  xc;
            double yk =  yc;
            double zk =  zc;
            textBox14.Text = xk.ToString();
            textBox19.Text = yk.ToString();
            textBox24.Text = zk.ToString();

            double k = double.Parse(textBox7.Text);     //不确定度传递
            double m = double.Parse(textBox8.Text);
            double n = double.Parse(textBox9.Text);
            double xp = double.Parse(textBox10.Text);
            double yp = double.Parse(textBox15.Text);
            double zp = double.Parse(textBox20.Text);
            double xtk = Math.Pow(xp, k);
            double ytm = Math.Pow(yp, m);
            double ztn = Math.Pow(zp, n);
            double N = xtk * ytm * ztn;
            xk = xk * xk / xp / xp;
            yk = yk * yk / yp / yp;
            zk = zk * zk / zp / zp;
            double un = (k * k * xk) + (m * m * yk) + (n * n * zk);
            un = Math.Pow(un, 0.5);
            un = N * un;
            textBox25.Text = un.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }

            double xc = double.Parse(textBox13.Text);
            double yc = double.Parse(textBox18.Text);
            double zc = double.Parse(textBox23.Text);
            double xk = 1.65 * xc;
            double yk = 1.65 * yc;
            double zk = 1.65 * zc;
            textBox14.Text = xk.ToString();
            textBox19.Text = yk.ToString();
            textBox24.Text = zk.ToString();

            double k = double.Parse(textBox7.Text);     //不确定度传递
            double m = double.Parse(textBox8.Text);
            double n = double.Parse(textBox9.Text);
            double xp = double.Parse(textBox10.Text);
            double yp = double.Parse(textBox15.Text);
            double zp = double.Parse(textBox20.Text);
            double xtk = Math.Pow(xp, k);
            double ytm = Math.Pow(yp, m);
            double ztn = Math.Pow(zp, n);
            double N = xtk * ytm * ztn;
            xk = xk * xk / xp / xp;
            yk = yk * yk / yp / yp;
            zk = zk * zk / zp / zp;
            double un = (k * k * xk) + (m * m * yk) + (n * n * zk);
            un = Math.Pow(un, 0.5);
            un = N * un;
            textBox25.Text = un.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }

            double xc = double.Parse(textBox13.Text);
            double yc = double.Parse(textBox18.Text);
            double zc = double.Parse(textBox23.Text);
            double xk = 1.96 * xc;
            double yk = 1.96 * yc;
            double zk = 1.96 * zc;
            textBox14.Text = xk.ToString();
            textBox19.Text = yk.ToString();
            textBox24.Text = zk.ToString();

            double k = double.Parse(textBox7.Text);     //不确定度传递
            double m = double.Parse(textBox8.Text);
            double n = double.Parse(textBox9.Text);
            double xp = double.Parse(textBox10.Text);
            double yp = double.Parse(textBox15.Text);
            double zp = double.Parse(textBox20.Text);
            double xtk = Math.Pow(xp, k);
            double ytm = Math.Pow(yp, m);
            double ztn = Math.Pow(zp, n);
            double N = xtk * ytm * ztn;
            xk = xk * xk / xp / xp;
            yk = yk * yk / yp / yp;
            zk = zk * zk / zp / zp;
            double un = (k * k * xk) + (m * m * yk) + (n * n * zk);
            un = Math.Pow(un, 0.5);
            un = N * un;
            textBox25.Text = un.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }

            double xc = double.Parse(textBox13.Text);
            double yc = double.Parse(textBox18.Text);
            double zc = double.Parse(textBox23.Text);
            double xk = 2.58 * xc;
            double yk = 2.58 * yc;
            double zk = 2.58 * zc;
            textBox14.Text = xk.ToString();
            textBox19.Text = yk.ToString();
            textBox24.Text = zk.ToString();

            double k = double.Parse(textBox7.Text);     //不确定度传递
            double m = double.Parse(textBox8.Text);
            double n = double.Parse(textBox9.Text);
            double xp = double.Parse(textBox10.Text);
            double yp = double.Parse(textBox15.Text);
            double zp = double.Parse(textBox20.Text);
            double xtk = Math.Pow(xp, k);
            double ytm = Math.Pow(yp, m);
            double ztn = Math.Pow(zp, n);
            double N = xtk * ytm * ztn;
            xk = xk * xk / xp / xp;
            yk = yk * yk / yp / yp;
            zk = zk * zk / zp / zp;
            double un = (k * k * xk) + (m * m * yk) + (n * n * zk);
            un = Math.Pow(un, 0.5);
            un = N * un;
            textBox25.Text = un.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Trim() == String.Empty)           //未得到c类不确定度时提示先进行计算
            {
                MessageBox.Show("请先点击“计算”得到C类不确定度");
                return;//是返回哦。不再运行下面的代码
            }

            double xc = double.Parse(textBox13.Text);
            double yc = double.Parse(textBox18.Text);
            double zc = double.Parse(textBox23.Text);
            double xk = 3 * xc;
            double yk = 3 * yc;
            double zk = 3 * zc;
            textBox14.Text = xk.ToString();
            textBox19.Text = yk.ToString();
            textBox24.Text = zk.ToString();

            double k = double.Parse(textBox7.Text);     //不确定度传递
            double m = double.Parse(textBox8.Text);
            double n = double.Parse(textBox9.Text);
            double xp = double.Parse(textBox10.Text);
            double yp = double.Parse(textBox15.Text);
            double zp = double.Parse(textBox20.Text);
            double xtk = Math.Pow(xp, k);
            double ytm = Math.Pow(yp, m);
            double ztn = Math.Pow(zp, n);
            double N = xtk * ytm * ztn;
            xk = xk * xk / xp / xp;
            yk = yk * yk / yp / yp;
            zk = zk * zk / zp / zp;
            double un = (k * k * xk) + (m * m * yk) + (n * n * zk);
            un = Math.Pow(un, 0.5);
            un = N * un;
            textBox25.Text = un.ToString();
        }

        private void Frm5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= 48 && e.KeyChar <= 58) || (e.KeyChar == 8) || e.KeyChar == 44 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= 48 && e.KeyChar <= 58) || (e.KeyChar == 8) || e.KeyChar == 44 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= 48 && e.KeyChar <= 58) || (e.KeyChar == 8) || e.KeyChar == 44 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= 48 && e.KeyChar <= 58) || (e.KeyChar == 8) || e.KeyChar == 44 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= 48 && e.KeyChar <= 58) || (e.KeyChar == 8) || e.KeyChar == 44 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
        }
    }
}
