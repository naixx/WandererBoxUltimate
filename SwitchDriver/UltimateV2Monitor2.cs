using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.TickGenerators;
using ScottPlot.WinForms;
using Label = System.Windows.Forms.Label;
using WinFormsColor = System.Drawing.Color;
using ScottColor = ScottPlot.Color;

namespace ASCOM.WandererBoxes
{
    public class UltimateV2Monitor2 : Form
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
        private NotifyIcon notifyIcon1;
        private TableLayoutPanel mainLayout;
        private TableLayoutPanel topLayout;
        private TableLayoutPanel bottomLayout;

        public UltimateV2Monitor2()
        {
            Load += UltimateV2Monitor_Load;
            InitializeComponent();
        }

        private void UltimateV2Monitor_Load(object sender, EventArgs e)
        {
            Switch.i = 0;

            startTime = DateTime.Now;

            InitializeVoltagePlot();
            InitializeCurrentPlot();
            InitializeTemperaturePlot();
            InitializeHumidityPlot();
        }

        private double GetElapsedSeconds() => (DateTime.Now - startTime).TotalSeconds;

        private void StylePlot(FormsPlot plot, DataLogger dataLogger)
        {
            plot.Plot.FigureBackground.Color = ScottColor.FromHex("#000000");
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

            // Адаптивный padding в зависимости от DPI
            float dpiScale = this.DeviceDpi / 96f;
            int leftPadding = (int)(32 * dpiScale);
            int bottomPadding = (int)(18 * dpiScale);
            plot.Plot.Layout.Fixed(new PixelPadding(leftPadding, 0, bottomPadding, 0));

            plot.Plot.Axes.Left.TickGenerator = new NumericAutomatic { TickDensity = 1 };
            plot.Plot.Title(false);
            plot.Plot.Axes.Bottom.Label.IsVisible = false;
            plot.Plot.Axes.Left.Label.IsVisible = false;
            plot.Plot.Axes.Margins(bottom: 0, top: 0, left: 0.0, right: 0.0);
            plot.Plot.Axes.AutoScale();

            plot.Plot.ScaleFactor = dpiScale;

            dataLogger.LineWidth = 0.7f * dpiScale;
            dataLogger.MarkerSize = 0;

            float baseFontSize = 12f;
            float fontSize = baseFontSize * dpiScale /*/ Math.Max(1.0f, dpiScale * 0.7f)*/;

            axes.Bottom.TickLabelStyle.ForeColor = ScottColor.FromHex("#FFFFFF");
            axes.Left.TickLabelStyle.ForeColor = ScottColor.FromHex("#FFFFFF");
            axes.Bottom.TickLabelStyle.FontSize = fontSize;
            axes.Left.TickLabelStyle.FontSize = fontSize;

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

            StylePlot(voltagePlot, vloLog);
            voltagePlot.Plot.Axes.Bottom.Label.IsVisible = true;
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

            StylePlot(currentPlot, currLog);
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

            StylePlot(temperaturePlot, tempLog);
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

            StylePlot(humidityPlot, humLog);
        }

        private void UpdateDataLoggerView(DataLogger logger, FormsPlot plot, bool showAll)
        {
            double oneMinuteInOADate = 60f * 5 / (24 * 60 * 60);
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

            voltagePlot.Refresh();
            currentPlot.Refresh();
            temperaturePlot.Refresh();
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
                label2.Text = $"Temperature:{Switch.DHTT}℃, DHT22";
                UpdateTemperatureChart(Switch.DHTT);
            }

            if (Switch.DSTstate && Switch.Sensortype == "DS18B20")
            {
                label2.Text = $"Temperature:{Switch.DST}℃, DS18B20 probe";
                UpdateTemperatureChart(Switch.DST);
            }

