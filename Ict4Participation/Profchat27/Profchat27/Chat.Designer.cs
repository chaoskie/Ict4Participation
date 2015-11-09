namespace Profchat27
{
    partial class Chat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// A list box on the <see cref="HoofdForm"/>
        /// </summary>
        private System.Windows.Forms.ListBox lbContacts;

        /// <summary>
        /// A label on the <see cref="HoofdForm"/>
        /// </summary>
        private System.Windows.Forms.Label label1;

        /// <summary>
        /// A button on the <see cref="HoofdForm"/>
        /// </summary>
        private System.Windows.Forms.Button btnStartChat;

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
            this.lbContacts = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartChat = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbChatroom = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbContacts
            // 
            this.lbContacts.FormattingEnabled = true;
            this.lbContacts.Location = new System.Drawing.Point(12, 25);
            this.lbContacts.Name = "lbContacts";
            this.lbContacts.Size = new System.Drawing.Size(207, 290);
            this.lbContacts.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contacts";
            // 
            // btnStartChat
            // 
            this.btnStartChat.Location = new System.Drawing.Point(225, 25);
            this.btnStartChat.Name = "btnStartChat";
            this.btnStartChat.Size = new System.Drawing.Size(106, 23);
            this.btnStartChat.TabIndex = 2;
            this.btnStartChat.Text = "Start Chat";
            this.btnStartChat.UseVisualStyleBackColor = true;
            this.btnStartChat.Click += new System.EventHandler(this.btnStartChat_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(225, 292);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Voeg toe";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbChatroom
            // 
            this.cbChatroom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChatroom.FormattingEnabled = true;
            this.cbChatroom.Location = new System.Drawing.Point(225, 265);
            this.cbChatroom.Name = "cbChatroom";
            this.cbChatroom.Size = new System.Drawing.Size(106, 21);
            this.cbChatroom.TabIndex = 4;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 327);
            this.Controls.Add(this.cbChatroom);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnStartChat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbContacts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Chat";
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbChatroom;
    }
}

