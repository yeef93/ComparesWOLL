using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class DetailPO : Form
    {
        MySqlConnection connection = new MySqlConnection("server=192.168.1.1;database=pedev;user=root;password=12345;");

        public DetailPO()
        {
            InitializeComponent();
        }

        private void DetailPO_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            connection.Open();

            string query = "SELECT tbl_wo.wo_ptsn ,tbl_wo.model, tbl_wodetail.partcode, tbl_wodetail.partname, " +
                "tbl_wodetail.qty, tbl_wodetail.issue FROM tbl_wodetail, tbl_wo WHERE " +
                "tbl_wo.wo_PTSN = tbl_wodetail.wo_PTSN AND tbl_wodetail.wo_PTSN = '" + tbPoNo.Text + "'";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
            {
                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridViewPO.DataSource = dset.Tables[0];
            }
            connection.Close();

            // Set table title Wo
            string[] titleWO = { "PO NUMBER", "MODEL", "PART NO", "PART NAME", "U/Q", "USAGE QTY" };
            for (int i = 0; i < titleWO.Length; i++)
            {
                dataGridViewPO.Columns[i].HeaderText = "" + titleWO[i];
            }

            tbtotalPart.Text = dataGridViewPO.Rows.Count.ToString();

            //show total qty component
            int sum = 0;
            for (int i = 0; i < dataGridViewPO.Rows.Count; ++i)
            {
                //get total qty component
                sum += Convert.ToInt32(dataGridViewPO.Rows[i].Cells[3].Value);

                DataGridViewCellStyle styleOk = new DataGridViewCellStyle();
                styleOk.BackColor = Color.Green;
                styleOk.ForeColor = Color.White;

                DataGridViewCellStyle styleError = new DataGridViewCellStyle();
                styleError.BackColor = Color.Red;
                styleError.ForeColor = Color.White;

                int woQtyy = Convert.ToInt32(dataGridViewPO.Rows[i].Cells[3].Value);
                int usagge = Convert.ToInt32(dataGridViewPO.Rows[i].Cells[9].Value);
                int totalissue = woQtyy * usagge;

            }

            tbtotalUsage.Text = sum.ToString();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            PurchaseOrder po = new PurchaseOrder();
            po.Show();
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
