
namespace CompareWOLL
{
    partial class MainMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workOrderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareWOVsLLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readLoadingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripUsername = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateTimeNow = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(824, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workOrderToolStripMenuItem1,
            this.loadingListToolStripMenuItem,
            this.compareWOVsLLToolStripMenuItem,
            this.readLoadingListToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // workOrderToolStripMenuItem1
            // 
            this.workOrderToolStripMenuItem1.Name = "workOrderToolStripMenuItem1";
            this.workOrderToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.workOrderToolStripMenuItem1.Text = "Work Order";
            this.workOrderToolStripMenuItem1.Click += new System.EventHandler(this.workOrderToolStripMenuItem1_Click);
            // 
            // loadingListToolStripMenuItem
            // 
            this.loadingListToolStripMenuItem.Name = "loadingListToolStripMenuItem";
            this.loadingListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadingListToolStripMenuItem.Text = "Loading List";
            this.loadingListToolStripMenuItem.Click += new System.EventHandler(this.loadingListToolStripMenuItem_Click);
            // 
            // compareWOVsLLToolStripMenuItem
            // 
            this.compareWOVsLLToolStripMenuItem.Name = "compareWOVsLLToolStripMenuItem";
            this.compareWOVsLLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.compareWOVsLLToolStripMenuItem.Text = "Compare WO vs LL";
            this.compareWOVsLLToolStripMenuItem.Click += new System.EventHandler(this.compareWOVsLLToolStripMenuItem_Click);
            // 
            // readLoadingListToolStripMenuItem
            // 
            this.readLoadingListToolStripMenuItem.Name = "readLoadingListToolStripMenuItem";
            this.readLoadingListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.readLoadingListToolStripMenuItem.Text = "Read Loading List";
            this.readLoadingListToolStripMenuItem.Click += new System.EventHandler(this.readLoadingListToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUsername,
            this.toolStripStatusLabel1,
            this.dateTimeNow});
            this.statusStrip1.Location = new System.Drawing.Point(0, 373);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(824, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripUsername
            // 
            this.toolStripUsername.Name = "toolStripUsername";
            this.toolStripUsername.Size = new System.Drawing.Size(124, 17);
            this.toolStripUsername.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(220, 17);
            this.toolStripStatusLabel1.Text = "Developed by IT-PE SMT Dept with ❤  | ";
            // 
            // dateTimeNow
            // 
            this.dateTimeNow.Name = "dateTimeNow";
            this.dateTimeNow.Size = new System.Drawing.Size(124, 17);
            this.dateTimeNow.Text = "toolStripStatusLabel2";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 395);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompareWOLL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeNow;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadingListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareWOVsLLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workOrderToolStripMenuItem1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripUsername;
        private System.Windows.Forms.ToolStripMenuItem readLoadingListToolStripMenuItem;
    }
}

