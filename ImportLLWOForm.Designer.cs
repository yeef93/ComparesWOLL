
namespace CompareWOLL
{
    partial class ImportLLWOForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelSMTA = new System.Windows.Forms.Label();
            this.textBoxSMTA = new System.Windows.Forms.TextBox();
            this.browseSMTA = new System.Windows.Forms.Button();
            this.browseSMTB = new System.Windows.Forms.Button();
            this.textBoxSMTB = new System.Windows.Forms.TextBox();
            this.labelSMTB = new System.Windows.Forms.Label();
            this.browseWO = new System.Windows.Forms.Button();
            this.textBoxWO = new System.Windows.Forms.TextBox();
            this.labelWO = new System.Windows.Forms.Label();
            this.uploadFileList = new System.Windows.Forms.Button();
            this.openFileDialogWO = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogSMTA = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogSMTB = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateTimeNow = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1 Side",
            "2 Side",
            "2 Side with testing",
            "2 Side with dipping"});
            this.comboBox1.Location = new System.Drawing.Point(94, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(223, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelSMTA
            // 
            this.labelSMTA.AutoSize = true;
            this.labelSMTA.Location = new System.Drawing.Point(21, 121);
            this.labelSMTA.Name = "labelSMTA";
            this.labelSMTA.Size = new System.Drawing.Size(59, 13);
            this.labelSMTA.TabIndex = 2;
            this.labelSMTA.Text = "SMT-A File";
            // 
            // textBoxSMTA
            // 
            this.textBoxSMTA.Location = new System.Drawing.Point(94, 121);
            this.textBoxSMTA.Name = "textBoxSMTA";
            this.textBoxSMTA.ReadOnly = true;
            this.textBoxSMTA.Size = new System.Drawing.Size(223, 20);
            this.textBoxSMTA.TabIndex = 3;
            // 
            // browseSMTA
            // 
            this.browseSMTA.Location = new System.Drawing.Point(345, 117);
            this.browseSMTA.Name = "browseSMTA";
            this.browseSMTA.Size = new System.Drawing.Size(75, 23);
            this.browseSMTA.TabIndex = 4;
            this.browseSMTA.Text = "Browse";
            this.browseSMTA.UseVisualStyleBackColor = true;
            this.browseSMTA.Click += new System.EventHandler(this.browseSMTA_Click);
            // 
            // browseSMTB
            // 
            this.browseSMTB.Location = new System.Drawing.Point(345, 162);
            this.browseSMTB.Name = "browseSMTB";
            this.browseSMTB.Size = new System.Drawing.Size(75, 23);
            this.browseSMTB.TabIndex = 7;
            this.browseSMTB.Text = "Browse";
            this.browseSMTB.UseVisualStyleBackColor = true;
            this.browseSMTB.Click += new System.EventHandler(this.browseSMTB_Click);
            // 
            // textBoxSMTB
            // 
            this.textBoxSMTB.Location = new System.Drawing.Point(94, 166);
            this.textBoxSMTB.Name = "textBoxSMTB";
            this.textBoxSMTB.ReadOnly = true;
            this.textBoxSMTB.Size = new System.Drawing.Size(223, 20);
            this.textBoxSMTB.TabIndex = 6;
            // 
            // labelSMTB
            // 
            this.labelSMTB.AutoSize = true;
            this.labelSMTB.Location = new System.Drawing.Point(21, 166);
            this.labelSMTB.Name = "labelSMTB";
            this.labelSMTB.Size = new System.Drawing.Size(59, 13);
            this.labelSMTB.TabIndex = 5;
            this.labelSMTB.Text = "SMT-B File";
            // 
            // browseWO
            // 
            this.browseWO.Location = new System.Drawing.Point(345, 75);
            this.browseWO.Name = "browseWO";
            this.browseWO.Size = new System.Drawing.Size(75, 23);
            this.browseWO.TabIndex = 10;
            this.browseWO.Text = "Browse";
            this.browseWO.UseVisualStyleBackColor = true;
            this.browseWO.Click += new System.EventHandler(this.browseWO_Click);
            // 
            // textBoxWO
            // 
            this.textBoxWO.Location = new System.Drawing.Point(94, 79);
            this.textBoxWO.Name = "textBoxWO";
            this.textBoxWO.ReadOnly = true;
            this.textBoxWO.Size = new System.Drawing.Size(223, 20);
            this.textBoxWO.TabIndex = 9;
            this.textBoxWO.TextChanged += new System.EventHandler(this.textBoxWO_TextChanged);
            // 
            // labelWO
            // 
            this.labelWO.AutoSize = true;
            this.labelWO.Location = new System.Drawing.Point(21, 79);
            this.labelWO.Name = "labelWO";
            this.labelWO.Size = new System.Drawing.Size(45, 13);
            this.labelWO.TabIndex = 8;
            this.labelWO.Text = "WO File";
            // 
            // uploadFileList
            // 
            this.uploadFileList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uploadFileList.Location = new System.Drawing.Point(229, 215);
            this.uploadFileList.Name = "uploadFileList";
            this.uploadFileList.Size = new System.Drawing.Size(190, 65);
            this.uploadFileList.TabIndex = 11;
            this.uploadFileList.Text = "Load File";
            this.uploadFileList.UseVisualStyleBackColor = true;
            this.uploadFileList.Click += new System.EventHandler(this.uploadFileList_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.uploadFileList);
            this.groupBox1.Controls.Add(this.browseWO);
            this.groupBox1.Controls.Add(this.textBoxWO);
            this.groupBox1.Controls.Add(this.labelWO);
            this.groupBox1.Controls.Add(this.browseSMTB);
            this.groupBox1.Controls.Add(this.textBoxSMTB);
            this.groupBox1.Controls.Add(this.labelSMTB);
            this.groupBox1.Controls.Add(this.browseSMTA);
            this.groupBox1.Controls.Add(this.textBoxSMTA);
            this.groupBox1.Controls.Add(this.labelSMTA);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(30, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 299);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File for Compare WO with LL";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.dateTimeNow});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 13;
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
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompareWOLL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelSMTA;
        private System.Windows.Forms.TextBox textBoxSMTA;
        private System.Windows.Forms.Button browseSMTA;
        private System.Windows.Forms.Button browseSMTB;
        private System.Windows.Forms.TextBox textBoxSMTB;
        private System.Windows.Forms.Label labelSMTB;
        private System.Windows.Forms.Button browseWO;
        private System.Windows.Forms.TextBox textBoxWO;
        private System.Windows.Forms.Label labelWO;
        private System.Windows.Forms.Button uploadFileList;
        private System.Windows.Forms.OpenFileDialog openFileDialogWO;
        private System.Windows.Forms.OpenFileDialog openFileDialogSMTA;
        private System.Windows.Forms.OpenFileDialog openFileDialogSMTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeNow;
    }
}