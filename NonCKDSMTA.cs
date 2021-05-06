using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class NonCKDSMTA : Form
    {
        MySqlConnection connection = new MySqlConnection("server=192.168.1.1;database=pedev;user=root;password=12345;");

        public NonCKDSMTA()
        {
            InitializeComponent();
        }

        private void NonCKDSMTA_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            string queryDetailSMTA = "SELECT customer, model_detail, machine, pwb_Type, prog_No, stencil FROM tbl_ll WHERE wo_PTSN = '" + tbPoNo.Text + "'";
            string queryResultSMTA = "SELECT tbl_lldetail.reel, tbl_wodetail.partcode, tbl_wodetail.qty, tbl_lldetail.alt_No FROM tbl_wodetail LEFT JOIN " +
                "tbl_lldetail ON tbl_wodetail.partcode = tbl_lldetail.partcode WHERE tbl_lldetail.wo_PTSN = '" + tbPoNo.Text + "' AND tbl_lldetail.process_Name = 'SMT-A' AND tbl_lldetail.reel != 'PCB'";

            try
            {
                connection.Open();
                // nampilin detail LL
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryDetailSMTA, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    if (dset.Rows.Count > 0)
                    {
                        tbCustomer.Text = dset.Rows[0]["customer"].ToString();
                        //tbModel.Text = dset.Rows[0]["model_detail"].ToString().Replace(" (SMT-A)", "");
                        tbModel.Text = dset.Rows[0]["model_detail"].ToString();
                        tbMachine.Text = dset.Rows[0]["machine"].ToString();
                        tbPWBType.Text = dset.Rows[0]["pwb_Type"].ToString();
                        tbProgNo.Text = dset.Rows[0]["prog_No"].ToString();
                        tbStencil.Text = dset.Rows[0]["stencil"].ToString();
                    }
                }

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryResultSMTA, connection))
                {
                    DataSet dset = new DataSet();

                    adpt.Fill(dset);

                    dataGridViewSMTA.DataSource = dset.Tables[0];
                }
                connection.Close();

                // Set table title Wo
                string[] titleWO = { "REEL", "PARTCODE", "QTY", "ALT NO" };
                for (int i = 0; i < titleWO.Length; i++)
                {
                    dataGridViewSMTA.Columns[i].HeaderText = "" + titleWO[i];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
