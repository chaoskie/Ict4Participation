namespace AdministrationParticipation
{
    partial class Hulpvraag
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
            this.lblPostDate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEndDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStartDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbQuestionTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteEntry = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbPoster = new System.Windows.Forms.TextBox();
            this.cbUrgentie = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblPostDate
            // 
            this.lblPostDate.AutoSize = true;
            this.lblPostDate.Location = new System.Drawing.Point(107, 190);
            this.lblPostDate.Name = "lblPostDate";
            this.lblPostDate.Size = new System.Drawing.Size(47, 13);
            this.lblPostDate.TabIndex = 60;
            this.lblPostDate.Text = "<empty>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 190);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Geplaatst op:";
            // 
            // cbStatus
            // 
            this.cbStatus.Enabled = false;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Niet aangenomen",
            "In behandeling",
            "Afgerond",
            "Vervallen"});
            this.cbStatus.Location = new System.Drawing.Point(110, 166);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(160, 21);
            this.cbStatus.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Bericht:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Urgentie";
            // 
            // tbAddress
            // 
            this.tbAddress.Enabled = false;
            this.tbAddress.Location = new System.Drawing.Point(110, 113);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(160, 20);
            this.tbAddress.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Adres";
            // 
            // tbEndDate
            // 
            this.tbEndDate.Enabled = false;
            this.tbEndDate.Location = new System.Drawing.Point(110, 87);
            this.tbEndDate.Name = "tbEndDate";
            this.tbEndDate.Size = new System.Drawing.Size(160, 20);
            this.tbEndDate.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Eind datum";
            // 
            // tbStartDate
            // 
            this.tbStartDate.Enabled = false;
            this.tbStartDate.Location = new System.Drawing.Point(110, 61);
            this.tbStartDate.Name = "tbStartDate";
            this.tbStartDate.Size = new System.Drawing.Size(160, 20);
            this.tbStartDate.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Start datum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(17, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Geplaatst door";
            // 
            // tbQuestionTitle
            // 
            this.tbQuestionTitle.Location = new System.Drawing.Point(110, 9);
            this.tbQuestionTitle.Name = "tbQuestionTitle";
            this.tbQuestionTitle.Size = new System.Drawing.Size(160, 20);
            this.tbQuestionTitle.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Titel";
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Location = new System.Drawing.Point(16, 328);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteEntry.TabIndex = 37;
            this.btnDeleteEntry.Text = "Verwijder";
            this.btnDeleteEntry.UseVisualStyleBackColor = true;
            this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(110, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Annuleer";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(201, 328);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 35;
            this.btnAccept.Text = "Bevestig";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(12, 221);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(260, 101);
            this.tbDescription.TabIndex = 61;
            // 
            // tbPoster
            // 
            this.tbPoster.Enabled = false;
            this.tbPoster.Location = new System.Drawing.Point(110, 35);
            this.tbPoster.Name = "tbPoster";
            this.tbPoster.Size = new System.Drawing.Size(160, 20);
            this.tbPoster.TabIndex = 62;
            // 
            // cbUrgentie
            // 
            this.cbUrgentie.Enabled = false;
            this.cbUrgentie.FormattingEnabled = true;
            this.cbUrgentie.Items.AddRange(new object[] {
            "Urgent ",
            "Normaal"});
            this.cbUrgentie.Location = new System.Drawing.Point(110, 139);
            this.cbUrgentie.Name = "cbUrgentie";
            this.cbUrgentie.Size = new System.Drawing.Size(160, 21);
            this.cbUrgentie.TabIndex = 63;
            // 
            // Hulpvraag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.cbUrgentie);
            this.Controls.Add(this.tbPoster);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lblPostDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbEndDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbQuestionTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteEntry);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.MaximizeBox = false;
            this.Name = "Hulpvraag";
            this.Text = "Hulpvraag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPostDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbQuestionTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteEntry;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbPoster;
        private System.Windows.Forms.ComboBox cbUrgentie;
    }
}