using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class DetailWO : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");

        public DetailWO()
        {
            InitializeComponent();
        }

        private void DetailWO_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            connection.Open();

            string query = "SELECT tbl_wo.model, tbl_wodetail.partcode, tbl_wo.model_No, tbl_wodetail.qty, tbl_wodetail.issue, " +
                "tbl_wo.wo_No, tbl_wodetail.bom_Row, tbl_wo.process_Name, tbl_wo.wo_ptsn , tbl_wo.wo_Usage FROM tbl_wodetail, " +
                "tbl_wo WHERE tbl_wo.model_No = tbl_wodetail.model_No AND tbl_wodetail.model_No = '" + modelNo.Text + "' AND " +
                "tbl_wodetail.process_Name = '" + process.Text + "'";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
            {
                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridViewWoList.DataSource = dset.Tables[0];
            }
            connection.Close();

            // Set table title Wo
            string[] titleWO = { "Model", "Part No", "Model No", "Usage", "Issue", "WO No", "BOM Row", "Process","WO PTSN", "WO Qty"};
            for (int i = 0; i < titleWO.Length; i++)
            {
                dataGridViewWoList.Columns[i].HeaderText = "" + titleWO[i];
            }

            totalPart.Text = dataGridViewWoList.Rows.Count.ToString();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            WorkOrder wo = new WorkOrder();
            wo.Show();
            this.Hide();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }
    }
}
