using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CompareWOLL
{
    public partial class importWO : Form
    {
        LoadForm lf = new LoadForm();
        Helper help = new Helper();
        MySqlConnection connection = new MySqlConnection("server=192.168.1.1;database=pedev;user=root;password=12345;");
        public importWO()
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


        private void addWO_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            dataGridViewWO.ReadOnly = true;

            browseWO.Enabled = false;
            saveButton.Enabled = false;

            connection.Open();

            string queryCustDropDown = "SELECT custname FROM tbl_customer WHERE detail = 'wo'";

            try
            {
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryCustDropDown, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    if (dset.Rows.Count > 0)
                    {
                        for (int j = 0; j < dset.Rows.Count; j++)
                        {
                            cmbCustomer.Items.Add(dset.Rows[j][0]);
                            cmbCustomer.ValueMember = dset.Rows[j][0].ToString();
                        }
                    }
                    else
                    {
                    }
                }

                connection.Close();

            }
            catch (Exception ex)
            {
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }
        }

        private void browseWO_Click(object sender, EventArgs e)
        {
            string filePathWO = string.Empty;
            string fileExtWO = string.Empty;
            string queryWO = string.Empty;
            string queryPcbNo = string.Empty;

            openFileDialogWO.Title = "Please Select a File Work Order";
            openFileDialogWO.Filter = "Excel Files|*.xls;*.xlsx;";
            if (openFileDialogWO.ShowDialog() == DialogResult.OK)
            {

                tbfilepathWO.Text = "";
                tbwoPTSN.Text = "";
                tbwoNo.Text = "";
                tbmodelNo.Text = "";
                tbmodel.Text = "";
                tbtotalPart.Text = "";
                tbtotalUsage.Text = "";
                tbwoQty.Text = "";

                tbtotalPart.BackColor = SystemColors.Control;
                tbtotalUsage.BackColor = SystemColors.Control;
                tbwoQty.BackColor = SystemColors.Control;

                string woFileName = openFileDialogWO.FileName;
                tbfilepathWO.Text = woFileName;
                fileExtWO = Path.GetExtension(woFileName).ToLower(); //get the file extension  
                queryWO = "select * from [Sheet1$A2:M]";


                if (fileExtWO.CompareTo(".xls") == 0 || fileExtWO.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = help.ReadExcel(woFileName, fileExtWO, queryWO); //read excel file  
                        dataGridViewWO.Visible = true;
                        dataGridViewWO.DataSource = dtExcel;

                        dataGridViewWO.Columns.RemoveAt(1);
                        dataGridViewWO.Columns.RemoveAt(5);
                        dataGridViewWO.Columns.RemoveAt(8);

                        tbwoPTSN.Text = dataGridViewWO.Rows[0].Cells[8].Value.ToString();
                        tbwoNo.Text = dataGridViewWO.Rows[0].Cells[5].Value.ToString();
                        tbmodelNo.Text = dataGridViewWO.Rows[0].Cells[2].Value.ToString();
                        tbmodel.Text = dataGridViewWO.Rows[0].Cells[0].Value.ToString();
                        tbwoQty.Text = dataGridViewWO.Rows[0].Cells[9].Value.ToString();
                        tbtotalPart.Text = dataGridViewWO.Rows.Count.ToString();

                        //bool pcbNoo = dataGridViewWO.Rows[0].Cells[2].Value.ToString().StartsWith("35");
                        //pcbNo.Text = pcbNoo.ToString();
                        //woUsage.Text = dataGridViewWO.Rows.Count.ToString();

                        // Set table title Wo
                        string[] titleWO = { "Model", "Part No", "Model No", "Usage", "Issue", "WO No", "BOM Row", "Process", "WO PTSN", "WO Qty" };
                        for (int i = 0; i < titleWO.Length; i++)
                        {
                            dataGridViewWO.Columns[i].HeaderText = "" + titleWO[i];
                        }

                        // menandai merah jika ada  cell kosong
                        int count = 0;
                        for (int i = 0; i < dataGridViewWO.Rows.Count; ++i)
                        {
                            for (int j = 0; j < dataGridViewWO.Columns.Count; j++)
                            {
                                var cellValue = dataGridViewWO.Rows[i].Cells[j].Value;

                                if (cellValue == null ||
                                    cellValue == DBNull.Value || string.IsNullOrEmpty(cellValue.ToString()))
                                {
                                    dataGridViewWO.Rows[i].Cells[j].Style.BackColor = Color.Red;
                                    count++;
                                }
                            }
                        }
                        //notif message cell blank
                        if (count > 0)
                        {
                            MessageBox.Show("There is " + count.ToString() + " cell is blank, Please revise the document ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error                        
                        }

                        //menandai merah jika cell partcode sama dengan cell model
                        for (int i = 0; i < dataGridViewWO.Rows.Count; ++i)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                string cellPartNo = dataGridViewWO.Rows[i].Cells[1].Value.ToString();
                                string cellModelNo = dataGridViewWO.Rows[i].Cells[2].Value.ToString();

                                if (cellPartNo == cellModelNo)
                                {
                                    dataGridViewWO.Rows[i].Cells[1].Style.BackColor = Color.Red;
                                    dataGridViewWO.Rows[i].Cells[2].Style.BackColor = Color.Red;
                                }
                            }                            
                        }

                        // mendai merah jika data 1 column tidak sama
                        for (int i = 0; i < dataGridViewWO.Rows.Count; ++i)
                        {
                            var cellValueModel = dataGridViewWO.Rows[i].Cells[0].Value.ToString();
                            var cellValueModelNo = dataGridViewWO.Rows[i].Cells[2].Value.ToString();
                            var cellValueWO = dataGridViewWO.Rows[i].Cells[5].Value.ToString();
                            var cellValueProcess = dataGridViewWO.Rows[i].Cells[7].Value.ToString();
                            var cellValueWoPtsn = dataGridViewWO.Rows[i].Cells[8].Value.ToString();
                            var cellValueWoQty = dataGridViewWO.Rows[i].Cells[9].Value.ToString();
                            float ValueWoQty;

                            var cellValueUsage = dataGridViewWO.Rows[i].Cells[3].Value.ToString();
                            float ValueUsage;

                            if (cellValueModel != tbmodel.Text)
                            {
                                dataGridViewWO.Rows[i].Cells[0].Style.BackColor = Color.Red;
                                count++;
                            }
                            if (cellValueModelNo != tbmodelNo.Text)
                            {
                                dataGridViewWO.Rows[i].Cells[2].Style.BackColor = Color.Red;
                                count++;
                            }
                            if (cellValueWO != tbwoNo.Text)
                            {
                                dataGridViewWO.Rows[i].Cells[5].Style.BackColor = Color.Red;
                                count++;
                            }

                            if (cellValueWoPtsn != tbwoPTSN.Text)
                            {
                                dataGridViewWO.Rows[i].Cells[8].Style.BackColor = Color.Red;
                                count++;
                            }
                            if (cellValueWoQty != tbwoQty.Text)
                            {
                                dataGridViewWO.Rows[i].Cells[9].Style.BackColor = Color.Red;
                                count++;
                            }

                            if (!Single.TryParse(cellValueWoQty, NumberStyles.Any, CultureInfo.InvariantCulture, out ValueWoQty))
                            {
                                dataGridViewWO.Rows[i].Cells[9].Style.BackColor = Color.Red;
                            }

                            if (!Single.TryParse(cellValueUsage, NumberStyles.Any, CultureInfo.InvariantCulture, out ValueUsage))
                            {
                                dataGridViewWO.Rows[i].Cells[3].Style.BackColor = Color.Red;
                                //dataGridViewWO.Rows[i].Cells[3].ToolTipText = "Change Data be Number";
                            }
                        }

                        //show total qty component
                        int sum = 0;
                        for (int i = 0; i < dataGridViewWO.Rows.Count; ++i)
                        {
                            //get total qty component
                            sum += Convert.ToInt32(dataGridViewWO.Rows[i].Cells[3].Value);

                            DataGridViewCellStyle styleOk = new DataGridViewCellStyle();
                            styleOk.BackColor = Color.Green;
                            styleOk.ForeColor = Color.White;

                            DataGridViewCellStyle styleError = new DataGridViewCellStyle();
                            styleError.BackColor = Color.Red;
                            styleError.ForeColor = Color.White;

                            int woQtyy = Convert.ToInt32(dataGridViewWO.Rows[i].Cells[3].Value);
                            int usagge = Convert.ToInt32(dataGridViewWO.Rows[i].Cells[9].Value);
                            int totalissue = woQtyy * usagge;


                            if (Convert.ToInt32(dataGridViewWO.Rows[i].Cells[4].Value) !=
                                totalissue)
                            {
                                tbtotalPart.Text = "#Erorr";
                                tbtotalPart.BackColor = System.Drawing.Color.Red;

                                tbtotalUsage.Text = "#Erorr";
                                tbtotalUsage.BackColor = System.Drawing.Color.Red;

                                this.tbwoQty.Text = "#Erorr";
                                this.tbwoQty.BackColor = System.Drawing.Color.Red;

                                dataGridViewWO.Rows[i].DefaultCellStyle = styleError;
                            }
                            if (tbtotalPart.Text == "#Erorr" || tbtotalUsage.Text == "#Erorr" || this.tbwoQty.Text == "#Erorr")
                            {
                                saveButton.Enabled = false;
                            }
                            else
                            {
                                saveButton.Enabled = true;
                            }
                        }

                        string totalUsage = sum.ToString();
                        tbtotalUsage.Text = totalUsage;
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message.ToString());

                        MessageBox.Show("Please select Work Order file with correct format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error 
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }

                // not allow to sort table
                for (int i = 0; i < dataGridViewWO.Columns.Count; i++)
                {
                    dataGridViewWO.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            saveButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            StartProgress("Loading...");

            homeButton.Enabled = false;
            backButton.Enabled = false;
            System.Threading.Thread.Sleep(2000);

            string woPTSNN = tbwoPTSN.Text;
            string woNoo = tbwoNo.Text;
            string modelNoo = tbmodelNo.Text;
            string modell = tbmodel.Text;
            string woqtyy = tbtotalUsage.Text;
            string wousagee = tbwoQty.Text;
            string customer = cmbCustomer.Text;
            saveButton.Enabled = false;


            if (woPTSNN == "" | woNoo == "" | modelNoo == "" | modell == "" | woqtyy == "")
            {
                CloseProgress();
                saveButton.Enabled = true;
                MessageBox.Show("Unable to import Work Order without fill data properly", "Work Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                homeButton.Enabled = true;
                backButton.Enabled = true;
            }

            else
            {
                try
                {
                    var cmd = new MySqlCommand("", connection);

                    connection.Open();
                    //Buka koneksi

                    string cekwoPTSN = "SELECT wo_PTSN FROM tbl_wo  WHERE wo_PTSN = '" + woPTSNN + "'";
                    string query = "INSERT INTO tbl_wo (id, wo_PTSN, wo_No, model_No, model, wo_QTY, wo_Usage, Customer, detail) VALUES (null, '" + woPTSNN + "','" + woNoo + "','" + modelNoo + "','" + modell + "', '" + woqtyy + "', '" + wousagee + "', '" + customer + "', 'wo')";
                    string querymodel = "INSERT INTO tbl_model ( wo_PTSN, process_Name ) SELECT wo_PTSN, process_Name FROM tbl_wodetail GROUP BY process_Name, wo_PTSN";
                    string trncteModel = "TRUNCATE tbl_model";

                    using (MySqlDataAdapter dscmd = new MySqlDataAdapter(cekwoPTSN, connection))
                    {
                        DataSet ds = new DataSet();
                        dscmd.Fill(ds);

                        if (ds.Tables[0].Rows.Count >= 1)
                        {
                            CloseProgress();
                            MessageBox.Show("Work Order PTSN " + woPTSNN + "  already uploaded", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                            tbfilepathWO.Text = "";
                            tbwoPTSN.Text = "";
                            tbwoNo.Text = "";
                            tbmodelNo.Text = "";
                            tbmodel.Text = "";
                            tbtotalPart.Text = "";
                            tbtotalUsage.Text = "";
                            tbwoQty.Text = "";
                            dataGridViewWO.DataSource = null;
                            dataGridViewWO.Refresh();

                            homeButton.Enabled = true;
                            backButton.Enabled = true;

                            connection.Close();
                        }

                        else
                        {

                            cmd.CommandText = trncteModel;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();

                            for (int i = 0; i < dataGridViewWO.Rows.Count; i++)
                            {
                                string StrQuery = "INSERT INTO tbl_wodetail VALUES ('"
                                    + dataGridViewWO.Rows[i].Cells[8].Value.ToString() + "', '"
                                    + dataGridViewWO.Rows[i].Cells[1].Value.ToString() + "', '"
                                    + dataGridViewWO.Rows[i].Cells[7].Value.ToString() + "', '"
                                    + dataGridViewWO.Rows[i].Cells[3].Value.ToString() + "', '"
                                    + dataGridViewWO.Rows[i].Cells[6].Value.ToString() + "', '"
                                    + dataGridViewWO.Rows[i].Cells[4].Value.ToString() + "');";
                                cmd.CommandText = StrQuery;
                                cmd.ExecuteNonQuery();
                            }

                            cmd.CommandText = querymodel;
                            cmd.ExecuteNonQuery();

                            connection.Close();
                            //Tutup koneksi
                            CloseProgress();
                            MessageBox.Show("Work Order Successfully saved", "Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            saveButton.Enabled = true;

                            this.Close();
                            WorkOrder wo = new WorkOrder();
                            wo.Show();
                        }
                    }
                }
                catch (Exception ex)
                {
                    CloseProgress();
                    MessageBox.Show(ex.Message.ToString());
                    connection.Close();
                    saveButton.Enabled = true;
                    homeButton.Enabled = true;
                    backButton.Enabled = true;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.toolStripUsername.Text = toolStripUsername.Text;
            mm.Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            WorkOrder wo = new WorkOrder();
            wo.toolStripUsername.Text = toolStripUsername.Text;
            wo.Show();
            this.Hide();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            browseWO.Enabled = true;
        }
    }
}
