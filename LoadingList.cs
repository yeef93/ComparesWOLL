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

            string query = "SELECT model_No, pwb_Type, pcb_No, part_Count FROM tbl_ll";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
            {
                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridViewWoList.DataSource = dset.Tables[0];
            }
            connection.Close();

            // Set table title Wo
            string[] titleWO = { "MODEL NO", "PWB TYPE", "PCB NO", "PART COUNT" };
            for (int i = 0; i < titleWO.Length; i++)
            {
                dataGridViewWoList.Columns[i].HeaderText = "" + titleWO[i];
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
            importLL ill = new importLL();
            ill.Show();
            this.Hide();
        }
    }
}
