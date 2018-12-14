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
    public partial class Examination : Form
    {
        Main main;
        MySqlConnection connection = new MySqlConnection(@"server=localhost;user=root;database=Clinic;password=root;port=3310;charset=utf8;");
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt = new DataTable();
        public Examination(Main m)
        {
            InitializeComponent();
            panel1.Hide();
            main = m;
            btnSave.Enabled = false;
            btnCancel.Hide();
            string date = string.Format("{0}-{1}-{2}", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());
            da = new MySqlDataAdapter("select A_id, P_name from patient,admittion where P_id=A_P_id and A_date='"+date+"'and A_examined=false;", connection);
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();

        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkValidDataToInsert() )
            {
                   connection.Open();
                cmd = new MySqlCommand("insert into examination(E_A_id,E_general_lock,E_pulse,E_blood_pressure, E_temprature, E_respiration_rate, E_head_neck, E_chest_examine,E_cardiac_examine, E_Abd_inspection,E_Abd_superficial_palpation, E_Abd_deep_palpation,E_Abd_percussion,E_Abd_ausculation,E_provisional_diagnosis) values(" +
                               dataGridView1.CurrentRow.Cells[0].Value + ",'" + txtGeneralLock.Text + " '," + Int32.Parse(txtPulse.Text) +
                               "," + Int32.Parse(txtBloodPressure.Text) + "," + double.Parse(txtTemperature.Text) + "," + Int32.Parse(txtRespiratoryRate.Text) +
                               ",'" + txtHead.Text + "','" + txtChest.Text + "','" + txtCardiac.Text + "','" + txtInspection.Text + "','" + txtSuperficialPalpation +
                               "','" + txtDeepPalpation.Text + "','" + txtPercussion.Text + "','" + txtAusculation.Text + "','" + txtProvisionalDiagnosis.Text + "');", connection);
                     cmd.ExecuteNonQuery();
                     connection.Close();
                string date = string.Format("{0}-{1}-{2}", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());
                da = new MySqlDataAdapter("select A_id, P_name from patient,admittion where P_id=A_P_id and A_date='" + date + "'and A_examined=false;", connection);
                dt.Clear();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                  btnCancel.Hide();
                  btnSave.Enabled = false;
                dataGridView1.Enabled = true;
                  dataGridView1.ClearSelection();
                  emptyTexts();
                  panel1.Hide();
            }
            else
                MessageBox.Show("invalid data ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            //btnAdmit.Hide();
            btnCancel.Hide();
            txtSearch.Enabled = true;
            btnSave.Enabled = false;
            dataGridView1.Enabled = true;
            dataGridView1.ClearSelection();
            emptyTexts();
        }
        private void btnAdmit_Click(object sender, EventArgs e)
        {
            panel1.Show();
            btnAdmit.Hide();
            btnCancel.Show();
            txtSearch.Enabled = false;
            btnSave.Enabled = true;
            dataGridView1.Enabled = false;
        }
        void emptyTexts()
        {
            txtAusculation.Text = "";
            txtBloodPressure.Text = "";
            txtCardiac.Text = "";
            txtChest.Text = "";
            txtDeepPalpation.Text = "";
            txtGeneralLock.Text = "";
            txtHead.Text = "";
            txtInspection.Text = "";
            txtPercussion.Text = "";
            txtProvisionalDiagnosis.Text = "";
            txtPulse.Text = "";
            txtRespiratoryRate.Text="";
            txtSuperficialPalpation.Text = "";
            txtTemperature.Text = "";
        }
        bool checkValidDataToInsert()
        {
            if (txtAusculation.Text == "" ||
            txtBloodPressure.Text == "" ||
            txtCardiac.Text == "" ||
            txtChest.Text == "" ||
            txtDeepPalpation.Text == "" ||
            txtGeneralLock.Text == "" ||
            txtHead.Text == "" ||
            txtInspection.Text == "" ||
            txtPercussion.Text == "" ||
            txtProvisionalDiagnosis.Text == "" ||
            txtPulse.Text == "" ||
            txtRespiratoryRate.Text == "" ||
            txtSuperficialPalpation.Text == "" ||
            txtTemperature.Text == ""
                ) return false;
            return true;
        }
        private void Examination_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0 && dataGridView1.CurrentRow.Cells[0].Value.ToString() != "")
                btnAdmit.Show();
            else btnAdmit.Hide();
           
        }
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            string date = string.Format("{0}-{1}-{2}", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());
            da = new MySqlDataAdapter("select A_id, P_name from patient,admittion where P_id=A_P_id and A_date='" + date + "'and P_name like '%" + txtSearch.Text + "%'and A_examined=false;", connection);
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
