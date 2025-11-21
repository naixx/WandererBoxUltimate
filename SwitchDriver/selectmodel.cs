// Decompiled with JetBrains decompiler
// Type: ASCOM.WandererBoxes.selectmodel
// Assembly: ASCOM.WandererBoxes.Switch, Version=6.6.0.0, Culture=neutral, PublicKeyToken=5a596dde3293c610
// MVID: E3106A5C-05F3-42C7-89F9-2A2C7253BE13
// Assembly location: C:\Program Files (x86)\Wanderer Astro\ASCOM.WandererBoxes.Switch.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using ASCOM.Utilities;
using ASCOM.WandererBoxes.Properties;

namespace ASCOM.WandererBoxes
{
  public class selectmodel : Form
  {
    private IContainer components;
    private Button cmdOK;
    private ComboBox comboBoxComPort;
    private Label label2;
    private CheckBox checkBox3;
    private CheckBox checkBox2;
    public CheckBox checkBox1;
    private PictureBox picASCOM;
    private RadioButton radioButton3;
    private RadioButton radioButton4;

    public selectmodel() => this.InitializeComponent();

    private void selectmodel_Load(object sender, EventArgs e)
    {
      if (Switch.lang == "en")
      {
        this.checkBox2.Checked = true;
        this.checkBox3.Checked = false;
      }
      else
      {
        this.checkBox3.Checked = true;
        this.checkBox2.Checked = false;
      }
      this.comboBoxComPort.Items.Clear();
      this.comboBoxComPort.Items.AddRange((object[]) SerialPort.GetPortNames());
      if (this.comboBoxComPort.Items.Contains((object) Switch.comPort))
        this.comboBoxComPort.SelectedItem = (object) Switch.comPort;
      switch (Switch.manualCOM)
      {
        case "true":
          this.checkBox1.Checked = true;
          this.comboBoxComPort.Enabled = true;
          this.label2.Enabled = true;
          break;
        case "false":
          this.checkBox1.Checked = false;
          this.comboBoxComPort.Enabled = false;
          this.label2.Enabled = false;
          break;
      }
      this.radioButton3.Checked = Switch.selectedmodel == "PlusV2";
      if (Switch.selectedmodel == "UltimateV2")
        this.radioButton4.Checked = true;
      else
        this.radioButton4.Checked = false;
    }

