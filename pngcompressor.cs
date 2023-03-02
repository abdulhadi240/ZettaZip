using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using static System.Net.WebRequestMethods;

namespace ZETTOZIP_FINAL
{
    public partial class pngcompressor : Form
    {
        public pngcompressor()
        {
            InitializeComponent();
        }

        int counter = 0;
        int len = 0;
        string txt;
        private static object output;

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
       
            internal static void A(int argc, string[] args)
            {
                if (argc != 2)
                {
                    Console.Write("Invalid cmd line arg. Usage: ./a.out <input file>\n");
                    
                }
                
                int num_of_unique_chars = 0;
                
                string @in = args[1];
                string @out = @in.Substring(0, @in.IndexOf("-compressed")) + "-decompressed.";
                string buff = new string(new char[1]);

                
                int fsize = buff[0] - '0';
                while ((fsize--) != 0)
                {
                    @out += buff[0];
                }

                
                if (output == null)
                {
                    Console.Write("Error creating output file\n");
                    
                }
                unordered_map<string, char> decode_map = new unordered_map<string, char>();
                string s = "";
                int flag = 0;

                
                    if (buff[0] != '\0')
                    {
                        flag = 0;
                        s += buff[0];
                    }
                    else
                    {
                        num_of_unique_chars++;
                        flag++;
                        s = "";
                    }
                

                
                int padding = buff[0] - '0';
                
                int @decimal;
                s = "";
                @decimal = buff[0];
               s = s + dectobin(@decimal);
                
                int start;
                if (padding == 0)
                {
                    s = "0" + s;
                    start = 1;
                }
                else
                {
                    start = padding;
                }
                for (int i = 1; s[start] != '\0'; i++)
                {
                  
                        start = start + i;
                        i = 0;
                    
                }
                
               
            }

        private static string dectobin(int @decimal)
        {
            throw new NotImplementedException();
        }

        private void CompressImage(Image sourceImage, int imageQuality, string savePath)
        {
            try
            {
                //Create an ImageCodecInfo-object for the codec information
                ImageCodecInfo jpegCodec = null;

                //Set quality factor for compression
                EncoderParameter imageQualitysParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, imageQuality);

                //List all avaible codecs (system wide)
                ImageCodecInfo[] allCodecs = ImageCodecInfo.GetImageEncoders();

                EncoderParameters codecParameter = new EncoderParameters(1);
                codecParameter.Param[0] = imageQualitysParameter;

                //Find and choose JPEG codec
                for (int i = 0; i < allCodecs.Length; i++)
                {
                    if (allCodecs[i].MimeType == "image/jpeg")
                    {
                        jpegCodec = allCodecs[i];
                        break;
                    }
                }

                //Save compressed image
                sourceImage.Save(savePath, jpegCodec, codecParameter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            page2 obj = new page2();
            obj.ShowDialog();
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Png Images(*.png)|*.png";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";
            ofd.Filter += "|All(*.JPG, *.PNG, *.bmp)| *.JPG; *.PNG; *.bmp";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                label1.Text = ofd.FileName;
                Image img = Image.FromFile(label1.Text);
                pictureBox3.Image = img;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label1.Text == "")
            {
                MessageBox.Show("Please load image first!");
            }
            else if (label1.Text.Contains(".jpg"))
            {
                CompressImage(Image.FromFile(label1.Text), 30, label1.Text.Insert(label1.Text.Length - 4, " JPEG Compressed Image"));
                Congragulation m = new Congragulation();
                m.ShowDialog();
            }
            else
            {
                string x = label1.Text.Insert(label1.Text.Length - 4, " JPEG Compressed Image");
                string y = "abcdefg";
                //x.Substring(0, x.Length-4)+".jpg"
                //MessageBox.Show(txtFilePthOrig.Text.Insert(txtFilePthOrig.Text.Length - 4, " Compressed Image").Substring(0, x.Length - 4) + ".jpg");

                CompressImage(Image.FromFile(label1.Text), 30, label1.Text.Insert(label1.Text.Length - 4, " JPEG Compressed Image").Substring(0, x.Length - 4) + ".jpg");
                Congragulation m = new Congragulation();
                m.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;

            if (counter > len)
            {
                counter = 0;
                label3.Text = "";
            }

            else
            {

                label3.Text = txt.Substring(0, counter);

                if (label3.ForeColor == Color.White)
                    label3.ForeColor = Color.Orange;
                else
                    label3.ForeColor = Color.White;
            }
        }

        private void pngcompressor_Load(object sender, EventArgs e)
        {
            txt = label3.Text;
            len = txt.Length;
            label3.Text = "";
            timer1.Start();
        }
    }
}
