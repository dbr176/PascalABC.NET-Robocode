namespace robopascal_runner
{
    partial class QuickMatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickMatch));
            this.runButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.roundsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.resolutionComboBox = new System.Windows.Forms.ComboBox();
            this.resoultionLabel = new System.Windows.Forms.Label();
            this.robotListCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.robotListLabel = new System.Windows.Forms.Label();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.deselectButton = new System.Windows.Forms.Button();
            this.inactiveLabel = new System.Windows.Forms.Label();
            this.inactiveNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.hideNamesCheckBox = new System.Windows.Forms.CheckBox();
            this.coolRateLabel = new System.Windows.Forms.Label();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.coolRateTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.roundsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inactiveNumericUpDown)).BeginInit();
            this.optionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(12, 349);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(277, 23);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Запуск";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество раундов";
            // 
            // roundsNumericUpDown
            // 
            this.roundsNumericUpDown.Location = new System.Drawing.Point(155, 14);
            this.roundsNumericUpDown.Name = "roundsNumericUpDown";
            this.roundsNumericUpDown.Size = new System.Drawing.Size(116, 20);
            this.roundsNumericUpDown.TabIndex = 1;
            this.roundsNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // resolutionComboBox
            // 
            this.resolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resolutionComboBox.FormattingEnabled = true;
            this.resolutionComboBox.Items.AddRange(new object[] {
            "640x480",
            "800x600",
            "1024x768",
            "1280x720",
            "1400x900"});
            this.resolutionComboBox.Location = new System.Drawing.Point(155, 43);
            this.resolutionComboBox.Name = "resolutionComboBox";
            this.resolutionComboBox.Size = new System.Drawing.Size(116, 21);
            this.resolutionComboBox.TabIndex = 2;
            // 
            // resoultionLabel
            // 
            this.resoultionLabel.AutoSize = true;
            this.resoultionLabel.Location = new System.Drawing.Point(6, 46);
            this.resoultionLabel.Name = "resoultionLabel";
            this.resoultionLabel.Size = new System.Drawing.Size(70, 13);
            this.resoultionLabel.TabIndex = 3;
            this.resoultionLabel.Text = "Разрешение";
            // 
            // robotListCheckedListBox
            // 
            this.robotListCheckedListBox.FormattingEnabled = true;
            this.robotListCheckedListBox.Location = new System.Drawing.Point(9, 164);
            this.robotListCheckedListBox.Name = "robotListCheckedListBox";
            this.robotListCheckedListBox.Size = new System.Drawing.Size(262, 109);
            this.robotListCheckedListBox.TabIndex = 4;
            // 
            // robotListLabel
            // 
            this.robotListLabel.AutoSize = true;
            this.robotListLabel.Location = new System.Drawing.Point(9, 145);
            this.robotListLabel.Name = "robotListLabel";
            this.robotListLabel.Size = new System.Drawing.Size(104, 13);
            this.robotListLabel.TabIndex = 5;
            this.robotListLabel.Text = "Список участников";
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(9, 279);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(104, 23);
            this.selectAllButton.TabIndex = 6;
            this.selectAllButton.Text = "Выбрать всех";
            this.selectAllButton.UseVisualStyleBackColor = true;
            // 
            // deselectButton
            // 
            this.deselectButton.Location = new System.Drawing.Point(161, 279);
            this.deselectButton.Name = "deselectButton";
            this.deselectButton.Size = new System.Drawing.Size(110, 23);
            this.deselectButton.TabIndex = 7;
            this.deselectButton.Text = "Сброс";
            this.deselectButton.UseVisualStyleBackColor = true;
            // 
            // inactiveLabel
            // 
            this.inactiveLabel.AutoSize = true;
            this.inactiveLabel.Location = new System.Drawing.Point(9, 72);
            this.inactiveLabel.Name = "inactiveLabel";
            this.inactiveLabel.Size = new System.Drawing.Size(140, 13);
            this.inactiveLabel.TabIndex = 8;
            this.inactiveLabel.Text = "Макс. время бездействия";
            // 
            // inactiveNumericUpDown
            // 
            this.inactiveNumericUpDown.Location = new System.Drawing.Point(155, 70);
            this.inactiveNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.inactiveNumericUpDown.Name = "inactiveNumericUpDown";
            this.inactiveNumericUpDown.Size = new System.Drawing.Size(116, 20);
            this.inactiveNumericUpDown.TabIndex = 9;
            this.inactiveNumericUpDown.Value = new decimal(new int[] {
            450,
            0,
            0,
            0});
            // 
            // hideNamesCheckBox
            // 
            this.hideNamesCheckBox.AutoSize = true;
            this.hideNamesCheckBox.Location = new System.Drawing.Point(83, 308);
            this.hideNamesCheckBox.Name = "hideNamesCheckBox";
            this.hideNamesCheckBox.Size = new System.Drawing.Size(108, 17);
            this.hideNamesCheckBox.TabIndex = 10;
            this.hideNamesCheckBox.Text = "Спрятать имена";
            this.hideNamesCheckBox.UseVisualStyleBackColor = true;
            // 
            // coolRateLabel
            // 
            this.coolRateLabel.AutoSize = true;
            this.coolRateLabel.Location = new System.Drawing.Point(9, 98);
            this.coolRateLabel.Name = "coolRateLabel";
            this.coolRateLabel.Size = new System.Drawing.Size(136, 13);
            this.coolRateLabel.TabIndex = 11;
            this.coolRateLabel.Text = "Время остывания орудия";
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Controls.Add(this.pictureBox1);
            this.optionsGroupBox.Controls.Add(this.coolRateTextBox);
            this.optionsGroupBox.Controls.Add(this.coolRateLabel);
            this.optionsGroupBox.Controls.Add(this.hideNamesCheckBox);
            this.optionsGroupBox.Controls.Add(this.inactiveNumericUpDown);
            this.optionsGroupBox.Controls.Add(this.inactiveLabel);
            this.optionsGroupBox.Controls.Add(this.deselectButton);
            this.optionsGroupBox.Controls.Add(this.selectAllButton);
            this.optionsGroupBox.Controls.Add(this.robotListLabel);
            this.optionsGroupBox.Controls.Add(this.robotListCheckedListBox);
            this.optionsGroupBox.Controls.Add(this.resoultionLabel);
            this.optionsGroupBox.Controls.Add(this.resolutionComboBox);
            this.optionsGroupBox.Controls.Add(this.roundsNumericUpDown);
            this.optionsGroupBox.Controls.Add(this.label1);
            this.optionsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(277, 331);
            this.optionsGroupBox.TabIndex = 0;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Настройки боя";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(125, 280);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // coolRateTextBox
            // 
            this.coolRateTextBox.Location = new System.Drawing.Point(155, 98);
            this.coolRateTextBox.Name = "coolRateTextBox";
            this.coolRateTextBox.Size = new System.Drawing.Size(116, 20);
            this.coolRateTextBox.TabIndex = 12;
            this.coolRateTextBox.Text = "0.1";
            this.coolRateTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.coolRateTextBox_KeyDown);
            // 
            // RunBattle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 384);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.optionsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RunBattle";
            this.Text = "Быстрый бой";
            ((System.ComponentModel.ISupportInitialize)(this.roundsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inactiveNumericUpDown)).EndInit();
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown roundsNumericUpDown;
        private System.Windows.Forms.ComboBox resolutionComboBox;
        private System.Windows.Forms.Label resoultionLabel;
        private System.Windows.Forms.CheckedListBox robotListCheckedListBox;
        private System.Windows.Forms.Label robotListLabel;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button deselectButton;
        private System.Windows.Forms.Label inactiveLabel;
        private System.Windows.Forms.NumericUpDown inactiveNumericUpDown;
        private System.Windows.Forms.CheckBox hideNamesCheckBox;
        private System.Windows.Forms.Label coolRateLabel;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.TextBox coolRateTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}