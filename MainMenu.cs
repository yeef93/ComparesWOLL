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

            label1.Visible = false;
            //label1.Text = "Hello,\nHow are you?\nI'm fine!";

        }

        private void compareWOVsLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compare compare = new Compare();
            compare.toolStripUsername.Text = toolStripUsername.Text;
            compare.Show();
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

        private void readLoadingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importExcel importExcel = new importExcel();
            importExcel.Show();
            this.Hide();
        }

        private void importExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importExcel import = new importExcel();
            import.Show();
            this.Hide();

        }
    }
}
