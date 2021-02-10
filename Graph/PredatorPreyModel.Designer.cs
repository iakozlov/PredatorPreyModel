namespace Graph
{
    partial class PredatorPreyModel
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PredatorPreyModel));
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.MakeChart = new System.Windows.Forms.Button();
            this.preysCount = new System.Windows.Forms.TextBox();
            this.predatorsCount = new System.Windows.Forms.TextBox();
            this.preysInfo = new System.Windows.Forms.Label();
            this.predatorsInfo = new System.Windows.Forms.Label();
            this.daysCount = new System.Windows.Forms.TextBox();
            this.daysInfo = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveChart = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.engLang = new System.Windows.Forms.Button();
            this.ruLang = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.langInfo = new System.Windows.Forms.Label();
            this.coeff = new System.Windows.Forms.TrackBar();
            this.coeffInfo = new System.Windows.Forms.Label();
            this.currentValue = new System.Windows.Forms.Label();
            this.modelName = new System.Windows.Forms.TextBox();
            this.nameInfo = new System.Windows.Forms.Label();
            this.loadModel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.coeff)).BeginInit();
            this.SuspendLayout();
            // 
            // plotView1
            // 
            this.plotView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotView1.Location = new System.Drawing.Point(85, 37);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(595, 334);
            this.plotView1.TabIndex = 0;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // MakeChart
            // 
            this.MakeChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MakeChart.AutoSize = true;
            this.MakeChart.BackColor = System.Drawing.Color.White;
            this.MakeChart.FlatAppearance.BorderSize = 0;
            this.MakeChart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.MakeChart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.MakeChart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MakeChart.ForeColor = System.Drawing.Color.RoyalBlue;
            this.MakeChart.Location = new System.Drawing.Point(754, 114);
            this.MakeChart.Name = "MakeChart";
            this.MakeChart.Size = new System.Drawing.Size(170, 60);
            this.MakeChart.TabIndex = 1;
            this.MakeChart.Text = "Build model";
            this.MakeChart.UseVisualStyleBackColor = false;
            this.MakeChart.Visible = false;
            this.MakeChart.Click += new System.EventHandler(this.MakeChart_Click);
            this.MakeChart.MouseEnter += new System.EventHandler(this.MakeChart_MouseEnter);
            this.MakeChart.MouseLeave += new System.EventHandler(this.MakeChart_MouseLeave);
            // 
            // preysCount
            // 
            this.preysCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.preysCount.Location = new System.Drawing.Point(34, 472);
            this.preysCount.Name = "preysCount";
            this.preysCount.Size = new System.Drawing.Size(142, 22);
            this.preysCount.TabIndex = 2;
            this.preysCount.Visible = false;
            // 
            // predatorsCount
            // 
            this.predatorsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.predatorsCount.Location = new System.Drawing.Point(207, 472);
            this.predatorsCount.Name = "predatorsCount";
            this.predatorsCount.Size = new System.Drawing.Size(175, 22);
            this.predatorsCount.TabIndex = 3;
            this.predatorsCount.Visible = false;
            // 
            // preysInfo
            // 
            this.preysInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.preysInfo.AutoSize = true;
            this.preysInfo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.preysInfo.ForeColor = System.Drawing.Color.Green;
            this.preysInfo.Location = new System.Drawing.Point(30, 430);
            this.preysInfo.Name = "preysInfo";
            this.preysInfo.Size = new System.Drawing.Size(146, 19);
            this.preysInfo.TabIndex = 4;
            this.preysInfo.Text = "Number of preys:";
            this.preysInfo.Visible = false;
            // 
            // predatorsInfo
            // 
            this.predatorsInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.predatorsInfo.AutoSize = true;
            this.predatorsInfo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.predatorsInfo.ForeColor = System.Drawing.Color.Red;
            this.predatorsInfo.Location = new System.Drawing.Point(203, 430);
            this.predatorsInfo.Name = "predatorsInfo";
            this.predatorsInfo.Size = new System.Drawing.Size(179, 19);
            this.predatorsInfo.TabIndex = 5;
            this.predatorsInfo.Text = "Number of predators:";
            this.predatorsInfo.Visible = false;
            // 
            // daysCount
            // 
            this.daysCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.daysCount.Location = new System.Drawing.Point(407, 472);
            this.daysCount.Name = "daysCount";
            this.daysCount.Size = new System.Drawing.Size(135, 22);
            this.daysCount.TabIndex = 6;
            this.daysCount.Visible = false;
            // 
            // daysInfo
            // 
            this.daysInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.daysInfo.AutoSize = true;
            this.daysInfo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.daysInfo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.daysInfo.Location = new System.Drawing.Point(408, 430);
            this.daysInfo.Name = "daysInfo";
            this.daysInfo.Size = new System.Drawing.Size(139, 19);
            this.daysInfo.TabIndex = 7;
            this.daysInfo.Text = "Number of days:";
            this.daysInfo.Visible = false;
            // 
            // saveChart
            // 
            this.saveChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveChart.BackColor = System.Drawing.Color.White;
            this.saveChart.FlatAppearance.BorderSize = 0;
            this.saveChart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.saveChart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.saveChart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveChart.ForeColor = System.Drawing.Color.RoyalBlue;
            this.saveChart.Location = new System.Drawing.Point(754, 66);
            this.saveChart.Name = "saveChart";
            this.saveChart.Size = new System.Drawing.Size(170, 30);
            this.saveChart.TabIndex = 8;
            this.saveChart.Text = "Save your chart";
            this.saveChart.UseVisualStyleBackColor = false;
            this.saveChart.Visible = false;
            this.saveChart.Click += new System.EventHandler(this.SaveChart_Click);
            this.saveChart.MouseEnter += new System.EventHandler(this.SaveChart_MouseEnter);
            this.saveChart.MouseLeave += new System.EventHandler(this.SaveChart_MouseLeave);
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startButton.BackColor = System.Drawing.Color.White;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.startButton.Location = new System.Drawing.Point(407, 346);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(170, 52);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            this.startButton.MouseEnter += new System.EventHandler(this.StartButton_MouseEnter);
            this.startButton.MouseLeave += new System.EventHandler(this.StartButton_MouseLeave);
            // 
            // engLang
            // 
            this.engLang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.engLang.FlatAppearance.BorderSize = 0;
            this.engLang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.engLang.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.engLang.ForeColor = System.Drawing.Color.AliceBlue;
            this.engLang.Location = new System.Drawing.Point(417, 270);
            this.engLang.Name = "engLang";
            this.engLang.Size = new System.Drawing.Size(130, 39);
            this.engLang.TabIndex = 10;
            this.engLang.Text = "English";
            this.engLang.UseVisualStyleBackColor = true;
            this.engLang.Click += new System.EventHandler(this.EngLang_Click);
            this.engLang.MouseEnter += new System.EventHandler(this.EngLang_MouseEnter);
            this.engLang.MouseLeave += new System.EventHandler(this.EngLang_MouseLeave);
            // 
            // ruLang
            // 
            this.ruLang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ruLang.FlatAppearance.BorderSize = 0;
            this.ruLang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ruLang.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ruLang.ForeColor = System.Drawing.Color.AliceBlue;
            this.ruLang.Location = new System.Drawing.Point(417, 217);
            this.ruLang.Name = "ruLang";
            this.ruLang.Size = new System.Drawing.Size(130, 47);
            this.ruLang.TabIndex = 11;
            this.ruLang.Text = "Русский";
            this.ruLang.UseVisualStyleBackColor = true;
            this.ruLang.Click += new System.EventHandler(this.RuLang_Click);
            this.ruLang.MouseEnter += new System.EventHandler(this.RuLang_MouseEnter);
            this.ruLang.MouseLeave += new System.EventHandler(this.RuLang_MouseLeave);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.welcomeLabel.Location = new System.Drawing.Point(81, 57);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(96, 24);
            this.welcomeLabel.TabIndex = 12;
            this.welcomeLabel.Text = "Welcome";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // langInfo
            // 
            this.langInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.langInfo.AutoSize = true;
            this.langInfo.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.langInfo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.langInfo.Location = new System.Drawing.Point(380, 175);
            this.langInfo.Name = "langInfo";
            this.langInfo.Size = new System.Drawing.Size(255, 29);
            this.langInfo.TabIndex = 13;
            this.langInfo.Text = "Select your language";
            // 
            // coeff
            // 
            this.coeff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.coeff.Location = new System.Drawing.Point(557, 472);
            this.coeff.Maximum = 30;
            this.coeff.Name = "coeff";
            this.coeff.Size = new System.Drawing.Size(132, 56);
            this.coeff.TabIndex = 14;
            this.coeff.Value = 10;
            this.coeff.Visible = false;
            this.coeff.Scroll += new System.EventHandler(this.Coeff_Scroll);
            // 
            // coeffInfo
            // 
            this.coeffInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.coeffInfo.AutoSize = true;
            this.coeffInfo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coeffInfo.ForeColor = System.Drawing.Color.AliceBlue;
            this.coeffInfo.Location = new System.Drawing.Point(553, 433);
            this.coeffInfo.Name = "coeffInfo";
            this.coeffInfo.Size = new System.Drawing.Size(188, 19);
            this.coeffInfo.TabIndex = 15;
            this.coeffInfo.Text = "Preys dead coefficient:";
            this.coeffInfo.Visible = false;
            // 
            // currentValue
            // 
            this.currentValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentValue.AutoSize = true;
            this.currentValue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.currentValue.Location = new System.Drawing.Point(554, 452);
            this.currentValue.Name = "currentValue";
            this.currentValue.Size = new System.Drawing.Size(89, 17);
            this.currentValue.TabIndex = 16;
            this.currentValue.Text = "currentValue";
            this.currentValue.Visible = false;
            // 
            // modelName
            // 
            this.modelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.modelName.Location = new System.Drawing.Point(754, 472);
            this.modelName.Name = "modelName";
            this.modelName.Size = new System.Drawing.Size(156, 22);
            this.modelName.TabIndex = 17;
            this.modelName.Visible = false;
            // 
            // nameInfo
            // 
            this.nameInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nameInfo.AutoSize = true;
            this.nameInfo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameInfo.ForeColor = System.Drawing.SystemColors.Info;
            this.nameInfo.Location = new System.Drawing.Point(750, 430);
            this.nameInfo.Name = "nameInfo";
            this.nameInfo.Size = new System.Drawing.Size(108, 19);
            this.nameInfo.TabIndex = 18;
            this.nameInfo.Text = "Model name:";
            this.nameInfo.Visible = false;
            // 
            // loadModel
            // 
            this.loadModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadModel.BackColor = System.Drawing.Color.White;
            this.loadModel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadModel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.loadModel.Location = new System.Drawing.Point(754, 23);
            this.loadModel.Name = "loadModel";
            this.loadModel.Size = new System.Drawing.Size(170, 29);
            this.loadModel.TabIndex = 19;
            this.loadModel.Text = "Load model";
            this.loadModel.UseVisualStyleBackColor = false;
            this.loadModel.Visible = false;
            this.loadModel.Click += new System.EventHandler(this.LoadModel_Click);
            this.loadModel.MouseEnter += new System.EventHandler(this.LoadModel_MouseEnter);
            this.loadModel.MouseLeave += new System.EventHandler(this.LoadModel_MouseLeave);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog2";
            // 
            // PredatorPreyModel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(936, 532);
            this.Controls.Add(this.loadModel);
            this.Controls.Add(this.nameInfo);
            this.Controls.Add(this.modelName);
            this.Controls.Add(this.currentValue);
            this.Controls.Add(this.coeffInfo);
            this.Controls.Add(this.coeff);
            this.Controls.Add(this.langInfo);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.ruLang);
            this.Controls.Add(this.engLang);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.saveChart);
            this.Controls.Add(this.daysInfo);
            this.Controls.Add(this.daysCount);
            this.Controls.Add(this.predatorsInfo);
            this.Controls.Add(this.preysInfo);
            this.Controls.Add(this.predatorsCount);
            this.Controls.Add(this.preysCount);
            this.Controls.Add(this.MakeChart);
            this.Controls.Add(this.plotView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PredatorPreyModel";
            this.Text = "The simulation program of predator-prey model";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PredatorPreyModel_FormClosing);
            this.SizeChanged += new System.EventHandler(this.PredatorPreyModel_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.coeff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.Button MakeChart;
        private System.Windows.Forms.TextBox preysCount;
        private System.Windows.Forms.TextBox predatorsCount;
        private System.Windows.Forms.Label preysInfo;
        private System.Windows.Forms.Label predatorsInfo;
        private System.Windows.Forms.TextBox daysCount;
        private System.Windows.Forms.Label daysInfo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button saveChart;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button engLang;
        private System.Windows.Forms.Button ruLang;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label langInfo;
        private System.Windows.Forms.TrackBar coeff;
        private System.Windows.Forms.Label coeffInfo;
        private System.Windows.Forms.Label currentValue;
        private System.Windows.Forms.TextBox modelName;
        private System.Windows.Forms.Label nameInfo;
        private System.Windows.Forms.Button loadModel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

