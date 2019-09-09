namespace RobotiqueEtMecatronique
{
    partial class Interface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interface));
            this.buttonStart = new System.Windows.Forms.Button();
            this.Serial = new System.IO.Ports.SerialPort(this.components);
            this.trackBarDegre = new System.Windows.Forms.TrackBar();
            this.BoxPort = new System.Windows.Forms.ComboBox();
            this.numericMin = new System.Windows.Forms.NumericUpDown();
            this.numericMax = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericSensitivity = new System.Windows.Forms.NumericUpDown();
            this.labelDegre = new System.Windows.Forms.Label();
            this.checkBoxInterruption = new System.Windows.Forms.CheckBox();
            this.checkBoxReset = new System.Windows.Forms.CheckBox();
            this.checkBoxPressure = new System.Windows.Forms.CheckBox();
            this.labelPressure = new System.Windows.Forms.Label();
            this.checkBoxControl = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxClose = new System.Windows.Forms.CheckBox();
            this.checkBoxOpen = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBoxFiche = new System.Windows.Forms.PictureBox();
            this.labelFiche = new System.Windows.Forms.Label();
            this.checkBoxRigide = new System.Windows.Forms.CheckBox();
            this.checkBoxSemiRigide = new System.Windows.Forms.CheckBox();
            this.checkBoxFragile = new System.Windows.Forms.CheckBox();
            this.checkBoxPersonnalisé = new System.Windows.Forms.CheckBox();
            this.labelTypeObjet = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDegre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFiche)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Transparent;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(15, 142);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(144, 38);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Lancer";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Serial
            // 
            this.Serial.PortName = "undefined";
            // 
            // trackBarDegre
            // 
            this.trackBarDegre.Enabled = false;
            this.trackBarDegre.LargeChange = 1;
            this.trackBarDegre.Location = new System.Drawing.Point(3, 277);
            this.trackBarDegre.Maximum = 120;
            this.trackBarDegre.Name = "trackBarDegre";
            this.trackBarDegre.Size = new System.Drawing.Size(622, 56);
            this.trackBarDegre.TabIndex = 1;
            this.trackBarDegre.Visible = false;
            this.trackBarDegre.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // BoxPort
            // 
            this.BoxPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BoxPort.FormattingEnabled = true;
            this.BoxPort.Location = new System.Drawing.Point(15, 32);
            this.BoxPort.Name = "BoxPort";
            this.BoxPort.Size = new System.Drawing.Size(147, 24);
            this.BoxPort.TabIndex = 2;
            // 
            // numericMin
            // 
            this.numericMin.Enabled = false;
            this.numericMin.Location = new System.Drawing.Point(12, 249);
            this.numericMin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericMin.Name = "numericMin";
            this.numericMin.Size = new System.Drawing.Size(84, 22);
            this.numericMin.TabIndex = 3;
            this.numericMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericMin.Visible = false;
            this.numericMin.ValueChanged += new System.EventHandler(this.numericMin_ValueChanged);
            // 
            // numericMax
            // 
            this.numericMax.Enabled = false;
            this.numericMax.Location = new System.Drawing.Point(526, 249);
            this.numericMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericMax.Name = "numericMax";
            this.numericMax.Size = new System.Drawing.Size(84, 22);
            this.numericMax.TabIndex = 4;
            this.numericMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericMax.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericMax.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choisir le port";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.BackColor = System.Drawing.Color.Transparent;
            this.labelMin.Enabled = false;
            this.labelMin.Location = new System.Drawing.Point(98, 251);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(103, 17);
            this.labelMin.TabIndex = 6;
            this.labelMin.Text = "Angle minimum";
            this.labelMin.Visible = false;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.BackColor = System.Drawing.Color.Transparent;
            this.labelMax.Enabled = false;
            this.labelMax.Location = new System.Drawing.Point(418, 251);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(106, 17);
            this.labelMax.TabIndex = 7;
            this.labelMax.Text = "Angle maximum";
            this.labelMax.Visible = false;
            this.labelMax.Click += new System.EventHandler(this.labelMax_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(14, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sensibilité FSR (%)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericSensitivity
            // 
            this.numericSensitivity.Enabled = false;
            this.numericSensitivity.Location = new System.Drawing.Point(15, 98);
            this.numericSensitivity.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericSensitivity.Name = "numericSensitivity";
            this.numericSensitivity.Size = new System.Drawing.Size(151, 22);
            this.numericSensitivity.TabIndex = 9;
            this.numericSensitivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericSensitivity.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericSensitivity.ValueChanged += new System.EventHandler(this.numericSensitivity_ValueChanged);
            // 
            // labelDegre
            // 
            this.labelDegre.AutoSize = true;
            this.labelDegre.BackColor = System.Drawing.Color.Transparent;
            this.labelDegre.Enabled = false;
            this.labelDegre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDegre.Location = new System.Drawing.Point(290, 245);
            this.labelDegre.Name = "labelDegre";
            this.labelDegre.Size = new System.Drawing.Size(21, 24);
            this.labelDegre.TabIndex = 10;
            this.labelDegre.Text = "0";
            this.labelDegre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDegre.Visible = false;
            // 
            // checkBoxInterruption
            // 
            this.checkBoxInterruption.AutoSize = true;
            this.checkBoxInterruption.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxInterruption.Location = new System.Drawing.Point(344, 54);
            this.checkBoxInterruption.Name = "checkBoxInterruption";
            this.checkBoxInterruption.Size = new System.Drawing.Size(102, 21);
            this.checkBoxInterruption.TabIndex = 11;
            this.checkBoxInterruption.Text = "Interruption";
            this.checkBoxInterruption.UseVisualStyleBackColor = false;
            this.checkBoxInterruption.Visible = false;
            this.checkBoxInterruption.CheckedChanged += new System.EventHandler(this.checkBoxInterruption_CheckedChanged);
            // 
            // checkBoxReset
            // 
            this.checkBoxReset.AutoSize = true;
            this.checkBoxReset.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxReset.Location = new System.Drawing.Point(344, 77);
            this.checkBoxReset.Name = "checkBoxReset";
            this.checkBoxReset.Size = new System.Drawing.Size(160, 21);
            this.checkBoxReset.TabIndex = 12;
            this.checkBoxReset.Text = "Réinitialisation angle";
            this.checkBoxReset.UseVisualStyleBackColor = false;
            this.checkBoxReset.Visible = false;
            this.checkBoxReset.CheckedChanged += new System.EventHandler(this.checkBoxReset_CheckedChanged);
            // 
            // checkBoxPressure
            // 
            this.checkBoxPressure.AutoSize = true;
            this.checkBoxPressure.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxPressure.Enabled = false;
            this.checkBoxPressure.Location = new System.Drawing.Point(344, 142);
            this.checkBoxPressure.Name = "checkBoxPressure";
            this.checkBoxPressure.Size = new System.Drawing.Size(102, 21);
            this.checkBoxPressure.TabIndex = 13;
            this.checkBoxPressure.Text = "Interruption";
            this.checkBoxPressure.UseVisualStyleBackColor = false;
            this.checkBoxPressure.Visible = false;
            // 
            // labelPressure
            // 
            this.labelPressure.AutoSize = true;
            this.labelPressure.BackColor = System.Drawing.Color.Transparent;
            this.labelPressure.Location = new System.Drawing.Point(341, 122);
            this.labelPressure.Name = "labelPressure";
            this.labelPressure.Size = new System.Drawing.Size(102, 17);
            this.labelPressure.TabIndex = 14;
            this.labelPressure.Text = "Pression FSR :";
            this.labelPressure.Visible = false;
            // 
            // checkBoxControl
            // 
            this.checkBoxControl.AutoSize = true;
            this.checkBoxControl.Location = new System.Drawing.Point(12, 222);
            this.checkBoxControl.Name = "checkBoxControl";
            this.checkBoxControl.Size = new System.Drawing.Size(133, 21);
            this.checkBoxControl.TabIndex = 15;
            this.checkBoxControl.Text = "Contrôle manuel";
            this.checkBoxControl.UseVisualStyleBackColor = true;
            this.checkBoxControl.Visible = false;
            this.checkBoxControl.CheckedChanged += new System.EventHandler(this.checkBoxControl_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBoxClose
            // 
            this.checkBoxClose.AutoSize = true;
            this.checkBoxClose.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxClose.Location = new System.Drawing.Point(344, 99);
            this.checkBoxClose.Name = "checkBoxClose";
            this.checkBoxClose.Size = new System.Drawing.Size(95, 21);
            this.checkBoxClose.TabIndex = 16;
            this.checkBoxClose.Text = "Fermeture";
            this.checkBoxClose.UseVisualStyleBackColor = false;
            this.checkBoxClose.Visible = false;
            this.checkBoxClose.CheckedChanged += new System.EventHandler(this.checkBoxClose_CheckedChanged);
            // 
            // checkBoxOpen
            // 
            this.checkBoxOpen.AutoSize = true;
            this.checkBoxOpen.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxOpen.Location = new System.Drawing.Point(474, 98);
            this.checkBoxOpen.Name = "checkBoxOpen";
            this.checkBoxOpen.Size = new System.Drawing.Size(94, 21);
            this.checkBoxOpen.TabIndex = 17;
            this.checkBoxOpen.Text = "Ouverture";
            this.checkBoxOpen.UseVisualStyleBackColor = false;
            this.checkBoxOpen.Visible = false;
            this.checkBoxOpen.CheckedChanged += new System.EventHandler(this.checkBoxOpen_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(643, 42);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(189, 179);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(643, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 15);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "Commandes Vocales :";
            // 
            // pictureBoxFiche
            // 
            this.pictureBoxFiche.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxFiche.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxFiche.BackgroundImage")));
            this.pictureBoxFiche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxFiche.Location = new System.Drawing.Point(791, 270);
            this.pictureBoxFiche.Name = "pictureBoxFiche";
            this.pictureBoxFiche.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxFiche.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxFiche.TabIndex = 21;
            this.pictureBoxFiche.TabStop = false;
            this.pictureBoxFiche.Click += new System.EventHandler(this.pictureBoxFiche_Click);
            // 
            // labelFiche
            // 
            this.labelFiche.AutoSize = true;
            this.labelFiche.Location = new System.Drawing.Point(677, 263);
            this.labelFiche.Name = "labelFiche";
            this.labelFiche.Size = new System.Drawing.Size(104, 34);
            this.labelFiche.TabIndex = 22;
            this.labelFiche.Text = "Télécharger \r\nfiche technique";
            // 
            // checkBoxRigide
            // 
            this.checkBoxRigide.AutoSize = true;
            this.checkBoxRigide.Location = new System.Drawing.Point(204, 77);
            this.checkBoxRigide.Name = "checkBoxRigide";
            this.checkBoxRigide.Size = new System.Drawing.Size(70, 21);
            this.checkBoxRigide.TabIndex = 23;
            this.checkBoxRigide.Text = "Rigide";
            this.checkBoxRigide.UseVisualStyleBackColor = true;
            this.checkBoxRigide.CheckedChanged += new System.EventHandler(this.checkBoxRigide_CheckedChanged);
            // 
            // checkBoxSemiRigide
            // 
            this.checkBoxSemiRigide.AutoSize = true;
            this.checkBoxSemiRigide.Location = new System.Drawing.Point(204, 98);
            this.checkBoxSemiRigide.Name = "checkBoxSemiRigide";
            this.checkBoxSemiRigide.Size = new System.Drawing.Size(101, 21);
            this.checkBoxSemiRigide.TabIndex = 24;
            this.checkBoxSemiRigide.Text = "Semi-rigide";
            this.checkBoxSemiRigide.UseVisualStyleBackColor = true;
            this.checkBoxSemiRigide.CheckedChanged += new System.EventHandler(this.checkBoxSemiRigide_CheckedChanged);
            // 
            // checkBoxFragile
            // 
            this.checkBoxFragile.AutoSize = true;
            this.checkBoxFragile.Location = new System.Drawing.Point(204, 118);
            this.checkBoxFragile.Name = "checkBoxFragile";
            this.checkBoxFragile.Size = new System.Drawing.Size(73, 21);
            this.checkBoxFragile.TabIndex = 25;
            this.checkBoxFragile.Text = "Fragile";
            this.checkBoxFragile.UseVisualStyleBackColor = true;
            this.checkBoxFragile.CheckedChanged += new System.EventHandler(this.checkBoxFragile_CheckedChanged);
            // 
            // checkBoxPersonnalisé
            // 
            this.checkBoxPersonnalisé.AutoSize = true;
            this.checkBoxPersonnalisé.Location = new System.Drawing.Point(204, 145);
            this.checkBoxPersonnalisé.Name = "checkBoxPersonnalisé";
            this.checkBoxPersonnalisé.Size = new System.Drawing.Size(112, 21);
            this.checkBoxPersonnalisé.TabIndex = 26;
            this.checkBoxPersonnalisé.Text = "Personnalisé";
            this.checkBoxPersonnalisé.UseVisualStyleBackColor = true;
            this.checkBoxPersonnalisé.CheckedChanged += new System.EventHandler(this.checkBoxPersonnalisé_CheckedChanged);
            // 
            // labelTypeObjet
            // 
            this.labelTypeObjet.AutoSize = true;
            this.labelTypeObjet.Location = new System.Drawing.Point(201, 54);
            this.labelTypeObjet.Name = "labelTypeObjet";
            this.labelTypeObjet.Size = new System.Drawing.Size(94, 17);
            this.labelTypeObjet.TabIndex = 27;
            this.labelTypeObjet.Text = "Type d\'objet :";
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(842, 333);
            this.Controls.Add(this.labelTypeObjet);
            this.Controls.Add(this.checkBoxPersonnalisé);
            this.Controls.Add(this.checkBoxFragile);
            this.Controls.Add(this.checkBoxSemiRigide);
            this.Controls.Add(this.checkBoxRigide);
            this.Controls.Add(this.labelFiche);
            this.Controls.Add(this.pictureBoxFiche);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.checkBoxOpen);
            this.Controls.Add(this.checkBoxClose);
            this.Controls.Add(this.checkBoxControl);
            this.Controls.Add(this.labelPressure);
            this.Controls.Add(this.checkBoxPressure);
            this.Controls.Add(this.checkBoxReset);
            this.Controls.Add(this.checkBoxInterruption);
            this.Controls.Add(this.labelDegre);
            this.Controls.Add(this.numericSensitivity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericMax);
            this.Controls.Add(this.numericMin);
            this.Controls.Add(this.BoxPort);
            this.Controls.Add(this.trackBarDegre);
            this.Controls.Add(this.buttonStart);
            this.Name = "Interface";
            this.Text = "Interface Pince";
            this.Load += new System.EventHandler(this.Interface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDegre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFiche)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TrackBar trackBarDegre;
        private System.Windows.Forms.ComboBox BoxPort;
        private System.Windows.Forms.NumericUpDown numericMin;
        private System.Windows.Forms.NumericUpDown numericMax;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelMax;
        public System.IO.Ports.SerialPort Serial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericSensitivity;
        private System.Windows.Forms.Label labelDegre;
        private System.Windows.Forms.CheckBox checkBoxReset;
        private System.Windows.Forms.CheckBox checkBoxPressure;
        private System.Windows.Forms.Label labelPressure;
        private System.Windows.Forms.CheckBox checkBoxInterruption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxControl;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxClose;
        private System.Windows.Forms.CheckBox checkBoxOpen;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBoxFiche;
        private System.Windows.Forms.Label labelFiche;
        private System.Windows.Forms.CheckBox checkBoxRigide;
        private System.Windows.Forms.CheckBox checkBoxSemiRigide;
        private System.Windows.Forms.CheckBox checkBoxFragile;
        private System.Windows.Forms.CheckBox checkBoxPersonnalisé;
        private System.Windows.Forms.Label labelTypeObjet;
    }
}

