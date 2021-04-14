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
    public partial class importExcel : Form
    {
        Helper help = new Helper();

        public importExcel()
        {
            InitializeComponent();
        }

        private void browseLL_Click(object sender, EventArgs e)
        {
            string filePathLL = string.Empty;
            string fileExtLL = string.Empty;
            string queryLL = string.Empty;

            openFileDialogExcel.Title = "Please Select a File Loading List";
            openFileDialogExcel.Filter = "Excel Files|*.xls;*.xlsx;";
            openFileDialogExcel.InitialDirectory = @"D:\";
            if (openFileDialogExcel.ShowDialog() == DialogResult.OK)
            {
                string woFileName = openFileDialogExcel.FileName;
                filepathLL.Text = woFileName;
                fileExtLL = Path.GetExtension(woFileName); //get the file extension  
                queryLL = "select * from [Sheet1$A9:I]";

                if (fileExtLL.CompareTo(".xls") == 0 || fileExtLL.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        // baca data utama LL
                        DataTable dtExcel = new DataTable();
                        dtExcel = help.ReadExcel(woFileName, fileExtLL, queryLL); //read excel file  
                        dataGridView1.DataSource = dtExcel;

                        dataGridView1.Columns.RemoveAt(5);
                        dataGridView1.Columns.RemoveAt(6);


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
                    dataGridView1.Columns[i].HeaderText = "" + titleWO[i];
                }

                // not allow to sort table
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

        }


        private void importExcel_Load(object sender, EventArgs e)
        {
            help.GetExcelSheetNames("D:\\Fara\\Reference WO vs LL\\file yang di pakai\\test XM-522J19C10000 SB  MASTER (SMT-A).xlsx");
        }
    }
}
