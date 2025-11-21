// Decompiled with JetBrains decompiler
// Type: ASCOM.WandererBoxes.UltimateV2Monitor
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
    public class UltimateV2Monitor : Form
    {
        private DateTime X_minValue;
        private readonly List<double> vol;
        private readonly List<double> cur;
        private IContainer components;
        private Chart chart1;
        private CheckBox checkBox1;
        private Label label1;
        private Chart chart2;
        private Chart chart3;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Chart chart4;
        private Button button1;

        public UltimateV2Monitor()
        {
            this.Load += new EventHandler(this.UltimateV2Monitor_Load);
            this.vol = new List<double>();
            this.cur = new List<double>();
            this.InitializeComponent();
        }

        private void UltimateV2Monitor_Load(object sender, EventArgs e)
        {
            Switch.i = 0;
            Timer timer = new Timer();
            timer.Tick += new EventHandler(this.OnTimedEvent);
            timer.Interval = 1000;
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
            this.chart3.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            this.chart3.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Seconds;
            this.chart3.ChartAreas[0].AxisX.MajorGrid.Interval = 4.0;
            this.chart3.ChartAreas[0].AxisX.LabelStyle.Interval = 4.0;
            this.chart3.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Seconds;
            this.chart3.ChartAreas[0].AxisX.Maximum = DateTime.Now.ToOADate();
            this.chart3.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
            this.chart4.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            this.chart4.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Seconds;
            this.chart4.ChartAreas[0].AxisX.MajorGrid.Interval = 4.0;
            this.chart4.ChartAreas[0].AxisX.LabelStyle.Interval = 4.0;
            this.chart4.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Seconds;
            this.chart4.ChartAreas[0].AxisX.Maximum = DateTime.Now.ToOADate();
            this.chart4.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
        }

        private void OnTimedEvent(object source, EventArgs e)
        {
            this.UpdateChart(Switch.voltage);
            this.UpdateChart2(Switch.current);
            this.label1.Text =
                $"Voltage:{Switch.voltage.ToString()}V   Current:{Switch.current.ToString()}A   Power:{(Switch.voltage * Switch.current).ToString("0.##")}W";
            if (Switch.DHTTstate && Switch.Sensortype == "DHT22")
            {
                this.label2.Text = $"Temperature:{Switch.DHTT.ToString()}℃ from DHT22 sensor";
                this.UpdateChart3(Switch.DHTT);
            }

            if (Switch.DSTstate && Switch.Sensortype == "DS18B20")
            {
                this.label2.Text = $"Temperature:{Switch.DST.ToString()}℃ from DS18B20 probe";
                this.UpdateChart3(Switch.DST);
            }

            if (Switch.DHTHstate && Switch.Sensortype == "DHT22")
            {
                this.label3.Text = $"Humidity:{Switch.DHTH.ToString()}% from DHT22 sensor";
                this.UpdateChart4(Switch.DHTH);
            }

            if (Switch.DHTTstate || Switch.DSTstate)
                return;
            this.label2.Text = this.label3.Text = "No sensor or wrong sensor selected";
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
                    this.chart2.ChartAreas[0].AxisY.Maximum = (double)((int)current + 3);
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
                    this.chart2.ChartAreas[0].AxisY.Maximum = (double)((int)current + 3);
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
                this.chart2.ChartAreas[0].AxisY.Maximum = (double)((int)current + 3);
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
            this.chart2.ChartAreas[0].AxisY.Maximum = (double)((int)current + 3);
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

        private void UpdateChart3(double temperature)
        {
            Series series = this.chart3.Series[0];
            if (this.checkBox1.Checked)
            {
                if (series.Points.Count <= 2400)
                {
                    this.chart3.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
                    this.chart3.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
                    this.chart3.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Minutes;
                    this.chart3.ChartAreas[0].AxisX.MajorGrid.Interval = 5.0;
                    this.chart3.ChartAreas[0].AxisX.LabelStyle.Interval = 5.0;
                    this.chart3.ChartAreas[0].AxisY.Maximum = (double)((int)(temperature / 10.0) * 10 + 15);
                    this.chart3.ChartAreas[0].AxisY.Minimum = (double)((int)(temperature / 10.0) * 10 - 5);
                    this.chart3.ChartAreas[0].AxisX.Minimum = this.X_minValue.ToOADate();
                    series.Points.SuspendUpdates();
                    series.Points.AddXY(DateTime.Now.ToOADate(), temperature);
                    this.chart3.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddSeconds(1.0).ToOADate();
                    series.Points.ResumeUpdates();
                    this.cur.Add(temperature);
                }

                if (series.Points.Count > 2400)
                {
                    this.chart3.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
                    this.chart3.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Hours;
                    this.chart3.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Hours;
                    this.chart3.ChartAreas[0].AxisX.MajorGrid.Interval = 1.0;
                    this.chart3.ChartAreas[0].AxisX.LabelStyle.Interval = 1.0;
                    this.chart3.ChartAreas[0].AxisY.Maximum = (double)((int)(temperature / 10.0) * 10 + 15);
                    this.chart3.ChartAreas[0].AxisY.Minimum = (double)((int)(temperature / 10.0) * 10 - 5);
                    this.chart3.ChartAreas[0].AxisX.Minimum = this.X_minValue.ToOADate();
                    series.Points.SuspendUpdates();
                    series.Points.AddXY(DateTime.Now.ToOADate(), temperature);
                    this.chart3.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddSeconds(1.0).ToOADate();
                    series.Points.ResumeUpdates();
                    this.cur.Add(temperature);
                }
            }

            if (this.checkBox1.Checked)
                return;
            DateTime dateTime1;
            if (series.Points.Count <= 30)
            {
                this.chart3.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
                this.chart3.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Seconds;
                this.chart3.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Seconds;
                this.chart3.ChartAreas[0].AxisX.MajorGrid.Interval = 15.0;
                this.chart3.ChartAreas[0].AxisX.LabelStyle.Interval = 15.0;
                series.Points.SuspendUpdates();
                this.chart3.ChartAreas[0].AxisY.Maximum = (double)((int)(temperature / 10.0) * 10 + 15);
                this.chart3.ChartAreas[0].AxisY.Minimum = (double)((int)(temperature / 10.0) * 10 - 5);
                Axis axisX1 = this.chart3.ChartAreas[0].AxisX;
                DateTime dateTime2 = DateTime.Now.AddSeconds(-60.0);
                double oaDate1 = dateTime2.ToOADate();
                axisX1.Minimum = oaDate1;
                DataPointCollection points = series.Points;
                dateTime2 = DateTime.Now;
                double oaDate2 = dateTime2.ToOADate();
                double yValue = temperature;
                points.AddXY(oaDate2, yValue);
                Axis axisX2 = this.chart3.ChartAreas[0].AxisX;
                dateTime1 = DateTime.Now.AddSeconds(1.0);
                double oaDate3 = dateTime1.ToOADate();
                axisX2.Maximum = oaDate3;
                series.Points.ResumeUpdates();
                this.cur.Add(temperature);
            }

            if (series.Points.Count <= 30)
                return;
            this.chart3.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            this.chart3.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
            this.chart3.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Minutes;
            this.chart3.ChartAreas[0].AxisX.MajorGrid.Interval = 2.0;
            this.chart3.ChartAreas[0].AxisX.LabelStyle.Interval = 2.0;
            series.Points.SuspendUpdates();
            this.chart3.ChartAreas[0].AxisY.Maximum = (double)((int)(temperature / 10.0) * 10 + 15);
            this.chart3.ChartAreas[0].AxisY.Minimum = (double)((int)(temperature / 10.0) * 10 - 5);
            Axis axisX3 = this.chart3.ChartAreas[0].AxisX;
            dateTime1 = DateTime.Now;
            dateTime1 = dateTime1.AddSeconds(-600.0);
            double oaDate4 = dateTime1.ToOADate();
            axisX3.Minimum = oaDate4;
            DataPointCollection points1 = series.Points;
            dateTime1 = DateTime.Now;
            double oaDate5 = dateTime1.ToOADate();
            double yValue1 = temperature;
            points1.AddXY(oaDate5, yValue1);
            Axis axisX4 = this.chart3.ChartAreas[0].AxisX;
            dateTime1 = DateTime.Now;
            dateTime1 = dateTime1.AddSeconds(1.0);
            double oaDate6 = dateTime1.ToOADate();
            axisX4.Maximum = oaDate6;
            series.Points.ResumeUpdates();
            this.cur.Add(temperature);
        }

        private void UpdateChart4(double humidity)
        {
            Series series = this.chart4.Series[0];
            this.chart4.ChartAreas[0].AxisY.Minimum = 0.0;
            if (humidity <= 0.0)
                this.chart4.ChartAreas[0].AxisY.Minimum = -30.0;
            if (this.checkBox1.Checked)
            {
                if (series.Points.Count <= 21000)
                {
                    this.chart4.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
                    this.chart4.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
                    this.chart4.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Minutes;
                    this.chart4.ChartAreas[0].AxisX.MajorGrid.Interval = 5.0;
                    this.chart4.ChartAreas[0].AxisX.LabelStyle.Interval = 5.0;
                    this.chart4.ChartAreas[0].AxisY.Maximum = 100.0;
                    this.chart4.ChartAreas[0].AxisX.Minimum = this.X_minValue.ToOADate();
                    series.Points.SuspendUpdates();
                    series.Points.AddXY(DateTime.Now.ToOADate(), humidity);
                    Axis axisX = this.chart4.ChartAreas[0].AxisX;
                    DateTime dateTime = DateTime.Now;
                    dateTime = dateTime.AddSeconds(1.0);
                    double oaDate = dateTime.ToOADate();
                    axisX.Maximum = oaDate;
                    series.Points.ResumeUpdates();
                    this.cur.Add(humidity);
                }

                if (series.Points.Count > 21000)
                {
                    this.chart4.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
                    this.chart4.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Hours;
                    this.chart4.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Hours;
                    this.chart4.ChartAreas[0].AxisX.MajorGrid.Interval = 1.0;
                    this.chart4.ChartAreas[0].AxisX.LabelStyle.Interval = 1.0;
                    this.chart4.ChartAreas[0].AxisY.Maximum = 100.0;
                    this.chart4.ChartAreas[0].AxisX.Minimum = this.X_minValue.ToOADate();
                    series.Points.SuspendUpdates();
                    series.Points.AddXY(DateTime.Now.ToOADate(), humidity);
                    Axis axisX = this.chart4.ChartAreas[0].AxisX;
                    DateTime dateTime = DateTime.Now;
                    dateTime = dateTime.AddSeconds(1.0);
                    double oaDate = dateTime.ToOADate();
                    axisX.Maximum = oaDate;
                    series.Points.ResumeUpdates();
                    this.cur.Add(humidity);
                }
            }

            if (this.checkBox1.Checked)
                return;
            if (series.Points.Count <= 30)
            {
                this.chart4.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
                this.chart4.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Seconds;
                this.chart4.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Seconds;
                this.chart4.ChartAreas[0].AxisX.MajorGrid.Interval = 15.0;
                this.chart4.ChartAreas[0].AxisX.LabelStyle.Interval = 15.0;
                series.Points.SuspendUpdates();
                this.chart4.ChartAreas[0].AxisY.Maximum = 100.0;
                this.chart4.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddSeconds(-60.0).ToOADate();
                series.Points.AddXY(DateTime.Now.ToOADate(), humidity);
                Axis axisX = this.chart4.ChartAreas[0].AxisX;
                DateTime dateTime = DateTime.Now;
                dateTime = dateTime.AddSeconds(1.0);
                double oaDate = dateTime.ToOADate();
                axisX.Maximum = oaDate;
                series.Points.ResumeUpdates();
                this.cur.Add(humidity);
            }

            if (series.Points.Count <= 30)
                return;
            this.chart4.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            this.chart4.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
            this.chart4.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Minutes;
            this.chart4.ChartAreas[0].AxisX.MajorGrid.Interval = 2.0;
            this.chart4.ChartAreas[0].AxisX.LabelStyle.Interval = 2.0;
            series.Points.SuspendUpdates();
            this.chart4.ChartAreas[0].AxisY.Maximum = 100.0;
            this.chart4.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddSeconds(-600.0).ToOADate();
            series.Points.AddXY(DateTime.Now.ToOADate(), humidity);
            Axis axisX1 = this.chart4.ChartAreas[0].AxisX;
            DateTime dateTime1 = DateTime.Now;
            dateTime1 = dateTime1.AddSeconds(1.0);
            double oaDate1 = dateTime1.ToOADate();
            axisX1.Maximum = oaDate1;
            series.Points.ResumeUpdates();
            this.cur.Add(humidity);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 274 && (int)m.WParam == 61536)
                return;
            base.WndProc(ref m);
        }

        private void chart2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            this.chart2.Series[0].Points.Clear();
            this.chart3.Series[0].Points.Clear();
            this.chart4.Series[0].Points.Clear();
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
            ChartArea chartArea3 = new ChartArea();
            Legend legend3 = new Legend();
            Series series3 = new Series();
            ChartArea chartArea4 = new ChartArea();
            Legend legend4 = new Legend();
            Series series4 = new Series();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UltimateV2Monitor));
            this.chart1 = new Chart();
            this.checkBox1 = new CheckBox();
            this.label1 = new Label();
            this.chart2 = new Chart();
            this.chart3 = new Chart();
            this.label2 = new Label();
            this.label3 = new Label();
            this.pictureBox1 = new PictureBox();
            this.pictureBox2 = new PictureBox();
            this.chart4 = new Chart();
            this.button1 = new Button();
            this.chart1.BeginInit();
            this.chart2.BeginInit();
            this.chart3.BeginInit();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            ((ISupportInitialize)this.pictureBox2).BeginInit();
            this.chart4.BeginInit();
            this.SuspendLayout();
            this.chart1.BackColor = Color.Black;
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
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Alignment = StringAlignment.Center;
            legend1.BackColor = Color.Black;
            legend1.ForeColor = Color.White;
            legend1.Name = "Legend1";
            legend1.TitleBackColor = Color.Black;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new Point(-19, 81);
            this.chart1.Margin = new Padding(3, 5, 3, 5);
            this.chart1.Name = "chart1";
            series1.BackGradientStyle = GradientStyle.TopBottom;
            series1.BorderColor = Color.White;
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = SeriesChartType.Area;
            series1.Color = Color.RoyalBlue;
            series1.Legend = "Legend1";
            series1.Name = "Voltage (V)";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new Size(864, 329);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new Font("小米兰亭", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.checkBox1.ForeColor = Color.White;
            this.checkBox1.Location = new Point(1243, 932);
            this.checkBox1.Margin = new Padding(3, 5, 3, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(154, 32 /*0x20*/);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "History data";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Maroon;
            this.label1.Font = new Font("微软雅黑", 10.71429f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.label1.ForeColor = SystemColors.ControlLightLight;
            this.label1.Location = new Point(455, 11);
            this.label1.Name = "label1";
            this.label1.Size = new Size(504, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Voltage:12.00V   Current:5.00A   Power:60.00W";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.Click += new EventHandler(this.label1_Click);
            this.chart2.BackColor = Color.Black;
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
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Alignment = StringAlignment.Center;
            legend2.BackColor = Color.Black;
            legend2.ForeColor = Color.White;
            legend2.Name = "Legend1";
            legend2.TitleBackColor = Color.Black;
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new Point(798, 81);
            this.chart2.Margin = new Padding(3, 5, 3, 5);
            this.chart2.Name = "chart2";
            series2.BackGradientStyle = GradientStyle.TopBottom;
            series2.BorderColor = Color.White;
            series2.BorderWidth = 5;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = SeriesChartType.Area;
            series2.Color = Color.OrangeRed;
            series2.Legend = "Legend1";
            series2.Name = "Current (A)";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new Size(846, 324);
            this.chart2.TabIndex = 3;
            this.chart2.Text = "chart2";
            this.chart2.Click += new EventHandler(this.chart2_Click);
            this.chart3.BackColor = Color.Black;
            chartArea3.AxisX.InterlacedColor = Color.White;
            chartArea3.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea3.AxisX.LineColor = Color.White;
            chartArea3.AxisX.MajorGrid.LineColor = Color.White;
            chartArea3.AxisX.MajorTickMark.LineColor = Color.White;
            chartArea3.AxisX.MinorGrid.LineColor = Color.White;
            chartArea3.AxisX.TitleForeColor = Color.White;
            chartArea3.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea3.AxisY.LineColor = Color.White;
            chartArea3.AxisY.MajorGrid.LineColor = Color.White;
            chartArea3.AxisY.MajorTickMark.LineColor = Color.White;
            chartArea3.AxisY.ScaleBreakStyle.LineColor = Color.White;
            chartArea3.AxisY.TitleForeColor = Color.Transparent;
            chartArea3.BackColor = Color.Black;
            chartArea3.BackSecondaryColor = Color.White;
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Alignment = StringAlignment.Center;
            legend3.BackColor = Color.Black;
            legend3.ForeColor = Color.White;
            legend3.Name = "Legend1";
            legend3.TitleBackColor = Color.Black;
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new Point(-19, 501);
            this.chart3.Margin = new Padding(3, 5, 3, 5);
            this.chart3.Name = "chart3";
            series3.BackGradientStyle = GradientStyle.TopBottom;
            series3.BorderColor = Color.White;
            series3.BorderWidth = 5;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = SeriesChartType.Area;
            series3.Color = Color.IndianRed;
            series3.Legend = "Legend1";
            series3.Name = "Temp (℃)";
            this.chart3.Series.Add(series3);
            this.chart3.Size = new Size(864, 421);
            this.chart3.TabIndex = 4;
            this.chart3.Text = "chart3";
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Maroon;
            this.label2.Font = new Font("微软雅黑", 10.71429f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.label2.ForeColor = SystemColors.ControlLightLight;
            this.label2.Location = new Point(42, 431);
            this.label2.Name = "label2";
            this.label2.Size = new Size(390, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "No sensor or wrong sensor selected";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.label3.AutoSize = true;
            this.label3.BackColor = Color.Maroon;
            this.label3.Font = new Font("微软雅黑", 10.71429f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.label3.ForeColor = SystemColors.ControlLightLight;
            this.label3.Location = new Point(831, 431);
            this.label3.Name = "label3";
            this.label3.Size = new Size(390, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "No sensor or wrong sensor selected";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;
            this.pictureBox1.BackColor = Color.Maroon;
            this.pictureBox1.Location = new Point(-13, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(1683, 84);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox2.BackColor = Color.Maroon;
            this.pictureBox2.Location = new Point(-13, 408);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(1638, 84);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.chart4.BackColor = Color.Black;
            chartArea4.AxisX.InterlacedColor = Color.White;
            chartArea4.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea4.AxisX.LineColor = Color.White;
            chartArea4.AxisX.MajorGrid.LineColor = Color.White;
            chartArea4.AxisX.MajorTickMark.LineColor = Color.White;
            chartArea4.AxisX.MinorGrid.LineColor = Color.White;
            chartArea4.AxisX.TitleForeColor = Color.White;
            chartArea4.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea4.AxisY.LineColor = Color.White;
            chartArea4.AxisY.MajorGrid.LineColor = Color.White;
            chartArea4.AxisY.MajorTickMark.LineColor = Color.White;
            chartArea4.AxisY.ScaleBreakStyle.LineColor = Color.White;
            chartArea4.AxisY.TitleForeColor = Color.Transparent;
            chartArea4.BackColor = Color.Black;
            chartArea4.BackSecondaryColor = Color.White;
            chartArea4.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea4);
            legend4.Alignment = StringAlignment.Center;
            legend4.BackColor = Color.Black;
            legend4.ForeColor = Color.White;
            legend4.Name = "Legend1";
            legend4.TitleBackColor = Color.Black;
            this.chart4.Legends.Add(legend4);
            this.chart4.Location = new Point(798, 501);
            this.chart4.Margin = new Padding(3, 5, 3, 5);
            this.chart4.Name = "chart4";
            series4.BackGradientStyle = GradientStyle.TopBottom;
            series4.BorderColor = Color.White;
            series4.BorderWidth = 5;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = SeriesChartType.Area;
            series4.Color = Color.MediumTurquoise;
            series4.Legend = "Legend1";
            series4.Name = "Humidity（%）";
            this.chart4.Series.Add(series4);
            this.chart4.Size = new Size(859, 421);
            this.chart4.TabIndex = 5;
            this.chart4.Text = "chart4";
            this.button1.BackColor = Color.Maroon;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.ForeColor = SystemColors.ButtonFace;
            this.button1.Location = new Point(1426, 927);
            this.button1.Name = "button1";
            this.button1.Size = new Size(110, 37);
            this.button1.TabIndex = 10;
            this.button1.Text = "Clear data";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.AutoScaleDimensions = new SizeF(144f, 144f);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = SystemColors.ActiveCaptionText;
            this.ClientSize = new Size(1602, 977);
            this.Controls.Add((Control)this.button1);
            this.Controls.Add((Control)this.label3);
            this.Controls.Add((Control)this.label2);
            this.Controls.Add((Control)this.chart4);
            this.Controls.Add((Control)this.chart3);
            this.Controls.Add((Control)this.chart2);
            this.Controls.Add((Control)this.label1);
            this.Controls.Add((Control)this.checkBox1);
            this.Controls.Add((Control)this.chart1);
            this.Controls.Add((Control)this.pictureBox1);
            this.Controls.Add((Control)this.pictureBox2);
            this.Font = new Font("小米兰亭", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.Margin = new Padding(3, 5, 3, 5);
            this.Name = nameof(UltimateV2Monitor);
            this.Text = "WandererBox Ultimate V2 Monitor";
            this.Load += new EventHandler(this.UltimateV2Monitor_Load);
            this.chart1.EndInit();
            this.chart2.EndInit();
            this.chart3.EndInit();
            ((ISupportInitialize)this.pictureBox1).EndInit();
            ((ISupportInitialize)this.pictureBox2).EndInit();
            this.chart4.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}