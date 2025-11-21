// Decompiled with JetBrains decompiler
// Type: ASCOM.WandererBoxes.PlusV2Monitor
// Assembly: ASCOM.WandererBoxes.Switch, Version=6.6.0.0, Culture=neutral, PublicKeyToken=5a596dde3293c610
// MVID: E3106A5C-05F3-42C7-89F9-2A2C7253BE13
// Assembly location: C:\Program Files (x86)\Wanderer Astro\ASCOM.WandererBoxes.Switch.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ASCOM.WandererBoxes
{
  public class PlusV2Monitor : Form
  {
    private DateTime X_minValue;
    private readonly List<double> vol;
    private readonly List<double> cur;
    private IContainer components;
    private Chart chart2;
    private Label label1;
    private Chart chart1;
    private PictureBox pictureBox1;
    private CheckBox checkBox1;
    private Button button1;

    public PlusV2Monitor()
    {
      this.Load += new EventHandler(this.PlusV2Monitor_Load);
      this.vol = new List<double>();
      this.cur = new List<double>();
      this.InitializeComponent();
    }

    private void PlusV2Monitor_Load(object sender, EventArgs e)
    {
      Switch.i = 0;
      Timer timer = new Timer();
      timer.Tick += new EventHandler(this.OnTimedEvent);
      timer.Interval = 2000;
      timer.Enabled = true;
      this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
      this.chart1.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Seconds;
      this.chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 4.0;
      this.chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 4.0;
      this.chart1.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Seconds;
      this.chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.ToOADate();
      this.chart1.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
      this.X_minValue = DateTime.Now;
      this.chart2.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
      this.chart2.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Seconds;
      this.chart2.ChartAreas[0].AxisX.MajorGrid.Interval = 4.0;
      this.chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 4.0;
      this.chart2.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Seconds;
      this.chart2.ChartAreas[0].AxisX.Maximum = DateTime.Now.ToOADate();
      this.chart2.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
    }

    private void OnTimedEvent(object source, EventArgs e)
    {
      this.UpdateChart(Switch.voltage);
      this.UpdateChart2(Switch.current);
      this.label1.Text = $"Voltage:{Switch.voltage.ToString()}V   Current:{Switch.current.ToString()}A   Power:{(Switch.voltage * Switch.current).ToString("0.##")}W";
    }

    private void UpdateChart(double voltage)
    {
      Series series = this.chart1.Series[0];
      DateTime dateTime;
      if (this.checkBox1.Checked)
      {
        if (series.Points.Count <= 2400)
        {
          this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
          this.chart1.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
          this.chart1.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Minutes;
          this.chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 5.0;
          this.chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 5.0;
          series.Points.SuspendUpdates();
          this.chart1.ChartAreas[0].AxisY.Maximum = 14.0;
          this.chart1.ChartAreas[0].AxisY.Minimum = 0.0;
          this.chart1.ChartAreas[0].AxisX.Minimum = this.X_minValue.ToOADate();
          DataPointCollection points = series.Points;
          dateTime = DateTime.Now;
          double oaDate1 = dateTime.ToOADate();
          double yValue = voltage;
          points.AddXY(oaDate1, yValue);
          Axis axisX = this.chart1.ChartAreas[0].AxisX;
          dateTime = DateTime.Now;
          dateTime = dateTime.AddSeconds(1.0);
          double oaDate2 = dateTime.ToOADate();
          axisX.Maximum = oaDate2;
          series.Points.ResumeUpdates();
          this.vol.Add(voltage);
        }
        if (series.Points.Count > 2400)
        {
          this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
          this.chart1.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Hours;
          this.chart1.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Hours;
          this.chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 1.0;
          this.chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1.0;
          series.Points.SuspendUpdates();
          this.chart1.ChartAreas[0].AxisY.Maximum = 14.0;
          this.chart1.ChartAreas[0].AxisY.Minimum = 0.0;
          this.chart1.ChartAreas[0].AxisX.Minimum = this.X_minValue.ToOADate();
          DataPointCollection points = series.Points;
          dateTime = DateTime.Now;
          double oaDate3 = dateTime.ToOADate();
          double yValue = voltage;
          points.AddXY(oaDate3, yValue);
          Axis axisX = this.chart1.ChartAreas[0].AxisX;
          dateTime = DateTime.Now;
          dateTime = dateTime.AddSeconds(1.0);
          double oaDate4 = dateTime.ToOADate();
          axisX.Maximum = oaDate4;
          series.Points.ResumeUpdates();
          this.vol.Add(voltage);
        }
      }
      if (this.checkBox1.Checked)
        return;
      if (series.Points.Count <= 30)
      {
        this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
        this.chart1.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Seconds;
        this.chart1.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Seconds;
        this.chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 15.0;
        this.chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 15.0;
        series.Points.SuspendUpdates();
        this.chart1.ChartAreas[0].AxisY.Maximum = 14.0;
        this.chart1.ChartAreas[0].AxisY.Minimum = 0.0;
        Axis axisX1 = this.chart1.ChartAreas[0].AxisX;
        dateTime = DateTime.Now;
        dateTime = dateTime.AddSeconds(-60.0);
        double oaDate5 = dateTime.ToOADate();
        axisX1.Minimum = oaDate5;
        DataPointCollection points = series.Points;
        dateTime = DateTime.Now;
        double oaDate6 = dateTime.ToOADate();
        double yValue = voltage;
        points.AddXY(oaDate6, yValue);
        Axis axisX2 = this.chart1.ChartAreas[0].AxisX;
        dateTime = DateTime.Now;
        dateTime = dateTime.AddSeconds(1.0);
        double oaDate7 = dateTime.ToOADate();
        axisX2.Maximum = oaDate7;
        series.Points.ResumeUpdates();
        this.vol.Add(voltage);
      }
      if (series.Points.Count <= 30)
        return;
      this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
      this.chart1.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
      this.chart1.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Minutes;
      this.chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 2.0;
      this.chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 2.0;
      series.Points.SuspendUpdates();
      this.chart1.ChartAreas[0].AxisY.Maximum = 14.0;
      this.chart1.ChartAreas[0].AxisY.Minimum = 0.0;
      Axis axisX3 = this.chart1.ChartAreas[0].AxisX;
      dateTime = DateTime.Now;
      dateTime = dateTime.AddSeconds(-600.0);
      double oaDate8 = dateTime.ToOADate();
      axisX3.Minimum = oaDate8;
      DataPointCollection points1 = series.Points;
      dateTime = DateTime.Now;
      double oaDate9 = dateTime.ToOADate();
      double yValue1 = voltage;
      points1.AddXY(oaDate9, yValue1);
      Axis axisX4 = this.chart1.ChartAreas[0].AxisX;
      dateTime = DateTime.Now;
      dateTime = dateTime.AddSeconds(1.0);
      double oaDate10 = dateTime.ToOADate();
      axisX4.Maximum = oaDate10;
      series.Points.ResumeUpdates();
      this.vol.Add(voltage);
    }

    private void UpdateChart2(double current)
    {
      Series series = this.chart2.Series[0];
      if (this.checkBox1.Checked)
      {
        if (series.Points.Count <= 2400)
        {
          this.chart2.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
          this.chart2.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
          this.chart2.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Minutes;
          this.chart2.ChartAreas[0].AxisX.MajorGrid.Interval = 5.0;
          this.chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 5.0;
          this.chart2.ChartAreas[0].AxisY.Maximum = 15.0;
          this.chart2.ChartAreas[0].AxisY.Minimum = 0.0;
          this.chart2.ChartAreas[0].AxisX.Minimum = this.X_minValue.ToOADate();
          series.Points.SuspendUpdates();
          series.Points.AddXY(DateTime.Now.ToOADate(), current);
          this.chart2.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddSeconds(1.0).ToOADate();
          series.Points.ResumeUpdates();
          this.cur.Add(current);
        }
        if (series.Points.Count > 2400)
        {
          this.chart2.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
          this.chart2.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Hours;
          this.chart2.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Hours;
          this.chart2.ChartAreas[0].AxisX.MajorGrid.Interval = 1.0;
          this.chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 1.0;
          this.chart2.ChartAreas[0].AxisY.Maximum = 15.0;
          this.chart2.ChartAreas[0].AxisY.Minimum = 0.0;
          this.chart2.ChartAreas[0].AxisX.Minimum = this.X_minValue.ToOADate();
          series.Points.SuspendUpdates();
          series.Points.AddXY(DateTime.Now.ToOADate(), current);
          this.chart2.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddSeconds(1.0).ToOADate();
          series.Points.ResumeUpdates();
          this.cur.Add(current);
        }
      }
      if (this.checkBox1.Checked)
        return;
      DateTime dateTime1;
      if (series.Points.Count <= 30)
      {
        this.chart2.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
        this.chart2.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Seconds;
        this.chart2.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Seconds;
        this.chart2.ChartAreas[0].AxisX.MajorGrid.Interval = 15.0;
        this.chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 15.0;
        series.Points.SuspendUpdates();
        this.chart2.ChartAreas[0].AxisY.Maximum = 15.0;
        this.chart2.ChartAreas[0].AxisY.Minimum = 0.0;
        Axis axisX1 = this.chart2.ChartAreas[0].AxisX;
        DateTime dateTime2 = DateTime.Now;
        dateTime2 = dateTime2.AddSeconds(-60.0);
        double oaDate1 = dateTime2.ToOADate();
        axisX1.Minimum = oaDate1;
        DataPointCollection points = series.Points;
        dateTime2 = DateTime.Now;
        double oaDate2 = dateTime2.ToOADate();
        double yValue = current;
        points.AddXY(oaDate2, yValue);
        Axis axisX2 = this.chart2.ChartAreas[0].AxisX;
        dateTime1 = DateTime.Now.AddSeconds(1.0);
        double oaDate3 = dateTime1.ToOADate();
        axisX2.Maximum = oaDate3;
        series.Points.ResumeUpdates();
        this.cur.Add(current);
      }
      if (series.Points.Count <= 30)
        return;
      this.chart2.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
      this.chart2.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
      this.chart2.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Minutes;
      this.chart2.ChartAreas[0].AxisX.MajorGrid.Interval = 2.0;
      this.chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 2.0;
      series.Points.SuspendUpdates();
      this.chart2.ChartAreas[0].AxisY.Maximum = 15.0;
      this.chart2.ChartAreas[0].AxisY.Minimum = 0.0;
      Axis axisX3 = this.chart2.ChartAreas[0].AxisX;
      dateTime1 = DateTime.Now;
      dateTime1 = dateTime1.AddSeconds(-600.0);
      double oaDate4 = dateTime1.ToOADate();
      axisX3.Minimum = oaDate4;
      DataPointCollection points1 = series.Points;
      dateTime1 = DateTime.Now;
      double oaDate5 = dateTime1.ToOADate();
      double yValue1 = current;
      points1.AddXY(oaDate5, yValue1);
      Axis axisX4 = this.chart2.ChartAreas[0].AxisX;
      dateTime1 = DateTime.Now;
      dateTime1 = dateTime1.AddSeconds(1.0);
      double oaDate6 = dateTime1.ToOADate();
      axisX4.Maximum = oaDate6;
      series.Points.ResumeUpdates();
      this.cur.Add(current);
    }

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == 274 && (int) m.WParam == 61536)
        return;
      base.WndProc(ref m);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.chart1.Series[0].Points.Clear();
      this.chart2.Series[0].Points.Clear();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ChartArea chartArea1 = new ChartArea();
      Legend legend1 = new Legend();
      Series series1 = new Series();
      ChartArea chartArea2 = new ChartArea();
      Legend legend2 = new Legend();
      Series series2 = new Series();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (PlusV2Monitor));
      this.chart2 = new Chart();
      this.label1 = new Label();
      this.chart1 = new Chart();
      this.pictureBox1 = new PictureBox();
      this.checkBox1 = new CheckBox();
      this.button1 = new Button();
      this.chart2.BeginInit();
      this.chart1.BeginInit();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.chart2.BackColor = Color.Black;
      chartArea1.AxisX.InterlacedColor = Color.White;
      chartArea1.AxisX.LabelStyle.ForeColor = Color.White;
      chartArea1.AxisX.LineColor = Color.White;
      chartArea1.AxisX.MajorGrid.LineColor = Color.White;
      chartArea1.AxisX.MajorTickMark.LineColor = Color.White;
      chartArea1.AxisX.MinorGrid.LineColor = Color.White;
      chartArea1.AxisX.TitleForeColor = Color.White;
      chartArea1.AxisY.LabelStyle.ForeColor = Color.White;
      chartArea1.AxisY.LineColor = Color.White;
      chartArea1.AxisY.MajorGrid.LineColor = Color.White;
      chartArea1.AxisY.MajorTickMark.LineColor = Color.White;
      chartArea1.AxisY.ScaleBreakStyle.LineColor = Color.White;
      chartArea1.AxisY.TitleForeColor = Color.Transparent;
      chartArea1.BackColor = Color.Black;
      chartArea1.BackSecondaryColor = Color.White;
      chartArea1.Name = "ChartArea1";
      this.chart2.ChartAreas.Add(chartArea1);
      legend1.Alignment = StringAlignment.Center;
      legend1.BackColor = Color.Black;
      legend1.ForeColor = Color.White;
      legend1.Name = "Legend1";
      legend1.TitleBackColor = Color.Black;
      this.chart2.Legends.Add(legend1);
      this.chart2.Location = new Point(856, 195);
      this.chart2.Margin = new Padding(8, 11, 8, 11);
      this.chart2.Name = "chart2";
      series1.BackGradientStyle = GradientStyle.TopBottom;
      series1.BorderColor = Color.White;
      series1.BorderWidth = 5;
      series1.ChartArea = "ChartArea1";
      series1.ChartType = SeriesChartType.Area;
      series1.Color = Color.OrangeRed;
      series1.Legend = "Legend1";
      series1.Name = "Current (A)";
      this.chart2.Series.Add(series1);
      this.chart2.Size = new Size(797, 422);
      this.chart2.TabIndex = 11;
      this.chart2.Text = "chart2";
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Maroon;
      this.label1.Font = new Font("微软雅黑", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.label1.ForeColor = SystemColors.ControlLightLight;
      this.label1.Location = new Point(411, 66);
      this.label1.Margin = new Padding(8, 0, 8, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(782, 45);
      this.label1.TabIndex = 10;
      this.label1.Text = "Voltage:12.00V   Current:5.00A   Power:60.00W";
      this.label1.TextAlign = ContentAlignment.MiddleCenter;
      this.chart1.BackColor = Color.Black;
      chartArea2.AxisX.InterlacedColor = Color.White;
      chartArea2.AxisX.LabelStyle.ForeColor = Color.White;
      chartArea2.AxisX.LineColor = Color.White;
      chartArea2.AxisX.MajorGrid.LineColor = Color.White;
      chartArea2.AxisX.MajorTickMark.LineColor = Color.White;
      chartArea2.AxisX.MinorGrid.LineColor = Color.White;
      chartArea2.AxisX.TitleForeColor = Color.White;
      chartArea2.AxisY.LabelStyle.ForeColor = Color.White;
      chartArea2.AxisY.LineColor = Color.White;
      chartArea2.AxisY.MajorGrid.LineColor = Color.White;
      chartArea2.AxisY.MajorTickMark.LineColor = Color.White;
      chartArea2.AxisY.ScaleBreakStyle.LineColor = Color.White;
      chartArea2.AxisY.TitleForeColor = Color.Transparent;
      chartArea2.BackColor = Color.Black;
      chartArea2.BackSecondaryColor = Color.White;
      chartArea2.Name = "ChartArea1";
      this.chart1.ChartAreas.Add(chartArea2);
      legend2.Alignment = StringAlignment.Center;
      legend2.BackColor = Color.Black;
      legend2.ForeColor = Color.White;
      legend2.Name = "Legend1";
      legend2.TitleBackColor = Color.Black;
      this.chart1.Legends.Add(legend2);
      this.chart1.Location = new Point(53, 195);
      this.chart1.Margin = new Padding(8, 11, 8, 11);
      this.chart1.Name = "chart1";
      series2.BackGradientStyle = GradientStyle.TopBottom;
      series2.BorderColor = Color.White;
      series2.BorderWidth = 5;
      series2.ChartArea = "ChartArea1";
      series2.ChartType = SeriesChartType.Area;
      series2.Color = Color.RoyalBlue;
      series2.Legend = "Legend1";
      series2.Name = "Voltage (V)";
      this.chart1.Series.Add(series2);
      this.chart1.Size = new Size(777, 422);
      this.chart1.TabIndex = 9;
      this.chart1.Text = "chart1";
      this.pictureBox1.BackColor = Color.Maroon;
      this.pictureBox1.Location = new Point(-53, -8);
      this.pictureBox1.Margin = new Padding(8, 8, 8, 8);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(2565, 195);
      this.pictureBox1.TabIndex = 12;
      this.pictureBox1.TabStop = false;
      this.checkBox1.AutoSize = true;
      this.checkBox1.Font = new Font("小米兰亭", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.checkBox1.ForeColor = Color.White;
      this.checkBox1.Location = new Point(596, 662);
      this.checkBox1.Margin = new Padding(8, 11, 8, 11);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(180, 37);
      this.checkBox1.TabIndex = 13;
      this.checkBox1.Text = "History data";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.button1.BackColor = Color.Maroon;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.ForeColor = SystemColors.ButtonHighlight;
      this.button1.Location = new Point(816, 656);
      this.button1.Name = "button1";
      this.button1.Size = new Size(132, 43);
      this.button1.TabIndex = 14;
      this.button1.Text = "Clear data";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(168f, 168f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.AutoSize = true;
      this.BackColor = SystemColors.ActiveCaptionText;
      this.ClientSize = new Size(1649, 744);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.chart2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.chart1);
      this.Controls.Add((Control) this.pictureBox1);
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      //this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(8, 8, 8, 8);
      this.Name = nameof (PlusV2Monitor);
      this.Text = "WandererBox Plus V2 Monitor";
      this.Load += new EventHandler(this.PlusV2Monitor_Load);
      this.chart2.EndInit();
      this.chart1.EndInit();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
