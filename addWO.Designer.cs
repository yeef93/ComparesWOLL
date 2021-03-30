
namespace CompareWOLL
{
    partial class addWO
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.browseWO = new System.Windows.Forms.Button();
            this.filepathWO = new System.Windows.Forms.TextBox();
            this.woNo = new System.Windows.Forms.TextBox();
            this.woPTSN = new System.Windows.Forms.TextBox();
            this.model = new System.Windows.Forms.TextBox();
            this.modelNo = new System.Windows.Forms.TextBox();
            this.woQty = new System.Windows.Forms.TextBox();
            this.dataGridViewWO = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialogWO = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateTimeNow = new System.Windows.Forms.ToolStripStatusLabel();
            this.pcbNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "WO Qty";
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
            // woQty
            // 
            this.woQty.Location = new System.Drawing.Point(115, 174);
            this.woQty.Name = "woQty";
            this.woQty.ReadOnly = true;
            this.woQty.Size = new System.Drawing.Size(223, 20);
            this.woQty.TabIndex = 17;
            // 
            // dataGridViewWO
            // 
            this.dataGridViewWO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWO.Location = new System.Drawing.Point(12, 280);
            this.dataGridViewWO.Name = "dataGridViewWO";
            this.dataGridViewWO.Size = new System.Drawing.Size(747, 195);
            this.dataGridViewWO.TabIndex = 18;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Location = new System.Drawing.Point(354, 507);
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
            this.toolStripStatusLabel1,
            this.dateTimeNow});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
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
            // pcbNo
            // 
            this.pcbNo.Location = new System.Drawing.Point(481, 178);
            this.pcbNo.Name = "pcbNo";
            this.pcbNo.Size = new System.Drawing.Size(223, 20);
            this.pcbNo.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(386, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "PCB No";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1 Side",
            "2 Side",
            "2 Side with testing",
            "2 Side with dipping"});
            this.comboBox1.Location = new System.Drawing.Point(115, 216);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(223, 21);
            this.comboBox1.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Type";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.woPTSN);
            this.groupBox1.Controls.Add(this.browseWO);
            this.groupBox1.Controls.Add(this.filepathWO);
            this.groupBox1.Controls.Add(this.modelNo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.pcbNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.woNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.model);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.woQty);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 259);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Work Order Detail";
            // 
            // addWO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dataGridViewWO);
            this.Controls.Add(this.groupBox1);
            this.Name = "addWO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Work Order";
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button browseWO;
        private System.Windows.Forms.TextBox filepathWO;
        private System.Windows.Forms.TextBox woNo;
        private System.Windows.Forms.TextBox woPTSN;
        private System.Windows.Forms.TextBox model;
        private System.Windows.Forms.TextBox modelNo;
        private System.Windows.Forms.TextBox woQty;
        private System.Windows.Forms.DataGridView dataGridViewWO;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialogWO;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeNow;
        private System.Windows.Forms.TextBox pcbNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}