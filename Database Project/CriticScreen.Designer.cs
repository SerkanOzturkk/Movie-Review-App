namespace Database_Project
{
    partial class CriticScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CriticScreen));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxCriticism = new System.Windows.Forms.PictureBox();
            this.pictureBoxMovies = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCriticism)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMovies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(352, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 28);
            this.label3.TabIndex = 15;
            this.label3.Text = "MY CRITICISMS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(157, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 28);
            this.label2.TabIndex = 14;
            this.label2.Text = "MOVIES";
            // 
            // pictureBoxCriticism
            // 
            this.pictureBoxCriticism.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxCriticism.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCriticism.Image")));
            this.pictureBoxCriticism.Location = new System.Drawing.Point(366, 103);
            this.pictureBoxCriticism.Name = "pictureBoxCriticism";
            this.pictureBoxCriticism.Size = new System.Drawing.Size(110, 79);
            this.pictureBoxCriticism.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCriticism.TabIndex = 13;
            this.pictureBoxCriticism.TabStop = false;
            this.pictureBoxCriticism.Click += new System.EventHandler(this.pictureBoxCriticism_Click);
            // 
            // pictureBoxMovies
            // 
            this.pictureBoxMovies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMovies.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMovies.Image")));
            this.pictureBoxMovies.Location = new System.Drawing.Point(143, 103);
            this.pictureBoxMovies.Name = "pictureBoxMovies";
            this.pictureBoxMovies.Size = new System.Drawing.Size(109, 79);
            this.pictureBoxMovies.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMovies.TabIndex = 12;
            this.pictureBoxMovies.TabStop = false;
            this.pictureBoxMovies.Click += new System.EventHandler(this.pictureBoxMovies_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(592, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(41, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 31;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // CriticScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.ClientSize = new System.Drawing.Size(636, 345);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBoxCriticism);
            this.Controls.Add(this.pictureBoxMovies);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CriticScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CriticScreen";
            this.Load += new System.EventHandler(this.CriticScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCriticism)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMovies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxCriticism;
        private System.Windows.Forms.PictureBox pictureBoxMovies;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}