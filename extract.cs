using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ZETTOZIP_FINAL
{
    public partial class extract : Form
    {
        public extract()
        {
            InitializeComponent();
        }

        int counter = 0;
        int len = 0;
        string txt;

        OpenFileDialog op = new OpenFileDialog();
        private void button3_Click(object sender, EventArgs e)
        {
            string folder = Application.StartupPath + @"\XFolder";
            System.Diagnostics.Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            p.StartInfo.FileName = (@"C:\Users\ADMIN\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\WinRAR\WinRAR");
            p.StartInfo.CreateNoWindow = true;
            psi.CreateNoWindow = true;
            psi.ErrorDialog = false;
            psi.UseShellExecute = false;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.Arguments =
         string.Format("x -o+ \"{0}\"  \"{1}\"", op.FileName, folder);
            p.EnableRaisingEvents = false;
            p.Start();
            Extraction_sussecful m = new Extraction_sussecful();
            m.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            op.Filter = "WinRAR | *.rar";
            op.ShowDialog();
            textBox1.Text = op.FileName;
        }

        private void extract_Load(object sender, EventArgs e)
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
    }
}
