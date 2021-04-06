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

            string query = "SELECT wo_PTSN, wo_No, model_No, model, process_Name ,wo_QTY, wo_Usage FROM tbl_wo";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
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


                // add button import in datagridview table
                DataGridViewButtonColumn btnImport = new DataGridViewButtonColumn();
                dataGridViewWoList.Columns.Add(btnImport);
                btnImport.HeaderText = "";
                btnImport.Text = "Import Loading List";
                btnImport.Name = "btnImport";
                btnImport.UseColumnTextForButtonValue = true;

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
            iWO.Show();
            this.Hide();
        }

        private void workOrderToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void compareWOVsLLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void dataGridViewWoList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
                ImportLL il = new ImportLL();
                string model = dataGridViewWoList.Rows[e.RowIndex].Cells[2].Value.ToString();
                string processName = dataGridViewWoList.Rows[e.RowIndex].Cells[5].Value.ToString();
                il.Show();
                il.tbModelNo.Text = model;
                il.tbProcess.Text = processName;
                this.Hide();

                //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked "+model+"");
            }
        }
    }
}
