using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class importLL : Form
    {
        public importLL()
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


        private void importLL_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            dataGridViewLLHide.Visible = false;
            browseLL.Enabled = false;
            saveButton.Enabled = false;            

            MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
            connection.Open();

            string query = "SELECT model_No FROM tbl_model";
            try
            {
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    cmbModelNo.DataSource = dset;
                    cmbModelNo.ValueMember = "model_No";
                    cmbModelNo.DisplayMember = "model_No";

                }
                connection.Close();

            }
            catch (Exception ex)
            {
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }       

            string modelNo = cmbModelNo.SelectedValue.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LoadingList ll = new LoadingList();
            ll.Show();
            this.Hide();
        }

        private void browseWO_Click(object sender, EventArgs e)
        {
            string filePathLL = string.Empty;
            string fileExtLL = string.Empty;
            string queryLL = string.Empty;
            string queryLLDetail = string.Empty;

            openFileDialogLL.Title = "Please Select a File Loading List";
            openFileDialogLL.Filter = "Excel Files|*.xls;*.xlsx;";
            openFileDialogLL.InitialDirectory = @"D:\";
            if (openFileDialogLL.ShowDialog() == DialogResult.OK)
            {
                string woFileName = openFileDialogLL.FileName;
                filepathLL.Text = woFileName;
                fileExtLL = Path.GetExtension(woFileName); //get the file extension  
                queryLL = "select * from [Sheet1$A3:I]";
                queryLLDetail = "select * from [Sheet1$A9:I]";


                if (fileExtLL.CompareTo(".xls") == 0 || fileExtLL.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        // baca data utama LL
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(woFileName, fileExtLL, queryLL); //read excel file  
                        dataGridViewLLHide.DataSource = dtExcel;

                       tbModel.Text = dataGridViewLLHide.Rows[0].Cells[0].Value.ToString().Remove(0,12);
                       tbMachine.Text = dataGridViewLLHide.Rows[1].Cells[0].Value.ToString().Remove(0, 12);
                       tbPWBType.Text = dataGridViewLLHide.Rows[2].Cells[0].Value.ToString().Remove(0, 12);
                       tbProg.Text = dataGridViewLLHide.Rows[3].Cells[0].Value.ToString().Remove(0, 12);
                       tbRev.Text = dataGridViewLLHide.Rows[4].Cells[5].Value.ToString();

                        // baca data detail LL
                        DataTable dtExcel1 = new DataTable();
                        dtExcel1 = ReadExcel(woFileName, fileExtLL, queryLLDetail); //read excel file  
                        dataGridViewLL.DataSource = dtExcel1;

                        dataGridViewLL.Columns.RemoveAt(5);
                        dataGridViewLL.Columns.RemoveAt(6); 
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

                for (int i = 0; i < dataGridViewLL.Columns.Count; i++)
                {
                    dataGridViewLL.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                saveButton.Enabled = true;
            }
        }

        private void cmbModelNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //label2.Text = cmbModelNo.SelectedValue.ToString();


            MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
            connection.Open();

            string query = "SELECT process_Name FROM tbl_wodetail WHERE model_No = '"+ cmbModelNo.SelectedValue.ToString() + "' GROUP BY process_Name ";
            try
            {
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    cmbProcess.DataSource = dset;
                    cmbProcess.ValueMember = "process_Name";
                    cmbProcess.DisplayMember = "process_Name";

                }
                connection.Close();

            }
            catch (Exception ex)
            {
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            browseLL.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string model = cmbModelNo.Text;            
            string process = cmbProcess.Text;
            string modelLL = tbModel.Text;
            string machine = tbMachine.Text;
            string pwbType = tbPWBType.Text;
            string prog = tbProg.Text;
            string rev = tbRev.Text;
            string pcb = tbPcbNo.Text;
            
            saveButton.Enabled = false;

            //show total qty component
            int sum = 0;
            for (int i = 0; i < dataGridViewLL.Rows.Count; ++i)
            {
                if (dataGridViewLL.Rows[i].Cells[3].Value == System.DBNull.Value)
                {
                    dataGridViewLL.Rows[i].Cells[3].Value = "0";
                }

                //get total qty component
                sum += Convert.ToInt32(dataGridViewLL.Rows[i].Cells[3].Value);

            }
            sum = sum+1;

            string llUsage = sum.ToString();



            if (model == "" | process == "" | modelLL == "" | machine == "" | pwbType == "" | prog == "" | rev == "" | pcb == "")
            {
                MessageBox.Show("Unable to import Work Order without fill data properly", "Work Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                saveButton.Enabled = true;
            }

            else
            {
                try
                {
                    var conn = new MySqlConnection("Host=localhost;Uid=root;Pwd=;Database=pe");
                    var cmd = new MySqlCommand("", conn);

                    string queryLL = "INSERT INTO tbl_ll VALUES('" + model + "','" + process + "','" + modelLL + "','" + machine + "','" + pwbType + "','" + prog + "','" + rev + "','" + pcb + "','"+ llUsage + "')";
                   

                    conn.Open();
                    //Buka koneksi

                    string[] allQuery = { queryLL };
                    for (int i = 0; i < allQuery.Length; i++)
                    {
                        cmd.CommandText = allQuery[i];
                        //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                        cmd.ExecuteNonQuery();
                        //Jalankan perintah / query dalam CommandText pada database
                    }

                    for (int i = 0; i < dataGridViewLL.Rows.Count; i++)
                    {
                        // query insert data part code
                        string StrQuery = "INSERT INTO tbl_partcodedetail VALUES ('" + model + "','" + process + "','"
                            + dataGridViewLL.Rows[i].Cells[1].Value.ToString() + "', '"
                            + dataGridViewLL.Rows[i].Cells[2].Value.ToString() + "', '"
                            + dataGridViewLL.Rows[i].Cells[5].Value.ToString() + "');";

                        cmd.CommandText = StrQuery;
                        cmd.ExecuteNonQuery();
                    }

                    for (int j = 0; j < dataGridViewLL.Rows.Count; j++)
                    {
                        if (dataGridViewLL.Rows[j].Cells[0].Value.ToString() != "")
                    {
                        string StrQueryLLDetail = "INSERT INTO tbl_lldetail VALUES ('" + model + "','" + process + "','"
                        + dataGridViewLL.Rows[j].Cells[0].Value.ToString() + "', '"
                        + dataGridViewLL.Rows[j].Cells[1].Value.ToString() + "', '1');";
                            cmd.CommandText = StrQueryLLDetail;
                            cmd.ExecuteNonQuery();


                            string StrQueryReelDetail = "INSERT INTO tbl_reel VALUES ('" + model + "','" + process + "','"
                        + dataGridViewLL.Rows[j].Cells[0].Value.ToString() + "', '"
                        + dataGridViewLL.Rows[j].Cells[3].Value.ToString() + "', '"
                        + dataGridViewLL.Rows[j].Cells[4].Value.ToString() + "', '"
                        + dataGridViewLL.Rows[j].Cells[6].Value.ToString() + "');";
                            cmd.CommandText = StrQueryReelDetail;
                            cmd.ExecuteNonQuery();


                        }
                        else if (dataGridViewLL.Rows[j].Cells[0].Value.ToString() == "" || dataGridViewLL.Rows[--j].Cells[0].Value.ToString() != "")
                        {
                            //MessageBox.Show(dataGridViewLL.Rows[--j].Cells[0].Value.ToString(), "Loading List", MessageBoxButtons.OK, MessageBoxIcon.Information);                           
                            
                            string StrQueryLLDetails = "INSERT INTO tbl_lldetail VALUES ('" + model + "','" + process + "','"
                        + dataGridViewLL.Rows[--j].Cells[0].Value.ToString() + "', '"
                        + dataGridViewLL.Rows[j].Cells[1].Value.ToString() + "', '2');";

                            cmd.CommandText = StrQueryLLDetails;
                            cmd.ExecuteNonQuery();

                            j++;
                        }

                        //else if (dataGridViewLL.Rows[j].Cells[0].Value.ToString() == "" || dataGridViewLL.Rows[--j].Cells[0].Value.ToString() == "" || dataGridViewLL.Rows[2-j].Cells[0].Value.ToString() != "")
                        //{
                        //    MessageBox.Show(dataGridViewLL.Rows[2-j].Cells[0].Value.ToString(), "Loading List", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //    //string StrQueryLLDetails = "UPDATE tbl_lldetail SET choice3 = '" + dataGridViewLL.Rows[j].Cells[1].Value.ToString() + "' WHERE model_No = '" + model + "' AND process_Name = '" + process + "' AND reel = '" + dataGridViewLL.Rows[2-j].Cells[0].Value.ToString() + "'; ";

                        //    //cmd.CommandText = StrQueryLLDetails;
                        //    //cmd.ExecuteNonQuery();

                        //    j = j + 2;
                        //}

                    }

                    conn.Close();
                    //Tutup koneksi

                    MessageBox.Show("Loading List Successfully saved", "Loading List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    saveButton.Enabled = true;

                    this.Close();
                    LoadingList ll = new LoadingList();
                    ll.Show();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    saveButton.Enabled = true;
                }
            }
        }
    }
}
