namespace Ict4Participation
{
    partial class Afspraken
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
            this.tbInformation = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbInformation
            // 
            this.tbInformation.Location = new System.Drawing.Point(12, 32);
            this.tbInformation.Multiline = true;
            this.tbInformation.Name = "tbInformation";
            this.tbInformation.ReadOnly = true;
            this.tbInformation.Size = new System.Drawing.Size(310, 339);
            this.tbInformation.TabIndex = 0;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblType.Location = new System.Drawing.Point(12, 9);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(43, 20);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "type:";
            // 
            // Afspraken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 383);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.tbInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Afspraken";
            this.Text = "Informatie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInformation;
        private System.Windows.Forms.Label lblType;

    }
}

