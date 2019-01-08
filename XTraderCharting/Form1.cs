using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace XTraderCharting
{
    public partial class Form1 : Form
    {
        DateTime StartTime;
        Contract Cont;
        public Form1() => InitializeComponent();
        private void Form1_Load(object sender, EventArgs e)
        {
            FootPrintBttn.Enabled = true;
            LinBttn.Enabled = false;
            FootPrintBttn.BackColor = SystemColors.Control;
            LinBttn.BackColor = SystemColors.ControlDark;
            LineChartSetup(LineChart);
            CSChartSetup(CSChart);
        }
        private void Form1_Shown(object sender, EventArgs e) { TTAPIFunctions TTAPIF = new TTAPIFunctions(); TTAPIF.Init(this, true); }

        public void XtraderConnected(string s, Contract c)
        {
            Cont = c;
            ContLBL.Text = s;
            ConnectionLbl.Text = "Connected";
            LineChartUpdateTimer.Enabled = true;
            CSChartUpdateTimer.Enabled = true;
        }
        public void BuildNotification(string msg, bool b) { Text = msg; }








        int ZoomLevel = 25;
        private void ZoomTrack_Scroll(object sender, EventArgs e)
        {
            if (ZoomTrack.Value < 25) ZoomLevel = ZoomTrack.Value * 2;
            else if (ZoomTrack.Value < 50) ZoomLevel = ZoomTrack.Value * 3;
            else if (ZoomTrack.Value < 75) ZoomLevel = ZoomTrack.Value * 4;
            else ZoomLevel = ZoomTrack.Value * 5;

            ZoomAmountLabel.Text = ZoomTrack.Value.ToString();
            LineChart.ChartAreas[0].AxisX.Maximum = (DateTime.Now.AddSeconds(ZoomLevel) - StartTime).TotalSeconds;
            CSChart.ChartAreas[0].AxisX.Maximum = (DateTime.Now.AddSeconds(ZoomLevel) - StartTime).TotalSeconds/ CSInterval;

        }

        DataPoint prevPoint;
        private void MainChart_MouseMove(object sender, MouseEventArgs e)
        {
            if (prevPoint != null) { prevPoint.MarkerStyle = MarkerStyle.None; prevPoint.IsValueShownAsLabel = false; }
            var result = LineChart.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            if (result.ChartElementType == ChartElementType.DataPoint) { var prop = result.Object as DataPoint; if (prop != null) { prop.IsValueShownAsLabel = true; prop.MarkerStyle = MarkerStyle.Star4; prevPoint = prop; } }
        }



        private void FootPrintBttn_Click(object sender, EventArgs e)
        {
            FootPrintBttn.Enabled = false; LinBttn.Enabled = true; FootPrintBttn.BackColor = SystemColors.ControlDark; LinBttn.BackColor = SystemColors.Control;
            CSPanel.Visible = true; LinePanel.Visible = false;
        }

        private void LinBttn_Click(object sender, EventArgs e)
        {
            FootPrintBttn.Enabled = true; LinBttn.Enabled = false; FootPrintBttn.BackColor = SystemColors.Control; LinBttn.BackColor = SystemColors.ControlDark;
            CSPanel.Visible = false; LinePanel.Visible = true;
        }
















        void LineChartSetup(Chart chart)
        {
            Series series = new Series("Price");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.Color = Color.Gray;
            series.IsVisibleInLegend = false;
            chart.Series.Add(series);

            //LineSeries = series; LineChart.Series.Remove(LineChart.Series[0]);
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisX.IsMarginVisible = false;

            StartTime = DateTime.Now; ZoomAmountLabel.Text = ZoomTrack.Value.ToString();
            Series time = new Series("XTime");
            time.ChartType = SeriesChartType.Line;
            time.BorderWidth = 0;
            time.IsVisibleInLegend = false;
            chart.Series.Add(time);

            double X = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 05, 00, 00) - StartTime).TotalSeconds;
            for (int i = 0; i < X; i++) { string LBL = DateTime.Now.AddSeconds(i).ToString("HH:mm:ss"); time.Points.AddXY(LBL, 0); }
            LineChart.ChartAreas[0].AxisX.Maximum = (DateTime.Now.AddSeconds(ZoomLevel) - StartTime).TotalSeconds;
            LineChart.ChartAreas[0].AxisX.Minimum = double.NaN;
        }

        private void ChartUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (Cont.MidPoint != 0)
            {
                //Update Chart
                string time = DateTime.Now.ToString("HH:mm:ss"); LineChart.Series["Price"].Points.AddXY(time, Cont.MidPoint * .25);

                LineChart.ChartAreas[0].AxisY.Maximum = (Cont.High + 10) * .25; LineChart.ChartAreas[0].AxisY.Minimum = (Cont.Low - 10) * .25;

                if (Cont.First > Cont.MidPoint) LineChart.Series["Price"].Color = Color.IndianRed; else LineChart.Series["Price"].Color = Color.Olive;
                LineChart.ChartAreas[0].AxisX.Maximum = (DateTime.Now.AddSeconds(ZoomLevel) - StartTime).TotalSeconds;
            }
        }






        void CSChartSetup(Chart chart)
        {

            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisX.IsMarginVisible = false;


            Series series = new Series("Price"); // <<== make sure to name the series "Price"
            chart.Series.Add(series);
            series.IsVisibleInLegend = false;
            chart.Series["Price"].ChartType = SeriesChartType.Candlestick;

            Series time = new Series("XTime");
            time.ChartType = SeriesChartType.Line;
            time.BorderWidth = 0;
            time.IsVisibleInLegend = false;
            chart.Series.Add(time);

            double X = ((new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 05, 00, 00) - StartTime).TotalSeconds)/ CSInterval;
            for (int i = 0; i < X; i++) { string LBL = DateTime.Now.AddSeconds(i*5).ToString("HH:mm:ss"); time.Points.AddXY(LBL, 0); }
            chart.ChartAreas[0].AxisX.Maximum = (DateTime.Now.AddSeconds(ZoomLevel) - StartTime).TotalSeconds/ CSInterval;
            chart.ChartAreas[0].AxisX.Minimum = double.NaN;

            // Set the style of the open-close marks
            CSChart.Series["Price"]["OpenCloseStyle"] = "Triangle";
            // Show both open and close marks
            CSChart.Series["Price"]["ShowOpenClose"] = "Both";
            // Set point width
            CSChart.Series["Price"]["PointWidth"] = "1.0";
            // Set colors bars
            CSChart.Series["Price"]["PriceUpColor"] = "Olive";   //= "Green"; // <<== use text indexer for series
            CSChart.Series["Price"]["PriceDownColor"] = "IndianRed";   //= "Red"; // <<== use text indexer for series
        }

        int IntervalCount = 0;
        int CurrentPoint = 0;
        private void CSChartUpdateTimer_Tick(object sender, EventArgs e)
        {
            IntervalCount++;
            if (!Recalcing)
            {
                if (IntervalCount > CSInterval||CurrentPoint == 0) { if (CSStartNewInterval(Cont.CSHigh, Cont.CSLow, Cont.CSOpen, Cont.CSClose)) IntervalCount = 0; }
                else CSInterumData(Cont.CSHigh, Cont.CSLow, Cont.CSOpen, Cont.CSClose);
            }

            double[] TempString = new double[4];
            TempString[0] = Cont.CSHigh * .25;
            TempString[1] = Cont.CSLow * .25;
            TempString[2] = Cont.CSOpen * .25;
            TempString[3] = Cont.CSClose * .25;
            DataPointDict.Add(DataPointDict.Count + 1, TempString);

            CSChart.ChartAreas[0].AxisY.Maximum = (Cont.CSHigh + 5) * .25;
            CSChart.ChartAreas[0].AxisY.Minimum = (Cont.CSLow - 5) * .25;

            CSChart.ChartAreas[0].AxisX.Maximum = (DateTime.Now.AddSeconds(ZoomLevel) - StartTime).TotalSeconds / CSInterval;            
        }

        Dictionary<int, double[]> DataPointDict = new Dictionary<int, double[]>();
        public bool CSStartNewInterval(double high, double low, double open, double close)
        {
            if (close == 0) return false;
            open = close; high = close; low = close;

            string time = DateTime.Now.ToString("HH:mm:ss");
            CurrentPoint = CSChart.Series["Price"].Points.AddXY(time, high * .25);
            CSChart.Series["Price"].Points[CurrentPoint].YValues[1] = low * .25;
            CSChart.Series["Price"].Points[CurrentPoint].YValues[2] = open * .25;
            CSChart.Series["Price"].Points[CurrentPoint].YValues[3] = close * .25;

            return true;
        }

        public void CSInterumData(double high, double low, double open, double close)
        {
            if (low == 0) low = open; if (high == 0) high = open;
            CSChart.Series["Price"].Points[CurrentPoint].YValues[0] = high * .25;
            CSChart.Series["Price"].Points[CurrentPoint].YValues[1] = low * .25;
            CSChart.Series["Price"].Points[CurrentPoint].YValues[2] = open * .25;
            CSChart.Series["Price"].Points[CurrentPoint].YValues[3] = close * .25;
            CSChart.Series["Price"].Points.ResumeUpdates();
            CSChart.Update();
        }


        bool Recalcing = false;
        void AdjustCSInterval()
        {
            Recalcing = true;
            int intervalcnt = 0;
            CSChart.Series["Price"].Points.Clear(); CurrentPoint = 0;
            for (int i = 1; i < DataPointDict.Count+1; i++)
            {
                intervalcnt++; double[] tempDoub = DataPointDict[i];
                if (intervalcnt > CSInterval||CurrentPoint==0) { if (CSStartNewInterval(tempDoub[0], tempDoub[1], tempDoub[2], tempDoub[3])) IntervalCount = 0; }
                else CSInterumData(tempDoub[0], tempDoub[1], tempDoub[2], tempDoub[3]);
        }
            Recalcing = false;
        }


        int CSInterval =5;

        private void SRB5_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                CSInterval = Convert.ToInt16(rb.Name.Substring(3));
                AdjustCSInterval();
            }
        }
    }
}
