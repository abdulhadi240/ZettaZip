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
using System.IO;

namespace ZETTOZIP_FINAL
{
    public partial class pdfcompressor : Form
    {
        private int ticks;
        public pdfcompressor()
        {
            InitializeComponent();
        }

        int counter = 0;
        int len = 0;
        string txt;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            page2 obj=new page2();
            obj.ShowDialog();
        }
        public class huffnode
        {
            public char character;
            public uint freq;
            public huffnode left;
            public huffnode right;

            internal void CopyFrom(huffnode huffnode)
            {
                throw new NotImplementedException();
            }
        }

        public class Minheap
        {
            public ushort size;
            public ushort capacity;
            public huffnode[] array;
        }

        public static class Globals
        {


            public static Dictionary<char, string> hashmap = new Dictionary<char, string>();

            public static huffnode newleafnode(char c, int f)
            {
                huffnode tmp = new huffnode();
                tmp.character = c;
                tmp.freq = (uint)f;
                tmp.left = null;
                tmp.right = null;
                return tmp;
            }

            public static huffnode newinternalnode(int f)
            {
                huffnode tmp = new huffnode();
                tmp.character = 'c';
                tmp.freq = (uint)f;
                tmp.left = null;
                tmp.right = null;
                return tmp;
            }

            public static void swap(huffnode[] a, int i, int j)
            {
                huffnode tmp = new huffnode();
                tmp = a[i];

                a[i].CopyFrom(a[j]);

                a[j].CopyFrom(tmp);
            }

            public static void heapify(Minheap heap)
            {
                int i;
                int j;
                int k;
                ushort n = heap.size;

                huffnode[] a = new huffnode[n];
                for (i = n / 2; i > 0; i--)
                {
                    if (2 * i + 1 <= n)
                    {
                        j = a[2 * i].freq < a[2 * i + 1].freq ? 2 * i : 2 * i + 1;
                    }
                    else
                    {
                        j = 2 * i;
                    }

                    if (a[j].freq < a[i].freq)
                    {
                        swap(a, i, j);
                        while (j <= n / 2 && (a[j].freq > a[2 * j].freq))
                        {
                            if (2 * j + 1 <= n)
                            {
                                k = a[2 * j].freq < a[2 * j + 1].freq ? 2 * j : 2 * j + 1;
                            }
                            else
                            {
                                k = 2 * j;
                            }
                            swap(a, k, j);
                            j = k;
                        }
                    }
                }
            }

            public static huffnode mintop(Minheap heap)
            {
                huffnode top = new huffnode();
                top = heap.array[1];

                heap.array[1].CopyFrom(heap.array[heap.size--]);
                heapify(heap);
                return top;
            }

            public static void insertnode(Minheap heap, huffnode leftchild, huffnode rightchild, int f)
            {
                huffnode tmp = new huffnode();
                tmp.character = '\0';
                tmp.freq = (uint)f;
                tmp.left = leftchild;
                tmp.right = rightchild;

                heap.array[++heap.size].CopyFrom(tmp);
                heapify(heap);
            }

            public static void huffman_tree(Minheap heap)
            {
                while (heap.size > 1)
                {
                    huffnode left_child = mintop(heap);
                    huffnode right_child = mintop(heap);
                    insertnode(heap, left_child, right_child, (int)(left_child.freq + right_child.freq));
                }
            }

            public static void assign_codes(huffnode root, string str)
            {
                string s1 = "";
                string s2 = "";
                if (root.left == null && root.right == null)
                {
                    hashmap[root.character] = str;
                }
                else
                {
                    s1 = str + "0";
                    s2 = str + "1";
                    assign_codes(root.left, s1);
                    assign_codes(root.right, s2);
                }
            }

            public static void preorder(huffnode root)
            {
                if (root != null)
                {
                    Console.Write(root.freq);
                    Console.Write("\t");
                    preorder(root.left);
                    preorder(root.right);
                }
            }


        }





        private bool CompressPDF(string CompressValue, string OutPutFile, string InputFile)
        {
            try
            {
                Process proc = new Process();
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.CreateNoWindow = true;
                psi.ErrorDialog = false;
                psi.UseShellExecute = false;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.FileName = string.Concat(Path.GetDirectoryName(Application.ExecutablePath), "\\compressed");

                string args = "-sDEVICE=pdfwrite -dCompatibilityLevel=1.4 " + " - dPDFSETTINGS =/ " + CompressValue + "-dNOPAUSE -dQUIET  -dBATCH" + "-sOutputFile=\"" + OutPutFile + "\" " + "\"" + InputFile + "\"";
                psi.Arguments = args;

                proc.StartInfo = psi;

                proc.Start();
                proc.WaitForExit();

                return true;

            }
            catch
            {
                return false;
            }
        }


        string outputDir = string.Empty;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            foreach (string pdffile in listBox1.Items)
            {
                string outp = outputDir + "\\" + Path.GetFileNameWithoutExtension(pdffile) + "_Compress.pdf";

                CompressPDF(pdffile, outp, "screen");



            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            

            Congragulation m=new Congragulation();
            m.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = true;
            openFile.Title = "Select Your Pdf";
            openFile.Filter = "PDF Files (*.PDF)|*.PDF";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFile.FileNames)
                {
                    listBox1.Items.Add(file);
                }
            }

            this.timer1.Start();
            
        }
        waitform a = new waitform();
        private void button3_Click(object sender, EventArgs e)
        {
           this.timer2.Start();
            this.timer1.Start();
            
            a.Show();


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

        private void pdfcompressor_Load(object sender, EventArgs e)
        {
            txt = label1.Text;
            len = txt.Length;
            label1.Text = "";
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            ticks++;
            
            if (ticks > 100)
            {
                timer2.Stop();
                a.Close();
                Congragulation m = new Congragulation();
                m.ShowDialog();
            }

        }
    }





   

   


}