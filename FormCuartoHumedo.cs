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
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            cmbCircuito.Items.Clear();
            cmbMuestra.Items.Clear();
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
                Muestra = cmbMuestra.SelectedItem.ToString(),
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
                MessageBox.Show(@"Captura Guardada Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Guardar La Captura", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
         }

        private void toolStripBtnActualizar_Click(object sender, EventArgs e)
        {

            var cTodo = new ModelCuartoHumedo
            {
                IdLinea = ModelCuartoHumedo.CuartoHumedoSelect.IdLinea,
                Circuito = cmbCircuito.SelectedItem.ToString(),
                Fecha = dtpCuartoHumedo.Value.Year + "/" + dtpCuartoHumedo.Value.Month + "/" + dtpCuartoHumedo.Value.Day + "/" +
                        dtpCuartoHumedo.Value.Hour + "/" + dtpCuartoHumedo.Value.Minute + "/" + dtpCuartoHumedo.Value.Second,
                Muestra = cmbMuestra.SelectedItem.ToString(),
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
            if (ModelCuartoHumedo.Actualizar(cTodo, 1) > 0)
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
            if (ModelCuartoHumedo.Eliminar(ModelCuartoHumedo.CuartoHumedoSelect.IdLinea) > 0)
            {
                MessageBox.Show(@"Captura Eliminada Correctamente!", @"Captura Eliminada", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                MessageBox.Show(@"No Se Pudo Eliminar La Captura", @"Captura No Eliminada", MessageBoxButtons.OK,
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
            dtgCuartoHumedo.DataSource = ModelCuartoHumedo.Buscar(dtpCuartoHumedo.Text, cmbLavado.Text, cmbTitulacion.Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ModelCuartoHumedo.DisplayInExcel();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }
    }
}
