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
    public partial class Rays : Form
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
        public Rays(Main m)
        {
            InitializeComponent();
            main = m;
            da = new MySqlDataAdapter("Select Adm_id,name from Admission_rays,rays where Ray_id=R_id and done=false;", connection);
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            hidePanels();
        }

        void hidePanels()
        {
            chestPanel.Hide();
            panel1.Hide();
            panel2.Hide();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[1].Value.ToString() != "" ||dataGridView1.SelectedCells.Count!=0 )
            {
                if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "Chest X_Ray")
                {
                    chestPanel.Show();
                    dataGridView1.Enabled = false;
                }
                else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "Abdominal U/S")
                {
                    panel1.Show();
                    dataGridView1.Enabled = false;
                }
                else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "MSCT Abdomen")
                {
                    panel2.Show();
                    dataGridView1.Enabled = false;
                }
            }
        }

        private void btnCancelChest_Click(object sender, EventArgs e)
        {
            hidePanels();
            txtChest.Text = "";
            dataGridView1.Enabled = true;
        }

        private void btnSaveChesst_Click(object sender, EventArgs e)
        {
            if (txtChest.Text == "") MessageBox.Show("fill required data", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else {
                connection.Open();
                int a = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                dataGridView1.ClearSelection();
                cmd = new MySqlCommand("insert into chest values(" + a + ",'" + txtChest.Text + "');", connection);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand("update Admission_rays set done =true where Adm_id=" + Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())+"; ", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                // blood(Adm_id int, parameters int, hb int, mcv int, mch int, reticulocyte int, plates int, tlc int, neutrophil int, lymphocyte int, eosinophile int, foreign key(Adm_id) references admittion(A_id));
                da = new MySqlDataAdapter("Select Adm_id,name from Admission_rays,rays where Ray_id=R_id and done=false;", connection);
                dt.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Enabled = true;
                //hidePanels();
            }
        }

        private void Rays_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }

        private void Rays_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelAbd_Click(object sender, EventArgs e)
        {
            hidePanels();
            dataGridView1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hidePanels();
            dataGridView1.Enabled = true;
        }

        private void txtSaveAbd_Click(object sender, EventArgs e)
        {
            if (txtAbdominal.Text == "") MessageBox.Show("fill required data", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else {
                connection.Open();
                int a = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                dataGridView1.ClearSelection();
                cmd = new MySqlCommand("insert into abdominal values(" + a + ",'" + txtChest.Text + "');", connection);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand("update Admission_rays set done =true where Adm_id="+ Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())+"; ", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                // blood(Adm_id int, parameters int, hb int, mcv int, mch int, reticulocyte int, plates int, tlc int, neutrophil int, lymphocyte int, eosinophile int, foreign key(Adm_id) references admittion(A_id));
                da = new MySqlDataAdapter("Select Adm_id,name from Admission_rays,rays where Ray_id=R_id and done=false;", connection);
                dt.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Enabled = true;
            }
        }

        private void btnsaveMSCt_Click_1(object sender, EventArgs e)
        {

            if (txtMct.Text == "") MessageBox.Show("fill required data", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else {
                connection.Open();
                int a = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                dataGridView1.ClearSelection();
                cmd = new MySqlCommand("insert into msct values(" +a + ",'" + txtChest.Text + "');", connection);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand("update Admission_rays set done =true where Adm_id=" + Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "; ", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                // blood(Adm_id int, parameters int, hb int, mcv int, mch int, reticulocyte int, plates int, tlc int, neutrophil int, lymphocyte int, eosinophile int, foreign key(Adm_id) references admittion(A_id));
                da = new MySqlDataAdapter("Select Adm_id,name from Admission_rays,rays where Ray_id=R_id and done=false;", connection);
                dt.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Enabled = true;
            }
        }

        private void btnCancelMsct_Click_1(object sender, EventArgs e)
        {
            hidePanels();
            txtMct.Text = "";
            dataGridView1.Enabled = true;
        }
    }
}
