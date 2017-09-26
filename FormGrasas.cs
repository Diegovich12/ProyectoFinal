using System;
using ProyectoNutrical.Models;
using System.Windows.Forms;
using System.Drawing;

namespace ProyectoNutrical
{
    public partial class FormGrasas : Form
    {
        public FormGrasas()
        {
            InitializeComponent();
            LlenarCombopuestos();
            LlenarGridView();
            InitializeTimePicker();
        }
        private DateTimePicker timePicker;

        private void InitializeTimePicker()
        {
            timePicker = new DateTimePicker();
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.ShowUpDown = true;
            timePicker.Location = new Point(120, 100);
            timePicker.Width = 100;
            Controls.Add(timePicker);
        }
        [STAThread]
        private void LlenarGridView()
        {
            foreach (var item in ModelGrasas.Llenargrid())
            {
                var row = (DataGridViewRow)dtgGrasas.Rows[0].Clone();
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
                dtgGrasas.Rows.Add(row);
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
            var pGrasas = new ModelGrasas
            {
                Circuito = cmbCircuito.SelectedItem.ToString(),
                Fecha = dtpGrasas.Value.Year + "/" + dtpGrasas.Value.Month + "/" + dtpGrasas.Value.Day +
                "/" + dtpGrasas.Value.Hour + "/" + dtpGrasas.Value.Minute + "/" + dtpGrasas.Value.Second,
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
            var resultado = ModelGrasas.Agregar(pGrasas);

            if (resultado > 0)
                MessageBox.Show(@"Registro Guardado Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Guardar El Registro", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void toolStripBtnActualizar_Click(object sender, EventArgs e)
        {
            ModelGrasas pGR = new ModelGrasas();
            pGR.IdLinea = ModelGrasas.GrasasSelect.IdLinea;
            pGR.Circuito = cmbCircuito.SelectedItem.ToString();
            pGR.Fecha = dtpGrasas.Text.Trim();
            pGR.MInicial = txtMInicial.Text.Trim();
            pGR.MFinal = txtMFinal.Text.Trim();
            pGR.MEnjuague = txtMEnjuague.Text.Trim();
            pGR.TAInicial = txtTAInicial.Text.Trim();
            pGR.TAFinal = txtTAFinal.Text.Trim();
            pGR.TAEnjuague = txtTAEnjuague.Text.Trim();
            pGR.TTA = lblTTA.Text.Trim();
            pGR.TipoLavado = cmbLavado.SelectedItem.ToString();
            pGR.TLInicial = txtTLInicial.Text.Trim();
            pGR.TLFinal = txtTLFinal.Text.Trim();
            pGR.TLEnjuague = txtTLEnjuague.Text.Trim();
            pGR.TTLavado = lblTTL.Text.Trim();
            pGR.Color1 = cmbSolucion.SelectedItem.ToString();
            pGR.Color2 = cmbSolucion2.SelectedItem.ToString();
            pGR.Titulacion = cmbTitulacion.SelectedItem.ToString();
            pGR.RT1 = txtRT1.Text.Trim();
            pGR.RT2 = txtRT2.Text.Trim();
            pGR.Operador = cmbOperador.SelectedItem.ToString();
            pGR.Analista = cmbAnalista.SelectedItem.ToString();

            if (ModelGrasas.Actualizar(pGR) > 0)
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
            if (ModelGrasas.Eliminar(ModelGrasas.GrasasSelect.IdLinea) > 0)
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
            foreach (var item in ModelGrasas.Buscar(cmbCircuito.SelectedItem.ToString()))
            {
                if (encontro)
                {
                    dtgGrasas.Rows.Clear();
                    dtgGrasas.Refresh();
                }
                var row = (DataGridViewRow)dtgGrasas.Rows[0].Clone();
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
                dtgGrasas.Rows.Add(row);
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
            ModelGrasas.DisplayInExcel();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void exportacionFechaYMuestrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelGrasas.DisplayInExcelMuestras();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void exportacionFechaYTitulacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelGrasas.DisplayInExcelTitulaciones();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void dtgGrasas_DoubleClick(object sender, EventArgs e)
        {
            if (dtgGrasas.SelectedRows.Count == 1)
            {
                if (dtgGrasas.CurrentRow != null)
                {
                    var idLinea = Convert.ToInt32(dtgGrasas.CurrentRow.Cells[0].Value);
                    ModelGrasas.ObtenerGR(idLinea);
                }
                cmbCircuito.SelectedItem = ModelGrasas.GrasasSelect.Circuito;
                dtpGrasas.Text = ModelGrasas.GrasasSelect.Fecha;
                txtMInicial.Text = ModelGrasas.GrasasSelect.MEnjuague;
                txtMFinal.Text = ModelGrasas.GrasasSelect.MFinal;
                txtMEnjuague.Text = ModelGrasas.GrasasSelect.MEnjuague;
                txtTAInicial.Text = ModelGrasas.GrasasSelect.TAInicial;
                txtTAFinal.Text = ModelGrasas.GrasasSelect.TAFinal;
                txtTAEnjuague.Text = ModelGrasas.GrasasSelect.TAEnjuague;
                lblTTA.Text = ModelGrasas.GrasasSelect.TTA;
                cmbLavado.SelectedItem = ModelGrasas.GrasasSelect.TipoLavado;
                txtTLInicial.Text = ModelGrasas.GrasasSelect.TLInicial;
                txtTLFinal.Text = ModelGrasas.GrasasSelect.TLFinal;
                txtTLEnjuague.Text = ModelGrasas.GrasasSelect.TLEnjuague;
                lblTTL.Text = ModelGrasas.GrasasSelect.TTLavado;
                cmbSolucion.SelectedItem = ModelGrasas.GrasasSelect.Color1;
                cmbSolucion2.SelectedItem = ModelGrasas.GrasasSelect.Color2;
                cmbTitulacion.SelectedItem = ModelGrasas.GrasasSelect.Titulacion;
                txtRT1.Text = ModelGrasas.GrasasSelect.RT1;
                txtRT2.Text = ModelGrasas.GrasasSelect.RT2;
                cmbOperador.SelectedItem = ModelGrasas.GrasasSelect.Operador;
                cmbAnalista.SelectedItem = ModelGrasas.GrasasSelect.Analista;
            }
            else
            {
                MessageBox.Show(@"debe de seleccionar una fila");
            }
        }
    }
}