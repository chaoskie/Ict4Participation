namespace Ict4Participation
{
    partial class HulpVragen
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbHulpvragen = new System.Windows.Forms.ListBox();
            this.btnNieuw = new System.Windows.Forms.Button();
            this.btnAnnuleren = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbChat = new System.Windows.Forms.TextBox();
            this.btnPlaats = new System.Windows.Forms.Button();
            this.lblQuestionName = new System.Windows.Forms.Label();
            this.lblQuestionInfo = new System.Windows.Forms.Label();
            this.lbSkills = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelChat = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Overzicht hulpvragen:";
            // 
            // lbHulpvragen
            // 
            this.lbHulpvragen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHulpvragen.FormattingEnabled = true;
            this.lbHulpvragen.ItemHeight = 20;
            this.lbHulpvragen.Location = new System.Drawing.Point(12, 32);
            this.lbHulpvragen.Name = "lbHulpvragen";
            this.lbHulpvragen.Size = new System.Drawing.Size(310, 344);
            this.lbHulpvragen.TabIndex = 1;
            this.lbHulpvragen.SelectedIndexChanged += new System.EventHandler(this.lbHulpvragen_SelectedIndexChanged);
            // 
            // btnNieuw
            // 
            this.btnNieuw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNieuw.Location = new System.Drawing.Point(12, 396);
            this.btnNieuw.Name = "btnNieuw";
            this.btnNieuw.Size = new System.Drawing.Size(153, 67);
            this.btnNieuw.TabIndex = 2;
            this.btnNieuw.Text = "Nieuwe hulpvraag";
            this.btnNieuw.UseVisualStyleBackColor = true;
            this.btnNieuw.Click += new System.EventHandler(this.btnNieuw_Click);
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuleren.Location = new System.Drawing.Point(169, 396);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(153, 67);
            this.btnAnnuleren.TabIndex = 2;
            this.btnAnnuleren.Text = "Terug";
            this.btnAnnuleren.UseVisualStyleBackColor = true;
            this.btnAnnuleren.Click += new System.EventHandler(this.btnAnnuleren_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(328, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Berichten op hulpvraag:";
            // 
            // tbChat
            // 
            this.tbChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChat.Location = new System.Drawing.Point(328, 396);
            this.tbChat.MaxLength = 500;
            this.tbChat.Multiline = true;
            this.tbChat.Name = "tbChat";
            this.tbChat.Size = new System.Drawing.Size(350, 65);
            this.tbChat.TabIndex = 4;
            // 
            // btnPlaats
            // 
            this.btnPlaats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaats.Location = new System.Drawing.Point(684, 396);
            this.btnPlaats.Name = "btnPlaats";
            this.btnPlaats.Size = new System.Drawing.Size(94, 65);
            this.btnPlaats.TabIndex = 2;
            this.btnPlaats.Text = "Reageer";
            this.btnPlaats.UseVisualStyleBackColor = true;
            this.btnPlaats.Click += new System.EventHandler(this.btnPlaats_Click);
            // 
            // lblQuestionName
            // 
            this.lblQuestionName.AutoSize = true;
            this.lblQuestionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionName.Location = new System.Drawing.Point(324, 9);
            this.lblQuestionName.Name = "lblQuestionName";
            this.lblQuestionName.Size = new System.Drawing.Size(231, 20);
            this.lblQuestionName.TabIndex = 5;
            this.lblQuestionName.Text = "<Geen vraag geselecteerd>";
            // 
            // lblQuestionInfo
            // 
            this.lblQuestionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionInfo.Location = new System.Drawing.Point(328, 29);
            this.lblQuestionInfo.Name = "lblQuestionInfo";
            this.lblQuestionInfo.Size = new System.Drawing.Size(308, 133);
            this.lblQuestionInfo.TabIndex = 6;
            this.lblQuestionInfo.Text = "<Geen vraag geselecteerd>";
            // 
            // lbSkills
            // 
            this.lbSkills.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSkills.FormattingEnabled = true;
            this.lbSkills.ItemHeight = 20;
            this.lbSkills.Location = new System.Drawing.Point(642, 29);
            this.lbSkills.Name = "lbSkills";
            this.lbSkills.Size = new System.Drawing.Size(136, 164);
            this.lbSkills.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(638, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Vereisten:";
            // 
            // panelChat
            // 
            this.panelChat.AutoScroll = true;
            this.panelChat.Location = new System.Drawing.Point(328, 199);
            this.panelChat.Name = "panelChat";
            this.panelChat.Size = new System.Drawing.Size(450, 177);
            this.panelChat.TabIndex = 9;
            // 
            // HulpVragen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 476);
            this.Controls.Add(this.panelChat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbSkills);
            this.Controls.Add(this.lblQuestionInfo);
            this.Controls.Add(this.lblQuestionName);
            this.Controls.Add(this.tbChat);
            this.Controls.Add(this.btnPlaats);
            this.Controls.Add(this.btnAnnuleren);
            this.Controls.Add(this.btnNieuw);
            this.Controls.Add(this.lbHulpvragen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HulpVragen";
            this.Text = "HulpVragen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HulpVragen_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbHulpvragen;
        private System.Windows.Forms.Button btnNieuw;
        private System.Windows.Forms.Button btnAnnuleren;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbChat;
        private System.Windows.Forms.Button btnPlaats;
        private System.Windows.Forms.Label lblQuestionName;
        private System.Windows.Forms.Label lblQuestionInfo;
        private System.Windows.Forms.ListBox lbSkills;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelChat;
    }
}