namespace Ict4Participation
{
    partial class Profiles
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
            this.lblName = new System.Windows.Forms.Label();
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            this.btnChat = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.afspraakMakenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsWeergevenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plaatsenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weergevenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRole = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(111, 135);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(127, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Henk Nogwattes";
            // 
            // pbAvatar
            // 
            this.pbAvatar.Location = new System.Drawing.Point(125, 32);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.Size = new System.Drawing.Size(102, 100);
            this.pbAvatar.TabIndex = 1;
            this.pbAvatar.TabStop = false;
            // 
            // btnChat
            // 
            this.btnChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChat.Location = new System.Drawing.Point(249, 185);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(89, 64);
            this.btnChat.TabIndex = 13;
            this.btnChat.Text = "Chat";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(12, 185);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 64);
            this.button4.TabIndex = 18;
            this.button4.Text = "<< Terug";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonTerug_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afspraakMakenToolStripMenuItem,
            this.detailsWeergevenToolStripMenuItem,
            this.reviewToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(350, 28);
            this.menuStrip2.TabIndex = 21;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // afspraakMakenToolStripMenuItem
            // 
            this.afspraakMakenToolStripMenuItem.Name = "afspraakMakenToolStripMenuItem";
            this.afspraakMakenToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.afspraakMakenToolStripMenuItem.Text = "Afspraak maken";
            this.afspraakMakenToolStripMenuItem.Click += new System.EventHandler(this.afspraakMakenToolStripMenuItem_Click);
            // 
            // detailsWeergevenToolStripMenuItem
            // 
            this.detailsWeergevenToolStripMenuItem.Name = "detailsWeergevenToolStripMenuItem";
            this.detailsWeergevenToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.detailsWeergevenToolStripMenuItem.Text = "Details weergeven";
            this.detailsWeergevenToolStripMenuItem.Click += new System.EventHandler(this.detailsWeergevenToolStripMenuItem_Click);
            // 
            // reviewToolStripMenuItem
            // 
            this.reviewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plaatsenToolStripMenuItem,
            this.weergevenToolStripMenuItem});
            this.reviewToolStripMenuItem.Name = "reviewToolStripMenuItem";
            this.reviewToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.reviewToolStripMenuItem.Text = "Review";
            // 
            // plaatsenToolStripMenuItem
            // 
            this.plaatsenToolStripMenuItem.Name = "plaatsenToolStripMenuItem";
            this.plaatsenToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.plaatsenToolStripMenuItem.Text = "Plaatsen";
            this.plaatsenToolStripMenuItem.Click += new System.EventHandler(this.plaatsenToolStripMenuItem_Click);
            // 
            // weergevenToolStripMenuItem
            // 
            this.weergevenToolStripMenuItem.Name = "weergevenToolStripMenuItem";
            this.weergevenToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.weergevenToolStripMenuItem.Text = "Weergeven";
            this.weergevenToolStripMenuItem.Click += new System.EventHandler(this.weergevenToolStripMenuItem_Click);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(129, 155);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(98, 20);
            this.lblRole.TabIndex = 22;
            this.lblRole.Text = "Hulpverlener";
            // 
            // Profiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 261);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.pbAvatar);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Profiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profiles";
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem afspraakMakenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsWeergevenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plaatsenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weergevenToolStripMenuItem;
        private System.Windows.Forms.Label lblRole;
    }
}