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
                        
        }

        private void compareWOVsLLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void workOrderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WorkOrder wo = new WorkOrder();
            wo.Show();
            this.Hide();
        }

        private void loadingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadingList LL = new LoadingList();
            LL.Show();
            this.Hide();
        }
    }
}
