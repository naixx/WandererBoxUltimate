// Decompiled with JetBrains decompiler
// Type: ASCOM.WandererBoxes.SetupForUltimateV2
// Assembly: ASCOM.WandererBoxes.Switch, Version=6.6.0.0, Culture=neutral, PublicKeyToken=5a596dde3293c610
// MVID: E3106A5C-05F3-42C7-89F9-2A2C7253BE13
// Assembly location: C:\Program Files (x86)\Wanderer Astro\ASCOM.WandererBoxes.Switch.dll

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ASCOM.Tools;

namespace ASCOM.WandererBoxes
{
  [ComVisible(false)]
  public class SetupForUltimateV2 : Form
  {
    private TraceLogger tl;
    public static int port;
    private IContainer components;
    private Label label17;
    private TextBox textBox4;
    private TextBox textBox3;
    private TextBox textBox2;
    private TextBox textBox1;
    private LinkLabel linkLabel1;
    private Label label1;
    private PictureBox pictureBox1;
    private TextBox textBox5;
    private TextBox textBox6;
    private TextBox textBox7;
    private TextBox textBox8;
    private TextBox textBox9;
    private TextBox textBox10;
    private TextBox textBox11;
    private TextBox textBox12;
    private TextBox textBox13;
    private TextBox textBox14;
    private PictureBox pictureBox7;
    private TextBox textBox15;
    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private CheckBox checkBox3;
    private CheckBox checkBox4;
    private CheckBox checkBox5;
    private CheckBox checkBox6;
    private CheckBox checkBox7;
    private CheckBox checkBox8;
    private Label label6;
    private PictureBox pictureBox16;
    private Label label8;
    private Label label12;
    private Label label25;
    private Label label29;
    private Label label30;
    private Label label31;
    private Label label32;
    private Label label33;
    private Label label34;
    private Label label35;
    private Label label36;
    private TrackBar trackBar1;
    private TrackBar trackBar8;
    private TrackBar trackBar12;
    private Label label37;
    private Label label38;
    private Label label42;
    private TrackBar trackBar13;
    private TrackBar trackBar15;
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
    private Label label50;
    private Label label3;
    private PictureBox pictureBox3;
    private PictureBox pictureBox4;
    private Label label39;
    private TrackBar trackBar14;
    private PictureBox pictureBox19;
    private Button cmdOK;
    private Button button1;
    private Label label2;
    private Label label14;
    private Label label15;
    private Label label16;
    private Label label10;
    private Label label11;
    private Label label13;
    private TrackBar trackBar2;
    private TrackBar trackBar3;
    private TrackBar trackBar4;
    private Label label9;
    private Label label5;
    private Label label4;
    private CheckBox checkBox9;

    public SetupForUltimateV2()
    {
      this.InitializeComponent();
      this.InitUI();
    }

