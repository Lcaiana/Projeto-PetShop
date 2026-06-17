using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPetShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTutor tutor = new frmTutor();
            tutor.Show();
        }

        private void petToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPet pet = new frmPet();
            pet.Show();
        }

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServiços serviços = new frmServiços();
            serviços.Show();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulta consulta = new frmConsulta();
            consulta.Show();
        }

        private void listagensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListagens listagens = new frmListagens();
            listagens.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre sobre = new frmSobre();
            sobre.Show();
        }
    }
}
