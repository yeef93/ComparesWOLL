using System;
using System.Windows.Forms;

namespace CompareWOLL
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void compareWOWithLLToolStripMenuItem_Click(object sender, EventArgs e)
        {

            addWO addWO = new addWO();
            addWO.Show();
            this.Hide();
        }

        private void compareWOVsLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportLLWOForm f2 = new ImportLLWOForm();
            f2.Show();
            this.Hide();
        }
    }
}
