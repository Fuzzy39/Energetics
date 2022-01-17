namespace Energetics
{
    partial class minesweeperButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTile
            // 
            this.lblTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lblTile.Font = new System.Drawing.Font("Arial Black", 19F, System.Drawing.FontStyle.Bold);
            this.lblTile.ForeColor = System.Drawing.Color.White;
            this.lblTile.Location = new System.Drawing.Point(3, 3);
            this.lblTile.Name = "lblTile";
            this.lblTile.Size = new System.Drawing.Size(134, 54);
            this.lblTile.TabIndex = 0;
            this.lblTile.Text = "Button";
            this.lblTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTile.Click += new System.EventHandler(this.lblTile_Click);
            this.lblTile.MouseEnter += new System.EventHandler(this.lblTile_MouseEnter);
            this.lblTile.MouseLeave += new System.EventHandler(this.lblTile_MouseLeave);
            // 
            // minesweeperButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTile);
            this.Name = "minesweeperButton";
            this.Size = new System.Drawing.Size(140, 60);
            this.Load += new System.EventHandler(this.minesweeperButton_Load);
            this.ResumeLayout(false);

        }

        #endregion


        public System.Windows.Forms.Label lblTile;
    }
}
