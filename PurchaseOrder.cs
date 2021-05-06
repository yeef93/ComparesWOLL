using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class PurchaseOrder : Form
    {
        MySqlConnection connection = new MySqlConnection("server=192.168.1.1;database=pedev;user=root;password=12345;");

        public PurchaseOrder()
        {
            InitializeComponent();
        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            connection.Open();

            string querywo = "SELECT customer, wo_PTSN, model, wo_Usage, wo_QTY FROM tbl_wo WHERE detail = 'po' ORDER BY id DESC";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(querywo, connection))
            {
                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridViewPoList.DataSource = dset.Tables[0];

                // add button detail in datagridview table
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridViewPoList.Columns.Add(btn);
                btn.HeaderText = "";
                btn.Text = "Detail";
                btn.Name = "btnDetail";
                btn.UseColumnTextForButtonValue = true;

                // add button import in datagridview table
                DataGridViewButtonColumn btnImport = new DataGridViewButtonColumn();
                dataGridViewPoList.Columns.Add(btnImport);
                btnImport.HeaderText = "";
                btnImport.Text = "Import Loading List";
                btnImport.Name = "btnImport";
                btnImport.UseColumnTextForButtonValue = true;

                // add button compare WO LL in datagridview table
                DataGridViewButtonColumn btnCompare = new DataGridViewButtonColumn();
                dataGridViewPoList.Columns.Add(btnCompare);
                btnCompare.HeaderText = "";
                btnCompare.Text = "Compare With LL";
                btnCompare.Name = "btnCompare";
                btnCompare.UseColumnTextForButtonValue = true;

                // add button delete in datagridview table
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                dataGridViewPoList.Columns.Add(btnDelete);
                btnDelete.HeaderText = "";
                btnDelete.Text = "Delete";
                btnDelete.Name = "btnDelete";
                btnDelete.UseColumnTextForButtonValue = true;

            }
            connection.Close();

            // Set table title Wo
            string[] titleWO = { "CUSTOMER", "PO NO", "MODEL", "WO USAGE", "WO QTY" };
            for (int i = 0; i < titleWO.Length; i++)
            {
                dataGridViewPoList.Columns[i].HeaderText = "" + titleWO[i];
            }

        }
        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.toolStripUsername.Text = toolStripUsername.Text;
            mm.Show();
            this.Hide();
        }

        private void importPO_Click(object sender, EventArgs e)
        {
            importPO iPO = new importPO();
            iPO.toolStripUsername.Text = toolStripUsername.Text;
            iPO.Show();
            this.Hide();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (dataGridViewPoList.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("customer LIKE '{0}%' or wo_PTSN LIKE '{0}%' or model LIKE '{0}%'", tbSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewPoList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridViewPoList.SelectedCells[0].RowIndex;
            string poNoslctd = dataGridViewPoList.Rows[i].Cells[1].Value.ToString();

            if (e.ColumnIndex == 5)
            {
                DetailPO dpo = new DetailPO();
                string cust = dataGridViewPoList.Rows[e.RowIndex].Cells[0].Value.ToString();
                string poNo = dataGridViewPoList.Rows[e.RowIndex].Cells[1].Value.ToString();
                string model = dataGridViewPoList.Rows[e.RowIndex].Cells[2].Value.ToString();
                string totalUsage = dataGridViewPoList.Rows[e.RowIndex].Cells[3].Value.ToString();
                string poQty = dataGridViewPoList.Rows[e.RowIndex].Cells[4].Value.ToString();

                dpo.tbCustomer.Text = cust;
                dpo.tbPoNo.Text = poNo;
                dpo.tbPoModel.Text = model;
                dpo.tbtotalUsage.Text = totalUsage;
                dpo.tbPoQty.Text = poQty;

                dpo.Show();
                this.Hide();
            }

            if (e.ColumnIndex == 7)
            {
                string poNo = dataGridViewPoList.Rows[e.RowIndex].Cells[1].Value.ToString();

                Compare cowl = new Compare();
                cowl.cmbWOPtsn.Text = poNo;
                cowl.Show();
                this.Hide();
            }

            if (e.ColumnIndex == 8)
            {
                string message = "Do you want to delete this Purchase Order and Loading List record for PO NO " + poNoslctd + " ?";
                string title = "Delete Purchase Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    var cmd = new MySqlCommand("", connection);

                    string querydeleteWO = "DELETE FROM tbl_wo WHERE wo_PTSN = '" + poNoslctd + "'";
                    string querydeleteWODetail = "DELETE FROM tbl_wodetail WHERE  wo_PTSN = '" + poNoslctd + "'";

                    string querydeleteLL = "DELETE FROM tbl_ll WHERE wo_PTSN = '" + poNoslctd + "'";
                    string querydeleteLLDetail = "DELETE FROM tbl_lldetail WHERE wo_PTSN = '" + poNoslctd + "'";
                    string querydeletePartCode = "DELETE FROM tbl_partcodedetail WHERE wo_PTSN = '" + poNoslctd + "'";
                    string querydeleteReel = "DELETE FROM tbl_reel WHERE wo_PTSN= '" + poNoslctd + "'";
                    string querydeleteResult = "DELETE FROM tbl_resultcompare WHERE wo_PTSN = '" + poNoslctd + "'";

                    connection.Open();

                    string[] allQuery = { querydeleteWO, querydeleteWODetail, querydeleteLL, querydeleteLLDetail, querydeletePartCode, querydeleteReel, querydeleteResult };
                    for (int j = 0; j < allQuery.Length; j++)
                    {
                        cmd.CommandText = allQuery[j];
                        //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                        cmd.ExecuteNonQuery();
                        //Jalankan perintah / query dalam CommandText pada database
                    }

                    connection.Close();
                    PurchaseOrder po = new PurchaseOrder();
                    po.Show();
                    this.Hide();
                    MessageBox.Show("Record Deleted successfully", "Purchase Order Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                }
            }
        }
    }
}
