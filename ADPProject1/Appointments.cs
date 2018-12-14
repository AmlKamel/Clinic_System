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
    public partial class Appointments : Form
    {
        Main main;
        public Appointments(Main m)
        {
            InitializeComponent();
            main = m;
        }

        private void Appointments_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