            if (Switch.DHTHstate && Switch.Sensortype == "DHT22")
            {
                label3.Text = $"Humidity:{Switch.DHTH}%, DHT22";
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

            data.Add(DateTime.Now.ToOADate(), value);
            data.Color = color;

            var (yMin, yMax) = yLimitsFunc(data.Data.Coordinates.Min(c => c.Y), data.Data.Coordinates.Max(c => c.Y));
            data.Axes.YAxis.Min = yMin;
            data.Axes.YAxis.Max = yMax;

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
            base.WndProc(ref m);
        }

        private bool force = false;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (force)
            {
                base.OnFormClosing(e);
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon1.Visible = true;
            }

            base.OnFormClosing(e);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        public void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(exitToolStripMenuItem_Click), sender, e);
                return;
            }

            notifyIcon1.Visible = false;
            force = true;
            Close();
            Dispose();
            Application.Exit();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UltimateV2Monitor));
            // AutoScaleDimensions = new SizeF(96f, 96f);
            // AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            mainLayout = new TableLayoutPanel();
            topLayout = new TableLayoutPanel();
            bottomLayout = new TableLayoutPanel();
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
            notifyIcon1 = new NotifyIcon(components);

            ((ISupportInitialize)pictureBox1).BeginInit();
            ((ISupportInitialize)pictureBox2).BeginInit();
            mainLayout.SuspendLayout();
            topLayout.SuspendLayout();
            bottomLayout.SuspendLayout();
            SuspendLayout();

            // NotifyIcon setup
            ContextMenuStrip trayMenu = new ContextMenuStrip();
            ToolStripMenuItem showItem = new ToolStripMenuItem("Show");
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");
            showItem.Click += showToolStripMenuItem_Click;
            exitItem.Click += exitToolStripMenuItem_Click;
            trayMenu.Items.Add(showItem);
            trayMenu.Items.Add(exitItem);

            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.Text = "WandererBox Monitor";
            notifyIcon1.ContextMenuStrip = trayMenu;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            notifyIcon1.Visible = false;

            // Main Layout - адаптивные высоты
            float dpiScale = this.DeviceDpi / 96f;
            float headerHeight = 42f * dpiScale;
            float buttonHeight = 35f * dpiScale;

            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.RowCount = 4;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, headerHeight));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, headerHeight));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            mainLayout.Dock = DockStyle.Fill;

            // Top Layout
            topLayout.ColumnCount = 2;
            topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            topLayout.RowCount = 1;
            topLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            topLayout.Dock = DockStyle.Fill;

            // Bottom Layout
            bottomLayout.ColumnCount = 2;
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            bottomLayout.RowCount = 2;
            bottomLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bottomLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, buttonHeight));
            bottomLayout.Dock = DockStyle.Fill;

            // voltagePlot
            voltagePlot.DisplayScale = 1F;
            voltagePlot.Dock = DockStyle.Fill;

            // currentPlot
            currentPlot.DisplayScale = 1F;
            currentPlot.Dock = DockStyle.Fill;

            // temperaturePlot
            temperaturePlot.DisplayScale = 1F;
            temperaturePlot.Dock = DockStyle.Fill;

            // humidityPlot
            humidityPlot.DisplayScale = 1F;
            humidityPlot.Dock = DockStyle.Fill;

            // Адаптивный размер шрифта для контролов
            float baseFontSize = 10f * dpiScale;

            // checkBox1
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Microsoft Sans Serif", baseFontSize);
            checkBox1.ForeColor = WinFormsColor.White;
            checkBox1.Text = "History data";
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;

            // button1
            button1.BackColor = WinFormsColor.Maroon;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = WinFormsColor.White;
            button1.Text = "Clear data";
            button1.Font = new Font("Microsoft Sans Serif", baseFontSize);
            button1.AutoSize = true;
            button1.Click += button1_Click;

            // label1
            label1.AutoSize = false;
            label1.Dock = DockStyle.Fill;
            label1.BackColor = WinFormsColor.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", baseFontSize * 1.05f);
            label1.ForeColor = WinFormsColor.White;
            label1.Text = "Voltage:12.00V   Current:5.00A   Power:60.00W";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Margin = new Padding(0);

            // label2
            label2.AutoSize = false;
            label2.Dock = DockStyle.Fill;
            label2.BackColor = WinFormsColor.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", baseFontSize);
            label2.ForeColor = WinFormsColor.White;
            label2.Text = "No sensor or wrong sensor selected";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Margin = new Padding(0, 0, 0, 0);

            // label3
            label3.AutoSize = false;
            label3.Dock = DockStyle.Fill;
            label3.BackColor = WinFormsColor.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", baseFontSize);
            label3.ForeColor = WinFormsColor.White;
            label3.Text = "No sensor or wrong sensor selected";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Margin = new Padding(0, 0, 0, 0);

            // pictureBox1
            pictureBox1.BackColor = WinFormsColor.Maroon;
            pictureBox1.Dock = DockStyle.Fill;

            // pictureBox2
            pictureBox2.BackColor = WinFormsColor.Maroon;
            pictureBox2.Dock = DockStyle.Fill;

            // Добавляем графики в topLayout
            topLayout.Controls.Add(voltagePlot, 0, 0);
            topLayout.Controls.Add(currentPlot, 1, 0);

            // Добавляем графики в bottomLayout
            bottomLayout.Controls.Add(temperaturePlot, 0, 0);
            bottomLayout.Controls.Add(humidityPlot, 1, 0);

            // Панель с кнопками
            TableLayoutPanel buttonPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = WinFormsColor.Black,
                ColumnCount = 3,
                RowCount = 1,
                //  Padding = new Padding((int)(8 * dpiScale))
            };

            buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            buttonPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            Panel spacer = new Panel { Dock = DockStyle.Fill };

            checkBox1.Anchor = AnchorStyles.Right;
            checkBox1.Margin = new Padding(0, 0, (int)(12 * dpiScale), 0);

            button1.Anchor = AnchorStyles.Right;
            button1.Margin = new Padding(0);
            button1.Margin = new Padding(0, 0, (int)(12 * dpiScale), 0);

            // button1.Padding = new Padding((int)(12 * dpiScale), (int)(8 * dpiScale), (int)(12 * dpiScale), (int)(8 * dpiScale));

            buttonPanel.Controls.Add(spacer, 0, 0);
            buttonPanel.Controls.Add(checkBox1, 1, 0);
            buttonPanel.Controls.Add(button1, 2, 0);

            bottomLayout.Controls.Add(buttonPanel, 0, 1);
            bottomLayout.SetColumnSpan(buttonPanel, 2);

            // Панель с label2 и label3
            TableLayoutPanel labelPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = WinFormsColor.Maroon
            };
            labelPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            labelPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            labelPanel.Controls.Add(label2, 0, 0);
            labelPanel.Controls.Add(label3, 1, 0);

            // Собираем mainLayout
            pictureBox1.Controls.Add(label1);

            mainLayout.Controls.Add(pictureBox1, 0, 0);
            mainLayout.Controls.Add(topLayout, 0, 1);
            mainLayout.Controls.Add(labelPanel, 0, 2);
            mainLayout.Controls.Add(bottomLayout, 0, 3);


            BackColor = WinFormsColor.Black;

            ClientSize = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.6), (int)(Screen.PrimaryScreen.Bounds.Height * 0.6));
            Controls.Add(mainLayout);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(800, 600);
            Name = "UltimateV2Monitor2";
            Text = "WandererBox Ultimate V2 Monitor";

            ((ISupportInitialize)pictureBox1).EndInit();
            ((ISupportInitialize)pictureBox2).EndInit();
            mainLayout.ResumeLayout(false);
            topLayout.ResumeLayout(false);
            bottomLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
                if (notifyIcon1 != null)
                {
                    notifyIcon1.Visible = false;
                    notifyIcon1.Dispose();
                }
            }

            base.Dispose(disposing);
        }
    }
}