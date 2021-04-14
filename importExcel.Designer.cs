
namespace CompareWOLL
{
    partial class importExcel
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
            this.browseLL = new System.Windows.Forms.Button();
            this.filepathLL = new System.Windows.Forms.TextBox();
            this.openFileDialogExcel = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excel File";
            // 
            // browseLL
            // 
            this.browseLL.Location = new System.Drawing.Point(299, 65);
            this.browseLL.Name = "browseLL";
            this.browseLL.Size = new System.Drawing.Size(75, 23);
            this.browseLL.TabIndex = 35;
            this.browseLL.Text = "Browse";
            this.browseLL.UseVisualStyleBackColor = true;
            this.browseLL.Click += new System.EventHandler(this.browseLL_Click);
            // 
            // filepathLL
            // 
            this.filepathLL.Location = new System.Drawing.Point(149, 68);
            this.filepathLL.Name = "filepathLL";
            this.filepathLL.ReadOnly = true;
            this.filepathLL.Size = new System.Drawing.Size(135, 20);
            this.filepathLL.TabIndex = 34;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(48, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(709, 283);
            this.dataGridView1.TabIndex = 36;
            // 
            // importExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.browseLL);
            this.Controls.Add(this.filepathLL);
            this.Controls.Add(this.label1);
            this.Name = "importExcel";
            this.Text = "Import Excel";
            this.Load += new System.EventHandler(this.importExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseLL;
        private System.Windows.Forms.TextBox filepathLL;
        private System.Windows.Forms.OpenFileDialog openFileDialogExcel;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}