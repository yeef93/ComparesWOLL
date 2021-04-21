using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class LoadingList : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");

        public LoadingList()
        {
            InitializeComponent();

        }
        private void LoadingList_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            
            connection.Open();

            string queryLL = "SELECT customer, model_No, process_Name, model_detail, machine, pwb_Type, prog_No, rev, pcb_No, part_Count FROM tbl_ll";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryLL, connection))
            {
                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridViewLLList.DataSource = dset.Tables[0];

                // add button detail in datagridview table
                DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn();
                dataGridViewLLList.Columns.Add(btnDetail);
                btnDetail.HeaderText = "";
                btnDetail.Text = "Detail";
                btnDetail.Name = "btnDetail";
                btnDetail.UseColumnTextForButtonValue = true;

                // add button delete in datagridview table
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                dataGridViewLLList.Columns.Add(btnDelete);
                btnDelete.HeaderText = "";
                btnDelete.Text = "Delete";
                btnDelete.Name = "btnDelete";
                btnDelete.UseColumnTextForButtonValue = true;

            }
            connection.Close();

            // Set table title Wo
            string[] titleWO = { "CUSTOMER", "MODEL NO", "PROCESS NAME", "MODEL DETAIL", "MACHINE", "PWB TYPE", "PROG NO", "REV", "PCB NO", "PART COUNT" };
            for (int i = 0; i < titleWO.Length; i++)
            {
                dataGridViewLLList.Columns[i].HeaderText = "" + titleWO[i];
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.toolStripUsername.Text = toolStripUsername.Text;
            mm.Show();
            this.Hide();
        }

        private void importWO_Click(object sender, EventArgs e)
        {
            ImportLL ill = new ImportLL();
            ill.Show();
            this.Hide();
        }

        private void dataGridViewLLList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridViewLLList.SelectedCells[0].RowIndex;
            string modelslctd = dataGridViewLLList.Rows[i].Cells[1].Value.ToString();
            string processslctd = dataGridViewLLList.Rows[i].Cells[2].Value.ToString();

            if (e.ColumnIndex == 10)
            {
                DetailLL dll = new DetailLL();
                string cust = dataGridViewLLList.Rows[e.RowIndex].Cells[0].Value.ToString();
                string modelNo = dataGridViewLLList.Rows[e.RowIndex].Cells[1].Value.ToString();
                string process = dataGridViewLLList.Rows[e.RowIndex].Cells[2].Value.ToString();
                string model = dataGridViewLLList.Rows[e.RowIndex].Cells[3].Value.ToString();
                string machine = dataGridViewLLList.Rows[e.RowIndex].Cells[4].Value.ToString();
                string pwbType = dataGridViewLLList.Rows[e.RowIndex].Cells[5].Value.ToString();
                string prog = dataGridViewLLList.Rows[e.RowIndex].Cells[6].Value.ToString();
                string rev = dataGridViewLLList.Rows[e.RowIndex].Cells[7].Value.ToString();
                string mainpcb = dataGridViewLLList.Rows[e.RowIndex].Cells[8].Value.ToString();

                dll.tbCustomer.Text = cust;
                dll.tbModelNo.Text = modelNo;
                dll.tbProcess.Text = process;
                dll.tbModel.Text =model;
                dll.tbPWBType.Text = pwbType;
                dll.tbMachine.Text = machine;
                dll.tbProg.Text = prog;
                dll.tbRev.Text = rev;
                dll.tbPcbNo.Text = mainpcb;

                dll.Show();
                this.Hide();
            }

                if (e.ColumnIndex == 11)
            {                
                string message = "Do you want to delete this Loading List " +modelslctd + " " +processslctd + " ?";
                string title = "Delete Loading List";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    
                    var cmd = new MySqlCommand("", connection);

                    string querydeleteLL = "DELETE FROM tbl_ll WHERE model_No = '"+modelslctd+ "' AND process_Name = '" + processslctd + "'";
                    string querydeleteLLDetail = "DELETE FROM tbl_lldetail WHERE model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";
                    string querydeletePartCode = "DELETE FROM tbl_partcodedetail WHERE model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";
                    string querydeleteReel = "DELETE FROM tbl_reel WHERE model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";
                    string querydeleteResult = "DELETE FROM tbl_resultcompare WHERE model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";

                    connection.Open();                    

                    string[] allQuery = { querydeleteLL, querydeleteLLDetail, querydeletePartCode, querydeleteReel, querydeleteResult };
                    for (int j = 0; j < allQuery.Length; j++)
                    {
                        cmd.CommandText = allQuery[j];
                        //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                        cmd.ExecuteNonQuery();
                        //Jalankan perintah / query dalam CommandText pada database
                    }

                    connection.Close();
                    LoadingList ll = new LoadingList();
                    ll.Show();
                    this.Hide();
                    MessageBox.Show("Record Deleted successfully", "Loading List Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                { 
                }
            }
        }
    }
}
