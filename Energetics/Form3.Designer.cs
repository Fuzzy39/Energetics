namespace Energetics
{
    partial class Form3
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
            this.player = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnReturn = new System.Windows.Forms.Button();
            this.lbl_Score = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblWinOrLose = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.White;
            this.player.Location = new System.Drawing.Point(361, 400);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(120, 30);
            this.player.TabIndex = 4;
            this.player.TabStop = false;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Yellow;
            this.ball.Location = new System.Drawing.Point(413, 374);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(20, 20);
            this.ball.TabIndex = 4;
            this.ball.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.mainGameTimerEvent);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.Gold;
            this.btnReturn.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(321, 270);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(203, 71);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Visible = false;
            this.btnReturn.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_Score
            // 
            this.lbl_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Score.Location = new System.Drawing.Point(12, 9);
            this.lbl_Score.Name = "lbl_Score";
            this.lbl_Score.Size = new System.Drawing.Size(367, 31);
            this.lbl_Score.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Gold;
            this.btnStart.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(321, 270);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(203, 71);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblWinOrLose
            // 
            this.lblWinOrLose.BackColor = System.Drawing.Color.Transparent;
            this.lblWinOrLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinOrLose.Location = new System.Drawing.Point(282, 236);
            this.lblWinOrLose.Name = "lblWinOrLose";
            this.lblWinOrLose.Size = new System.Drawing.Size(282, 31);
            this.lblWinOrLose.TabIndex = 7;
            this.lblWinOrLose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWinOrLose.Visible = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(842, 468);
            this.Controls.Add(this.lblWinOrLose);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.player);
            this.Controls.Add(this.lbl_Score);
            this.KeyPreview = true;
            this.Name = "Form3";
            this.Text = "Heat Energy";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.VisibleChanged += new System.EventHandler(this.Form3_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lbl_Score;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblWinOrLose;
    }
}