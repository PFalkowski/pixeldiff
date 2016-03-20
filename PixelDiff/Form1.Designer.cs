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
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private Bitmap picturesDifferentPixels;

        private Bitmap pictureBoxsDifferentPixelsRed;

        private Image pictureAHash;

        private Image pictureBHash;

        private Image pictureA;

        private Image pictureB;

        private OpenFileDialog openFileDialog1;

        private Label label2;

        private Label label3;

        private Label label5;

        private Button button3;

        private Button button2;

        private Button button1;

        private Panel panel1;

        private Label label7;

        private Label label6;

        private PictureBox pictureBoxDiffPixels;

        private PictureBox pictureBoxDiffPixelsRed;

        private Label label9;

        private Label label8;

        private SplitContainer splitContainer1;

        private ListBox listBox1;

        private ListBox listBox2;

        private SplitContainer splitContainer2;

        private Label label4;

        private Label label1;

        private Button button4;

        private FolderBrowserDialog folderBrowserDialog1;

        private Button button5;

        private Label label11;

        private TextBox textBox2;

        private Label label10;

        private TextBox textBox1;

        private CheckBox checkBox1;

        private Button button6;

        private ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem aboutToolStripMenuItem;

        private ToolStripMenuItem licenceToolStripMenuItem;

        private PictureBox pictureAHashBox;

        private Label label13;

        private Label label14;

        private Label label12;

        private PictureBox pictureBoxB;

        private GroupBox groupBox2;

        private GroupBox LoadBox;

        private GroupBox groupBox1;

        private PictureBox pictureBBox;

        private PictureBox pictureABox;

        private Label label18;

        private Label label17;

        private Label label16;

        private Label label15;

        private Label label19;

        private NumericUpDown numericUpDown1;

        private CheckBox checkBox2;

        private CheckBox DoffPixelsRedcheckBox;

        private CheckBox DiffPixelscheckBox;

        private CheckBox hashAcheckBox;

        private CheckBox HashBcheckBox;

        private CheckBox PicBcheckBox;

        private CheckBox PicACheckBox;

        private RadioButton radioButtonGt;

        private RadioButton radioButtonLess;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";
            base.Name = "Form1";
            this.openFileDialog1 = new OpenFileDialog();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label5 = new Label();
            this.button3 = new Button();
            this.button2 = new Button();
            this.button1 = new Button();
            this.panel1 = new Panel();
            this.DoffPixelsRedcheckBox = new CheckBox();
            this.DiffPixelscheckBox = new CheckBox();
            this.hashAcheckBox = new CheckBox();
            this.HashBcheckBox = new CheckBox();
            this.PicBcheckBox = new CheckBox();
            this.PicACheckBox = new CheckBox();
            this.label18 = new Label();
            this.label17 = new Label();
            this.label16 = new Label();
            this.label15 = new Label();
            this.pictureBoxB = new PictureBox();
            this.pictureAHashBox = new PictureBox();
            this.pictureBBox = new PictureBox();
            this.pictureABox = new PictureBox();
            this.label7 = new Label();
            this.label6 = new Label();
            this.pictureBoxDiffPixels = new PictureBox();
            this.pictureBoxDiffPixelsRed = new PictureBox();
            this.label9 = new Label();
            this.label8 = new Label();
            this.splitContainer1 = new SplitContainer();
            this.listBox1 = new ListBox();
            this.listBox2 = new ListBox();
            this.splitContainer2 = new SplitContainer();
            this.groupBox2 = new GroupBox();
            this.label19 = new Label();
            this.numericUpDown1 = new NumericUpDown();
            this.checkBox2 = new CheckBox();
            this.textBox1 = new TextBox();
            this.label10 = new Label();
            this.textBox2 = new TextBox();
            this.checkBox1 = new CheckBox();
            this.label11 = new Label();
            this.LoadBox = new GroupBox();
            this.button6 = new Button();
            this.button4 = new Button();
            this.button5 = new Button();
            this.groupBox1 = new GroupBox();
            this.label1 = new Label();
            this.label13 = new Label();
            this.label14 = new Label();
            this.label12 = new Label();
            this.label4 = new Label();
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new ToolStripMenuItem();
            this.licenceToolStripMenuItem = new ToolStripMenuItem();
            this.radioButtonLess = new RadioButton();
            this.radioButtonGt = new RadioButton();
            this.panel1.SuspendLayout();
            ((ISupportInitialize)this.pictureBoxB).BeginInit();
            ((ISupportInitialize)this.pictureAHashBox).BeginInit();
            ((ISupportInitialize)this.pictureBBox).BeginInit();
            ((ISupportInitialize)this.pictureABox).BeginInit();
            ((ISupportInitialize)this.pictureBoxDiffPixels).BeginInit();
            ((ISupportInitialize)this.pictureBoxDiffPixelsRed).BeginInit();
            ((ISupportInitialize)this.splitContainer1).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((ISupportInitialize)this.splitContainer2).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize)this.numericUpDown1).BeginInit();
            this.LoadBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.openFileDialog1.FileName = "openFileDialog1";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(105, 29);
            this.label2.Name = "label2";
            this.label2.Size = new Size(13, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "0";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(3, 44);
            this.label3.Name = "label3";
            this.label3.Size = new Size(97, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Percent difference:";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(174, 44);
            this.label5.Name = "label5";
            this.label5.Size = new Size(15, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "%";
            this.button3.Location = new Point(6, 77);
            this.button3.Name = "button3";
            this.button3.Size = new Size(99, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Get difference!";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.button2.Location = new Point(6, 48);
            this.button2.Name = "button2";
            this.button2.Size = new Size(100, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Load image B";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button1.Location = new Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new Size(99, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load image A";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.panel1.Controls.Add(this.DoffPixelsRedcheckBox);
            this.panel1.Controls.Add(this.DiffPixelscheckBox);
            this.panel1.Controls.Add(this.hashAcheckBox);
            this.panel1.Controls.Add(this.HashBcheckBox);
            this.panel1.Controls.Add(this.PicBcheckBox);
            this.panel1.Controls.Add(this.PicACheckBox);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.pictureBoxB);
            this.panel1.Controls.Add(this.pictureAHashBox);
            this.panel1.Controls.Add(this.pictureBBox);
            this.panel1.Controls.Add(this.pictureABox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pictureBoxDiffPixels);
            this.panel1.Controls.Add(this.pictureBoxDiffPixelsRed);
            this.panel1.Location = new Point(2, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(819, 665);
            this.panel1.TabIndex = 12;
            this.DoffPixelsRedcheckBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.DoffPixelsRedcheckBox.AutoSize = true;
            this.DoffPixelsRedcheckBox.Checked = true;
            this.DoffPixelsRedcheckBox.CheckState = CheckState.Checked;
            this.DoffPixelsRedcheckBox.Location = new Point(689, 379);
            this.DoffPixelsRedcheckBox.Name = "DoffPixelsRedcheckBox";
            this.DoffPixelsRedcheckBox.Size = new Size(49, 17);
            this.DoffPixelsRedcheckBox.TabIndex = 35;
            this.DoffPixelsRedcheckBox.Text = "save";
            this.DoffPixelsRedcheckBox.UseVisualStyleBackColor = true;
            this.DiffPixelscheckBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.DiffPixelscheckBox.AutoSize = true;
            this.DiffPixelscheckBox.Checked = true;
            this.DiffPixelscheckBox.CheckState = CheckState.Checked;
            this.DiffPixelscheckBox.Location = new Point(84, 380);
            this.DiffPixelscheckBox.Name = "DiffPixelscheckBox";
            this.DiffPixelscheckBox.Size = new Size(49, 17);
            this.DiffPixelscheckBox.TabIndex = 34;
            this.DiffPixelscheckBox.Text = "save";
            this.DiffPixelscheckBox.UseVisualStyleBackColor = true;
            this.hashAcheckBox.AutoSize = true;
            this.hashAcheckBox.Checked = true;
            this.hashAcheckBox.CheckState = CheckState.Checked;
            this.hashAcheckBox.Location = new Point(359, 356);
            this.hashAcheckBox.Name = "hashAcheckBox";
            this.hashAcheckBox.Size = new Size(49, 17);
            this.hashAcheckBox.TabIndex = 33;
            this.hashAcheckBox.Text = "save";
            this.hashAcheckBox.UseVisualStyleBackColor = true;
            this.HashBcheckBox.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.HashBcheckBox.AutoSize = true;
            this.HashBcheckBox.Checked = true;
            this.HashBcheckBox.CheckState = CheckState.Checked;
            this.HashBcheckBox.Location = new Point(449, 356);
            this.HashBcheckBox.Name = "HashBcheckBox";
            this.HashBcheckBox.Size = new Size(49, 17);
            this.HashBcheckBox.TabIndex = 32;
            this.HashBcheckBox.Text = "save";
            this.HashBcheckBox.UseVisualStyleBackColor = true;
            this.PicBcheckBox.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.PicBcheckBox.AutoSize = true;
            this.PicBcheckBox.Checked = true;
            this.PicBcheckBox.CheckState = CheckState.Checked;
            this.PicBcheckBox.Location = new Point(526, 7);
            this.PicBcheckBox.Name = "PicBcheckBox";
            this.PicBcheckBox.Size = new Size(49, 17);
            this.PicBcheckBox.TabIndex = 31;
            this.PicBcheckBox.Text = "save";
            this.PicBcheckBox.UseVisualStyleBackColor = true;
            this.PicACheckBox.AutoSize = true;
            this.PicACheckBox.Checked = true;
            this.PicACheckBox.CheckState = CheckState.Checked;
            this.PicACheckBox.Location = new Point(41, 7);
            this.PicACheckBox.Name = "PicACheckBox";
            this.PicACheckBox.Size = new Size(49, 17);
            this.PicACheckBox.TabIndex = 30;
            this.PicACheckBox.Text = "save";
            this.PicACheckBox.UseVisualStyleBackColor = true;
            this.label18.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.label18.AutoSize = true;
            this.label18.Location = new Point(489, 8);
            this.label18.Name = "label18";
            this.label18.Size = new Size(31, 13);
            this.label18.TabIndex = 21;
            this.label18.Text = "pic B";
            this.label17.AutoSize = true;
            this.label17.Location = new Point(4, 8);
            this.label17.Name = "label17";
            this.label17.Size = new Size(31, 13);
            this.label17.TabIndex = 20;
            this.label17.Text = "pic A";
            this.label16.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.label16.AutoSize = true;
            this.label16.Location = new Point(446, 210);
            this.label16.Name = "label16";
            this.label16.Size = new Size(40, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "hash B";
            this.label15.AutoSize = true;
            this.label15.Location = new Point(356, 210);
            this.label15.Name = "label15";
            this.label15.Size = new Size(40, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "hash A";
            this.pictureBoxB.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.pictureBoxB.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBoxB.Location = new Point(435, 226);
            this.pictureBoxB.Name = "pictureBoxB";
            this.pictureBoxB.Size = new Size(128, 128);
            this.pictureBoxB.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBoxB.TabIndex = 15;
            this.pictureBoxB.TabStop = false;
            this.pictureBoxB.Paint += new PaintEventHandler(this.pictureBox2_Paint_1);
            this.pictureAHashBox.BorderStyle = BorderStyle.FixedSingle;
            this.pictureAHashBox.Location = new Point(269, 226);
            this.pictureAHashBox.Name = "pictureAHashBox";
            this.pictureAHashBox.Size = new Size(128, 128);
            this.pictureAHashBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureAHashBox.TabIndex = 14;
            this.pictureAHashBox.TabStop = false;
            this.pictureAHashBox.Paint += new PaintEventHandler(this.pictureBox1_Paint_1);
            this.pictureBBox.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.pictureBBox.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBBox.Location = new Point(492, 30);
            this.pictureBBox.Name = "pictureBBox";
            this.pictureBBox.Size = new Size(343, 343);
            this.pictureBBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBBox.TabIndex = 17;
            this.pictureBBox.TabStop = false;
            this.pictureBBox.WaitOnLoad = true;
            this.pictureBBox.Paint += new PaintEventHandler(this.pictureBox6_Paint);
            this.pictureABox.BorderStyle = BorderStyle.FixedSingle;
            this.pictureABox.InitialImage = null;
            this.pictureABox.Location = new Point(7, 30);
            this.pictureABox.Name = "pictureABox";
            this.pictureABox.Size = new Size(343, 343);
            this.pictureABox.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureABox.TabIndex = 16;
            this.pictureABox.TabStop = false;
            this.pictureABox.WaitOnLoad = true;
            this.pictureABox.Paint += new PaintEventHandler(this.pictureBox5_Paint);
            this.label7.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.label7.AutoSize = true;
            this.label7.Location = new Point(551, 380);
            this.label7.Name = "label7";
            this.label7.Size = new Size(127, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "different pixels (one color)";
            this.label6.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.label6.AutoSize = true;
            this.label6.Location = new Point(4, 380);
            this.label6.Name = "label6";
            this.label6.Size = new Size(74, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "different pixels";
            this.pictureBoxDiffPixels.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.pictureBoxDiffPixels.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBoxDiffPixels.Location = new Point(7, 400);
            this.pictureBoxDiffPixels.Name = "pictureBoxDiffPixels";
            this.pictureBoxDiffPixels.Size = new Size(256, 256);
            this.pictureBoxDiffPixels.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBoxDiffPixels.TabIndex = 6;
            this.pictureBoxDiffPixels.TabStop = false;
            this.pictureBoxDiffPixels.Paint += new PaintEventHandler(this.pictureBox3_Paint);
            this.pictureBoxDiffPixelsRed.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.pictureBoxDiffPixelsRed.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBoxDiffPixelsRed.Location = new Point(554, 406);
            this.pictureBoxDiffPixelsRed.Name = "pictureBoxDiffPixelsRed";
            this.pictureBoxDiffPixelsRed.Size = new Size(256, 256);
            this.pictureBoxDiffPixelsRed.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBoxDiffPixelsRed.TabIndex = 11;
            this.pictureBoxDiffPixelsRed.TabStop = false;
            this.pictureBoxDiffPixelsRed.Paint += new PaintEventHandler(this.pictureBox4_Paint);
            this.label9.AutoSize = true;
            this.label9.Location = new Point(3, 29);
            this.label9.Name = "label9";
            this.label9.Size = new Size(79, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Different pixels:";
            this.label8.AutoSize = true;
            this.label8.Location = new Point(88, 29);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0, 13);
            this.label8.TabIndex = 14;
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.Location = new Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            this.splitContainer1.Panel2.Controls.Add(this.listBox2);
            this.splitContainer1.Size = new Size(387, 784);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 15;
            this.listBox1.Dock = DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new Size(200, 784);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox2.Dock = DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new Point(0, 0);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new Size(183, 784);
            this.listBox2.TabIndex = 2;
            this.listBox2.SelectedIndexChanged += new EventHandler(this.listBox2_SelectedIndexChanged_1);
            this.splitContainer2.Dock = DockStyle.Fill;
            this.splitContainer2.Location = new Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel2.Controls.Add(this.LoadBox);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new Size(1215, 784);
            this.splitContainer2.SplitterDistance = 387;
            this.splitContainer2.TabIndex = 16;
            this.groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.groupBox2.Controls.Add(this.radioButtonGt);
            this.groupBox2.Controls.Add(this.radioButtonLess);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new Point(474, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(338, 107);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save";
            this.label19.AutoSize = true;
            this.label19.Location = new Point(222, 71);
            this.label19.Name = "label19";
            this.label19.Size = new Size(28, 13);
            this.label19.TabIndex = 29;
            this.label19.Text = "than";
            this.numericUpDown1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.numericUpDown1.Location = new Point(256, 67);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new Size(76, 20);
            this.numericUpDown1.TabIndex = 27;
            NumericUpDown arg_16BD_0 = this.numericUpDown1;
            int[] array = new int[4];
            array[0] = 70;
            arg_16BD_0.Value = new decimal(array);
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = CheckState.Checked;
            this.checkBox2.Location = new Point(10, 70);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new Size(132, 17);
            this.checkBox2.TabIndex = 26;
            this.checkBox2.Text = "Save only if similarity is";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.textBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.textBox1.Location = new Point(97, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(235, 20);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "*.jpg";
            this.label10.AutoSize = true;
            this.label10.Location = new Point(7, 26);
            this.label10.Name = "label10";
            this.label10.Size = new Size(43, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "pattern:";
            this.textBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.textBox2.Location = new Point(97, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(235, 20);
            this.textBox2.TabIndex = 21;
            this.textBox2.Click += new EventHandler(this.textBox2_Click);
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = CheckState.Checked;
            this.checkBox1.Location = new Point(258, 90);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(74, 17);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Auto save";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
            this.label11.AutoSize = true;
            this.label11.Location = new Point(7, 48);
            this.label11.Name = "label11";
            this.label11.Size = new Size(45, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "save to:";
            this.LoadBox.Controls.Add(this.button1);
            this.LoadBox.Controls.Add(this.button3);
            this.LoadBox.Controls.Add(this.button6);
            this.LoadBox.Controls.Add(this.button2);
            this.LoadBox.Controls.Add(this.button4);
            this.LoadBox.Controls.Add(this.button5);
            this.LoadBox.Location = new Point(3, 3);
            this.LoadBox.Name = "LoadBox";
            this.LoadBox.Size = new Size(227, 107);
            this.LoadBox.TabIndex = 29;
            this.LoadBox.TabStop = false;
            this.LoadBox.Text = "Load";
            this.button6.BackColor = SystemColors.ButtonShadow;
            this.button6.Location = new Point(111, 77);
            this.button6.Name = "button6";
            this.button6.Size = new Size(99, 23);
            this.button6.TabIndex = 24;
            this.button6.Text = "Get differences!";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new EventHandler(this.button6_Click);
            this.button4.BackColor = SystemColors.ButtonShadow;
            this.button4.Location = new Point(111, 19);
            this.button4.Name = "button4";
            this.button4.Size = new Size(99, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "Load folder into A";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new EventHandler(this.button4_Click);
            this.button5.BackColor = SystemColors.ButtonShadow;
            this.button5.Location = new Point(111, 48);
            this.button5.Name = "button5";
            this.button5.Size = new Size(99, 23);
            this.button5.TabIndex = 18;
            this.button5.Text = "Load folder into B";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new EventHandler(this.button5_Click);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new Point(236, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(232, 107);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(174, 29);
            this.label1.Name = "label1";
            this.label1.Size = new Size(18, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "px";
            this.label13.AutoSize = true;
            this.label13.Location = new Point(105, 57);
            this.label13.Name = "label13";
            this.label13.Size = new Size(13, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "0";
            this.label14.AutoSize = true;
            this.label14.Location = new Point(174, 57);
            this.label14.Name = "label14";
            this.label14.Size = new Size(15, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "%";
            this.label12.AutoSize = true;
            this.label12.Location = new Point(3, 57);
            this.label12.Name = "label12";
            this.label12.Size = new Size(96, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Percptual similarity:";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(105, 44);
            this.label4.Name = "label4";
            this.label4.Size = new Size(13, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "0";
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.aboutToolStripMenuItem,
                this.licenceToolStripMenuItem
            });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(115, 48);
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new EventHandler(this.aboutToolStripMenuItem_Click);
            this.licenceToolStripMenuItem.Name = "licenceToolStripMenuItem";
            this.licenceToolStripMenuItem.Size = new Size(114, 22);
            this.licenceToolStripMenuItem.Text = "Licence";
            this.licenceToolStripMenuItem.Click += new EventHandler(this.licenceToolStripMenuItem_Click);
            this.radioButtonLess.AutoSize = true;
            this.radioButtonLess.Location = new Point(148, 69);
            this.radioButtonLess.Name = "radioButtonLess";
            this.radioButtonLess.Size = new Size(31, 17);
            this.radioButtonLess.TabIndex = 30;
            this.radioButtonLess.TabStop = true;
            this.radioButtonLess.Text = "<";
            this.radioButtonLess.UseVisualStyleBackColor = true;
            this.radioButtonGt.AutoSize = true;
            this.radioButtonGt.Location = new Point(185, 69);
            this.radioButtonGt.Name = "radioButtonGt";
            this.radioButtonGt.Size = new Size(31, 17);
            this.radioButtonGt.TabIndex = 31;
            this.radioButtonGt.TabStop = true;
            this.radioButtonGt.Text = ">";
            this.radioButtonGt.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(1215, 784);
            this.ContextMenuStrip = this.contextMenuStrip1;
            base.Controls.Add(this.splitContainer2);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((ISupportInitialize)this.pictureBoxB).EndInit();
            ((ISupportInitialize)this.pictureAHashBox).EndInit();
            ((ISupportInitialize)this.pictureBBox).EndInit();
            ((ISupportInitialize)this.pictureABox).EndInit();
            ((ISupportInitialize)this.pictureBoxDiffPixels).EndInit();
            ((ISupportInitialize)this.pictureBoxDiffPixelsRed).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((ISupportInitialize)this.splitContainer1).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((ISupportInitialize)this.splitContainer2).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((ISupportInitialize)this.numericUpDown1).EndInit();
            this.LoadBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            base.ResumeLayout(false);
        }
        #endregion
    }
}

