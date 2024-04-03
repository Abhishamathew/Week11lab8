using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week11.Threads
{
    public partial class ThreadingForm : Form
    {
        public ThreadingForm()
        {
            InitializeComponent();
        }

        private async void generateBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(numbertxt.Text, out int n))
            {
                Task task1 = Task.Run(() => Fibonacci(n));

                listBox1.Items.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid number");
            }


            
        }

        private async void Fibonacci(int n)
        {
            
            int a = 0;
            int b = 1;
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
                listBox1.BeginInvoke(new Action(() => listBox1.Items.Add(c)));
                Thread.Sleep(100);
            }

        }


    }
}
