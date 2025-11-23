using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.AxisLimitManagers;
using ScottPlot.Plottables;
using ScottPlot.TickGenerators;
using ScottPlot.WinForms;
using Label = System.Windows.Forms.Label;
using WinFormsColor = System.Drawing.Color;
using ScottColor = ScottPlot.Color;

namespace ASCOM.WandererBoxes
{
    public partial class UltimateV2Monitor2 : Form
    {
        private DateTime startTime;

        private DataLogger vloLog = new DataLogger();
        private DataLogger currLog = new DataLogger();
        private DataLogger tempLog = new DataLogger();
        private DataLogger humLog = new DataLogger();

        private IContainer components;
        private FormsPlot voltagePlot;
        private FormsPlot currentPlot;
        private FormsPlot temperaturePlot;
        private FormsPlot humidityPlot;
        private CheckBox checkBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button1;

        public UltimateV2Monitor2()
        {
            Load += UltimateV2Monitor_Load;
            InitializeComponent();
        }

        private void UltimateV2Monitor_Load(object sender, EventArgs e)
        {
            Switch.i = 0;

            startTime = DateTime.Now;

            // Initialize plots
            InitializeVoltagePlot();
            InitializeCurrentPlot();
            InitializeTemperaturePlot();
            InitializeHumidityPlot();
        }

        private double GetElapsedSeconds() => (DateTime.Now - startTime).TotalSeconds;

        private void StylePlot(FormsPlot plot)
        {
            plot.Plot.FigureBackground.Color = ScottColor.FromHex("#100000");
            plot.Plot.DataBackground.Color = ScottColor.FromHex("#000000");

            var axes = plot.Plot.Axes;
            plot.Plot.Axes.Bottom.TickGenerator = new NumericAutomatic { TickDensity = 2 };

            var bottomAxis = plot.Plot.Axes.Bottom;
            bottomAxis.Label.Text = "Time (s)";
            plot.Plot.Axes.DateTimeTicksBottom();

            plot.Plot.RenderManager.RenderStarting += (s, e) =>
            {
                Tick[] ticks = plot.Plot.Axes.Bottom.TickGenerator.Ticks;
                for (int i = 0; i < ticks.Length; i++)
                {
                    DateTime dt = DateTime.FromOADate(ticks[i].Position);
                    string label = $"{dt:HH}:{dt:mm}:{dt:ss}";
                    ticks[i] = new Tick(ticks[i].Position, label);
                }
            };

            plot.Plot.Axes.Left.TickGenerator = new NumericAutomatic { TickDensity = 1 };

            plot.Plot.Title(false);
            plot.Plot.Axes.Bottom.Label.IsVisible = false;
            plot.Plot.Axes.Left.Label.IsVisible = false;

            // ИСПРАВЛЕНИЕ #2: Убираем паддинг внизу графиков
            plot.Plot.Axes.Margins(bottom: 0, top: 0, left: 0.0, right: 0.0);

            plot.Plot.Axes.AutoScale();

            plot.Plot.ScaleFactor = 1.2;

            axes.Bottom.TickLabelStyle.ForeColor = ScottColor.FromHex("#FFFFFF");
            axes.Left.TickLabelStyle.ForeColor = ScottColor.FromHex("#FFFFFF");
            axes.Bottom.TickLabelStyle.FontSize = 25f;
            axes.Left.TickLabelStyle.FontSize = 25f;

            axes.Bottom.MajorTickStyle.Color = ScottColor.FromHex("#FFFFFF");
            axes.Left.MajorTickStyle.Color = ScottColor.FromHex("#FFFFFF");

            axes.Bottom.MinorTickStyle.Color = ScottColor.FromHex("#FFFFFF");
            axes.Left.MinorTickStyle.Color = ScottColor.FromHex("#FFFFFF");

            axes.Bottom.FrameLineStyle.Color = ScottColor.FromHex("#FFFFFF");
            axes.Left.FrameLineStyle.Color = ScottColor.FromHex("#FFFFFF");

            plot.Plot.Grid.MajorLineColor = ScottColor.FromHex("#333333");
        }
        
