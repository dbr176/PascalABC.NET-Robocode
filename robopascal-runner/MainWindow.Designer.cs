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
            this.logboxListBox = new System.Windows.Forms.ListBox();
            this.logboxLabel = new System.Windows.Forms.Label();
            this.openPathButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // compileButton
            // 
            this.compileButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.compileButton.Location = new System.Drawing.Point(12, 12);
            this.compileButton.Name = "compileButton";
            this.compileButton.Size = new System.Drawing.Size(315, 23);
            this.compileButton.TabIndex = 0;
            this.compileButton.Text = "Скомпилировать роботов";
            this.compileButton.UseVisualStyleBackColor = true;
            this.compileButton.Click += new System.EventHandler(this.compileButton_Click);
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.runButton.Location = new System.Drawing.Point(12, 41);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(315, 23);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Запустить Robocode";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // logboxListBox
            // 
            this.logboxListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logboxListBox.FormattingEnabled = true;
            this.logboxListBox.Location = new System.Drawing.Point(12, 93);
            this.logboxListBox.Name = "logboxListBox";
            this.logboxListBox.Size = new System.Drawing.Size(315, 147);
            this.logboxListBox.TabIndex = 4;
            // 
            // logboxLabel
            // 
            this.logboxLabel.AutoSize = true;
            this.logboxLabel.Location = new System.Drawing.Point(9, 67);
            this.logboxLabel.Name = "logboxLabel";
            this.logboxLabel.Size = new System.Drawing.Size(110, 13);
            this.logboxLabel.TabIndex = 5;
            this.logboxLabel.Text = "Отчет о компиляции";
            // 
            // openPathButton
            // 
            this.openPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openPathButton.Location = new System.Drawing.Point(12, 253);
            this.openPathButton.Name = "openPathButton";
            this.openPathButton.Size = new System.Drawing.Size(315, 23);
            this.openPathButton.TabIndex = 7;
            this.openPathButton.Text = "Открыть каталог роботов";
            this.openPathButton.UseVisualStyleBackColor = true;
            this.openPathButton.Click += new System.EventHandler(this.openPathButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 282);
            this.Controls.Add(this.openPathButton);
            this.Controls.Add(this.logboxLabel);
            this.Controls.Add(this.logboxListBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.compileButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Запуск RoboPascal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button compileButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.ListBox logboxListBox;
        private System.Windows.Forms.Label logboxLabel;
        private System.Windows.Forms.Button openPathButton;
    }
}

