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
    public partial class DoctorData : Form
    {
        Main main;
        //loged user type
        string userType;
        //user his personal info shown
        int ID;
        string state = "";
        //loged user
        int LogedUserID;
        MySqlConnection connection = new MySqlConnection(@"server=localhost;user=root;database=Clinic;password=root;port=3310;charset=utf8;");
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt = new DataTable();
        public DoctorData(int id,Main m)
        {
            InitializeComponent();
            main = m;
            ID = id;
            LogedUserID = id;
            btnCancelPersonalInfo.Hide();
            btnSavePersonalInfo.Hide();
            getPersonalDataFromDataBase(LogedUserID);
            // get loged user email and name 
            lblEmail.Text = txtEmail.Text;
            lblName.Text = txtName.Text;
            userType = compType.Text;
            if (userType != "Admin")
                btnDoctors.Enabled = false;
            unenableTexts();
            infoPanel.Show();
            panel1.Hide();

            cancel.Hide();
            unenableDoctorTexts();
            search.Enabled = false;
            btnSave.Enabled = false;
        }
        private void DoctorData_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }
        private void home_Click(object sender, EventArgs e)
        {
            main.Show();
            this.Close();
        }
        /// /for pesonal data panel
        private void lblEmail_Click(object sender, EventArgs e)
        {
            infoPanel.Show();
            panel1.Hide();
            getPersonalDataFromDataBase(LogedUserID);
        }
        private void lblEmail_MouseHover(object sender, EventArgs e)
        {
            lblEmail.ForeColor = Color.Blue;
        }
        private void lblEmail_MouseLeave(object sender, EventArgs e)
        {
            lblEmail.ForeColor = Color.FromArgb(1, 0, 192, 192);
        }
        void enableTexts()
        {
            if (!txtAddress.Enabled) txtAddress.Enabled = true;
            if (!txtAge.Enabled) txtAge.Enabled = true;
            if (!txtEmail.Enabled) txtEmail.Enabled = true;
            if (!txtName.Enabled) txtName.Enabled = true;
            if (!txtPass.Enabled) txtPass.Enabled = true;
            if (!txtPhone.Enabled) txtPhone.Enabled = true;
            if (userType == "Admin")
                compType.Enabled = true;
        }
        void unenableTexts()
        {
            if (txtAddress.Enabled) txtAddress.Enabled = false;
            if (txtAge.Enabled) txtAge.Enabled = false;
            if (txtEmail.Enabled) txtEmail.Enabled = false;
            if (txtName.Enabled) txtName.Enabled = false;
            if (txtPass.Enabled) txtPass.Enabled = false;
            if (txtPhone.Enabled) txtPhone.Enabled = false;
            if (compType.Enabled) compType.Enabled = false;
        }
        void emptyTexts()
        {
            txtAddress.Text = "";
            txtAge.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtPass.Text = "";
            txtPhone.Text = "";
            compType.SelectedIndex = -1;
        }
        void getPersonalDataFromDataBase(int id)
        {
            connection.Open();
            cmd = new MySqlCommand("select * from user where U_id=" + id + ";", connection);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string current_user_type = "";
                ID = id;
                txtName.Text = dr[1].ToString();
                current_user_type = dr[2].ToString();
                if (current_user_type == "Admin")
                    compType.SelectedIndex = 0;
                else if (current_user_type == "Rays_Doctor")
                    compType.SelectedIndex = 1;
                else if (current_user_type == "Analysis_Doctor")
                    compType.SelectedIndex = 2;
                else if (current_user_type == "Examination_Doctor")
                    compType.SelectedIndex = 3;
                else if (current_user_type == "Register")
                    compType.SelectedIndex = 4;
                // MessageBox.Show(current_user_type);
                txtPass.Text = dr[3].ToString();
                txtEmail.Text = dr[4].ToString();
                txtPhone.Text = dr[5].ToString();
                txtAddress.Text = dr[6].ToString();
                txtAge.Text = dr[7].ToString();
                connection.Close();
            }
        }
        private void btnSavePersonalInfo_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text == "" || txtAge.Text == "" || txtEmail.Text == "" || txtName.Text == "" || txtPass.Text == "" || txtPhone.Text == "")
                MessageBox.Show("Fill REquired data");
            else
            {
                try
                {
                    int age = Int32.Parse(txtAge.Text);
                    int phone = Int32.Parse(txtPhone.Text);
                    connection.Open();
                    cmd = new MySqlCommand("update user set U_name='" + txtName.Text + "',U_type='" + compType.Text + "',Pass='" + txtPass.Text + "',Email='" + txtEmail.Text + "',Phone=" + phone + ",Address='" + txtAddress.Text + "',age=" + age + " where U_ID=" + ID + ";", connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    btnSavePersonalInfo.Hide();
                    btnCancelPersonalInfo.Hide();
                    btnEditPersonalInfo.Show();
                    unenableTexts();
                }

                catch
                {
                    MessageBox.Show("unvalid data for age or phone");
                }
            }
        }
        private void btnEditPersonalInfo_Click(object sender, EventArgs e)
        {
            enableTexts();
            btnSavePersonalInfo.Show();
            btnEditPersonalInfo.Hide();
            btnCancelPersonalInfo.Show();
        }
        private void btnCancelPersonalInfo_Click(object sender, EventArgs e)
        {
            getPersonalDataFromDataBase(ID);
            unenableTexts();
            btnSavePersonalInfo.Hide();
            btnEditPersonalInfo.Show();
            btnCancelPersonalInfo.Hide();
        }
        // doctors panel data
        private void btnDoctors_Click(object sender, EventArgs e)
        {
            panel1.Show();
            da = new MySqlDataAdapter("select U_name,Email from user;", connection);
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            emptyDoctorTexts();
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            cancel.Show();
            enableDoctorTexts();
            state = "add";
        }

        void enableDoctorTexts()
        {
            if (!txtdoctorAddress.Enabled) txtdoctorAddress.Enabled = true;
            if (!txtdoctorID.Enabled) txtdoctorID.Enabled = true;
            if (!txtdoctorAge.Enabled) txtdoctorAge.Enabled = true;
            if (!txtdoctorEmail.Enabled) txtdoctorEmail.Enabled = true;
            if (!txtdoctorName.Enabled) txtdoctorName.Enabled = true;
            if (!txtdoctorPass.Enabled) txtdoctorPass.Enabled = true;
            if (!txtdoctorPhone.Enabled) txtdoctorPhone.Enabled = true;
            comdoctorType.Enabled = true;
        }
        void unenableDoctorTexts()
        {
            if (txtdoctorAddress.Enabled) txtdoctorAddress.Enabled = false;
            if (txtdoctorID.Enabled) txtdoctorID.Enabled = false;
            if (txtdoctorAge.Enabled) txtdoctorAge.Enabled = false;
            if (txtdoctorEmail.Enabled) txtdoctorEmail.Enabled = false;
            if (txtdoctorName.Enabled) txtdoctorName.Enabled = false;
            if (txtdoctorPass.Enabled) txtdoctorPass.Enabled = false;
            if (txtdoctorPhone.Enabled) txtdoctorPhone.Enabled = false;
            if (comdoctorType.Enabled) comdoctorType.Enabled = false;
        }
        void emptyDoctorTexts()
        {
            txtdoctorAddress.Text = "";
            txtdoctorID.Text = "";
            txtdoctorAge.Text = "";
            txtdoctorEmail.Text = "";
            txtdoctorName.Text = "";
            txtdoctorPass.Text = "";
            txtdoctorPhone.Text = "";
            comdoctorType.SelectedIndex = -1;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;         
            unenableDoctorTexts();
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = true;
            cancel.Hide();
            dataGridView1.ClearSelection();
            emptyDoctorTexts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedCells.Count==0)
            {
                string s = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                connection.Open();
                cmd = new MySqlCommand("delete from user where  Email='" + s + "';", connection);
                cmd.ExecuteNonQuery();
                da = new MySqlDataAdapter("select U_name,Email from user;", connection);
                dt.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;           
                dataGridView1.ClearSelection();
                emptyDoctorTexts();
                connection.Close();
            }
            else MessageBox.Show("Select User to be deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkValidDataToInsert())
            {

                if (state == "add")
                {
                        connection.Open();
                        cmd = new MySqlCommand("insert into user values(" + Int32.Parse(txtdoctorID.Text) + ",'" + txtdoctorName.Text + "','" + comdoctorType.Text + "','" + txtdoctorPass.Text + "','" + txtdoctorEmail.Text + "','" + txtdoctorPhone.Text + "','" + txtdoctorAddress.Text + "'," + Int32.Parse(txtdoctorAge.Text) + ")", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();

                }
                else if (state == "edit")
                {
                    connection.Open();
                    cmd = new MySqlCommand("update user set U_name='" + txtdoctorName + "',U_type='" + comdoctorType.Text + "',Pass='" + txtdoctorPass.Text + "',Email='" + txtdoctorEmail.Text + "',Phone='" + txtdoctorPhone.Text + "',Address='" + txtdoctorAddress.Text + "',age=" + Int32.Parse(txtdoctorAge.Text) + " where U_ID=" + Int32.Parse(txtdoctorID.Text) + ";", connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                da = new MySqlDataAdapter("select U_name,Email from user;", connection);
                dt.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;               
                cancel.Hide();
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                dataGridView1.ClearSelection();
                emptyDoctorTexts();
            }
            //else
               // MessageBox.Show("invalid data try correct one", "warning",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
        }

        bool checkValidDataToInsert()
        {
            if (txtdoctorID.Text == "" || txtdoctorAddress.Text == "" || txtdoctorAge.Text == "" || txtdoctorEmail.Text == "" || txtdoctorName.Text == "" || txtdoctorPass.Text == "" || txtdoctorPhone.Text == "")

            {
                MessageBox.Show("invalid data try correct one", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            else
            {
                 try
                {
                    Int32.Parse(txtdoctorPhone.Text);
                    Int32.Parse(txtdoctorAge.Text);
                    Int32.Parse(txtdoctorID.Text);
                }
                catch
                {
                    MessageBox.Show("invalid data  ", "warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count==0)

                MessageBox.Show("Select user to be edited");
            else
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                cancel.Show();
                enableDoctorTexts();
                txtdoctorID.Enabled = false;

            }
           

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count!=0)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                else
                {
                    connection.Close();
                    connection.Open();
                }
                string s = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cmd = new MySqlCommand("select * from user where Email='" + s + "';", connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string current_user_type = "";
                    ID = Int32.Parse(dr[0].ToString());
                    txtdoctorID.Text = ID.ToString();
                    txtdoctorName.Text = dr[1].ToString();
                    current_user_type = dr[2].ToString();
                    if (current_user_type == "Admin")
                        comdoctorType.SelectedIndex = 0;
                    else if (current_user_type == "Rays_Doctor")
                        comdoctorType.SelectedIndex = 1;
                    else if (current_user_type == "Analysis_Doctor")
                        comdoctorType.SelectedIndex = 2;
                    else if (current_user_type == "Examination_Doctor")
                        comdoctorType.SelectedIndex = 3;
                    else if (current_user_type == "Register")
                        comdoctorType.SelectedIndex = 4;
                    // MessageBox.Show(current_user_type);
                    txtdoctorPass.Text = dr[3].ToString();
                    txtdoctorEmail.Text = dr[4].ToString();
                    txtdoctorPhone.Text = dr[5].ToString();
                    txtdoctorAddress.Text = dr[6].ToString();
                    txtdoctorAge.Text = dr[7].ToString();

                }
                connection.Close();
            }
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
           // connection.Open();
            if (comSearchType.Text == "") comSearchType.SelectedIndex = 1;
            if (comSearchType.Text == "Type")
            {
                da = new MySqlDataAdapter("select * from user where U_type like '%" + TextBox2.Text + "%'", connection);
                dt.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comSearchType.Text == "Name")
            {
                da = new MySqlDataAdapter("select * from user where U_name like '%" + TextBox2.Text + "%'", connection);
                dt.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comSearchType.Text == "Email")
            {
                da = new MySqlDataAdapter("select * from user where Email like '%" + TextBox2.Text + "%'", connection);
                dt.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
           // connection.Close();
        }
    }
}
