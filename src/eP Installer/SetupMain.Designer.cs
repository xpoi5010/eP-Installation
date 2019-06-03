namespace eP_Installer
{
    partial class SetupMain
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
            this.installPage = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // installPage
            // 
            this.installPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.installPage.Location = new System.Drawing.Point(0, 0);
            this.installPage.Name = "installPage";
            this.installPage.Size = new System.Drawing.Size(590, 370);
            this.installPage.TabIndex = 0;
            // 
            // SetupMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(590, 370);
            this.Controls.Add(this.installPage);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(606, 409);
            this.MinimumSize = new System.Drawing.Size(606, 409);
            this.Name = "SetupMain";
            this.ShowIcon = false;
            this.Text = "測試用安裝程式";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel installPage;
    }
}

