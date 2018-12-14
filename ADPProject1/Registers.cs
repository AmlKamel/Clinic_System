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
    public partial class Registers : Form
    {
        Main main;
        MySqlConnection connection = new MySqlConnection(@"server=localhost;user=root;database=Clinic;password=root;port=3310;charset=utf8;");
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt = new DataTable();
        string state = "";
       
        public Registers(Main m)
        {
            InitializeComponent();
            main = m;
            btnSave.Enabled = false;
            btnCancel.Hide();
            txtPastHistory.Enabled = false;
            da = new MySqlDataAdapter("select P_id,P_name from patient;", connection);
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            unenableTexts();
            groupBox3.Show();
            dateRegister.Value = DateTime.Today.Date;
            dateAdmitt.Value = DateTime.Today.Date;
            //dateAdmitt.Text = "";
            //dateRegister.Enabled = false;
        }

        void enableTexts()
        {
            if (!txtAddress.Enabled) txtAddress.Enabled = true;
            if (!txtAge.Enabled) txtAge.Enabled = true;
            if (!combMaritalStatus.Enabled) combMaritalStatus.Enabled = true;
            if (!txtName.Enabled) txtName.Enabled = true;
            if (!combSex.Enabled) combSex.Enabled = true;
            if (!txtPhone.Enabled) txtPhone.Enabled = true;
            if (!txtID.Enabled) txtID.Enabled = true;
            //if (!dateRegister.Enabled) dateRegister.Enabled = true;
        }
        void unenableTexts()
        {
            if (txtAddress.Enabled) txtAddress.Enabled = false;
            if (txtAge.Enabled) txtAge.Enabled = false;
            if (combMaritalStatus.Enabled) combMaritalStatus.Enabled = false;
            if (txtName.Enabled) txtName.Enabled = false;
            if (combSex.Enabled) combSex.Enabled = false;
            if (txtPhone.Enabled) txtPhone.Enabled = false;
            if (txtID.Enabled) txtID.Enabled = false;
            //if (dateRegister.Enabled) dateRegister.Enabled = false;
        }
        void emptyTexts()
        {
            txtAddress.Text = "";
            txtID.Text = "";
            txtAge.Text = "";
            txtName.Text = "";
            combSex.Text = "";
            txtPhone.Text = "";
            combMaritalStatus.SelectedIndex = -1;
            dateRegister.Text = "";
            //dateAdmitt.Value=DateTime.Today
            txtPastHistory.Text = "";
            txtComplaint.Text = "";
            txtfamilyhistory.Text = "";
            txtHistoryPres.Text = "";
            txtMHistory.Text = "";
             
        }
        bool checkValidDataToInsert()
        {
            if (txtID.Text == "" || txtAddress.Text == "" || txtAge.Text == "" || combSex.Text == "" || txtName.Text == "" || combMaritalStatus.Text == "" || txtPhone.Text == ""||dateRegister.Text==""||txtPhone.Text.Length!=11)
                return false;
            else
            {
                try
                {
                   // Int32.Parse(txtPhone.Text);
                    Int32.Parse(txtAge.Text);
                    Int32.Parse(txtID.Text);
                    DateTime t = dateRegister.Value;
                }
                catch
                { return false;
                }
            }
            return true;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Registers_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            da = new MySqlDataAdapter("select P_id,P_name from patient where P_name like '%" + txtSearch.Text + "%'", connection);
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            //groupAdmittion.Hide();
            btnCancel.Show();
            btnSave.Enabled = true;
            btnAddNewPatient.Enabled = false;
            enableTexts();
            state = "add";
            dataGridView1.ClearSelection();
            emptyTexts();
            dataGridView1.Enabled = false;
            dateRegister.Value = DateTime.Today.Date;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //groupAdmittion.Show();
            btnCancel.Hide();
            btnSave.Enabled = false;
            btnAddNewPatient.Enabled = true;
            unenableTexts();
            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(checkValidDataToInsert()||state=="admit")
            {

                if (state == "add")
                {
                    connection.Open();
                    string date = string.Format("{0}-{1}-{2}", DateTime.Today.Date.Year.ToString(), DateTime.Today.Month.ToString(), DateTime.Today.Date.Day.ToString());
                    cmd = new MySqlCommand("insert into patient values(" + Int32.Parse(txtID.Text) + ",'" + txtName.Text + "'," + Int32.Parse(txtAge.Text)+",'"+ txtAddress.Text+"','"+ txtPhone.Text+"','"+ combSex.Text+"','"+ combMaritalStatus.Text + "','"+date+"');", connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    da = new MySqlDataAdapter("select P_id,P_name from patient;", connection);
                    dt.Clear();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
                else if (state == "admit")
                {
                    if (dateAdmitt.Text == "" || txtComplaint.Text == "" || txtfamilyhistory.Text == "" || txtHistoryPres.Text == ""||txtMHistory.Text=="")
                    {
                        MessageBox.Show("Fill Required data ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        connection.Open();
                        int id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        string date = string.Format("{0}-{1}-{2}", DateTime.Today.Date.Year.ToString(), DateTime.Today.Month.ToString(), DateTime.Today.Date.Day.ToString());
                        cmd = new MySqlCommand("insert into admittion(A_date, A_P_id, A_complaint, A_family_history,A_presentIllness_history,A_medical_history,A_examined)values('" + date + "'," + id + ", '" + txtComplaint.Text + "','"+txtfamilyhistory.Text+"','"+txtHistoryPres.Text+"','"+txtMHistory.Text+"',false);", connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        btnAdmit.Hide();
                        groupBox3.Show();
                        MessageBox.Show("Your admittion added correctly");
                    }
                }
               
                btnCancel.Hide();
                btnAddNewPatient.Enabled = true;
                btnSave.Enabled = false;
                dataGridView1.ClearSelection();
                emptyTexts();
                unenableTexts();
                dataGridView1.Enabled = true;
            }
            else
                    MessageBox.Show("invalid data ","warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0 && dataGridView1.CurrentRow.Cells[0].Value.ToString() != "")
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
                string s = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cmd = new MySqlCommand("select * from patient where P_id=" + s + ";", connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtID.Text = dr[0].ToString();
                    txtName.Text = dr[1].ToString();
                    txtAge.Text = dr[2].ToString();
                    txtAddress.Text = dr[3].ToString();
                    txtPhone.Text = dr[4].ToString();
                    combSex.Text = dr[5].ToString();
                    combMaritalStatus.Text = dr[6].ToString();
                    dateRegister.Text = dr[7].ToString();
                }
                connection.Close();
                connection.Open();
                txtPastHistory.Text = "Date                      Complaint \r\n";
                cmd = new MySqlCommand("select A_date,A_complaint from admittion where A_P_id=" + s + ";", connection);
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    txtPastHistory.Text += dr[0] + "    " + dr[1]+"\r\n";
                }
                connection.Close();
            }
            else emptyTexts();
            if (dataGridView1.SelectedCells.Count != 0 && !btnSave.Enabled&& dataGridView1.CurrentCell.Value.ToString()!="")
                btnAdmit.Show();
            else btnAdmit.Hide();
        }

        private void btnAdmit_Click(object sender, EventArgs e)
        {
            groupBox3.Hide();
            btnSave.Enabled = true;
            btnAddNewPatient.Enabled = false;
            btnAdmit.Hide();
            state = "admit";
            dataGridView1.Enabled = false;
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            groupBox3.Show();
            btnSave.Enabled = false;
            txtComplaint.Text = "";
            btnAddNewPatient.Enabled = true;
            dataGridView1.Enabled = true;
            dataGridView1.ClearSelection();
            emptyTexts();
        }
    }
}
