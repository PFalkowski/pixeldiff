using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PixelDiff
{
    public partial class Form1 : Form
    {
        private const string fileFormatFilter = "Images |*.jpg;*.jpeg;*.png;*.bmp;*.gif";

        private const string errorCaption = "Error occured.";

        private const string warningCaption = "Warning!";

        private const string About = "Written by Piotr Falkowski piotr.falkowski.fm@gmail.com. © Piotr Falkowski 2015";

        private const string Licence = "This software is provided as is WITHOUT ANY GUARANTEES under the GNU General Public License v3.0: see http://www.gnu.org/licenses/gpl-3.0.html";

        private static readonly string defaultSaveDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "pxDifferences");

        private string PathToSingleFileWithDiff = Path.Combine(Form1.defaultSaveDir, "differences.csv");

        private Dictionary<string, Bitmap> picturesA = new Dictionary<string, Bitmap>();

        private Dictionary<string, Bitmap> picturesB = new Dictionary<string, Bitmap>();



        public bool ReadyToCompare
        {
            get
            {
                return this.listBox2.Items != null && this.listBox2.Items.Count > 0 && this.listBox2.SelectedItem != null && this.listBox1.Items != null && this.listBox1.Items.Count > 0 && this.listBox1.SelectedItem != null;
            }
        }

        public bool ReadyToCompareBulk
        {
            get
            {
                return this.picturesA != null && this.picturesB != null && this.picturesA.Count > 0 && this.picturesB.Count > 0;
            }
        }

        public Form1()
        {
            this.InitializeComponent();
            this.openFileDialog1.CheckFileExists = true;
            this.folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            this.textBox2.Text = Form1.defaultSaveDir;
            this.openFileDialog1.Filter = fileFormatFilter;
            this.radioButtonLess.Checked = true;
        }

        private void LoadImage(string fileName, ref Dictionary<string, Bitmap> dict, ref ListBox listbox)
        {
            try
            {
                string fileName2 = Path.GetFileName(fileName);
                if (!dict.ContainsKey(fileName2))
                {
                    Bitmap value = new Bitmap(fileName);
                    if (listbox != null)
                    {
                        listbox.Items.Add(fileName2);
                    }
                    dict.Add(fileName2, value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occured.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.LoadImage(this.openFileDialog1.FileName, ref this.picturesA, ref this.listBox1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.LoadImage(this.openFileDialog1.FileName, ref this.picturesB, ref this.listBox2);
            }
        }
        //http://stackoverflow.com/a/9367937/3922292
        private unsafe Bitmap PixelDiff(Bitmap a, Bitmap b)
        {
            Bitmap bitmap = new Bitmap(a.Width, a.Height, PixelFormat.Format32bppArgb);
            Rectangle rect = new Rectangle(Point.Empty, a.Size);
            using (Extensions.DisposableImageData disposableImageData = a.LockBitsDisposable(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb))
            {
                using (Extensions.DisposableImageData disposableImageData2 = b.LockBitsDisposable(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb))
                {
                    using (Extensions.DisposableImageData disposableImageData3 = bitmap.LockBitsDisposable(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb))
                    {
                        byte* ptr = (byte*)((void*)disposableImageData.Scan0);
                        byte* ptr2 = (byte*)((void*)disposableImageData2.Scan0);
                        byte* ptr3 = (byte*)((void*)disposableImageData3.Scan0);
                        int num = disposableImageData.Stride * disposableImageData.Height;
                        for (int i = 0; i < num; i++)
                        {
                            if ((i + 1) % 4 == 0)
                            {
                                *ptr3 = (byte)((*ptr + *ptr2) / 2);
                            }
                            else
                            {
                                *ptr3 = (byte)~(*ptr ^ *ptr2);
                            }
                            ptr3++;
                            ptr++;
                            ptr2++;
                        }
                    }
                }
            }
            return bitmap;
        }

        private Tuple<Bitmap, uint> PixelDiffSafe(Bitmap a, Bitmap b)
        {
            Bitmap bitmap = new Bitmap(a.Width, a.Height);
            uint num = 0u;
            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < a.Width; j++)
                {
                    Color pixel = a.GetPixel(j, i);
                    Color pixel2 = b.GetPixel(j, i);
                    if (pixel != pixel2)
                    {
                        Color color = Color.FromArgb(255, 0, 0);
                        bitmap.SetPixel(j, i, color);
                        num += 1u;
                    }
                }
            }
            return new Tuple<Bitmap, uint>(bitmap, num);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                Bitmap bitmap = null;
                if (this.picturesA.TryGetValue(this.listBox1.SelectedItem.ToString(), out bitmap))
                {
                    this.pictureA = bitmap;
                    this.pictureABox.Refresh();
                }
            }
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedItem != null)
            {
                Bitmap bitmap = null;
                if (this.picturesB.TryGetValue(this.listBox2.SelectedItem.ToString(), out bitmap))
                {
                    this.pictureB = bitmap;
                    this.pictureBBox.Refresh();
                }
            }
        }

        private string Compare(Tuple<string, Bitmap> picA, Tuple<string, Bitmap> picB)
        {
            this.pictureA = picA.Item2;
            this.pictureB = picB.Item2;
            this.picturesDifferentPixels = this.PixelDiff(picA.Item2, picB.Item2);
            Tuple<Bitmap, uint> tuple = this.PixelDiffSafe(picA.Item2, picB.Item2);
            double arg_6E_0 = 100.0 * tuple.Item2 / (double)(picA.Item2.Width * picA.Item2.Height);
            this.pictureBoxsDifferentPixelsRed = tuple.Item1;
            this.label2.Text = tuple.Item2.ToString();
            this.label4.Text = Math.Round(100.0 * tuple.Item2 / (double)(picA.Item2.Width * picA.Item2.Height), 5).ToString();
            Tuple<double, Image, Image> tuple2 = ImageHash.Similarity(picA.Item2, picB.Item2);
            this.label13.Text = Math.Round(tuple2.Item1, 5).ToString();
            this.pictureAHash = tuple2.Item2;
            this.pictureBHash = tuple2.Item3;
            this.pictureAHashBox.Refresh();
            this.pictureBoxB.Refresh();
            this.pictureBoxDiffPixels.Refresh();
            this.pictureBoxDiffPixelsRed.Refresh();
            this.pictureABox.Refresh();
            this.pictureBBox.Refresh();
            if (this.checkBox1.Checked && (!this.checkBox2.Checked || (this.radioButtonLess.Checked && (decimal)tuple2.Item1 < this.numericUpDown1.Value) || (this.radioButtonGt.Checked && (decimal)tuple2.Item1 > this.numericUpDown1.Value)))
            {
                bool flag = false;
                if (!Directory.Exists(this.textBox2.Text))
                {
                    try
                    {
                        Directory.CreateDirectory(this.textBox2.Text);
                    }
                    catch (Exception)
                    {
                        flag = true;
                    }
                }
                if (!flag && Directory.Exists(this.textBox2.Text))
                {
                    if (this.hashAcheckBox.Checked)
                    {
                        this.pictureAHash.Save(Path.Combine(this.textBox2.Text, string.Concat(new object[]
                        {
                            Math.Round(tuple2.Item1, 1),
                            "_",
                            picA.Item1,
                            "_ps_",
                            ".jpg"
                        })));
                    }
                    if (this.HashBcheckBox.Checked)
                    {
                        this.pictureBHash.Save(Path.Combine(this.textBox2.Text, string.Concat(new object[]
                        {
                            Math.Round(tuple2.Item1, 1),
                            "_",
                            picB.Item1,
                            "_ps_",
                            ".jpg"
                        })));
                    }
                    if (this.DiffPixelscheckBox.Checked)
                    {
                        this.picturesDifferentPixels.Save(Path.Combine(this.textBox2.Text, string.Concat(new object[]
                        {
                            Math.Round(tuple2.Item1, 1),
                            "_",
                            picA.Item1,
                            "_and_",
                            picB.Item1,
                            "_c_",
                            ".jpg"
                        })));
                    }
                    if (this.DoffPixelsRedcheckBox.Checked)
                    {
                        this.pictureBoxsDifferentPixelsRed.Save(Path.Combine(this.textBox2.Text, string.Concat(new object[]
                        {
                            Math.Round(tuple2.Item1, 1),
                            "_",
                            picA.Item1,
                            "_and_",
                            picB.Item1,
                            "_r_",
                            ".jpg"
                        })));
                    }
                    if (this.PicACheckBox.Checked)
                    {
                        picA.Item2.Save(Path.Combine(this.textBox2.Text, picA.Item1));
                    }
                    if (this.PicBcheckBox.Checked)
                    {
                        picB.Item2.Save(Path.Combine(this.textBox2.Text, picB.Item1));
                    }
                }
            }
            return string.Format("{0},{1},{2},{3},{4}", new object[]
            {
                picA.Item1,
                picB.Item1,
                this.label2.Text,
                this.label4.Text,
                tuple2.Item1
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.ReadyToCompare)
            {
                Bitmap arg_26_0 = this.picturesA[this.listBox1.SelectedItem.ToString()];
                Bitmap arg_42_0 = this.picturesB[this.listBox2.SelectedItem.ToString()];
                this.Compare(new Tuple<string, Bitmap>(this.listBox1.SelectedItem.ToString(), this.picturesA[this.listBox1.SelectedItem.ToString()]), new Tuple<string, Bitmap>(this.listBox2.SelectedItem.ToString(), this.picturesB[this.listBox2.SelectedItem.ToString()]));
            }
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            if (this.pictureAHash != null)
            {
                e.Graphics.DrawImage(this.pictureAHash, 0, 0);
            }
        }

        private void pictureBox2_Paint_1(object sender, PaintEventArgs e)
        {
            if (this.pictureBHash != null)
            {
                e.Graphics.DrawImage(this.pictureBHash, 0, 0);
            }
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            if (this.picturesDifferentPixels != null)
            {
                e.Graphics.DrawImage(this.picturesDifferentPixels, 0, 0);
            }
        }

        private void pictureBox4_Paint(object sender, PaintEventArgs e)
        {
            if (this.pictureBoxsDifferentPixelsRed != null)
            {
                e.Graphics.DrawImage(this.pictureBoxsDifferentPixelsRed, 0, 0);
            }
        }

        private void pictureBox5_Paint(object sender, PaintEventArgs e)
        {
            if (this.pictureA != null)
            {
                e.Graphics.DrawImage(this.pictureA, 0, 0);
            }
        }

        private void pictureBox6_Paint(object sender, PaintEventArgs e)
        {
            if (this.pictureB != null)
            {
                e.Graphics.DrawImage(this.pictureB, 0, 0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                IOrderedEnumerable<string> orderedEnumerable = from x in Directory.EnumerateFiles(this.folderBrowserDialog1.SelectedPath, this.textBox1.Text)
                                                               orderby x
                                                               select x;
                foreach (string current in orderedEnumerable)
                {
                    this.LoadImage(current, ref this.picturesA, ref this.listBox1);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                IOrderedEnumerable<string> orderedEnumerable = from x in Directory.EnumerateFiles(this.folderBrowserDialog1.SelectedPath, this.textBox1.Text)
                                                               orderby x
                                                               select x;
                foreach (string current in orderedEnumerable)
                {
                    this.LoadImage(current, ref this.picturesB, ref this.listBox2);
                }
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox2.Enabled = this.checkBox1.Checked;
            this.radioButtonGt.Enabled = this.checkBox1.Checked;
            this.radioButtonLess.Enabled = this.checkBox1.Checked;
            this.checkBox2.Enabled = this.checkBox1.Checked;
            this.numericUpDown1.Enabled = this.checkBox1.Checked;
            this.PicACheckBox.Enabled = this.checkBox1.Checked;
            this.PicBcheckBox.Enabled = this.checkBox1.Checked;
            this.HashBcheckBox.Enabled = this.checkBox1.Checked;
            this.hashAcheckBox.Enabled = this.checkBox1.Checked;
            this.DiffPixelscheckBox.Enabled = this.checkBox1.Checked;
            this.DoffPixelsRedcheckBox.Enabled = this.checkBox1.Checked;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.ReadyToCompareBulk)
            {
                StreamWriter streamWriter = null;
                bool flag = false;
                if (this.checkBox1.Checked)
                {
                    if (!Directory.Exists(this.textBox2.Text))
                    {
                        try
                        {
                            Directory.CreateDirectory(this.textBox2.Text);
                        }
                        catch (Exception)
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        try
                        {
                            streamWriter = new StreamWriter(this.PathToSingleFileWithDiff);
                            streamWriter.WriteLine("FileA,FileB,PixelsDifferent,PercentDiff,PerceptualSimilarity");
                        }
                        catch (Exception)
                        {
                            streamWriter = null;
                        }
                    }
                }
                if (this.picturesA.Count != this.picturesB.Count)
                {
                    MessageBox.Show("Not equal number of pictures. The comparision will stop when the shorter list end is reached.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                using (Dictionary<string, Bitmap>.Enumerator enumerator = this.picturesA.GetEnumerator())
                {
                    using (Dictionary<string, Bitmap>.Enumerator enumerator2 = this.picturesB.GetEnumerator())
                    {
                        while (enumerator.MoveNext() && enumerator2.MoveNext())
                        {
                            KeyValuePair<string, Bitmap> current = enumerator.Current;
                            string arg_CD_0 = current.Key;
                            KeyValuePair<string, Bitmap> current2 = enumerator.Current;
                            Tuple<string, Bitmap> arg_F7_1 = new Tuple<string, Bitmap>(arg_CD_0, current2.Value);
                            KeyValuePair<string, Bitmap> current3 = enumerator2.Current;
                            string arg_F2_0 = current3.Key;
                            KeyValuePair<string, Bitmap> current4 = enumerator2.Current;
                            string value = this.Compare(arg_F7_1, new Tuple<string, Bitmap>(arg_F2_0, current4.Value));
                            if (streamWriter != null)
                            {
                                streamWriter.WriteLine(value);
                            }
                        }
                    }
                }
                if (streamWriter != null)
                {
                    streamWriter.Flush();
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Written by Piotr Falkowski piotr.falkowski.fm@gmail.com. © Piotr Falkowski 2015", "About", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void licenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This software is provided as is WITHOUT ANY GUARANTEES under the GNU General Public License v3.0: see http://www.gnu.org/licenses/gpl-3.0.html", "Licence", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }


    }
}
