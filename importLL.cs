using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class ImportLL : Form
    {
        Helper help = new Helper();
        public ImportLL()
        {
            InitializeComponent();
        }

        private void importLL_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            dataGridViewLLHide.Visible = false;
            saveButton.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.toolStripUsername.Text = toolStripUsername.Text;
            mm.Show();
            this.Hide();
        }

        private void browseWO_Click(object sender, EventArgs e)
        {
            string filePathLL = string.Empty;
            string fileExtLL = string.Empty;
            string queryLL = string.Empty;
            string queryLLDetail = string.Empty;
            string queryGetPCBNo = string.Empty;
            string queryGetAltPCB = string.Empty;
            string queryGetTotal = string.Empty;

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
                queryGetPCBNo = "select * from [Sheet1$E9:E]";
                queryGetAltPCB = "select * from [Sheet1$B9:B]";
                queryGetTotal = "select * from [Sheet1$E9:E]";

                if (fileExtLL.CompareTo(".xls") == 0 || fileExtLL.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        // baca data utama LL
                        DataTable dtExcel = new DataTable();
                        dtExcel = help.ReadExcel(woFileName, fileExtLL, queryLL); //read excel file  
                        dataGridViewLLHide.DataSource = dtExcel;

                        tbModel.Text = dataGridViewLLHide.Rows[0].Cells[0].Value.ToString().Remove(0, 12);
                        tbMachine.Text = dataGridViewLLHide.Rows[1].Cells[0].Value.ToString().Remove(0, 12);
                        tbPWBType.Text = dataGridViewLLHide.Rows[2].Cells[0].Value.ToString().Remove(0, 12);
                        tbProg.Text = dataGridViewLLHide.Rows[3].Cells[0].Value.ToString().Remove(0, 12);
                        tbRev.Text = dataGridViewLLHide.Rows[4].Cells[5].Value.ToString();

                        // baca data detail LL
                        DataTable dtExcel1 = new DataTable();
                        dtExcel1 = help.ReadExcel(woFileName, fileExtLL, queryLLDetail); //read excel file  
                        dataGridViewLL.DataSource = dtExcel1;

                        dataGridViewLL.Columns.RemoveAt(5);
                        dataGridViewLL.Columns.RemoveAt(6);

                        int rowLL = dataGridViewLL.Rows.Count;

                        // baca pcb No
                        DataTable dtExcel2 = new DataTable();
                        dtExcel2 = help.ReadExcel(woFileName, fileExtLL, queryGetPCBNo); //read excel file  
                        //dataGridViewPCBNo.DataSource = dtExcel2;

                        DataView dataView = dtExcel2.DefaultView;
                        dataView.RowFilter = "F1 LIKE '%PCB NO%'";
                        dataGridViewPCBNo.DataSource = dataView;

                        tbPcbNo.Text = dataGridViewPCBNo.Rows[0].Cells[0].Value.ToString().Substring(11, 12);


                        // baca Alt pcb No
                        DataTable dtExcel3 = new DataTable();
                        dtExcel3 = help.ReadExcel(woFileName, fileExtLL, queryGetAltPCB); //read excel file  
                        //dataGridViewPCBNo.DataSource = dtExcel2;

                        DataView dataView1 = dtExcel3.DefaultView;
                        dataView1.RowFilter = "F1 LIKE '%PCB%'";
                        dataGridAltPCB.DataSource = dataView1;

                        if (dataView1.Count > 0)
                        {
                            string allPCB = dataGridAltPCB.Rows[0].Cells[0].Value.ToString().Remove(0, 26);

                            //// Get 12 characters from the right of the string
                            //string altPCB1 = allPCB.Substring(allPCB.Length - 26, 12);

                            //// Get 12 characters from the right of the string
                            //string altPCB2 = allPCB.Substring(allPCB.Length - 12, 12);

                            // to split alt pcb if 2 pcb alt
                            string str = allPCB;
                            char ch = ',';

                            int freq = str.Split(ch).Length - 1;
                            var altpcb = str.Split(',');


                            tbAltPcbNo1.Text = altpcb[0].Replace(" ", "");
                            tbAltPcbNo2.Text = altpcb[1].Replace(" ", "");

                            //MessageBox.Show(freq.ToString());
                            //for (int i = 0; i < freq; i++)
                            //{
                            //    string a = altpcb[i];
                            //}

                        }

                        // buat cari batas total row
                        DataTable dtExcel4 = new DataTable();
                        dtExcel4 = help.ReadExcel(woFileName, fileExtLL, queryGetTotal); //read excel file  
                        dataGridViewGetTotalRow.DataSource = dtExcel4;
                        int totalrow = dataGridViewGetTotalRow.Rows.Count;

                        string searchingFor = " PCB NO";
                        int rowIndex = 0;
                        foreach (DataGridViewRow row in dataGridViewGetTotalRow.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.Value.ToString().Contains(searchingFor))
                                    rowIndex = row.Index;
                            }
                        }

                        //if (rowIndex > 0)
                        //    MessageBox.Show(rowIndex.ToString()+"Row found.");
                        //else
                        //    MessageBox.Show("Row not found. Searching value does not exist.");


                        for (int i = rowLL - 1; i >= rowIndex; i--)
                        {
                            dataGridViewLL.Rows.RemoveAt(i);
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

        private void cmbProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            browseLL.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string model = tbModelNo.Text;
            string process = tbProcess.Text;
            string modelLL = tbModel.Text;
            string machine = tbMachine.Text;
            string pwbType = tbPWBType.Text;
            string prog = tbProg.Text;
            string rev = tbRev.Text;
            string pcb = tbPcbNo.Text;
            string pcb1 = tbAltPcbNo1.Text;
            string pcb2 = tbAltPcbNo2.Text;
            string remark = tbRemark.Text;

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
            sum = sum + 1;

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

                    string queryLL = "INSERT INTO tbl_ll VALUES('','" + model + "','" + process + "','" + modelLL + "','" + machine + "','" + pwbType + "','" + prog + "','" + rev + "','" + pcb + "','" + llUsage + "','" + remark + "')";
                    string queryInputPCB = "INSERT INTO tbl_lldetail VALUES ('" + model + "','" + process + "','PCB', '" + pcb + "', '1', '1');";
                    string queryPCBAlt1 = "INSERT INTO tbl_lldetail VALUES ('" + model + "','" + process + "','PCB', '" + pcb1 + "', '2', '1');";
                    string queryPCBAlt2 = "INSERT INTO tbl_lldetail VALUES ('" + model + "','" + process + "','PCB', '" + pcb2 + "', '3', '1');";

                    conn.Open();
                    //Buka koneksi

                    string[] allQuery = { queryLL, queryInputPCB };
                    for (int i = 0; i < allQuery.Length; i++)
                    {
                        cmd.CommandText = allQuery[i];
                        //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                        cmd.ExecuteNonQuery();
                        //Jalankan perintah / query dalam CommandText pada database
                    }

                    if (queryPCBAlt1 != "")
                    {
                        cmd.CommandText = queryPCBAlt1;
                        cmd.ExecuteNonQuery();
                    }

                    if (queryPCBAlt2 != "")
                    {
                        cmd.CommandText = queryPCBAlt2;
                        cmd.ExecuteNonQuery();
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

                    String reelID = "";
                    int altNo = 1;

                    for (int j = 0; j < dataGridViewLL.Rows.Count; j++)
                    {
                        if (dataGridViewLL.Rows[j].Cells[0].Value.ToString() != "")
                        {
                            reelID = dataGridViewLL.Rows[j].Cells[0].Value.ToString();
                            altNo = 1;
                            string StrQueryReelDetail = "INSERT INTO tbl_reel VALUES ('"
                                + reelID + "', '" + model + "','" + process + "','"+ dataGridViewLL.Rows[j].Cells[3].Value.ToString() + "', '"
                                + dataGridViewLL.Rows[j].Cells[4].Value.ToString() + "', '"
                                + dataGridViewLL.Rows[j].Cells[6].Value.ToString() + "');";

                            cmd.CommandText = StrQueryReelDetail;
                            cmd.ExecuteNonQuery();
                        }

                        string StrQueryLLDetail = "INSERT INTO tbl_lldetail VALUES ('" + model + "','" + process + "','"
                        + reelID + "', '"
                        + dataGridViewLL.Rows[j].Cells[1].Value.ToString() + "','" + altNo + "', '"
                        + dataGridViewLL.Rows[j].Cells[3].Value.ToString() + "');";
                        cmd.CommandText = StrQueryLLDetail;
                        cmd.ExecuteNonQuery();
                        altNo++;
                    }

                    //foreach (DataGridViewRow row in dataGridViewLL.Rows)
                    //{
                    //    foreach (DataGridViewCell cell in row.Cells)
                    //    {
                    //        if (cell.Value.ToString() == "")
                    //        {
                    //            rowIndex = row.Index;
                    //            if (rowIndex.ToString() != "")
                    //            {
                    //                break;
                    //            }
                    //        }
                    //    }
                    //    MessageBox.Show(rowIndex.ToString());
                    //}

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

        private void tbPcbNo_TextChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
        }
    }
}