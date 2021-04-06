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
    public partial class DetailLL : Form
    {
        public DetailLL()
        {
            InitializeComponent();
        }

        private void DetailLL_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LoadingList ll = new LoadingList();
            ll.Show();
            this.Hide();
        }
    }
}
