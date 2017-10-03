using ProyectoNutrical.Models;
using System;
using System.Windows.Forms;

namespace ProyectoNutrical
{
    public partial class FormRegistroProveedores : Form
    {
        public FormRegistroProveedores()
        {
            InitializeComponent();
            LlenarGridView();
        }

        private void LlenarGridView()
        {
            foreach (var item in ModelProveedores.Llenargrid())
            {
                var row = (DataGridViewRow)dtgProveedores.Rows[0].Clone();
                row.Cells[0].Value = item.IdProveedor;
                row.Cells[1].Value = item.Nombre;
                row.Cells[2].Value = item.Proveedor;
                row.Cells[3].Value = item.Matricula;
                row.Cells[4].Value = item.Rancho;
                row.Cells[5].Value = item.NoPipa;
                dtgProveedores.Rows.Add(row);
            }
        }
        private void toolStripBtnGuardar_Click(object sender, EventArgs e)
        {
            var insert = new ModelProveedores
            {
                Nombre = txtNombre.Text.Trim(),
                Matricula = txtMatricula.Text.Trim(),
                Rancho = txtRancho.Text.Trim(),
                NoPipa = txtNoPipa.Text.Trim(),
                Proveedor = txtProveedor.Text.Trim()
            };
            var resultado = ModelProveedores.Agregar(insert);

            if (resultado > 0)
                MessageBox.Show(@"Proveedor Guardado Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Guardar El Proveedor", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void toolStripBtnModificar_Click(object sender, EventArgs e)
        {

            var pTodo = new ModelProveedores
            {
                IdProveedor = ModelProveedores.ProveedorSelec.IdProveedor,
                Nombre = txtNombre.Text.Trim(),
                Matricula = txtMatricula.Text.Trim(),
                Proveedor = txtProveedor.Text.Trim(),
                Rancho = txtRancho.Text.Trim(),
                NoPipa = txtNoPipa.Text.Trim(),
            };

           if (ModelProveedores.Actualizar(pTodo) > 0)
                MessageBox.Show(@"Cliente Guardado Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No se pudo guardar el cliente", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            /*
            if (MessageBox.Show(@"Esta Seguro Que Desea Eliminar El Proveedor", @"Estas Seguro??",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (ModelProveedores.Eliminar(ModelProveedores.ProveedorSelec.IdProveedor,
                    ModelProveedores.ProveedorSelec.IdRancho) > 0)
            {
                MessageBox.Show(@"Proveedor Eliminado Correctamente!", @"Proveedor Eliminado", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                MessageBox.Show(@"No Se Pudo Eliminar El Proveedor", @"Proveedor No Eliminado", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show(@"Se Cancelo La Eliminacion", @"Eliminacion Cancelada", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            */
        }

        private void toolStripBtnBuscar_Click(object sender, EventArgs e)
        {
            dtgProveedores.DataSource = ModelProveedores.Buscar(txtNombre.Text);
        }

        private void dtgProveedores_DoubleClick(object sender, EventArgs e)
        {
            if (dtgProveedores.SelectedRows.Count == 1)
            {
                if (dtgProveedores.CurrentRow != null)
                {
                    var id = Convert.ToInt32(dtgProveedores.CurrentRow.Cells[0].Value);
                    ModelProveedores.ObtenerProveedor(id);
                }
                txtNombre.Text = ModelProveedores.ProveedorSelec.Nombre;
                txtProveedor.Text = ModelProveedores.ProveedorSelec.Proveedor;
                txtMatricula.Text = ModelProveedores.ProveedorSelec.Matricula;
                txtRancho.Text = ModelProveedores.ProveedorSelec.Rancho;
                txtNoPipa.Text = ModelProveedores.ProveedorSelec.NoPipa;

            }
            else
            {
                MessageBox.Show(@"debe de seleccionar una fila");
            }
        }
    }
}