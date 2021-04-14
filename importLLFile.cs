using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class importLLFile : Form
    {
        Helper help = new Helper();

        public importLLFile()
        {
            InitializeComponent();
        }

        private void importLLFile_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void browseLL_Click(object sender, EventArgs e)
        {
            string filePathLL = string.Empty;
            string fileExtLL = string.Empty;
            string queryLL = string.Empty;
            string queryLLDetail = string.Empty;
            string queryGetPCBNo = string.Empty;
            string queryGetAltPCB = string.Empty;
            string queryGetTotal = string.Empty;
            string queryGetStencil = string.Empty;

            openFileDialogLL.Title = "Please Select a File Loading List";
            openFileDialogLL.Filter = "Excel Files|*.xls;*.xlsx;";
            openFileDialogLL.InitialDirectory = @"D:\";
            if (openFileDialogLL.ShowDialog() == DialogResult.OK)
            {
                string woFileName = openFileDialogLL.FileName;
                filepathLL.Text = woFileName;
                fileExtLL = Path.GetExtension(woFileName); //get the file extension 

                if (fileExtLL.CompareTo(".xls") == 0 || fileExtLL.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        // baca data utama LL
                        DataTable dtExcel = new DataTable();
                        dtExcel = help.ReadExcel(woFileName, fileExtLL, queryLL); //read excel file  
                        dataGridViewLLHide.DataSource = dtExcel;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }

                // Set table title Wo
                string[] titleWO = { "REEL", "PART CODE", "TP", "QTY", "LOC.", "DEC", "F.Type" };
                for (int i = 0; i < titleWO.Length; i++)
                {
                    dataGridViewLL.Columns[i].HeaderText = "" + titleWO[i];
                }

                // not allow to sort table
                for (int i = 0; i < dataGridViewLL.Columns.Count; i++)
                {
                    dataGridViewLL.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }
    }
}
