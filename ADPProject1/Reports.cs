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
    public partial class Reports : Form
    {
     

        Main main;
        MySqlConnection connection = new MySqlConnection(@"server=localhost;user=root;database=Clinic;password=root;port=3310;charset=utf8;");
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt = new DataTable();
        int x;
        public Reports(Main m)
        {

            InitializeComponent();
            main = m;
            da = new MySqlDataAdapter("select P_id,P_name from patient;", connection);
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Reports_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            da = new MySqlDataAdapter("select P_id,P_name from patient where P_name like '%" + txtSearch.Text + "%'", connection);
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void Reports_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            

            // patient info 
            string s = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            connection.Open();
            cmd = new MySqlCommand("select * from patient where P_id=" + s + ";", connection);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
              
                txtName.Text = dr[1].ToString();
                txtAge.Text = dr[2].ToString();
                dateRegister.Text = dr[7].ToString();
            }
            dr.Close();
            connection.Close();
            
            //compaint
              connection.Open();
             cmd = new MySqlCommand("select A_id from admittion where A_P_id="+s+ " order by A_date desc limit 1 ;", connection);
              x=   Convert.ToInt32( cmd.ExecuteScalar());
            ///    Messagebox.show(x.ToString());
           // MessageBox.Show(x.ToString());

             connection.Close();
            
            
            //compl

               connection.Open();
               cmd = new MySqlCommand("select A_complaint from admittion where A_id=" + x + ";", connection);
            dr = cmd.ExecuteReader();
            if (dr.Read())
                textBox1.Text = dr[0].ToString();
            dr.Close();
            connection.Close();


            connection.Open();
            cmd = new MySqlCommand("select comment from comments where adm=" + x + ";", connection);
            dr = cmd.ExecuteReader();
            if (dr.Read())
                textBox2.Text = dr[0].ToString();
            dr.Close();
            connection.Close();
            // textBox1.Text =         ;
            //  textBox1.Text = Convert.ToString(cmd.ExecuteScalar());
            connection.Close();
                
            connection.Open();
                   cmd = new MySqlCommand("select * from examination where E_A_id ="+ x + " ;", connection);
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


                connection.Close();
             
            }





    }
}
