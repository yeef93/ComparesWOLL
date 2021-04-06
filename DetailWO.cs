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
    public partial class DetailWO : Form
    {
        public DetailWO()
        {
            InitializeComponent();
        }

        private void DetailWO_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            WorkOrder wo = new WorkOrder();
            wo.Show();
            this.Hide();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }
    }
}
