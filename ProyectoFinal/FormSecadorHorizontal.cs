using ProyectoNutrical.Models;
using System;
using System.Windows.Forms;

namespace ProyectoNutrical
{
    public partial class FormSecadorHorizontal : Form
    {
        public FormSecadorHorizontal()
        {
            InitializeComponent();
            LlenarCombopuestos();
            LlenarGridView();
            cmbCircuito.SelectedIndex = 0;
        }
        private void LlenarGridView()
        {
            foreach (var item in ModelSecadorHorizontal.Llenargrid())
            {
                var row = (DataGridViewRow)dtgHorizontal.Rows[0].Clone();
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
                dtgHorizontal.Rows.Add(row);
            }
        }
        private void LlenarCombopuestos()
        {
            foreach (var item in ModelTrabajadores.LlenarcomboTrabajadores(1))
                cmbOperador.Items.Add(item.Nombre);
            foreach (var item in ModelTrabajadores.LlenarcomboTrabajadores(2))
                cmbAnalista.Items.Add(item.Nombre);
        }
        private void toolStripBtnGuardar_Click(object sender, EventArgs e)
        {
            var pSH = new ModelSecadorHorizontal
            {
                Circuito = cmbCircuito.SelectedItem.ToString(),
                Fecha = dtpHorizontal.Value.Year + "/" + dtpHorizontal.Value.Month + "/" + dtpHorizontal.Value.Day +
                "/" + dtpHorizontal.Value.Hour + "/" + dtpHorizontal.Value.Minute + "/" + dtpHorizontal.Value.Second,
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
                Color1 = cmbSolucion.SelectedItem.ToString(),
                Color2 = cmbSolucion2.SelectedItem.ToString(),
                Titulacion = cmbTitulacion.SelectedItem.ToString(),
                RT1 = txtRT1.Text.Trim(),
                RT2 = txtRT2.Text.Trim(),
                Operador = cmbOperador.SelectedItem.ToString(),
                Analista = cmbAnalista.SelectedItem.ToString()
            };

            if (ModelSecadorHorizontal.Agregar(pSH) > 0)
            {
                MessageBox.Show(@"Registro Guardado Con Exito!!", @"Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarGrid();
            }
            else
                MessageBox.Show(@"No Se Pudo Guardar El Registro", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void toolStripBtnActualizar_Click(object sender, EventArgs e)
        {

            ModelSecadorHorizontal pSH = new ModelSecadorHorizontal
            {
                IdLinea = ModelSecadorHorizontal.SHorizontalSelect.IdLinea,
                Circuito = cmbCircuito.SelectedItem.ToString(),
                Fecha = dtpHorizontal.Value.Year + "/" + dtpHorizontal.Value.Month + "/" + dtpHorizontal.Value.Day +
                "/" + dtpHorizontal.Value.Hour + "/" + dtpHorizontal.Value.Minute + "/" + dtpHorizontal.Value.Second,
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
                Color1 = cmbSolucion.SelectedItem.ToString(),
                Color2 = cmbSolucion2.SelectedItem.ToString(),
                Titulacion = cmbTitulacion.SelectedItem.ToString(),
                RT1 = txtRT1.Text.Trim(),
                RT2 = txtRT2.Text.Trim(),
                Operador = cmbOperador.SelectedItem.ToString(),
                Analista = cmbAnalista.SelectedItem.ToString()
            };

            if (ModelSecadorHorizontal.Actualizar(pSH) > 0)
            {
                MessageBox.Show("Los Datos Se Actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarGrid();
            }
            else
                MessageBox.Show("No Se Pudo Actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           
        }

        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Esta Seguro Que Desea Eliminar El Registro", @"Estas Seguro??",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (ModelSecadorHorizontal.Eliminar(ModelSecadorHorizontal.SHorizontalSelect.IdLinea) > 0)
            {
                MessageBox.Show(@"Registro Eliminado Correctamente!", @"Registro Eliminado", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                LimpiarGrid();
            }
            else
            {
                MessageBox.Show(@"Se Cancelo La Eliminacion", @"Eliminacion Cancelada", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripBtnBuscar_Click(object sender, EventArgs e)
        {
            var encontro = true;
            foreach (var item in ModelSecadorHorizontal.Buscar(cmbCircuito.SelectedItem.ToString()))
            {
                if (encontro)
                {
                    dtgHorizontal.Rows.Clear();
                    dtgHorizontal.Refresh();
                }
                var row = (DataGridViewRow)dtgHorizontal.Rows[0].Clone();
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
                dtgHorizontal.Rows.Add(row);
                encontro = false;
            }
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
            cmbSolucion.Items.Clear();
            cmbSolucion2.Items.Clear();
            cmbTitulacion.Items.Clear();
            txtRT1.Clear();
            txtRT2.Clear();
            cmbOperador.Items.Clear();
            cmbAnalista.Items.Clear();
        }

        private void exportacionTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelSecadorHorizontal.DisplayInExcel();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void exportacionFechaYMuestrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelSecadorHorizontal.DisplayInExcelMuestras();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void exportacionFechaYTitulacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelSecadorHorizontal.DisplayInExcelTitulaciones();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void dtgHorizontal_DoubleClick(object sender, EventArgs e)
        {
            if (dtgHorizontal.SelectedRows.Count == 1)
            {
                if (dtgHorizontal.CurrentRow != null)
                    ModelSecadorHorizontal.ObtenerSH(Convert.ToInt32(dtgHorizontal.CurrentRow.Cells[0].Value));
                cmbCircuito.SelectedItem = ModelSecadorHorizontal.SHorizontalSelect.Circuito;
                dtpHorizontal.Text = ModelSecadorHorizontal.SHorizontalSelect.Fecha;
                txtMInicial.Text = ModelSecadorHorizontal.SHorizontalSelect.MEnjuague;
                txtMFinal.Text = ModelEvaporador.EvaporadorSelect.MFinal;
                txtMEnjuague.Text = ModelSecadorHorizontal.SHorizontalSelect.MEnjuague;
                txtTAInicial.Text = ModelSecadorHorizontal.SHorizontalSelect.TAInicial;
                txtTAFinal.Text = ModelSecadorHorizontal.SHorizontalSelect.TAFinal;
                txtTAEnjuague.Text = ModelSecadorHorizontal.SHorizontalSelect.TAEnjuague;
                lblTTA.Text = ModelSecadorHorizontal.SHorizontalSelect.TTA;
                cmbLavado.SelectedItem = ModelSecadorHorizontal.SHorizontalSelect.TipoLavado;
                txtTLInicial.Text = ModelSecadorHorizontal.SHorizontalSelect.TLInicial;
                txtTLFinal.Text = ModelSecadorHorizontal.SHorizontalSelect.TLFinal;
                txtTLEnjuague.Text = ModelSecadorHorizontal.SHorizontalSelect.TLEnjuague;
                lblTTL.Text = ModelSecadorHorizontal.SHorizontalSelect.TTLavado;
                cmbSolucion.SelectedItem = ModelSecadorHorizontal.SHorizontalSelect.Color1;
                cmbSolucion2.SelectedItem = ModelSecadorHorizontal.SHorizontalSelect.Color2;
                cmbTitulacion.SelectedItem = ModelSecadorHorizontal.SHorizontalSelect.Titulacion;
                txtRT1.Text = ModelSecadorHorizontal.SHorizontalSelect.RT1;
                txtRT2.Text = ModelSecadorHorizontal.SHorizontalSelect.RT2;
                cmbOperador.SelectedItem = ModelSecadorHorizontal.SHorizontalSelect.Operador;
                cmbAnalista.SelectedItem = ModelSecadorHorizontal.SHorizontalSelect.Analista;
            }
            else
            {
                MessageBox.Show(@"debe de seleccionar una fila");
            }
        }

        public void LimpiarGrid()
        {
            dtgHorizontal.Rows.Clear();
            dtgHorizontal.Refresh();
            LlenarGridView();
        }
    }
}