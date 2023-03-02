using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ZETTOZIP_FINAL
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=LoginForm;Integrated Security=True;Pooling=False");
        SqlCommand scmd;
        private void button1_Click(object sender, EventArgs e)
        {
            if (UserName.Text == "" || Pass.Text == "")
            {
                MessageBox.Show("Please fill manadotry feild");

            }
            else if (Pass.Text != confirm.Text)
            {
                MessageBox.Show("Pasword Doesnot match");
            }
            else
            {


                string query = @"INSERT INTO [dbo].[Table_1]
                      ([username],[pass])
                         VALUES ('" + UserName.Text + "' ,'" + Pass.Text + "')";
                conn.Open();
                SqlCommand cmd= new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Registration_sussecfull a=new Registration_sussecfull();
                a.ShowDialog();
                this.Close();

                Form1 b=new Form1();
                b.ShowDialog();

                
            }
            


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox2.Checked;

            switch (check)
            {
                case true:
                    {
                        Pass.UseSystemPasswordChar = false;
                        confirm.UseSystemPasswordChar = false;
                        break;
                    }
                default:
                    {
                        Pass.UseSystemPasswordChar = true;
                        confirm.UseSystemPasswordChar = true;
                        break;
                    }
            }
        }
    }
}
