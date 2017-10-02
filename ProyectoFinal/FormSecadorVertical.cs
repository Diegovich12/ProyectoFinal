using ProyectoNutrical.Models;
using System;
using System.Windows.Forms;

namespace ProyectoNutrical
{
    public partial class FormSecadorVertical : Form
    {
        public FormSecadorVertical()
        {
            InitializeComponent();
            LlenarCombopuestos();
            LlenarGridView();

            cmbCircuito.SelectedIndex = 0;
        }

        private void LlenarGridView()
        {
            foreach (var item in ModelSecadorVertical.Llenargrid())
            {
                var row = (DataGridViewRow)dtgVertical.Rows[0].Clone();
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
                dtgVertical.Rows.Add(row);
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
            var pSV = new ModelSecadorVertical
            {
                Circuito = cmbCircuito.SelectedItem.ToString(),
                Fecha = dtpSecadorVertical.Value.Year + "/" + dtpSecadorVertical.Value.Month + "/" + dtpSecadorVertical.Value.Day +
                "/" + dtpSecadorVertical.Value.Hour + "/" + dtpSecadorVertical.Value.Minute + "/" + dtpSecadorVertical.Value.Second,
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
            var resultado = ModelSecadorVertical.Agregar(pSV);

            if (resultado > 0)
                MessageBox.Show(@"Registro Guardado Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Guardar El Registro", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void toolStripBtnActualizar_Click(object sender, EventArgs e)
        {
            ModelSecadorVertical pSV = new ModelSecadorVertical
            {
                IdLinea = ModelSecadorVertical.SVerticalSelect.IdLinea,
                Circuito = cmbCircuito.SelectedItem.ToString(),
                Fecha = dtpSecadorVertical.Value.Year + "/" + dtpSecadorVertical.Value.Month + "/" + dtpSecadorVertical.Value.Day +
                "/" + dtpSecadorVertical.Value.Hour + "/" + dtpSecadorVertical.Value.Minute + "/" + dtpSecadorVertical.Value.Second,
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


            if (ModelSecadorVertical.Actualizar(pSV) > 0)
            {
                MessageBox.Show("Los Datos Se Actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No Se Pudo Actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Esta Seguro Que Desea Eliminar El Registro", @"Estas Seguro??",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (ModelSecadorVertical.Eliminar(ModelSecadorVertical.SVerticalSelect.IdLinea) > 0)
            {
                MessageBox.Show(@"Registro Eliminado Correctamente!", @"Registro Eliminado", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
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
            foreach (var item in ModelSecadorVertical.Buscar(cmbCircuito.SelectedItem.ToString()))
            {
                if (encontro)
                {
                    dtgVertical.Rows.Clear();
                    dtgVertical.Refresh();
                }
                var row = (DataGridViewRow)dtgVertical.Rows[0].Clone();
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
                dtgVertical.Rows.Add(row);
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
            ModelSecadorVertical.DisplayInExcel();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void exportacionFechaYMuestrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelSecadorVertical.DisplayInExcelMuestras();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void exportacionFechaYTitulacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelSecadorVertical.DisplayInExcelTitulaciones();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void dtgVertical_DoubleClick(object sender, EventArgs e)
        {
            if (dtgVertical.SelectedRows.Count == 1)
            {
                if (dtgVertical.CurrentRow != null)
                {
                    var idLinea = Convert.ToInt32(dtgVertical.CurrentRow.Cells[0].Value);
                    ModelSecadorVertical.ObtenerSV(idLinea);
                }
                cmbCircuito.SelectedItem = ModelSecadorVertical.SVerticalSelect.Circuito;
                dtpSecadorVertical.Text = ModelSecadorVertical.SVerticalSelect.Fecha;
                txtMInicial.Text = ModelSecadorVertical.SVerticalSelect.MEnjuague;
                txtMFinal.Text = ModelSecadorVertical.SVerticalSelect.MFinal;
                txtMEnjuague.Text = ModelSecadorVertical.SVerticalSelect.MEnjuague;
                txtTAInicial.Text = ModelSecadorVertical.SVerticalSelect.TAInicial;
                txtTAFinal.Text = ModelSecadorVertical.SVerticalSelect.TAFinal;
                txtTAEnjuague.Text = ModelSecadorVertical.SVerticalSelect.TAEnjuague;
                lblTTA.Text = ModelSecadorVertical.SVerticalSelect.TTA;
                cmbLavado.SelectedItem = ModelSecadorVertical.SVerticalSelect.TipoLavado;
                txtTLInicial.Text = ModelSecadorVertical.SVerticalSelect.TLInicial;
                txtTLFinal.Text = ModelSecadorVertical.SVerticalSelect.TLFinal;
                txtTLEnjuague.Text = ModelSecadorVertical.SVerticalSelect.TLEnjuague;
                lblTTL.Text = ModelSecadorVertical.SVerticalSelect.TTLavado;
                cmbSolucion.SelectedItem = ModelSecadorVertical.SVerticalSelect.Color1;
                cmbSolucion2.SelectedItem = ModelSecadorVertical.SVerticalSelect.Color2;
                cmbTitulacion.SelectedItem = ModelSecadorVertical.SVerticalSelect.Titulacion;
                txtRT1.Text = ModelSecadorVertical.SVerticalSelect.RT1;
                txtRT2.Text = ModelSecadorVertical.SVerticalSelect.RT2;
                cmbOperador.SelectedItem = ModelSecadorVertical.SVerticalSelect.Operador;
                cmbAnalista.SelectedItem = ModelSecadorVertical.SVerticalSelect.Analista;
            }
            else
            {
                MessageBox.Show(@"debe de seleccionar una fila");
            }
        }
    }
}