using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
        OleDbConnection OleDbcon;

        public importExcel()
        {
            InitializeComponent();
        }

        private void browseLL_Click(object sender, EventArgs e)
        {
            string fileExtLL = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Please Select a File Loading List";

            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(openFileDialog.FileName))

                {
                    string llFileName = openFileDialog.FileName;
                    fileExtLL = Path.GetExtension(llFileName); //get the file extension  

                    if (fileExtLL.CompareTo(".xls") == 0 || fileExtLL.CompareTo(".xlsx") == 0)
                    {
                        try
                        {                            

                            OleDbcon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + openFileDialog.FileName + ";Extended Properties=Excel 12.0;");

                            OleDbcon.Open();

                            DataTable dt = OleDbcon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                            OleDbcon.Close();

                            label2.Text = dt.Rows.Count.ToString();

                            for (int i = 0; i < dt.Rows.Count; i++)

                            {
                                String sheetName = dt.Rows[i]["TABLE_NAME"].ToString();

                                sheetName = sheetName.Substring(0, sheetName.Length - 1).Replace("'", "");

                                OleDbDataAdapter oledbDa = new OleDbDataAdapter("Select * from [" + sheetName + "A8:I55]", OleDbcon);

                                DataTable data = new DataTable();

                                //data.Rows.Add();
                                oledbDa.Fill(data);

                                dataGridViewLL.DataSource = data;

                                dataGridViewLL.Columns.RemoveAt(5);
                                dataGridViewLL.Columns.RemoveAt(6);

                                // not allow to sort table
                                for (int j = 0; j < dataGridViewLL.Columns.Count; j++)
                                {
                                    dataGridViewLL.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                                }
                            }
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

        private void button2_Click(object sender, EventArgs e)

        {

            OpenFileDialog OpenFileDialog = new OpenFileDialog();

            OpenFileDialog.ShowDialog();

            string path = OpenFileDialog.FileName;

        }

        //private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    var sheet = comboBox1.Text;

        //    OleDbDataAdapter oledbDa = new OleDbDataAdapter("Select * from [" + sheet + "A8:I55]", OleDbcon);

        //    DataTable dt = new DataTable();

        //    oledbDa.Fill(dt);

        //    dataGridViewLL.DataSource = dt;

        //    dataGridViewLL.Columns.RemoveAt(5);
        //    dataGridViewLL.Columns.RemoveAt(6);

        //    // not allow to sort table
        //    for (int i = 0; i < dataGridViewLL.Columns.Count; i++)
        //    {
        //        dataGridViewLL.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    }
        //}

        private void importExcel_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }
    }
}
