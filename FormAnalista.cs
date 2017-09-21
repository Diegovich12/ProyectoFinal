using System;
using System.Windows.Forms;

namespace ProyectoNutrical
{
    public partial class FormAnalista : Form
    {
        public FormAnalista()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void altaProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newMdiChild = new FormRegistroProveedores {MdiParent = this};
            newMdiChild.Show();
        }

        private void altaTrabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newMdiChild = new FormTrabajadores {MdiParent = this};
            newMdiChild.Show();
        }


        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var newMdiChild = new FormComprasProveedores {MdiParent = this};
            newMdiChild.Show();
        }

        private void nutricalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newMdiChild = new FormPagos {MdiParent = this};
            newMdiChild.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var newMdiChild = new FormMilkoScan {MdiParent = this};
            newMdiChild.Show();
        }
    }
}