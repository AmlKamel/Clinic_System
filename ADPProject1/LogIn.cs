using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ADPProject1
{
    public partial class LogIn : Form
    {
        MySqlConnection connection = new MySqlConnection(@"server=localhost;user=root;database=Clinic;password=root;port=3310;charset=utf8;");
        MySqlCommand cmd;
         enum Type { Admin, Register,Analysis_Doctor, Rays_Doctor };
         int userID;
        string userType;
        public LogIn()
        {
            InitializeComponent();
            label6.Hide();
            //MessageBox.Show();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            label5.Text = "";
            label6.Hide();
            if (txtPass.Text == "" || txtEmail.Text == "")
            {
                if (txtEmail.Text == "") label4.Text = "*";
                if (txtPass.Text == "") label5.Text = "*";
            }
            else
            {
                connection.Open();
                cmd = new MySqlCommand("select U_id,U_type from user where Email='" + txtEmail.Text + "' and Pass='" + txtPass.Text + "';",connection);
                MySqlDataReader dr= cmd.ExecuteReader();
                if (dr.Read())
                {
                    userID =Int32.Parse( dr[0].ToString());
                    userType = dr[1].ToString();
                    Main m = new Main(userID,userType, this);
                    m.Location = this.Location;
                    this.Hide();
                    m.Show();
                }
                else  label6.Show();
                connection.Close();
            }
        }
    }
}
