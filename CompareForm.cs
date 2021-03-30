using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;       // EXCEL APPLICATION.
using System.Drawing;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace CompareWOLL
{
    public partial class CompareForm : Form
    {
        private Microsoft.Office.Interop.Excel.Application ExcelObj = null;
        public CompareForm()
        {
            InitializeComponent();
            //ExcelObj = new Microsoft.Office.Interop.Excel.Application();
            //// See if the Excel Application Object was successfully constructed  
            //if (ExcelObj == null)
            //{
            //    MessageBox.Show("ERROR: EXCEL couldn't be started!");
            //    System.Windows.Forms.Application.Exit();
            //}
            //// Make the Application Visible  
            //ExcelObj.Visible = true;

        }
        public DataTable ReadExcel(string fileName, string fileExt, string query)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter(query, con); //here we read data from sheet1  
                    oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                catch { }
            }
            return dtexcel;
        }

        private void Form3_Load(object sender, System.EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");

            string filePathWO = string.Empty;
            string fileExtWO = string.Empty;
            string queryWO = string.Empty;
            string query = string.Empty;

            string filePathLL = string.Empty;
            string fileExtLL = string.Empty;
            string queryLL = string.Empty;

            filepathWO.Text = ImportLLWOForm.woFilePath;
            filepathLL.Text = ImportLLWOForm.smtaFilePath;

            

            // for pathfile Work Order

            filePathWO = ImportLLWOForm.woFilePath; //get the path of the file  
            fileExtWO = Path.GetExtension(ImportLLWOForm.woFilePath); //get the file extension  
            queryWO = "select * from [Sheet1$A2:M]";
            //query = "SELECT SUM(TOTAL) FROM [Sheet1$e:e]";
            if (fileExtWO.CompareTo(".xls") == 0 || fileExtWO.CompareTo(".xlsx") == 0)
            {
                try
                {
                    DataTable dtExcel = new DataTable();
                    dtExcel = ReadExcel(filePathWO, fileExtWO, queryWO); //read excel file  
                    dataGridViewWO.Visible = true;
                    dataGridViewWO.DataSource = dtExcel;
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
            string[] titleWO = { "Model", "", "Part No", "Model No", "QTY", "Issue", "WO No", "", "", "WO PTSN", "WO Qty" };
            for (int i = 0; i < titleWO.Length; i++)
            {
                dataGridViewWO.Columns[i].HeaderText = "" + titleWO[i];
            }


            // for pathfile Loading List
            filePathLL = ImportLLWOForm.smtaFilePath; //get the path of the file  
            fileExtLL = Path.GetExtension(ImportLLWOForm.smtaFilePath); //get the file extension  
            queryLL = "select * from [Sheet1$a2:i]";
            if (fileExtLL.CompareTo(".xls") == 0 || fileExtLL.CompareTo(".xlsx") == 0)
            {
                try
                {
                    DataTable dtExcel = new DataTable();
                    dtExcel = ReadExcel(filePathLL, fileExtLL, queryLL); //read excel file  
                    dataGridViewLL.Visible = true;
                    dataGridViewLL.DataSource = dtExcel;
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
            
        }
    }
}
