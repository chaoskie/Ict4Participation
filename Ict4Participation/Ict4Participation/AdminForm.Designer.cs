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
            this.lbRubrics = new System.Windows.Forms.ListBox();
            this.lbPosts = new System.Windows.Forms.ListBox();
            this.lbPostDetails = new System.Windows.Forms.ListBox();
            this.lbPostComments = new System.Windows.Forms.ListBox();
            this.lblPostOwner = new System.Windows.Forms.Label();
            this.btnEditPost = new System.Windows.Forms.Button();
            this.btnEditComment = new System.Windows.Forms.Button();
            this.btnDeleteComment = new System.Windows.Forms.Button();
            this.btnDeletePost = new System.Windows.Forms.Button();
            this.lblPostDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbRubrics
            // 
            this.lbRubrics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRubrics.FormattingEnabled = true;
            this.lbRubrics.ItemHeight = 16;
            this.lbRubrics.Items.AddRange(new object[] {
            "Vragen",
            "Gebruikers",
            "Reviews"});
            this.lbRubrics.Location = new System.Drawing.Point(12, 12);
            this.lbRubrics.Name = "lbRubrics";
            this.lbRubrics.Size = new System.Drawing.Size(120, 340);
            this.lbRubrics.TabIndex = 0;
            this.lbRubrics.SelectedIndexChanged += new System.EventHandler(this.lbRubrics_SelectedIndexChanged);
            // 
            // lbPosts
            // 
            this.lbPosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPosts.FormattingEnabled = true;
            this.lbPosts.ItemHeight = 16;
            this.lbPosts.Location = new System.Drawing.Point(138, 12);
            this.lbPosts.Name = "lbPosts";
            this.lbPosts.Size = new System.Drawing.Size(120, 340);
            this.lbPosts.TabIndex = 0;
            this.lbPosts.SelectedIndexChanged += new System.EventHandler(this.lbPosts_SelectedIndexChanged);
            // 
            // lbPostDetails
            // 
            this.lbPostDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPostDetails.FormattingEnabled = true;
            this.lbPostDetails.ItemHeight = 16;
            this.lbPostDetails.Location = new System.Drawing.Point(264, 12);
            this.lbPostDetails.Name = "lbPostDetails";
            this.lbPostDetails.Size = new System.Drawing.Size(221, 84);
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
            // lblPostOwner
            // 
            this.lblPostOwner.AutoSize = true;
            this.lblPostOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostOwner.Location = new System.Drawing.Point(264, 110);
            this.lblPostOwner.Name = "lblPostOwner";
            this.lblPostOwner.Size = new System.Drawing.Size(13, 20);
            this.lblPostOwner.TabIndex = 2;
            this.lblPostOwner.Text = " ";
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
            // btnDeletePost
            // 
            this.btnDeletePost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePost.ForeColor = System.Drawing.Color.Red;
            this.btnDeletePost.Location = new System.Drawing.Point(491, 50);
            this.btnDeletePost.Name = "btnDeletePost";
            this.btnDeletePost.Size = new System.Drawing.Size(75, 46);
            this.btnDeletePost.TabIndex = 6;
            this.btnDeletePost.Text = "Verwijder post";
            this.btnDeletePost.UseVisualStyleBackColor = true;
            this.btnDeletePost.Click += new System.EventHandler(this.btnDeletePost_Click);
            // 
            // lblPostDate
            // 
            this.lblPostDate.AutoSize = true;
            this.lblPostDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostDate.Location = new System.Drawing.Point(264, 134);
            this.lblPostDate.Name = "lblPostDate";
            this.lblPostDate.Size = new System.Drawing.Size(13, 20);
            this.lblPostDate.TabIndex = 2;
            this.lblPostDate.Text = " ";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 364);
            this.Controls.Add(this.btnDeletePost);
            this.Controls.Add(this.btnDeleteComment);
            this.Controls.Add(this.btnEditComment);
            this.Controls.Add(this.btnEditPost);
            this.Controls.Add(this.lblPostDate);
            this.Controls.Add(this.lblPostOwner);
            this.Controls.Add(this.lbPostComments);
            this.Controls.Add(this.lbPostDetails);
            this.Controls.Add(this.lbPosts);
            this.Controls.Add(this.lbRubrics);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRubrics;
        private System.Windows.Forms.ListBox lbPosts;
        private System.Windows.Forms.ListBox lbPostDetails;
        private System.Windows.Forms.ListBox lbPostComments;
        private System.Windows.Forms.Label lblPostOwner;
        private System.Windows.Forms.Button btnEditPost;
        private System.Windows.Forms.Button btnEditComment;
        private System.Windows.Forms.Button btnDeleteComment;
        private System.Windows.Forms.Button btnDeletePost;
        private System.Windows.Forms.Label lblPostDate;
    }
}