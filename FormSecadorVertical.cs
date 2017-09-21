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
        }
        private void LlenarGridView()
        {
            foreach (var item in ModelSecadorVertical.Llenargrid())
            {
                var row = (DataGridViewRow)dtgVertical.Rows[0].Clone();
                row.Cells[0].Value = item.IdLinea;
                row.Cells[1].Value = item.Circuito;
                row.Cells[2].Value = item.MInicial;
                row.Cells[3].Value = item.MFinal;
                row.Cells[4].Value = item.MEnjuague;
                row.Cells[5].Value = item.TAInicial;
                row.Cells[6].Value = item.TAFinal;
                row.Cells[7].Value = item.TAEnjuague;
                row.Cells[8].Value = item.TTA;
                row.Cells[9].Value = item.TipoLavado;
                row.Cells[10].Value = item.TLInicial;
                row.Cells[11].Value = item.TLFinal;
                row.Cells[12].Value = item.TLEnjuague;
                row.Cells[13].Value = item.TTLavado;
                row.Cells[14].Value = item.Color1;
                row.Cells[15].Value = item.Color2;
                row.Cells[16].Value = item.Titulacion;
                row.Cells[17].Value = item.RT1;
                row.Cells[18].Value = item.RT2;
                row.Cells[19].Value = item.Operador;
                row.Cells[20].Value = item.Analista;
                dtgVertical.Rows.Add(row);
            }
        }
        private void LlenarCombopuestos()
        {/*
            foreach (var item in ModelRecepcion.Llenarcombo())
                cmbCircuito.Items.Add(item.Circuito);
            foreach (var item in ModelRecepcion.Llenarcombo())
                cmbLavado.Items.Add(item.TipoLavado);
            foreach (var item in ModelRecepcion.Llenarcombo())
                cmbSolucion.Items.Add(item.Color1);
            foreach (var item in ModelRecepcion.Llenarcombo())
                cmbSolucion2.Items.Add(item.Color2);
            foreach (var item in ModelRecepcion.Llenarcombo())
                cmbTitulacion.Items.Add(item.Titulacion);
            foreach (var item in ModelRecepcion.Llenarcombo())
                cmbOperador.Items.Add(item.Operador);
            foreach (var item in ModelRecepcion.Llenarcombo())
                cmbAnalista.Items.Add(item.Analista);
                */
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
            ModelSecadorVertical pSV = new ModelSecadorVertical();
            pSV.IdLinea = ModelSecadorVertical.SVerticalSelect.IdLinea;
            pSV.Circuito = cmbCircuito.SelectedItem.ToString();
            pSV.Fecha = dtpSecadorVertical.Text.Trim();
            pSV.MInicial = txtMInicial.Text.Trim();
            pSV.MFinal = txtMFinal.Text.Trim();
            pSV.MEnjuague = txtMEnjuague.Text.Trim();
            pSV.TAInicial = txtTAInicial.Text.Trim();
            pSV.TAFinal = txtTAFinal.Text.Trim();
            pSV.TAEnjuague = txtTAEnjuague.Text.Trim();
            pSV.TTA = lblTTA.Text.Trim();
            pSV.TipoLavado = cmbLavado.SelectedItem.ToString();
            pSV.TLInicial = txtTLInicial.Text.Trim();
            pSV.TLFinal = txtTLFinal.Text.Trim();
            pSV.TLEnjuague = txtTLEnjuague.Text.Trim();
            pSV.TTLavado = lblTTL.Text.Trim();
            pSV.Color1 = cmbSolucion.SelectedItem.ToString();
            pSV.Color2 = cmbSolucion2.SelectedItem.ToString();
            pSV.Titulacion = cmbTitulacion.SelectedItem.ToString();
            pSV.RT1 = txtRT1.Text.Trim();
            pSV.RT2 = txtRT2.Text.Trim();
            pSV.Operador = cmbOperador.SelectedItem.ToString();
            pSV.Analista = cmbAnalista.SelectedItem.ToString();

         
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
            if (ModelSecadorVertical.Eliminar(ModelSecadorVertical.SVerticalSelect.IdLinea,
                    ModelSecadorVertical.SVerticalSelect.IdLinea) > 0)
            {
                MessageBox.Show(@"Registro Eliminado Correctamente!", @"Registro Eliminado", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                MessageBox.Show(@"No Se Pudo Eliminar El Registro", @"Registro No Eliminado", MessageBoxButtons.OK,
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
            dtgVertical.DataSource = ModelSecadorVertical.Buscar(dtpSecadorVertical.Text, cmbLavado.Text, cmbTitulacion.Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ModelSecadorVertical.DisplayInExcel();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
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
    }
}