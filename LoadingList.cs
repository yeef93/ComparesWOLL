using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                // add button detail in datagridview table
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridViewLLList.Columns.Add(btn);
                btn.HeaderText = "";
                btn.Text = "Detail";
                btn.Name = "btnDetail";
                btn.UseColumnTextForButtonValue = true;

            }
            connection.Close();

            // Set table title Wo
            string[] titleWO = { "MODEL NO","PROCESS NAME", "MODEL DETAIL",  "MACHINE", "PWB TYPE", "PROG NO", "REV", "PCB NO", "PART COUNT" };
            for (int i = 0; i < titleWO.Length; i++)
            {
                dataGridViewLLList.Columns[i].HeaderText = "" + titleWO[i];
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
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

        }
    }
}
