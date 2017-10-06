using System;
using ProyectoNutrical.Models;
using System.Windows.Forms;

namespace ProyectoNutrical
{
    public partial class FormCuartoHumedo : Form
    {
        public FormCuartoHumedo()
        {
            InitializeComponent();
            LlenarGridView();
            LlenarCombopuestos();

            cmbCircuito.SelectedIndex = 0;
        }
        private void LlenarGridView()
        {
            foreach (var item in ModelCuartoHumedo.LlenarGridView())
            {
                var row = (DataGridViewRow)dtgCuartoHumedo.Rows[0].Clone();
                row.Cells[0].Value = item.IdLinea;
                row.Cells[1].Value = item.Circuito;
                row.Cells[2].Value = item.Fecha;
                row.Cells[3].Value = item.MInicial;
                row.Cells[4].Value = item.MFinal;
                row.Cells[5].Value = item.MEnjuague;
                row.Cells[6].Value = item.TAInicial;
                row.Cells[7].Value = item.TAFinal;
                row.Cells[8].Value = item.TAEnjuague;
                row.Cells[9].Value = item.TTA;
                row.Cells[10].Value = item.TipoLavado;
                row.Cells[11].Value = item.TLInicial;
                row.Cells[12].Value = item.TLFinal;
                row.Cells[13].Value = item.TLEnjuague;
                row.Cells[14].Value = item.TTLavado;
                row.Cells[15].Value = item.Color1;
                row.Cells[16].Value = item.Color2;
                row.Cells[17].Value = item.Titulacion;
                row.Cells[18].Value = item.RT1;
                row.Cells[19].Value = item.RT2;
                row.Cells[20].Value = item.Operador;
                row.Cells[21].Value = item.Analista;
                dtgCuartoHumedo.Rows.Add(row);
            }

        }

        private void LlenarCombopuestos()
        {
            foreach (var item in ModelTrabajadores.LlenarcomboTrabajadores(1)) cmbOperador.Items.Add(item.Nombre);
            foreach (var item in ModelTrabajadores.LlenarcomboTrabajadores(2)) cmbAnalista.Items.Add(item.Nombre);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            cmbCircuito.Items.Clear();
            txtMInicial.Clear();
            txtMFinal.Clear();
            txtMEnjuague.Clear();
            txtTAInicial.Clear();
            txtTAFinal.Clear();
            txtTAEnjuague.Clear();
            cmbLavado.Items.Clear();
            txtTLInicial.Clear();
            txtTLFinal.Clear();
            txtTLEnjuague.Clear();
            cmbSolucion1.Items.Clear();
            cmbSolucion2.Items.Clear();
            cmbTitulacion.Items.Clear();
            txtRT1.Clear();
            txtRT2.Clear();
            cmbOperador.Items.Clear();
            cmbAnalista.Items.Clear();
        }

