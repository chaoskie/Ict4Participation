﻿namespace Ict4Participation
{
    partial class HoofdForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnLogOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtnPlaceQuestion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnShowRequests = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnShowAllRequests = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnShowOwnRequests = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.vrijwilligersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hulpbehoevendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnGereed = new System.Windows.Forms.Button();
            this.administratorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnLogOut,
            this.toolStripSeparator3,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripComboBox1,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(534, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnLogOut
            // 
            this.tsbtnLogOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnLogOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLogOut.Name = "tsbtnLogOut";
            this.tsbtnLogOut.Size = new System.Drawing.Size(78, 24);
            this.tsbtnLogOut.Text = "Afmelden";
            this.tsbtnLogOut.Click += new System.EventHandler(this.tsbtnLogOut_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnPlaceQuestion,
            this.tsbtnShowRequests});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(91, 24);
            this.toolStripDropDownButton1.Text = "Hulpvraag";
            // 
            // tsbtnPlaceQuestion
            // 
            this.tsbtnPlaceQuestion.Name = "tsbtnPlaceQuestion";
            this.tsbtnPlaceQuestion.Size = new System.Drawing.Size(225, 24);
            this.tsbtnPlaceQuestion.Text = "Plaats";
            this.tsbtnPlaceQuestion.Click += new System.EventHandler(this.tsbtnPlaceQuestion_Click);
            // 
            // tsbtnShowRequests
            // 
            this.tsbtnShowRequests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnShowAllRequests,
            this.tsbtnShowOwnRequests});
            this.tsbtnShowRequests.Name = "tsbtnShowRequests";
            this.tsbtnShowRequests.Size = new System.Drawing.Size(225, 24);
            this.tsbtnShowRequests.Text = "Aanvragen weergeven";
            this.tsbtnShowRequests.Click += new System.EventHandler(this.tsbtnShowAllRequests_Click);
            // 
            // tsbtnShowAllRequests
            // 
            this.tsbtnShowAllRequests.Name = "tsbtnShowAllRequests";
            this.tsbtnShowAllRequests.Size = new System.Drawing.Size(152, 24);
            this.tsbtnShowAllRequests.Text = "Alle";
            this.tsbtnShowAllRequests.Click += new System.EventHandler(this.tsbtnShowAllRequests_Click);
            // 
            // tsbtnShowOwnRequests
            // 
            this.tsbtnShowOwnRequests.Name = "tsbtnShowOwnRequests";
            this.tsbtnShowOwnRequests.Size = new System.Drawing.Size(152, 24);
            this.tsbtnShowOwnRequests.Text = "Eigen";
            this.tsbtnShowOwnRequests.Click += new System.EventHandler(this.tsbtnShowOwnRequests_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vrijwilligersToolStripMenuItem,
            this.hulpbehoevendenToolStripMenuItem,
            this.administratorsToolStripMenuItem});
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(81, 24);
            this.toolStripDropDownButton2.Text = "Profielen";
            // 
            // vrijwilligersToolStripMenuItem
            // 
            this.vrijwilligersToolStripMenuItem.Name = "vrijwilligersToolStripMenuItem";
            this.vrijwilligersToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.vrijwilligersToolStripMenuItem.Text = "Vrijwilligers";
            // 
            // hulpbehoevendenToolStripMenuItem
            // 
            this.hulpbehoevendenToolStripMenuItem.Name = "hulpbehoevendenToolStripMenuItem";
            this.hulpbehoevendenToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.hulpbehoevendenToolStripMenuItem.Text = "Hulpbehoevenden";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(190, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(61, 20);
            this.toolStripLabel1.Text = "Zoeken:";
            // 
            // pbAvatar
            // 
            this.pbAvatar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbAvatar.Location = new System.Drawing.Point(18, 28);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.Size = new System.Drawing.Size(100, 96);
            this.pbAvatar.TabIndex = 4;
            this.pbAvatar.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(124, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(148, 20);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Albrecht Nogwattes";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 136);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 17;
            // 
            // btnGereed
            // 
            this.btnGereed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGereed.Location = new System.Drawing.Point(257, 254);
            this.btnGereed.Name = "btnGereed";
            this.btnGereed.Size = new System.Drawing.Size(265, 44);
            this.btnGereed.TabIndex = 18;
            this.btnGereed.Text = "Verander profiel";
            this.btnGereed.UseVisualStyleBackColor = true;
            // 
            // administratorsToolStripMenuItem
            // 
            this.administratorsToolStripMenuItem.Name = "administratorsToolStripMenuItem";
            this.administratorsToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.administratorsToolStripMenuItem.Text = "Administrators";
            // 
            // HoofdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 306);
            this.Controls.Add(this.btnGereed);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbAvatar);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(550, 39);
            this.Name = "HoofdForm";
            this.Text = "Hoofdmenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HoofdForm_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnLogOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tsbtnPlaceQuestion;
        private System.Windows.Forms.ToolStripMenuItem tsbtnShowRequests;
        private System.Windows.Forms.ToolStripMenuItem tsbtnShowAllRequests;
        private System.Windows.Forms.ToolStripMenuItem tsbtnShowOwnRequests;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem vrijwilligersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hulpbehoevendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnGereed;
        private System.Windows.Forms.ToolStripMenuItem administratorsToolStripMenuItem;

    }
}