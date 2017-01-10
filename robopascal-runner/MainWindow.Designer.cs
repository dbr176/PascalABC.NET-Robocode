namespace robopascal_runner
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.compileButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.robopascalPathTextBox = new System.Windows.Forms.TextBox();
            this.pathButton = new System.Windows.Forms.Button();
            this.logboxListBox = new System.Windows.Forms.ListBox();
            this.logboxLabel = new System.Windows.Forms.Label();
            this.robopascalLabel = new System.Windows.Forms.Label();
            this.defaultPathButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // compileButton
            // 
            this.compileButton.Location = new System.Drawing.Point(12, 80);
            this.compileButton.Name = "compileButton";
            this.compileButton.Size = new System.Drawing.Size(312, 23);
            this.compileButton.TabIndex = 0;
            this.compileButton.Text = "Скомпилировать роботов";
            this.compileButton.UseVisualStyleBackColor = true;
            this.compileButton.Click += new System.EventHandler(this.compileButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(330, 80);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(312, 23);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Запустить Robocode";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // robopascalPathTextBox
            // 
            this.robopascalPathTextBox.Location = new System.Drawing.Point(12, 25);
            this.robopascalPathTextBox.Name = "robopascalPathTextBox";
            this.robopascalPathTextBox.Size = new System.Drawing.Size(630, 20);
            this.robopascalPathTextBox.TabIndex = 2;
            // 
            // pathButton
            // 
            this.pathButton.Location = new System.Drawing.Point(12, 51);
            this.pathButton.Name = "pathButton";
            this.pathButton.Size = new System.Drawing.Size(312, 23);
            this.pathButton.TabIndex = 3;
            this.pathButton.Text = "Выбрать каталог";
            this.pathButton.UseVisualStyleBackColor = true;
            this.pathButton.Click += new System.EventHandler(this.pathButton_Click);
            // 
            // logboxListBox
            // 
            this.logboxListBox.FormattingEnabled = true;
            this.logboxListBox.Location = new System.Drawing.Point(12, 122);
            this.logboxListBox.Name = "logboxListBox";
            this.logboxListBox.Size = new System.Drawing.Size(630, 134);
            this.logboxListBox.TabIndex = 4;
            // 
            // logboxLabel
            // 
            this.logboxLabel.AutoSize = true;
            this.logboxLabel.Location = new System.Drawing.Point(12, 106);
            this.logboxLabel.Name = "logboxLabel";
            this.logboxLabel.Size = new System.Drawing.Size(110, 13);
            this.logboxLabel.TabIndex = 5;
            this.logboxLabel.Text = "Отчет о компиляции";
            // 
            // robopascalLabel
            // 
            this.robopascalLabel.AutoSize = true;
            this.robopascalLabel.Location = new System.Drawing.Point(12, 9);
            this.robopascalLabel.Name = "robopascalLabel";
            this.robopascalLabel.Size = new System.Drawing.Size(109, 13);
            this.robopascalLabel.TabIndex = 6;
            this.robopascalLabel.Text = "Каталог с роботами";
            // 
            // defaultPathButton
            // 
            this.defaultPathButton.Location = new System.Drawing.Point(330, 51);
            this.defaultPathButton.Name = "defaultPathButton";
            this.defaultPathButton.Size = new System.Drawing.Size(312, 23);
            this.defaultPathButton.TabIndex = 7;
            this.defaultPathButton.Text = "Стандартный каталог";
            this.defaultPathButton.UseVisualStyleBackColor = true;
            this.defaultPathButton.Click += new System.EventHandler(this.defaultPathButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 262);
            this.Controls.Add(this.defaultPathButton);
            this.Controls.Add(this.robopascalLabel);
            this.Controls.Add(this.logboxLabel);
            this.Controls.Add(this.logboxListBox);
            this.Controls.Add(this.pathButton);
            this.Controls.Add(this.robopascalPathTextBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.compileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Запуск RoboPascal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button compileButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TextBox robopascalPathTextBox;
        private System.Windows.Forms.Button pathButton;
        private System.Windows.Forms.ListBox logboxListBox;
        private System.Windows.Forms.Label logboxLabel;
        private System.Windows.Forms.Label robopascalLabel;
        private System.Windows.Forms.Button defaultPathButton;
    }
}

