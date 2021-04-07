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
    public partial class Login : Form
    {

        ConnectionDB con = new ConnectionDB();
        Helper help = new Helper();
        string id, username, password, name, role;

        public Login()
        {
            InitializeComponent();
            Helper help = new Helper();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            dateTimeNow.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string passwords = help.encryption(txtPassword.Text);
            try
            {
                if (txtUsername.Text != "" && txtPassword.Text != "")
                {

                    con.Open();
                    string query = "SELECT id,username,pass,NAME,ROLE FROM tbl_user WHERE username = '" + txtUsername.Text + "' AND pass = '" + passwords + "'";
                    MySqlDataReader row;
                    row = con.ExecuteReader(query);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            id = row["id"].ToString();
                            username = row["username"].ToString();
                            password = row["pass"].ToString();
                            name = row["name"].ToString();
                            role = row["role"].ToString();
                        }

                        MainMenu mm = new MainMenu();

                        mm.toolStripUsername.Text = "Welcome "+name +", "+role+" |";
                        mm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Data not found", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Fill Username and Password field to Login", "Information");
                }
            }
            catch
            {
                MessageBox.Show("Connection Error", "Information");
            }
        }
    }
}
