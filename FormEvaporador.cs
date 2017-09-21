using System;
using System.Windows.Forms;
using ProyectoNutrical.Models;

namespace ProyectoNutrical
{
    public partial class FormEvaporador : Form
    {
        public FormEvaporador()
        {
            InitializeComponent();
            LlenarCombopuestos();
            LlenarGridView();
        }
        
        private void LlenarGridView()
        {
            foreach (var item in ModelEvaporador.Llenargrid())
            {
                var row = (DataGridViewRow)dtgEvaporador.Rows[0].Clone();
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
                dtgEvaporador.Rows.Add(row);
            }
        }
        private void LlenarCombopuestos()
        {
            /*
            foreach (var item in ModelRecepcion.Llenarcombo())
                cmbCircuito.Items.Add(item.Circuito);
            foreach (var item in ModelRecepcion.Llenarcombo())
                cmbLavado.Items.Add(item.TipoLavado);
            foreach (var item in ModelRecepcion.Llenarcombo())
                cmbSolucion.Items.Add(item.Color1);
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
            var pEvaporador = new ModelEvaporador
            {
                Circuito = cmbCircuito.SelectedItem.ToString(),
                Fecha = dtpEvaporador.Value.Year + "/" + dtpEvaporador.Value.Month + "/" + dtpEvaporador.Value.Day +
                        "/" + dtpEvaporador.Value.Hour + "/" + dtpEvaporador.Value.Minute + "/" +
                        dtpEvaporador.Value.Second,
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
                Color2 = cmbSolucion.SelectedItem.ToString(),
                Titulacion = cmbTitulacion.SelectedItem.ToString(),
                RT1 = txtRT1.Text.Trim(),
                RT2 = txtRT2.Text.Trim(),
                Operador = cmbOperador.SelectedItem.ToString(),
                Analista = cmbAnalista.SelectedItem.ToString()
            };
            var resultado = ModelEvaporador.Agregar(pEvaporador);

            if (resultado > 0)
                MessageBox.Show(@"Registro Guardado Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Guardar El Registro", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Esta Seguro Que Desea Eliminar El Registro", @"Estas Seguro??",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (ModelEvaporador.Eliminar(ModelEvaporador.EvaporadorSelect.IdLinea,
                    ModelEvaporador.EvaporadorSelect.IdLinea) > 0)
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
            dtgEvaporador.DataSource = ModelRecepcion.Buscar(dtpEvaporador.Text, cmbLavado.Text, cmbTitulacion.Text);
        }

        private void toolStripBtnActualizar_Click(object sender, EventArgs e)
        {
            ModelEvaporador pEvaporador = new ModelEvaporador();
            pEvaporador.IdLinea = ModelEvaporador.EvaporadorSelect.IdLinea;
            pEvaporador.Circuito = cmbCircuito.SelectedItem.ToString();
            pEvaporador.Fecha = dtpEvaporador.Text.Trim();
            pEvaporador.MInicial = txtMInicial.Text.Trim();
            pEvaporador.MFinal = txtMFinal.Text.Trim();
            pEvaporador.MEnjuague = txtMEnjuague.Text.Trim();
            pEvaporador.TAInicial = txtTAInicial.Text.Trim();
            pEvaporador.TAFinal = txtTAFinal.Text.Trim();
            pEvaporador.TAEnjuague = txtTAEnjuague.Text.Trim();
            pEvaporador.TTA = lblTTA.Text.Trim();
            pEvaporador.TipoLavado = cmbLavado.SelectedItem.ToString();
            pEvaporador.TLInicial = txtTLInicial.Text.Trim();
            pEvaporador.TLFinal = txtTLFinal.Text.Trim();
            pEvaporador.TLEnjuague = txtTLEnjuague.Text.Trim();
            pEvaporador.TTLavado = lblTTL.Text.Trim();
            pEvaporador.Color1 = cmbSolucion.SelectedItem.ToString();
            pEvaporador.Color2 = cmbSolucion2.SelectedItem.ToString();
            pEvaporador.Titulacion = cmbTitulacion.SelectedItem.ToString();
            pEvaporador.RT1 = txtRT1.Text.Trim();
            pEvaporador.RT2 = txtRT2.Text.Trim();
            pEvaporador.Operador = cmbOperador.SelectedItem.ToString();
            pEvaporador.Analista = cmbAnalista.SelectedItem.ToString();

            if (ModelEvaporador.Actualizar(pEvaporador) > 0)
            {
                MessageBox.Show("Los Datos Se Actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
                MessageBox.Show("No Se Pudo Actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ModelEvaporador.DisplayInExcel();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            cmbCircuito.Items.Clear();
            cmbSolucion2.Items.Clear();
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
            cmbTitulacion.Items.Clear();
            txtRT1.Clear();
            txtRT2.Clear();
            cmbOperador.Items.Clear();
            cmbAnalista.Items.Clear();
        }
    }
}