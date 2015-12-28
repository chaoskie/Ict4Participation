namespace AdministrationParticipation
{
    partial class Reviews
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
            this.label4 = new System.Windows.Forms.Label();
            this.tbPosted = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPoster = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeleteEntry = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblReviewScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Review score:";
            // 
            // tbPosted
            // 
            this.tbPosted.Enabled = false;
            this.tbPosted.Location = new System.Drawing.Point(102, 41);
            this.tbPosted.Name = "tbPosted";
            this.tbPosted.Size = new System.Drawing.Size(160, 20);
            this.tbPosted.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ontvanger";
            // 
            // tbPoster
            // 
            this.tbPoster.Enabled = false;
            this.tbPoster.Location = new System.Drawing.Point(102, 15);
            this.tbPoster.Name = "tbPoster";
            this.tbPoster.Size = new System.Drawing.Size(160, 20);
            this.tbPoster.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Geplaatst door";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(15, 112);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(247, 190);
            this.tbDescription.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Bericht:";
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Location = new System.Drawing.Point(10, 328);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteEntry.TabIndex = 21;
            this.btnDeleteEntry.Text = "Verwijder";
            this.btnDeleteEntry.UseVisualStyleBackColor = true;
            this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(104, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Annuleer";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(195, 328);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 19;
            this.btnAccept.Text = "Bevestig";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblReviewScore
            // 
            this.lblReviewScore.AutoSize = true;
            this.lblReviewScore.Location = new System.Drawing.Point(99, 70);
            this.lblReviewScore.Name = "lblReviewScore";
            this.lblReviewScore.Size = new System.Drawing.Size(47, 13);
            this.lblReviewScore.TabIndex = 22;
            this.lblReviewScore.Text = "<empty>";
            // 
            // Reviews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.lblReviewScore);
            this.Controls.Add(this.btnDeleteEntry);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPoster);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPosted);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.Name = "Reviews";
            this.Text = "Reviews";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPosted;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPoster;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeleteEntry;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblReviewScore;
    }
}