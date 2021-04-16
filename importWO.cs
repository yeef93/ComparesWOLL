using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CompareWOLL
{
    public partial class importWO : Form
    {

        public importWO()
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
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            dataGridViewWO.ReadOnly = true;

            saveButton.Enabled = false;

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
            string queryPcbNo = string.Empty;

            openFileDialogWO.Title = "Please Select a File Work Order";
            //openFileDialogWO.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm| CSV files (*.csv)|*.csv";
            openFileDialogWO.Filter = "Excel Files|*.xls;*.xlsx;";
            openFileDialogWO.InitialDirectory = @"D:\";
            if (openFileDialogWO.ShowDialog() == DialogResult.OK)
            {

                filepathWO.Text = "";
                woPTSN.Text = "";
                woNo.Text = "";
                modelNo.Text = "";
                model.Text = "";
                process.Text = "";
                totalPart.Text = "";
                woQty.Text = "";
                woUsage.Text = "";

                totalPart.BackColor = SystemColors.Control;
                woQty.BackColor = SystemColors.Control;
                woUsage.BackColor = SystemColors.Control;

                string woFileName = openFileDialogWO.FileName;
                filepathWO.Text = woFileName;
                fileExtWO = Path.GetExtension(woFileName); //get the file extension  
                queryWO = "select * from [Sheet1$A3:M]";


                if (fileExtWO.CompareTo(".xls") == 0 || fileExtWO.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(woFileName, fileExtWO, queryWO); //read excel file  
                        dataGridViewWO.Visible = true;
                        dataGridViewWO.DataSource = dtExcel;

                        dataGridViewWO.Columns.RemoveAt(1);
                        dataGridViewWO.Columns.RemoveAt(5);
                        dataGridViewWO.Columns.RemoveAt(8);

                        woPTSN.Text = dataGridViewWO.Rows[0].Cells[8].Value.ToString();
                        woNo.Text = dataGridViewWO.Rows[0].Cells[5].Value.ToString();
                        modelNo.Text = dataGridViewWO.Rows[0].Cells[2].Value.ToString();
                        model.Text = dataGridViewWO.Rows[0].Cells[0].Value.ToString();
                        woUsage.Text = dataGridViewWO.Rows[0].Cells[9].Value.ToString();
                        process.Text = dataGridViewWO.Rows[0].Cells[7].Value.ToString();
                        totalPart.Text = dataGridViewWO.Rows.Count.ToString();

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
                                //var cellPosition = dataGridViewWO.Rows[i].Cells[j];

                                if (cellValue == null ||
                                    cellValue == DBNull.Value || string.IsNullOrEmpty(cellValue.ToString()))
                                {
                                    dataGridViewWO.Rows[i].Cells[j].Style.BackColor = Color.Red;
                                    count++;
                                }
                            }
                        }
                        if (count > 0)
                        {
                            MessageBox.Show("There is " + count.ToString() + " cell is blank, Please revise the document ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error                        
                        }

                        // mendadai merah jika data 1 column tidak sama
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

                            if (cellValueModel != model.Text)
                            {
                                dataGridViewWO.Rows[i].Cells[0].Style.BackColor = Color.Red;
                                count++;
                            }
                            if (cellValueModelNo != modelNo.Text)
                            {
                                dataGridViewWO.Rows[i].Cells[2].Style.BackColor = Color.Red;
                                count++;
                            }
                            if (cellValueWO != woNo.Text)
                            {
                                dataGridViewWO.Rows[i].Cells[5].Style.BackColor = Color.Red;
                                count++;
                            }
                            if (cellValueProcess != process.Text)
                            {
                                dataGridViewWO.Rows[i].Cells[7].Style.BackColor = Color.Red;
                                count++;
                            }
                            if (cellValueWoPtsn != woPTSN.Text)
                            {
                                dataGridViewWO.Rows[i].Cells[8].Style.BackColor = Color.Red;
                                count++;
                            }
                            if (cellValueWoQty != woUsage.Text)
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
                        for (int i = 0; i < dataGridViewWO.Rows.Count; ++i)
                        {
                            if (dataGridViewWO.Rows[i].Cells[0].Style.BackColor == Color.Red ||
                                dataGridViewWO.Rows[i].Cells[2].Style.BackColor == Color.Red ||
                                dataGridViewWO.Rows[i].Cells[5].Style.BackColor == Color.Red ||
                                dataGridViewWO.Rows[i].Cells[7].Style.BackColor == Color.Red ||
                                dataGridViewWO.Rows[i].Cells[8].Style.BackColor == Color.Red ||
                                dataGridViewWO.Rows[i].Cells[9].Style.BackColor == Color.Red ||
                                dataGridViewWO.Rows[i].Cells[3].Style.BackColor == Color.Red
                               )
                            {
                                MessageBox.Show("Data Issue Part Not Match, Please Check Excel File", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                                saveButton.Enabled = false;
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
                                totalPart.Text = "#Erorr";
                                totalPart.BackColor = System.Drawing.Color.Red;

                                woQty.Text = "#Erorr";
                                woQty.BackColor = System.Drawing.Color.Red;

                                woUsage.Text = "#Erorr";
                                woUsage.BackColor = System.Drawing.Color.Red;

                                dataGridViewWO.Rows[i].DefaultCellStyle = styleError;
                            }
                            if (totalPart.Text == "#Erorr" || woQty.Text == "#Erorr" || woUsage.Text == "#Erorr")
                            {
                                saveButton.Enabled = false;
                            }
                            if (process.Text == "")
                            {
                                //MessageBox.Show("Please fill process column", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                            }
                            else
                            {
                                saveButton.Enabled = true;
                            }
                        }

                        woQty.Text = sum.ToString();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message.ToString());

                        if (ex.Message.ToString() == "Object cannot be cast from DBNull to Other types.")
                        {
                            MessageBox.Show("Selected file not match with WO template", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                        }
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
            homeButton.Enabled = false;
            backButton.Enabled = false;
            LoadForm lf = new LoadForm();
            lf.Show();

            System.Threading.Thread.Sleep(2000);

            string woPTSNN = woPTSN.Text;
            string woNoo = woNo.Text;
            string modelNoo = modelNo.Text;
            string modell = model.Text;
            string woqtyy = woQty.Text;
            string wousagee = woUsage.Text;
            string processs = process.Text;
            //string pcbNoo = pcbNo.Text;
            saveButton.Enabled = false;


            if (woPTSNN == "" | woNoo == "" | modelNoo == "" | modell == "" | woqtyy == "")
            {
                lf.Close();
                saveButton.Enabled = true;
                MessageBox.Show("Unable to import Work Order without fill data properly", "Work Order", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {
                try
                {
                    var conn = new MySqlConnection("Host=localhost;Uid=root;Pwd=;Database=pe");
                    var cmd = new MySqlCommand("", conn);

                    string cekmodel = "SELECT model_No, process_Name FROM tbl_model  WHERE model_No = '" + modelNoo + "' AND process_Name = '" + processs + "'";
                    string query = "INSERT INTO tbl_wo VALUES('', '" + woPTSNN + "','" + woNoo + "','" + modelNoo + "','" + modell + "', '" + woqtyy + "', '" + wousagee + "','" + processs + "' )";
                    string querymodel = "INSERT INTO tbl_model VALUES('','" + modelNoo + "','" + processs + "')";

                    conn.Open();
                    //Buka koneksi

                    using (MySqlDataAdapter dscmd = new MySqlDataAdapter(cekmodel, conn))
                    {
                        DataSet ds = new DataSet();
                        dscmd.Fill(ds);

                        if (ds.Tables[0].Rows.Count >= 1)
                        {
                            lf.Close();
                            MessageBox.Show("Work Order Data " + modelNoo + "  " + processs + " already uploaded", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                            homeButton.Enabled = true;
                            backButton.Enabled = true;
                        }

                        else
                        {

                            string[] allQuery = { query, querymodel };
                            for (int i = 0; i < allQuery.Length; i++)
                            {
                                cmd.CommandText = allQuery[i];
                                //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                                cmd.ExecuteNonQuery();
                                //Jalankan perintah / query dalam CommandText pada database
                            }

                            //cmd.CommandText = query;
                            //cmd.CommandText = querymodel;
                            ////Masukkan perintah/query yang akan dijalankan ke dalam CommandText  

                            for (int i = 0; i < dataGridViewWO.Rows.Count; i++)
                            {
                                string StrQuery = "INSERT INTO tbl_wodetail VALUES ('"
                                    + dataGridViewWO.Rows[i].Cells[2].Value.ToString() + "', '"
                                    + dataGridViewWO.Rows[i].Cells[1].Value.ToString() + "', '"
                                    + dataGridViewWO.Rows[i].Cells[7].Value.ToString() + "', '"
                                    + dataGridViewWO.Rows[i].Cells[3].Value.ToString() + "', '"
                                    + dataGridViewWO.Rows[i].Cells[6].Value.ToString() + "', '"
                                    + dataGridViewWO.Rows[i].Cells[4].Value.ToString() + "');";
                                cmd.CommandText = StrQuery;
                                cmd.ExecuteNonQuery();
                            }

                            conn.Close();
                            //Tutup koneksi
                            lf.Close();
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
                    MessageBox.Show(ex.Message.ToString());
                    saveButton.Enabled = true;
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
    }
}
