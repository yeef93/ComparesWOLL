using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class Compare : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
        ExcelConvert excelConvert = new ExcelConvert();
        string LLWONMPartCodes = string.Empty;
        string LLWONMQtys = string.Empty;
        string LLWONFPartCodes = string.Empty;
        string LLWONMPartCodeUseds = string.Empty;

        string WOLLNMPartCodes = string.Empty;
        string WOLLNMQtys = string.Empty;
        string WOLLNFPartCodes = string.Empty;
        string WOLLNMPartCodeUseds = string.Empty;
        string partcodeLLCheckSum = string.Empty;

        int LLWONMPartCode;
        int LLWONMQty;
        int LLWONFPartCode;
        int LLWONMPartCodeUsed;

        int WOLLNMPartCode;
        int WOLLNMQty;
        int WOLLNFPartCode;
        int WOLLNMPartCodeUsed;

        string notMatchPartCodeLLWO = string.Empty;

        int partCodeNotMatchLLWO;
        int qtyNotMatchLLWO;
        int partCodeUsedNotMatchLLWO;

        int partCodeNotMatchWOLL;
        int qtyNotMatchWOLL;
        int partCodeUsedNotMatchWOLL;

        int maksRowpartCodeNotMatchLLWO;

        public Compare()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void btnWO_Click(object sender, EventArgs e)
        {
            WorkOrder wo = new WorkOrder();
            wo.Show();
            this.Hide();
        }

        private void Compare_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            cmbLLModel.Enabled = false;
            btnCompare.Enabled = false;
            label3.Visible = false;
            label16.Visible = false;
            gbSummary.Visible = false;

            groupBox4.Visible = false;

            string queryWODropDown = "SELECT model_No FROM tbl_wo ";

            try
            {
                connection.Open();
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryWODropDown, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    for (int i = 0; i < dset.Rows.Count; i++)
                    {
                        cmbWOModel.Items.Add(dset.Rows[i][0]);
                        cmbWOModel.ValueMember = dset.Rows[i][0].ToString();
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

        private void cmbWOModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLLModel.ResetText();
            cmbLLModel.Enabled = true;
            label16.Visible = false;
            label3.Visible = false;
            tbCustomer.Text = "";
            tbModel.Text = "";
            tbPWBType.Text = "";
            tbStencil.Text = "";
            tbPCB.Text = "";
            woQty.Text = "";
            llQty.Text = "";
            compareQty.Text = "";
            comparePartcode.Text = "";
            gbSummary.Visible = false;
            compareQty.BackColor = SystemColors.Control;
            comparePartcode.BackColor = SystemColors.Control;

            while (dataGridViewCompareLLWO.Rows.Count > 0)
            {
                dataGridViewCompareLLWO.Rows.RemoveAt(0);
            }

            while (dataGridViewCompareWOLL.Rows.Count > 0)
            {
                dataGridViewCompareWOLL.Rows.RemoveAt(0);
            }

            cmbLLModel.Items.Clear();

            string model = cmbWOModel.Text;

            string queryLLDropDown = "SELECT model_No FROM tbl_ll WHERE model_No = '" + model + "'GROUP BY model_No";

            try
            {
                connection.Open();
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryLLDropDown, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    if (dset.Rows.Count > 0)
                    {
                        for (int i = 0; i < dset.Rows.Count; i++)
                        {
                            cmbLLModel.Items.Add(dset.Rows[i][0]);
                            cmbLLModel.ValueMember = dset.Rows[i][0].ToString();
                        }
                    }
                    else
                    {
                        string message = "No any Loading List for selected Work Order, Do you want to upload Loading List File?";
                        string title = "Confirmation Upload Loading List ";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.Yes)
                        {
                            ImportLL ill = new ImportLL();
                            ill.tbModelNo.Text = model;

                            try
                            {

                                string queryCustName = "SELECT customer FROM tbl_wo WHERE model_No = '" + model + "'";

                                using (MySqlDataAdapter adt = new MySqlDataAdapter(queryCustName, connection))
                                {
                                    DataTable dst = new DataTable();
                                    adt.Fill(dst);

                                    if (dst.Rows.Count > 0)
                                    {
                                        ill.tbCust.Text = dst.Rows[0]["customer"].ToString();
                                    }

                                }

                                string queryProcessDropDown = "SELECT tbl_customer.process_Name FROM tbl_wo, tbl_customer WHERE tbl_wo.customer =  tbl_customer.custname AND tbl_wo.model_No = '" + model + "'";
                                using (MySqlDataAdapter adpts = new MySqlDataAdapter(queryProcessDropDown, connection))
                                {
                                    DataTable dsets = new DataTable();
                                    adpts.Fill(dsets);

                                    if (dsets.Rows.Count > 0)
                                    {
                                        string process = dsets.Rows[0][0].ToString().Replace(" ", String.Empty); ;
                                        int totalProcess = process.Split(',').Length;
                                        var processName = process.Split(',');

                                        for (int j = 0; j < totalProcess; j++)
                                        {
                                            ill.cmbProcess.Items.Add(processName[j]);
                                            ill.cmbProcess.ValueMember = processName[j].ToString();
                                        }
                                    }
                                    else
                                    {
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // tampilkan pesan error
                                MessageBox.Show(ex.Message);
                            }

                            ill.Show();
                            this.Hide();
                        }
                    }
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                connection.Close();
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbLLModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCompare.Enabled = true;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            gbSummary.Visible = true;

            string queryTotalLL = "SELECT SUM(tbl_lldetail.qty) AS totalLL FROM tbl_lldetail WHERE model_No = '" + cmbLLModel.Text + "'";

            string queryTotalWO = "SELECT SUM(tbl_wodetail.qty) AS totalWO FROM tbl_wodetail WHERE model_No = '" + cmbLLModel.Text + "'";

            string queryDetailLL = "SELECT customer, model_detail, machine, pwb_Type, prog_No, stencil FROM tbl_ll WHERE  model_No = '" + cmbLLModel.Text + "' GROUP BY model_No";

            try
            {
                connection.Open();
                // nampilin detail LL
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryDetailLL, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    if (dset.Rows.Count > 0)
                    {
                        tbCustomer.Text = dset.Rows[0]["customer"].ToString();
                        tbModel.Text = dset.Rows[0]["model_detail"].ToString().Replace(" (SMT-A)", "");
                        tbPWBType.Text = dset.Rows[0]["pwb_Type"].ToString();
                        tbStencil.Text = dset.Rows[0]["stencil"].ToString();
                    }
                }
                //nampilin qty Wo
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryTotalWO, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    if (dset.Rows.Count > 0)
                    {
                        woQty.Text = dset.Rows[0]["totalWO"].ToString();
                    }

                }
                //nampilin qty LL
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryTotalLL, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    if (dset.Rows.Count > 0)
                    {
                        llQty.Text = dset.Rows[0]["totalLL"].ToString();
                    }
                }

                //nampilin selected PCB
                string queryPCB = "SELECT tbl_wodetail.partcode FROM tbl_wodetail LEFT JOIN tbl_lldetail " +
                    "ON tbl_wodetail.partcode = tbl_lldetail.partcode  " +
                    "WHERE tbl_wodetail.model_No = '" + cmbLLModel.Text + "' AND tbl_lldetail.model_No = '" + cmbLLModel.Text + "' " +
                    "AND tbl_lldetail.reel = 'PCB' GROUP BY tbl_wodetail.partcode";
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryPCB, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    if (dset.Rows.Count > 0)
                    {
                        tbPCB.Text = dset.Rows[0]["partcode"].ToString();
                    }

                }

                //nampilin data dalam datagridview compare LL WO 

                string queryLLWO = "SELECT  t1.partcode, t1.llQty, t1.partUsed, t2.partcode, t2.woQty, t2.partUsed " +
                    "FROM (SELECT tbl_lldetail.partcode, COUNT(tbl_lldetail.partcode) AS partUsed, SUM(tbl_lldetail.qty) AS llQty" +
                    " FROM tbl_lldetail WHERE tbl_lldetail.model_No = '" + cmbLLModel.Text + "' GROUP BY tbl_lldetail.partcode ) t1 " +
                    "LEFT JOIN ( SELECT tbl_wodetail.partcode, COUNT(tbl_wodetail.partcode) AS partUsed, " +
                    "SUM(tbl_wodetail.qty) AS woQty     FROM tbl_wodetail WHERE tbl_wodetail.model_No = '" + cmbLLModel.Text + "' " +
                    "GROUP BY tbl_wodetail.partcode ) t2 ON t1.partcode = t2.partcode ORDER BY t2.partcode";

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryLLWO, connection))
                {
                    DataSet dset = new DataSet();
                    adpt.Fill(dset);

                    dataGridViewCompareLLWO.DataSource = dset.Tables[0];
                    dataGridViewCompareLLWO.Columns.Add("columnPartStatus", "STATUS");

                    //tampilin data temporary result
                    dataGridViewCompareLLWOResult.DataSource = dset.Tables[0];
                }



                LblPartcodeNMLLWO.Text = "";
                LblPartcodeUsedQtyNMLLWO.Text = "";

                LblQtyPartcodeNMLLWO.Text = "";
                LblQtyPartcodeUsedQtyNMLLWO.Text = "";

                LblPartcodeQtyNMLLWO.Text = "";
                LblQtyPartcodeQtyNMLLWO.Text = "";


                //menghitung jumlah row data
                int rowCount = ((DataTable)this.dataGridViewCompareLLWO.DataSource).Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    label3.Text = "Total Part Loading List : " + rowCount.ToString();
                    label3.Visible = true;

                    DataGridViewCellStyle styleOk = new DataGridViewCellStyle();
                    styleOk.BackColor = Color.Green;
                    styleOk.ForeColor = Color.White;

                    DataGridViewCellStyle styleError = new DataGridViewCellStyle();
                    styleError.BackColor = Color.Red;
                    styleError.ForeColor = Color.White;

                    DataGridViewCellStyle styleWarning = new DataGridViewCellStyle();
                    styleWarning.BackColor = Color.Yellow;
                    styleWarning.ForeColor = Color.Black;

                    if (dataGridViewCompareLLWO.Rows[i].Cells[0].Value.ToString() !=
                        dataGridViewCompareLLWO.Rows[i].Cells[3].Value.ToString())
                    {
                        dataGridViewCompareLLWO.Rows[i].Cells[6].Value = "Part Code Not Match with Work Order";
                        dataGridViewCompareLLWO.Rows[i].DefaultCellStyle = styleError;

                        btnWO.Enabled = true;
                        partCodeNotMatchLLWO++;
                        LblPartcodeNMLLWO.Text += "\n" + dataGridViewCompareLLWO.Rows[i].Cells[0].Value.ToString();
                        LblQtyPartcodeNMLLWO.Text += "\n" + dataGridViewCompareLLWO.Rows[i].Cells[1].Value.ToString();
                    }

                    else if (dataGridViewCompareLLWO.Rows[i].Cells[1].Value.ToString() !=
                        dataGridViewCompareLLWO.Rows[i].Cells[4].Value.ToString())
                    {
                        dataGridViewCompareLLWO.Rows[i].Cells[6].Value = "Qty Not Match with Work Order";
                        dataGridViewCompareLLWO.Rows[i].DefaultCellStyle = styleError;

                        qtyNotMatchLLWO++;
                        LblPartcodeQtyNMLLWO.Text += "\n" + dataGridViewCompareLLWO.Rows[i].Cells[0].Value.ToString();
                        LblQtyPartcodeQtyNMLLWO.Text += "\n" + dataGridViewCompareLLWO.Rows[i].Cells[1].Value.ToString();
                    }

                    else if (dataGridViewCompareLLWO.Rows[i].Cells[2].Value.ToString() !=
                       dataGridViewCompareLLWO.Rows[i].Cells[5].Value.ToString())
                    {
                        dataGridViewCompareLLWO.Rows[i].Cells[6].Value = "Part Code Used Qty Not Match with Work Order";
                        dataGridViewCompareLLWO.Rows[i].DefaultCellStyle = styleWarning;
                        partCodeUsedNotMatchLLWO++;

                        LblPartcodeUsedQtyNMLLWO.Text += "\n" + dataGridViewCompareLLWO.Rows[i].Cells[0].Value.ToString();
                        LblQtyPartcodeUsedQtyNMLLWO.Text += "\n" + dataGridViewCompareLLWO.Rows[i].Cells[1].Value.ToString();
                    }

                    //compare partcode
                    else if (dataGridViewCompareLLWO.Rows[i].Cells[0].Value.ToString() ==
                        dataGridViewCompareLLWO.Rows[i].Cells[3].Value.ToString() ||
                        dataGridViewCompareLLWO.Rows[i].Cells[1].Value.ToString() ==
                        dataGridViewCompareLLWO.Rows[i].Cells[4].Value.ToString() ||
                        dataGridViewCompareLLWO.Rows[i].Cells[2].Value.ToString() ==
                        dataGridViewCompareLLWO.Rows[i].Cells[5].Value.ToString())
                    {
                        dataGridViewCompareLLWO.Rows[i].Cells[6].Value = "Match";
                        dataGridViewCompareLLWO.Rows[i].DefaultCellStyle = styleOk;
                    }


                    LLWONMPartCode = partCodeNotMatchLLWO;
                    LLWONMQty = qtyNotMatchLLWO;
                    LLWONMPartCodeUsed = partCodeUsedNotMatchLLWO;

                    if (LLWONMPartCode > 0)
                    {
                        LLWONMPartCodes = "Partcode Not Match LL VS WO : " + partCodeNotMatchLLWO.ToString();
                    }
                    if (LLWONMQty > 0)
                    {
                        LLWONMQtys = "\nQty Not Match LL VS WO : " + qtyNotMatchLLWO.ToString();
                    }
                    if (LLWONMPartCodeUsed > 0)
                    {
                        LLWONMPartCodeUseds = "\nPartcode Used Not Match LL VS WO : " + partCodeUsedNotMatchLLWO.ToString();
                    }
                }

                if (LLWONMPartCodes == "" && LLWONMQtys == "" && LLWONFPartCodes == "" && LLWONMPartCodeUseds == "")
                {
                    lbSummaryLLWO.Text = "All Data Match";
                }
                else
                {
                    lbSummaryLLWO.Text = LLWONMPartCodes + LLWONMQtys + LLWONFPartCodes + LLWONMPartCodeUseds;
                }

                if (lbSummaryLLWO.Text.Contains("Partcode Not Match LL VS WO : ") || lbSummaryWOLL.Text.Contains("Partcode Not Match WO VS LL: "))
                {
                    comparePartcode.Text = "Part Code Not Match";
                    comparePartcode.BackColor = System.Drawing.Color.Red;
                }
                else if (lbSummaryLLWO.Text.Contains("Partcode Used Not Match LL VS WO : ") || lbSummaryWOLL.Text.Contains("Partcode Used Not Match WO VS LL : "))
                {
                    comparePartcode.Text = "Part Used Not Match";
                    comparePartcode.BackColor = System.Drawing.Color.Yellow;
                    comparePartcode.ForeColor = Color.Black;
                }
                else if (lbSummaryLLWO.Text == "All Data Match" && lbSummaryWOLL.Text == "All Data Match")
                {
                    comparePartcode.Text = "Match";
                    comparePartcode.BackColor = System.Drawing.Color.Blue;
                }


                // Set table title Wo
                string[] titleWO = { "PART CODE LL ", "QTY LL", "PART LL USED", "PART CODE WO", "QTY WO", "PART WO USED" };
                for (int i = 0; i < titleWO.Length; i++)
                {
                    dataGridViewCompareLLWO.Columns[i].HeaderText = "" + titleWO[i];
                }

                for (int i = 0; i < dataGridViewCompareLLWO.Columns.Count; i++)
                {
                    dataGridViewCompareLLWO.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }


                //nampilin data dalam datagridview compare WO LL

                string queryWOLL = "SELECT t1.partcode, t1.woQty, t1.partUsed, t2.partcode, t2.llQty, t2.partUsed " +
                    "FROM ( SELECT tbl_wodetail.partcode, COUNT(tbl_wodetail.partcode) AS partUsed, SUM(tbl_wodetail.qty) AS woQty" +
                    " FROM tbl_wodetail WHERE tbl_wodetail.model_No = '" + cmbLLModel.Text + "' GROUP BY tbl_wodetail.partcode ) t1  " +
                    "LEFT JOIN ( SELECT tbl_lldetail.partcode, COUNT(tbl_lldetail.partcode) AS partUsed, SUM(tbl_lldetail.qty) AS llQty " +
                    "FROM tbl_lldetail WHERE tbl_lldetail.model_No = '" + cmbLLModel.Text + "' GROUP BY tbl_lldetail.partcode ) t2 " +
                    "ON t1.partcode = t2.partcode ORDER BY t2.partcode";

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryWOLL, connection))
                {

                    DataSet dset = new DataSet();
                    adpt.Fill(dset);

                    dataGridViewCompareWOLL.DataSource = dset.Tables[0];
                    dataGridViewCompareWOLL.Columns.Add("columnPartStatus", "STATUS");

                }


                LblPartcodeNMWOLL.Text = "";
                LblQtyPartcodeNMWOLL.Text = "";

                LblPartcodeUsedQtyNMWOLL.Text = "";
                LblQtyPartcodeUsedQtyNMWOLL.Text = "";

                LblPartcodeQtyNMWOLL.Text = "";
                LblQtyPartcodeQtyNMWOLL.Text = "";


                //menghitung jumlah row data
                int rowCounts = ((DataTable)this.dataGridViewCompareWOLL.DataSource).Rows.Count;
                for (int i = 0; i < rowCounts; i++)
                {
                    label16.Text = "Total Part Work Order " + rowCounts.ToString();
                    label16.Visible = true;

                    DataGridViewCellStyle styleOk = new DataGridViewCellStyle();
                    styleOk.BackColor = Color.Green;
                    styleOk.ForeColor = Color.White;

                    DataGridViewCellStyle styleError = new DataGridViewCellStyle();
                    styleError.BackColor = Color.Red;
                    styleError.ForeColor = Color.White;

                    DataGridViewCellStyle styleWarning = new DataGridViewCellStyle();
                    styleWarning.BackColor = Color.Yellow;
                    styleWarning.ForeColor = Color.Black;

                    if (dataGridViewCompareWOLL.Rows[i].Cells[0].Value.ToString() !=
                        dataGridViewCompareWOLL.Rows[i].Cells[3].Value.ToString())
                    {
                        dataGridViewCompareWOLL.Rows[i].Cells[6].Value = "Part Code Not Match with Loading List";
                        dataGridViewCompareWOLL.Rows[i].DefaultCellStyle = styleError;
                        btnWO.Enabled = true;

                        partCodeNotMatchWOLL++;
                        LblPartcodeNMWOLL.Text += "\n" + dataGridViewCompareWOLL.Rows[i].Cells[0].Value.ToString();
                        LblQtyPartcodeNMWOLL.Text += "\n" + dataGridViewCompareWOLL.Rows[i].Cells[1].Value.ToString();
                    }

                    else if (dataGridViewCompareWOLL.Rows[i].Cells[1].Value.ToString() !=
                       dataGridViewCompareWOLL.Rows[i].Cells[4].Value.ToString())
                    {
                        dataGridViewCompareWOLL.Rows[i].Cells[6].Value = "Qty Not Match with Loading List";
                        dataGridViewCompareWOLL.Rows[i].DefaultCellStyle = styleError;
                        qtyNotMatchWOLL++;

                        LblPartcodeQtyNMWOLL.Text += "\n" + dataGridViewCompareWOLL.Rows[i].Cells[0].Value.ToString();
                        LblQtyPartcodeQtyNMWOLL.Text += "\n" + dataGridViewCompareWOLL.Rows[i].Cells[1].Value.ToString();
                    }

                    else if (dataGridViewCompareWOLL.Rows[i].Cells[2].Value.ToString() !=
                       dataGridViewCompareWOLL.Rows[i].Cells[5].Value.ToString())
                    {
                        dataGridViewCompareWOLL.Rows[i].Cells[6].Value = "Part Code Used Qty Not Match with Loading List";
                        dataGridViewCompareWOLL.Rows[i].DefaultCellStyle = styleWarning;
                        partCodeUsedNotMatchWOLL++;

                        LblPartcodeUsedQtyNMWOLL.Text += "\n" + dataGridViewCompareWOLL.Rows[i].Cells[0].Value.ToString();
                        LblQtyPartcodeUsedQtyNMWOLL.Text += "\n" + dataGridViewCompareWOLL.Rows[i].Cells[1].Value.ToString();
                    }

                    //compare partcode
                    else if (dataGridViewCompareWOLL.Rows[i].Cells[0].Value.ToString() ==
                        dataGridViewCompareWOLL.Rows[i].Cells[3].Value.ToString() ||
                        dataGridViewCompareWOLL.Rows[i].Cells[1].Value.ToString() ==
                        dataGridViewCompareWOLL.Rows[i].Cells[4].Value.ToString() ||
                        dataGridViewCompareWOLL.Rows[i].Cells[2].Value.ToString() ==
                        dataGridViewCompareWOLL.Rows[i].Cells[5].Value.ToString())
                    {
                        dataGridViewCompareWOLL.Rows[i].Cells[6].Value = "Match";
                        dataGridViewCompareWOLL.Rows[i].DefaultCellStyle = styleOk;
                    }

                    WOLLNMPartCode = partCodeNotMatchWOLL;
                    WOLLNMQty = qtyNotMatchWOLL;
                    WOLLNMPartCodeUsed = partCodeUsedNotMatchWOLL;

                    if (WOLLNMPartCode > 0)
                    {
                        WOLLNMPartCodes = "Partcode Not Match WO VS LL : " + partCodeNotMatchWOLL.ToString();
                    }
                    if (WOLLNMQty > 0)
                    {
                        WOLLNMQtys = "\nQty Not Match WO VS LL : " + qtyNotMatchWOLL.ToString();
                    }
                    if (WOLLNMPartCodeUsed > 0)
                    {
                        WOLLNMPartCodeUseds = "\nPartcode Used Not Match WO VS LL : " + partCodeUsedNotMatchWOLL.ToString();
                    }

                    if (WOLLNMPartCodes == "" && WOLLNMQtys == "" && WOLLNFPartCodes == "" && WOLLNMPartCodeUseds == "")
                    {
                        lbSummaryWOLL.Text = "All Data Match";
                    }
                    else
                    {
                        lbSummaryWOLL.Text = WOLLNMPartCodes + WOLLNMQtys + WOLLNFPartCodes + WOLLNMPartCodeUseds;
                    }


                }

                // Set table title Wo
                string[] titleLL = { "PART CODE WO", "QTY WO", "PART WO USED", "PART CODE LL", "QTY LL", "PART LL USED" };
                for (int i = 0; i < titleLL.Length; i++)
                {
                    dataGridViewCompareWOLL.Columns[i].HeaderText = "" + titleLL[i];
                }

                for (int i = 0; i < dataGridViewCompareWOLL.Columns.Count; i++)
                {
                    dataGridViewCompareWOLL.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                // display qty match or not
                if (woQty.Text == "" || llQty.Text == "")
                {
                    compareQty.Text = "#ERROR";
                    compareQty.BackColor = System.Drawing.Color.Red;
                }

                else if (woQty.Text == llQty.Text)
                {
                    compareQty.BackColor = System.Drawing.Color.Blue;
                    compareQty.Text = "Match";
                }

                else if (woQty.Text != llQty.Text)
                {
                    compareQty.Text = "Not Match";
                    compareQty.BackColor = System.Drawing.Color.Red;
                }

                if (tbPCB.Text == "")
                {
                    MessageBox.Show("No any selected PCB", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }

            groupBox4.Visible = true;
            btnCompare.Enabled = false;

            if (tbCustomer.Text == "PEGATRON")
            {
                //nampilin part yang perlu check sum
                string queryPartcodeLL = "SELECT * FROM tbl_lldetail WHERE model_No = '" + cmbLLModel.Text + "' AND partcode LIKE '0500%'";
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryPartcodeLL, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);
                    NotifCheckSum notif = new NotifCheckSum();
                    for (int i = 0; i < dset.Rows.Count; i++)
                    {
                        notif.tbChecksum.Text += "\r\n" + dset.Rows[i]["partcode"].ToString() + " ";
                    }
                    notif.Show();
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            btnHome.Enabled = false;
            btnWO.Enabled = false;


            // Create a new workbook with a single sheet
            excelConvert.NewFile();
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            // worksheet.Name = "Report";
            // set hide gridlines
            app.ActiveWindow.DisplayGridlines = false;

            worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[3, 10]].Merge();
            worksheet.Cells[2, 1].Font.Name = "Arial";
            worksheet.Cells[2, 1].Font.FontStyle = "Bold";
            worksheet.Cells[2, 1].Font.Size = 12;
            worksheet.Cells[2, 1].Font.Color = Color.Black;
            worksheet.Cells[2, 1].EntireRow.Font.Bold = true;
            worksheet.Cells[2, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            worksheet.Cells[2, 1].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            worksheet.Cells[2, 1] = "WORK ORDER (WO) AND LOADING LIST (LL) COMPARISON RESULT";
            worksheet.Range[worksheet.Cells[4, 1], worksheet.Cells[4, 10]].Merge();
            worksheet.Cells[4, 1].Font.FontStyle = "Bold";
            worksheet.Cells[4, 1].Font.Size = 10;
            worksheet.Cells[4, 1] = "PT. SAT NUSAPERSADA Tbk";
            worksheet.Cells[4, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            worksheet.Range[worksheet.Cells[6, 1], worksheet.Cells[1000, 1000]].Font.Name = "Arial";
            worksheet.Range[worksheet.Cells[6, 1], worksheet.Cells[1000, 1000]].Font.Size = 10;
            worksheet.Cells[6, 1].Font.Size = 10;
            worksheet.Cells[6, 1] = "CUSTOMER     : " + tbCustomer.Text;
            worksheet.Cells[7, 1] = "MODEL     : " + tbModel.Text.Replace(" (SMT-A)", "");
            worksheet.Cells[8, 1] = "PWB TYPE  : " + tbPWBType.Text;
            worksheet.Cells[9, 1] = "REPORT DATE: " + DateTime.Now.ToString("dd MMMM yyyy");


            worksheet.Range[worksheet.Cells[10, 1], worksheet.Cells[9, 10]].Cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

            worksheet.Range[worksheet.Cells[12, 1], worksheet.Cells[12, 10]].Font.FontStyle = "Bold";
            worksheet.Range[worksheet.Cells[12, 1], worksheet.Cells[12, 10]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            worksheet.Range[worksheet.Cells[12, 1], worksheet.Cells[12, 10]].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            worksheet.Range[worksheet.Cells[12, 1], worksheet.Cells[13, 4]].Merge();
            worksheet.Cells[12, 1] = "Criteria Comparison";
            //worksheet.Cells[11, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            worksheet.Range[worksheet.Cells[12, 6], worksheet.Cells[13, 6]].Merge();
            worksheet.Cells[12, 6] = "Result";

            worksheet.Range[worksheet.Cells[12, 8], worksheet.Cells[12, 10]].Merge();
            worksheet.Cells[12, 8] = "NG Comparison Result ";
            worksheet.Range[worksheet.Cells[12, 8], worksheet.Cells[12, 10]].Cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;

            worksheet.Cells[13, 8] = "Data From";
            worksheet.Cells[13, 9] = "Partcode";
            worksheet.Cells[13, 10] = "Qty";

            worksheet.Range[worksheet.Cells[14, 1], worksheet.Cells[14, 10]].Cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
            worksheet.Range[worksheet.Cells[11, 1], worksheet.Cells[14, 10]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

            worksheet.Cells[16, 2] = "Qty LL Compare To Qty WO";
            worksheet.Cells[16, 6] = compareQty.Text;

            worksheet.Cells[16, 8] = "LL";
            worksheet.Cells[16, 10] = llQty.Text;

            worksheet.Cells[17, 8] = "WO";
            worksheet.Cells[17, 10] = woQty.Text;

            worksheet.Cells[19, 2] = "Partcode LL Compare to WO";

            if (partCodeNotMatchLLWO>0)
            {
                worksheet.Cells[19, 6] = "Not Match";
                worksheet.Cells[19, 8] = "LL";

                // menampilkan data partcode not match LL vs WO 
                maksRowpartCodeNotMatchLLWO = 19 + partCodeNotMatchLLWO;
                string[] partCodeNotMatchLLWOText = LblPartcodeNMLLWO.Text.Split('\n');
                string[] QtyPartcodeNotMatchNMLLWO = LblQtyPartcodeNMLLWO.Text.Split('\n');


                for (int i = 19; i < maksRowpartCodeNotMatchLLWO; i++)
                {
                    for (int j = 0; j <= partCodeNotMatchLLWO; j++)
                    {
                        worksheet.Cells[i, 9] = partCodeNotMatchLLWOText[j];
                        worksheet.Cells[i, 10] = QtyPartcodeNotMatchNMLLWO[j];
                    }
                }
            }
            else
            {
                worksheet.Cells[19, 6] = "Match";
            }                      



            // menampilkan data partcode not match WO vs LL
            int newRowpartCodeNotMatchWOLL = maksRowpartCodeNotMatchLLWO + 1;
            int maksRowpartCodeNotMatchWOLL = newRowpartCodeNotMatchWOLL + partCodeNotMatchWOLL;
            string[] partCodeNotMatchWOLLText = LblPartcodeNMWOLL.Text.Split('\n');
            string[] QtyPartcodeNotMatchNMWOLL = LblQtyPartcodeNMWOLL.Text.Split('\n');

            worksheet.Cells[newRowpartCodeNotMatchWOLL, 2] = "Partcode WO Compare to LL";
            if (partCodeNotMatchWOLL > 0)
            {
                worksheet.Cells[newRowpartCodeNotMatchWOLL, 6] = "Not Match";
                worksheet.Cells[newRowpartCodeNotMatchWOLL, 8] = "WO";

                for (int i = newRowpartCodeNotMatchWOLL; i < maksRowpartCodeNotMatchWOLL; i++)
                {
                    for (int j = 0; j <= partCodeNotMatchWOLL; j++)
                    {
                        worksheet.Cells[i, 9] = partCodeNotMatchWOLLText[j];
                        worksheet.Cells[i, 10] = QtyPartcodeNotMatchNMWOLL[j];
                    }
                }
            }    
            else
            {
                worksheet.Cells[newRowpartCodeNotMatchWOLL, 6] = "Match";
            }           


            // menampilkan data partcode qty not match LL vs WO 
            int newRowQtyNotMatchLLWO = maksRowpartCodeNotMatchWOLL + 1;
            int maksRowQtyNotMatchLLWO = newRowQtyNotMatchLLWO + qtyNotMatchLLWO;
            string[] qtyNotMatchLLWOText = LblPartcodeQtyNMLLWO.Text.Split('\n');
            string[] QtyPartcodeNMLLWO = LblQtyPartcodeQtyNMLLWO.Text.Split('\n');

            worksheet.Cells[newRowQtyNotMatchLLWO, 2] = "Partcode Qty LL Compare to WO";
            if (qtyNotMatchLLWO > 0)
            {
                worksheet.Cells[newRowQtyNotMatchLLWO, 6] = "Not Match";
                worksheet.Cells[newRowQtyNotMatchLLWO, 8] = "LL";

                for (int i = newRowQtyNotMatchLLWO; i < maksRowQtyNotMatchLLWO; i++)
                {
                    for (int j = 0; j <= qtyNotMatchLLWO; j++)
                    {
                        worksheet.Cells[i, 9] = qtyNotMatchLLWOText[j];
                        worksheet.Cells[i, 10] = QtyPartcodeNMLLWO[j];
                    }
                }
            }
            else
            {
                worksheet.Cells[newRowQtyNotMatchLLWO, 6] = "Match";
            }
                       


            // menampilkan data partcode qty not match WO vs LL
            int newRowQtyNotMatchWOLL = maksRowQtyNotMatchLLWO + 1;
            int maksRowQtyNotMatchWOLL = newRowQtyNotMatchWOLL + qtyNotMatchWOLL;
            string[] qtyNotMatchWOLLText = LblPartcodeQtyNMWOLL.Text.Split('\n');
            string[] QtyPartcodeNMWOLL = LblQtyPartcodeQtyNMWOLL.Text.Split('\n');

            worksheet.Cells[newRowQtyNotMatchWOLL, 2] = "Partcode Qty WO Compare to LL";
            if (qtyNotMatchWOLL > 0)
            {
                worksheet.Cells[newRowQtyNotMatchWOLL, 6] = "Not Match";
                worksheet.Cells[newRowQtyNotMatchWOLL, 8] = "WO";

                for (int i = newRowQtyNotMatchWOLL; i < maksRowQtyNotMatchWOLL; i++)
                {
                    for (int j = 0; j <= qtyNotMatchWOLL; j++)
                    {
                        worksheet.Cells[i, 9] = qtyNotMatchWOLLText[j];
                        worksheet.Cells[i, 10] = QtyPartcodeNMWOLL[j];
                    }
                }
            }
            else 
            {
                worksheet.Cells[newRowQtyNotMatchWOLL, 6] = "Match";
            }           


            // menampilkan data Partcode Used not match LL vs WO
            int newRowPartcodeUsedNotMatchLLWO = maksRowQtyNotMatchWOLL + 1;
            int maksRowPartcodeUsedNotMatchLLWO = newRowPartcodeUsedNotMatchLLWO + partCodeUsedNotMatchLLWO;
            string[] PartcodeUsedNotMatchLLWOText = LblPartcodeUsedQtyNMLLWO.Text.Split('\n');
            string[] QtyPartcodeUsedNMLLWO = LblQtyPartcodeUsedQtyNMLLWO.Text.Split('\n');

            worksheet.Cells[newRowPartcodeUsedNotMatchLLWO, 2] = "Partcode Used LL Compare to WO";
            if (partCodeUsedNotMatchLLWO > 0)
            {
                worksheet.Cells[newRowPartcodeUsedNotMatchLLWO, 6] = "Not Match";
                worksheet.Cells[newRowPartcodeUsedNotMatchLLWO, 8] = "LL";

                for (int i = newRowPartcodeUsedNotMatchLLWO; i < maksRowPartcodeUsedNotMatchLLWO; i++)
                {
                    for (int j = 0; j <= partCodeUsedNotMatchLLWO; j++)
                    {
                        worksheet.Cells[i, 9] = PartcodeUsedNotMatchLLWOText[j];
                        worksheet.Cells[i, 10] = QtyPartcodeUsedNMLLWO[j];
                    }
                }
            }
            else
            {
                worksheet.Cells[newRowPartcodeUsedNotMatchLLWO, 6] = "Match";
            }            

            // menampilkan data Partcode Used not match WO vs LL
            int newRowPartcodeUsedNotMatchWOLL = maksRowPartcodeUsedNotMatchLLWO + 1;
            int maksRowPartcodeUsedNotMatchWOLL = newRowPartcodeUsedNotMatchWOLL + partCodeUsedNotMatchWOLL;
            string[] PartcodeUsedNotMatchWOLLText = LblPartcodeUsedQtyNMWOLL.Text.Split('\n');
            string[] QtyPartcodeUsedNMWOLL = LblQtyPartcodeUsedQtyNMWOLL.Text.Split('\n');

            worksheet.Cells[newRowPartcodeUsedNotMatchWOLL, 2] = "Partcode Used WO Compare to LL";
            if (partCodeUsedNotMatchWOLL > 0)
            {
                worksheet.Cells[newRowPartcodeUsedNotMatchWOLL, 6] = "Not Match";
                worksheet.Cells[newRowPartcodeUsedNotMatchWOLL, 8] = "WO";

                for (int i = newRowPartcodeUsedNotMatchWOLL; i < maksRowPartcodeUsedNotMatchWOLL; i++)
                {
                    for (int j = 0; j <= partCodeUsedNotMatchWOLL; j++)
                    {
                        worksheet.Cells[i, 9] = PartcodeUsedNotMatchWOLLText[j];
                        worksheet.Cells[i, 10] = QtyPartcodeUsedNMWOLL[j];
                    }
                }
            }
            else
            {
                worksheet.Cells[newRowPartcodeUsedNotMatchWOLL, 6] = "Match";
            }           


            worksheet.Range[worksheet.Cells[maksRowPartcodeUsedNotMatchWOLL+1, 1], worksheet.Cells[maksRowPartcodeUsedNotMatchWOLL + 1, 10]].Cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
            worksheet.Cells[maksRowPartcodeUsedNotMatchWOLL + 1, 1] = "SMT DEPT";
            worksheet.Cells[maksRowPartcodeUsedNotMatchWOLL + 1, 1].Font.FontStyle = "Bold";

            // Saving the file in a speicifed path
            // excelConvert.SaveAs(@"D:\" + model[0].Replace(" ", "").ToString() + " ( " + model[1].Replace(" ", "").ToString() + " )");

            // Closing the file
            excelConvert.Close();
            MessageBox.Show("Excel File Success Generated", "Generate Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnHome.Enabled = true;
            btnWO.Enabled = true;
        }
    }
}
