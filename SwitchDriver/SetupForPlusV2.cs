// Decompiled with JetBrains decompiler
// Type: ASCOM.WandererBoxes.SetupForPlusV2
// Assembly: ASCOM.WandererBoxes.Switch, Version=6.6.0.0, Culture=neutral, PublicKeyToken=5a596dde3293c610
// MVID: E3106A5C-05F3-42C7-89F9-2A2C7253BE13
// Assembly location: C:\Program Files (x86)\Wanderer Astro\ASCOM.WandererBoxes.Switch.dll

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ASCOM.Utilities;
using ASCOM.WandererBoxes.Properties;

namespace ASCOM.WandererBoxes
{
  [ComVisible(false)]
  public class SetupForPlusV2 : Form
  {
    private TraceLogger tl;
    public static int port;
    private Form1 M;
    internal static string Switch1;
    internal static string Switch2;
    internal static string Switch3;
    internal static string Switch4;
    private IContainer components;
    private Button cmdOK;
    private Button cmdCancel;
    private Label label1;
    private PictureBox picASCOM;
    private LinkLabel linkLabel1;
    private TextBox textBox4;
    private TextBox textBox3;
    private TextBox textBox2;
    private TextBox textBox1;
    private PictureBox pictureBox1;
    private PictureBox pictureBox2;
    private Label label7;
    private PictureBox pictureBox5;
    private PictureBox pictureBox6;
    private TextBox textBox5;
    private CheckBox checkBox3;
    private CheckBox checkBox4;
    private CheckBox checkBox2;
    private CheckBox checkBox1;
    private Label label50;
    private Label label29;
    private Label label30;
    private Label label31;
    private Label label33;
    private Label label34;
    private Label label35;
    private Label label36;
    private TrackBar trackBar1;
    private TrackBar trackBar8;
    private TrackBar trackBar12;
    private Label label44;
    private Label label45;
    private Label label46;
    private TrackBar trackBar16;
    private TrackBar trackBar17;
    private TrackBar trackBar18;
    private Label label47;
    private Label label48;
    private Label label49;
    private PictureBox pictureBox17;
    private PictureBox pictureBox18;
    private Label label6;
    private Label label17;
    private PictureBox pictureBox13;
    private PictureBox pictureBox8;
    private PictureBox pictureBox3;
    private PictureBox pictureBox4;
    private PictureBox pictureBox7;
    private PictureBox pictureBox9;
    private PictureBox pictureBox10;
    private PictureBox pictureBox11;
    private CheckBox checkBox9;

    public SetupForPlusV2(TraceLogger tlDriver)
    {
      this.InitializeComponent();
      this.tl = tlDriver;
      this.InitUI();
    }

    private void cmdOK_Click(object sender, EventArgs e)
    {
      Switch.DC1_3name = this.textBox1.Text;
      Switch.DC4name = this.textBox2.Text;
      Switch.DC5name = this.textBox3.Text;
      Switch.DC6name = this.textBox4.Text;
      Switch.USBname = this.textBox5.Text;
      Switch.dew1low = this.trackBar18.Value;
      Switch.dew1high = this.trackBar17.Value;
      Switch.dew1maximum = this.trackBar16.Value;
      Switch.dew2low = this.trackBar12.Value;
      Switch.dew2high = this.trackBar8.Value;
      Switch.dew2maximum = this.trackBar1.Value;
      Switch.heater1Mode = !this.checkBox1.Checked ? "Switch1" : "Dew Heater1";
      if (this.checkBox4.Checked)
        Switch.heater2Mode = "Dew Heater2";
      else
        Switch.heater2Mode = "Switch2";
    }

    private void cmdCancel_Click(object sender, EventArgs e) => this.Close();

    private void BrowseToAscom(object sender, EventArgs e)
    {
      try
      {
        Process.Start("https://ascom-standards.org/");
      }
      catch (Win32Exception ex)
      {
        if (ex.ErrorCode != -2147467259 /*0x80004005*/)
          return;
        int num = (int) MessageBox.Show(ex.Message);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void InitUI()
    {
    }

    private void label17_Click(object sender, EventArgs e)
    {
      int num = (int) new Form1().ShowDialog();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    }

    private void label17_Click_1(object sender, EventArgs e)
    {
      int num = (int) new Form1().ShowDialog();
    }

    private void label50_Click(object sender, EventArgs e)
    {
    }

    private void label33_Click(object sender, EventArgs e)
    {
    }

    private void trackBar18_Scroll(object sender, EventArgs e)
    {
      this.label46.Text = this.trackBar18.Value.ToString();
    }

    private void trackBar17_Scroll(object sender, EventArgs e)
    {
      this.label45.Text = this.trackBar17.Value.ToString();
    }

    private void trackBar16_Scroll(object sender, EventArgs e)
    {
      this.label44.Text = this.trackBar16.Value.ToString();
    }

    private void trackBar12_Scroll(object sender, EventArgs e)
    {
      this.label36.Text = this.trackBar12.Value.ToString();
    }

    private void trackBar8_Scroll(object sender, EventArgs e)
    {
      this.label35.Text = this.trackBar8.Value.ToString();
    }

    private void trackBar1_Scroll_1(object sender, EventArgs e)
    {
      this.label34.Text = this.trackBar1.Value.ToString();
    }

    private void checkBox4_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox1.Checked)
      {
        this.checkBox2.Checked = false;
        Switch.heater1Mode = "Dew Heater1";
        Switch.DC1status = "3";
        this.trackBar18.Enabled = this.trackBar17.Enabled = this.trackBar16.Enabled = true;
        this.label50.ForeColor = this.label49.ForeColor = this.label48.ForeColor = this.label47.ForeColor = this.label46.ForeColor = this.label45.ForeColor = this.label44.ForeColor = Color.White;
      }
      else
      {
        this.checkBox2.Checked = true;
        Switch.heater1Mode = "Switch1";
        Switch.DC1status = "On";
        this.trackBar18.Enabled = this.trackBar17.Enabled = this.trackBar16.Enabled = false;
        this.label50.ForeColor = this.label49.ForeColor = this.label48.ForeColor = this.label47.ForeColor = this.label46.ForeColor = this.label45.ForeColor = this.label44.ForeColor = Color.DimGray;
      }
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox2.Checked)
      {
        this.checkBox1.Checked = false;
        Switch.heater1Mode = "Switch1";
        Switch.DC1status = "On";
        this.trackBar18.Enabled = this.trackBar17.Enabled = this.trackBar16.Enabled = false;
        this.label50.ForeColor = this.label49.ForeColor = this.label48.ForeColor = this.label47.ForeColor = this.label46.ForeColor = this.label45.ForeColor = this.label44.ForeColor = Color.DimGray;
      }
      else
      {
        this.checkBox1.Checked = true;
        Switch.heater1Mode = "Dew Heater1";
        Switch.DC1status = "3";
        this.trackBar18.Enabled = this.trackBar17.Enabled = this.trackBar16.Enabled = true;
        this.label50.ForeColor = this.label49.ForeColor = this.label48.ForeColor = this.label47.ForeColor = this.label46.ForeColor = this.label45.ForeColor = this.label44.ForeColor = Color.White;
      }
    }

