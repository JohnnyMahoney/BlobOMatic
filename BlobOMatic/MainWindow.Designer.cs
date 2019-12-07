namespace BlobOMatic
{
    partial class mainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.gamePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gamePanel.Location = new System.Drawing.Point(280, 150);
            this.gamePanel.Margin = new System.Windows.Forms.Padding(0);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(720, 400);
            this.gamePanel.TabIndex = 0;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gamePanel_Paint);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.gamePanel);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blob \'o Matic";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
    }
}

