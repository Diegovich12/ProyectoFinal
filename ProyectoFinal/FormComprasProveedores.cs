using System;
using System.Windows.Forms;
using ProyectoNutrical.Models;

namespace ProyectoNutrical
{
    public partial class FormComprasProveedores : Form
    {
        public FormComprasProveedores()
        {
            InitializeComponent();
            ComboProveedores();
            ComboAnalista();
            LlenarGridView();

            cmbProveedor.SelectedIndex = 0;
            cmbRancho.SelectedIndex = 0;
            cmbAnalista.SelectedIndex = 0;
            cmbProducto.SelectedIndex = 0;
        }

        private void ComboAnalista()
        {
            foreach (var item in ModelTrabajadores.LlenarcomboTrabajadores(2))
                cmbAnalista.Items.Add(item.Nombre);
        }

        public void Limpiarcp()
        {
            txtNoPipa.Clear();
            cmbProveedor.Items.Clear();
            cmbRancho.Items.Clear();
            txtRemision.Clear();
            txtPlacas.Clear();
            cmbAnalista.Items.Clear();
            txtSello1.Clear();
            txtSello2.Clear();
            cmbProducto.Items.Clear();
            txtDensidad.Clear();
            txtGrasa.Clear();
            txtSNG.Clear();
            txtST.Clear();
            txtCrioscopia.Clear();
            txtProteina.Clear();
            txtKilos.Clear();
            txtLitros.Clear();

        }

        private void LlenarGridView()
        {
            foreach (var item in ModelComprasP.Llenargrid())
            {
                var row = (DataGridViewRow)dtgCompras.Rows[0].Clone();
                row.Cells[0].Value = item.IdCompra;
                row.Cells[1].Value = item.Fecha;
                row.Cells[2].Value = item.NoPipa;
                row.Cells[3].Value = item.Proveedor;
                row.Cells[4].Value = item.Rancho;
                row.Cells[5].Value = item.NoRemision;
                row.Cells[6].Value = item.FechaLlegada;
                row.Cells[7].Value = item.Placas;
                row.Cells[8].Value = item.Analista;
                row.Cells[9].Value = item.Sello1;
                row.Cells[10].Value = item.Sello2;
                row.Cells[11].Value = item.TipoProducto;
                row.Cells[12].Value = item.Densidad;
                row.Cells[13].Value = item.Grasa;
                row.Cells[14].Value = item.SNG;
                row.Cells[15].Value = item.ST;
                row.Cells[16].Value = item.Crioscopia;
                row.Cells[17].Value = item.Proteina;
                row.Cells[18].Value = item.Kilos;
                row.Cells[19].Value = item.Litros;
                dtgCompras.Rows.Add(row);
            }
        }

        private void ComboProveedores()
        {
            foreach (var item in ModelProveedores.Llenarcombo("Proveedor"))
                cmbProveedor.Items.Add(item.Proveedor);

            foreach (var item in ModelProveedores.Llenarcombo("Ranchos"))
                cmbRancho.Items.Add(item.Rancho);
        }

