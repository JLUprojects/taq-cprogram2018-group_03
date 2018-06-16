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
    public partial class FormZhu : Form
    {
        double[] x;
        double[] y;

        public FormZhu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty) return;
            string[] numbers = textBox1.Text.Split(',');
            List<double> list = new List<double>();
            foreach (var sx in numbers)
            {
                double vx;
                if (double.TryParse(sx, out vx))
                {
                    list.Add(vx);
                }
            }
            x = list.ToArray();

            if (textBox2.Text.Trim() == string.Empty) return;
            string[] numbersy = textBox2.Text.Split(',');
            List<double> listy = new List<double>();
            foreach (var sy in numbersy)
            {
                double vy;
                if (double.TryParse(sy, out vy))
                {
                    listy.Add(vy);
                }
            }
            y = listy.ToArray();

            int n = x.Length;
            int j1 = n / 2;
            int i;
            double k;
            double s = 0;

            if (n % 2 != 0)
            {
                MessageBox.Show("您输入的数据个数为奇数，请删除一对数据！");
            }
            if (n % 2 == 0)
            {
                for (i = 0; i <= j1 - 1; i++)
                {
                    s = s + (y[i + j1] - y[i]) / (x[i + j1] - x[i]);
                }
                k = s / j1;
                textBox3.Text = k.ToString();
            }
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FormZhu_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit ();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >=48 && e.KeyChar <=58)||(e.KeyChar ==8)||e.KeyChar ==44 || e.KeyChar==46)
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
