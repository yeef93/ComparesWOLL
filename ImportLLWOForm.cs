using System;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class ImportLLWOForm : Form
    {
        public static string woFilePath = "";
        public static string smtaFilePath = "";
        public static string smtbFilePath = "";

        public ImportLLWOForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            labelSMTA.Hide();
            textBoxSMTA.Hide();
            browseSMTA.Hide();
            labelSMTB.Hide();
            textBoxSMTB.Hide();
            browseSMTB.Hide();
            uploadFileList.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem.ToString() == "1 Side")
            {
                labelSMTA.Show();
                textBoxSMTA.Show();
                browseSMTA.Show();
                labelSMTB.Hide();
                textBoxSMTB.Hide();
                browseSMTB.Hide();
            }

            else if (comboBox1.SelectedItem.ToString() == "2 Side")
            {
                labelSMTA.Show();
                textBoxSMTA.Show();
                browseSMTA.Show();
                labelSMTB.Show();
                textBoxSMTB.Show();
                browseSMTB.Show();
            }
        }

        private void browseWO_Click(object sender, EventArgs e)
        {
            openFileDialogWO.Title = "Please Select a File Work Order";
            //openFileDialogWO.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm| CSV files (*.csv)|*.csv";
            openFileDialogWO.Filter = "Excel Files|*.xls;*.xlsx;";
            openFileDialogWO.InitialDirectory = @"C:\";
            openFileDialogWO.ShowDialog();
            string woFileName = openFileDialogWO.FileName;
            textBoxWO.Text = woFileName;
        }

        private void browseSMTA_Click(object sender, EventArgs e)
        {
            openFileDialogSMTA.Title = "Please Select a File SMT-A";
            openFileDialogSMTA.Filter = "Excel Files|*.xls;*.xlsx;";
            openFileDialogSMTA.InitialDirectory = @"C:\";
            openFileDialogSMTA.ShowDialog();
            string smtaFileName = openFileDialogSMTA.FileName;
            textBoxSMTA.Text = smtaFileName;

            if (comboBox1.SelectedItem.ToString() == "1 Side")
            {
                uploadFileList.Enabled = true;
            }
        }

        private void browseSMTB_Click(object sender, EventArgs e)
        {
            openFileDialogSMTB.Title = "Please Select a File SMT-B";
            openFileDialogSMTB.Filter = "Excel Files|*.xls;*.xlsx;";
            openFileDialogSMTB.InitialDirectory = @"C:\";
            openFileDialogSMTB.ShowDialog();
            string smtbFileName = openFileDialogSMTB.FileName;
            textBoxSMTB.Text = smtbFileName;

            if (comboBox1.SelectedItem.ToString() == "2 Side" | smtbFileName != "")
            {
                uploadFileList.Enabled = true;
            }
        }

        private void uploadFileList_Click_1(object sender, EventArgs e)
        {
            woFilePath = textBoxWO.Text;
            smtaFilePath = textBoxSMTA.Text;
            smtbFilePath = textBoxSMTB.Text;

            CompareForm f3 = new CompareForm();
            f3.Show();
            this.Hide();
        }

        private void textBoxWO_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
