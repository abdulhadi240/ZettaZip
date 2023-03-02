using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ZETTOZIP_FINAL
{
    public partial class Splash_Screen : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect,
        int nTopRect,
        int RightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
        );

        public Splash_Screen()
        {
            InitializeComponent();
        }

        private void Splash_Screen_Load(object sender, EventArgs e)
        {
            
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            circularProgressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
                circularProgressBar1.Value += 2;
                circularProgressBar1.Text = circularProgressBar1.Value.ToString() + "%";

                if (circularProgressBar1.Value == 100)
                {
                    timer1.Enabled = false;
                this.Hide();


                    Form1 f = new Form1();
                    f.Show();
                    
                }
            }
        }
    }






    


