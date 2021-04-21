using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class ImportLL : Form
    {
        Helper help = new Helper();
        MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
        LoadForm lf = new LoadForm();

        string filePathLL = string.Empty;
        string fileExtLL = string.Empty;
        string queryLL = string.Empty;
        string queryLLDetail = string.Empty;
        string queryGetPCBNo = string.Empty;
        string queryGetTotal = string.Empty;
        string queryGetStencil = string.Empty;
        string llUsage = string.Empty;
        string llPartTotal = string.Empty;
        int lengthProcess;

        public ImportLL()
        {
            InitializeComponent();
        }

        //The below is the key for showing Progress bar
        private void StartProgress(String strStatusText)
        {
            LoadForm lf = new LoadForm();
            ShowProgress();
        }
        private void CloseProgress()
        {
            //Thread.Sleep(200);
            while (!this.IsHandleCreated)
                System.Threading.Thread.Sleep(200);
            lf.Invoke(new Action(lf.Close));
        }
        private void ShowProgress()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    try
                    {
                        lf.ShowDialog();
                    }
                    catch (Exception ex) { }
                }
                else
                {
                    Thread th = new Thread(ShowProgress);
                    th.IsBackground = false;
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void importLL_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            dataGridViewLLHide.Visible = false;
            saveButton.Enabled = false;
            browseLL.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            lf.Close();
            WorkOrder wo = new WorkOrder();
            wo.toolStripUsername.Text = toolStripUsername.Text;
            wo.Show();
            this.Hide();
        }

        private void cmbProcess_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            browseLL.Enabled = true;
            lengthProcess = cmbProcess.Text.Length + 1;
        }

        private void browseWO_Click(object sender, EventArgs e)
        {

            tbPcbNo.BackColor = SystemColors.Control;

            openFileDialogLL.Title = "Please Select a File Loading List";
            openFileDialogLL.Filter = "Excel Files|*.xls;*.xlsx;";
            openFileDialogLL.InitialDirectory = @"D:\";
            if (openFileDialogLL.ShowDialog() == DialogResult.OK)
            {
                saveButton.Enabled = true;
                string woFileName = openFileDialogLL.FileName;
                filepathLL.Text = woFileName;
                fileExtLL = Path.GetExtension(woFileName).ToLower(); //get the file extension  
                queryLL = "select * from [Sheet1$A2:I]";
                queryLLDetail = "select * from [Sheet1$A8:I]";
                queryGetPCBNo = "select * from [Sheet1$E9:E]";
                queryGetTotal = "select * from [Sheet1$E9:E]";
                queryGetStencil = "select * from [Sheet1$G9:G]";

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


                        //verify excel file is correct
                        string modelLL = tbModel.Text;
                        modelLL = modelLL.Replace(" ", String.Empty);

                        string modelLLNO = modelLL.Substring(3, 12);
                        string processLL = modelLL.Substring(modelLL.Length - lengthProcess).Replace(")", "");

                        if (modelLL == tbModelNo.Text || processLL == cmbProcess.Text)
                        {
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

                            DataView dataView = dtExcel2.DefaultView;
                            dataView.Table.Columns[0].ColumnName = "F1";
                            dataView.RowFilter = "F1 LIKE '%PCB NO%'";
                            dataGridViewPCBNo.DataSource = dataView;

                            if (dataView.Count > 0)
                            {
                                tbPcbNo.Text = dataGridViewPCBNo.Rows[0].Cells[0].Value.ToString().Substring(11, 12);
                            }
                            else if (dataView.Count == 0)
                            {
                                tbPcbNo.BackColor = Color.Red;
                                MessageBox.Show("PCB No Not Found, Please check again the document.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                saveButton.Enabled = false;
                            }


                            // baca stencil
                            DataTable dtExcel5 = new DataTable();
                            dtExcel5 = help.ReadExcel(woFileName, fileExtLL, queryGetStencil); //read excel file  

                            DataView dataView2 = dtExcel5.DefaultView;
                            dataView2.Table.Columns[0].ColumnName = "F1";
                            dataView2.RowFilter = "F1 LIKE '% STENCIL NO : %'";
                            dataGridViewStencil.DataSource = dataView2;

                            if (dataView2.Count > 0)
                            {
                                tbStencil.Text = dataGridViewStencil.Rows[0].Cells[0].Value.ToString().Substring(14);
                            }
                            else if (dataView2.Count == 0)
                            {
                                tbStencil.BackColor = Color.Red;
                                MessageBox.Show("Stencil No Not Found, Please check again the document.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                                saveButton.Enabled = false;
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

                            //delete data start from text pcb No
                            for (int i = rowLL - 1; i > rowIndex; i--)
                            {
                                dataGridViewLL.Rows.RemoveAt(i);
                            }

                            int sum = 0;
                            int totalPartCode = 0;
                            for (int i = 0; i < dataGridViewLL.Rows.Count; ++i)
                            {
                                //show total qty component
                                if (dataGridViewLL.Rows[i].Cells[3].Value == System.DBNull.Value)
                                {
                                    dataGridViewLL.Rows[i].Cells[3].Value = "0";
                                }

                                if (dataGridViewLL.Rows[i].Cells[1].Value.ToString() != "")
                                {
                                    totalPartCode++;
                                }
                                //get total qty component
                                sum += Convert.ToInt32(dataGridViewLL.Rows[i].Cells[3].Value);

                            }

                            //sum = sum + 1;
                            llUsage = sum.ToString();
                            totalPoint.Text = llUsage;
                            totalPart.Text = totalPartCode.ToString();

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

                            int count = 0;
                            int[] slctdColumn = { 4 };
                            for (int i = 0; i < dataGridViewLL.Rows.Count; ++i)
                            {
                                for (int j = 0; j < slctdColumn.Length; j++)
                                {
                                    var cellValue = dataGridViewLL.Rows[i].Cells[slctdColumn[j]].Value;
                                    //var cellPosition = dataGridViewWO.Rows[i].Cells[j];

                                    if (cellValue == null ||
                                        cellValue == DBNull.Value || string.IsNullOrEmpty(cellValue.ToString()))
                                    {
                                        dataGridViewLL.Rows[i].Cells[slctdColumn[j]].Style.BackColor = Color.Red;
                                        count++;
                                    }
                                }
                            }
                            if (count > 0)
                            {
                                MessageBox.Show("There is " + count.ToString() + " cell is blank, Please revise the document ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error                        
                            }
                        }
                        else if (modelLL != tbModelNo.Text || processLL != cmbProcess.Text)
                        {
                            MessageBox.Show("Excel file contain Model " + modelLLNO + " and Process " + processLL + " not match with selected Model No and Process, Please check again the document.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                            filepathLL.Text = "";
                            tbModel.Text = "";
                            tbMachine.Text = "";
                            tbPWBType.Text = "";
                            tbProg.Text = "";
                            tbRev.Text = "";
                            tbPcbNo.Text = "";
                            tbStencil.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                        //MessageBox.Show("Ada error ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }

        private void cmbProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            browseLL.Enabled = true;
        }

        private void tbPcbNo_TextChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                backButton.Enabled = false;
                StartProgress("Loading...");
                //lf.Show();

                string cust = tbCust.Text;
                string model = tbModelNo.Text;
                string modelLL = tbModel.Text;
                string machine = tbMachine.Text;
                string pwbType = tbPWBType.Text;
                string prog = tbProg.Text;
                string rev = tbRev.Text;
                string pcb = tbPcbNo.Text;
                string stencil = tbStencil.Text;
                string remark = tbRemark.Text;
                string process = cmbProcess.Text;

                saveButton.Enabled = false;

                if (model == "" | process == "" | modelLL == "" | machine == "" | pwbType == "" | prog == "" | pcb == "")
                {
                    CloseProgress();
                    MessageBox.Show("Unable to import Work Order without fill data properly", "Work Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    saveButton.Enabled = true;
                    backButton.Enabled = true;
                }

                else
                {
                    try
                    {
                        
                        var cmd = new MySqlCommand("", connection);

                        string cekmodel = "SELECT model_No, process_Name FROM tbl_ll  WHERE model_No = '" + model + "'AND process_Name ='" + process + "'";
                        string cekPCB = "SELECT * FROM tbl_lldetail WHERE partcode = '" + pcb + "' AND model_No = '" + model + "' AND reel = 'PCB'";
                        string queryLL = "INSERT INTO tbl_ll VALUES('','" + cust + "','" + model + "','" + process + "','" + modelLL + "','" + machine + "','" + pwbType + "','" + prog + "','" + rev + "','" + pcb + "','" + llUsage + "','" + stencil + "','" + remark + "')";
                        string queryInputPCB = "INSERT INTO tbl_lldetail VALUES ('" + model + "','" + process + "','PCB', '" + pcb + "', '1', '1');";
                        string queryAddPartCodePCB = "INSERT INTO tbl_partcodedetail VALUES ('" + model + "','" + process + "','PCB',  '" + pcb + "', '','PCB' ); ";

                        connection.Open();
                        //Buka koneksi

                        using (MySqlDataAdapter dscmd = new MySqlDataAdapter(cekmodel, connection))
                        {
                            DataSet ds = new DataSet();
                            dscmd.Fill(ds);

                            if (ds.Tables[0].Rows.Count >= 1)
                            {
                                lf.Hide();
                                MessageBox.Show("Loading List Data Model " + model + " and Process " + process + "  already uploaded", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                                backButton.Enabled = true;
                            }

                            else
                            {
                                MySqlCommand cmddb = new MySqlCommand(cekPCB, connection);
                                MySqlDataAdapter da = new MySqlDataAdapter(cmddb);
                                DataSet ds1 = new DataSet();
                                da.Fill(ds1);
                                int l = ds1.Tables[0].Rows.Count;
                                if (l == 0)
                                {
                                    string[] allQuery = { queryLL, queryInputPCB, queryAddPartCodePCB };
                                    for (int i = 0; i < allQuery.Length; i++)
                                    {
                                        cmd.CommandText = allQuery[i];
                                        //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                                        cmd.ExecuteNonQuery();
                                        //Jalankan perintah / query dalam CommandText pada database
                                    }
                                }
                                else
                                {
                                    string[] allQuery = { queryLL, queryAddPartCodePCB };
                                    for (int i = 0; i < allQuery.Length; i++)
                                    {
                                        cmd.CommandText = allQuery[i];
                                        //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                                        cmd.ExecuteNonQuery();
                                        //Jalankan perintah / query dalam CommandText pada database
                                    }
                                }                                

                                for (int i = 0; i < dataGridViewLL.Rows.Count; i++)
                                {
                                    string prtCode = dataGridViewLL.Rows[i].Cells[1].Value.ToString();

                                    if (prtCode != "")
                                    {
                                        // query insert data part code
                                        string StrQuery = "INSERT INTO tbl_partcodedetail VALUES ('" + model + "','" + process + "','"
                                            + dataGridViewLL.Rows[i].Cells[0].Value.ToString() + "','"
                                            + dataGridViewLL.Rows[i].Cells[1].Value.ToString() + "', '"
                                            + dataGridViewLL.Rows[i].Cells[2].Value.ToString() + "', '"
                                            + dataGridViewLL.Rows[i].Cells[5].Value.ToString() + "');";

                                        cmd.CommandText = StrQuery;
                                        cmd.ExecuteNonQuery();
                                    }
                                }

                                String reelID = "";
                                String qty = "";
                                String loc = "";

                                int altNo = 1;

                                for (int j = 0; j < dataGridViewLL.Rows.Count; j++)
                                {
                                    if (dataGridViewLL.Rows[j].Cells[0].Value.ToString() != "")
                                    {
                                        reelID = dataGridViewLL.Rows[j].Cells[0].Value.ToString();
                                        qty = dataGridViewLL.Rows[j].Cells[3].Value.ToString();
                                        altNo = 1;
                                        string StrQueryReelDetail = "INSERT INTO tbl_reel VALUES ('','"
                                            + reelID + "', '" + model + "','" + process + "','" + dataGridViewLL.Rows[j].Cells[3].Value.ToString() + "', '"
                                            + dataGridViewLL.Rows[j].Cells[4].Value.ToString() + "', '"
                                            + dataGridViewLL.Rows[j].Cells[6].Value.ToString() + "');";

                                        cmd.CommandText = StrQueryReelDetail;
                                        cmd.ExecuteNonQuery();

                                        string StrQueryLLDetail = "INSERT INTO tbl_lldetail VALUES ('" + model + "','" + process + "','"
                                   + reelID + "', '"
                                   + dataGridViewLL.Rows[j].Cells[1].Value.ToString() + "','" + altNo + "', '"
                                   + qty + "');";
                                        cmd.CommandText = StrQueryLLDetail;
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        //update location
                                        loc = dataGridViewLL.Rows[j].Cells[4].Value.ToString();

                                        string StrQueryAddLoc = "UPDATE tbl_reel SET loc = CONCAT(loc,'" + loc + "') " +
                                            "WHERE reel = '" + reelID + "' AND tbl_reel.model_No = '" + model + "'";
                                        cmd.CommandText = StrQueryAddLoc;
                                        cmd.ExecuteNonQuery();
                                    }

                                    
                                }

                                connection.Close();
                                //Tutup koneksi
                                CloseProgress();

                                MessageBox.Show("Loading List Successfully saved", "Loading List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                saveButton.Enabled = true;
                                backButton.Enabled = true;

                                cmbProcess.Items.Remove(cmbProcess.SelectedItem);
                                filepathLL.Text = "";
                                tbModel.Text = "";
                                tbPWBType.Text = "";
                                tbMachine.Text = "";
                                tbProg.Text = "";
                                tbRev.Text = "";
                                tbPcbNo.Text = "";
                                tbStencil.Text = "";
                                totalPoint.Text = "";
                                totalPart.Text = "";
                                dataGridViewLL.DataSource = null;
                                dataGridViewLL.Refresh();

                                var count = cmbProcess.Items.Count;

                                if (count > 0)
                                {
                                    MessageBox.Show("Continue Import Other Process", "Loading List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cmbProcess.SelectedItem = cmbProcess.Items[0];
                                }
                                else if (count == 0)
                                {
                                    string message = "Do you want to compare this model ?";
                                    string title = "Compare WO vs LL";
                                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                    DialogResult result = MessageBox.Show(message, title, buttons);
                                    if (result == DialogResult.Yes)
                                    {
                                        Compare cowl = new Compare();
                                        //cowl.cmbWOModel.SelectedItem = cowl.cmbWOModel.Items[0];
                                        cowl.cmbWOModel.SelectedItem = tbModelNo.Text;
                                        cowl.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        LoadingList ll = new LoadingList();
                                        ll.Show();
                                        this.Hide();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CloseProgress();
                        MessageBox.Show(ex.Message.ToString());
                        backButton.Enabled = true;
                        saveButton.Enabled = true;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}