namespace Ex05.BullEyesWinFormUI
{
    public partial class TableColor
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
            this.A = new System.Windows.Forms.Button();
            this.B = new System.Windows.Forms.Button();
            this.C = new System.Windows.Forms.Button();
            this.D = new System.Windows.Forms.Button();
            this.E = new System.Windows.Forms.Button();
            this.F = new System.Windows.Forms.Button();
            this.G = new System.Windows.Forms.Button();
            this.H = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // A
            // 
            this.A.BackColor = System.Drawing.Color.Fuchsia;
            this.A.Location = new System.Drawing.Point(12, 12);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(50, 47);
            this.A.TabIndex = 0;
            this.A.UseVisualStyleBackColor = false;
            this.A.Click += new System.EventHandler(this.button_Click);
            // 
            // B
            // 
            this.B.BackColor = System.Drawing.Color.Red;
            this.B.Location = new System.Drawing.Point(68, 12);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(50, 47);
            this.B.TabIndex = 1;
            this.B.UseVisualStyleBackColor = false;
            this.B.Click += new System.EventHandler(this.button_Click);
            // 
            // C
            // 
            this.C.BackColor = System.Drawing.Color.Lime;
            this.C.Location = new System.Drawing.Point(124, 12);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(50, 47);
            this.C.TabIndex = 2;
            this.C.UseVisualStyleBackColor = false;
            this.C.Click += new System.EventHandler(this.button_Click);
            // 
            // D
            // 
            this.D.BackColor = System.Drawing.Color.Cyan;
            this.D.Location = new System.Drawing.Point(180, 12);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(50, 47);
            this.D.TabIndex = 3;
            this.D.UseVisualStyleBackColor = false;
            this.D.Click += new System.EventHandler(this.button_Click);
            // 
            // E
            // 
            this.E.BackColor = System.Drawing.Color.Blue;
            this.E.Location = new System.Drawing.Point(12, 65);
            this.E.Name = "E";
            this.E.Size = new System.Drawing.Size(50, 47);
            this.E.TabIndex = 4;
            this.E.UseVisualStyleBackColor = false;
            this.E.Click += new System.EventHandler(this.button_Click);
            // 
            // F
            // 
            this.F.BackColor = System.Drawing.Color.Yellow;
            this.F.Location = new System.Drawing.Point(68, 65);
            this.F.Name = "F";
            this.F.Size = new System.Drawing.Size(50, 47);
            this.F.TabIndex = 5;
            this.F.UseVisualStyleBackColor = false;
            this.F.Click += new System.EventHandler(this.button_Click);
            // 
            // G
            // 
            this.G.BackColor = System.Drawing.Color.Maroon;
            this.G.Location = new System.Drawing.Point(124, 65);
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(50, 47);
            this.G.TabIndex = 6;
            this.G.UseVisualStyleBackColor = false;
            this.G.Click += new System.EventHandler(this.button_Click);
            // 
            // H
            // 
            this.H.BackColor = System.Drawing.Color.White;
            this.H.Location = new System.Drawing.Point(180, 65);
            this.H.Name = "H";
            this.H.Size = new System.Drawing.Size(50, 47);
            this.H.TabIndex = 7;
            this.H.UseVisualStyleBackColor = false;
            this.H.Click += new System.EventHandler(this.button_Click);
            // 
            // TableColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 123);
            this.Controls.Add(this.H);
            this.Controls.Add(this.G);
            this.Controls.Add(this.F);
            this.Controls.Add(this.E);
            this.Controls.Add(this.D);
            this.Controls.Add(this.C);
            this.Controls.Add(this.B);
            this.Controls.Add(this.A);
            this.Name = "TableColor";
            this.Text = "Pick a color:";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button A;
        private System.Windows.Forms.Button B;
        private System.Windows.Forms.Button C;
        private System.Windows.Forms.Button D;
        private System.Windows.Forms.Button E;
        private System.Windows.Forms.Button F;
        private System.Windows.Forms.Button G;
        private System.Windows.Forms.Button H;
    }
}