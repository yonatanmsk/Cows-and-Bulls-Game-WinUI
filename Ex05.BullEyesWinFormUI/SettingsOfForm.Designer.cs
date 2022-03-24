namespace Ex05.BullEyesWinFormUI
{
    public partial class SettingsOfForm
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
            if(disposing && (components != null))
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
            this.NumberOfChancesButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NumberOfChancesButton
            // 
            this.NumberOfChancesButton.Location = new System.Drawing.Point(18, 24);
            this.NumberOfChancesButton.Name = "NumberOfChancesButton";
            this.NumberOfChancesButton.Size = new System.Drawing.Size(274, 31);
            this.NumberOfChancesButton.TabIndex = 0;
            this.NumberOfChancesButton.Text = "Number of chances: 4";
            this.NumberOfChancesButton.UseVisualStyleBackColor = true;
            this.NumberOfChancesButton.Click += new System.EventHandler(this.sizeBoardButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(193, 79);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(99, 31);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // SettingsOfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 122);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.NumberOfChancesButton);
            this.Name = "SettingsOfForm";
            this.Text = "Cows and Bulls";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NumberOfChancesButton;
        private System.Windows.Forms.Button StartButton;
    }
}