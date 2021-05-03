using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
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

            string query = "SELECT tbl_wo.model, tbl_wodetail.partcode, tbl_wo.model_No, tbl_wodetail.qty, " +
                "tbl_wodetail.issue, tbl_wo.wo_No, tbl_wodetail.bom_Row, tbl_wodetail.process_Name, tbl_wo.wo_ptsn , " +
                "tbl_wo.wo_Usage FROM tbl_wodetail, tbl_wo WHERE tbl_wo.wo_PTSN = tbl_wodetail.wo_PTSN " +
                "AND tbl_wodetail.wo_PTSN = '" + tbwoPTSN.Text + "'";

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

            //show total qty component
            int sum = 0;
            for (int i = 0; i < dataGridViewWoList.Rows.Count; ++i)
            {
                //get total qty component
                sum += Convert.ToInt32(dataGridViewWoList.Rows[i].Cells[3].Value);

                DataGridViewCellStyle styleOk = new DataGridViewCellStyle();
                styleOk.BackColor = Color.Green;
                styleOk.ForeColor = Color.White;

                DataGridViewCellStyle styleError = new DataGridViewCellStyle();
                styleError.BackColor = Color.Red;
                styleError.ForeColor = Color.White;

                int woQtyy = Convert.ToInt32(dataGridViewWoList.Rows[i].Cells[3].Value);
                int usagge = Convert.ToInt32(dataGridViewWoList.Rows[i].Cells[9].Value);
                int totalissue = woQtyy * usagge;


                if (Convert.ToInt32(dataGridViewWoList.Rows[i].Cells[4].Value) !=
                    totalissue)
                {
                    totalPart.Text = "#Erorr";
                    totalPart.BackColor = System.Drawing.Color.Red;

                    totalUsage.Text = "#Erorr";
                    totalUsage.BackColor = System.Drawing.Color.Red;

                    this.woQty.Text = "#Erorr";
                    this.woQty.BackColor = System.Drawing.Color.Red;

                    dataGridViewWoList.Rows[i].DefaultCellStyle = styleError;
                }
                if (totalPart.Text == "#Erorr" || totalUsage.Text == "#Erorr" || this.woQty.Text == "#Erorr")
                {
                    saveButton.Enabled = false;
                }
                else
                {
                    saveButton.Enabled = true;
                }
            }

            totalUsage.Text = sum.ToString();

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
