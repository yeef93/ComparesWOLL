﻿using MySql.Data.MySqlClient;
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
            btnGenerate.Enabled = false;
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
            tbMachine.Text = "";
            tbPWBType.Text = "";
            tbProgNo.Text = "";
            tbStencil.Text = "";
            tbPCB.Text = "";
            woQty.Text = "";
            llQty.Text = "";
            compareQty.Text = "";
            gbSummary.Visible = false;
            compareQty.BackColor = SystemColors.Control;

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
                        tbModel.Text = dset.Rows[0]["model_detail"].ToString();
                        tbMachine.Text = dset.Rows[0]["machine"].ToString();
                        tbPWBType.Text = dset.Rows[0]["pwb_Type"].ToString();
                        tbProgNo.Text = dset.Rows[0]["prog_No"].ToString();
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

                int partCodeNotMatchLLWO = 0;
                int qtyNotMatchLLWO = 0;
                int partCodeNotFoundLLWO = 0;
                int partCodeUsedNotMatchLLWO = 0;


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
                        dataGridViewCompareLLWO.Rows[i].Cells[6].Value = "Part Code Not Match with Loading List";
                        dataGridViewCompareLLWO.Rows[i].DefaultCellStyle = styleError;

                        btnWO.Enabled = true;

                        partCodeNotMatchLLWO++;
                    }

                    else if (dataGridViewCompareLLWO.Rows[i].Cells[1].Value.ToString() !=
                        dataGridViewCompareLLWO.Rows[i].Cells[4].Value.ToString())
                    {
                        dataGridViewCompareLLWO.Rows[i].Cells[6].Value = "Qty Not Match with Loading List";
                        dataGridViewCompareLLWO.Rows[i].DefaultCellStyle = styleError;

                        qtyNotMatchLLWO++;
                    }

                    else if (dataGridViewCompareLLWO.Rows[i].Cells[0].Value.ToString() !=
                        dataGridViewCompareLLWO.Rows[i].Cells[3].Value.ToString())
                    {
                        dataGridViewCompareLLWO.Rows[i].Cells[6].Value = "Part Code Not Found in Loading List";
                        dataGridViewCompareLLWO.Rows[i].DefaultCellStyle = styleError;

                        partCodeNotFoundLLWO++;
                    }

                    else if (dataGridViewCompareLLWO.Rows[i].Cells[2].Value.ToString() !=
                       dataGridViewCompareLLWO.Rows[i].Cells[5].Value.ToString())
                    {
                        dataGridViewCompareLLWO.Rows[i].Cells[6].Value = "Part Code Used Qty Not Match with Loading List";
                        dataGridViewCompareLLWO.Rows[i].DefaultCellStyle = styleWarning;
                        partCodeUsedNotMatchLLWO++;
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

                    int LLWONMPartCode = partCodeNotMatchLLWO;
                    int LLWONMQty = qtyNotMatchLLWO;
                    int LLWONFPartCode = partCodeNotFoundLLWO;
                    int LLWONMPartCodeUsed = partCodeUsedNotMatchLLWO;

                    lbPartCodeNotMatchLLWO.Text = "Partcode Not Match LL VS WO : " + partCodeNotMatchLLWO.ToString();
                    lbQtyNotMatchLLWO.Text = "Qty Not Match LL VS WO : " + qtyNotMatchLLWO.ToString();
                    lbPartCodeNotFoundLLWO.Text = "Partcode Not Found LL VS WO : " + partCodeNotFoundLLWO.ToString();
                    lbPartCodeUsedNotMatchLLWO.Text = "Partcode Used Not Match LL VS WO : " + partCodeUsedNotMatchLLWO.ToString();

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

                int partCodeNotMatchWOLL = 0;
                int qtyNotMatchWOLL = 0;
                int partCodeNotFoundWOLL = 0;
                int partCodeUsedNotMatchWOLL = 0;


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
                        dataGridViewCompareWOLL.Rows[i].Cells[6].Value = "Part Code Not Match with Work Order";
                        dataGridViewCompareWOLL.Rows[i].DefaultCellStyle = styleError;
                        btnWO.Enabled = true;

                        partCodeNotMatchWOLL++;
                    }

                    else if (dataGridViewCompareWOLL.Rows[i].Cells[1].Value.ToString() !=
                       dataGridViewCompareWOLL.Rows[i].Cells[4].Value.ToString())
                    {
                        dataGridViewCompareWOLL.Rows[i].Cells[6].Value = "Qty Not Match with Work Order";
                        dataGridViewCompareWOLL.Rows[i].DefaultCellStyle = styleError;
                        qtyNotMatchWOLL++;
                    }

                    else if (dataGridViewCompareWOLL.Rows[i].Cells[0].Value.ToString() !=
                        dataGridViewCompareWOLL.Rows[i].Cells[3].Value.ToString())
                    {
                        dataGridViewCompareWOLL.Rows[i].Cells[6].Value = "Part Code Not Found in Work Order";
                        dataGridViewCompareWOLL.Rows[i].DefaultCellStyle = styleError;
                        partCodeNotFoundWOLL++;
                    }

                    else if (dataGridViewCompareWOLL.Rows[i].Cells[1].Value.ToString() !=
                        dataGridViewCompareWOLL.Rows[i].Cells[4].Value.ToString())
                    {
                        dataGridViewCompareWOLL.Rows[i].Cells[6].Value = "Qty Not Match with Work Order";
                        dataGridViewCompareWOLL.Rows[i].DefaultCellStyle = styleError;
                        qtyNotMatchWOLL++;
                    }

                    else if (dataGridViewCompareWOLL.Rows[i].Cells[2].Value.ToString() !=
                       dataGridViewCompareWOLL.Rows[i].Cells[5].Value.ToString())
                    {
                        dataGridViewCompareWOLL.Rows[i].Cells[6].Value = "Part Code Used Qty Not Match with Work Order";
                        dataGridViewCompareWOLL.Rows[i].DefaultCellStyle = styleWarning;
                        partCodeUsedNotMatchWOLL++;
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


                    lbPartCodeNotMatchWOLL.Text = "Partcode Not Match WO VS LL : " + partCodeNotMatchWOLL.ToString();
                    lbQtyNotMatchWOLL.Text = "Qty Not Match WO VS LL : " + qtyNotMatchWOLL.ToString();
                    lbPartCodeNotFoundWOLL.Text = "Partcode Not Found WO VS LL : " + partCodeNotFoundWOLL.ToString();
                    lbPartCodeUsedNotMatchWOLL.Text = "Partcode Used Not Match WO VS LL : " + partCodeUsedNotMatchWOLL.ToString();

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
                    btnGenerate.Enabled = true;
                }

                else if (woQty.Text == llQty.Text)
                {
                    compareQty.BackColor = System.Drawing.Color.Blue;
                    compareQty.Text = "Match";
                    btnGenerate.Enabled = true;
                }

                else if (woQty.Text != llQty.Text)
                {
                    compareQty.Text = "Not Match";
                    compareQty.BackColor = System.Drawing.Color.Red;
                    btnGenerate.Enabled = true;
                }

                if (tbPCB.Text == "")
                {
                    MessageBox.Show("No any selected PCB", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                    btnGenerate.Enabled = true;
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
                MessageBox.Show("Don't Forget to Checksum", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); //custom messageBox to show error  
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            btnHome.Enabled = false;
            btnWO.Enabled = false;

            LoadForm lf = new LoadForm();
            lf.Show();

            int totalpart;
            int totalPointRow;
            int remarkRow;
            int footerRow;

            // to split model and process
            string str = cmbLLModel.Text;
            char ch = '|';

            var model = str.Split(ch);


            //truncate result tabel
            var cmd = new MySqlCommand("", connection);
            connection.Open();

            for (int i = 0; i < dataGridViewCompareLLWOResult.Rows.Count; i++)
            {
                string queryResult = "TRUNCATE tbl_resultcompare";
                cmd.CommandText = queryResult;
                cmd.ExecuteNonQuery();
            }
            connection.Close();

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

            // set hide gridlines
            app.ActiveWindow.DisplayGridlines = false;

            connection.Open();

            for (int i = 0; i < dataGridViewCompareLLWOResult.Rows.Count; i++)
            {
                string queryResult = "INSERT INTO tbl_resultcompare (tbl_resultcompare.model_No, tbl_resultcompare.process_Name, " +
                    "tbl_resultcompare.reel, tbl_resultcompare.partcode, tbl_resultcompare.alt_No, tbl_resultcompare.tp, tbl_resultcompare.qty," +
                    " tbl_resultcompare.loc, tbl_resultcompare.dec, tbl_resultcompare.f_Type)" +
                    "SELECT tbl_reel.model_No, tbl_reel.process_Name, tbl_reel.reel, tbl_partcodedetail.partcode,tbl_lldetail.alt_No," +
                    " tbl_partcodedetail.tp, tbl_reel.qty, tbl_reel.loc, tbl_partcodedetail.dec,tbl_reel.f_Type " +
                    "FROM tbl_reel, tbl_partcodedetail, tbl_lldetail WHERE tbl_reel.reel = '" + dataGridViewCompareLLWOResult.Rows[i].Cells[0].Value.ToString() + "' " +
                    "AND tbl_partcodedetail.partcode = '" + dataGridViewCompareLLWOResult.Rows[i].Cells[1].Value.ToString() + "' AND tbl_reel.model_No = '" + model[0].Replace(" ", "").ToString() + "' " +
                    "AND tbl_reel.process_Name = '" + model[1].Replace(" ", "") + "' " +
                    "AND tbl_partcodedetail.partcode = tbl_lldetail.partcode";
                cmd.CommandText = queryResult;
                cmd.ExecuteNonQuery();
            }
            connection.Close();

            worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 9]].Merge();
            worksheet.Cells[1, 1].Font.Name = "Times New Roman";
            worksheet.Cells[1, 1].Font.FontStyle = "Bold";
            worksheet.Cells[1, 1].Font.Size = 20;
            worksheet.Cells[1, 1].Font.Color = Color.Blue;
            worksheet.Cells[1, 1].EntireRow.Font.Bold = true;
            worksheet.Cells[1, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            worksheet.Cells[1, 1] = "SMT MACHINE LOADING LIST";

            worksheet.Cells[2, 9] = "Page 1 of 1";
            worksheet.Cells[2, 9].Style.Font.Size = 10;
            //worksheet.Cells.Font.Color = Color.Blue;
            worksheet.Cells[2, 9].EntireRow.Font.Italic = true;

            worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[7, 1]].Font.Name = "Courier New";
            worksheet.Cells[3, 1].Font.FontStyle = "Bold";
            worksheet.Cells[3, 1].Font.Size = 10;
            worksheet.Cells[3, 1] = "MODEL     : " + tbModel.Text;

            worksheet.Range[worksheet.Cells[3, 6], worksheet.Cells[3, 9]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            worksheet.Range[worksheet.Cells[3, 6], worksheet.Cells[3, 9]].Font.Color = Color.White;
            worksheet.Range[worksheet.Cells[2, 6], worksheet.Cells[3, 9]].Font.Name = "Times New Roman";
            worksheet.Range[worksheet.Cells[3, 6], worksheet.Cells[3, 9]].Style.Font.Size = 8;
            worksheet.Cells[3, 6] = "Rev.";
            worksheet.Cells[3, 7] = "Prepared by";
            worksheet.Cells[3, 8] = "Checked by";
            worksheet.Cells[3, 9] = "Approved by";

            worksheet.Cells[4, 1].Font.FontStyle = "Bold";
            worksheet.Cells[4, 1].Font.Size = 9;
            worksheet.Cells[4, 1] = "MACHINE   : " + tbMachine.Text;
            worksheet.Cells[5, 1].Font.FontStyle = "Bold";
            worksheet.Cells[5, 1].Font.Size = 9;
            worksheet.Cells[5, 1] = "PWB TYPE  : " + tbPWBType.Text;
            worksheet.Cells[6, 1].Font.FontStyle = "Bold";
            worksheet.Cells[6, 1].Font.Size = 9;
            worksheet.Cells[6, 1] = "PROG.NO.  : " + tbProgNo.Text;
            worksheet.Cells[7, 1].Font.FontStyle = "Bold";
            worksheet.Cells[7, 1].Font.Size = 9;
            worksheet.Cells[7, 1] = "DATE      : " + DateTime.Now.ToString("dd MMMM yyyy");

            worksheet.Range[worksheet.Cells[8, 1], worksheet.Cells[1000, 7]].Font.Name = "Times New Roman";
            worksheet.Range[worksheet.Cells[8, 1], worksheet.Cells[8, 7]].Font.FontStyle = "Bold";
            worksheet.Range[worksheet.Cells[8, 1], worksheet.Cells[8, 7]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
            worksheet.Cells[8, 1] = "REEL";
            worksheet.Cells[8, 2] = "PART CODE";
            worksheet.Cells[8, 3] = "TP";
            worksheet.Cells[8, 4] = "QTY";
            worksheet.Cells[8, 5] = "LOC.";
            worksheet.Cells[8, 6] = "DEC.";
            worksheet.Cells[8, 7] = "F. TYPE";

            connection.Open();
            string resultPartCode = "SELECT tbl_resultcompare.reel, tbl_resultcompare.partcode, tbl_resultcompare.tp, tbl_resultcompare.qty, " +
                "tbl_resultcompare.loc,tbl_resultcompare.dec, tbl_resultcompare.f_Type  FROM tbl_resultcompare " +
                "WHERE tbl_resultcompare.model_No = '" + model[0].Replace(" ", "") + "' AND tbl_resultcompare.process_Name = '" + model[1].Replace(" ", "") + "'";


            using (MySqlDataAdapter dscmd = new MySqlDataAdapter(resultPartCode, connection))
            {
                DataSet ds = new DataSet();
                dscmd.Fill(ds);

                totalpart = ds.Tables[0].Rows.Count;

                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                    {
                        string data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        worksheet.Cells[i + 9, j + 1] = "'" + data;
                    }
                }

            }

            int woQtyy = Convert.ToInt32(woQty.Text);
            int totalPoint = woQtyy - 1;


            totalPointRow = totalpart + 9;
            worksheet.Range[worksheet.Cells[totalPointRow, 1], worksheet.Cells[totalPointRow, 3]].Merge();
            worksheet.Range[worksheet.Cells[totalPointRow, 1], worksheet.Cells[totalPointRow, 6]].Font.FontStyle = "Bold";
            worksheet.Cells[totalPointRow, 1] = "TOTAL POINT";
            worksheet.Cells[totalPointRow, 4] = totalPoint;
            worksheet.Cells[totalPointRow, 5] = " PCB NO: " + tbPCB.Text;
            worksheet.Cells[totalPointRow, 6] = " STENCIL NO : " + tbStencil.Text;

            remarkRow = totalpart + 11;

            string remark = "SELECT remarks FROM tbl_ll";

            using (MySqlDataAdapter dscmd = new MySqlDataAdapter(remark, connection))
            {
                DataSet ds = new DataSet();
                dscmd.Fill(ds);

                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    string data = ds.Tables[0].Rows[i].ItemArray[i].ToString();

                    worksheet.Range[worksheet.Cells[remarkRow, 1], worksheet.Cells[remarkRow, 9]].Merge();
                    worksheet.Cells[remarkRow, 1] = data;
                }
            }
            connection.Close();

            worksheet.Cells[remarkRow + 2, 1] = "FM - SMT - ENG - 011";

            // Saving the file in a speicifed path
            // excelConvert.SaveAs(@"D:\" + model[0].Replace(" ", "").ToString() + " ( " + model[1].Replace(" ", "").ToString() + " )");

            // Closing the file
            excelConvert.Close();
            lf.Close();
            MessageBox.Show("Excel File Success Generated", "Generate Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnHome.Enabled = true;
            btnWO.Enabled = true;
        }
    }
}
