using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZETTOZIP_FINAL
{
    public partial class page2 : Form
    {
        public page2()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            pdfcompressor obj=new pdfcompressor();
            obj.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            page1cs obj=new page1cs();
            obj.ShowDialog();   
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            pngcompressor obj=new pngcompressor();
            obj.ShowDialog();
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            
            this.pictureBox5.BackColor = ColorTranslator.FromHtml("#19324B");
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            
            this.pictureBox2.BackColor = ColorTranslator.FromHtml("#19324B");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            
            this.pictureBox3.BackColor = ColorTranslator.FromHtml("#19324B");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            
        }
    }
}
