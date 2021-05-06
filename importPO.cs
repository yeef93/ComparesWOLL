using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class importPO : Form
    {
        LoadForm lf = new LoadForm();
        Helper help = new Helper();
        MySqlConnection connection = new MySqlConnection("server=192.168.1.1;database=pedev;user=root;password=12345;");

        public importPO()
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

        private void homeButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.toolStripUsername.Text = toolStripUsername.Text;
            mm.Show();
            this.Hide();
        }

        private void importSO_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            dataGridViewPO.ReadOnly = true;

            browseSO.Enabled = false;
            saveButton.Enabled = false;
            connection.Open();

            string queryCustDropDown = "SELECT custname FROM tbl_customer WHERE detail = 'po'";

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

        private void backButton_Click(object sender, EventArgs e)
        {
            PurchaseOrder so = new PurchaseOrder();
            so.toolStripUsername.Text = toolStripUsername.Text;
            so.Show();
            this.Hide();
        }

        private void browseSO_Click(object sender, EventArgs e)
        {
            string filePathPO = string.Empty;
            string fileExtPO = string.Empty;
            string queryPO = string.Empty;

            openFileDialogPO.Title = "Please Select a File Purchase Order";
            openFileDialogPO.Filter = "Excel Files|*.xls;*.xlsx;";
            if (openFileDialogPO.ShowDialog() == DialogResult.OK)
            {
                tbfilepathPO.Text = "";
                tbPoModel.Text = "";
                tbPoNo.Text = "";

                tbtotalPart.BackColor = SystemColors.Control;
                tbtotalUsage.BackColor = SystemColors.Control;
                tbPoQty.BackColor = SystemColors.Control;

                string poFileName = openFileDialogPO.FileName;
                tbfilepathPO.Text = poFileName;
                fileExtPO = Path.GetExtension(poFileName).ToLower(); //get the file extension  
                queryPO = "select * from [Sheet1$A6:F]";


                if (fileExtPO.CompareTo(".xls") == 0 || fileExtPO.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = help.ReadExcel(poFileName, fileExtPO, queryPO); //read excel file  
                        dataGridViewPO.Visible = true;
                        dataGridViewPO.DataSource = dtExcel;

                        tbPoNo.Text = dataGridViewPO.Rows[0].Cells[0].Value.ToString();
                        tbPoModel.Text = dataGridViewPO.Rows[0].Cells[1].Value.ToString();
                        tbtotalPart.Text = dataGridViewPO.Rows.Count.ToString();
                        //tbtotalUsage.Text = dataGridViewPO.Rows[0].Cells[4].Value.ToString();
                        tbPoQty.Text = dataGridViewPO.Rows[0].Cells[5].Value.ToString();


                        // Set table title Wo
                        string[] titleWO = { "PO Number", "Model", "PART NO", "PART NAME", "U/Q", "Usage Qty" };
                        for (int i = 0; i < titleWO.Length; i++)
                        {
                            dataGridViewPO.Columns[i].HeaderText = "" + titleWO[i];
                        }

                        // menandai merah jika ada  cell kosong
                        int count = 0;
                        for (int i = 0; i < dataGridViewPO.Rows.Count; ++i)
                        {
                            for (int j = 0; j < dataGridViewPO.Columns.Count; j++)
                            {
                                var cellValue = dataGridViewPO.Rows[i].Cells[j].Value;
                                //var cellPosition = dataGridViewWO.Rows[i].Cells[j];

                                if (cellValue == null ||
                                    cellValue == DBNull.Value || string.IsNullOrEmpty(cellValue.ToString()))
                                {
                                    dataGridViewPO.Rows[i].Cells[j].Style.BackColor = Color.Red;
                                    count++;
                                }
                            }
                        }
                        //notif message cell blank
                        if (count > 0)
                        {
                            MessageBox.Show("There is " + count.ToString() + " cell is blank, Please revise the document ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error                        
                        }

                        // mendadai merah jika data 1 column tidak sama
                        for (int i = 0; i < dataGridViewPO.Rows.Count; ++i)
                        {
                            var cellValuePONumber = dataGridViewPO.Rows[i].Cells[0].Value.ToString();
                            var cellValueModel = dataGridViewPO.Rows[i].Cells[1].Value.ToString();

                            if (cellValuePONumber != tbPoNo.Text)
                            {
                                dataGridViewPO.Rows[i].Cells[0].Style.BackColor = Color.Red;
                                count++;
                            }

                            if (cellValueModel != tbPoModel.Text)
                            {
                                dataGridViewPO.Rows[i].Cells[1].Style.BackColor = Color.Red;
                                count++;
                            }
                        }


                        //show total qty component
                        int sum = 0;
                        for (int i = 0; i < dataGridViewPO.Rows.Count; ++i)
                        {
                            //get total qty component
                            sum += Convert.ToInt32(dataGridViewPO.Rows[i].Cells[4].Value);

                            DataGridViewCellStyle styleOk = new DataGridViewCellStyle();
                            styleOk.BackColor = Color.Green;
                            styleOk.ForeColor = Color.White;

                            DataGridViewCellStyle styleError = new DataGridViewCellStyle();
                            styleError.BackColor = Color.Red;
                            styleError.ForeColor = Color.White;

                            int woQtyy = Convert.ToInt32(dataGridViewPO.Rows[i].Cells[4].Value);
                            int usagge = Convert.ToInt32(dataGridViewPO.Rows[0].Cells[5].Value);
                            int totalissue = woQtyy * usagge;


                            if (Convert.ToInt32(dataGridViewPO.Rows[i].Cells[5].Value) !=
                                totalissue)
                            {
                                tbtotalPart.Text = "#Erorr";
                                tbtotalPart.BackColor = System.Drawing.Color.Red;

                                tbtotalUsage.Text = "#Erorr";
                                tbtotalUsage.BackColor = System.Drawing.Color.Red;

                                tbPoQty.Text = "#Erorr";
                                tbPoQty.BackColor = System.Drawing.Color.Red;

                                dataGridViewPO.Rows[i].DefaultCellStyle = styleError;
                                saveButton.Enabled = false;
                            }
                        }

                        if (tbtotalPart.Text == "#Erorr" )
                        {
                            saveButton.Enabled = false;
                        }
                        else
                        {
                            saveButton.Enabled = true;
                        }

                        string totalUsage = sum.ToString();
                        tbtotalUsage.Text = totalUsage;
                        saveButton.Enabled = true;

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
                for (int i = 0; i < dataGridViewPO.Columns.Count; i++)
                {
                    dataGridViewPO.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            browseSO.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            StartProgress("Loading...");

            homeButton.Enabled = false;
            backButton.Enabled = false;
            System.Threading.Thread.Sleep(2000);

            string poNO = tbPoNo.Text;
            string poModel = tbPoModel.Text;
            string totalpart = tbtotalPart.Text;
            string totalUsage = tbtotalUsage.Text;
            string poqty = tbPoQty.Text;
            string customer = cmbCustomer.Text;
            saveButton.Enabled = false;

            if (poNO == "" | poModel == "" | totalpart == "" | totalUsage == "" | poqty == "")
            {
                CloseProgress();
                saveButton.Enabled = true;
                MessageBox.Show("Unable to import Purchase Order without fill data properly", "Work Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    string cekwoPTSN = "SELECT wo_No FROM tbl_wo  WHERE wo_No = '" + poNO + "'";
                    string query = "INSERT INTO tbl_wo (id, wo_PTSN, wo_No, model_No, model, wo_QTY, wo_Usage, customer, detail) VALUES " +
                        "(NULL,  '" + poNO + "', NULL, NULL, '" + poModel + "', '" + poqty + "', '" + totalUsage + "', '" + customer + "', 'po')";

                    using (MySqlDataAdapter dscmd = new MySqlDataAdapter(cekwoPTSN, connection))
                    {
                        DataSet ds = new DataSet();
                        dscmd.Fill(ds);

                        if (ds.Tables[0].Rows.Count >= 1)
                        {
                            CloseProgress();
                            MessageBox.Show("Purchase Order with PO No" + poNO + "  already uploaded", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                            tbfilepathPO.Text = "";
                            tbPoNo.Text = "";
                            tbPoModel.Text = "";
                            tbtotalPart.Text = "";
                            tbtotalUsage.Text = "";
                            tbPoQty.Text = "";
                            dataGridViewPO.DataSource = null;
                            dataGridViewPO.Refresh();

                            homeButton.Enabled = true;
                            backButton.Enabled = true;

                            connection.Close();
                        }

                        else
                        {

                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();

                            for (int i = 0; i < dataGridViewPO.Rows.Count; i++)
                            {
                                string StrQuery = "INSERT INTO tbl_wodetail VALUES ('"
                                    + dataGridViewPO.Rows[i].Cells[0].Value.ToString() + "', '"
                                    + dataGridViewPO.Rows[i].Cells[2].Value.ToString() + "', null, '"
                                    + dataGridViewPO.Rows[i].Cells[4].Value.ToString() + "', null, '"
                                    + dataGridViewPO.Rows[i].Cells[5].Value.ToString() + "');";
                                cmd.CommandText = StrQuery;
                                cmd.ExecuteNonQuery();
                            }

                            connection.Close();
                            //Tutup koneksi
                            CloseProgress();
                            MessageBox.Show("Purchase Order Successfully saved", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            saveButton.Enabled = true;

                            this.Close();
                            PurchaseOrder po = new PurchaseOrder();
                            po.Show();
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
    }
}
