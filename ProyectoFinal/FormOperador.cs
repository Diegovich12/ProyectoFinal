using System;
using System.Windows.Forms;

namespace ProyectoNutrical
{
    public partial class FormOperador : Form
    {
        public FormOperador()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripBtnRecepcion_Click(object sender, EventArgs e)
        {
            var newMDIChild = new FormRecepcion { MdiParent = this };
            newMDIChild.Show();
        }

        private void toolStripBtnEvaporador_Click(object sender, EventArgs e)
        {
            var newMDIChild = new FormEvaporador { MdiParent = this };
            newMDIChild.Show();
        }

        private void toolStripBtnVertical_Click(object sender, EventArgs e)
        {
            var newMDIChild = new FormSecadorVertical { MdiParent = this };
            newMDIChild.Show();
        }

        private void toolStripBtnHorizontal_Click(object sender, EventArgs e)
        {
            var newMDIChild = new FormSecadorHorizontal { MdiParent = this };
            newMDIChild.Show();
        }

        private void toolStripBtnGrasas_Click(object sender, EventArgs e)
        {
            var newMDIChild = new FormGrasas { MdiParent = this };
            newMDIChild.Show();
        }
        private void toolStripBtnCuartoHumedo_Click(object sender, EventArgs e)
        {
            var newMDIChild = new FormCuartoHumedo { MdiParent = this };
            newMDIChild.Show();
        }
    }
}