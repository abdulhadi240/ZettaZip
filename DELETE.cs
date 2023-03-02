using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ZETTOZIP_FINAL
{
    public partial class DELETE : Form
    {
        public DELETE()
        {
            InitializeComponent();
        }
        int counter = 0;
        int len = 0;
        string txt;

        OpenFileDialog op = new OpenFileDialog();
       
        private void button3_Click(object sender, EventArgs e)
        {
            string filepath = textBox1.Text;

            if (File.Exists(filepath))
            {

                File.Delete(filepath);
                FileDeleted m = new FileDeleted();
                m.ShowDialog();

            }
            else
            {

                FileNotDeleted m = new FileNotDeleted();
                m.ShowDialog();

            }
        }

        private void DELETE_Load(object sender, EventArgs e)
        {
            txt = label1.Text;
            len = txt.Length;
            label1.Text = "";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;

            if (counter > len)
            {
                counter = 0;
                label1.Text = "";
            }

            else
            {

                label1.Text = txt.Substring(0, counter);

                if (label1.ForeColor == Color.White)
                    label1.ForeColor = Color.Orange;
                else
                    label1.ForeColor = Color.White;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            op.ShowDialog();
            textBox1.Text = op.FileName;
        }
    }
}
