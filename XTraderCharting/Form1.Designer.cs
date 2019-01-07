namespace XTraderCharting
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.LineChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ConnectionLbl = new System.Windows.Forms.Label();
            this.LineChartUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.ZoomTrack = new System.Windows.Forms.TrackBar();
            this.ZoomAmountLabel = new System.Windows.Forms.Label();
            this.ContLBL = new System.Windows.Forms.Label();
            this.LinBttn = new System.Windows.Forms.Button();
            this.FootPrintBttn = new System.Windows.Forms.Button();
            this.CSChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CSChartUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.LinePanel = new System.Windows.Forms.Panel();
            this.CSPanel = new System.Windows.Forms.Panel();
            this.IntervalPanel = new System.Windows.Forms.Panel();
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.SRB120 = new System.Windows.Forms.RadioButton();
            this.SRB10 = new System.Windows.Forms.RadioButton();
            this.SRB60 = new System.Windows.Forms.RadioButton();
            this.SRB30 = new System.Windows.Forms.RadioButton();
            this.SRB5 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.LineChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CSChart)).BeginInit();
            this.LinePanel.SuspendLayout();
            this.CSPanel.SuspendLayout();
            this.IntervalPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LineChart
            // 
            this.LineChart.BackColor = System.Drawing.SystemColors.Control;
            this.LineChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LineChart.BorderlineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LineChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea5.BackColor = System.Drawing.SystemColors.Control;
            chartArea5.Name = "ChartArea1";
            this.LineChart.ChartAreas.Add(chartArea5);
            this.LineChart.Location = new System.Drawing.Point(8, 8);
            this.LineChart.Margin = new System.Windows.Forms.Padding(0);
            this.LineChart.Name = "LineChart";
            this.LineChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            this.LineChart.Size = new System.Drawing.Size(657, 443);
            this.LineChart.TabIndex = 0;
            this.LineChart.Text = "MainChart";
            this.LineChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainChart_MouseMove);
            // 
            // ConnectionLbl
            // 
            this.ConnectionLbl.AutoSize = true;
            this.ConnectionLbl.Location = new System.Drawing.Point(72, 480);
            this.ConnectionLbl.Name = "ConnectionLbl";
            this.ConnectionLbl.Size = new System.Drawing.Size(78, 14);
            this.ConnectionLbl.TabIndex = 1;
            this.ConnectionLbl.Text = "Not Connected";
            // 
            // LineChartUpdateTimer
            // 
            this.LineChartUpdateTimer.Interval = 1000;
            this.LineChartUpdateTimer.Tick += new System.EventHandler(this.ChartUpdateTimer_Tick);
            // 
            // ZoomTrack
            // 
            this.ZoomTrack.AutoSize = false;
            this.ZoomTrack.Location = new System.Drawing.Point(506, 476);
            this.ZoomTrack.Maximum = 100;
            this.ZoomTrack.Minimum = 1;
            this.ZoomTrack.Name = "ZoomTrack";
            this.ZoomTrack.Size = new System.Drawing.Size(265, 24);
            this.ZoomTrack.TabIndex = 2;
            this.ZoomTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ZoomTrack.Value = 50;
            this.ZoomTrack.Scroll += new System.EventHandler(this.ZoomTrack_Scroll);
            // 
            // ZoomAmountLabel
            // 
            this.ZoomAmountLabel.Location = new System.Drawing.Point(763, 479);
            this.ZoomAmountLabel.Name = "ZoomAmountLabel";
            this.ZoomAmountLabel.Size = new System.Drawing.Size(25, 14);
            this.ZoomAmountLabel.TabIndex = 3;
            this.ZoomAmountLabel.Text = "100";
            // 
            // ContLBL
            // 
            this.ContLBL.AutoSize = true;
            this.ContLBL.Location = new System.Drawing.Point(8, 480);
            this.ContLBL.Name = "ContLBL";
            this.ContLBL.Size = new System.Drawing.Size(48, 14);
            this.ContLBL.TabIndex = 4;
            this.ContLBL.Text = "Contract";
            // 
            // LinBttn
            // 
            this.LinBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LinBttn.Location = new System.Drawing.Point(311, 479);
            this.LinBttn.Name = "LinBttn";
            this.LinBttn.Size = new System.Drawing.Size(23, 18);
            this.LinBttn.TabIndex = 5;
            this.LinBttn.UseVisualStyleBackColor = true;
            this.LinBttn.Click += new System.EventHandler(this.LinBttn_Click);
            // 
            // FootPrintBttn
            // 
            this.FootPrintBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FootPrintBttn.Location = new System.Drawing.Point(340, 479);
            this.FootPrintBttn.Name = "FootPrintBttn";
            this.FootPrintBttn.Size = new System.Drawing.Size(23, 18);
            this.FootPrintBttn.TabIndex = 5;
            this.FootPrintBttn.UseVisualStyleBackColor = true;
            this.FootPrintBttn.Click += new System.EventHandler(this.FootPrintBttn_Click);
            // 
            // CSChart
            // 
            this.CSChart.BackColor = System.Drawing.SystemColors.Control;
            this.CSChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CSChart.BorderlineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CSChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea6.BackColor = System.Drawing.SystemColors.Control;
            chartArea6.BackSecondaryColor = System.Drawing.Color.White;
            chartArea6.Name = "ChartArea1";
            this.CSChart.ChartAreas.Add(chartArea6);
            this.CSChart.Location = new System.Drawing.Point(10, 7);
            this.CSChart.Margin = new System.Windows.Forms.Padding(0);
            this.CSChart.Name = "CSChart";
            this.CSChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            this.CSChart.Size = new System.Drawing.Size(657, 444);
            this.CSChart.TabIndex = 6;
            this.CSChart.Text = "MainChart";
            // 
            // CSChartUpdateTimer
            // 
            this.CSChartUpdateTimer.Interval = 1000;
            this.CSChartUpdateTimer.Tick += new System.EventHandler(this.CSChartUpdateTimer_Tick);
            // 
            // LinePanel
            // 
            this.LinePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LinePanel.Controls.Add(this.LineChart);
            this.LinePanel.Location = new System.Drawing.Point(6, 8);
            this.LinePanel.Name = "LinePanel";
            this.LinePanel.Size = new System.Drawing.Size(779, 461);
            this.LinePanel.TabIndex = 7;
            // 
            // CSPanel
            // 
            this.CSPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CSPanel.Controls.Add(this.IntervalPanel);
            this.CSPanel.Controls.Add(this.CSChart);
            this.CSPanel.Location = new System.Drawing.Point(6, 8);
            this.CSPanel.Name = "CSPanel";
            this.CSPanel.Size = new System.Drawing.Size(779, 461);
            this.CSPanel.TabIndex = 8;
            this.CSPanel.Visible = false;
            // 
            // IntervalPanel
            // 
            this.IntervalPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IntervalPanel.Controls.Add(this.IntervalLabel);
            this.IntervalPanel.Controls.Add(this.SRB120);
            this.IntervalPanel.Controls.Add(this.SRB10);
            this.IntervalPanel.Controls.Add(this.SRB60);
            this.IntervalPanel.Controls.Add(this.SRB30);
            this.IntervalPanel.Controls.Add(this.SRB5);
            this.IntervalPanel.Location = new System.Drawing.Point(684, 8);
            this.IntervalPanel.Name = "IntervalPanel";
            this.IntervalPanel.Size = new System.Drawing.Size(80, 145);
            this.IntervalPanel.TabIndex = 7;
            // 
            // IntervalLabel
            // 
            this.IntervalLabel.AutoSize = true;
            this.IntervalLabel.Location = new System.Drawing.Point(6, 6);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(42, 14);
            this.IntervalLabel.TabIndex = 9;
            this.IntervalLabel.Text = "Interval";
            // 
            // SRB120
            // 
            this.SRB120.AutoSize = true;
            this.SRB120.Location = new System.Drawing.Point(8, 118);
            this.SRB120.Name = "SRB120";
            this.SRB120.Size = new System.Drawing.Size(65, 18);
            this.SRB120.TabIndex = 0;
            this.SRB120.Text = "120 Sec";
            this.SRB120.UseVisualStyleBackColor = true;
            this.SRB120.CheckedChanged += new System.EventHandler(this.SRB5_CheckedChanged);
            // 
            // SRB10
            // 
            this.SRB10.AutoSize = true;
            this.SRB10.Location = new System.Drawing.Point(8, 49);
            this.SRB10.Name = "SRB10";
            this.SRB10.Size = new System.Drawing.Size(59, 18);
            this.SRB10.TabIndex = 0;
            this.SRB10.Text = "10 Sec";
            this.SRB10.UseVisualStyleBackColor = true;
            this.SRB10.CheckedChanged += new System.EventHandler(this.SRB5_CheckedChanged);
            // 
            // SRB60
            // 
            this.SRB60.AutoSize = true;
            this.SRB60.Location = new System.Drawing.Point(8, 95);
            this.SRB60.Name = "SRB60";
            this.SRB60.Size = new System.Drawing.Size(59, 18);
            this.SRB60.TabIndex = 0;
            this.SRB60.Text = "60 Sec";
            this.SRB60.UseVisualStyleBackColor = true;
            this.SRB60.CheckedChanged += new System.EventHandler(this.SRB5_CheckedChanged);
            // 
            // SRB30
            // 
            this.SRB30.AutoSize = true;
            this.SRB30.Location = new System.Drawing.Point(8, 72);
            this.SRB30.Name = "SRB30";
            this.SRB30.Size = new System.Drawing.Size(59, 18);
            this.SRB30.TabIndex = 0;
            this.SRB30.Text = "30 Sec";
            this.SRB30.UseVisualStyleBackColor = true;
            this.SRB30.CheckedChanged += new System.EventHandler(this.SRB5_CheckedChanged);
            // 
            // SRB5
            // 
            this.SRB5.AutoSize = true;
            this.SRB5.Checked = true;
            this.SRB5.Location = new System.Drawing.Point(8, 26);
            this.SRB5.Name = "SRB5";
            this.SRB5.Size = new System.Drawing.Size(53, 18);
            this.SRB5.TabIndex = 0;
            this.SRB5.TabStop = true;
            this.SRB5.Text = "5 Sec";
            this.SRB5.UseVisualStyleBackColor = true;
            this.SRB5.CheckedChanged += new System.EventHandler(this.SRB5_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 502);
            this.Controls.Add(this.CSPanel);
            this.Controls.Add(this.LinePanel);
            this.Controls.Add(this.FootPrintBttn);
            this.Controls.Add(this.LinBttn);
            this.Controls.Add(this.ContLBL);
            this.Controls.Add(this.ZoomAmountLabel);
            this.Controls.Add(this.ZoomTrack);
            this.Controls.Add(this.ConnectionLbl);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.LineChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CSChart)).EndInit();
            this.LinePanel.ResumeLayout(false);
            this.CSPanel.ResumeLayout(false);
            this.IntervalPanel.ResumeLayout(false);
            this.IntervalPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart LineChart;
        private System.Windows.Forms.Label ConnectionLbl;
        private System.Windows.Forms.Timer LineChartUpdateTimer;
        private System.Windows.Forms.TrackBar ZoomTrack;
        private System.Windows.Forms.Label ZoomAmountLabel;
        private System.Windows.Forms.Label ContLBL;
        private System.Windows.Forms.Button LinBttn;
        private System.Windows.Forms.Button FootPrintBttn;
        private System.Windows.Forms.DataVisualization.Charting.Chart CSChart;
        private System.Windows.Forms.Timer CSChartUpdateTimer;
        private System.Windows.Forms.Panel LinePanel;
        private System.Windows.Forms.Panel CSPanel;
        private System.Windows.Forms.Panel IntervalPanel;
        private System.Windows.Forms.Label IntervalLabel;
        private System.Windows.Forms.RadioButton SRB120;
        private System.Windows.Forms.RadioButton SRB10;
        private System.Windows.Forms.RadioButton SRB60;
        private System.Windows.Forms.RadioButton SRB30;
        private System.Windows.Forms.RadioButton SRB5;
    }
}

