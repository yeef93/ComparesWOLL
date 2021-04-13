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

        private void compareWOVsLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompareWOLL cwl = new CompareWOLL();
            cwl.toolStripUsername.Text = toolStripUsername.Text;
            cwl.Show();
            this.Hide();
        }

        private void workOrderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WorkOrder wo = new WorkOrder();
            wo.toolStripUsername.Text = toolStripUsername.Text;
            wo.Show();
            this.Hide();
        }

        private void loadingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadingList LL = new LoadingList();
            LL.toolStripUsername.Text = toolStripUsername.Text;
            LL.Show();
            this.Hide();
        }

    }
}