        private void toolStripBtnGuardar_Click(object sender, EventArgs e)
        {
            var pCH = new ModelCuartoHumedo
            {
                IdLinea = ModelCuartoHumedo.CuartoHumedoSelect.IdLinea,
                Circuito = cmbCircuito.SelectedItem.ToString(),
                Fecha = dtpCuartoHumedo.Value.Year + "/" + dtpCuartoHumedo.Value.Month + "/" + dtpCuartoHumedo.Value.Day + "/" +
                      dtpCuartoHumedo.Value.Hour + "/" + dtpCuartoHumedo.Value.Minute + "/" + dtpCuartoHumedo.Value.Second,
                MInicial = txtMInicial.Text.Trim(),
                MFinal = txtMFinal.Text.Trim(),
                MEnjuague = txtMEnjuague.Text.Trim(),
                TAInicial = txtTAInicial.Text.Trim(),
                TAFinal = txtTAFinal.Text.Trim(),
                TAEnjuague = txtTAEnjuague.Text.Trim(),
                TTA = lblTTA.Text.Trim(),
                TipoLavado = cmbLavado.SelectedItem.ToString(),
                TLInicial = txtTLInicial.Text.Trim(),
                TLFinal = txtTLFinal.Text.Trim(),
                TLEnjuague = txtTLEnjuague.Text.Trim(),
                TTLavado = lblTTL.Text.Trim(),
                Color1 = cmbSolucion1.SelectedItem.ToString(),
                Color2 = cmbSolucion2.SelectedItem.ToString(),
                Titulacion = cmbTitulacion.SelectedItem.ToString(),
                RT1 = txtRT1.Text.Trim(),
                RT2 = txtRT2.Text.Trim(),
                Operador = cmbOperador.SelectedItem.ToString(),
                Analista = cmbAnalista.SelectedItem.ToString()
            };
            var resultado = ModelCuartoHumedo.Agregar(pCH);

            if (resultado > 0)
            {
                MessageBox.Show(@"Captura Guardada Con Exito!!", @"Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarGrid();
            }
            else
                MessageBox.Show(@"No Se Pudo Guardar La Captura", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void toolStripBtnActualizar_Click(object sender, EventArgs e)
        {

            ModelCuartoHumedo pCH = new ModelCuartoHumedo
            {
                IdLinea = ModelCuartoHumedo.CuartoHumedoSelect.IdLinea,
                Circuito = cmbCircuito.SelectedItem.ToString(),
                Fecha = dtpCuartoHumedo.Value.Year + "/" + dtpCuartoHumedo.Value.Month + "/" + dtpCuartoHumedo.Value.Day + "/" +
                      dtpCuartoHumedo.Value.Hour + "/" + dtpCuartoHumedo.Value.Minute + "/" + dtpCuartoHumedo.Value.Second,
                MInicial = txtMInicial.Text.Trim(),
                MFinal = txtMFinal.Text.Trim(),
                MEnjuague = txtMEnjuague.Text.Trim(),
                TAInicial = txtTAInicial.Text.Trim(),
                TAFinal = txtTAFinal.Text.Trim(),
                TAEnjuague = txtTAEnjuague.Text.Trim(),
                TTA = lblTTA.Text.Trim(),
                TipoLavado = cmbLavado.SelectedItem.ToString(),
                TLInicial = txtTLInicial.Text.Trim(),
                TLFinal = txtTLFinal.Text.Trim(),
                TLEnjuague = txtTLEnjuague.Text.Trim(),
                TTLavado = lblTTL.Text.Trim(),
                Color1 = cmbSolucion1.SelectedItem.ToString(),
                Color2 = cmbSolucion2.SelectedItem.ToString(),
                Titulacion = cmbTitulacion.SelectedItem.ToString(),
                RT1 = txtRT1.Text.Trim(),
                RT2 = txtRT2.Text.Trim(),
                Operador = cmbOperador.SelectedItem.ToString(),
                Analista = cmbAnalista.SelectedItem.ToString()
            };

            if (ModelCuartoHumedo.Actualizar(pCH) > 0)
            {
                MessageBox.Show("Los Datos Se Actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarGrid();
            }
            else
                MessageBox.Show("No Se Pudo Actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Deseas Eliminar La Captura", @"Estas Seguro??",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (ModelCuartoHumedo.Eliminar(ModelCuartoHumedo.CuartoHumedoSelect.IdLinea) > 0)
            {
                MessageBox.Show(@"Captura Eliminada Correctamente!", @"Captura Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarGrid();
            }
            else
            {
                MessageBox.Show(@"Se Cancelo La Eliminación", @"Eliminación Cancelada", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripBtnBuscar_Click(object sender, EventArgs e)
        {
            var encontro = true;
            foreach (var item in ModelCuartoHumedo.Buscar(cmbCircuito.SelectedItem.ToString()))
            {
                if (encontro)
                {
                    dtgCuartoHumedo.Rows.Clear();
                    dtgCuartoHumedo.Refresh();
                }
                var row = (DataGridViewRow)dtgCuartoHumedo.Rows[0].Clone();
                row.Cells[0].Value = item.IdLinea;
                row.Cells[1].Value = item.Circuito;
                row.Cells[2].Value = item.Fecha;
                row.Cells[3].Value = item.MInicial;
                row.Cells[4].Value = item.MFinal;
                row.Cells[5].Value = item.MEnjuague;
                row.Cells[6].Value = item.TAInicial;
                row.Cells[7].Value = item.TAFinal;
                row.Cells[8].Value = item.TAEnjuague;
                row.Cells[9].Value = item.TTA;
                row.Cells[10].Value = item.TipoLavado;
                row.Cells[11].Value = item.TLInicial;
                row.Cells[12].Value = item.TLFinal;
                row.Cells[13].Value = item.TLEnjuague;
                row.Cells[14].Value = item.TTLavado;
                row.Cells[15].Value = item.Color1;
                row.Cells[16].Value = item.Color2;
                row.Cells[17].Value = item.Titulacion;
                row.Cells[18].Value = item.RT1;
                row.Cells[19].Value = item.RT2;
                row.Cells[20].Value = item.Operador;
                row.Cells[21].Value = item.Analista;
                dtgCuartoHumedo.Rows.Add(row);
                encontro = false;
            }
        }

        private void dtgCuartoHumedo_DoubleClick(object sender, EventArgs e)
        {
            if (dtgCuartoHumedo.SelectedRows.Count == 1)
            {
                if (dtgCuartoHumedo.CurrentRow != null)
                    ModelCuartoHumedo.ObtenerCH(Convert.ToInt32(dtgCuartoHumedo.CurrentRow.Cells[0].Value));

                cmbCircuito.SelectedItem = ModelCuartoHumedo.CuartoHumedoSelect.Circuito;
                dtpCuartoHumedo.Text = ModelCuartoHumedo.CuartoHumedoSelect.Fecha;
                txtMInicial.Text = ModelCuartoHumedo.CuartoHumedoSelect.MEnjuague;
                txtMFinal.Text = ModelCuartoHumedo.CuartoHumedoSelect.MFinal;
                txtMEnjuague.Text = ModelCuartoHumedo.CuartoHumedoSelect.MEnjuague;
                txtTAInicial.Text = ModelCuartoHumedo.CuartoHumedoSelect.TAInicial;
                txtTAFinal.Text = ModelCuartoHumedo.CuartoHumedoSelect.TAFinal;
                txtTAEnjuague.Text = ModelCuartoHumedo.CuartoHumedoSelect.TAEnjuague;
                lblTTA.Text = ModelCuartoHumedo.CuartoHumedoSelect.TTA;
                cmbLavado.SelectedItem = ModelCuartoHumedo.CuartoHumedoSelect.TipoLavado;
                txtTLInicial.Text = ModelCuartoHumedo.CuartoHumedoSelect.TLInicial;
                txtTLFinal.Text = ModelCuartoHumedo.CuartoHumedoSelect.TLFinal;
                txtTLEnjuague.Text = ModelCuartoHumedo.CuartoHumedoSelect.TLEnjuague;
                lblTTL.Text = ModelCuartoHumedo.CuartoHumedoSelect.TTLavado;
                cmbSolucion1.SelectedItem = ModelCuartoHumedo.CuartoHumedoSelect.Color1;
                cmbSolucion2.SelectedItem = ModelCuartoHumedo.CuartoHumedoSelect.Color2;
                cmbTitulacion.SelectedItem = ModelCuartoHumedo.CuartoHumedoSelect.Titulacion;
                txtRT1.Text = ModelCuartoHumedo.CuartoHumedoSelect.RT1;
                txtRT2.Text = ModelCuartoHumedo.CuartoHumedoSelect.RT2;
                cmbOperador.SelectedItem = ModelCuartoHumedo.CuartoHumedoSelect.Operador;
                cmbAnalista.SelectedItem = ModelCuartoHumedo.CuartoHumedoSelect.Analista;
            }
            else
            {
                MessageBox.Show(@"debe de seleccionar una fila");
            }
        }

        private void exportacionTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelCuartoHumedo.DisplayInExcel();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void exportacionFechaYMuestrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelCuartoHumedo.DisplayInExcelMuestras();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void exportacionFechaYTitulacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelCuartoHumedo.DisplayInExcelTitulaciones();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        public void LimpiarGrid()
        {
            dtgCuartoHumedo.Rows.Clear();
            dtgCuartoHumedo.Refresh();
            LlenarGridView();
        }
    }
}
