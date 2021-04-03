﻿using MySql.Data.MySqlClient;
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
    public partial class CompareWOLL : Form
    {
        public CompareWOLL()
        {
            InitializeComponent();
        }

        private void CompareWOLL_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            cmbLLModelNo.Enabled = false;
            btnCompare.Enabled = false;

            MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
            connection.Open();

            string queryModelWO = "SELECT model_No FROM tbl_model";
            string queryModelLL = "SELECT model_No FROM tbl_ll";

            try
            {
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryModelWO, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    cmbWOModelNo.DataSource = dset;
                    cmbWOModelNo.ValueMember = "model_No";
                    cmbWOModelNo.DisplayMember = "model_No";

                }

                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryModelLL, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    cmbLLModelNo.DataSource = dset;
                    cmbLLModelNo.ValueMember = "model_No";
                    cmbLLModelNo.DisplayMember = "model_No";

                }


                connection.Close();

            }
            catch (Exception ex)
            {
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }


        }
        private void cmbWOModelNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
            connection.Open();

            string query = "SELECT process_Name FROM tbl_wodetail WHERE model_No = '" + cmbWOModelNo.SelectedValue.ToString() + "' GROUP BY process_Name ";
            try
            {
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    cmbWOProcess.DataSource = dset;
                    cmbWOProcess.ValueMember = "process_Name";
                    cmbWOProcess.DisplayMember = "process_Name";

                }
                connection.Close();

            }
            catch (Exception ex)
            {
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
            connection.Open();

            string query = "SELECT process_Name FROM tbl_ll WHERE model_No = '" + cmbLLModelNo.SelectedValue.ToString() + "'";
            try
            {
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    cmbLLProcess.DataSource = dset;
                    cmbLLProcess.ValueMember = "process_Name";
                    cmbLLProcess.DisplayMember = "process_Name";

                }
                connection.Close();

            }
            catch (Exception ex)
            {
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbWOProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLLModelNo.Enabled = true;
        }

        private void cmbLLProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCompare.Enabled = true;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;database=pe;user=root;password=;");
            connection.Open();

            string queryWO = "SELECT SUM(qty) AS totalLL FROM tbl_wodetail WHERE model_No = '" + cmbWOModelNo.SelectedValue.ToString() + "' AND process_Name = '" + cmbWOProcess.SelectedValue.ToString() + "'";
            string queryLL = "SELECT part_Count FROM tbl_ll WHERE model_No = '" + cmbLLModelNo.SelectedValue.ToString() + "' AND process_Name = '" + cmbLLProcess.SelectedValue.ToString() + "'";


            try
            {
                //nampilin qty Wo
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryWO, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    if (dset.Rows.Count > 0)
                    {
                        woQty.Text = dset.Rows[0]["totalLL"].ToString();
                    }

                }

                //nampilin qty LL
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(queryLL, connection))
                {
                    DataTable dset = new DataTable();
                    adpt.Fill(dset);

                    if (dset.Rows.Count > 0)
                    {
                        llQty.Text = dset.Rows[0]["part_Count"].ToString();
                    }

                }


                connection.Close();

                if (woQty.Text == llQty.Text)
                {
                    compareQty.BackColor = System.Drawing.Color.Blue;
                    compareQty.Text = "Match";
                }

                else if (woQty.Text != llQty.Text)
                {
                    compareQty.Text = "Not Match";
                    compareQty.BackColor = System.Drawing.Color.Red;
                }

            }
            catch (Exception ex)
            {
                // tampilkan pesan error
                MessageBox.Show(ex.Message);
            }
        }
    }
}
