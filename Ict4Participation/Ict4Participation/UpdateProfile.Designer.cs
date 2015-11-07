namespace Ict4Participation
{
    partial class UpdateProfile
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPhotoPath = new System.Windows.Forms.TextBox();
            this.btnChoosePhoto = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbAdress = new System.Windows.Forms.TextBox();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbPassword1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbPassword2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbPhotoPath);
            this.groupBox1.Controls.Add(this.btnChoosePhoto);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.tbAdress);
            this.groupBox1.Controls.Add(this.cbSex);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 207);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Persoonsgegevens";
            // 
            // tbPhotoPath
            // 
            this.tbPhotoPath.Location = new System.Drawing.Point(110, 160);
            this.tbPhotoPath.Name = "tbPhotoPath";
            this.tbPhotoPath.ReadOnly = true;
            this.tbPhotoPath.Size = new System.Drawing.Size(99, 26);
            this.tbPhotoPath.TabIndex = 13;
            // 
            // btnChoosePhoto
            // 
            this.btnChoosePhoto.Location = new System.Drawing.Point(215, 158);
            this.btnChoosePhoto.Name = "btnChoosePhoto";
            this.btnChoosePhoto.Size = new System.Drawing.Size(89, 30);
            this.btnChoosePhoto.TabIndex = 15;
            this.btnChoosePhoto.Text = "Bladeren...";
            this.btnChoosePhoto.UseVisualStyleBackColor = true;
            this.btnChoosePhoto.Click += new System.EventHandler(this.btnChoosePhoto_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Profielfoto:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(110, 25);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(194, 26);
            this.tbName.TabIndex = 2;
            // 
            // tbAdress
            // 
            this.tbAdress.Location = new System.Drawing.Point(110, 57);
            this.tbAdress.Multiline = true;
            this.tbAdress.Name = "tbAdress";
            this.tbAdress.Size = new System.Drawing.Size(194, 58);
            this.tbAdress.TabIndex = 3;
            // 
            // cbSex
            // 
            this.cbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cbSex.Location = new System.Drawing.Point(110, 121);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(194, 28);
            this.cbSex.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Naam:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Adres:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Geslacht:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbPassword2);
            this.groupBox3.Controls.Add(this.tbEmail);
            this.groupBox3.Controls.Add(this.tbPassword1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 137);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Accountgegevens";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(73, 25);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(231, 26);
            this.tbEmail.TabIndex = 3;
            // 
            // tbPassword1
            // 
            this.tbPassword1.Location = new System.Drawing.Point(73, 78);
            this.tbPassword1.Name = "tbPassword1";
            this.tbPassword1.Size = new System.Drawing.Size(233, 26);
            this.tbPassword1.TabIndex = 3;
            this.tbPassword1.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 40);
            this.label9.TabIndex = 4;
            this.label9.Text = "Nieuw wachtwoord\r\ninstellen:";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(12, 368);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 30);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(179, 368);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 30);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Pas aan";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbPassword2
            // 
            this.tbPassword2.Location = new System.Drawing.Point(73, 111);
            this.tbPassword2.Name = "tbPassword2";
            this.tbPassword2.Size = new System.Drawing.Size(233, 26);
            this.tbPassword2.TabIndex = 5;
            this.tbPassword2.UseSystemPasswordChar = true;
            // 
            // UpdateProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 410);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "UpdateProfile";
            this.Text = "UpdateProfile";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbAdress;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPhotoPath;
        private System.Windows.Forms.Button btnChoosePhoto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbPassword1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbPassword2;

    }
}