    private void cmdOK_Click(object sender, EventArgs e)
    {
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

    private void SetupDialogForm_Load(object sender, EventArgs e)
    {
      this.textBox9.Text = Switch.DC1name;
      this.textBox8.Text = Switch.DC2name;
      this.textBox7.Text = Switch.DC3name;
      this.textBox4.Text = Switch.DC4name;
      this.textBox5.Text = Switch.DC5_8name;
      this.textBox15.Text = Switch.DC9name;
      this.textBox6.Text = Switch.USB3_1name;
      this.textBox10.Text = Switch.USB3_2name;
      this.textBox12.Text = Switch.USB3_3name;
      this.textBox11.Text = Switch.USB2_1name;
      this.textBox14.Text = Switch.USB2_2name;
      this.textBox13.Text = Switch.USB2_3name;
      this.textBox1.Text = Switch.USB2_4name;
      this.textBox2.Text = Switch.USB2_5name;
      this.textBox3.Text = Switch.USB2_6name;
      this.trackBar18.Value = Switch.dew1low;
      this.label46.Text = this.trackBar18.Value.ToString();
      this.label2.Text = ((double) this.trackBar18.Value * 0.04706).ToString("0.0") + " V";
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
      this.trackBar15.Value = Switch.dew3low;
      this.label42.Text = this.trackBar15.Value.ToString();
      this.trackBar14.Value = Switch.dew3high;
      this.label38.Text = this.trackBar14.Value.ToString();
      this.trackBar13.Value = Switch.dew3maximum;
      this.label37.Text = this.trackBar13.Value.ToString();
      this.trackBar4.Value = Switch.dew1t;
      this.label13.Text = this.trackBar4.Value.ToString();
      this.trackBar3.Value = Switch.dew2t;
      this.label11.Text = this.trackBar3.Value.ToString();
      this.trackBar2.Value = Switch.dew3t;
      this.label10.Text = this.trackBar2.Value.ToString();
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
      if (Switch.heater3Mode == "Dew Heater3")
      {
        this.checkBox6.Checked = true;
        this.trackBar15.Enabled = this.trackBar14.Enabled = this.trackBar13.Enabled = true;
        this.label32.ForeColor = this.label25.ForeColor = this.label12.ForeColor = this.label8.ForeColor = this.label42.ForeColor = this.label38.ForeColor = this.label37.ForeColor = Color.White;
        this.checkBox5.Checked = false;
      }
      else
      {
        this.checkBox5.Checked = true;
        this.trackBar15.Enabled = this.trackBar14.Enabled = this.trackBar13.Enabled = false;
        this.label32.ForeColor = this.label25.ForeColor = this.label12.ForeColor = this.label8.ForeColor = this.label42.ForeColor = this.label38.ForeColor = this.label37.ForeColor = Color.DimGray;
        this.checkBox6.Checked = false;
      }
      if (Switch.Sensortype == "None")
      {
        this.trackBar2.Enabled = this.trackBar3.Enabled = this.trackBar4.Enabled = false;
        this.label4.ForeColor = this.label5.ForeColor = this.label9.ForeColor = this.label10.ForeColor = this.label14.ForeColor = this.label11.ForeColor = this.label13.ForeColor = this.label16.ForeColor = this.label15.ForeColor = this.label14.ForeColor = Color.DimGray;
      }
      if (Switch.Sensortype == "DHT22")
      {
        this.checkBox7.Checked = true;
        this.checkBox8.Checked = false;
        this.trackBar2.Enabled = this.trackBar3.Enabled = this.trackBar4.Enabled = false;
        this.label4.ForeColor = this.label5.ForeColor = this.label9.ForeColor = this.label10.ForeColor = this.label14.ForeColor = this.label11.ForeColor = this.label13.ForeColor = this.label16.ForeColor = this.label15.ForeColor = this.label14.ForeColor = Color.DimGray;
      }
      if (Switch.Sensortype == "DS18B20")
      {
        this.checkBox8.Checked = true;
        this.checkBox7.Checked = false;
        this.trackBar2.Enabled = this.trackBar3.Enabled = this.trackBar4.Enabled = true;
        this.label4.ForeColor = this.label5.ForeColor = this.label9.ForeColor = this.label10.ForeColor = this.label14.ForeColor = this.label11.ForeColor = this.label13.ForeColor = this.label16.ForeColor = this.label15.ForeColor = this.label14.ForeColor = Color.White;
      }
      if (Switch.lang == "en")
      {
        this.checkBox9.Checked = true;
        this.checkBox1.Text = this.checkBox6.Text = this.checkBox4.Text = "Dew Heater";
        this.checkBox2.Text = this.checkBox3.Text = this.checkBox5.Text = "Switch";
        this.checkBox8.Text = "DS18B20 Probe";
        this.checkBox7.Text = "DHT22 Sensor";
        this.cmdOK.Text = "OK";
        this.button1.Text = "Cancel";
        this.label6.Text = "PWM (Dew Heater) Ports Setting";
        this.label3.Text = "Constant Temperatrue Mode Setting";
        this.label50.Text = this.label4.Text = "PWM Port DC 1";
        this.label33.Text = this.label5.Text = "PWM Port DC 2";
        this.label32.Text = this.label9.Text = "PWM Port DC 3";
        this.label49.Text = this.label31.Text = this.label25.Text = "Low";
        this.label48.Text = this.label30.Text = this.label12.Text = "High";
        this.label47.Text = this.label29.Text = this.label8.Text = "Maximum";
        this.label39.Text = "Auto control of dew heater has two modes:\r\n1. Humidity mode:Requires DHT22 humidity sensor.\r\n2. Constant temperature mode:Requires DS18B20 temperature probe.";
        this.linkLabel1.Text = "To explore more please click here";
      }
      else
      {
        this.checkBox9.Checked = false;
        this.checkBox1.Text = this.checkBox6.Text = this.checkBox4.Text = "调压模式";
        this.checkBox2.Text = this.checkBox3.Text = this.checkBox5.Text = "开关模式";
        this.checkBox8.Text = "DS18B20 温度探头";
        this.checkBox7.Text = "DHT22 温湿传感器";
        this.cmdOK.Text = "确认";
        this.button1.Text = "取消";
        this.label6.Text = "       调压（除雾带）口设置";
        this.label3.Text = "                   除雾带恒温设置";
        this.label50.Text = this.label4.Text = "调压口DC1";
        this.label33.Text = this.label5.Text = "调压口DC2";
        this.label32.Text = this.label9.Text = "调压口DC3";
        this.label49.Text = this.label31.Text = this.label25.Text = "低";
        this.label48.Text = this.label30.Text = this.label12.Text = " 高";
        this.label47.Text = this.label29.Text = this.label8.Text = "    最大";
        this.label39.Text = "除雾带自动控制有两种模式：\r\n1. 湿度模式:需要 DHT22 湿度传感器。\r\n2. 恒温模式:需要DS18B20温度探头。";
        this.linkLabel1.Text = "更多信息请点击此处";
        Switch.lang = "cn";
      }
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void cmdOK_Click_1(object sender, EventArgs e)
    {
      Switch.DC1name = this.textBox9.Text;
      Switch.DC2name = this.textBox8.Text;
      Switch.DC3name = this.textBox7.Text;
      Switch.DC4name = this.textBox4.Text;
      Switch.DC5_8name = this.textBox5.Text;
      Switch.DC9name = this.textBox15.Text;
      Switch.USB3_1name = this.textBox6.Text;
      Switch.USB3_2name = this.textBox10.Text;
      Switch.USB3_3name = this.textBox12.Text;
      Switch.USB2_1name = this.textBox11.Text;
      Switch.USB2_2name = this.textBox14.Text;
      Switch.USB2_3name = this.textBox13.Text;
      Switch.USB2_4name = this.textBox1.Text;
      Switch.USB2_5name = this.textBox2.Text;
      Switch.USB2_6name = this.textBox3.Text;
      Switch.dew1low = this.trackBar18.Value;
      Switch.dew1high = this.trackBar17.Value;
      Switch.dew1maximum = this.trackBar16.Value;
      Switch.dew2low = this.trackBar12.Value;
      Switch.dew2high = this.trackBar8.Value;
      Switch.dew2maximum = this.trackBar1.Value;
      Switch.dew3low = this.trackBar15.Value;
      Switch.dew3high = this.trackBar14.Value;
      Switch.dew3maximum = this.trackBar13.Value;
      Switch.dew1t = this.trackBar4.Value;
      Switch.dew2t = this.trackBar3.Value;
      Switch.dew3t = this.trackBar2.Value;
      Switch.heater1Mode = !this.checkBox1.Checked ? "Switch1" : "Dew Heater1";
      Switch.heater2Mode = !this.checkBox4.Checked ? "Switch2" : "Dew Heater2";
      if (this.checkBox6.Checked)
        Switch.heater3Mode = "Dew Heater3";
      else
        Switch.heater3Mode = "Switch3";
    }

    private void cmdCancel_Click_1(object sender, EventArgs e)
    {
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox1.Checked)
      {
        this.checkBox2.Checked = false;
        Switch.heater1Mode = "Dew Heater1";
        Switch.DC1status = "3";
        this.trackBar18.Enabled = this.trackBar17.Enabled = this.trackBar16.Enabled = true;
        this.label50.ForeColor = this.label49.ForeColor = this.label48.ForeColor = this.label47.ForeColor = this.label46.ForeColor = this.label45.ForeColor = this.label44.ForeColor = Color.White;
        if (!(Switch.Sensortype == "DS18B20"))
          return;
        this.label4.ForeColor = this.label13.ForeColor = this.label16.ForeColor = Color.White;
        this.trackBar4.Enabled = true;
      }
      else
      {
        this.checkBox2.Checked = true;
        Switch.heater1Mode = "Switch1";
        Switch.DC1status = "On";
        this.trackBar18.Enabled = this.trackBar17.Enabled = this.trackBar16.Enabled = false;
        this.label50.ForeColor = this.label49.ForeColor = this.label48.ForeColor = this.label47.ForeColor = this.label46.ForeColor = this.label45.ForeColor = this.label44.ForeColor = Color.DimGray;
        this.label4.ForeColor = this.label13.ForeColor = this.label16.ForeColor = Color.DimGray;
        this.trackBar4.Enabled = false;
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
        this.label4.ForeColor = this.label13.ForeColor = this.label16.ForeColor = Color.DimGray;
        this.trackBar4.Enabled = false;
      }
      else
      {
        this.checkBox1.Checked = true;
        Switch.heater1Mode = "Dew Heater1";
        Switch.DC1status = "3";
        this.trackBar18.Enabled = this.trackBar17.Enabled = this.trackBar16.Enabled = true;
        this.label50.ForeColor = this.label49.ForeColor = this.label48.ForeColor = this.label47.ForeColor = this.label46.ForeColor = this.label45.ForeColor = this.label44.ForeColor = Color.White;
        if (!(Switch.Sensortype == "DS18B20"))
          return;
        this.label4.ForeColor = this.label13.ForeColor = this.label16.ForeColor = Color.White;
        this.trackBar4.Enabled = true;
      }
    }

    private void checkBox4_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox4.Checked)
      {
        this.checkBox3.Checked = false;
        Switch.heater2Mode = "Dew Heater2";
        Switch.DC2status = "3";
        this.trackBar12.Enabled = this.trackBar8.Enabled = this.trackBar1.Enabled = true;
        this.label33.ForeColor = this.label31.ForeColor = this.label30.ForeColor = this.label29.ForeColor = this.label36.ForeColor = this.label35.ForeColor = this.label34.ForeColor = Color.White;
        if (!(Switch.Sensortype == "DS18B20"))
          return;
        this.label5.ForeColor = this.label11.ForeColor = this.label15.ForeColor = Color.White;
        this.trackBar3.Enabled = true;
      }
      else
      {
        this.checkBox3.Checked = true;
        Switch.heater2Mode = "Switch2";
        Switch.DC2status = "On";
        this.trackBar12.Enabled = this.trackBar8.Enabled = this.trackBar1.Enabled = false;
        this.label33.ForeColor = this.label31.ForeColor = this.label30.ForeColor = this.label29.ForeColor = this.label36.ForeColor = this.label35.ForeColor = this.label34.ForeColor = Color.DimGray;
        this.label5.ForeColor = this.label11.ForeColor = this.label15.ForeColor = Color.DimGray;
        this.trackBar3.Enabled = false;
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
        this.label33.ForeColor = this.label31.ForeColor = this.label30.ForeColor = this.label29.ForeColor = this.label36.ForeColor = this.label35.ForeColor = this.label34.ForeColor = Color.DimGray;
        this.label5.ForeColor = this.label11.ForeColor = this.label15.ForeColor = Color.DimGray;
        this.trackBar3.Enabled = false;
      }
      else
      {
        this.checkBox4.Checked = true;
        Switch.heater2Mode = "Dew Heater2";
        Switch.DC2status = "3";
        this.trackBar12.Enabled = this.trackBar8.Enabled = this.trackBar1.Enabled = true;
        this.label33.ForeColor = this.label31.ForeColor = this.label30.ForeColor = this.label29.ForeColor = this.label36.ForeColor = this.label35.ForeColor = this.label34.ForeColor = Color.White;
        if (!(Switch.Sensortype == "DS18B20"))
          return;
        this.label5.ForeColor = this.label11.ForeColor = this.label15.ForeColor = Color.White;
        this.trackBar3.Enabled = true;
      }
    }

