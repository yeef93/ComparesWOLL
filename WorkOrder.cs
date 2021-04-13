using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class WorkOrder : Form
    {
        public WorkOrder()
        {
            InitializeComponent();
        }

        private void WorkOrder_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
            connection.Open();

            string querywo = "SELECT wo_PTSN, wo_No, model_No, model, process_Name ,wo_QTY, wo_Usage FROM tbl_wo";
            string queryll = "SELECT model_No, process_Name FROM tbl_ll WHERE model_No = '60B38YE10A02P' AND process_Name = 'SMT-A'";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(querywo, connection))
            {
                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridViewWoList.DataSource = dset.Tables[0];

                // add button detail in datagridview table
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridViewWoList.Columns.Add(btn);
                btn.HeaderText = "";
                btn.Text = "Detail";
                btn.Name = "btnDetail";
                btn.UseColumnTextForButtonValue = true;

                // add button delete in datagridview table
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                dataGridViewWoList.Columns.Add(btnDelete);
                btnDelete.HeaderText = "";
                btnDelete.Text = "Delete";
                btnDelete.Name = "btnDelete";
                btnDelete.UseColumnTextForButtonValue = true;

                // add button import in datagridview table
                DataGridViewButtonColumn btnImport = new DataGridViewButtonColumn();
                dataGridViewWoList.Columns.Add(btnImport);
                btnImport.HeaderText = "";
                btnImport.Text = "Import Loading List";
                btnImport.Name = "btnImport";
                btnImport.UseColumnTextForButtonValue = true;
                //btnImport.Visible = false;


                // add button compare WO LL in datagridview table
                DataGridViewButtonColumn btnCompare = new DataGridViewButtonColumn();
                dataGridViewWoList.Columns.Add(btnCompare);
                btnCompare.HeaderText = "";
                btnCompare.Text = "Compare With LL";
                btnCompare.Name = "btnCompare";
                btnCompare.UseColumnTextForButtonValue = true;


            }
            connection.Close();

            // Set table title Wo
            string[] titleWO = { "WO PTSN", "WO NO", "MODEL NO", "MODEL", "PROCESS NAME", "WO QTY", "WO USAGE" };
            for (int i = 0; i < titleWO.Length; i++)
            {
                dataGridViewWoList.Columns[i].HeaderText = "" + titleWO[i];
            }


        }

        private void importWO_Click(object sender, EventArgs e)
        {
            importWO iWO = new importWO();
            iWO.toolStripUsername.Text = toolStripUsername.Text;
            iWO.Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.toolStripUsername.Text = toolStripUsername.Text;
            mm.Show();
            this.Hide();
        }

        private void dataGridViewWoList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridViewWoList.SelectedCells[0].RowIndex;
            string modelslctd = dataGridViewWoList.Rows[i].Cells[2].Value.ToString();
            string processslctd = dataGridViewWoList.Rows[i].Cells[4].Value.ToString();

            if (e.ColumnIndex == 7)
            {
                DetailWO dwo = new DetailWO();
                string woPtsn = dataGridViewWoList.Rows[e.RowIndex].Cells[0].Value.ToString();
                string woNo = dataGridViewWoList.Rows[e.RowIndex].Cells[1].Value.ToString();
                string modelNo = dataGridViewWoList.Rows[e.RowIndex].Cells[2].Value.ToString();
                string model = dataGridViewWoList.Rows[e.RowIndex].Cells[3].Value.ToString();
                string processName = dataGridViewWoList.Rows[e.RowIndex].Cells[4].Value.ToString();
                string woQty = dataGridViewWoList.Rows[e.RowIndex].Cells[6].Value.ToString();
                string woUsage = dataGridViewWoList.Rows[e.RowIndex].Cells[5].Value.ToString();


                dwo.woPTSN.Text = woPtsn;
                dwo.woNo.Text = woNo;
                dwo.modelNo.Text = modelNo;
                dwo.model.Text = model;
                dwo.woQty.Text = woQty;
                dwo.woUsage.Text = woUsage;
                dwo.process.Text = processName;

                dwo.Show();
                this.Hide();
                //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
            }

            if (e.ColumnIndex == 8)
            {
                string message = "Do you want to delete this Work Order and Loading List record " + modelslctd + " " + processslctd + " ?";
                string title = "Delete Work Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    var conn = new MySqlConnection("Host=localhost;Uid=root;Pwd=;Database=pe");
                    var cmd = new MySqlCommand("", conn);

                    string querydeleteWO = "DELETE FROM tbl_wo WHERE  model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";
                    string querydeleteWODetail = "DELETE FROM tbl_wodetail WHERE  model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";
                    string querydeleteModel = "DELETE FROM tbl_model WHERE  model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";

                    string querydeleteLL = "DELETE FROM tbl_ll WHERE model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";
                    string querydeleteLLDetail = "DELETE FROM tbl_lldetail WHERE model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";
                    string querydeletePartCode = "DELETE FROM tbl_partcodedetail WHERE model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";
                    string querydeleteReel = "DELETE FROM tbl_reel WHERE model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";
                    string querydeleteResult = "DELETE FROM tbl_resultcompare WHERE model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";

                    conn.Open();

                    string[] allQuery = { querydeleteWO, querydeleteWODetail, querydeleteModel, querydeleteLL, querydeleteLLDetail, querydeletePartCode, querydeleteReel, querydeleteResult };
                    for (int j = 0; j < allQuery.Length; j++)
                    {
                        cmd.CommandText = allQuery[j];
                        //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                        cmd.ExecuteNonQuery();
                        //Jalankan perintah / query dalam CommandText pada database
                    }

                    conn.Close();
                    WorkOrder wo = new WorkOrder();
                    wo.Show();
                    this.Hide();
                    MessageBox.Show("Record Deleted successfully", "Work Order Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                }
            }

            if (e.ColumnIndex == 9)
            {

                ImportLL il = new ImportLL();
                string model = dataGridViewWoList.Rows[e.RowIndex].Cells[2].Value.ToString();
                string processName = dataGridViewWoList.Rows[e.RowIndex].Cells[4].Value.ToString();
                il.Show();
                il.tbModelNo.Text = model;
                il.tbProcess.Text = processName;
                this.Hide();

                //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked "+model+"");
            }

            if (e.ColumnIndex == 10)
            {

                CompareWOLL cowl = new CompareWOLL();
                cowl.Show();
                this.Hide();
            }
        }
    }
}
