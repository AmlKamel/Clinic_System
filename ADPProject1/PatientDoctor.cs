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
    public partial class PatientDoctor : Form
    {
        Main main;
        MySqlConnection connection = new MySqlConnection(@"server=localhost;user=root;database=Clinic;password=root;port=3310;charset=utf8;");
        MySqlCommand cmd;
        MySqlDataAdapter da;
        MySqlDataAdapter da1;
        MySqlDataAdapter da12;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        string state = "";
        public PatientDoctor(Main m)
        {
            InitializeComponent();
            main = m;
            unenableTextPersonInfo();
            unenableTextAdmition();
            unenableTextExaminInfo();
            unenableSave();

            string date = string.Format("{0}-{1}-{2}", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());
            da = new MySqlDataAdapter("select A_id,A_P_id, P_name from patient,admittion where P_id=A_P_id and A_date='" + date + "'", connection);
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
        }

        void enableSave()
        {
           
            btnAddAnalysis.Enabled = false;
            btnAddComment.Enabled = false;
            btnAddMedicine.Enabled = false;
            btnAddRays.Enabled = false;
        }
        void unenableSave()
        {
           
            btnAddAnalysis.Enabled = true;
            btnAddComment.Enabled = true;
            btnAddMedicine.Enabled = true;
            btnAddRays.Enabled = true;
        }
        void hidePanels()
        {
           if( PAddRays.Visible)PAddRays.Hide();
           if (PHistory.Visible) PHistory.Hide();
            //if (PMedicine.Visible) PMedicine.Hide();
            if (pcomment.Visible) pcomment.Hide();
            if (PAnalysis.Visible) PAnalysis.Hide();



        }
        void emptyTextPersonalInfo()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            combSex.Text = "";
            combMaritalStatus.Text = "";
            dateRegister.Text = "";
        }
        void emptyTextAdmition()
        {
            txtComplaint.Text = "";
            txtfamilyhistory.Text="";
            txtHistoryPres.Text = "";
            txtMHistory.Text = "";
        }
        void unenableTextAdmition()
        {
            txtComplaint.Enabled = false;
            txtfamilyhistory.Enabled = false;
            txtHistoryPres.Enabled = false;
            txtMHistory.Enabled = false;
        }
        void unenableTextPersonInfo()
        {
            txtID.Enabled = false;
            txtName.Enabled = false;
            txtAge.Enabled = false;
            txtAddress.Enabled = false;
            txtPhone.Enabled = false;
            combSex.Enabled = false;
            combMaritalStatus.Enabled = false;
            dateRegister.Enabled = false;
        }
        void unenableTextExaminInfo()
        {
            txtGeneralLock.Enabled = false;
            txtPulse.Enabled = false;
            txtBloodPressure.Enabled = false;
            txtTemperature.Enabled = false;
            txtRespiratoryRate.Enabled = false;
            txtHead.Enabled = false;
            txtChest.Enabled = false;
            txtCardiac.Enabled = false;
            txtInspection.Enabled = false;
            txtSuperficialPalpation.Enabled = false;
            txtDeepPalpation.Enabled = false;
            txtPercussion.Enabled = false;
            txtAusculation.Enabled = false;
            txtProvisionalDiagnosis.Enabled = false;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string date = string.Format("{0}-{1}-{2}", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());
            da = new MySqlDataAdapter("select A_id, P_name from patient,admittion where P_id=A_P_id and A_date='" + date + "'and P_name like '%" + txtSearch.Text + "%'and A_examined=false;", connection);
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0 || dataGridView1.CurrentRow.Cells[0].Value.ToString() == "")
            {
                hidePanels();
                enableSave();
                //btnSave.Enabled = false;

            }
            else
            {
                unenableSave();
                hidePanels();
                PHistory.Show();
                //load patient info
                connection.Open();
                string s = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cmd = new MySqlCommand("select * from patient,admittion where P_id=A_P_id and A_id=" + s + ";", connection);
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
                if (connection.State==ConnectionState.Open) connection.Close();
                else {
                    connection.Close();
                    connection.Open();
                }
               // connection.Close();
                //load admittion info
                
                //connection.Open();
                string id = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                da1 = new MySqlDataAdapter("select A_id, A_date from admittion where A_P_id= " + Int32.Parse(id) + ";", connection);
                dt1.Clear();
                da1.Fill(dt1);
                dataGridView2.DataSource = dt1;
                if (connection.State == ConnectionState.Open) connection.Close();

                //load examination info
                if (connection.State == ConnectionState.Open) connection.Close();
                else {
                    connection.Close();
                    connection.Open();
                }
                // connection.Open();
                dr.Close();
                 id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cmd = new MySqlCommand("select * from examination where E_A_id ="+ Int32.Parse(id)+ ";", connection);
                 dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtGeneralLock.Text =dr[2].ToString();
                    txtPulse.Text = dr[3].ToString();
                    txtBloodPressure.Text = dr[4].ToString();
                    txtTemperature.Text = dr[5].ToString();
                    txtRespiratoryRate.Text = dr[6].ToString();
                    txtHead.Text = dr[7].ToString();
                    txtChest.Text = dr[8].ToString();
                    txtCardiac.Text = dr[9].ToString();
                    txtInspection.Text = dr[10].ToString();
                    txtSuperficialPalpation.Text = dr[11].ToString();
                    txtDeepPalpation.Text = dr[12].ToString();
                    txtPercussion.Text = dr[13].ToString();
                    txtAusculation.Text = dr[14].ToString();
                    txtProvisionalDiagnosis.Text = dr[15].ToString();

                }
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }
        private void btnAddRays_Click(object sender, EventArgs e)
        {
            hidePanels();
            enableSave();
            //btnSave.Enabled = false;
            PAddRays.Show();
           dataGridView1.Enabled = false;
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count != 0 && dataGridView2.CurrentRow.Cells[0].Value.ToString() != "")
            {
                if (connection.State == ConnectionState.Open) connection.Close();
                connection.Open();
                string id = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                cmd = new MySqlCommand("select A_complaint, A_family_history,A_presentIllness_history,A_medical_history from admittion where A_id=" + Int32.Parse(id) + ";", connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtComplaint.Text = dr[0].ToString();
                    txtfamilyhistory.Text = dr[1].ToString();
                    txtHistoryPres.Text = dr[2].ToString();
                    txtMHistory.Text = dr[3].ToString();
                }
                connection.Close();
            }

        }
        private void btnCancelAddRay_Click_1(object sender, EventArgs e)
        {
            hidePanels();
            dataGridView1.Enabled = true;
            dataGridView1.ClearSelection();
           // enableSave();
            //btnSave.Enabled = false;
        }
        private void PatientDoctor_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }
        private void btnSaveAddRay_Click(object sender, EventArgs e)
        {
            //no selected 
            if (!boxAbdom.Checked && !boxChest.Checked && !boxMSCT.Checked)
                MessageBox.Show("no Selected Rays ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (dataGridView1.CurrentRow.Cells[0].Value != "" && dataGridView1.SelectedCells.Count != 0)
            {
                try
                {
                    connection.Open();
                    if (boxChest.Checked)
                    {

                        string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        cmd = new MySqlCommand("insert into Admission_rays values(" + d + ",100,false);", connection);
                        cmd.ExecuteNonQuery();
                    }

                    if (boxAbdom.Checked)
                    {
                        string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        cmd = new MySqlCommand("insert into Admission_rays values(" + d + ",200,false);", connection);
                        cmd.ExecuteNonQuery();
                    }
                    if (boxMSCT.Checked)
                    {
                        string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        cmd = new MySqlCommand("insert into Admission_rays values(" + d + ",300,false);", connection);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("some rays already assigned to patient", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    connection.Close();
                    hidePanels();
                  //  dataGridView1.ClearSelection();
                    unenableSave();
                    //dataGridView1.Enabled = true;
                    dataGridView1.Enabled = true;
                    dataGridView1.ClearSelection();
                }
            }
        }

        private void btnAddAnalysis_Click(object sender, EventArgs e)
        {
            hidePanels();
            enableSave();
            //btnSave.Enabled = false;
            PAnalysis.Show();
            dataGridView1.Enabled = false;

        }
        private void btnsaveAddAna_Click(object sender, EventArgs e)
        {
            //no selected 
            if (!boxBloodPic.Checked && !boxCoagul.Checked && !boxElectrolytes.Checked && !boxLiver.Checked && !boxUrine.Checked && !boxStool.Checked && !boxAlpha.Checked && !boxAscitic.Checked)
                MessageBox.Show("no Selected Rays ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (dataGridView1.CurrentRow.Cells[0].Value != "" && dataGridView1.SelectedCells.Count != 0)
            {
                try
                {
                    connection.Open();
                    if (boxBloodPic.Checked)
                    {

                        string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        cmd = new MySqlCommand("insert into Admission_analysis values(" + d + ",100,false);", connection);
                        cmd.ExecuteNonQuery();
                    }

                    if (boxCoagul.Checked)
                    {
                        string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        cmd = new MySqlCommand("insert into Admission_analysis values(" + d + ",200,false);", connection);
                        cmd.ExecuteNonQuery();
                    }
                    if (boxElectrolytes.Checked)
                    {
                        string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        cmd = new MySqlCommand("insert into Admission_analysis values(" + d + ",300,false);", connection);
                        cmd.ExecuteNonQuery();
                    }
                    if (boxLiver.Checked)
                    {
                        string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        cmd = new MySqlCommand("insert into Admission_analysis values(" + d + ",400,false);", connection);
                        cmd.ExecuteNonQuery();
                    }
                    if (boxUrine.Checked)
                    {
                        string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        cmd = new MySqlCommand("insert into Admission_analysis values(" + d + ",500,false);", connection);
                        cmd.ExecuteNonQuery();
                    }
                    if (boxStool.Checked)
                    {
                        string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        cmd = new MySqlCommand("insert into Admission_analysis values(" + d + ",600,false);", connection);
                        cmd.ExecuteNonQuery();
                    }
                    if (boxAlpha.Checked)
                    {
                        string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        cmd = new MySqlCommand("insert into Admission_analysis values(" + d + ",700,false);", connection);
                        cmd.ExecuteNonQuery();
                    }
                    if (boxAscitic.Checked)
                    {
                        string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        cmd = new MySqlCommand("insert into Admission_analysis values(" + d + ",800,false);", connection);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("some analysis already assigned to patient", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    connection.Close();
                    hidePanels();
                    dataGridView1.Enabled = true;
                    dataGridView1.ClearSelection();

                }
            }
        }

        private void btncancelAddAna_Click(object sender, EventArgs e)
        {
            hidePanels();
            
            dataGridView1.Enabled = true;
            dataGridView1.ClearSelection();
        }


        private void btnAddComment_Click(object sender, EventArgs e)
        {
            hidePanels();

            pcomment.Show();
            panel1.Hide();
            
        //    pMedicine.Show();
            dataGridView1.Enabled = false;
        }

        void loadMedicinesToListBox()
        {
            listBox1.Items.Clear();
            connection.Open();
            string id = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            cmd = new MySqlCommand("select M_id,M_name from medicine;", connection);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr[0].ToString() + "-" + dr[1].ToString());
            }
            connection.Close();
        }
       /* private void btnSaveAddMedicine_Click(object sender, EventArgs e)
        {
            ////no selected 
            //if (txtMedicines.Items.Count==0)
            //    MessageBox.Show("no medicine added ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //else if (dataGridView1.CurrentRow.Cells[0].Value != "" && dataGridView1.SelectedCells.Count != 0)
            //{
            //    connection.Open();
            //    string[] arr;
            //    for (int i = 0; i < txtMedicines.Items.Count; i++)
            //    {
            //        arr = txtMedicines.Items[i].ToString().Split(new char['-']);
            //        string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //        cmd = new MySqlCommand("insert into medicine(adm,text) values(" +d+ arr[0]+ ");", connection);
            //        cmd.ExecuteNonQuery();
            //    }

            //    connection.Close();
            //    hidePanels();
            //    dataGridView1.ClearSelection();
            //    unenableSave();
            //    dataGridView1.Enabled = true;
            //}
        }*/

        private void btnCancelAddMedicin_Click(object sender, EventArgs e)
        {
            hidePanels();
            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
            unenableSave();
        }

        private void btnsavecomm_Click(object sender, EventArgs e)
        {
            //no selected 
            if (textBox1.Text == "")
                MessageBox.Show("Write comment to be added ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (dataGridView1.CurrentRow.Cells[0].Value != "" && dataGridView1.SelectedCells.Count != 0)
            {
                connection.Open();
                string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cmd = new MySqlCommand("insert into comments(adm,comment) values(" + d + ",'" + textBox1.Text + "');", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                hidePanels();

                //dataGridView1.ClearSelection();
                unenableSave();
                //  dataGridView1.Enabled = true;
                dataGridView1.Enabled = true;
                dataGridView1.ClearSelection();
            }
        }
        private void btnCancelcomm_Click(object sender, EventArgs e)
        {
            hidePanels();
            dataGridView1.Enabled = true;
            dataGridView1.ClearSelection();
           
            enableSave();
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {

        }

        private void btnAddMedicine_Click_1(object sender, EventArgs e)
        {
            hidePanels();

            //pMedicine.Show();
            loadMedicinesToListBox();
             pcomment.Show();
            panel1.Show();
           // Form1 f = new Form1();
           // f.Show();

            dataGridView1.Enabled = false;
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
      
            //listBox1.Items.Remove(listBox1.SelectedItem);



            }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count == 0)
                MessageBox.Show("no medicine added ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (dataGridView1.CurrentRow.Cells[0].Value != "" && dataGridView1.SelectedCells.Count != 0)
            {
                connection.Open();
                string[] arr;
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    arr = listBox2.Items[i].ToString().Split(new char['-']);
                    string d = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    cmd = new MySqlCommand("insert into Admission_medicine ( Adm_id, med_id) values(" + d + arr[0] + ");", connection);
                    cmd.ExecuteNonQuery();
                }

                connection.Close();
                hidePanels();
                dataGridView1.ClearSelection();
                unenableSave();
                dataGridView1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hidePanels();

            dataGridView1.Enabled = true;
            dataGridView1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = listBox1.SelectedItem.ToString();
            listBox2.Items.Add(s);
            listBox1.ClearSelected();
            listBox1.Items.Remove(s);

        }
    }
    }