        private void ToolStripBtnGuardar_Click(object sender, EventArgs e)
        {
            var pComprasP = new ModelComprasP
            {
                Fecha = dtpFecha.Value.Year + "/" + dtpFecha.Value.Month + "/" + dtpFecha.Value.Day + "/" +
                      dtpFecha.Value.Hour + "/" + dtpFecha.Value.Minute + "/" + dtpFecha.Value.Second,
                NoPipa = txtNoPipa.Text,
                Proveedor = cmbProveedor.SelectedItem.ToString(),
                Rancho = cmbRancho.SelectedItem.ToString(),
                NoRemision = txtRemision.Text,
                FechaLlegada = dtpFechaL.Value.Year + "/" + dtpFechaL.Value.Month + "/" + dtpFechaL.Value.Day + "/" +
                      dtpFechaL.Value.Hour + "/" + dtpFechaL.Value.Minute + "/" + dtpFechaL.Value.Second,
                Placas = txtPlacas.Text,
                Analista = cmbAnalista.SelectedItem.ToString(),
                Sello1 = txtSello1.Text,
                Sello2 = txtSello2.Text,
                TipoProducto = cmbProducto.SelectedItem.ToString(),
                Densidad = double.Parse(txtDensidad.Text),
                Grasa = double.Parse(txtGrasa.Text),
                SNG = double.Parse(txtSNG.Text),
                ST = double.Parse(txtST.Text),
                Crioscopia = double.Parse(txtCrioscopia.Text),
                Proteina = double.Parse(txtProteina.Text),
                Kilos = double.Parse(txtKilos.Text),
                Litros = double.Parse(txtLitros.Text)
            };
            var resultado = ModelComprasP.Agregar(pComprasP);

            if (resultado > 0)
                MessageBox.Show(@"Compra Guardada Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Guardar La Compra", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void ToolStripBtnModificar_Click(object sender, EventArgs e)
        {

            var pComprasP = new ModelComprasP
            {
                IdCompra = ModelComprasP.ComprasPSelect.IdCompra,
                Fecha = dtpFecha.Value.Year + "/" + dtpFecha.Value.Month + "/" + dtpFecha.Value.Day + "/" +
              dtpFecha.Value.Hour + "/" + dtpFecha.Value.Minute + "/" + dtpFecha.Value.Second,
                NoPipa = txtNoPipa.Text.Trim(),
                Proveedor = cmbProveedor.SelectedItem.ToString(),
                Rancho = cmbRancho.SelectedItem.ToString(),
                NoRemision = txtRemision.Text.Trim(),
                FechaLlegada = dtpFechaL.Value.Year + "/" + dtpFechaL.Value.Month + "/" + dtpFechaL.Value.Day + "/" +
              dtpFechaL.Value.Hour + "/" + dtpFechaL.Value.Minute + "/" + dtpFechaL.Value.Second,
                Placas = txtPlacas.Text.Trim(),
                Analista = cmbAnalista.SelectedItem.ToString(),
                Sello1 = txtSello1.Text.Trim(),
                Sello2 = txtSello2.Text.Trim(),
                TipoProducto = cmbProducto.SelectedItem.ToString(),
                Densidad = Convert.ToDouble(txtDensidad.Text),
                Grasa = Convert.ToDouble(txtGrasa.Text),
                SNG = Convert.ToDouble(txtSNG.Text),
                ST = Convert.ToDouble(txtST.Text),
                Crioscopia = Convert.ToDouble(txtCrioscopia.Text),
                Proteina = Convert.ToDouble(txtProteina.Text),
                Kilos = Convert.ToDouble(txtKilos.Text),
                Litros = Convert.ToDouble(txtLitros.Text)
            };

            dtgCompras.Refresh();
            if (ModelComprasP.Actualizar(pComprasP) > 0)
                MessageBox.Show(@"Captura Actualizada Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Actualizar La Captura", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
        }

        private void ToolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Esta Seguro Que Desea Eliminar El Pago", @"Estas Seguro??",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (ModelComprasP.Eliminar(ModelComprasP.ComprasPSelect.IdCompra,
                    ModelComprasP.ComprasPSelect.IdCompra) > 0)
            {
                MessageBox.Show(@"Pago Eliminado Correctamente!", @"Pago Eliminado", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                MessageBox.Show(@"No Se Pudo Eliminar El Pago", @"Pago No Eliminado", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                Limpiarcp();
            }
            else
            {
                MessageBox.Show(@"Se Cancelo La Eliminacion", @"Eliminacion Cancelada", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void ToolStripBtnBuscar_Click(object sender, EventArgs e)
        {
            var Rancho = string.IsNullOrEmpty(cmbRancho.SelectedItem.ToString());
            var Producto = string.IsNullOrEmpty(cmbProducto.SelectedItem.ToString());
            var NoRemicion = string.IsNullOrEmpty(txtRemision.Text);

            if (Rancho && Producto && NoRemicion)
                MessageBox.Show("Debes de Seleccionar algun Dato para buscar Rancho, Producto o Numero de Remicion");
            else
            {
                var encontro = true;
                foreach (var item in ModelComprasP.Buscar(cmbRancho.SelectedItem.ToString(), cmbProducto.SelectedItem.ToString(), txtRemision.Text.Trim()))
                {
                    if (encontro)
                    {
                        dtgCompras.Rows.Clear();
                        dtgCompras.Refresh();
                    }
                    var row = (DataGridViewRow)dtgCompras.Rows[0].Clone();
                    row.Cells[0].Value = item.IdCompra;
                    row.Cells[1].Value = item.Fecha;
                    row.Cells[2].Value = item.NoPipa;
                    row.Cells[3].Value = item.Proveedor;
                    row.Cells[4].Value = item.Rancho;
                    row.Cells[5].Value = item.NoRemision;
                    row.Cells[6].Value = item.FechaLlegada;
                    row.Cells[7].Value = item.Placas;
                    row.Cells[8].Value = item.Analista;
                    row.Cells[9].Value = item.Sello1;
                    row.Cells[10].Value = item.Sello2;
                    row.Cells[11].Value = item.TipoProducto;
                    row.Cells[12].Value = item.Densidad;
                    row.Cells[13].Value = item.Grasa;
                    row.Cells[14].Value = item.SNG;
                    row.Cells[15].Value = item.ST;
                    row.Cells[16].Value = item.Crioscopia;
                    row.Cells[17].Value = item.Proteina;
                    row.Cells[18].Value = item.Kilos;
                    row.Cells[19].Value = item.Litros;
                    dtgCompras.Rows.Add(row);
                    encontro = false;

                }
            }
        }

        private void DtgCompras_DoubleClick(object sender, EventArgs e)
        {
            if (dtgCompras.SelectedRows.Count == 1)
            {
                if (dtgCompras.CurrentRow != null)
                    ModelComprasP.ObtenerCompras(Convert.ToInt32(dtgCompras.CurrentRow.Cells[0].Value));

                dtpFecha.Text = ModelComprasP.ComprasPSelect.Fecha;
                txtNoPipa.Text = ModelComprasP.ComprasPSelect.NoPipa;
                cmbProveedor.SelectedItem = ModelComprasP.ComprasPSelect.Proveedor;
                cmbRancho.SelectedItem = ModelComprasP.ComprasPSelect.Rancho;
                txtRemision.Text = ModelComprasP.ComprasPSelect.NoRemision;
                dtpFechaL.Text = ModelComprasP.ComprasPSelect.Fecha;
                txtPlacas.Text = ModelComprasP.ComprasPSelect.Placas;
                cmbAnalista.SelectedItem = ModelComprasP.ComprasPSelect.Analista;
                txtSello1.Text = ModelComprasP.ComprasPSelect.Sello1;
                txtSello2.Text = ModelComprasP.ComprasPSelect.Sello2;
                cmbProducto.SelectedItem = ModelComprasP.ComprasPSelect.TipoProducto;
                txtDensidad.Text = Convert.ToString(ModelComprasP.ComprasPSelect.Densidad);
                txtGrasa.Text = Convert.ToString(ModelComprasP.ComprasPSelect.Grasa);
                txtSNG.Text = Convert.ToString(ModelComprasP.ComprasPSelect.SNG);
                txtST.Text = Convert.ToString(ModelComprasP.ComprasPSelect.ST);
                txtCrioscopia.Text = Convert.ToString(ModelComprasP.ComprasPSelect.Crioscopia);
                txtProteina.Text = Convert.ToString(ModelComprasP.ComprasPSelect.Proteina);
                txtKilos.Text = Convert.ToString(ModelComprasP.ComprasPSelect.Kilos);
                txtLitros.Text = Convert.ToString(ModelComprasP.ComprasPSelect.Litros);
            }
            else
            {
                MessageBox.Show(@"debe de seleccionar una fila");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ModelComprasP.DisplayInExcell();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }
    }
}