namespace Ict4Participation
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnGereed = new System.Windows.Forms.Button();
            this.btnVoegToe = new System.Windows.Forms.Button();
            this.cbSkills = new System.Windows.Forms.ComboBox();
            this.lbSkills = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.btnVoegToe);
            this.groupBox1.Controls.Add(this.cbSkills);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbSkills);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 339);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Overzicht vraag";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titel:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 26);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(75, 57);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(229, 86);
            this.textBox2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Inhoud:";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(75, 149);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(229, 26);
            this.dtpDate.TabIndex = 14;
            // 
            // btnGereed
            // 
            this.btnGereed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGereed.Location = new System.Drawing.Point(12, 357);
            this.btnGereed.Name = "btnGereed";
            this.btnGereed.Size = new System.Drawing.Size(310, 44);
            this.btnGereed.TabIndex = 13;
            this.btnGereed.Text = "Gereed";
            this.btnGereed.UseVisualStyleBackColor = true;
            // 
            // btnVoegToe
            // 
            this.btnVoegToe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoegToe.Location = new System.Drawing.Point(199, 213);
            this.btnVoegToe.Name = "btnVoegToe";
            this.btnVoegToe.Size = new System.Drawing.Size(105, 30);
            this.btnVoegToe.TabIndex = 12;
            this.btnVoegToe.Text = "Voeg Toe";
            this.btnVoegToe.UseVisualStyleBackColor = true;
            // 
            // cbSkills
            // 
            this.cbSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkills.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSkills.FormattingEnabled = true;
            this.cbSkills.Items.AddRange(new object[] {
            "Auto",
            "Rijbewijs",
            "Getraind",
            "Goede conditie",
            "Technisch",
            "Spraakzaam"});
            this.cbSkills.Location = new System.Drawing.Point(6, 215);
            this.cbSkills.Name = "cbSkills";
            this.cbSkills.Size = new System.Drawing.Size(187, 28);
            this.cbSkills.TabIndex = 11;
            // 
            // lbSkills
            // 
            this.lbSkills.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSkills.FormattingEnabled = true;
            this.lbSkills.ItemHeight = 20;
            this.lbSkills.Items.AddRange(new object[] {
            "Getraind"});
            this.lbSkills.Location = new System.Drawing.Point(6, 249);
            this.lbSkills.Name = "lbSkills";
            this.lbSkills.Size = new System.Drawing.Size(298, 84);
            this.lbSkills.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Benodigde skills:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tijd:";
            // 
            // Hulpvraag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 413);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGereed);
            this.Name = "Hulpvraag";
            this.Text = "Hulpvraag";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnGereed;
        private System.Windows.Forms.Button btnVoegToe;
        private System.Windows.Forms.ComboBox cbSkills;
        private System.Windows.Forms.ListBox lbSkills;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}