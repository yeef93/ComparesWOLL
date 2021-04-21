using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class DetailLL : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
        public DetailLL()
        {
            InitializeComponent();
        }

        private void DetailLL_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            string query = "SELECT tbl_reel.reel, tbl_partcodedetail.partcode, tbl_partcodedetail.tp,  tbl_reel.qty, tbl_reel.loc, tbl_partcodedetail.dec, tbl_reel.f_Type " +
                "FROM tbl_partcodedetail, tbl_reel WHERE tbl_partcodedetail.reel = tbl_reel.reel AND tbl_partcodedetail.process_Name = tbl_reel.process_Name " +
                "AND tbl_partcodedetail.model_No = '" + tbModelNo.Text + "' AND tbl_partcodedetail.process_Name = '" + tbProcess.Text + "'";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
            {
                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridViewLL.DataSource = dset.Tables[0];
            }
            connection.Close();

            // Set table title Wo
            string[] titleWO = { "REEL", "PART CODE", "TP", "QTY", "LOC", "DEC", "F.TYPE"};
            for (int i = 0; i < titleWO.Length; i++)
            {
                dataGridViewLL.Columns[i].HeaderText = "" + titleWO[i];
            }

            int sum = 0;
            int totalPartCode = 0;
            for (int i = 0; i < dataGridViewLL.Rows.Count; ++i)
            {
                //show total qty component
                if (dataGridViewLL.Rows[i].Cells[3].Value == System.DBNull.Value)
                {
                    dataGridViewLL.Rows[i].Cells[3].Value = "0";
                }

                if (dataGridViewLL.Rows[i].Cells[1].Value.ToString() != "")
                {
                    totalPartCode++;
                }
                //get total qty component
                sum += Convert.ToInt32(dataGridViewLL.Rows[i].Cells[3].Value);

            }
            sum = sum;

            totalPoint.Text = sum.ToString();
            totalPart.Text = totalPartCode.ToString();


        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LoadingList ll = new LoadingList();
            ll.Show();
            this.Hide();
        }
    }
}