    private void checkBox6_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox6.Checked)
      {
        this.checkBox5.Checked = false;
        Switch.heater3Mode = "Dew Heater3";
        Switch.DC3status = "3";
        this.trackBar15.Enabled = this.trackBar14.Enabled = this.trackBar13.Enabled = true;
        this.label32.ForeColor = this.label25.ForeColor = this.label12.ForeColor = this.label8.ForeColor = this.label42.ForeColor = this.label38.ForeColor = this.label37.ForeColor = Color.White;
        if (!(Switch.Sensortype == "DS18B20"))
          return;
        this.label9.ForeColor = this.label10.ForeColor = this.label14.ForeColor = Color.White;
        this.trackBar2.Enabled = true;
      }
      else
      {
        this.checkBox5.Checked = true;
        Switch.heater3Mode = "Switch3";
        Switch.DC3status = "On";
        this.trackBar15.Enabled = this.trackBar14.Enabled = this.trackBar13.Enabled = false;
        this.label32.ForeColor = this.label25.ForeColor = this.label12.ForeColor = this.label8.ForeColor = this.label42.ForeColor = this.label38.ForeColor = this.label37.ForeColor = Color.DimGray;
        this.label9.ForeColor = this.label10.ForeColor = this.label14.ForeColor = Color.DimGray;
        this.trackBar2.Enabled = false;
      }
    }

    private void checkBox5_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox5.Checked)
      {
        this.checkBox6.Checked = false;
        Switch.heater3Mode = "Switch3";
        Switch.DC3status = "On";
        this.trackBar15.Enabled = this.trackBar14.Enabled = this.trackBar13.Enabled = false;
        this.label32.ForeColor = this.label25.ForeColor = this.label12.ForeColor = this.label8.ForeColor = this.label42.ForeColor = this.label38.ForeColor = this.label37.ForeColor = Color.DimGray;
        this.label9.ForeColor = this.label10.ForeColor = this.label14.ForeColor = Color.DimGray;
        this.trackBar2.Enabled = false;
      }
      else
      {
        this.checkBox6.Checked = true;
        Switch.heater3Mode = "Dew Heater3";
        Switch.DC3status = "3";
        this.trackBar15.Enabled = this.trackBar14.Enabled = this.trackBar13.Enabled = true;
        this.label32.ForeColor = this.label25.ForeColor = this.label12.ForeColor = this.label8.ForeColor = this.label42.ForeColor = this.label38.ForeColor = this.label37.ForeColor = Color.White;
        if (!(Switch.Sensortype == "DS18B20"))
          return;
        this.label9.ForeColor = this.label10.ForeColor = this.label14.ForeColor = Color.White;
        this.trackBar2.Enabled = true;
      }
    }

    private void checkBox7_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox7.Checked)
      {
        this.checkBox8.Checked = false;
        Switch.Sensortype = "DHT22";
        this.trackBar2.Enabled = this.trackBar3.Enabled = this.trackBar4.Enabled = false;
        this.label4.ForeColor = this.label5.ForeColor = this.label9.ForeColor = this.label10.ForeColor = this.label14.ForeColor = this.label11.ForeColor = this.label13.ForeColor = this.label16.ForeColor = this.label15.ForeColor = this.label14.ForeColor = Color.DimGray;
      }
      else
        Switch.Sensortype = "None";
    }

    private void checkBox8_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox8.Checked)
      {
        this.checkBox7.Checked = false;
        Switch.Sensortype = "DS18B20";
        this.trackBar2.Enabled = this.trackBar3.Enabled = this.trackBar4.Enabled = true;
        this.label4.ForeColor = this.label5.ForeColor = this.label9.ForeColor = this.label10.ForeColor = this.label14.ForeColor = this.label11.ForeColor = this.label13.ForeColor = this.label16.ForeColor = this.label15.ForeColor = this.label14.ForeColor = Color.White;
        if (this.checkBox2.Checked)
        {
          this.trackBar18.Enabled = this.trackBar17.Enabled = this.trackBar16.Enabled = false;
          this.label50.ForeColor = this.label49.ForeColor = this.label48.ForeColor = this.label47.ForeColor = this.label46.ForeColor = this.label45.ForeColor = this.label44.ForeColor = Color.DimGray;
          this.label4.ForeColor = this.label13.ForeColor = this.label16.ForeColor = Color.DimGray;
          this.trackBar4.Enabled = false;
        }
        if (this.checkBox3.Checked)
        {
          this.trackBar12.Enabled = this.trackBar8.Enabled = this.trackBar1.Enabled = false;
          this.label33.ForeColor = this.label31.ForeColor = this.label30.ForeColor = this.label29.ForeColor = this.label36.ForeColor = this.label35.ForeColor = this.label34.ForeColor = Color.DimGray;
          this.label5.ForeColor = this.label11.ForeColor = this.label15.ForeColor = Color.DimGray;
          this.trackBar3.Enabled = false;
        }
        if (!this.checkBox5.Checked)
          return;
        this.trackBar15.Enabled = this.trackBar14.Enabled = this.trackBar13.Enabled = false;
        this.label32.ForeColor = this.label25.ForeColor = this.label12.ForeColor = this.label8.ForeColor = this.label42.ForeColor = this.label38.ForeColor = this.label37.ForeColor = Color.DimGray;
        this.label9.ForeColor = this.label10.ForeColor = this.label14.ForeColor = Color.DimGray;
        this.trackBar2.Enabled = false;
      }
      else
      {
        Switch.Sensortype = "None";
        this.trackBar2.Enabled = this.trackBar3.Enabled = this.trackBar4.Enabled = false;
        this.label4.ForeColor = this.label5.ForeColor = this.label9.ForeColor = this.label10.ForeColor = this.label14.ForeColor = this.label11.ForeColor = this.label13.ForeColor = this.label16.ForeColor = this.label15.ForeColor = this.label14.ForeColor = Color.DimGray;
      }
    }

    private void label17_Click(object sender, EventArgs e)
    {
      int num = (int) new Form2().ShowDialog();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("http://www.wandererastro.com/");
    }

    private void trackBar18_Scroll(object sender, EventArgs e)
    {
      this.label46.Text = this.trackBar18.Value.ToString();
      this.label2.Text = ((double) this.trackBar18.Value * 0.04706).ToString("0.0") + " V";
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

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
      this.label34.Text = this.trackBar1.Value.ToString();
    }

    private void trackBar15_Scroll(object sender, EventArgs e)
    {
      this.label42.Text = this.trackBar15.Value.ToString();
    }

    private void trackBar14_Scroll(object sender, EventArgs e)
    {
      this.label38.Text = this.trackBar14.Value.ToString();
    }

    private void trackBar13_Scroll(object sender, EventArgs e)
    {
      this.label37.Text = this.trackBar13.Value.ToString();
    }

    private void trackBar4_Scroll(object sender, EventArgs e)
    {
      this.label13.Text = this.trackBar4.Value.ToString();
    }

    private void trackBar3_Scroll(object sender, EventArgs e)
    {
      this.label11.Text = this.trackBar3.Value.ToString();
    }

    private void trackBar2_Scroll(object sender, EventArgs e)
    {
      this.label10.Text = this.trackBar2.Value.ToString();
    }

    private void comboBoxComPort_SelectedIndexChanged_1(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e) => this.Close();

    private void label16_Click(object sender, EventArgs e)
    {
    }

    private void label15_Click(object sender, EventArgs e)
    {
    }

    private void pictureBox2_Click(object sender, EventArgs e)
    {
    }

    private void textBox14_TextChanged(object sender, EventArgs e)
    {
    }

    private void checkBox9_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox9.Checked)
      {
        this.checkBox1.Text = this.checkBox6.Text = this.checkBox4.Text = "Dew Heater";
        this.checkBox2.Text = this.checkBox3.Text = this.checkBox5.Text = "Switch";
        this.checkBox8.Text = "DS18B20 Probe";
        this.checkBox7.Text = "DHT22 Sensor";
        this.cmdOK.Text = "OK";
        this.button1.Text = "Cancel";
        this.label6.Text = "PWM (Dew Heater) Ports Setting";
        this.label3.Text = "Constant Temperatrue Mode Setting";
        this.label50.Text = this.label4.Text = "PWM Port DC 1";
        this.label33.Text = this.label5.Text = "PWM Port DC 2";
        this.label32.Text = this.label9.Text = "PWM Port DC 3";
        this.label49.Text = this.label31.Text = this.label25.Text = "Low";
        this.label48.Text = this.label30.Text = this.label12.Text = "High";
        this.label47.Text = this.label29.Text = this.label8.Text = "Maximum";
        this.label39.Text = "Auto control of dew heater has two modes:\r\n1. Humidity mode:Requires DHT22 humidity sensor.\r\n2. Constant temperature mode:Requires DS18B20 temperature probe.";
        this.linkLabel1.Text = "To explore more please click here";
        Switch.lang = "en";
      }
      else
      {
        this.checkBox1.Text = this.checkBox6.Text = this.checkBox4.Text = "调压模式";
        this.checkBox2.Text = this.checkBox3.Text = this.checkBox5.Text = "开关模式";
        this.checkBox8.Text = "DS18B20 温度探头";
        this.checkBox7.Text = "DHT22 温湿传感器";
        this.cmdOK.Text = "确认";
        this.button1.Text = "取消";
        this.label6.Text = "       调压（除雾带）口设置";
        this.label3.Text = "                   除雾带恒温设置";
        this.label50.Text = this.label4.Text = "调压口DC1";
        this.label33.Text = this.label5.Text = "调压口DC2";
        this.label32.Text = this.label9.Text = "调压口DC3";
        this.label49.Text = this.label31.Text = this.label25.Text = "低";
        this.label48.Text = this.label30.Text = this.label12.Text = " 高";
        this.label47.Text = this.label29.Text = this.label8.Text = "    最大";
        this.label39.Text = "除雾带自动控制有两种模式：\r\n1. 湿度模式:需要 DHT22 湿度传感器。\r\n2. 恒温模式:需要DS18B20温度探头。";
        this.linkLabel1.Text = "更多信息请点击此处";
        Switch.lang = "cn";
      }
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (SetupForUltimateV2));
      this.label17 = new Label();
      this.textBox4 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox1 = new TextBox();
      this.linkLabel1 = new LinkLabel();
      this.label1 = new Label();
      this.pictureBox1 = new PictureBox();
      this.textBox5 = new TextBox();
      this.textBox6 = new TextBox();
      this.textBox7 = new TextBox();
      this.textBox8 = new TextBox();
      this.textBox9 = new TextBox();
      this.textBox10 = new TextBox();
      this.textBox11 = new TextBox();
      this.textBox12 = new TextBox();
      this.textBox13 = new TextBox();
      this.textBox14 = new TextBox();
      this.pictureBox7 = new PictureBox();
      this.textBox15 = new TextBox();
      this.checkBox1 = new CheckBox();
      this.checkBox2 = new CheckBox();
      this.checkBox3 = new CheckBox();
      this.checkBox4 = new CheckBox();
      this.checkBox5 = new CheckBox();
      this.checkBox6 = new CheckBox();
      this.checkBox7 = new CheckBox();
      this.checkBox8 = new CheckBox();
      this.label6 = new Label();
      this.pictureBox16 = new PictureBox();
      this.label8 = new Label();
      this.label12 = new Label();
      this.label25 = new Label();
      this.label29 = new Label();
      this.label30 = new Label();
      this.label31 = new Label();
      this.label32 = new Label();
      this.label33 = new Label();
      this.label34 = new Label();
      this.label35 = new Label();
      this.label36 = new Label();
      this.trackBar1 = new TrackBar();
      this.trackBar8 = new TrackBar();
      this.trackBar12 = new TrackBar();
      this.label37 = new Label();
      this.label38 = new Label();
      this.label42 = new Label();
      this.trackBar13 = new TrackBar();
      this.trackBar15 = new TrackBar();
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
      this.label50 = new Label();
      this.label3 = new Label();
      this.pictureBox3 = new PictureBox();
      this.pictureBox4 = new PictureBox();
      this.label39 = new Label();
      this.trackBar14 = new TrackBar();
      this.pictureBox19 = new PictureBox();
      this.cmdOK = new Button();
      this.button1 = new Button();
      this.label2 = new Label();
      this.label14 = new Label();
      this.label15 = new Label();
      this.label16 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.label13 = new Label();
      this.trackBar2 = new TrackBar();
      this.trackBar3 = new TrackBar();
      this.trackBar4 = new TrackBar();
      this.label9 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.checkBox9 = new CheckBox();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.pictureBox7).BeginInit();
      ((ISupportInitialize) this.pictureBox16).BeginInit();
      this.trackBar1.BeginInit();
      this.trackBar8.BeginInit();
      this.trackBar12.BeginInit();
      this.trackBar13.BeginInit();
      this.trackBar15.BeginInit();
      this.trackBar16.BeginInit();
      this.trackBar17.BeginInit();
      this.trackBar18.BeginInit();
      ((ISupportInitialize) this.pictureBox17).BeginInit();
      ((ISupportInitialize) this.pictureBox18).BeginInit();
      ((ISupportInitialize) this.pictureBox3).BeginInit();
      ((ISupportInitialize) this.pictureBox4).BeginInit();
      this.trackBar14.BeginInit();
      ((ISupportInitialize) this.pictureBox19).BeginInit();
      this.trackBar2.BeginInit();
      this.trackBar3.BeginInit();
      this.trackBar4.BeginInit();
      this.SuspendLayout();
      this.label17.AutoSize = true;
      this.label17.BackColor = Color.Maroon;
      this.label17.BorderStyle = BorderStyle.Fixed3D;
      this.label17.Cursor = Cursors.Help;
      this.label17.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label17.ForeColor = SystemColors.ButtonHighlight;
      this.label17.Location = new Point(1919, 110);
      this.label17.Margin = new Padding(4, 0, 4, 0);
      this.label17.Name = "label17";
      this.label17.Size = new Size(27, 27);
      this.label17.TabIndex = 70;
      this.label17.Text = "?";
      this.label17.Click += new EventHandler(this.label17_Click);
      this.textBox4.BackColor = Color.LightSalmon;
      this.textBox4.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox4.Location = new Point(26, 242);
      this.textBox4.Margin = new Padding(4, 5, 4, 5);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new Size(209, 35);
      this.textBox4.TabIndex = 53;
      this.textBox4.Text = "DC OUT 4";
      this.textBox4.TextAlign = HorizontalAlignment.Center;
      this.textBox3.BackColor = Color.LightSalmon;
      this.textBox3.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox3.Location = new Point(1095, 639);
      this.textBox3.Margin = new Padding(4, 5, 4, 5);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(209, 35);
      this.textBox3.TabIndex = 52;
      this.textBox3.Text = "USB2.0-6";
      this.textBox3.TextAlign = HorizontalAlignment.Center;
      this.textBox2.BackColor = Color.LightSalmon;
      this.textBox2.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox2.Location = new Point(1095, 586);
      this.textBox2.Margin = new Padding(4, 5, 4, 5);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(209, 35);
      this.textBox2.TabIndex = 51;
      this.textBox2.Text = "USB2.0-5";
      this.textBox2.TextAlign = HorizontalAlignment.Center;
      this.textBox1.BackColor = Color.LightSalmon;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox1.Location = new Point(1095, 532);
      this.textBox1.Margin = new Padding(4, 5, 4, 5);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(209, 35);
      this.textBox1.TabIndex = 50;
      this.textBox1.Text = "USB2.0-4";
      this.textBox1.TextAlign = HorizontalAlignment.Center;
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.BackColor = Color.Transparent;
      this.linkLabel1.Font = new Font("Segoe Print", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel1.ForeColor = SystemColors.ControlDarkDark;
      this.linkLabel1.LinkColor = Color.DimGray;
      this.linkLabel1.Location = new Point(142, 1167);
      this.linkLabel1.Margin = new Padding(4, 0, 4, 0);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(494, 49);
      this.linkLabel1.TabIndex = 72;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "To explore more please click here";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.label1.BackColor = Color.Gray;
      this.label1.Font = new Font("Ink Free", 20.14286f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.White;
      this.label1.Location = new Point(607, 18);
      this.label1.Margin = new Padding(6, 0, 6, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(605, 66);
      this.label1.TabIndex = 76;
      this.label1.Text = "WandererBox Ultimate V2";
      this.pictureBox1.BackColor = Color.Gray;
      this.pictureBox1.Location = new Point(3, 3);
      this.pictureBox1.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(2018, 85);
      this.pictureBox1.TabIndex = 77;
      this.pictureBox1.TabStop = false;
      this.textBox5.BackColor = Color.LightSalmon;
      this.textBox5.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox5.Location = new Point(356, 719);
      this.textBox5.Margin = new Padding(4, 5, 4, 5);
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new Size(442, 35);
      this.textBox5.TabIndex = 106;
      this.textBox5.Text = "DC OUT 5-8";
      this.textBox5.TextAlign = HorizontalAlignment.Center;
      this.textBox6.BackColor = Color.LightSalmon;
      this.textBox6.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox6.Location = new Point(260, 154);
      this.textBox6.Margin = new Padding(4, 5, 4, 5);
      this.textBox6.Name = "textBox6";
      this.textBox6.Size = new Size(209, 35);
      this.textBox6.TabIndex = 108;
      this.textBox6.Text = "USB3.1-1";
      this.textBox6.TextAlign = HorizontalAlignment.Center;
      this.textBox7.BackColor = Color.LightSalmon;
      this.textBox7.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox7.Location = new Point(411, 655);
      this.textBox7.Margin = new Padding(4, 5, 4, 5);
      this.textBox7.Name = "textBox7";
      this.textBox7.Size = new Size(209, 35);
      this.textBox7.TabIndex = 114;
      this.textBox7.Text = "Dew Heater 3";
      this.textBox7.TextAlign = HorizontalAlignment.Center;
      this.textBox8.BackColor = Color.LightSalmon;
      this.textBox8.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox8.Location = new Point(411, 601);
      this.textBox8.Margin = new Padding(4, 5, 4, 5);
      this.textBox8.Name = "textBox8";
      this.textBox8.Size = new Size(209, 35);
      this.textBox8.TabIndex = 112 /*0x70*/;
      this.textBox8.Text = "Dew Heater 2";
      this.textBox8.TextAlign = HorizontalAlignment.Center;
      this.textBox9.BackColor = Color.LightSalmon;
      this.textBox9.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox9.Location = new Point(411, 541);
      this.textBox9.Margin = new Padding(4, 5, 4, 5);
      this.textBox9.Name = "textBox9";
      this.textBox9.Size = new Size(209, 35);
      this.textBox9.TabIndex = 110;
      this.textBox9.Text = "Dew Heater 1";
      this.textBox9.TextAlign = HorizontalAlignment.Center;
      this.textBox10.BackColor = Color.LightSalmon;
      this.textBox10.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox10.Location = new Point(260, 206);
      this.textBox10.Margin = new Padding(4, 5, 4, 5);
      this.textBox10.Name = "textBox10";
      this.textBox10.Size = new Size(209, 35);
      this.textBox10.TabIndex = 119;
      this.textBox10.Text = "USB3.1-2";
      this.textBox10.TextAlign = HorizontalAlignment.Center;
      this.textBox11.BackColor = Color.LightSalmon;
      this.textBox11.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox11.Location = new Point(889, 173);
      this.textBox11.Margin = new Padding(4, 5, 4, 5);
      this.textBox11.Name = "textBox11";
      this.textBox11.Size = new Size(209, 35);
      this.textBox11.TabIndex = 123;
      this.textBox11.Text = "USB2.0-1";
      this.textBox11.TextAlign = HorizontalAlignment.Center;
      this.textBox12.BackColor = Color.LightSalmon;
      this.textBox12.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox12.Location = new Point(260, 260);
      this.textBox12.Margin = new Padding(4, 5, 4, 5);
      this.textBox12.Name = "textBox12";
      this.textBox12.Size = new Size(209, 35);
      this.textBox12.TabIndex = 121;
      this.textBox12.Text = "USB3.1-3";
      this.textBox12.TextAlign = HorizontalAlignment.Center;
      this.textBox13.BackColor = Color.LightSalmon;
      this.textBox13.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox13.Location = new Point(889, 273);
      this.textBox13.Margin = new Padding(4, 5, 4, 5);
      this.textBox13.Name = "textBox13";
      this.textBox13.Size = new Size(209, 35);
      this.textBox13.TabIndex = (int) sbyte.MaxValue;
      this.textBox13.Text = "USB2.0-3";
      this.textBox13.TextAlign = HorizontalAlignment.Center;
      this.textBox14.BackColor = Color.LightSalmon;
      this.textBox14.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox14.Location = new Point(889, 223);
      this.textBox14.Margin = new Padding(4, 5, 4, 5);
      this.textBox14.Name = "textBox14";
      this.textBox14.Size = new Size(209, 35);
      this.textBox14.TabIndex = 125;
      this.textBox14.Text = "USB2.0-2";
      this.textBox14.TextAlign = HorizontalAlignment.Center;
      this.textBox14.TextChanged += new EventHandler(this.textBox14_TextChanged);
      // this.pictureBox7.Image = (Image) componentResourceManager.GetObject("pictureBox7.Image");
      this.pictureBox7.Location = new Point(-39, 134);
      this.pictureBox7.Margin = new Padding(6);
      this.pictureBox7.Name = "pictureBox7";
      this.pictureBox7.Size = new Size(1480, 922);
      this.pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox7.TabIndex = 129;
      this.pictureBox7.TabStop = false;
      this.textBox15.BackColor = Color.LightSalmon;
      this.textBox15.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox15.Location = new Point(1098, 724);
      this.textBox15.Margin = new Padding(4, 5, 4, 5);
      this.textBox15.Name = "textBox15";
      this.textBox15.Size = new Size(209, 35);
      this.textBox15.TabIndex = 130;
      this.textBox15.Text = "DC OUT 9";
      this.textBox15.TextAlign = HorizontalAlignment.Center;
      this.checkBox1.AutoSize = true;
      this.checkBox1.Checked = true;
      this.checkBox1.CheckState = CheckState.Checked;
      this.checkBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox1.Location = new Point(633, 547);
      this.checkBox1.Margin = new Padding(6);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(150, 29);
      this.checkBox1.TabIndex = 131;
      this.checkBox1.Text = "Dew Heater";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
      this.checkBox2.AutoSize = true;
      this.checkBox2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox2.Location = new Point(787, 547);
      this.checkBox2.Margin = new Padding(6);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(101, 29);
      this.checkBox2.TabIndex = 132;
      this.checkBox2.Text = "Switch";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged);
      this.checkBox3.AutoSize = true;
      this.checkBox3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox3.Location = new Point(787, 607);
      this.checkBox3.Margin = new Padding(6);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(101, 29);
      this.checkBox3.TabIndex = 134;
      this.checkBox3.Text = "Switch";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.checkBox3.CheckedChanged += new EventHandler(this.checkBox3_CheckedChanged);
      this.checkBox4.AutoSize = true;
      this.checkBox4.Checked = true;
      this.checkBox4.CheckState = CheckState.Checked;
      this.checkBox4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox4.Location = new Point(633, 607);
      this.checkBox4.Margin = new Padding(6);
      this.checkBox4.Name = "checkBox4";
      this.checkBox4.Size = new Size(150, 29);
      this.checkBox4.TabIndex = 133;
      this.checkBox4.Text = "Dew Heater";
      this.checkBox4.UseVisualStyleBackColor = true;
      this.checkBox4.CheckedChanged += new EventHandler(this.checkBox4_CheckedChanged);
      this.checkBox5.AutoSize = true;
      this.checkBox5.Checked = true;
      this.checkBox5.CheckState = CheckState.Checked;
      this.checkBox5.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox5.Location = new Point(787, 665);
      this.checkBox5.Margin = new Padding(6);
      this.checkBox5.Name = "checkBox5";
      this.checkBox5.Size = new Size(101, 29);
      this.checkBox5.TabIndex = 136;
      this.checkBox5.Text = "Switch";
      this.checkBox5.UseVisualStyleBackColor = true;
      this.checkBox5.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      this.checkBox6.AutoSize = true;
      this.checkBox6.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox6.Location = new Point(633, 665);
      this.checkBox6.Margin = new Padding(6);
      this.checkBox6.Name = "checkBox6";
      this.checkBox6.Size = new Size(150, 29);
      this.checkBox6.TabIndex = 135;
      this.checkBox6.Text = "Dew Heater";
      this.checkBox6.UseVisualStyleBackColor = true;
      this.checkBox6.CheckedChanged += new EventHandler(this.checkBox6_CheckedChanged);
      this.checkBox7.AutoSize = true;
      this.checkBox7.BackColor = Color.Transparent;
      this.checkBox7.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox7.Location = new Point(73, 746);
      this.checkBox7.Margin = new Padding(6);
      this.checkBox7.Name = "checkBox7";
      this.checkBox7.Size = new Size(179, 29);
      this.checkBox7.TabIndex = 138;
      this.checkBox7.Text = "DHT22 Sensor";
      this.checkBox7.UseVisualStyleBackColor = false;
      this.checkBox7.CheckedChanged += new EventHandler(this.checkBox7_CheckedChanged);
      this.checkBox8.AutoSize = true;
      this.checkBox8.BackColor = Color.Transparent;
      this.checkBox8.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox8.Location = new Point(73, 702);
      this.checkBox8.Margin = new Padding(6);
      this.checkBox8.Name = "checkBox8";
      this.checkBox8.Size = new Size(192 /*0xC0*/, 29);
      this.checkBox8.TabIndex = 137;
      this.checkBox8.Text = "DS18B20 Probe";
      this.checkBox8.UseVisualStyleBackColor = false;
      this.checkBox8.CheckedChanged += new EventHandler(this.checkBox8_CheckedChanged);
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.IndianRed;
      this.label6.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label6.ForeColor = Color.White;
      this.label6.Location = new Point(1499, 108);
      this.label6.Margin = new Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new Size(412, 29);
      this.label6.TabIndex = 155;
      this.label6.Text = "PWM (Dew Heater) Ports Setting";
      this.pictureBox16.BackColor = Color.IndianRed;
      this.pictureBox16.Location = new Point(1393, 81);
      this.pictureBox16.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox16.Name = "pictureBox16";
      this.pictureBox16.Size = new Size(628, 70);
      this.pictureBox16.TabIndex = 156;
      this.pictureBox16.TabStop = false;
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Firebrick;
      this.label8.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label8.ForeColor = Color.White;
      this.label8.Location = new Point(1419, 874);
      this.label8.Margin = new Padding(4, 0, 4, 0);
      this.label8.Name = "label8";
      this.label8.Size = new Size(111, 25);
      this.label8.TabIndex = 189;
      this.label8.Text = "Maximum";
      this.label8.TextAlign = ContentAlignment.MiddleCenter;
      this.label12.AutoSize = true;
      this.label12.BackColor = Color.Firebrick;
      this.label12.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label12.ForeColor = Color.White;
      this.label12.Location = new Point(1445, 807);
      this.label12.Margin = new Padding(4, 0, 4, 0);
      this.label12.Name = "label12";
      this.label12.Size = new Size(60, 25);
      this.label12.TabIndex = 188;
      this.label12.Text = "High";
      this.label12.TextAlign = ContentAlignment.MiddleCenter;
      this.label25.AutoSize = true;
      this.label25.BackColor = Color.Firebrick;
      this.label25.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label25.ForeColor = Color.White;
      this.label25.Location = new Point(1448, 742);
      this.label25.Margin = new Padding(4, 0, 4, 0);
      this.label25.Name = "label25";
      this.label25.Size = new Size(54, 25);
      this.label25.TabIndex = 187;
      this.label25.Text = "Low";
      this.label25.TextAlign = ContentAlignment.MiddleCenter;
      this.label29.AutoSize = true;
      this.label29.BackColor = Color.Maroon;
      this.label29.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label29.ForeColor = Color.White;
      this.label29.Location = new Point(1419, 614);
      this.label29.Margin = new Padding(4, 0, 4, 0);
      this.label29.Name = "label29";
      this.label29.Size = new Size(111, 25);
      this.label29.TabIndex = 186;
      this.label29.Text = "Maximum";
      this.label29.TextAlign = ContentAlignment.MiddleCenter;
      this.label30.AutoSize = true;
      this.label30.BackColor = Color.Maroon;
      this.label30.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label30.ForeColor = Color.White;
      this.label30.Location = new Point(1446, 545);
      this.label30.Margin = new Padding(4, 0, 4, 0);
      this.label30.Name = "label30";
      this.label30.Size = new Size(60, 25);
      this.label30.TabIndex = 185;
      this.label30.Text = "High";
      this.label30.TextAlign = ContentAlignment.MiddleCenter;
      this.label31.AutoSize = true;
      this.label31.BackColor = Color.Maroon;
      this.label31.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label31.ForeColor = Color.White;
      this.label31.Location = new Point(1449, 479);
      this.label31.Margin = new Padding(4, 0, 4, 0);
      this.label31.Name = "label31";
      this.label31.Size = new Size(54, 25);
      this.label31.TabIndex = 184;
      this.label31.Text = "Low";
      this.label31.TextAlign = ContentAlignment.MiddleCenter;
      this.label32.AutoSize = true;
      this.label32.BackColor = Color.Firebrick;
      this.label32.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label32.ForeColor = Color.White;
      this.label32.Location = new Point(1620, 688);
      this.label32.Margin = new Padding(4, 0, 4, 0);
      this.label32.Name = "label32";
      this.label32.Size = new Size(205, 29);
      this.label32.TabIndex = 183;
      this.label32.Text = "PWM Port DC 3";
      this.label33.AutoSize = true;
      this.label33.BackColor = Color.Maroon;
      this.label33.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label33.ForeColor = Color.White;
      this.label33.Location = new Point(1621, 420);
      this.label33.Margin = new Padding(4, 0, 4, 0);
      this.label33.Name = "label33";
      this.label33.Size = new Size(205, 29);
      this.label33.TabIndex = 182;
      this.label33.Text = "PWM Port DC 2";
      this.label34.AutoSize = true;
      this.label34.BackColor = Color.Maroon;
      this.label34.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label34.ForeColor = Color.White;
      this.label34.Location = new Point(1934, 616);
      this.label34.Margin = new Padding(4, 0, 4, 0);
      this.label34.Name = "label34";
      this.label34.Size = new Size(48 /*0x30*/, 25);
      this.label34.TabIndex = 181;
      this.label34.Text = "255";
      this.label35.AutoSize = true;
      this.label35.BackColor = Color.Maroon;
      this.label35.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label35.ForeColor = Color.White;
      this.label35.Location = new Point(1934, 547);
      this.label35.Margin = new Padding(4, 0, 4, 0);
      this.label35.Name = "label35";
      this.label35.Size = new Size(48 /*0x30*/, 25);
      this.label35.TabIndex = 180;
      this.label35.Text = "185";
      this.label36.AutoSize = true;
      this.label36.BackColor = Color.Maroon;
      this.label36.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label36.ForeColor = Color.White;
      this.label36.Location = new Point(1934, 481);
      this.label36.Margin = new Padding(4, 0, 4, 0);
      this.label36.Name = "label36";
      this.label36.Size = new Size(48 /*0x30*/, 25);
      this.label36.TabIndex = 179;
      this.label36.Text = "100";
      this.trackBar1.BackColor = Color.Maroon;
      this.trackBar1.LargeChange = 10;
      this.trackBar1.Location = new Point(1538, 611);
      this.trackBar1.Margin = new Padding(4, 5, 4, 5);
      this.trackBar1.Maximum = (int) byte.MaxValue;
      this.trackBar1.Minimum = 201;
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new Size(388, 80 /*0x50*/);
      this.trackBar1.SmallChange = 5;
      this.trackBar1.TabIndex = 178;
      this.trackBar1.TickFrequency = 10;
      this.trackBar1.Value = (int) byte.MaxValue;
      this.trackBar1.Scroll += new EventHandler(this.trackBar1_Scroll);
      this.trackBar8.BackColor = Color.Maroon;
      this.trackBar8.LargeChange = 10;
      this.trackBar8.Location = new Point(1538, 544);
      this.trackBar8.Margin = new Padding(4, 5, 4, 5);
      this.trackBar8.Maximum = 200;
      this.trackBar8.Minimum = 151;
      this.trackBar8.Name = "trackBar8";
      this.trackBar8.Size = new Size(388, 80 /*0x50*/);
      this.trackBar8.SmallChange = 5;
      this.trackBar8.TabIndex = 177;
      this.trackBar8.TickFrequency = 10;
      this.trackBar8.Value = 190;
      this.trackBar8.Scroll += new EventHandler(this.trackBar8_Scroll);
      this.trackBar12.BackColor = Color.Maroon;
      this.trackBar12.LargeChange = 10;
      this.trackBar12.Location = new Point(1538, 479);
      this.trackBar12.Margin = new Padding(4, 5, 4, 5);
      this.trackBar12.Maximum = 150;
      this.trackBar12.Minimum = 1;
      this.trackBar12.Name = "trackBar12";
      this.trackBar12.Size = new Size(388, 80 /*0x50*/);
      this.trackBar12.SmallChange = 5;
      this.trackBar12.TabIndex = 176 /*0xB0*/;
      this.trackBar12.TickFrequency = 10;
      this.trackBar12.Value = 120;
      this.trackBar12.Scroll += new EventHandler(this.trackBar12_Scroll);
      this.label37.AutoSize = true;
      this.label37.BackColor = Color.Firebrick;
      this.label37.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label37.ForeColor = Color.White;
      this.label37.Location = new Point(1936, 875);
      this.label37.Margin = new Padding(4, 0, 4, 0);
      this.label37.Name = "label37";
      this.label37.Size = new Size(48 /*0x30*/, 25);
      this.label37.TabIndex = 175;
      this.label37.Text = "255";
      this.label38.AutoSize = true;
      this.label38.BackColor = Color.Firebrick;
      this.label38.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label38.ForeColor = Color.White;
      this.label38.Location = new Point(1936, 809);
      this.label38.Margin = new Padding(4, 0, 4, 0);
      this.label38.Name = "label38";
      this.label38.Size = new Size(48 /*0x30*/, 25);
      this.label38.TabIndex = 174;
      this.label38.Text = "185";
      this.label42.AutoSize = true;
      this.label42.BackColor = Color.Firebrick;
      this.label42.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label42.ForeColor = Color.White;
      this.label42.Location = new Point(1936, 743);
      this.label42.Margin = new Padding(4, 0, 4, 0);
      this.label42.Name = "label42";
      this.label42.Size = new Size(48 /*0x30*/, 25);
      this.label42.TabIndex = 173;
      this.label42.Text = "100";
      this.trackBar13.BackColor = Color.Firebrick;
      this.trackBar13.LargeChange = 10;
      this.trackBar13.Location = new Point(1538, 874);
      this.trackBar13.Margin = new Padding(4, 5, 4, 5);
      this.trackBar13.Maximum = (int) byte.MaxValue;
      this.trackBar13.Minimum = 201;
      this.trackBar13.Name = "trackBar13";
      this.trackBar13.Size = new Size(388, 80 /*0x50*/);
      this.trackBar13.SmallChange = 5;
      this.trackBar13.TabIndex = 171;
      this.trackBar13.TickFrequency = 10;
      this.trackBar13.Value = (int) byte.MaxValue;
      this.trackBar13.Scroll += new EventHandler(this.trackBar13_Scroll);
      this.trackBar15.BackColor = Color.Firebrick;
      this.trackBar15.LargeChange = 10;
      this.trackBar15.Location = new Point(1538, 743);
      this.trackBar15.Margin = new Padding(4, 5, 4, 5);
      this.trackBar15.Maximum = 150;
      this.trackBar15.Minimum = 1;
      this.trackBar15.Name = "trackBar15";
      this.trackBar15.Size = new Size(388, 80 /*0x50*/);
      this.trackBar15.SmallChange = 5;
      this.trackBar15.TabIndex = 169;
      this.trackBar15.TickFrequency = 10;
      this.trackBar15.Value = 120;
      this.trackBar15.Scroll += new EventHandler(this.trackBar15_Scroll);
      this.label44.AutoSize = true;
      this.label44.BackColor = Color.Firebrick;
      this.label44.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label44.ForeColor = Color.White;
      this.label44.Location = new Point(1930, 347);
      this.label44.Margin = new Padding(4, 0, 4, 0);
      this.label44.Name = "label44";
      this.label44.Size = new Size(48 /*0x30*/, 25);
      this.label44.TabIndex = 166;
      this.label44.Text = "255";
      this.label45.AutoSize = true;
      this.label45.BackColor = Color.Firebrick;
      this.label45.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label45.ForeColor = Color.White;
      this.label45.Location = new Point(1930, 279);
      this.label45.Margin = new Padding(4, 0, 4, 0);
      this.label45.Name = "label45";
      this.label45.Size = new Size(48 /*0x30*/, 25);
      this.label45.TabIndex = 165;
      this.label45.Text = "185";
      this.label46.AutoSize = true;
      this.label46.BackColor = Color.Firebrick;
      this.label46.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label46.ForeColor = Color.White;
      this.label46.Location = new Point(1930, 216);
      this.label46.Margin = new Padding(4, 0, 4, 0);
      this.label46.Name = "label46";
      this.label46.Size = new Size(48 /*0x30*/, 25);
      this.label46.TabIndex = 164;
      this.label46.Text = "100";
      this.trackBar16.BackColor = Color.Firebrick;
      this.trackBar16.LargeChange = 10;
      this.trackBar16.Location = new Point(1538, 345);
      this.trackBar16.Margin = new Padding(4, 5, 4, 5);
      this.trackBar16.Maximum = (int) byte.MaxValue;
      this.trackBar16.Minimum = 201;
      this.trackBar16.Name = "trackBar16";
      this.trackBar16.Size = new Size(385, 80 /*0x50*/);
      this.trackBar16.SmallChange = 5;
      this.trackBar16.TabIndex = 163;
      this.trackBar16.TickFrequency = 10;
      this.trackBar16.Value = (int) byte.MaxValue;
      this.trackBar16.Scroll += new EventHandler(this.trackBar16_Scroll);
      this.trackBar17.BackColor = Color.Firebrick;
      this.trackBar17.LargeChange = 10;
      this.trackBar17.Location = new Point(1534, 279);
      this.trackBar17.Margin = new Padding(4, 5, 4, 5);
      this.trackBar17.Maximum = 200;
      this.trackBar17.Minimum = 151;
      this.trackBar17.Name = "trackBar17";
      this.trackBar17.Size = new Size(388, 80 /*0x50*/);
      this.trackBar17.SmallChange = 5;
      this.trackBar17.TabIndex = 162;
      this.trackBar17.TickFrequency = 10;
      this.trackBar17.Value = 190;
      this.trackBar17.Scroll += new EventHandler(this.trackBar17_Scroll);
      this.trackBar18.BackColor = Color.Firebrick;
      this.trackBar18.LargeChange = 10;
      this.trackBar18.Location = new Point(1534, 214);
      this.trackBar18.Margin = new Padding(4, 5, 4, 5);
      this.trackBar18.Maximum = 150;
      this.trackBar18.Minimum = 1;
      this.trackBar18.Name = "trackBar18";
      this.trackBar18.Size = new Size(388, 80 /*0x50*/);
      this.trackBar18.SmallChange = 5;
      this.trackBar18.TabIndex = 161;
      this.trackBar18.TickFrequency = 10;
      this.trackBar18.Value = 120;
      this.trackBar18.Scroll += new EventHandler(this.trackBar18_Scroll);
      this.label47.AutoSize = true;
      this.label47.BackColor = Color.Firebrick;
      this.label47.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label47.ForeColor = Color.White;
      this.label47.Location = new Point(1423, 348);
      this.label47.Margin = new Padding(4, 0, 4, 0);
      this.label47.Name = "label47";
      this.label47.Size = new Size(111, 25);
      this.label47.TabIndex = 160 /*0xA0*/;
      this.label47.Text = "Maximum";
      this.label47.TextAlign = ContentAlignment.MiddleCenter;
      this.label48.AutoSize = true;
      this.label48.BackColor = Color.Firebrick;
      this.label48.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label48.ForeColor = Color.White;
      this.label48.Location = new Point(1448, 281);
      this.label48.Margin = new Padding(4, 0, 4, 0);
      this.label48.Name = "label48";
      this.label48.Size = new Size(60, 25);
      this.label48.TabIndex = 159;
      this.label48.Text = "High";
      this.label48.TextAlign = ContentAlignment.MiddleCenter;
      this.label49.AutoSize = true;
      this.label49.BackColor = Color.Firebrick;
      this.label49.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label49.ForeColor = Color.White;
      this.label49.Location = new Point(1451, 217);
      this.label49.Margin = new Padding(4, 0, 4, 0);
      this.label49.Name = "label49";
      this.label49.Size = new Size(54, 25);
      this.label49.TabIndex = 158;
      this.label49.Text = "Low";
      this.label49.TextAlign = ContentAlignment.MiddleCenter;
      this.pictureBox17.BackColor = Color.Firebrick;
      this.pictureBox17.Location = new Point(1393, 89);
      this.pictureBox17.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox17.Name = "pictureBox17";
      this.pictureBox17.Size = new Size(628, 316);
      this.pictureBox17.TabIndex = 157;
      this.pictureBox17.TabStop = false;
      this.pictureBox18.BackColor = Color.Maroon;
      this.pictureBox18.Location = new Point(1393, 400);
      this.pictureBox18.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox18.Name = "pictureBox18";
      this.pictureBox18.Size = new Size(628, 287);
      this.pictureBox18.TabIndex = 167;
      this.pictureBox18.TabStop = false;
      this.label50.AutoSize = true;
      this.label50.BackColor = Color.Firebrick;
      this.label50.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label50.ForeColor = Color.White;
      this.label50.Location = new Point(1622, 163);
      this.label50.Margin = new Padding(4, 0, 4, 0);
      this.label50.Name = "label50";
      this.label50.Size = new Size(205, 29);
      this.label50.TabIndex = 190;
      this.label50.Text = "PWM Port DC 1";
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.IndianRed;
      this.label3.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label3.ForeColor = Color.White;
      this.label3.Location = new Point(1483, 964);
      this.label3.Margin = new Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(454, 29);
      this.label3.TabIndex = 191;
      this.label3.Text = "Constant Temperatrue Mode Setting";
      this.pictureBox3.BackColor = Color.IndianRed;
      this.pictureBox3.Location = new Point(1393, 945);
      this.pictureBox3.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new Size(628, 70);
      this.pictureBox3.TabIndex = 192 /*0xC0*/;
      this.pictureBox3.TabStop = false;
      this.pictureBox4.BackColor = Color.Firebrick;
      this.pictureBox4.Location = new Point(1393, 1003);
      this.pictureBox4.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new Size(628, 256 /*0x0100*/);
      this.pictureBox4.TabIndex = 193;
      this.pictureBox4.TabStop = false;
      this.label39.BackColor = Color.Transparent;
      this.label39.Font = new Font("Microsoft Sans Serif", 9.857143f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label39.ForeColor = SystemColors.ControlDarkDark;
      this.label39.Location = new Point(86, 1024 /*0x0400*/);
      this.label39.Margin = new Padding(0);
      this.label39.Name = "label39";
      this.label39.Size = new Size(800, 88);
      this.label39.TabIndex = 224 /*0xE0*/;
      this.label39.Text = "Auto control of dew heater has two modes:\r\n1. Humidity mode:Requires DHT22 humidity sensor.\r\n2. Constant temperature mode:Requires DS18B20 temperature probe.";
      this.label39.TextAlign = ContentAlignment.MiddleCenter;
      this.trackBar14.BackColor = Color.Firebrick;
      this.trackBar14.LargeChange = 10;
      this.trackBar14.Location = new Point(1538, 809);
      this.trackBar14.Margin = new Padding(4, 5, 4, 5);
      this.trackBar14.Maximum = 200;
      this.trackBar14.Minimum = 151;
      this.trackBar14.Name = "trackBar14";
      this.trackBar14.Size = new Size(388, 80 /*0x50*/);
      this.trackBar14.SmallChange = 5;
      this.trackBar14.TabIndex = 170;
      this.trackBar14.TickFrequency = 10;
      this.trackBar14.Value = 190;
      this.trackBar14.Scroll += new EventHandler(this.trackBar14_Scroll);
      this.pictureBox19.BackColor = Color.Firebrick;
      this.pictureBox19.Location = new Point(1393, 670);
      this.pictureBox19.Margin = new Padding(4, 5, 4, 5);
      this.pictureBox19.Name = "pictureBox19";
      this.pictureBox19.Size = new Size(628, 284);
      this.pictureBox19.TabIndex = 168;
      this.pictureBox19.TabStop = false;
      this.cmdOK.AutoSize = true;
      this.cmdOK.BackColor = SystemColors.ControlLight;
      this.cmdOK.DialogResult = DialogResult.OK;
      this.cmdOK.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.cmdOK.Location = new Point(1011, 1167);
      this.cmdOK.Margin = new Padding(6, 5, 6, 5);
      this.cmdOK.Name = "cmdOK";
      this.cmdOK.Size = new Size(128 /*0x80*/, 53);
      this.cmdOK.TabIndex = 73;
      this.cmdOK.Text = "OK";
      this.cmdOK.UseVisualStyleBackColor = false;
      this.cmdOK.Click += new EventHandler(this.cmdOK_Click_1);
      this.button1.AutoSize = true;
      this.button1.BackColor = SystemColors.ControlLight;
      this.button1.DialogResult = DialogResult.OK;
      this.button1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.button1.Location = new Point(1185, 1167);
      this.button1.Margin = new Padding(6, 5, 6, 5);
      this.button1.Name = "button1";
      this.button1.Size = new Size(134, 53);
      this.button1.TabIndex = 229;
      this.button1.Text = "Cancel";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Firebrick;
      this.label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label2.ForeColor = Color.White;
      this.label2.Location = new Point(1922, 216);
      this.label2.Margin = new Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(0, 25);
      this.label2.TabIndex = 230;
      this.label2.TextAlign = ContentAlignment.MiddleCenter;
      this.label14.AutoSize = true;
      this.label14.BackColor = Color.Firebrick;
      this.label14.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label14.ForeColor = Color.White;
      this.label14.Location = new Point(1963, 1170);
      this.label14.Margin = new Padding(4, 0, 4, 0);
      this.label14.Name = "label14";
      this.label14.Size = new Size(33, 29);
      this.label14.TabIndex = 258;
      this.label14.Text = "℃";
      this.label15.AutoSize = true;
      this.label15.BackColor = Color.Firebrick;
      this.label15.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label15.ForeColor = Color.White;
      this.label15.Location = new Point(1965, 1109);
      this.label15.Margin = new Padding(4, 0, 4, 0);
      this.label15.Name = "label15";
      this.label15.Size = new Size(33, 29);
      this.label15.TabIndex = 257;
      this.label15.Text = "℃";
      this.label16.AutoSize = true;
      this.label16.BackColor = Color.Firebrick;
      this.label16.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label16.ForeColor = Color.White;
      this.label16.Location = new Point(1963, 1043);
      this.label16.Margin = new Padding(4, 0, 4, 0);
      this.label16.Name = "label16";
      this.label16.Size = new Size(33, 29);
      this.label16.TabIndex = 256 /*0x0100*/;
      this.label16.Text = "℃";
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.Firebrick;
      this.label10.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label10.ForeColor = Color.White;
      this.label10.Location = new Point(1919, 1170);
      this.label10.Margin = new Padding(4, 0, 4, 0);
      this.label10.Name = "label10";
      this.label10.Size = new Size(41, 29);
      this.label10.TabIndex = (int) byte.MaxValue;
      this.label10.Text = "40";
      this.label11.AutoSize = true;
      this.label11.BackColor = Color.Firebrick;
      this.label11.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label11.ForeColor = Color.White;
      this.label11.Location = new Point(1921, 1109);
      this.label11.Margin = new Padding(4, 0, 4, 0);
      this.label11.Name = "label11";
      this.label11.Size = new Size(41, 29);
      this.label11.TabIndex = 254;
      this.label11.Text = "40";
      this.label13.AutoSize = true;
      this.label13.BackColor = Color.Firebrick;
      this.label13.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label13.ForeColor = Color.White;
      this.label13.Location = new Point(1919, 1045);
      this.label13.Margin = new Padding(4, 0, 4, 0);
      this.label13.Name = "label13";
      this.label13.Size = new Size(41, 29);
      this.label13.TabIndex = 253;
      this.label13.Text = "40";
      this.trackBar2.BackColor = Color.Firebrick;
      this.trackBar2.LargeChange = 2;
      this.trackBar2.Location = new Point(1618, 1171);
      this.trackBar2.Margin = new Padding(4, 5, 4, 5);
      this.trackBar2.Maximum = 50;
      this.trackBar2.Minimum = 10;
      this.trackBar2.Name = "trackBar2";
      this.trackBar2.Size = new Size(294, 80 /*0x50*/);
      this.trackBar2.TabIndex = 252;
      this.trackBar2.TickFrequency = 2;
      this.trackBar2.Value = 40;
      this.trackBar3.BackColor = Color.Firebrick;
      this.trackBar3.LargeChange = 2;
      this.trackBar3.Location = new Point(1618, 1106);
      this.trackBar3.Margin = new Padding(4, 5, 4, 5);
      this.trackBar3.Maximum = 50;
      this.trackBar3.Minimum = 10;
      this.trackBar3.Name = "trackBar3";
      this.trackBar3.Size = new Size(294, 80 /*0x50*/);
      this.trackBar3.TabIndex = 251;
      this.trackBar3.TickFrequency = 2;
      this.trackBar3.Value = 40;
      this.trackBar4.BackColor = Color.Firebrick;
      this.trackBar4.LargeChange = 2;
      this.trackBar4.Location = new Point(1618, 1041);
      this.trackBar4.Margin = new Padding(4, 5, 4, 5);
      this.trackBar4.Maximum = 50;
      this.trackBar4.Minimum = 10;
      this.trackBar4.Name = "trackBar4";
      this.trackBar4.Size = new Size(294, 80 /*0x50*/);
      this.trackBar4.TabIndex = 250;
      this.trackBar4.TickFrequency = 2;
      this.trackBar4.Value = 40;
      this.label9.AutoSize = true;
      this.label9.BackColor = Color.Firebrick;
      this.label9.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label9.ForeColor = Color.White;
      this.label9.Location = new Point(1432, 1175);
      this.label9.Margin = new Padding(4, 0, 4, 0);
      this.label9.Name = "label9";
      this.label9.Size = new Size(169, 25);
      this.label9.TabIndex = 249;
      this.label9.Text = "PWM Port DC3";
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Firebrick;
      this.label5.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label5.ForeColor = Color.White;
      this.label5.Location = new Point(1432, 1109);
      this.label5.Margin = new Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new Size(169, 25);
      this.label5.TabIndex = 248;
      this.label5.Text = "PWM Port DC2";
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Firebrick;
      this.label4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label4.ForeColor = Color.White;
      this.label4.Location = new Point(1432, 1043);
      this.label4.Margin = new Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new Size(169, 25);
      this.label4.TabIndex = 247;
      this.label4.Text = "PWM Port DC1";
      this.checkBox9.AutoSize = true;
      this.checkBox9.Font = new Font("Microsoft Sans Serif", 9.857143f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.checkBox9.Location = new Point(1139, 1053);
      this.checkBox9.Name = "checkBox9";
      this.checkBox9.Size = new Size(73, 33);
      this.checkBox9.TabIndex = 259;
      this.checkBox9.Text = "EN";
      this.checkBox9.UseVisualStyleBackColor = true;
      this.checkBox9.CheckedChanged += new EventHandler(this.checkBox9_CheckedChanged);
      this.AutoScaleDimensions = new SizeF(11f, 24f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new Size(2021, 1258);
      this.Controls.Add((Control) this.checkBox9);
      this.Controls.Add((Control) this.label14);
      this.Controls.Add((Control) this.label15);
      this.Controls.Add((Control) this.label16);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.label13);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label39);
      this.Controls.Add((Control) this.label50);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.checkBox7);
      this.Controls.Add((Control) this.checkBox8);
      this.Controls.Add((Control) this.checkBox5);
      this.Controls.Add((Control) this.checkBox6);
      this.Controls.Add((Control) this.checkBox3);
      this.Controls.Add((Control) this.checkBox4);
      this.Controls.Add((Control) this.checkBox2);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.textBox15);
      this.Controls.Add((Control) this.textBox13);
      this.Controls.Add((Control) this.textBox14);
      this.Controls.Add((Control) this.textBox11);
      this.Controls.Add((Control) this.textBox12);
      this.Controls.Add((Control) this.textBox10);
      this.Controls.Add((Control) this.textBox7);
      this.Controls.Add((Control) this.textBox8);
      this.Controls.Add((Control) this.textBox9);
      this.Controls.Add((Control) this.textBox6);
      this.Controls.Add((Control) this.textBox5);
      this.Controls.Add((Control) this.cmdOK);
      this.Controls.Add((Control) this.linkLabel1);
      this.Controls.Add((Control) this.label17);
      this.Controls.Add((Control) this.textBox4);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.pictureBox16);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.label25);
      this.Controls.Add((Control) this.label29);
      this.Controls.Add((Control) this.label30);
      this.Controls.Add((Control) this.label31);
      this.Controls.Add((Control) this.label32);
      this.Controls.Add((Control) this.label33);
      this.Controls.Add((Control) this.label34);
      this.Controls.Add((Control) this.label35);
      this.Controls.Add((Control) this.label36);
      this.Controls.Add((Control) this.label37);
      this.Controls.Add((Control) this.label38);
      this.Controls.Add((Control) this.label42);
      this.Controls.Add((Control) this.label44);
      this.Controls.Add((Control) this.label45);
      this.Controls.Add((Control) this.label46);
      this.Controls.Add((Control) this.label47);
      this.Controls.Add((Control) this.label48);
      this.Controls.Add((Control) this.label49);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.pictureBox3);
      this.Controls.Add((Control) this.trackBar13);
      this.Controls.Add((Control) this.trackBar14);
      this.Controls.Add((Control) this.trackBar15);
      this.Controls.Add((Control) this.pictureBox19);
      this.Controls.Add((Control) this.trackBar1);
      this.Controls.Add((Control) this.trackBar8);
      this.Controls.Add((Control) this.trackBar12);
      this.Controls.Add((Control) this.pictureBox18);
      this.Controls.Add((Control) this.trackBar16);
      this.Controls.Add((Control) this.trackBar17);
      this.Controls.Add((Control) this.trackBar18);
      this.Controls.Add((Control) this.pictureBox17);
      this.Controls.Add((Control) this.trackBar2);
      this.Controls.Add((Control) this.trackBar3);
      this.Controls.Add((Control) this.trackBar4);
      this.Controls.Add((Control) this.pictureBox4);
      this.Controls.Add((Control) this.pictureBox7);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Margin = new Padding(6, 5, 6, 5);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (SetupForUltimateV2);
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = " ";
      this.Load += new EventHandler(this.SetupDialogForm_Load);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.pictureBox7).EndInit();
      ((ISupportInitialize) this.pictureBox16).EndInit();
      this.trackBar1.EndInit();
      this.trackBar8.EndInit();
      this.trackBar12.EndInit();
      this.trackBar13.EndInit();
      this.trackBar15.EndInit();
      this.trackBar16.EndInit();
      this.trackBar17.EndInit();
      this.trackBar18.EndInit();
      ((ISupportInitialize) this.pictureBox17).EndInit();
      ((ISupportInitialize) this.pictureBox18).EndInit();
      ((ISupportInitialize) this.pictureBox3).EndInit();
      ((ISupportInitialize) this.pictureBox4).EndInit();
      this.trackBar14.EndInit();
      ((ISupportInitialize) this.pictureBox19).EndInit();
      this.trackBar2.EndInit();
      this.trackBar3.EndInit();
      this.trackBar4.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
