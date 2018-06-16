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
    public partial class FormZui : Form
    {
        double[] x;
        double[] y;
        public FormZui()
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
                double vx;
                if (double.TryParse(s, out vx))
                {
                    list.Add(vx);
                }
            }
            x = list.ToArray();

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
            y = listy.ToArray();

            int  n = x.Length;
            int  ny = y.Length;
            if (n != ny) 
            {
                MessageBox.Show("横坐标与纵坐标的个数必须相同！");
             }

            int i;
            double sx = 0;
            double sy = 0;
            double sx2 = 0;
            double sxy = 0;
            double sy2 = 0;
            double k, b;
            double avex, avey, avex2, avexy, avey2;
            double se2 = 0;
            double ey, ek, eb;
            double gamma;
            double[] ej= new double [n];

            /*利用最小二乘法拟合参数最佳值*/
            for (i = 0; i <= n - 1; i++)
            {
                sx = sx + x[i];
                sy = sy + y[i];
                sx2 = sx2 + Math.Pow (x[i], 2);
                sxy = sxy + x[i] * y[i];
            }
            avex = sx / n;
            avey = sy / n;
            avex2 = sx2 / n;
            avexy = sxy / n;
            k = -(avex * avey - avexy) / (avex2 - Math.Pow (avex, 2));
            b = avey - k * avex;
            textBox3.Text = k.ToString();
            textBox4.Text = b.ToString();

            /*测量值的标准偏差*/
            for (i = 0; i <= n - 1; i++)
            {
                ej[i] = y[i] - (k * x[i] + b);
            }
            for (i = 0; i <= n - 1; i++)
            {
                se2 = se2 + Math.Pow (ej[i], 2);
            }
            ey = Math.Sqrt (se2 / (n - 2));
            ek = ey / (Math.Sqrt (n * (avex2 - Math.Pow (avex, 2))));
            eb = Math.Sqrt (avex2) * ek;
            textBox5.Text = ey.ToString();
            textBox6.Text = ek.ToString();
            textBox7.Text = eb.ToString();

            /*γ检验*/
            for (i = 0; i <= n - 1; i++)
            {
                sy2 = sy2 + Math.Pow (y[i], 2);
            }
            avey2 = sy2 / n;
            gamma = (avexy - avex * avey) / (Math.Sqrt ((avex2 - Math.Pow (avex, 2)) * (avey2 - Math.Pow (avey, 2))));

            textBox8.Text = gamma.ToString();

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FormZui_FormClosed(object sender, FormClosedEventArgs e)
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
    }
}
