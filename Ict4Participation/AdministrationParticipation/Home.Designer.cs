namespace AdministrationParticipation
{
    partial class Home
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
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbSearchField = new System.Windows.Forms.ToolStripComboBox();
            this.tbSearchThis = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnOpenQuestion = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnOpenReaction = new System.Windows.Forms.Button();
            this.btnOpenReviews = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbNewQuestions = new System.Windows.Forms.ListBox();
            this.lbNewReviews = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cbSearchField,
            this.tbSearchThis,
            this.btnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(814, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel1.Text = "Zoeken:";
            // 
            // cbSearchField
            // 
            this.cbSearchField.Items.AddRange(new object[] {
            "Alles",
            "Gebruikers",
            "Vragen",
            "Reacties",
            "Reviews"});
            this.cbSearchField.Name = "cbSearchField";
            this.cbSearchField.Size = new System.Drawing.Size(121, 25);
            this.cbSearchField.Text = "Alles";
            // 
            // tbSearchThis
            // 
            this.tbSearchThis.Name = "tbSearchThis";
            this.tbSearchThis.Size = new System.Drawing.Size(100, 25);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = global::AdministrationParticipation.Properties.Resources.search;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 22);
            this.btnSearch.Text = "toolStripButton1";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnOpenQuestion
            // 
            this.btnOpenQuestion.Location = new System.Drawing.Point(9, 27);
            this.btnOpenQuestion.Name = "btnOpenQuestion";
            this.btnOpenQuestion.Size = new System.Drawing.Size(126, 47);
            this.btnOpenQuestion.TabIndex = 1;
            this.btnOpenQuestion.Text = "Open Vragen";
            this.btnOpenQuestion.UseVisualStyleBackColor = true;
            this.btnOpenQuestion.Click += new System.EventHandler(this.btnOpenQuestion_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(9, 80);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(126, 47);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "Open Gebruikers";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnOpenReaction
            // 
            this.btnOpenReaction.Location = new System.Drawing.Point(9, 133);
            this.btnOpenReaction.Name = "btnOpenReaction";
            this.btnOpenReaction.Size = new System.Drawing.Size(126, 47);
            this.btnOpenReaction.TabIndex = 3;
            this.btnOpenReaction.Text = "Open Reacties";
            this.btnOpenReaction.UseVisualStyleBackColor = true;
            this.btnOpenReaction.Click += new System.EventHandler(this.btnOpenReaction_Click);
            // 
            // btnOpenReviews
            // 
            this.btnOpenReviews.Location = new System.Drawing.Point(9, 186);
            this.btnOpenReviews.Name = "btnOpenReviews";
            this.btnOpenReviews.Size = new System.Drawing.Size(126, 47);
            this.btnOpenReviews.TabIndex = 4;
            this.btnOpenReviews.Text = "Open Reviews";
            this.btnOpenReviews.UseVisualStyleBackColor = true;
            this.btnOpenReviews.Click += new System.EventHandler(this.btnOpenReviews_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Welkom, ";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(70, 39);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(47, 13);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "<empty>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nieuwe vragen";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenReaction);
            this.groupBox1.Controls.Add(this.btnOpenQuestion);
            this.groupBox1.Controls.Add(this.btnUsers);
            this.groupBox1.Controls.Add(this.btnOpenReviews);
            this.groupBox1.Location = new System.Drawing.Point(15, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 245);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quick Nav";
            // 
            // lbNewQuestions
            // 
            this.lbNewQuestions.FormattingEnabled = true;
            this.lbNewQuestions.Location = new System.Drawing.Point(196, 72);
            this.lbNewQuestions.Name = "lbNewQuestions";
            this.lbNewQuestions.Size = new System.Drawing.Size(272, 277);
            this.lbNewQuestions.TabIndex = 9;
            this.lbNewQuestions.DoubleClick += new System.EventHandler(this.lbNewQuestions_DoubleClick);
            // 
            // lbNewReviews
            // 
            this.lbNewReviews.FormattingEnabled = true;
            this.lbNewReviews.Location = new System.Drawing.Point(521, 72);
            this.lbNewReviews.Name = "lbNewReviews";
            this.lbNewReviews.Size = new System.Drawing.Size(272, 277);
            this.lbNewReviews.TabIndex = 11;
            this.lbNewReviews.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbNewReviews_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nieuwe reviews";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 361);
            this.Controls.Add(this.lbNewReviews);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbNewQuestions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cbSearchField;
        private System.Windows.Forms.ToolStripTextBox tbSearchThis;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.Button btnOpenQuestion;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnOpenReaction;
        private System.Windows.Forms.Button btnOpenReviews;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbNewQuestions;
        private System.Windows.Forms.ListBox lbNewReviews;
        private System.Windows.Forms.Label label3;
    }
}