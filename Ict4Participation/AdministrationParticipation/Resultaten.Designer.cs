namespace AdministrationParticipation
{
    partial class Resultaten
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
            this.lbResultaten = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbResultaten
            // 
            this.lbResultaten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbResultaten.FormattingEnabled = true;
            this.lbResultaten.Location = new System.Drawing.Point(4, 4);
            this.lbResultaten.Name = "lbResultaten";
            this.lbResultaten.Size = new System.Drawing.Size(256, 355);
            this.lbResultaten.TabIndex = 0;
            this.lbResultaten.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbResultaten_MouseDoubleClick);
            // 
            // Resultaten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 361);
            this.Controls.Add(this.lbResultaten);
            this.MaximizeBox = false;
            this.Name = "Resultaten";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Resultaten";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbResultaten;
    }
}