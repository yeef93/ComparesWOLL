
namespace CompareWOLL
{
    partial class importWO
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.browseWO = new System.Windows.Forms.Button();
            this.filepathWO = new System.Windows.Forms.TextBox();
            this.woNo = new System.Windows.Forms.TextBox();
            this.woPTSN = new System.Windows.Forms.TextBox();
            this.model = new System.Windows.Forms.TextBox();
            this.modelNo = new System.Windows.Forms.TextBox();
            this.dataGridViewWO = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialogWO = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripUsername = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateTimeNow = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.totalPart = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.totalUsage = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.woQty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWO)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Model";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Model No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(386, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "WO No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "WO PTSN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "WO File";
            // 
            // browseWO
            // 
            this.browseWO.Location = new System.Drawing.Point(365, 32);
            this.browseWO.Name = "browseWO";
            this.browseWO.Size = new System.Drawing.Size(75, 23);
            this.browseWO.TabIndex = 12;
            this.browseWO.Text = "Browse";
            this.browseWO.UseVisualStyleBackColor = true;
            this.browseWO.Click += new System.EventHandler(this.browseWO_Click);
            // 
            // filepathWO
            // 
            this.filepathWO.Location = new System.Drawing.Point(117, 32);
            this.filepathWO.Name = "filepathWO";
            this.filepathWO.ReadOnly = true;
            this.filepathWO.Size = new System.Drawing.Size(223, 20);
            this.filepathWO.TabIndex = 11;
            // 
            // woNo
            // 
            this.woNo.Location = new System.Drawing.Point(481, 82);
            this.woNo.Name = "woNo";
            this.woNo.ReadOnly = true;
            this.woNo.Size = new System.Drawing.Size(223, 20);
            this.woNo.TabIndex = 13;
            // 
            // woPTSN
            // 
            this.woPTSN.Location = new System.Drawing.Point(115, 82);
            this.woPTSN.Name = "woPTSN";
            this.woPTSN.ReadOnly = true;
            this.woPTSN.Size = new System.Drawing.Size(223, 20);
            this.woPTSN.TabIndex = 14;
            // 
            // model
            // 
            this.model.Location = new System.Drawing.Point(481, 129);
            this.model.Name = "model";
            this.model.ReadOnly = true;
            this.model.Size = new System.Drawing.Size(223, 20);
            this.model.TabIndex = 15;
            // 
            // modelNo
            // 
            this.modelNo.Location = new System.Drawing.Point(115, 127);
            this.modelNo.Name = "modelNo";
            this.modelNo.ReadOnly = true;
            this.modelNo.Size = new System.Drawing.Size(223, 20);
            this.modelNo.TabIndex = 16;
            // 
            // dataGridViewWO
            // 
            this.dataGridViewWO.AllowUserToAddRows = false;
            this.dataGridViewWO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWO.Location = new System.Drawing.Point(12, 239);
            this.dataGridViewWO.Name = "dataGridViewWO";
            this.dataGridViewWO.Size = new System.Drawing.Size(1194, 367);
            this.dataGridViewWO.TabIndex = 18;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Location = new System.Drawing.Point(567, 617);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUsername,
            this.toolStripStatusLabel1,
            this.dateTimeNow});
            this.statusStrip1.Location = new System.Drawing.Point(0, 648);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1218, 22);
            this.statusStrip1.TabIndex = 20;
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.totalPart);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.totalUsage);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.woQty);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.woPTSN);
            this.groupBox1.Controls.Add(this.browseWO);
            this.groupBox1.Controls.Add(this.filepathWO);
            this.groupBox1.Controls.Add(this.modelNo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.woNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.model);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1194, 179);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Work Order Detail";
            // 
            // totalPart
            // 
            this.totalPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPart.Location = new System.Drawing.Point(804, 61);
            this.totalPart.Name = "totalPart";
            this.totalPart.ReadOnly = true;
            this.totalPart.Size = new System.Drawing.Size(100, 47);
            this.totalPart.TabIndex = 33;
            this.totalPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(818, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Total Part";
            // 
            // totalUsage
            // 
            this.totalUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalUsage.Location = new System.Drawing.Point(933, 61);
            this.totalUsage.Name = "totalUsage";
            this.totalUsage.ReadOnly = true;
            this.totalUsage.Size = new System.Drawing.Size(100, 47);
            this.totalUsage.TabIndex = 31;
            this.totalUsage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1081, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 30;
            this.label9.Text = "WO Qty";
            // 
            // woQty
            // 
            this.woQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.woQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.woQty.Location = new System.Drawing.Point(1060, 61);
            this.woQty.Name = "woQty";
            this.woQty.ReadOnly = true;
            this.woQty.Size = new System.Drawing.Size(100, 47);
            this.woQty.TabIndex = 27;
            this.woQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(939, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "Total Usage";
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(1131, 25);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 27;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // homeButton
            // 
            this.homeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.homeButton.Location = new System.Drawing.Point(1050, 25);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(75, 23);
            this.homeButton.TabIndex = 26;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // importWO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 670);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dataGridViewWO);
            this.Controls.Add(this.groupBox1);
            this.Name = "importWO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Work Order";
            this.Load += new System.EventHandler(this.addWO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWO)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button browseWO;
        private System.Windows.Forms.TextBox filepathWO;
        private System.Windows.Forms.TextBox woNo;
        private System.Windows.Forms.TextBox woPTSN;
        private System.Windows.Forms.TextBox model;
        private System.Windows.Forms.TextBox modelNo;
        private System.Windows.Forms.DataGridView dataGridViewWO;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialogWO;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeNow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox woQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.TextBox totalUsage;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ToolStripStatusLabel toolStripUsername;
        private System.Windows.Forms.TextBox totalPart;
        private System.Windows.Forms.Label label5;
    }
}