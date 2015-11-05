namespace Ict4Participation
{
    partial class Registreren2
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegistreer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddSkill = new System.Windows.Forms.Button();
            this.cbSkills = new System.Windows.Forms.ComboBox();
            this.tbVOGPath = new System.Windows.Forms.TextBox();
            this.btnAddVOG = new System.Windows.Forms.Button();
            this.btnRemoveSkills = new System.Windows.Forms.Button();
            this.lbSkills = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(200, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tags:";
            // 
            // btnRegistreer
            // 
            this.btnRegistreer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistreer.Location = new System.Drawing.Point(73, 204);
            this.btnRegistreer.Name = "btnRegistreer";
            this.btnRegistreer.Size = new System.Drawing.Size(121, 30);
            this.btnRegistreer.TabIndex = 0;
            this.btnRegistreer.Text = "Registreer";
            this.btnRegistreer.UseVisualStyleBackColor = true;
            this.btnRegistreer.Click += new System.EventHandler(this.btnRegistreer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddSkill);
            this.groupBox1.Controls.Add(this.cbSkills);
            this.groupBox1.Controls.Add(this.tbVOGPath);
            this.groupBox1.Controls.Add(this.btnAddVOG);
            this.groupBox1.Controls.Add(this.btnRemoveSkills);
            this.groupBox1.Controls.Add(this.lbSkills);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 186);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vrijwilliger gegevens";
            // 
            // btnAddSkill
            // 
            this.btnAddSkill.Location = new System.Drawing.Point(202, 25);
            this.btnAddSkill.Name = "btnAddSkill";
            this.btnAddSkill.Size = new System.Drawing.Size(102, 56);
            this.btnAddSkill.TabIndex = 11;
            this.btnAddSkill.Text = "Voeg Toe";
            this.btnAddSkill.UseVisualStyleBackColor = true;
            this.btnAddSkill.Click += new System.EventHandler(this.btnAddSkill_Click);
            // 
            // cbSkills
            // 
            this.cbSkills.FormattingEnabled = true;
            this.cbSkills.Items.AddRange(new object[] {
            "Auto",
            "Rijbewijs",
            "Getraind",
            "Goede conditie",
            "Technisch",
            "Spraakzaam"});
            this.cbSkills.Location = new System.Drawing.Point(60, 27);
            this.cbSkills.Name = "cbSkills";
            this.cbSkills.Size = new System.Drawing.Size(136, 28);
            this.cbSkills.TabIndex = 10;
            // 
            // tbVOGPath
            // 
            this.tbVOGPath.Location = new System.Drawing.Point(61, 153);
            this.tbVOGPath.Name = "tbVOGPath";
            this.tbVOGPath.ReadOnly = true;
            this.tbVOGPath.Size = new System.Drawing.Size(135, 26);
            this.tbVOGPath.TabIndex = 9;
            // 
            // btnAddVOG
            // 
            this.btnAddVOG.Location = new System.Drawing.Point(202, 151);
            this.btnAddVOG.Name = "btnAddVOG";
            this.btnAddVOG.Size = new System.Drawing.Size(102, 30);
            this.btnAddVOG.TabIndex = 8;
            this.btnAddVOG.Text = "Bladeren...";
            this.btnAddVOG.UseVisualStyleBackColor = true;
            this.btnAddVOG.Click += new System.EventHandler(this.btnAddVOG_Click);
            // 
            // btnRemoveSkills
            // 
            this.btnRemoveSkills.Location = new System.Drawing.Point(202, 87);
            this.btnRemoveSkills.Name = "btnRemoveSkills";
            this.btnRemoveSkills.Size = new System.Drawing.Size(102, 58);
            this.btnRemoveSkills.TabIndex = 8;
            this.btnRemoveSkills.Text = "Verwijder";
            this.btnRemoveSkills.UseVisualStyleBackColor = true;
            this.btnRemoveSkills.Click += new System.EventHandler(this.btnRemoveSkills_Click);
            // 
            // lbSkills
            // 
            this.lbSkills.FormattingEnabled = true;
            this.lbSkills.ItemHeight = 20;
            this.lbSkills.Location = new System.Drawing.Point(60, 61);
            this.lbSkills.Name = "lbSkills";
            this.lbSkills.Size = new System.Drawing.Size(136, 84);
            this.lbSkills.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "VOG:";
            // 
            // Registreren2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 245);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegistreer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Registreren2";
            this.Text = "Registreren";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Registreren_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistreer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbSkills;
        private System.Windows.Forms.TextBox tbVOGPath;
        private System.Windows.Forms.Button btnAddVOG;
        private System.Windows.Forms.Button btnRemoveSkills;
        private System.Windows.Forms.ListBox lbSkills;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddSkill;

    }
}

