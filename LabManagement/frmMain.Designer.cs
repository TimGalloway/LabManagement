namespace LabManagementWPF
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.tsddManagement = new System.Windows.Forms.ToolStripDropDownButton();
            this.optClients = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.AutoSize = false;
            this.tsMainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddManagement});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Padding = new System.Windows.Forms.Padding(5);
            this.tsMainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMainMenu.Size = new System.Drawing.Size(800, 34);
            this.tsMainMenu.TabIndex = 0;
            this.tsMainMenu.Text = "toolStrip1";
            this.tsMainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tsddManagement
            // 
            this.tsddManagement.AutoSize = false;
            this.tsddManagement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optClients});
            this.tsddManagement.Image = ((System.Drawing.Image)(resources.GetObject("tsddManagement.Image")));
            this.tsddManagement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddManagement.Name = "tsddManagement";
            this.tsddManagement.Size = new System.Drawing.Size(90, 28);
            this.tsddManagement.Text = "Management";
            // 
            // optClients
            // 
            this.optClients.Name = "optClients";
            this.optClients.Size = new System.Drawing.Size(180, 22);
            this.optClients.Tag = "frmClients";
            this.optClients.Text = "Clients";
            this.optClients.Click += new System.EventHandler(this.optClients_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tsMainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Lab Management";
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripDropDownButton tsddManagement;
        private System.Windows.Forms.ToolStripMenuItem optClients;
    }
}

