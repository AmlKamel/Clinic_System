using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADPProject1
{
    public partial class Main : Form
    {
        LogIn ff;
        bool logOut;
        int UserID;
        string userType;
        public Main(int id,string type,LogIn f)
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            ff = f;
            UserID = id;
            logOut = false;
            userType = type;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text =  "Today :  "+DateTime.Now.ToLongDateString()+"   Time :  "+DateTime.Now.ToLongTimeString();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (logOut) ff.Show();
            else ff.Close();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            DoctorData d = new DoctorData(UserID, this);
            this.Hide();
            d.Show();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {

            if (userType == "Register")
            {
                Registers r = new Registers(this);
                r.Show();
            }
            else if (userType == "Rays_Doctor")
            {
                Rays r = new Rays(this);
                r.Show();
            }
            else if (userType == "Analysis_Doctor")
            {
                Analysis a = new Analysis(this);
                a.Show();
            }
            else if (userType == "Examination_Doctor")
            {
                Examination exx = new Examination(this);
                exx.Show();
            }
            else
            { PatientDoctor ex = new PatientDoctor(this);
               ex.Show();
            }            
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports r = new Reports(this);
            this.Hide();
            r.Show();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            Appointments ap = new Appointments(this);
            this.Hide();
            ap.Show();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            DialogResult d= MessageBox.Show( "Sure To log in to another account ", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(d==DialogResult.OK)
            {
                logOut = true;
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
             this.Close();
        }
    }
}