        private void InitializeVoltagePlot()
        {
            voltagePlot.Plot.Clear();

            voltagePlot.Plot.Title("Voltage (V)");
            voltagePlot.Plot.Axes.Bottom.Label.Text = "Time";
            voltagePlot.Plot.Axes.Left.Label.Text = "Voltage (V)";

            vloLog = voltagePlot.Plot.Add.DataLogger();
            vloLog.LegendText = "Voltage (V)";
            vloLog.LineWidth = 5;
            vloLog.MarkerSize = 0;

            StylePlot(voltagePlot);
            voltagePlot.Plot.Axes.Bottom.Label.IsVisible = true;

            // Устанавливаем начальный режим отображения (последняя минута)
            UpdateDataLoggerView(vloLog, voltagePlot, false);
        }

        private void InitializeCurrentPlot()
        {
            currentPlot.Plot.Clear();

            currentPlot.Plot.Title("Current (A)");
            currentPlot.Plot.Axes.Bottom.Label.Text = "Time";
            currentPlot.Plot.Axes.Left.Label.Text = "Current (A)";
            currentPlot.Plot.Axes.Left.Min = 0;
            currLog = currentPlot.Plot.Add.DataLogger();

            currLog.LegendText = "Current (A)";
            currLog.LineWidth = 5;
            currLog.MarkerSize = 0;

            StylePlot(currentPlot);

            // Устанавливаем начальный режим отображения (последняя минута)
            UpdateDataLoggerView(currLog, currentPlot, false);
        }

        private void InitializeTemperaturePlot()
        {
            temperaturePlot.Plot.Clear();

            temperaturePlot.Plot.Title("Temperature (℃)");
            temperaturePlot.Plot.Axes.Bottom.Label.Text = "Time";
            temperaturePlot.Plot.Axes.Left.Label.Text = "Temp (℃)";
            tempLog = temperaturePlot.Plot.Add.DataLogger();

            tempLog.LegendText = "Temp (℃)";
            tempLog.LineWidth = 5;
            tempLog.MarkerSize = 0;

            StylePlot(temperaturePlot);

            // Устанавливаем начальный режим отображения (последняя минута)
            UpdateDataLoggerView(tempLog, temperaturePlot, false);
        }

        private void InitializeHumidityPlot()
        {
            humidityPlot.Plot.Clear();

            humidityPlot.Plot.Title("Humidity (%)");
            humidityPlot.Plot.Axes.Bottom.Label.Text = "Time";
            humidityPlot.Plot.Axes.Left.Label.Text = "Humidity (%)";
            humidityPlot.Plot.Axes.Left.Min = 0;
            humidityPlot.Plot.Axes.Left.Max = 100;

            humLog = humidityPlot.Plot.Add.DataLogger();

            humLog.LegendText = "Humidity (%)";
            humLog.LineWidth = 5;
            humLog.MarkerSize = 0;
            humLog.ViewFull();

            StylePlot(humidityPlot);
        }

        // ИСПРАВЛЕНИЕ #1: Метод для управления отображением по времени
        private void UpdateDataLoggerView(DataLogger logger, FormsPlot plot, bool showAll)
        {
            double oneMinuteInOADate = 60f*5 / (24 * 60 * 60);
            var w = oneMinuteInOADate;


            if (showAll)
            {
                var slideManager = new Full();
                logger.AxisManager = slideManager;
            }
            else
            {
                var slideManager = new Slide
                {
                    Width = w,
                    PaddingFractionX = 0,
                    PaddingFractionY = 0.5
                };
                logger.AxisManager = slideManager;
            }
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool showAllHistory = checkBox1.Checked;
            UpdateDataLoggerView(vloLog, voltagePlot, showAllHistory);
            UpdateDataLoggerView(currLog, currentPlot, showAllHistory);
            UpdateDataLoggerView(tempLog, temperaturePlot, showAllHistory);
           // UpdateDataLoggerView(humLog, humidityPlot, showAllHistory);

            // Обновляем графики
            voltagePlot.Refresh();
            currentPlot.Refresh();
            temperaturePlot.Refresh();
          //  humidityPlot.Refresh();
        }
        
