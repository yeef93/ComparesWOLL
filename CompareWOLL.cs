using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class CompareWOLL : Form
    {
        
        ExcelConvert excelConvert = new ExcelConvert();

        public CompareWOLL()
        {
            InitializeComponent();        }

        private void CompareWOLL_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            cmbLLModelNo.Enabled = false;
            btnCompare.Enabled = false;
            btnGenerate.Enabled = false;

            MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
            connection.Open();

            string queryModelWO = "SELECT model_No FROM tbl_model";
            string queryModelLL = "SELECT model_No FROM tbl_ll";

            try
            {
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryModelWO, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    cmbWOModelNo.DataSource = dset;
                    cmbWOModelNo.ValueMember = "model_No";
                    cmbWOModelNo.DisplayMember = "model_No";

                }

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryModelLL, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    cmbLLModelNo.DataSource = dset;
                    cmbLLModelNo.ValueMember = "model_No";
                    cmbLLModelNo.DisplayMember = "model_No";
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }


        }
        private void cmbWOModelNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
            connection.Open();

            string query = "SELECT process_Name FROM tbl_wodetail WHERE model_No = '" + cmbWOModelNo.SelectedValue.ToString() + "' GROUP BY process_Name ";
            try
            {
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    cmbWOProcess.DataSource = dset;
                    cmbWOProcess.ValueMember = "process_Name";
                    cmbWOProcess.DisplayMember = "process_Name";

                }
                connection.Close();

            }
            catch (Exception ex)
            {
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
            connection.Open();

            string query = "SELECT process_Name FROM tbl_ll WHERE model_No = '" + cmbLLModelNo.SelectedValue.ToString() + "'";
            try
            {
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    cmbLLProcess.DataSource = dset;
                    cmbLLProcess.ValueMember = "process_Name";
                    cmbLLProcess.DisplayMember = "process_Name";

                }
                connection.Close();

            }
            catch (Exception ex)
            {
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }
        }


        private void cmbWOProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLLModelNo.Enabled = true;
        }

        private void cmbLLProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCompare.Enabled = true;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
            connection.Open();

            string queryWO = "SELECT SUM(qty) AS totalWO FROM tbl_wodetail WHERE model_No = '" + cmbWOModelNo.SelectedValue.ToString() + "' AND process_Name = '" + cmbWOProcess.SelectedValue.ToString() + "'";
            string queryLL = "SELECT SUM(qty) AS totalLL FROM tbl_lldetail WHERE alt_No = '1' AND model_No = '" + cmbWOModelNo.SelectedValue.ToString() + "' AND process_Name = '" + cmbWOProcess.SelectedValue.ToString() + "'";

            string queryTblWO = "SELECT partcode, qty FROM tbl_wodetail WHERE model_No = '" + cmbLLModelNo.SelectedValue.ToString() + "' AND process_Name = '" + cmbLLProcess.SelectedValue.ToString() + "'";

            try
            {
                //nampilin qty Wo
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryWO, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    if (dset.Rows.Count > 0)
                    {
                        woQty.Text = dset.Rows[0]["totalWO"].ToString();
                    }

                }

                //nampilin qty LL
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryLL, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    if (dset.Rows.Count > 0)
                    {
                        llQty.Text = dset.Rows[0]["totalLL"].ToString();
                    }

                }

                //nampilin selected PCB
                string queryPCB = "SELECT tbl_wodetail.partcode FROM tbl_wodetail LEFT JOIN tbl_lldetail ON " +
                    "tbl_wodetail.partcode = tbl_lldetail.partcode WHERE tbl_wodetail.model_No = '" + cmbLLModelNo.SelectedValue.ToString() + "' " +
                    "AND tbl_wodetail.process_Name = '" + cmbLLProcess.SelectedValue.ToString() + "' AND tbl_lldetail.reel = 'PCB'";
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryPCB, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    if (dset.Rows.Count > 0)
                    {
                        tbPCB.Text = dset.Rows[0]["partcode"].ToString();
                    }

                }

                //nampilin data dalam datagridview compare

                string query = "SELECT tbl_lldetail.reel, tbl_wodetail.partcode, tbl_lldetail.partcode, tbl_wodetail.qty, " +
                    "tbl_lldetail.qty, tbl_lldetail.alt_No FROM tbl_wodetail LEFT JOIN tbl_lldetail " +
                    "ON tbl_wodetail.partcode = tbl_lldetail.partcode WHERE " +
                    "tbl_wodetail.model_No = '" + cmbLLModelNo.SelectedValue.ToString() + "' AND " +
                    "tbl_wodetail.process_Name = '" + cmbLLProcess.SelectedValue.ToString() + "' AND tbl_lldetail.reel != 'PCB'";
                    

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
                {
                    DataSet dset = new DataSet();

                    adpt.Fill(dset);

                    dataGridViewCompareLLWO.DataSource = dset.Tables[0];
                    dataGridViewCompareLLWO.Columns.Add("columnPartStatus", "Status");

                    //tampilin data temporary result
                    dataGridViewCompareLLWOResult.DataSource = dset.Tables[0];

                }

                dataGridViewCompareLLWOResult.Columns.RemoveAt(2);
                dataGridViewCompareLLWOResult.Columns.RemoveAt(4);
                dataGridViewCompareLLWOResult.Columns.RemoveAt(3);

                connection.Close();

                //menghitung jumlah row data

                int rowCount = ((DataTable)this.dataGridViewCompareLLWO.DataSource).Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    DataGridViewCellStyle styleOk = new DataGridViewCellStyle();
                    styleOk.BackColor = Color.Green;
                    styleOk.ForeColor = Color.White;

                    DataGridViewCellStyle styleError = new DataGridViewCellStyle();
                    styleError.BackColor = Color.Red;
                    styleError.ForeColor = Color.White;

                    

                    if (dataGridViewCompareLLWO.Rows[i].Cells[1].Value.ToString() !=
                        dataGridViewCompareLLWO.Rows[i].Cells[2].Value.ToString() ||
                        dataGridViewCompareLLWO.Rows[i].Cells[3].Value.ToString() !=
                        dataGridViewCompareLLWO.Rows[i].Cells[4].Value.ToString())
                    {
                        dataGridViewCompareLLWO.Rows[i].Cells[6].Value = "Part Code and Qty Not Match with Loading List";
                        dataGridViewCompareLLWO.Rows[i].DefaultCellStyle = styleError;

                        btnWO.Enabled = true;
                    }

                    else if (dataGridViewCompareLLWO.Rows[i].Cells[1].Value.ToString() !=
                        dataGridViewCompareLLWO.Rows[i].Cells[2].Value.ToString())
                    {
                        dataGridViewCompareLLWO.Rows[i].Cells[6].Value = "Part Code Not Found in Loading List";
                        dataGridViewCompareLLWO.Rows[i].DefaultCellStyle = styleError;
                    }

                    else if (dataGridViewCompareLLWO.Rows[i].Cells[3].Value.ToString() !=
                        dataGridViewCompareLLWO.Rows[i].Cells[4].Value.ToString())
                    {
                        dataGridViewCompareLLWO.Rows[i].Cells[6].Value = "Qty Not Match with Loading List";
                        dataGridViewCompareLLWO.Rows[i].DefaultCellStyle = styleError;
                    }

                    //compare partcode
                    else if (dataGridViewCompareLLWO.Rows[i].Cells[1].Value.ToString() ==
                        dataGridViewCompareLLWO.Rows[i].Cells[2].Value.ToString() ||
                        dataGridViewCompareLLWO.Rows[i].Cells[3].Value.ToString() ==
                        dataGridViewCompareLLWO.Rows[i].Cells[4].Value.ToString())
                    {
                        dataGridViewCompareLLWO.Rows[i].Cells[6].Value = "Part Code and Qty Match";
                        dataGridViewCompareLLWO.Rows[i].DefaultCellStyle = styleOk;
                    }

                }

                // Set table title Wo
                string[] titleWO = { "REEL", "PART CODE WO", "PART CODE LL", "QTY WO", "QTY LL", "CHOICE NO" };
                for (int i = 0; i < titleWO.Length; i++)
                {
                    dataGridViewCompareLLWO.Columns[i].HeaderText = "" + titleWO[i];
                }

                for (int i = 0; i < dataGridViewCompareLLWO.Columns.Count; i++)
                {
                    dataGridViewCompareLLWO.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                // display qty match or not

                if (woQty.Text == llQty.Text)
                {
                    compareQty.BackColor = System.Drawing.Color.Blue;
                    compareQty.Text = "Match";
                    btnGenerate.Enabled = true;
                }

                else if (woQty.Text != llQty.Text)
                {
                    compareQty.Text = "Not Match";
                    compareQty.BackColor = System.Drawing.Color.Red;
                    btnGenerate.Enabled = false;
                }
                
            }
            catch (Exception ex)
            {
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerate_Click_1(object sender, EventArgs e)
        {
            int totalpart;
            int nextrow;

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

            //Insert result to db
            var conn = new MySqlConnection("Host=localhost;Uid=root;Pwd=;Database=pe");
            var cmd = new MySqlCommand("", conn);
            conn.Open();

            for (int i = 0; i < dataGridViewCompareLLWOResult.Rows.Count; i++)
            {
                string queryResult = "INSERT INTO tbl_resultcompare (tbl_resultcompare.model_No, tbl_resultcompare.process_Name, " +
                    "tbl_resultcompare.reel, tbl_resultcompare.partcode, tbl_resultcompare.alt_No, tbl_resultcompare.tp, tbl_resultcompare.qty," +
                    " tbl_resultcompare.loc, tbl_resultcompare.dec, tbl_resultcompare.f_Type)" +
                    "SELECT tbl_reel.model_No, tbl_reel.process_Name, tbl_reel.reel, tbl_partcodedetail.partcode,tbl_lldetail.alt_No," +
                    " tbl_partcodedetail.tp, tbl_reel.qty, tbl_reel.loc, tbl_partcodedetail.dec,tbl_reel.f_Type " +
                    "FROM tbl_reel, tbl_partcodedetail, tbl_lldetail WHERE tbl_reel.reel = '" + dataGridViewCompareLLWOResult.Rows[i].Cells[0].Value.ToString() + "' " +
                    "AND tbl_partcodedetail.partcode = '" + dataGridViewCompareLLWOResult.Rows[i].Cells[1].Value.ToString() + "' AND tbl_reel.model_No = '" + cmbLLModelNo.SelectedValue.ToString() + "' " +
                    "AND tbl_reel.process_Name = '" + cmbLLProcess.SelectedValue.ToString() + "' " +
                    "AND tbl_partcodedetail.partcode = tbl_lldetail.partcode";
                cmd.CommandText = queryResult;
                cmd.ExecuteNonQuery();
            }
            conn.Close();

            worksheet.Rows.Font.Name = "Times New Roman";
            worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 9]].Merge();
            worksheet.Cells[1, 1] = "SMT MACHINE LOADING LIST";
            worksheet.Cells[1, 1].Style.Font.Size = 20;            
            worksheet.Cells[1, 1].Font.Color = Color.Blue;
            worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

            worksheet.Cells[2, 9] = "Page 1 of 1";
            worksheet.Cells[2, 9].Style.Font.Size = 10;
            //worksheet.Cells.Font.Color = Color.Blue;
            worksheet.Cells[2, 9].EntireRow.Font.Italic = true;


            worksheet.Rows.Font.Name = "Courier New";
            worksheet.Cells[3, 1] = "MODEL     : XM-522J19C10000 SB  MASTER (SMT-A)";
            worksheet.Cells[3, 6] = "Rev.";
            worksheet.Cells[3, 6].Font.Color = Color.White;
            worksheet.Cells[3, 7] = "Prepared by";
            worksheet.Cells[3, 8] = "Checked by";
            worksheet.Cells[3, 9] = "Approved by";

            worksheet.Cells[4, 1] = "MACHINE   : NXT3-D15MCLB (LINE #07H-LB)";
            worksheet.Cells[5, 1] = "PWB TYPE  : J19C SB (1 PNL : 16 PCS)";
            worksheet.Cells[6, 1] = "PROG.NO.  : 7HLB-52J19CJSB-A";
            worksheet.Cells[7, 1] = "DATE      : 19 Dec 2020";

            worksheet.Cells[8, 1] = "REEL";
            worksheet.Cells[8, 2] = "PART CODE";
            worksheet.Cells[8, 3] = "TP";
            worksheet.Cells[8, 4] = "QTY";
            worksheet.Cells[8, 5] = "LOC.";
            worksheet.Cells[8, 6] = "DEC.";
            worksheet.Cells[8, 7] = "F. TYPE";

            conn.Open();
            string resultPartCode = "SELECT tbl_resultcompare.reel, tbl_resultcompare.partcode, tbl_resultcompare.tp, tbl_resultcompare.qty, " +
                "tbl_resultcompare.loc,tbl_resultcompare.dec, tbl_resultcompare.f_Type  FROM tbl_resultcompare " +
                "WHERE tbl_resultcompare.model_No = '" + cmbLLModelNo.SelectedValue.ToString() + "' AND tbl_resultcompare.process_Name = '" + cmbLLProcess.SelectedValue.ToString() + "'";
               

            using (MySqlDataAdapter dscmd = new MySqlDataAdapter(resultPartCode, conn))
            {
                DataSet ds = new DataSet();
                dscmd.Fill(ds);

                totalpart = ds.Tables[0].Rows.Count;

                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                    {
                        string data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        worksheet.Cells[i + 9, j + 1] = data;
                    }
                }

            }

            nextrow = totalpart + 9;

            string remark = "SELECT remarks FROM tbl_ll";


            using (MySqlDataAdapter dscmd = new MySqlDataAdapter(remark, conn))
            {
                DataSet ds = new DataSet();
                dscmd.Fill(ds);

                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
               {
                    string data = ds.Tables[0].Rows[i].ItemArray[i].ToString();

                    worksheet.Range[worksheet.Cells[23, 1], worksheet.Cells[23, 9]].Merge();
                    worksheet.Cells[23, 1] = data ;
                }
            }

            conn.Close();


            //conn.Open();
            //string detailLL = "SELECT model_No, machine, pwb_Type, prog_No, process_Name, model_detail, rev, pcb_No, remarks FROM tbl_ll";


            //using (MySqlDataAdapter dscmd = new MySqlDataAdapter(detailLL, conn))
            //{
            //    DataSet ds = new DataSet();
            //    dscmd.Fill(ds);

            //    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            //    {
            //        for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
            //        {
            //            string data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
            //            worksheet.Cells[i + 3, j + 1] = "MODEL     : " + data +"" ;
            //        }
            //    }

            //}
            //conn.Close();

            // Saving the file in a speicifed path
            // excelConvert.SaveAs(@"D:\" + cmbLLModelNo.SelectedValue.ToString() + " ( " + cmbLLProcess.SelectedValue.ToString() + " )");

            // Closing the file
            excelConvert.Close();

            MessageBox.Show("Excel File Success Generated", "Generate Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnGenerate.Enabled = false;
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
    }
}
