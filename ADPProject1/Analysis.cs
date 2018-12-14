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
    public partial class Analysis : Form
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
        
        public Analysis(Main m)
        {
            InitializeComponent();
            main = m;
            da = new MySqlDataAdapter("Select Adm_id,name from Admission_analysis,analysis where Analysis_id=A_id and done=false;", connection);
            dt.Clear();
            da.Fill(dt);
            hidePanels();
            dataGridView1.DataSource = dt;
        }

        void hidePanels()
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[1].Value.ToString() != "" || dataGridView1.SelectedCells.Count != 0)
            {
                if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "Complete_Blood_Picture")
                {
                    panel1.Show();
                    dataGridView1.Enabled = false;
                }
                else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "Coagulation_Profile")
                {
                    panel2.Show();
                    dataGridView1.Enabled = false;
                }
                else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "Elecrolytes_And_Functions")
                {
                    panel3.Show();
                    dataGridView1.Enabled = false;
                }
                else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "Liver_Function_Tests")
                {
                    panel4.Show();
                    dataGridView1.Enabled = false;
                }
                else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "Urine_Analysis")
                {
                    //panel2.Show();
                    dataGridView1.Enabled = false;
                }
                else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "Stool_Analysis")
                {
                    //panel2.Show();
                    dataGridView1.Enabled = false;
                }
                else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "Alpha_Feto_Protein")
                {
                    //panel2.Show();
                    dataGridView1.Enabled = false;
                }
                else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "Ascitic_Fluid")
                {
                    //panel2.Show();
                    dataGridView1.Enabled = false;
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Analysis_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }

        private void btnOkBlood_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelBlood_Click(object sender, EventArgs e)
        {
            hidePanels();         
            dataGridView1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hidePanels();
            dataGridView1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            hidePanels();
            dataGridView1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hidePanels();
            dataGridView1.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            hidePanels();
            dataGridView1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hidePanels();
            dataGridView1.Enabled = true;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            hidePanels();
            dataGridView1.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
