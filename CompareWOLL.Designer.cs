
namespace CompareWOLL
{
    partial class CompareWOLL
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbStencil = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbProgNo = new System.Windows.Forms.TextBox();
            this.tbPWBType = new System.Windows.Forms.TextBox();
            this.tbMachine = new System.Windows.Forms.TextBox();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.llQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.woQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.compareQty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbWOModelNo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbWOProcess = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbLLProcess = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLLModelNo = new System.Windows.Forms.ComboBox();
            this.dataGridViewCompareLLWO = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPCB = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dataGridViewCompareLLWOResult = new System.Windows.Forms.DataGridView();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnWO = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompareLLWO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompareLLWOResult)).BeginInit();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 728);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1369, 22);
            this.statusStrip1.TabIndex = 5;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Loading List Model No";
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompare.Location = new System.Drawing.Point(896, 230);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(234, 38);
            this.btnCompare.TabIndex = 33;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.llQty);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.woQty);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.compareQty);
            this.groupBox1.Controls.Add(this.btnCompare);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1344, 274);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compare Work Order with Loading List";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbStencil);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.tbProgNo);
            this.groupBox4.Controls.Add(this.tbPWBType);
            this.groupBox4.Controls.Add(this.tbMachine);
            this.groupBox4.Controls.Add(this.tbModel);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(439, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(417, 202);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Detail Loading List";
            // 
            // tbStencil
            // 
            this.tbStencil.Location = new System.Drawing.Point(134, 164);
            this.tbStencil.Name = "tbStencil";
            this.tbStencil.ReadOnly = true;
            this.tbStencil.Size = new System.Drawing.Size(231, 20);
            this.tbStencil.TabIndex = 47;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(47, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 46;
            this.label13.Text = "STENCIL. NO";
            // 
            // tbProgNo
            // 
            this.tbProgNo.Location = new System.Drawing.Point(134, 128);
            this.tbProgNo.Name = "tbProgNo";
            this.tbProgNo.ReadOnly = true;
            this.tbProgNo.Size = new System.Drawing.Size(231, 20);
            this.tbProgNo.TabIndex = 7;
            // 
            // tbPWBType
            // 
            this.tbPWBType.Location = new System.Drawing.Point(134, 95);
            this.tbPWBType.Name = "tbPWBType";
            this.tbPWBType.ReadOnly = true;
            this.tbPWBType.Size = new System.Drawing.Size(231, 20);
            this.tbPWBType.TabIndex = 6;
            // 
            // tbMachine
            // 
            this.tbMachine.Location = new System.Drawing.Point(134, 60);
            this.tbMachine.Name = "tbMachine";
            this.tbMachine.ReadOnly = true;
            this.tbMachine.Size = new System.Drawing.Size(231, 20);
            this.tbMachine.TabIndex = 5;
            // 
            // tbModel
            // 
            this.tbModel.Location = new System.Drawing.Point(134, 29);
            this.tbModel.Name = "tbModel";
            this.tbModel.ReadOnly = true;
            this.tbModel.Size = new System.Drawing.Size(231, 20);
            this.tbModel.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(47, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "PROG. NO";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "PWB TYPE";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(47, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "MACHINE";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "MODEL";
            // 
            // llQty
            // 
            this.llQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.llQty.Location = new System.Drawing.Point(1030, 73);
            this.llQty.Name = "llQty";
            this.llQty.ReadOnly = true;
            this.llQty.Size = new System.Drawing.Size(100, 47);
            this.llQty.TabIndex = 43;
            this.llQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(1027, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 16);
            this.label6.TabIndex = 42;
            this.label6.Text = "Loading List Qty";
            // 
            // woQty
            // 
            this.woQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.woQty.Location = new System.Drawing.Point(897, 73);
            this.woQty.Name = "woQty";
            this.woQty.ReadOnly = true;
            this.woQty.Size = new System.Drawing.Size(100, 47);
            this.woQty.TabIndex = 42;
            this.woQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(894, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "Work Order Qty";
            // 
            // compareQty
            // 
            this.compareQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.compareQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compareQty.ForeColor = System.Drawing.Color.White;
            this.compareQty.Location = new System.Drawing.Point(897, 169);
            this.compareQty.Name = "compareQty";
            this.compareQty.ReadOnly = true;
            this.compareQty.Size = new System.Drawing.Size(233, 47);
            this.compareQty.TabIndex = 36;
            this.compareQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(935, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "Compare Qty Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbWOModelNo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbWOProcess);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(16, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 104);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Work Order";
            // 
            // cmbWOModelNo
            // 
            this.cmbWOModelNo.FormattingEnabled = true;
            this.cmbWOModelNo.Location = new System.Drawing.Point(167, 35);
            this.cmbWOModelNo.Name = "cmbWOModelNo";
            this.cmbWOModelNo.Size = new System.Drawing.Size(204, 21);
            this.cmbWOModelNo.Sorted = true;
            this.cmbWOModelNo.TabIndex = 38;
            this.cmbWOModelNo.SelectedIndexChanged += new System.EventHandler(this.cmbWOModelNo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Work Order Model No";
            // 
            // cmbWOProcess
            // 
            this.cmbWOProcess.FormattingEnabled = true;
            this.cmbWOProcess.Location = new System.Drawing.Point(167, 66);
            this.cmbWOProcess.Name = "cmbWOProcess";
            this.cmbWOProcess.Size = new System.Drawing.Size(204, 21);
            this.cmbWOProcess.TabIndex = 40;
            this.cmbWOProcess.SelectedIndexChanged += new System.EventHandler(this.cmbWOProcess_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Work Order Process";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbLLProcess);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbLLModelNo);
            this.groupBox3.Location = new System.Drawing.Point(16, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(406, 97);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loading List";
            // 
            // cmbLLProcess
            // 
            this.cmbLLProcess.FormattingEnabled = true;
            this.cmbLLProcess.Location = new System.Drawing.Point(177, 59);
            this.cmbLLProcess.Name = "cmbLLProcess";
            this.cmbLLProcess.Size = new System.Drawing.Size(204, 21);
            this.cmbLLProcess.TabIndex = 42;
            this.cmbLLProcess.SelectedIndexChanged += new System.EventHandler(this.cmbLLProcess_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Loading List Process";
            // 
            // cmbLLModelNo
            // 
            this.cmbLLModelNo.FormattingEnabled = true;
            this.cmbLLModelNo.Location = new System.Drawing.Point(177, 28);
            this.cmbLLModelNo.Name = "cmbLLModelNo";
            this.cmbLLModelNo.Size = new System.Drawing.Size(204, 21);
            this.cmbLLModelNo.Sorted = true;
            this.cmbLLModelNo.TabIndex = 32;
            this.cmbLLModelNo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridViewCompareLLWO
            // 
            this.dataGridViewCompareLLWO.AllowUserToAddRows = false;
            this.dataGridViewCompareLLWO.AllowUserToDeleteRows = false;
            this.dataGridViewCompareLLWO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCompareLLWO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCompareLLWO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompareLLWO.Location = new System.Drawing.Point(13, 378);
            this.dataGridViewCompareLLWO.Name = "dataGridViewCompareLLWO";
            this.dataGridViewCompareLLWO.Size = new System.Drawing.Size(1344, 288);
            this.dataGridViewCompareLLWO.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 355);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Selected PCB No";
            // 
            // tbPCB
            // 
            this.tbPCB.Location = new System.Drawing.Point(195, 347);
            this.tbPCB.Name = "tbPCB";
            this.tbPCB.ReadOnly = true;
            this.tbPCB.Size = new System.Drawing.Size(204, 20);
            this.tbPCB.TabIndex = 41;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(451, 675);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(234, 38);
            this.btnGenerate.TabIndex = 42;
            this.btnGenerate.Text = "Generate Excel File";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click_1);
            // 
            // dataGridViewCompareLLWOResult
            // 
            this.dataGridViewCompareLLWOResult.AllowUserToAddRows = false;
            this.dataGridViewCompareLLWOResult.AllowUserToDeleteRows = false;
            this.dataGridViewCompareLLWOResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCompareLLWOResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCompareLLWOResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompareLLWOResult.Location = new System.Drawing.Point(13, 378);
            this.dataGridViewCompareLLWOResult.Name = "dataGridViewCompareLLWOResult";
            this.dataGridViewCompareLLWOResult.Size = new System.Drawing.Size(1344, 288);
            this.dataGridViewCompareLLWOResult.TabIndex = 43;
            this.dataGridViewCompareLLWOResult.Visible = false;
            // 
            // btnHome
            // 
            this.btnHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHome.Location = new System.Drawing.Point(1201, 25);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 23);
            this.btnHome.TabIndex = 44;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnWO
            // 
            this.btnWO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWO.Location = new System.Drawing.Point(1282, 25);
            this.btnWO.Name = "btnWO";
            this.btnWO.Size = new System.Drawing.Size(75, 23);
            this.btnWO.TabIndex = 45;
            this.btnWO.Text = "Work Order";
            this.btnWO.UseVisualStyleBackColor = true;
            this.btnWO.Click += new System.EventHandler(this.btnWO_Click);
            // 
            // CompareWOLL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 750);
            this.Controls.Add(this.btnWO);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.dataGridViewCompareLLWOResult);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.tbPCB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewCompareLLWO);
            this.Name = "CompareWOLL";
            this.Text = "Compare Work Order with Loading List";
            this.Load += new System.EventHandler(this.CompareWOLL_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompareLLWO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompareLLWOResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeNow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox compareQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridViewCompareLLWO;
        private System.Windows.Forms.ComboBox cmbLLModelNo;
        private System.Windows.Forms.ComboBox cmbWOProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWOModelNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbLLProcess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox woQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox llQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPCB;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView dataGridViewCompareLLWOResult;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnWO;
        public System.Windows.Forms.ToolStripStatusLabel toolStripUsername;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbProgNo;
        private System.Windows.Forms.TextBox tbPWBType;
        private System.Windows.Forms.TextBox tbMachine;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.TextBox tbStencil;
        private System.Windows.Forms.Label label13;
    }
}