        public void OnTimedEvent(object source, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnTimedEvent), source, e);
                return;
            }

            UpdateVoltageChart(Switch.voltage);
            UpdateCurrentChart(Switch.current);

            label1.Text = $"Voltage:{Switch.voltage:F2}V   Current:{Switch.current:F2}A   Power:{(Switch.voltage * Switch.current):0.##}W";

            if (Switch.DHTTstate && Switch.Sensortype == "DHT22")
            {
                label2.Text = $"Temperature:{Switch.DHTT}℃ from DHT22 sensor";
                UpdateTemperatureChart(Switch.DHTT);
            }

            if (Switch.DSTstate && Switch.Sensortype == "DS18B20")
            {
                label2.Text = $"Temperature:{Switch.DST}℃ from DS18B20 probe";
                UpdateTemperatureChart(Switch.DST);
            }

            if (Switch.DHTHstate && Switch.Sensortype == "DHT22")
            {
                label3.Text = $"Humidity:{Switch.DHTH}% from DHT22 sensor";
                UpdateHumidityChart(Switch.DHTH);
            }

            if (!Switch.DHTTstate && !Switch.DSTstate)
            {
                label2.Text = label3.Text = "No sensor or wrong sensor selected";
            }
        }

        private void UpdateChart(
            double value,
            DataLogger data,
            FormsPlot plot,
            ScottColor color,
            Func<double, double, (double yMin, double yMax)> yLimitsFunc,
            string legendText = null)
        {
            if (plot.InvokeRequired)
            {
                plot.Invoke(new Action(() => UpdateChart(value, data, plot, color, yLimitsFunc, legendText)));
                return;
            }

            double elapsedTime = GetElapsedSeconds();
            data.Add(DateTime.Now.ToOADate(), value);

            data.Color = color;

            // if (data.Data.Coordinates.Any())
            // {
            var (yMin, yMax) = yLimitsFunc(data.Data.Coordinates.Min(c => c.Y), data.Data.Coordinates.Max(c => c.Y));
            data.Axes.YAxis.Min = yMin;
            data.Axes.YAxis.Max = yMax;
            // }

            plot.Refresh();
        }

        private void UpdateVoltageChart(double voltage)
        {
            UpdateChart(voltage, vloLog, voltagePlot, ScottColor.FromHex("#4169E1"),
                (min, max) => (min - 0.5, max + 0.5), "Voltage");
        }

        private void UpdateCurrentChart(double current)
        {
            UpdateChart(current, currLog, currentPlot, ScottColor.FromHex("#FF4500"),
                (min, max) => (Math.Max(min - 0.5, 0), max + 0.5));
        }

        private void UpdateTemperatureChart(double temperature)
        {
            UpdateChart(temperature, tempLog, temperaturePlot, ScottColor.FromHex("#CD5C5C"),
                (min, max) => (min - 3, max + 3));
        }

        private void UpdateHumidityChart(double humidity)
        {
            UpdateChart(humidity, humLog, humidityPlot, ScottColor.FromHex("#48D1CC"),
                (min, max) => (min - 4, max + 4));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vloLog.Clear();
            currLog.Clear();
            tempLog.Clear();
            humLog.Clear();
            startTime = DateTime.Now;

            voltagePlot.Refresh();
            currentPlot.Refresh();
            temperaturePlot.Refresh();
            humidityPlot.Refresh();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x112 && (int)m.WParam == 0xF060)
                return;
            base.WndProc(ref m);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UltimateV2Monitor));

            voltagePlot = new FormsPlot();
            currentPlot = new FormsPlot();
            temperaturePlot = new FormsPlot();
            humidityPlot = new FormsPlot();
            checkBox1 = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            button1 = new Button();

            ((ISupportInitialize)pictureBox1).BeginInit();
            ((ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();

            // voltagePlot
            voltagePlot.DisplayScale = 1F;
            voltagePlot.Location = new Point(10, 81);
            voltagePlot.Name = "voltagePlot";
            voltagePlot.Size = new Size(780, 329);
            voltagePlot.TabIndex = 0;

            // currentPlot
            currentPlot.DisplayScale = 1F;
            currentPlot.Location = new Point(810, 81);
            currentPlot.Name = "currentPlot";
            currentPlot.Size = new Size(780, 329);
            currentPlot.TabIndex = 1;

            // temperaturePlot
            temperaturePlot.DisplayScale = 1F;
            temperaturePlot.Location = new Point(10, 501);
            temperaturePlot.Name = "temperaturePlot";
            temperaturePlot.Size = new Size(780, 421);
            temperaturePlot.TabIndex = 2;

            // humidityPlot
            humidityPlot.DisplayScale = 1F;
            humidityPlot.Location = new Point(810, 501);
            humidityPlot.Name = "humidityPlot";
            humidityPlot.Size = new Size(780, 421);
            humidityPlot.TabIndex = 3;

            // checkBox1
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Microsoft Sans Serif", 10.5f);
            checkBox1.ForeColor = WinFormsColor.White;
            checkBox1.Location = new Point(1243, 932);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(154, 26);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "History data";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;

            // label1
            label1.AutoSize = true;
            label1.BackColor = WinFormsColor.Maroon;
            label1.Font = new Font("Microsoft Sans Serif", 10.71f);
            label1.ForeColor = WinFormsColor.White;
            label1.Location = new Point(455, 11);
            label1.Name = "label1";
            label1.Size = new Size(504, 30);
            label1.TabIndex = 5;
            label1.Text = "Voltage:12.00V   Current:5.00A   Power:60.00W";
            label1.TextAlign = ContentAlignment.MiddleCenter;

            // label2
            label2.AutoSize = true;
            label2.BackColor = WinFormsColor.Maroon;
            label2.Font = new Font("Microsoft Sans Serif", 10.71f);
            label2.ForeColor = WinFormsColor.White;
            label2.Location = new Point(42, 431);
            label2.Name = "label2";
            label2.Size = new Size(390, 30);
            label2.TabIndex = 6;
            label2.Text = "No sensor or wrong sensor selected";
            label2.TextAlign = ContentAlignment.MiddleCenter;

            // label3
            label3.AutoSize = true;
            label3.BackColor = WinFormsColor.Maroon;
            label3.Font = new Font("Microsoft Sans Serif", 10.71f);
            label3.ForeColor = WinFormsColor.White;
            label3.Location = new Point(831, 431);
            label3.Name = "label3";
            label3.Size = new Size(390, 30);
            label3.TabIndex = 7;
            label3.Text = "No sensor or wrong sensor selected";
            label3.TextAlign = ContentAlignment.MiddleCenter;

            // pictureBox1
            pictureBox1.BackColor = WinFormsColor.Maroon;
            pictureBox1.Location = new Point(-13, -12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1683, 84);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;

            // pictureBox2
            pictureBox2.BackColor = WinFormsColor.Maroon;
            pictureBox2.Location = new Point(-13, 408);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1638, 84);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;

            // button1
            button1.BackColor = WinFormsColor.Maroon;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = WinFormsColor.White;
            button1.Location = new Point(1426, 927);
            button1.Name = "button1";
            button1.Size = new Size(110, 37);
            button1.TabIndex = 10;
            button1.Text = "Clear data";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;

            // UltimateV2Monitor2
            AutoScaleDimensions = new SizeF(144f, 144f);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = WinFormsColor.Black;
            ClientSize = new Size(1602, 977);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(humidityPlot);
            Controls.Add(temperaturePlot);
            Controls.Add(currentPlot);
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Controls.Add(voltagePlot);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "UltimateV2Monitor2";
            Text = "WandererBox Ultimate V2 Monitor";

            ((ISupportInitialize)pictureBox1).EndInit();
            ((ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }
    }
}