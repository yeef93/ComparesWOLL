using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Ubiety.Dns.Core;

namespace CompareWOLL
{
    public partial class addWO : Form
    {
        ConnectionDB con = new ConnectionDB();      


        public addWO()
        {
            InitializeComponent();
        }
        
        // for read excel file
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

        private void addWO_Load(object sender, EventArgs e)
        {

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            dataGridViewWO.ReadOnly = true;

            //MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
            //connection.Open();

            //string query = "SELECT * FROM tbl_wo";

            //using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
            //{
            //    DataSet dset = new DataSet();

            //    adpt.Fill(dset);

            //    dataGridViewWO.DataSource = dset.Tables[0];
            //}
            //connection.Close();

        }

        private void browseWO_Click(object sender, EventArgs e)
        {
            string filePathWO = string.Empty;
            string fileExtWO = string.Empty;
            string queryWO = string.Empty;

            openFileDialogWO.Title = "Please Select a File Work Order";
            //openFileDialogWO.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm| CSV files (*.csv)|*.csv";
            openFileDialogWO.Filter = "Excel Files|*.xls;*.xlsx;";
            openFileDialogWO.InitialDirectory = @"D:\";
            if (openFileDialogWO.ShowDialog() == DialogResult.OK)
            {
                string woFileName = openFileDialogWO.FileName;
                filepathWO.Text = woFileName;
                fileExtWO = Path.GetExtension(woFileName); //get the file extension  
                queryWO = "select * from [Sheet1$A2:M]";


                if (fileExtWO.CompareTo(".xls") == 0 || fileExtWO.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(woFileName, fileExtWO, queryWO); //read excel file  
                        dataGridViewWO.Visible = true;
                        dataGridViewWO.DataSource = dtExcel;

                        woPTSN.Text = dataGridViewWO.Rows[0].Cells[11].Value.ToString();
                        woNo.Text = dataGridViewWO.Rows[0].Cells[7].Value.ToString();
                        modelNo.Text = dataGridViewWO.Rows[0].Cells[3].Value.ToString();
                        model.Text = dataGridViewWO.Rows[0].Cells[0].Value.ToString();
                        woQty.Text = dataGridViewWO.Rows[0].Cells[12].Value.ToString();
                        
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
                string[] titleWO = { "Model", "", "Part No", "Model No", "QTY", "Issue", "", "WO No", "BOM Row", "Process","",  "WO PTSN", "WO Qty" };
                for (int i = 0; i < titleWO.Length; i++)
                {
                    dataGridViewWO.Columns[i].HeaderText = "" + titleWO[i];
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string woPTSNN = woPTSN.Text;
            string woNoo = woNo.Text;
            string modelNoo = modelNo.Text;
            string modell = model.Text;
            string woqtyy = woQty.Text;
            string pcbNoo = pcbNo.Text;

            var conn = new MySqlConnection("Host=localhost;Uid=root;Pwd=;Database=pe");
            var cmd = new MySqlCommand("", conn);

            string query = "INSERT INTO tbl_wo VALUES('"+woPTSNN+ "','" + woNoo + "','" + modelNoo + "','" + modell + "', '" + woqtyy + "', '3520C3LM0A9T', '1 SIDE' )";

            cmd.CommandText = query;
            //Masukkan perintah/query yang akan dijalankan ke dalam CommandText

            conn.Open();
            //Buka koneksi
            cmd.ExecuteNonQuery();
            //Jalankan perintah / query dalam CommandText pada database
            conn.Close();
            //Tutup koneksi

            this.Close();
        }
    }
}
