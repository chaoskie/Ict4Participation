namespace Ict4Participation
{
    partial class PlaatsReview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaatsReview));
            this.cbHulpverlener = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.btnPlaceReview = new System.Windows.Forms.Button();
            this.nudStar = new System.Windows.Forms.NumericUpDown();
            this.pbStar1 = new System.Windows.Forms.PictureBox();
            this.pbStar2 = new System.Windows.Forms.PictureBox();
            this.pbStar3 = new System.Windows.Forms.PictureBox();
            this.pbStar4 = new System.Windows.Forms.PictureBox();
            this.pbStar5 = new System.Windows.Forms.PictureBox();
            this.StarsPanel = new System.Windows.Forms.Panel();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudStar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar5)).BeginInit();
            this.StarsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbHulpverlener
            // 
            this.cbHulpverlener.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbHulpverlener.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbHulpverlener.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHulpverlener.FormattingEnabled = true;
            this.cbHulpverlener.Location = new System.Drawing.Point(116, 6);
            this.cbHulpverlener.Name = "cbHulpverlener";
            this.cbHulpverlener.Size = new System.Drawing.Size(206, 28);
            this.cbHulpverlener.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hulpverlener:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Aantal sterren:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Review:";
            // 
            // tbDescription
            // 
            this.tbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescription.Location = new System.Drawing.Point(10, 154);
            this.tbDescription.MaxLength = 255;
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(312, 111);
            this.tbDescription.TabIndex = 4;
            // 
            // btnPlaceReview
            // 
            this.btnPlaceReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaceReview.Location = new System.Drawing.Point(10, 271);
            this.btnPlaceReview.Name = "btnPlaceReview";
            this.btnPlaceReview.Size = new System.Drawing.Size(312, 67);
            this.btnPlaceReview.TabIndex = 5;
            this.btnPlaceReview.Text = "Plaats review";
            this.btnPlaceReview.UseVisualStyleBackColor = true;
            this.btnPlaceReview.Click += new System.EventHandler(this.btnPlaceReview_Click);
            // 
            // nudStar
            // 
            this.nudStar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nudStar.Location = new System.Drawing.Point(12, 103);
            this.nudStar.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudStar.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStar.Name = "nudStar";
            this.nudStar.Size = new System.Drawing.Size(50, 26);
            this.nudStar.TabIndex = 6;
            this.nudStar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStar.ValueChanged += new System.EventHandler(this.nudStar_ValueChanged);
            // 
            // pbStar1
            // 
            this.pbStar1.Image = ((System.Drawing.Image)(resources.GetObject("pbStar1.Image")));
            this.pbStar1.Location = new System.Drawing.Point(3, 0);
            this.pbStar1.Name = "pbStar1";
            this.pbStar1.Size = new System.Drawing.Size(30, 30);
            this.pbStar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStar1.TabIndex = 7;
            this.pbStar1.TabStop = false;
            this.pbStar1.Visible = false;
            // 
            // pbStar2
            // 
            this.pbStar2.Image = ((System.Drawing.Image)(resources.GetObject("pbStar2.Image")));
            this.pbStar2.Location = new System.Drawing.Point(39, 0);
            this.pbStar2.Name = "pbStar2";
            this.pbStar2.Size = new System.Drawing.Size(30, 30);
            this.pbStar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStar2.TabIndex = 8;
            this.pbStar2.TabStop = false;
            this.pbStar2.Visible = false;
            // 
            // pbStar3
            // 
            this.pbStar3.Image = ((System.Drawing.Image)(resources.GetObject("pbStar3.Image")));
            this.pbStar3.Location = new System.Drawing.Point(75, 0);
            this.pbStar3.Name = "pbStar3";
            this.pbStar3.Size = new System.Drawing.Size(30, 30);
            this.pbStar3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStar3.TabIndex = 9;
            this.pbStar3.TabStop = false;
            this.pbStar3.Visible = false;
            // 
            // pbStar4
            // 
            this.pbStar4.Image = ((System.Drawing.Image)(resources.GetObject("pbStar4.Image")));
            this.pbStar4.Location = new System.Drawing.Point(111, 0);
            this.pbStar4.Name = "pbStar4";
            this.pbStar4.Size = new System.Drawing.Size(30, 30);
            this.pbStar4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStar4.TabIndex = 10;
            this.pbStar4.TabStop = false;
            this.pbStar4.Visible = false;
            // 
            // pbStar5
            // 
            this.pbStar5.Image = ((System.Drawing.Image)(resources.GetObject("pbStar5.Image")));
            this.pbStar5.Location = new System.Drawing.Point(147, 0);
            this.pbStar5.Name = "pbStar5";
            this.pbStar5.Size = new System.Drawing.Size(30, 30);
            this.pbStar5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStar5.TabIndex = 11;
            this.pbStar5.TabStop = false;
            this.pbStar5.Visible = false;
            // 
            // StarsPanel
            // 
            this.StarsPanel.Controls.Add(this.pbStar1);
            this.StarsPanel.Controls.Add(this.pbStar5);
            this.StarsPanel.Controls.Add(this.pbStar2);
            this.StarsPanel.Controls.Add(this.pbStar4);
            this.StarsPanel.Controls.Add(this.pbStar3);
            this.StarsPanel.Location = new System.Drawing.Point(77, 103);
            this.StarsPanel.Name = "StarsPanel";
            this.StarsPanel.Size = new System.Drawing.Size(200, 30);
            this.StarsPanel.TabIndex = 12;
            // 
            // tbTitle
            // 
            this.tbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.Location = new System.Drawing.Point(116, 40);
            this.tbTitle.MaxLength = 100;
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(206, 26);
            this.tbTitle.TabIndex = 13;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(8, 43);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(42, 20);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Titel:";
            // 
            // PlaatsReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 350);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.StarsPanel);
            this.Controls.Add(this.nudStar);
            this.Controls.Add(this.btnPlaceReview);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbHulpverlener);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlaatsReview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Plaats Review";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlaatsReview_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.nudStar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar5)).EndInit();
            this.StarsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbHulpverlener;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button btnPlaceReview;
        private System.Windows.Forms.NumericUpDown nudStar;
        private System.Windows.Forms.PictureBox pbStar1;
        private System.Windows.Forms.PictureBox pbStar2;
        private System.Windows.Forms.PictureBox pbStar3;
        private System.Windows.Forms.PictureBox pbStar4;
        private System.Windows.Forms.PictureBox pbStar5;
        private System.Windows.Forms.Panel StarsPanel;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lblTitle;
    }
}