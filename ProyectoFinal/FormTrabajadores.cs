using System;
using System.Windows.Forms;
using ProyectoNutrical.Models;

namespace ProyectoNutrical
{
    public partial class FormTrabajadores : Form
    {
        public FormTrabajadores()
        {
            InitializeComponent();
            LlenarCombopuestos();
            LlenarGridView();
        }

        public void limpiarc()
        {
            txtNombre.Clear();
            txtApellidoPaterno.Clear();
            txtApellidoMaterno.Clear();
            cmbPuesto.Items.Clear();
           
        }
        /// <summary>
        ///     Este metodo es lo que rellena al gridview
        /// </summary>
        private void LlenarGridView()
        {
            foreach (var item in ModelTrabajadores.Llenargrid())
            {
                var row = (DataGridViewRow) dtgTrabajadores.Rows[0].Clone();
                row.Cells[0].Value = item.IdTrabajador;
                row.Cells[1].Value = item.Nombre;
                row.Cells[2].Value = item.ApellidoPaterno;
                row.Cells[3].Value = item.ApellidoMaterno;
                row.Cells[4].Value = item.IdPuesto;
                row.Cells[5].Value = item.Puesto;
                row.Cells[6].Value = item.IdUsuario;
                dtgTrabajadores.Rows.Add(row);
            }
        }

        private void LlenarCombopuestos()
        {
            foreach (var item in ModelTrabajadores.Llenarcombo())
                cmbPuesto.Items.Add(item.Puesto);
        }

        private void toolStripBtnGuardar_Click(object sender, EventArgs e)
        {
            var insert = new ModelTrabajadores
            {
                Nombre = txtNombre.Text.Trim(),
                ApellidoPaterno = txtApellidoPaterno.Text.Trim(),
                ApellidoMaterno = txtApellidoMaterno.Text.Trim(),
                Contrasena = txtContrasena.Text.Trim(),
                Usuario = txtUsuario.Text.Trim(),
                Puesto = cmbPuesto.SelectedItem.ToString()
            };
            var resultado = ModelTrabajadores.Agregar(insert);

            if (resultado > 0)
                MessageBox.Show(@"Trabajador Guardado Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Guardar El Trabajador", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void dtgTrabajadores_DoubleClick(object sender, EventArgs e)
        {
            if (dtgTrabajadores.SelectedRows.Count == 1)
            {
                if (dtgTrabajadores.CurrentRow != null)
                {
                    var id = Convert.ToInt32(dtgTrabajadores.CurrentRow.Cells[0].Value);
                    ModelTrabajadores.ObtenerTrabajador(id);
                }
                txtNombre.Text = ModelTrabajadores.TrabajadorSelec.Nombre;
                txtApellidoPaterno.Text = ModelTrabajadores.TrabajadorSelec.ApellidoPaterno;
                txtApellidoMaterno.Text = ModelTrabajadores.TrabajadorSelec.ApellidoMaterno;
                cmbPuesto.SelectedIndex = ModelTrabajadores.TrabajadorSelec.IdPuesto - 1;
            }
            else
            {
                MessageBox.Show(@"debe de seleccionar una fila");
            }
        }

        private void trabajadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aTodo = new ModelTrabajadores
            {
                IdTrabajador = ModelTrabajadores.TrabajadorSelec.IdTrabajador,
                Nombre = txtNombre.Text.Trim(),
                ApellidoPaterno = txtApellidoPaterno.Text.Trim(),
                ApellidoMaterno = txtApellidoMaterno.Text.Trim(),
                IdPuesto = cmbPuesto.SelectedIndex + 1,
                IdUsuario = ModelTrabajadores.TrabajadorSelec.IdUsuario
            };
            if (ModelTrabajadores.Actualizar(aTodo, 1) > 0)
                MessageBox.Show(@"Trabajador Actualizado Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Actualizar El Trabajador", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
        }

        private void usuarioYContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aUsuario = new ModelTrabajadores
            {
                IdUsuario = ModelTrabajadores.TrabajadorSelec.IdUsuario,
                Usuario = txtUsuario.Text.Trim(),
                Contrasena = txtContrasena.Text.Trim(),
                IdPuesto = cmbPuesto.SelectedIndex + 1
            };
            if (ModelTrabajadores.Actualizar(aUsuario, 2) > 0)
                MessageBox.Show(@"Usuario y Contraseña Actualizada!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Actualizar", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aTodo = new ModelTrabajadores
            {
                IdTrabajador = ModelTrabajadores.TrabajadorSelec.IdTrabajador,
                Nombre = txtNombre.Text.Trim(),
                ApellidoPaterno = txtApellidoPaterno.Text.Trim(),
                ApellidoMaterno = txtApellidoMaterno.Text.Trim(),
                IdPuesto = cmbPuesto.SelectedIndex + 1,
                IdUsuario = ModelTrabajadores.TrabajadorSelec.IdUsuario,
                Usuario = txtUsuario.Text.Trim(),
                Contrasena = txtContrasena.Text.Trim()
            };
            if (ModelTrabajadores.Actualizar(aTodo, 3) > 0)
                MessageBox.Show(@"Trabajador y Usuario Actualizado!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Actualizar", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
        }

        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Desea Eliminar El Trabajador", @"Estas Seguro??",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (ModelTrabajadores.Eliminar(ModelTrabajadores.TrabajadorSelec.IdTrabajador,
                    ModelTrabajadores.TrabajadorSelec.IdUsuario) > 0)
            {
                MessageBox.Show(@"Trabajador Eliminado Correctamente!", @"Trabajador Eliminado", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                limpiarc();
            }
            else
            {
                MessageBox.Show(@"Se Cancelo La Eliminacion", @"Eliminacion Cancelada", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripBtnBuscar_Click(object sender, EventArgs e)
        {
            dtgTrabajadores.DataSource =
                ModelTrabajadores.Buscar(txtNombre.Text, txtApellidoPaterno.Text, txtApellidoMaterno.Text);
        }
    }
}