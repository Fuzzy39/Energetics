namespace Energetics
{
    partial class MinesweeperTile
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
            this.lblTile.BackColor = System.Drawing.Color.DimGray;
            this.lblTile.Font = new System.Drawing.Font("Arial Black", 24F, System.Drawing.FontStyle.Bold);
            this.lblTile.ForeColor = System.Drawing.Color.White;
            this.lblTile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTile.Location = new System.Drawing.Point(2, 2);
            this.lblTile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTile.Name = "lblTile";
            this.lblTile.Size = new System.Drawing.Size(76, 76);
            this.lblTile.TabIndex = 0;
            this.lblTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTile.Click += new System.EventHandler(this.lblTile_Click);
            this.lblTile.MouseEnter += new System.EventHandler(this.lblTile_MouseEnter);
            this.lblTile.MouseLeave += new System.EventHandler(this.lblTile_MouseLeave);
            // 
            // MinesweeperTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTile);
            this.Name = "MinesweeperTile";
            this.Size = new System.Drawing.Size(80, 80);
            this.Load += new System.EventHandler(this.MinesweeperTile_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTile;
    }
}