    private void cmdOK_Click(object sender, EventArgs e)
    {
      switch (Switch.selectedmodel)
      {
        case "UltimateV2":
          using (Profile profile = new Profile())
          {
            profile.DeviceType = "Switch";
            Switch.DC1name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomDC1name, string.Empty, "PWM 1");
            Switch.DC2name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomDC2name, string.Empty, "PWM 2");
            Switch.DC3name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomDC3name, string.Empty, "PWM 3");
            Switch.DC4name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomDC4name, string.Empty, "DC OUT 4");
            Switch.DC5_8name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomDC5_8name, string.Empty, "DC OUT 5-8");
            Switch.DC9name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomDC9name, string.Empty, "DC9 Always ON");
            Switch.USB3_1name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomUSB3_1name, string.Empty, "USB3.1-1");
            Switch.USB3_2name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomUSB3_2name, string.Empty, "USB3.1-2");
            Switch.USB3_3name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomUSB3_3name, string.Empty, "USB3.1-3");
            Switch.USB2_1name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomUSB2_1name, string.Empty, "USB2.0-1");
            Switch.USB2_2name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomUSB2_2name, string.Empty, "USB2.0-2");
            Switch.USB2_3name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomUSB2_3name, string.Empty, "USB2.0-3");
            Switch.USB2_4name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomUSB2_4name, string.Empty, "USB2.0-4");
            Switch.USB2_5name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomUSB2_5name, string.Empty, "USB2.0-5");
            Switch.USB2_6name = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomUSB2_6name, string.Empty, "USB2.0-6");
            Switch.heater1Mode = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomheater1Mode, string.Empty, "Dew Heater1");
            Switch.heater2Mode = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomheater2Mode, string.Empty, "Dew Heater2");
            Switch.heater3Mode = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomheater3Mode, string.Empty, "Switch3");
            Switch.dew1low = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomdew1low, string.Empty, "1150")) - 1000;
            Switch.dew2low = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomdew2low, string.Empty, "2150")) - 2000;
            Switch.dew3low = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomdew3low, string.Empty, "3150")) - 3000;
            Switch.dew1high = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomdew1high, string.Empty, "1190")) - 1000;
            Switch.dew2high = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomdew2high, string.Empty, "2190")) - 2000;
            Switch.dew3high = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomdew3high, string.Empty, "3190")) - 3000;
            Switch.dew1maximum = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomdew1maximum, string.Empty, "1255")) - 1000;
            Switch.dew2maximum = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomdew2maximum, string.Empty, "2255")) - 2000;
            Switch.dew3maximum = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomdew3maximum, string.Empty, "3255")) - 3000;
            Switch.dew1t = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomdew1t, string.Empty, "10040")) - 10000;
            Switch.dew2t = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomdew2t, string.Empty, "20040")) - 20000;
            Switch.dew3t = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.Ascomdew3t, string.Empty, "30040")) - 30000;
            Switch.Sensortype = profile.GetValue("ASCOM.WandererBoxes.Switch", Switch.AscomSensorType, string.Empty, "None");
            Switch.DC1status = profile.GetValue("ASCOM.WandererBoxes.Switch", "DC1status", string.Empty, "3");
            Switch.DC2status = profile.GetValue("ASCOM.WandererBoxes.Switch", "DC2status", string.Empty, "3");
            Switch.DC3status = profile.GetValue("ASCOM.WandererBoxes.Switch", "DC3status", string.Empty, "On");
            Switch.DC4status = profile.GetValue("ASCOM.WandererBoxes.Switch", "DC4status", string.Empty, "On");
            Switch.DC5_8status = profile.GetValue("ASCOM.WandererBoxes.Switch", "DC5_8status", string.Empty, "On");
            Switch.USB31status = profile.GetValue("ASCOM.WandererBoxes.Switch", "USB31status", string.Empty, "On");
            Switch.USB32status = profile.GetValue("ASCOM.WandererBoxes.Switch", "USB32status", string.Empty, "On");
            Switch.USB33status = profile.GetValue("ASCOM.WandererBoxes.Switch", "USB33status", string.Empty, "On");
            Switch.USB21status = profile.GetValue("ASCOM.WandererBoxes.Switch", "USB21status", string.Empty, "On");
            Switch.USB22status = profile.GetValue("ASCOM.WandererBoxes.Switch", "USB22status", string.Empty, "On");
            Switch.USB23status = profile.GetValue("ASCOM.WandererBoxes.Switch", "USB23status", string.Empty, "On");
            Switch.USB24status = profile.GetValue("ASCOM.WandererBoxes.Switch", "USB24status", string.Empty, "On");
            Switch.USB25status = profile.GetValue("ASCOM.WandererBoxes.Switch", "USB25status", string.Empty, "On");
            Switch.USB26status = profile.GetValue("ASCOM.WandererBoxes.Switch", "USB26status", string.Empty, "On");
            break;
          }
        case "PlusV2":
          using (Profile profile = new Profile())
          {
            profile.DeviceType = "Switch";
            Switch.DC1_3name = profile.GetValue("ASCOM.WandererBoxes.Switch", "1-3", string.Empty, "DC 1-3");
            Switch.DC4name = profile.GetValue("ASCOM.WandererBoxes.Switch", "4", string.Empty, "PWM 1");
            Switch.DC5name = profile.GetValue("ASCOM.WandererBoxes.Switch", "5", string.Empty, "PWM 2");
            Switch.DC6name = profile.GetValue("ASCOM.WandererBoxes.Switch", "6", string.Empty, "DC6 Always On");
            Switch.USBname = profile.GetValue("ASCOM.WandererBoxes.Switch", "USB", string.Empty, "USB Device");
            Switch.heater1Mode = profile.GetValue("ASCOM.WandererBoxes.Switch", "1mode", string.Empty, "Dew Heater1");
            Switch.heater2Mode = profile.GetValue("ASCOM.WandererBoxes.Switch", "2mode", string.Empty, "Dew Heater2");
            Switch.dew1low = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", "1low", string.Empty, "1150")) - 1000;
            Switch.dew2low = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", "2low", string.Empty, "2150")) - 2000;
            Switch.dew1high = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", "1high", string.Empty, "1190")) - 1000;
            Switch.dew2high = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", "2high", string.Empty, "2190")) - 2000;
            Switch.dew1maximum = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", "1max", string.Empty, "1255")) - 1000;
            Switch.dew2maximum = Convert.ToInt32(profile.GetValue("ASCOM.WandererBoxes.Switch", "2max", string.Empty, "2255")) - 2000;
            Switch.DC1status = profile.GetValue("ASCOM.WandererBoxes.Switch", "DC1status", string.Empty, "0");
            Switch.DC2status = profile.GetValue("ASCOM.WandererBoxes.Switch", "DC2status", string.Empty, "0");
            Switch.DC3status = profile.GetValue("ASCOM.WandererBoxes.Switch", "DC3status", string.Empty, "On");
            Switch.USBstatus = profile.GetValue("ASCOM.WandererBoxes.Switch", "USBstatus", string.Empty, "On");
            Switch.Sensortype = profile.GetValue("ASCOM.WandererBoxes.Switch", "type", string.Empty, "None");
            break;
          }
      }
      if (!this.radioButton3.Checked && !this.radioButton4.Checked)
      {
        int num = (int) MessageBox.Show("Please select the model in setup!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        try
        {
          Switch.comPort = (string) this.comboBoxComPort.SelectedItem;
        }
        catch
        {
        }
      }
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox1.Checked)
      {
        this.comboBoxComPort.Enabled = true;
        this.label2.Enabled = true;
        Switch.manualCOM = "true";
      }
      else
      {
        this.comboBoxComPort.Enabled = false;
        this.label2.Enabled = false;
        Switch.manualCOM = "false";
      }
    }

    private void radioButton3_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioButton3.Checked)
        return;
      Switch.selectedmodel = "PlusV2";
    }

    private void radioButton4_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioButton4.Checked)
        return;
      Switch.selectedmodel = "UltimateV2";
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox2.Checked)
      {
        this.checkBox3.Checked = false;
        this.checkBox1.Text = "Manual selection";
        this.label2.Text = "Port";
        Switch.lang = "en";
      }
      if (!this.checkBox2.Checked)
      {
        this.checkBox3.Checked = true;
        this.checkBox1.Text = "手动选择端口";
        this.label2.Text = "端口";
        Switch.lang = "cn";
      }
      using (Profile profile = new Profile())
      {
        profile.DeviceType = "Switch";
        profile.WriteValue("ASCOM.WandererBoxes.Switch", "lang", "en");
      }
    }

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.checkBox3.Checked)
      {
        this.checkBox2.Checked = true;
        this.checkBox1.Text = "Manual selection";
        this.label2.Text = "Port";
        Switch.lang = "en";
      }
      if (this.checkBox3.Checked)
      {
        this.checkBox2.Checked = false;
        this.checkBox1.Text = "手动选择端口";
        this.label2.Text = "端口";
        Switch.lang = "cn";
      }
      using (Profile profile = new Profile())
      {
        profile.DeviceType = "Switch";
        profile.WriteValue("ASCOM.WandererBoxes.Switch", "lang", "cn");
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (selectmodel));
      this.cmdOK = new Button();
      this.comboBoxComPort = new ComboBox();
      this.label2 = new Label();
      this.checkBox3 = new CheckBox();
      this.checkBox2 = new CheckBox();
      this.checkBox1 = new CheckBox();
      this.picASCOM = new PictureBox();
      this.radioButton3 = new RadioButton();
      this.radioButton4 = new RadioButton();
      ((ISupportInitialize) this.picASCOM).BeginInit();
      this.SuspendLayout();
      this.cmdOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cmdOK.DialogResult = DialogResult.OK;
      this.cmdOK.Location = new Point(217, 178);
      this.cmdOK.Name = "cmdOK";
      this.cmdOK.Size = new Size(59, 22);
      this.cmdOK.TabIndex = 2;
      this.cmdOK.Text = "OK";
      this.cmdOK.UseVisualStyleBackColor = true;
      this.cmdOK.Click += new EventHandler(this.cmdOK_Click);
      this.comboBoxComPort.FormattingEnabled = true;
      this.comboBoxComPort.Location = new Point(53, 179);
      this.comboBoxComPort.Name = "comboBoxComPort";
      this.comboBoxComPort.Size = new Size(90, 20);
      this.comboBoxComPort.TabIndex = 9;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.857143f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(12, 181);
      this.label2.Name = "label2";
      this.label2.Size = new Size(34, 17);
      this.label2.TabIndex = 8;
      this.label2.Text = "Port";
      this.checkBox3.AutoSize = true;
      this.checkBox3.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox3.Location = new Point(99, 27);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(51, 21);
      this.checkBox3.TabIndex = 44;
      this.checkBox3.Text = "中文";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.checkBox3.CheckedChanged += new EventHandler(this.checkBox3_CheckedChanged);
      this.checkBox2.AutoSize = true;
      this.checkBox2.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox2.Location = new Point(33, 27);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(68, 21);
      this.checkBox2.TabIndex = 43;
      this.checkBox2.Text = "English";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged);
      this.checkBox1.AutoSize = true;
      this.checkBox1.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox1.Location = new Point(15, 148);
      this.checkBox1.Margin = new Padding(2);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(133, 21);
      this.checkBox1.TabIndex = 42;
      this.checkBox1.Text = "Manual selection";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
      this.picASCOM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.picASCOM.Cursor = Cursors.Hand;
      this.picASCOM.Image = (Image) Resources.ASCOM;
      this.picASCOM.Location = new Point(236, 14);
      this.picASCOM.Name = "picASCOM";
      this.picASCOM.Size = new Size(47, 44);
      this.picASCOM.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picASCOM.TabIndex = 41;
      this.picASCOM.TabStop = false;
      this.radioButton3.AutoSize = true;
      this.radioButton3.Location = new Point(15, 77);
      this.radioButton3.Margin = new Padding(1);
      this.radioButton3.Name = "radioButton3";
      this.radioButton3.Size = new Size(137, 16 /*0x10*/);
      this.radioButton3.TabIndex = 45;
      this.radioButton3.Text = "WandererBox Plus V2";
      this.radioButton3.UseVisualStyleBackColor = true;
      this.radioButton3.CheckedChanged += new EventHandler(this.radioButton3_CheckedChanged);
      this.radioButton4.AutoSize = true;
      this.radioButton4.Checked = true;
      this.radioButton4.Location = new Point(15, 104);
      this.radioButton4.Margin = new Padding(1);
      this.radioButton4.Name = "radioButton4";
      this.radioButton4.Size = new Size(161, 16 /*0x10*/);
      this.radioButton4.TabIndex = 46;
      this.radioButton4.TabStop = true;
      this.radioButton4.Text = "WandererBox Ultimate V2";
      this.radioButton4.UseVisualStyleBackColor = true;
      this.radioButton4.CheckedChanged += new EventHandler(this.radioButton4_CheckedChanged);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(307, 208 /*0xD0*/);
      this.Controls.Add((Control) this.radioButton4);
      this.Controls.Add((Control) this.radioButton3);
      this.Controls.Add((Control) this.checkBox3);
      this.Controls.Add((Control) this.checkBox2);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.picASCOM);
      this.Controls.Add((Control) this.comboBoxComPort);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.cmdOK);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(1);
      this.Name = nameof (selectmodel);
      this.Text = "Select product model";
      this.Load += new EventHandler(this.selectmodel_Load);
      ((ISupportInitialize) this.picASCOM).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