    private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
    {
      if (this.checkBox4.Checked)
      {
        this.checkBox3.Checked = false;
        Switch.heater2Mode = "Dew Heater2";
        Switch.DC2status = "3";
        this.trackBar12.Enabled = this.trackBar8.Enabled = this.trackBar1.Enabled = true;
        this.label33.ForeColor = this.label31.ForeColor = this.label30.ForeColor = this.label29.ForeColor = this.label36.ForeColor = this.label35.ForeColor = this.label34.ForeColor = Color.White;
      }
      else
      {
        this.checkBox3.Checked = true;
        Switch.heater2Mode = "Switch2";
        Switch.DC2status = "On";
        this.trackBar12.Enabled = this.trackBar8.Enabled = this.trackBar1.Enabled = false;
        this.label33.ForeColor = this.label31.ForeColor = this.label30.ForeColor = this.label29.ForeColor = this.label36.ForeColor = this.label35.ForeColor = this.label34.ForeColor = Color.Gray;
      }
    }

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox3.Checked)
      {
        this.checkBox4.Checked = false;
        Switch.heater2Mode = "Switch2";
        Switch.DC2status = "On";
        this.trackBar12.Enabled = this.trackBar8.Enabled = this.trackBar1.Enabled = false;
        this.label33.ForeColor = this.label31.ForeColor = this.label30.ForeColor = this.label29.ForeColor = this.label36.ForeColor = this.label35.ForeColor = this.label34.ForeColor = Color.Gray;
      }
      else
      {
        this.checkBox4.Checked = true;
        Switch.heater2Mode = "Dew Heater2";
        Switch.DC2status = "3";
        this.trackBar12.Enabled = this.trackBar8.Enabled = this.trackBar1.Enabled = true;
        this.label33.ForeColor = this.label31.ForeColor = this.label30.ForeColor = this.label29.ForeColor = this.label36.ForeColor = this.label35.ForeColor = this.label34.ForeColor = Color.White;
      }
    }

    private void checkBox9_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox9.Checked)
      {
        Switch.Sensortype = "Weather";
        if (this.checkBox2.Checked)
        {
          this.trackBar18.Enabled = this.trackBar17.Enabled = this.trackBar16.Enabled = false;
          this.label50.ForeColor = this.label49.ForeColor = this.label48.ForeColor = this.label47.ForeColor = this.label46.ForeColor = this.label45.ForeColor = this.label44.ForeColor = Color.DimGray;
        }
        if (!this.checkBox3.Checked)
          return;
        this.trackBar12.Enabled = this.trackBar8.Enabled = this.trackBar1.Enabled = false;
        this.label33.ForeColor = this.label31.ForeColor = this.label30.ForeColor = this.label29.ForeColor = this.label36.ForeColor = this.label35.ForeColor = this.label34.ForeColor = Color.DimGray;
      }
      else
        Switch.Sensortype = "None";
    }

    private void textBox5_TextChanged(object sender, EventArgs e)
    {
    }

    private void pictureBox2_Click(object sender, EventArgs e)
    {
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("http://www.wandererastro.com/");
    }

    private void SetupDialogForm_Load(object sender, EventArgs e)
    {
      this.textBox1.Text = Switch.DC1_3name;
      this.textBox2.Text = Switch.DC4name;
      this.textBox3.Text = Switch.DC5name;
      this.textBox4.Text = Switch.DC6name;
      this.textBox5.Text = Switch.USBname;
      this.trackBar18.Value = Switch.dew1low;
      this.label46.Text = this.trackBar18.Value.ToString();
      this.trackBar17.Value = Switch.dew1high;
      this.label45.Text = this.trackBar17.Value.ToString();
      this.trackBar16.Value = Switch.dew1maximum;
      this.label44.Text = this.trackBar16.Value.ToString();
      this.trackBar12.Value = Switch.dew2low;
      this.label36.Text = this.trackBar12.Value.ToString();
      this.trackBar8.Value = Switch.dew2high;
      this.label35.Text = this.trackBar8.Value.ToString();
      this.trackBar1.Value = Switch.dew2maximum;
      this.label34.Text = this.trackBar1.Value.ToString();
      if (Switch.heater1Mode == "Dew Heater1")
      {
        this.checkBox1.Checked = true;
        this.trackBar18.Enabled = this.trackBar17.Enabled = this.trackBar16.Enabled = true;
        this.label50.ForeColor = this.label49.ForeColor = this.label48.ForeColor = this.label47.ForeColor = this.label46.ForeColor = this.label45.ForeColor = this.label44.ForeColor = Color.White;
        this.checkBox2.Checked = false;
      }
      else
      {
        this.checkBox2.Checked = true;
        this.trackBar18.Enabled = this.trackBar17.Enabled = this.trackBar16.Enabled = false;
        this.label50.ForeColor = this.label49.ForeColor = this.label48.ForeColor = this.label47.ForeColor = this.label46.ForeColor = this.label45.ForeColor = this.label44.ForeColor = Color.DimGray;
        this.checkBox1.Checked = false;
      }
      if (Switch.heater2Mode == "Dew Heater2")
      {
        this.checkBox4.Checked = true;
        this.trackBar12.Enabled = this.trackBar8.Enabled = this.trackBar1.Enabled = true;
        this.label33.ForeColor = this.label31.ForeColor = this.label30.ForeColor = this.label29.ForeColor = this.label36.ForeColor = this.label35.ForeColor = this.label34.ForeColor = Color.White;
        this.checkBox3.Checked = false;
      }
      else
      {
        this.checkBox3.Checked = true;
        this.trackBar12.Enabled = this.trackBar8.Enabled = this.trackBar1.Enabled = false;
        this.label33.ForeColor = this.label31.ForeColor = this.label30.ForeColor = this.label29.ForeColor = this.label36.ForeColor = this.label35.ForeColor = this.label34.ForeColor = Color.DimGray;
        this.checkBox4.Checked = false;
      }
      if (!(Switch.Sensortype == "Weather"))
        return;
      this.checkBox9.Enabled = true;
      this.checkBox9.Checked = true;
      this.checkBox9.ForeColor = Color.Black;
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (SetupForPlusV2));
      this.cmdOK = new Button();
      this.cmdCancel = new Button();
      this.label1 = new Label();
      this.picASCOM = new PictureBox();
      this.linkLabel1 = new LinkLabel();
      this.textBox4 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox1 = new TextBox();
      this.pictureBox1 = new PictureBox();
      this.pictureBox2 = new PictureBox();
      this.label7 = new Label();
      this.pictureBox5 = new PictureBox();
      this.pictureBox6 = new PictureBox();
      this.textBox5 = new TextBox();
      this.checkBox3 = new CheckBox();
      this.checkBox4 = new CheckBox();
      this.checkBox2 = new CheckBox();
      this.checkBox1 = new CheckBox();
      this.label50 = new Label();
      this.label29 = new Label();
      this.label30 = new Label();
      this.label31 = new Label();
      this.label33 = new Label();
      this.label34 = new Label();
      this.label35 = new Label();
      this.label36 = new Label();
      this.trackBar1 = new TrackBar();
      this.trackBar8 = new TrackBar();
      this.trackBar12 = new TrackBar();
      this.label44 = new Label();
      this.label45 = new Label();
      this.label46 = new Label();
      this.trackBar16 = new TrackBar();
      this.trackBar17 = new TrackBar();
      this.trackBar18 = new TrackBar();
      this.label47 = new Label();
      this.label48 = new Label();
      this.label49 = new Label();
      this.pictureBox17 = new PictureBox();
      this.pictureBox18 = new PictureBox();
      this.label6 = new Label();
      this.label17 = new Label();
      this.pictureBox13 = new PictureBox();
      this.pictureBox8 = new PictureBox();
      this.pictureBox3 = new PictureBox();
      this.pictureBox4 = new PictureBox();
      this.pictureBox7 = new PictureBox();
      this.pictureBox9 = new PictureBox();
      this.pictureBox10 = new PictureBox();
      this.pictureBox11 = new PictureBox();
      this.checkBox9 = new CheckBox();
      ((ISupportInitialize) this.picASCOM).BeginInit();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      ((ISupportInitialize) this.pictureBox5).BeginInit();
      ((ISupportInitialize) this.pictureBox6).BeginInit();
      this.trackBar1.BeginInit();
      this.trackBar8.BeginInit();
      this.trackBar12.BeginInit();
      this.trackBar16.BeginInit();
      this.trackBar17.BeginInit();
      this.trackBar18.BeginInit();
      ((ISupportInitialize) this.pictureBox17).BeginInit();
      ((ISupportInitialize) this.pictureBox18).BeginInit();
      ((ISupportInitialize) this.pictureBox13).BeginInit();
      ((ISupportInitialize) this.pictureBox8).BeginInit();
      ((ISupportInitialize) this.pictureBox3).BeginInit();
      ((ISupportInitialize) this.pictureBox4).BeginInit();
      ((ISupportInitialize) this.pictureBox7).BeginInit();
      ((ISupportInitialize) this.pictureBox9).BeginInit();
      ((ISupportInitialize) this.pictureBox10).BeginInit();
      ((ISupportInitialize) this.pictureBox11).BeginInit();
      this.SuspendLayout();
      this.cmdOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cmdOK.DialogResult = DialogResult.OK;
      this.cmdOK.Font = new Font("小米兰亭", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.cmdOK.Location = new Point(1452, 1106);
      this.cmdOK.Margin = new Padding(4, 2, 4, 2);
      this.cmdOK.Name = "cmdOK";
      this.cmdOK.Size = new Size(125, 55);
      this.cmdOK.TabIndex = 0;
      this.cmdOK.Text = "OK";
      this.cmdOK.UseVisualStyleBackColor = true;
      this.cmdOK.Click += new EventHandler(this.cmdOK_Click);
      this.cmdCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cmdCancel.DialogResult = DialogResult.Cancel;
      this.cmdCancel.Font = new Font("小米兰亭", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.cmdCancel.Location = new Point(1648, 1106);
      this.cmdCancel.Margin = new Padding(4, 2, 4, 2);
      this.cmdCancel.Name = "cmdCancel";
      this.cmdCancel.Size = new Size(125, 55);
      this.cmdCancel.TabIndex = 1;
      this.cmdCancel.Text = "Cancel";
      this.cmdCancel.UseVisualStyleBackColor = true;
      this.cmdCancel.Click += new EventHandler(this.cmdCancel_Click);
      this.label1.BackColor = Color.Gray;
      this.label1.Font = new Font("Ink Free", 27.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.White;
      this.label1.Location = new Point(509, 28);
      this.label1.Margin = new Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(764, 94);
      this.label1.TabIndex = 2;
      this.label1.Text = "WandererBox Plus V2";
      this.label1.Click += new EventHandler(this.label1_Click);
      this.picASCOM.Anchor = AnchorStyles.None;
      this.picASCOM.Cursor = Cursors.Hand;
      this.picASCOM.Image = (Image) Resources.ASCOM;
      this.picASCOM.Location = new Point(1781, 25);
      this.picASCOM.Margin = new Padding(4, 2, 4, 2);
      this.picASCOM.Name = "picASCOM";
      this.picASCOM.Size = new Size(96 /*0x60*/, 117);
      this.picASCOM.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picASCOM.TabIndex = 3;
      this.picASCOM.TabStop = false;
      this.picASCOM.Click += new EventHandler(this.BrowseToAscom);
      this.picASCOM.DoubleClick += new EventHandler(this.BrowseToAscom);
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.BackColor = Color.Gray;
      this.linkLabel1.Font = new Font("小米兰亭", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.linkLabel1.LinkColor = Color.White;
      this.linkLabel1.Location = new Point(229, 1106);
      this.linkLabel1.Margin = new Padding(2, 0, 2, 0);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(570, 37);
      this.linkLabel1.TabIndex = 9;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "More information and help please click here";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.textBox4.BackColor = Color.LightSalmon;
      this.textBox4.Font = new Font("小米兰亭", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox4.Location = new Point(124, 540);
      this.textBox4.Margin = new Padding(2);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new Size(119, 45);
      this.textBox4.TabIndex = 26;
      this.textBox4.Text = "DC6";
      this.textBox4.TextAlign = HorizontalAlignment.Center;
      this.textBox3.BackColor = Color.LightSalmon;
      this.textBox3.Font = new Font("小米兰亭", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox3.Location = new Point(568, 594);
      this.textBox3.Margin = new Padding(2);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(153, 45);
      this.textBox3.TabIndex = 25;
      this.textBox3.Text = "DC5 PWM";
      this.textBox3.TextAlign = HorizontalAlignment.Center;
      this.textBox2.BackColor = Color.LightSalmon;
      this.textBox2.Font = new Font("小米兰亭", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox2.Location = new Point(568, 523);
      this.textBox2.Margin = new Padding(2);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(153, 45);
      this.textBox2.TabIndex = 24;
      this.textBox2.Text = "DC4 PWM";
      this.textBox2.TextAlign = HorizontalAlignment.Center;
      this.textBox1.BackColor = Color.LightSalmon;
      this.textBox1.Font = new Font("小米兰亭", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox1.Location = new Point(557, 452);
      this.textBox1.Margin = new Padding(2);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(344, 45);
      this.textBox1.TabIndex = 23;
      this.textBox1.Text = "DC1-3 Switch";
      this.textBox1.TextAlign = HorizontalAlignment.Center;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.pictureBox1.BackColor = Color.Gray;
      this.pictureBox1.Location = new Point(-26, 0);
      this.pictureBox1.Margin = new Padding(2);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(1936, 161);
      this.pictureBox1.TabIndex = 27;
      this.pictureBox1.TabStop = false;
      this.pictureBox2.BackColor = Color.Gray;
      this.pictureBox2.Location = new Point(-11, 1065);
      this.pictureBox2.Margin = new Padding(2);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(1920, 131);
      this.pictureBox2.TabIndex = 28;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.Click += new EventHandler(this.pictureBox2_Click);
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Gray;
      this.label7.Font = new Font("小米兰亭", 7.8f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label7.ForeColor = SystemColors.ButtonHighlight;
      this.label7.Location = new Point(1236, 94);
      this.label7.Margin = new Padding(2, 0, 2, 0);
      this.label7.Name = "label7";
      this.label7.Size = new Size(212, 28);
      this.label7.TabIndex = 29;
      this.label7.Text = "Interface Version 2.2";
      this.pictureBox5.Image = (Image) componentResourceManager.GetObject("pictureBox5.Image");
      this.pictureBox5.Location = new Point(84, -125);
      this.pictureBox5.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new Size(1040, 755);
      this.pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox5.TabIndex = 46;
      this.pictureBox5.TabStop = false;
      this.pictureBox6.Image = (Image) componentResourceManager.GetObject("pictureBox6.Image");
      this.pictureBox6.Location = new Point(-72, 683);
      this.pictureBox6.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox6.Name = "pictureBox6";
      this.pictureBox6.Size = new Size(1096, 461);
      this.pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox6.TabIndex = 47;
      this.pictureBox6.TabStop = false;
      this.textBox5.BackColor = Color.LightSalmon;
      this.textBox5.Font = new Font("小米兰亭", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox5.Location = new Point(283, 667);
      this.textBox5.Margin = new Padding(2);
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new Size(321, 45);
      this.textBox5.TabIndex = 107;
      this.textBox5.Text = "USB Device";
      this.textBox5.TextAlign = HorizontalAlignment.Center;
      this.textBox5.TextChanged += new EventHandler(this.textBox5_TextChanged);
      this.checkBox3.AutoSize = true;
      this.checkBox3.Checked = true;
      this.checkBox3.CheckState = CheckState.Checked;
      this.checkBox3.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox3.Location = new Point(936, 602);
      this.checkBox3.Margin = new Padding(4, 5, 4, 5);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(120, 36);
      this.checkBox3.TabIndex = 140;
      this.checkBox3.Text = "Switch";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.checkBox3.CheckedChanged += new EventHandler(this.checkBox3_CheckedChanged);
      this.checkBox4.AutoSize = true;
      this.checkBox4.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox4.Location = new Point(748, 602);
      this.checkBox4.Margin = new Padding(4, 5, 4, 5);
      this.checkBox4.Name = "checkBox4";
      this.checkBox4.Size = new Size(178, 36);
      this.checkBox4.TabIndex = 139;
      this.checkBox4.Text = "Dew Heater";
      this.checkBox4.UseVisualStyleBackColor = true;
      this.checkBox4.CheckedChanged += new EventHandler(this.checkBox4_CheckedChanged_1);
      this.checkBox2.AutoSize = true;
      this.checkBox2.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox2.Location = new Point(938, 527);
      this.checkBox2.Margin = new Padding(4, 5, 4, 5);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(120, 36);
      this.checkBox2.TabIndex = 138;
      this.checkBox2.Text = "Switch";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged);
      this.checkBox1.AutoSize = true;
      this.checkBox1.Checked = true;
      this.checkBox1.CheckState = CheckState.Checked;
      this.checkBox1.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox1.Location = new Point(744, 527);
      this.checkBox1.Margin = new Padding(4, 5, 4, 5);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(178, 36);
      this.checkBox1.TabIndex = 137;
      this.checkBox1.Text = "Dew Heater";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new EventHandler(this.checkBox4_CheckedChanged);
      this.label50.AutoSize = true;
      this.label50.BackColor = SystemColors.ButtonShadow;
      this.label50.Font = new Font("小米兰亭", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label50.ForeColor = Color.White;
      this.label50.Location = new Point(1349, 269);
      this.label50.Margin = new Padding(2, 0, 2, 0);
      this.label50.Name = "label50";
      this.label50.Size = new Size(308, 42);
      this.label50.TabIndex = 212;
      this.label50.Text = "Dew Heater Port 4";
      this.label50.Click += new EventHandler(this.label50_Click);
      this.label29.AutoSize = true;
      this.label29.BackColor = Color.DimGray;
      this.label29.Font = new Font("小米兰亭", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label29.ForeColor = Color.White;
      this.label29.Location = new Point(1112, 948);
      this.label29.Margin = new Padding(2, 0, 2, 0);
      this.label29.Name = "label29";
      this.label29.Size = new Size(385, 32 /*0x20*/);
      this.label29.TabIndex = 211;
      this.label29.Text = "Maximum Power  PWM Setting";
      this.label30.AutoSize = true;
      this.label30.BackColor = Color.DimGray;
      this.label30.Font = new Font("小米兰亭", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label30.ForeColor = Color.White;
      this.label30.Location = new Point(1140, 865);
      this.label30.Margin = new Padding(2, 0, 2, 0);
      this.label30.Name = "label30";
      this.label30.Size = new Size(317, 32 /*0x20*/);
      this.label30.TabIndex = 210;
      this.label30.Text = "High Power PWM Setting";
      this.label31.AutoSize = true;
      this.label31.BackColor = Color.DimGray;
      this.label31.Font = new Font("小米兰亭", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label31.ForeColor = Color.White;
      this.label31.Location = new Point(1147, 783);
      this.label31.Margin = new Padding(2, 0, 2, 0);
      this.label31.Name = "label31";
      this.label31.Size = new Size(311, 32 /*0x20*/);
      this.label31.TabIndex = 209;
      this.label31.Text = "Low Power PWM Setting";
      this.label33.AutoSize = true;
      this.label33.BackColor = Color.DimGray;
      this.label33.Font = new Font("小米兰亭", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label33.ForeColor = Color.White;
      this.label33.Location = new Point(1349, 677);
      this.label33.Margin = new Padding(2, 0, 2, 0);
      this.label33.Name = "label33";
      this.label33.Size = new Size(308, 42);
      this.label33.TabIndex = 208 /*0xD0*/;
      this.label33.Text = "Dew Heater Port 5";
      this.label33.Click += new EventHandler(this.label33_Click);
      this.label34.AutoSize = true;
      this.label34.BackColor = Color.DimGray;
      this.label34.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label34.ForeColor = Color.White;
      this.label34.Location = new Point(1789, 948);
      this.label34.Margin = new Padding(2, 0, 2, 0);
      this.label34.Name = "label34";
      this.label34.Size = new Size(55, 32 /*0x20*/);
      this.label34.TabIndex = 207;
      this.label34.Text = "255";
      this.label35.AutoSize = true;
      this.label35.BackColor = Color.DimGray;
      this.label35.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label35.ForeColor = Color.White;
      this.label35.Location = new Point(1789, 865);
      this.label35.Margin = new Padding(2, 0, 2, 0);
      this.label35.Name = "label35";
      this.label35.Size = new Size(53, 32 /*0x20*/);
      this.label35.TabIndex = 206;
      this.label35.Text = "185";
      this.label36.AutoSize = true;
      this.label36.BackColor = Color.DimGray;
      this.label36.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label36.ForeColor = Color.White;
      this.label36.Location = new Point(1792 /*0x0700*/, 783);
      this.label36.Margin = new Padding(2, 0, 2, 0);
      this.label36.Name = "label36";
      this.label36.Size = new Size(53, 32 /*0x20*/);
      this.label36.TabIndex = 205;
      this.label36.Text = "100";
      this.trackBar1.BackColor = Color.DimGray;
      this.trackBar1.LargeChange = 10;
      this.trackBar1.Location = new Point(1524, 944);
      this.trackBar1.Margin = new Padding(2);
      this.trackBar1.Maximum = (int) byte.MaxValue;
      this.trackBar1.Minimum = 100;
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new Size(251, 90);
      this.trackBar1.SmallChange = 5;
      this.trackBar1.TabIndex = 204;
      this.trackBar1.TickFrequency = 10;
      this.trackBar1.Value = (int) byte.MaxValue;
      this.trackBar1.Scroll += new EventHandler(this.trackBar1_Scroll_1);
      this.trackBar8.BackColor = Color.DimGray;
      this.trackBar8.LargeChange = 10;
      this.trackBar8.Location = new Point(1524, 865);
      this.trackBar8.Margin = new Padding(2);
      this.trackBar8.Maximum = (int) byte.MaxValue;
      this.trackBar8.Minimum = 100;
      this.trackBar8.Name = "trackBar8";
      this.trackBar8.Size = new Size(251, 90);
      this.trackBar8.SmallChange = 5;
      this.trackBar8.TabIndex = 203;
      this.trackBar8.TickFrequency = 10;
      this.trackBar8.Value = 190;
      this.trackBar8.Scroll += new EventHandler(this.trackBar8_Scroll);
      this.trackBar12.BackColor = Color.DimGray;
      this.trackBar12.LargeChange = 10;
      this.trackBar12.Location = new Point(1524, 781);
      this.trackBar12.Margin = new Padding(2);
      this.trackBar12.Maximum = (int) byte.MaxValue;
      this.trackBar12.Minimum = 100;
      this.trackBar12.Name = "trackBar12";
      this.trackBar12.Size = new Size(251, 90);
      this.trackBar12.SmallChange = 5;
      this.trackBar12.TabIndex = 202;
      this.trackBar12.TickFrequency = 10;
      this.trackBar12.Value = 150;
      this.trackBar12.Scroll += new EventHandler(this.trackBar12_Scroll);
      this.label44.AutoSize = true;
      this.label44.BackColor = SystemColors.ButtonShadow;
      this.label44.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label44.ForeColor = Color.White;
      this.label44.Location = new Point(1792 /*0x0700*/, 540);
      this.label44.Margin = new Padding(2, 0, 2, 0);
      this.label44.Name = "label44";
      this.label44.Size = new Size(55, 32 /*0x20*/);
      this.label44.TabIndex = 200;
      this.label44.Text = "255";
      this.label45.AutoSize = true;
      this.label45.BackColor = SystemColors.ButtonShadow;
      this.label45.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label45.ForeColor = Color.White;
      this.label45.Location = new Point(1792 /*0x0700*/, 450);
      this.label45.Margin = new Padding(2, 0, 2, 0);
      this.label45.Name = "label45";
      this.label45.Size = new Size(53, 32 /*0x20*/);
      this.label45.TabIndex = 199;
      this.label45.Text = "185";
      this.label46.AutoSize = true;
      this.label46.BackColor = SystemColors.ButtonShadow;
      this.label46.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label46.ForeColor = Color.White;
      this.label46.Location = new Point(1792 /*0x0700*/, 360);
      this.label46.Margin = new Padding(2, 0, 2, 0);
      this.label46.Name = "label46";
      this.label46.Size = new Size(53, 32 /*0x20*/);
      this.label46.TabIndex = 198;
      this.label46.Text = "100";
      this.trackBar16.BackColor = SystemColors.ButtonShadow;
      this.trackBar16.LargeChange = 10;
      this.trackBar16.Location = new Point(1524, 533);
      this.trackBar16.Margin = new Padding(2);
      this.trackBar16.Maximum = (int) byte.MaxValue;
      this.trackBar16.Minimum = 100;
      this.trackBar16.Name = "trackBar16";
      this.trackBar16.Size = new Size(251, 90);
      this.trackBar16.SmallChange = 5;
      this.trackBar16.TabIndex = 197;
      this.trackBar16.TickFrequency = 10;
      this.trackBar16.Value = (int) byte.MaxValue;
      this.trackBar16.Scroll += new EventHandler(this.trackBar16_Scroll);
      this.trackBar17.BackColor = SystemColors.ButtonShadow;
      this.trackBar17.LargeChange = 10;
      this.trackBar17.Location = new Point(1524, 450);
      this.trackBar17.Margin = new Padding(2);
      this.trackBar17.Maximum = (int) byte.MaxValue;
      this.trackBar17.Minimum = 100;
      this.trackBar17.Name = "trackBar17";
      this.trackBar17.Size = new Size(248, 90);
      this.trackBar17.SmallChange = 5;
      this.trackBar17.TabIndex = 196;
      this.trackBar17.TickFrequency = 10;
      this.trackBar17.Value = 190;
      this.trackBar17.Scroll += new EventHandler(this.trackBar17_Scroll);
      this.trackBar18.BackColor = SystemColors.ButtonShadow;
      this.trackBar18.LargeChange = 10;
      this.trackBar18.Location = new Point(1524, 352);
      this.trackBar18.Margin = new Padding(2);
      this.trackBar18.Maximum = (int) byte.MaxValue;
      this.trackBar18.Minimum = 100;
      this.trackBar18.Name = "trackBar18";
      this.trackBar18.Size = new Size(248, 90);
      this.trackBar18.SmallChange = 5;
      this.trackBar18.TabIndex = 195;
      this.trackBar18.TickFrequency = 10;
      this.trackBar18.Value = 150;
      this.trackBar18.Scroll += new EventHandler(this.trackBar18_Scroll);
      this.label47.AutoSize = true;
      this.label47.BackColor = SystemColors.ButtonShadow;
      this.label47.Font = new Font("小米兰亭", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label47.ForeColor = Color.White;
      this.label47.Location = new Point(1112, 531);
      this.label47.Margin = new Padding(2, 0, 2, 0);
      this.label47.Name = "label47";
      this.label47.Size = new Size(378, 32 /*0x20*/);
      this.label47.TabIndex = 194;
      this.label47.Text = "Maximum Power PWM Setting";
      this.label48.AutoSize = true;
      this.label48.BackColor = SystemColors.ButtonShadow;
      this.label48.Font = new Font("小米兰亭", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label48.ForeColor = Color.White;
      this.label48.Location = new Point(1130, 450);
      this.label48.Margin = new Padding(2, 0, 2, 0);
      this.label48.Name = "label48";
      this.label48.Size = new Size(317, 32 /*0x20*/);
      this.label48.TabIndex = 193;
      this.label48.Text = "High Power PWM Setting";
      this.label49.AutoSize = true;
      this.label49.BackColor = SystemColors.ButtonShadow;
      this.label49.Font = new Font("小米兰亭", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label49.ForeColor = Color.White;
      this.label49.Location = new Point(1139, 360);
      this.label49.Margin = new Padding(2, 0, 2, 0);
      this.label49.Name = "label49";
      this.label49.Size = new Size(311, 32 /*0x20*/);
      this.label49.TabIndex = 192 /*0xC0*/;
      this.label49.Text = "Low Power PWM Setting";
      this.pictureBox17.BackColor = SystemColors.ButtonShadow;
      this.pictureBox17.Location = new Point(1088, 239);
      this.pictureBox17.Margin = new Padding(2);
      this.pictureBox17.Name = "pictureBox17";
      this.pictureBox17.Size = new Size(821, 394);
      this.pictureBox17.TabIndex = 191;
      this.pictureBox17.TabStop = false;
      this.pictureBox18.BackColor = Color.DimGray;
      this.pictureBox18.Location = new Point(1088, 628);
      this.pictureBox18.Margin = new Padding(2);
      this.pictureBox18.Name = "pictureBox18";
      this.pictureBox18.Size = new Size(853, 431);
      this.pictureBox18.TabIndex = 201;
      this.pictureBox18.TabStop = false;
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Gray;
      this.label6.Font = new Font("小米兰亭", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label6.ForeColor = Color.White;
      this.label6.Location = new Point(1276, 175);
      this.label6.Margin = new Padding(2, 0, 2, 0);
      this.label6.Name = "label6";
      this.label6.Size = new Size(435, 42);
      this.label6.TabIndex = 214;
      this.label6.Text = "Dew Heater Power Setting";
      this.label17.AutoSize = true;
      this.label17.BackColor = Color.Black;
      this.label17.BorderStyle = BorderStyle.Fixed3D;
      this.label17.Cursor = Cursors.Help;
      this.label17.Font = new Font("宋体", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label17.ForeColor = SystemColors.ButtonHighlight;
      this.label17.Location = new Point(1763, 181);
      this.label17.Margin = new Padding(2, 0, 2, 0);
      this.label17.Name = "label17";
      this.label17.Size = new Size(34, 35);
      this.label17.TabIndex = 213;
      this.label17.Text = "?";
      this.label17.Click += new EventHandler(this.label17_Click_1);
      this.pictureBox13.BackColor = SystemColors.InactiveCaptionText;
      this.pictureBox13.Location = new Point(-482, 150);
      this.pictureBox13.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox13.Name = "pictureBox13";
      this.pictureBox13.Size = new Size(2398, 15);
      this.pictureBox13.TabIndex = 215;
      this.pictureBox13.TabStop = false;
      this.pictureBox8.BackColor = SystemColors.InactiveCaptionText;
      this.pictureBox8.Location = new Point(1072, 158);
      this.pictureBox8.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox8.Name = "pictureBox8";
      this.pictureBox8.Size = new Size(20, 906);
      this.pictureBox8.TabIndex = 216;
      this.pictureBox8.TabStop = false;
      this.pictureBox3.BackColor = SystemColors.InactiveCaptionText;
      this.pictureBox3.Location = new Point(-344, 1058);
      this.pictureBox3.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new Size(2398, 15);
      this.pictureBox3.TabIndex = 217;
      this.pictureBox3.TabStop = false;
      this.pictureBox4.BackColor = Color.Gray;
      this.pictureBox4.Location = new Point(1078, 150);
      this.pictureBox4.Margin = new Padding(2);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new Size(828, 105);
      this.pictureBox4.TabIndex = 218;
      this.pictureBox4.TabStop = false;
      this.pictureBox7.BackColor = SystemColors.InactiveCaptionText;
      this.pictureBox7.Location = new Point(1885, -2);
      this.pictureBox7.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox7.Name = "pictureBox7";
      this.pictureBox7.Size = new Size(29, 1203);
      this.pictureBox7.TabIndex = 219;
      this.pictureBox7.TabStop = false;
      this.pictureBox9.BackColor = SystemColors.InactiveCaptionText;
      this.pictureBox9.Location = new Point(-344, 1181);
      this.pictureBox9.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox9.Name = "pictureBox9";
      this.pictureBox9.Size = new Size(2398, 15);
      this.pictureBox9.TabIndex = 220;
      this.pictureBox9.TabStop = false;
      this.pictureBox10.BackColor = SystemColors.InactiveCaptionText;
      this.pictureBox10.Location = new Point(-4, 0);
      this.pictureBox10.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox10.Name = "pictureBox10";
      this.pictureBox10.Size = new Size(20, 1202);
      this.pictureBox10.TabIndex = 221;
      this.pictureBox10.TabStop = false;
      this.pictureBox11.BackColor = SystemColors.InactiveCaptionText;
      this.pictureBox11.Location = new Point(-504, -2);
      this.pictureBox11.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox11.Name = "pictureBox11";
      this.pictureBox11.Size = new Size(2413, 22);
      this.pictureBox11.TabIndex = 222;
      this.pictureBox11.TabStop = false;
      this.checkBox9.AutoSize = true;
      this.checkBox9.BackColor = Color.Transparent;
      this.checkBox9.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox9.Location = new Point(360, 1008);
      this.checkBox9.Margin = new Padding(4, 5, 4, 5);
      this.checkBox9.Name = "checkBox9";
      this.checkBox9.Size = new Size(395, 36);
      this.checkBox9.TabIndex = 227;
      this.checkBox9.Text = "Wanderer Weather Station Mini";
      this.checkBox9.UseVisualStyleBackColor = false;
      this.checkBox9.CheckedChanged += new EventHandler(this.checkBox9_CheckedChanged);
      this.AutoScaleDimensions = new SizeF(12f, 25f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1900, 1186);
      this.Controls.Add((Control) this.checkBox9);
      this.Controls.Add((Control) this.pictureBox11);
      this.Controls.Add((Control) this.pictureBox10);
      this.Controls.Add((Control) this.pictureBox9);
      this.Controls.Add((Control) this.pictureBox7);
      this.Controls.Add((Control) this.pictureBox3);
      this.Controls.Add((Control) this.pictureBox8);
      this.Controls.Add((Control) this.pictureBox13);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label17);
      this.Controls.Add((Control) this.label50);
      this.Controls.Add((Control) this.label29);
      this.Controls.Add((Control) this.label30);
      this.Controls.Add((Control) this.label31);
      this.Controls.Add((Control) this.label33);
      this.Controls.Add((Control) this.label34);
      this.Controls.Add((Control) this.label35);
      this.Controls.Add((Control) this.label36);
      this.Controls.Add((Control) this.trackBar1);
      this.Controls.Add((Control) this.trackBar8);
      this.Controls.Add((Control) this.trackBar12);
      this.Controls.Add((Control) this.label44);
      this.Controls.Add((Control) this.label45);
      this.Controls.Add((Control) this.label46);
      this.Controls.Add((Control) this.trackBar16);
      this.Controls.Add((Control) this.trackBar17);
      this.Controls.Add((Control) this.trackBar18);
      this.Controls.Add((Control) this.label47);
      this.Controls.Add((Control) this.label48);
      this.Controls.Add((Control) this.label49);
      this.Controls.Add((Control) this.pictureBox17);
      this.Controls.Add((Control) this.pictureBox18);
      this.Controls.Add((Control) this.checkBox3);
      this.Controls.Add((Control) this.checkBox4);
      this.Controls.Add((Control) this.checkBox2);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.textBox5);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.textBox4);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.linkLabel1);
      this.Controls.Add((Control) this.picASCOM);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.cmdCancel);
      this.Controls.Add((Control) this.cmdOK);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.pictureBox2);
      this.Controls.Add((Control) this.pictureBox6);
      this.Controls.Add((Control) this.pictureBox4);
      this.Controls.Add((Control) this.pictureBox5);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Margin = new Padding(4, 2, 4, 2);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (SetupForPlusV2);
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "WandererBox Plus Setup";
      this.Load += new EventHandler(this.SetupDialogForm_Load);
      ((ISupportInitialize) this.picASCOM).EndInit();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      ((ISupportInitialize) this.pictureBox5).EndInit();
      ((ISupportInitialize) this.pictureBox6).EndInit();
      this.trackBar1.EndInit();
      this.trackBar8.EndInit();
      this.trackBar12.EndInit();
      this.trackBar16.EndInit();
      this.trackBar17.EndInit();
      this.trackBar18.EndInit();
      ((ISupportInitialize) this.pictureBox17).EndInit();
      ((ISupportInitialize) this.pictureBox18).EndInit();
      ((ISupportInitialize) this.pictureBox13).EndInit();
      ((ISupportInitialize) this.pictureBox8).EndInit();
      ((ISupportInitialize) this.pictureBox3).EndInit();
      ((ISupportInitialize) this.pictureBox4).EndInit();
      ((ISupportInitialize) this.pictureBox7).EndInit();
      ((ISupportInitialize) this.pictureBox9).EndInit();
      ((ISupportInitialize) this.pictureBox10).EndInit();
      ((ISupportInitialize) this.pictureBox11).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
