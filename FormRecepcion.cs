using System;
using System.Windows.Forms;
using ProyectoNutrical.Models;

namespace ProyectoNutrical
{
    public partial class FormRecepcion : Form
    {
        public FormRecepcion()
        {
            InitializeComponent();
            LlenarCombopuestos();
            LlenarGridView();
        }
       
        private void LlenarGridView()
        {         
            foreach (var item in ModelRecepcion.LlenarGridView())
            {
                var row = (DataGridViewRow)dtgRecepcion.Rows[0].Clone();
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
                dtgRecepcion.Rows.Add(row);
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
            var pRecepcion = new ModelRecepcion
            {
                IdLinea = ModelRecepcion.RecepcionSelect.IdLinea,
                Circuito = cmbCircuito.SelectedItem.ToString(),
                Fecha = dtpRecepcion.Value.Year + "/" + dtpRecepcion.Value.Month + "/" + dtpRecepcion.Value.Day + "/" +
                        dtpRecepcion.Value.Hour + "/" + dtpRecepcion.Value.Minute + "/" + dtpRecepcion.Value.Second,
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
                TLEnjuague = txtTLEnjuague.Text.Trim(), //edte
                TTLavado = lblTTL.Text.Trim(),
                Color1 = cmbSolucion1.SelectedItem.ToString(),
                Color2 = cmbSolucion2.SelectedItem.ToString(),
                Titulacion = cmbTitulacion.SelectedItem.ToString(),
                RT1 = txtRT1.Text.Trim(),
                RT2 = txtRT2.Text.Trim(),
                Operador = cmbOperador.SelectedItem.ToString(),
                Analista = cmbAnalista.SelectedItem.ToString()
            };
            var resultado = ModelRecepcion.Agregar(pRecepcion);

            if (resultado > 0)
                MessageBox.Show(@"Captura Guardada Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Guardar La Captura", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void toolStripBtnActualizar_Click(object sender, EventArgs e)
        {
            var rTodo = new ModelRecepcion
            {
                IdLinea = ModelRecepcion.RecepcionSelect.IdLinea,
                Circuito = cmbCircuito.SelectedItem.ToString(),
                Fecha = dtpRecepcion.Value.Year + "/" + dtpRecepcion.Value.Month + "/" + dtpRecepcion.Value.Day + "/" +
                        dtpRecepcion.Value.Hour + "/" + dtpRecepcion.Value.Minute + "/" + dtpRecepcion.Value.Second,
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
            if (ModelRecepcion.Actualizar(rTodo) > 0)
                MessageBox.Show(@"Captura Actualizada Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Actualizar La Captura", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
        }

        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Deseas Eliminar La Captura", @"Estas Seguro??",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (ModelRecepcion.Eliminar(ModelRecepcion.RecepcionSelect.IdLinea) > 0)
            {
                MessageBox.Show(@"Captura Eliminada Correctamente!", @"Captura Eliminada", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
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
            foreach (var item in ModelRecepcion.Buscar(cmbCircuito.SelectedItem.ToString()))
            {
                if (encontro)
                {
                    dtgRecepcion.Rows.Clear();
                    dtgRecepcion.Refresh();
                }
                var row = (DataGridViewRow)dtgRecepcion.Rows[0].Clone();
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
                dtgRecepcion.Rows.Add(row);
                encontro = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ModelRecepcion.DisplayInExcel();
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
            cmbSolucion1.Items.Clear();
            cmbSolucion2.Items.Clear();
            cmbTitulacion.Items.Clear();
            txtRT1.Clear();
            txtRT2.Clear();
            cmbOperador.Items.Clear();
            cmbAnalista.Items.Clear(); 
        }

        private void dtgRecepcion_DoubleClick(object sender, EventArgs e)
        {
            if (dtgRecepcion.SelectedRows.Count == 1)
            {
                if (dtgRecepcion.CurrentRow != null)
                {
                    var idLinea = Convert.ToInt32(dtgRecepcion.CurrentRow.Cells[0].Value);
                    ModelRecepcion.ObtenerRecepcion(idLinea);
                }
                cmbCircuito.SelectedItem = ModelRecepcion.RecepcionSelect.Circuito;
                dtpRecepcion.Text = ModelRecepcion.RecepcionSelect.Fecha;
                txtMInicial.Text = ModelRecepcion.RecepcionSelect.MEnjuague;
                txtMFinal.Text = ModelRecepcion.RecepcionSelect.MFinal;
                txtMEnjuague.Text = ModelRecepcion.RecepcionSelect.MEnjuague;
                txtTAInicial.Text = ModelRecepcion.RecepcionSelect.TAInicial;
                txtTAFinal.Text = ModelRecepcion.RecepcionSelect.TAFinal;
                txtTAEnjuague.Text = ModelRecepcion.RecepcionSelect.TAEnjuague;
                lblTTA.Text = ModelRecepcion.RecepcionSelect.TTA;
                cmbLavado.SelectedItem = ModelRecepcion.RecepcionSelect.TipoLavado;
                txtTLInicial.Text = ModelRecepcion.RecepcionSelect.TLInicial;
                txtTLFinal.Text = ModelRecepcion.RecepcionSelect.TLFinal;
                txtTLEnjuague.Text = ModelRecepcion.RecepcionSelect.TLEnjuague;
                lblTTL.Text = ModelRecepcion.RecepcionSelect.TTLavado;
                cmbSolucion1.SelectedItem = ModelRecepcion.RecepcionSelect.Color1;
                cmbSolucion2.SelectedItem = ModelRecepcion.RecepcionSelect.Color2;
                cmbTitulacion.SelectedItem = ModelRecepcion.RecepcionSelect.Titulacion;
                txtRT1.Text = ModelRecepcion.RecepcionSelect.RT1;
                txtRT2.Text = ModelRecepcion.RecepcionSelect.RT2;
                cmbOperador.SelectedItem = ModelRecepcion.RecepcionSelect.Operador;
                cmbAnalista.SelectedItem = ModelRecepcion.RecepcionSelect.Analista;
            }
            else
            {
                MessageBox.Show(@"debe de seleccionar una fila");
            }
        }

        private void exportacionFechaYMuestrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelRecepcion.DisplayInExcelMuestras();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void exportacionFechaYTitulacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelRecepcion.DisplayInExcelTitulaciones();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }
    }
}