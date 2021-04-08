using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class DetailWO : Form
    {
        public DetailWO()
        {
            InitializeComponent();
        }

        private void DetailWO_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;


            MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
            connection.Open();

            string query = "SELECT tbl_wodetail.partcode, tbl_wodetail.qty FROM tbl_wodetail WHERE tbl_wodetail.model_No = '"+modelNo.Text+ "' AND tbl_wodetail.process_Name ='" + process.Text + "'";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
            {
                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridViewWoList.DataSource = dset.Tables[0];
            }
            connection.Close();

            // Set table title Wo
            string[] titleWO = { "PART CODE", "QTY" };
            for (int i = 0; i < titleWO.Length; i++)
            {
                dataGridViewWoList.Columns[i].HeaderText = "" + titleWO[i];
            }
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
