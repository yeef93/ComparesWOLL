using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class LoadingList : Form
    {
        public LoadingList()
        {
            InitializeComponent();

        }


        private void LoadingList_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
            connection.Open();

            string query = "SELECT model_No, process_Name, model_detail, machine, pwb_Type, prog_No, rev, pcb_No, part_Count FROM tbl_ll";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
            {
                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridViewLLList.DataSource = dset.Tables[0];


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
            string[] titleWO = { "MODEL NO", "PROCESS NAME", "MODEL DETAIL", "MACHINE", "PWB TYPE", "PROG NO", "REV", "PCB NO", "PART COUNT" };
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
            string modelslctd = dataGridViewLLList.Rows[i].Cells[0].Value.ToString();
            string processslctd = dataGridViewLLList.Rows[i].Cells[1].Value.ToString();

            if (e.ColumnIndex == 9)
            {                
                string message = "Do you want to delete this Loading List " +modelslctd + " " +processslctd + " ?";
                string title = "Delete Loading List";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    var conn = new MySqlConnection("Host=localhost;Uid=root;Pwd=;Database=pe");
                    var cmd = new MySqlCommand("", conn);

                    string querydeleteLL = "DELETE FROM tbl_ll WHERE model_No = '"+modelslctd+ "' AND process_Name = '" + processslctd + "'";
                    string querydeleteLLDetail = "DELETE FROM tbl_lldetail WHERE model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";
                    string querydeletePartCode = "DELETE FROM tbl_partcodedetail WHERE model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";
                    string querydeleteReel = "DELETE FROM tbl_reel WHERE model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";
                    string querydeleteResult = "DELETE FROM tbl_resultcompare WHERE model_No = '" + modelslctd + "' AND process_Name = '" + processslctd + "'";

                    conn.Open();                    

                    string[] allQuery = { querydeleteLL, querydeleteLLDetail, querydeletePartCode, querydeleteReel, querydeleteResult };
                    for (int j = 0; j < allQuery.Length; j++)
                    {
                        cmd.CommandText = allQuery[j];
                        //Masukkan perintah/query yang akan dijalankan ke dalam CommandText
                        cmd.ExecuteNonQuery();
                        //Jalankan perintah / query dalam CommandText pada database
                    }

                    conn.Close();
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
