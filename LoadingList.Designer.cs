
namespace CompareWOLL
{
    partial class LoadingList
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripUsername = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateTimeNow = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewLLList = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLLList)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUsername,
            this.toolStripStatusLabel1,
            this.dateTimeNow});
            this.statusStrip1.Location = new System.Drawing.Point(0, 346);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(780, 22);
            this.statusStrip1.TabIndex = 8;
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
            // dataGridViewLLList
            // 
            this.dataGridViewLLList.AllowUserToAddRows = false;
            this.dataGridViewLLList.AllowUserToDeleteRows = false;
            this.dataGridViewLLList.AllowUserToOrderColumns = true;
            this.dataGridViewLLList.AllowUserToResizeColumns = false;
            this.dataGridViewLLList.AllowUserToResizeRows = false;
            this.dataGridViewLLList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLLList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLLList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLLList.Location = new System.Drawing.Point(24, 67);
            this.dataGridViewLLList.Name = "dataGridViewLLList";
            this.dataGridViewLLList.ReadOnly = true;
            this.dataGridViewLLList.Size = new System.Drawing.Size(729, 262);
            this.dataGridViewLLList.TabIndex = 7;
            this.dataGridViewLLList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLLList_CellContentClick);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(658, 25);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // LoadingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 368);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridViewLLList);
            this.Name = "LoadingList";
            this.Text = "Loading List";
            this.Load += new System.EventHandler(this.LoadingList_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLLList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeNow;
        private System.Windows.Forms.DataGridView dataGridViewLLList;
        private System.Windows.Forms.Button backButton;
        public System.Windows.Forms.ToolStripStatusLabel toolStripUsername;
    }
}