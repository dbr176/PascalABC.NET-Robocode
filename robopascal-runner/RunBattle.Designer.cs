namespace robopascal_runner
{
    partial class RunBattle
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
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(337, 162);
            this.optionsGroupBox.TabIndex = 0;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Настройки боя";
            // 
            // RunBattle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 442);
            this.Controls.Add(this.optionsGroupBox);
            this.Name = "RunBattle";
            this.Text = "Быстрый бой";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox optionsGroupBox;
    }
}