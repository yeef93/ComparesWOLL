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
            if (e.ColumnIndex == 9)
            {
                DetailLL dll = new DetailLL();
                string modelNo = dataGridViewLLList.Rows[e.RowIndex].Cells[0].Value.ToString();
                string processName = dataGridViewLLList.Rows[e.RowIndex].Cells[1].Value.ToString();
                string model = dataGridViewLLList.Rows[e.RowIndex].Cells[2].Value.ToString();
                string machine = dataGridViewLLList.Rows[e.RowIndex].Cells[3].Value.ToString();
                string pwbType = dataGridViewLLList.Rows[e.RowIndex].Cells[4].Value.ToString();
                string progNo = dataGridViewLLList.Rows[e.RowIndex].Cells[5].Value.ToString();
                string rev = dataGridViewLLList.Rows[e.RowIndex].Cells[6].Value.ToString();
                string pcbNo = dataGridViewLLList.Rows[e.RowIndex].Cells[7].Value.ToString();
                

                dll.tbModelNo.Text = modelNo;
                dll.tbProcess.Text = processName;
                dll.tbModel.Text = model;
                dll.tbMachine.Text = machine;
                dll.tbPWBType.Text = pwbType;
                dll.tbProg.Text = progNo;
                dll.tbRev.Text = rev;
                dll.tbPcbNo.Text = pcbNo;

                dll.Show();
                this.Hide();
                //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
            }
        }
    }
}
