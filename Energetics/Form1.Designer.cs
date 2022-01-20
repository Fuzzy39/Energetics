namespace Energetics
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
            this.lblTemporary = new System.Windows.Forms.Label();
            this.btnKinetic = new Energetics.minesweeperButton();
            this.btnNuclear = new Energetics.minesweeperButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblTemporary
            // 
            this.lblTemporary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(170)))), ((int)(((byte)(160)))));
            this.lblTemporary.Font = new System.Drawing.Font("Arial", 32F);
            this.lblTemporary.ForeColor = System.Drawing.Color.White;
            this.lblTemporary.Location = new System.Drawing.Point(8, 205);
            this.lblTemporary.Name = "lblTemporary";
            this.lblTemporary.Size = new System.Drawing.Size(564, 101);
            this.lblTemporary.TabIndex = 0;
            this.lblTemporary.Text = "Energetics";
            this.lblTemporary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTemporary.VisibleChanged += new System.EventHandler(this.lblTemporary_VisibleChanged);
            // 
            // btnKinetic
            // 
            this.btnKinetic.BackColor = System.Drawing.Color.White;
            this.btnKinetic.Location = new System.Drawing.Point(12, 12);
            this.btnKinetic.Name = "btnKinetic";
            this.btnKinetic.Size = new System.Drawing.Size(560, 190);
            this.btnKinetic.TabIndex = 3;
            this.btnKinetic.Click += new System.EventHandler(this.btnKinetic_Click);
            // 
            // btnNuclear
            // 
            this.btnNuclear.BackColor = System.Drawing.Color.White;
            this.btnNuclear.Location = new System.Drawing.Point(12, 309);
            this.btnNuclear.Name = "btnNuclear";
            this.btnNuclear.Size = new System.Drawing.Size(560, 190);
            this.btnNuclear.TabIndex = 4;
            this.btnNuclear.Click += new System.EventHandler(this.btnNuclear_Click_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 32;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(170)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(584, 511);
            this.Controls.Add(this.btnNuclear);
            this.Controls.Add(this.btnKinetic);
            this.Controls.Add(this.lblTemporary);
            this.Name = "Form1";
            this.Text = "Energetics";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTemporary;
        private minesweeperButton btnKinetic;
        private minesweeperButton btnNuclear;
        private System.Windows.Forms.Timer timer1;
    }
}

