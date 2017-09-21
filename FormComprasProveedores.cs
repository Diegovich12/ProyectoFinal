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
        }
        public void limpiarcp()
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
                row.Cells[7].Value = item.FechaLlegada;
                row.Cells[8].Value = item.Placas;
                row.Cells[9].Value = item.Analista;
                row.Cells[10].Value = item.Sello1;
                row.Cells[11].Value = item.Sello2;
                row.Cells[12].Value = item.TipoProducto;
                row.Cells[13].Value = item.Densidad;
                row.Cells[14].Value = item.Grasa;
                row.Cells[15].Value = item.SNG;
                row.Cells[16].Value = item.ST;
                row.Cells[17].Value = item.Crioscopia;
                row.Cells[18].Value = item.Proteina;
                row.Cells[19].Value = item.Kilos;
                row.Cells[20].Value = item.Litros;
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


        private void toolStripBtnGuardar_Click(object sender, EventArgs e)
        {
            var pComprasP = new ModelComprasP
            {
               /* IdCompra = int.Parse(txtCompra.Text),
                Fecha = dtpFecha.Value.Year + "/" + dtpFecha.Value.Month + "/" + dtpFecha.Value.Day + "/" +
                      dtpFecha.Value.Hour + "/" + dtpFecha.Value.Minute + "/" + dtpFecha.Value.Second,
                NoPipa = double.Parse(txtNoPipa.Text),
                Proveedor = double.Parse(cmbProveedor.SelectedItem.ToString(),
                Rancho = double.Parse(cmbRancho.SelectedItem.ToString(),
                NoRemision = double.Parse(txtRemision.Text),
                FechaLlegada = dtpFechaL.Value.Year + "/" + dtpFechaL.Value.Month + "/" + dtpFechaL.Value.Day + "/" +
                      dtpFechaL.Value.Hour + "/" + dtpFechaL.Value.Minute + "/" + dtpFechaL.Value.Second,
                Placas = double.Parse(txtPlacas.Text),
                Analista = double.Parse(cmbAnalista.SelectedItem.ToString(),
                Sello1 = double.Parse(txtSello1.Text),
                Sello2 = double.Parse(txtSello2.Text),
                TipoProducto = double.Parse(cmbProducto.SelectedItem.ToString(),
                Densidad = double.Parse(txtDensidad.Text),
                Grasa = double.Parse(txtGrasa.Text),
                SNG = double.Parse(txtSNG.Text),
                ST = double.Parse(txtST.Text),
                Crioscopia = double.Parse(txtCrioscopia.Text),
                Proteina = double.Parse(txtProteina.Text),
                Kilos = double.Parse(txtKilos.Text),
                Litros = double.Parse(txtLitros.Text)*/
            };
            var resultado = ModelComprasP.Agregar(pComprasP);

            if (resultado > 0)
                MessageBox.Show(@"Compra Guardada Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Guardar La Compra", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void toolStripBtnModificar_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
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
                limpiarcp();
            }
            else
            {
                MessageBox.Show(@"Se Cancelo La Eliminacion", @"Eliminacion Cancelada", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripBtnBuscar_Click(object sender, EventArgs e)
        {
            dtgCompras.DataSource =
                ModelComprasP.Buscar(txtRemision.Text);
        }
    }
}