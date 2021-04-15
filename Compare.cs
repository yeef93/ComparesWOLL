using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class Compare : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
        ExcelConvert excelConvert = new ExcelConvert();

        public Compare()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void btnWO_Click(object sender, EventArgs e)
        {
            WorkOrder wo = new WorkOrder();
            wo.Show();
            this.Hide();
        }

        private void Compare_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            cmbLLModel.Enabled = false;
            btnCompare.Enabled = false;
            btnGenerate.Enabled = false;

            groupBox4.Visible = false;

            connection.Open();

            string queryWODropDown = "SELECT model_No, process_Name FROM tbl_wo";

            try
            {

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryWODropDown, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    for (int i = 0; i < dset.Rows.Count; i++)
                    {
                        cmbWOModel.Items.Add(dset.Rows[i][0] + " | " + dset.Rows[i][1]);
                        cmbWOModel.ValueMember = dset.Rows[i][1].ToString();

                    }
                }

                connection.Close();

            }
            catch (Exception ex)
            {
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbWOModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLLModel.ResetText();
            cmbLLModel.Enabled = true;
            tbModel.Text = "";
            tbMachine.Text = "";
            tbPWBType.Text = "";
            tbProgNo.Text = "";
            tbStencil.Text = "";
            tbPCB.Text = "";
            woQty.Text = "";
            llQty.Text = "";
            compareQty.Text = "";
            compareQty.BackColor = SystemColors.Control;
            while (dataGridViewCompareLLWO.Rows.Count > 0)
            {
                dataGridViewCompareLLWO.Rows.RemoveAt(0);
            }

            cmbLLModel.Items.Clear();

            // to split model and process
            string str = cmbWOModel.Text;
            char ch = '|';

            var model = str.Split(ch);

            connection.Open();

            string queryLLDropDown = "SELECT model_No, process_Name FROM tbl_ll WHERE model_No = '" + model[0].Replace(" ", "") + "' AND process_Name = '" + model[1].Replace(" ", "") + "' ";

            try
            {

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryLLDropDown, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    if (dset.Rows.Count > 0)
                    {
                        for (int i = 0; i < dset.Rows.Count; i++)
                        {
                            cmbLLModel.Items.Add(dset.Rows[i][0] + " | " + dset.Rows[i][1]);
                            cmbLLModel.ValueMember = dset.Rows[i][1].ToString();

                        }
                    }
                    else
                    {
                        string message = "No any Loading List for selected Work Order, Do you want to upload Loading List File?";
                        string title = "Confirmation Upload Loading List ";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.Yes)
                        {
                            ImportLL ill = new ImportLL();
                            ill.tbModelNo.Text = model[0].Replace(" ", "");
                            ill.tbProcess.Text = model[1].Replace(" ", "");
                            ill.Show();
                            this.Hide();
                        }
                    }
                }

                connection.Close();

            }
            catch (Exception ex)
            {
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbLLModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCompare.Enabled = true;
        }
    }
}
