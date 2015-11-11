namespace Ict4Participation
{
    partial class AdminForm
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
            this.lbTables = new System.Windows.Forms.ListBox();
            this.lbPost = new System.Windows.Forms.ListBox();
            this.lbPostDetails = new System.Windows.Forms.ListBox();
            this.lbPostComments = new System.Windows.Forms.ListBox();
            this.btnEditPost = new System.Windows.Forms.Button();
            this.btnEditComment = new System.Windows.Forms.Button();
            this.btnDeleteComment = new System.Windows.Forms.Button();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTables
            // 
            this.lbTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTables.FormattingEnabled = true;
            this.lbTables.ItemHeight = 16;
            this.lbTables.Items.AddRange(new object[] {
            "Vragen",
            "Gebruikers",
            "Reviews"});
            this.lbTables.Location = new System.Drawing.Point(12, 12);
            this.lbTables.Name = "lbTables";
            this.lbTables.Size = new System.Drawing.Size(120, 340);
            this.lbTables.TabIndex = 0;
            this.lbTables.SelectedIndexChanged += new System.EventHandler(this.lbRubrics_SelectedIndexChanged);
            // 
            // lbPost
            // 
            this.lbPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPost.FormattingEnabled = true;
            this.lbPost.ItemHeight = 16;
            this.lbPost.Location = new System.Drawing.Point(138, 12);
            this.lbPost.Name = "lbPost";
            this.lbPost.Size = new System.Drawing.Size(120, 340);
            this.lbPost.TabIndex = 0;
            this.lbPost.SelectedIndexChanged += new System.EventHandler(this.lbPosts_SelectedIndexChanged);
            // 
            // lbPostDetails
            // 
            this.lbPostDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPostDetails.FormattingEnabled = true;
            this.lbPostDetails.ItemHeight = 16;
            this.lbPostDetails.Location = new System.Drawing.Point(264, 12);
            this.lbPostDetails.Name = "lbPostDetails";
            this.lbPostDetails.Size = new System.Drawing.Size(221, 148);
            this.lbPostDetails.TabIndex = 1;
            // 
            // lbPostComments
            // 
            this.lbPostComments.FormattingEnabled = true;
            this.lbPostComments.HorizontalScrollbar = true;
            this.lbPostComments.Location = new System.Drawing.Point(264, 181);
            this.lbPostComments.Name = "lbPostComments";
            this.lbPostComments.Size = new System.Drawing.Size(221, 173);
            this.lbPostComments.TabIndex = 1;
            // 
            // btnEditPost
            // 
            this.btnEditPost.Location = new System.Drawing.Point(491, 12);
            this.btnEditPost.Name = "btnEditPost";
            this.btnEditPost.Size = new System.Drawing.Size(75, 23);
            this.btnEditPost.TabIndex = 4;
            this.btnEditPost.Text = "Edit";
            this.btnEditPost.UseVisualStyleBackColor = true;
            this.btnEditPost.Click += new System.EventHandler(this.btnEditPost_Click);
            // 
            // btnEditComment
            // 
            this.btnEditComment.Location = new System.Drawing.Point(491, 181);
            this.btnEditComment.Name = "btnEditComment";
            this.btnEditComment.Size = new System.Drawing.Size(75, 23);
            this.btnEditComment.TabIndex = 5;
            this.btnEditComment.Text = "Edit";
            this.btnEditComment.UseVisualStyleBackColor = true;
            this.btnEditComment.Click += new System.EventHandler(this.btnEditComment_Click);
            // 
            // btnDeleteComment
            // 
            this.btnDeleteComment.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteComment.Location = new System.Drawing.Point(491, 210);
            this.btnDeleteComment.Name = "btnDeleteComment";
            this.btnDeleteComment.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteComment.TabIndex = 6;
            this.btnDeleteComment.Text = "Verwijder";
            this.btnDeleteComment.UseVisualStyleBackColor = true;
            this.btnDeleteComment.Click += new System.EventHandler(this.btnDeleteComment_Click);
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteQuestion.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteQuestion.Location = new System.Drawing.Point(491, 50);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(75, 46);
            this.btnDeleteQuestion.TabIndex = 6;
            this.btnDeleteQuestion.Text = "Verwijder";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.btnDeletePost_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 364);
            this.Controls.Add(this.btnDeleteQuestion);
            this.Controls.Add(this.btnDeleteComment);
            this.Controls.Add(this.btnEditComment);
            this.Controls.Add(this.btnEditPost);
            this.Controls.Add(this.lbPostComments);
            this.Controls.Add(this.lbPostDetails);
            this.Controls.Add(this.lbPost);
            this.Controls.Add(this.lbTables);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbTables;
        private System.Windows.Forms.ListBox lbPost;
        private System.Windows.Forms.ListBox lbPostDetails;
        private System.Windows.Forms.ListBox lbPostComments;
        private System.Windows.Forms.Button btnEditPost;
        private System.Windows.Forms.Button btnEditComment;
        private System.Windows.Forms.Button btnDeleteComment;
        private System.Windows.Forms.Button btnDeleteQuestion;
    }
}