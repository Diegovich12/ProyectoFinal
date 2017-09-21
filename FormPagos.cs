using ProyectoNutrical.Models;
using System;
using System.Windows.Forms;

namespace ProyectoNutrical
{
    public partial class FormPagos : Form
    {
        public FormPagos()
        {
            InitializeComponent();
            LlenarGridView();
        }
        public void limpiarp()
        {
            txtIDPago.Clear();
            txtKilos.Clear();
            txtLitros.Clear();
            txtTemperatura.Clear();
            txtAcidez.Clear();
            txtpH.Clear();
            txtCrioscopia.Clear();
            txtGrasa.Clear();
            txtDensidad.Clear();
            txtSNG.Clear();
            txtST.Clear();
            cmbAlcohol.Items.Clear();
            cmbNeutralizantes.Items.Clear();
            cmbEbullicion.Items.Clear();
            cmbEbullicion.Items.Clear();
            txtOlor.Clear();
            txtTermofilicos.Clear();
            txtMicro.Clear();
            txtDisposicion.Clear();
            txtSTArena.Clear();
            txtProteina.Clear();
            txtKilosSAP.Clear();
            txtLitrosSAP.Clear();

        }
        private void LlenarGridView()
        {
            foreach (var item in ModelPagos.Llenargrid())
            {
                var row = (DataGridViewRow)dtgPagos.Rows[0].Clone();
                row.Cells[0].Value = item.IdPagos;
                row.Cells[1].Value = item.Kilos;
                row.Cells[2].Value = item.Litros;
                row.Cells[3].Value = item.Temperatura;
                row.Cells[4].Value = item.Acidez;
                row.Cells[5].Value = item.Ph;
                row.Cells[6].Value = item.Crioscopia;
                row.Cells[7].Value = item.Grasa;
                row.Cells[8].Value = item.Densidad;
                row.Cells[9].Value = item.Sng;
                row.Cells[10].Value = item.St;
                row.Cells[11].Value = item.Alcohol;
                row.Cells[12].Value = item.Neutralizantes;
                row.Cells[13].Value = item.Ebullicion;
                row.Cells[14].Value = item.Inhibidores;
                row.Cells[15].Value = item.Sabor;
                row.Cells[16].Value = item.Termofilicos;
                row.Cells[17].Value = item.Micro;
                row.Cells[18].Value = item.Disposicion;
                row.Cells[19].Value = item.StArena;
                row.Cells[20].Value = item.Proteina;
                row.Cells[21].Value = item.KilosSap;
                row.Cells[22].Value = item.LitrosSap;
                dtgPagos.Rows.Add(row);
            }
        }
        private void toolStripBtnGuardar_Click(object sender, EventArgs e)
        {
            var pPagos = new ModelPagos
            {
                //IdPagos = txtIDPago.Text.Trim(),
                Kilos = txtKilos.Text.Trim(),
                Litros = txtLitros.Text.Trim(),
                Temperatura = txtTemperatura.Text.Trim(),
                Acidez = txtAcidez.Text.Trim(),
                Ph = txtpH.Text.Trim(),
                Crioscopia = txtCrioscopia.Text.Trim(),
                Grasa =txtGrasa.Text.Trim(),
                Densidad = txtDensidad.Text.Trim(),
                Sng = txtSNG.Text.Trim(),
                St = txtST.Text.Trim(),
                Alcohol = cmbAlcohol.SelectedItem.ToString(),
                Neutralizantes = cmbNeutralizantes.SelectedItem.ToString(),
                Ebullicion = cmbEbullicion.SelectedItem.ToString(),
                Inhibidores = cmbInhibidores.SelectedItem.ToString(),
                Sabor = txtOlor.Text.Trim(),
                Termofilicos = txtTermofilicos.Text.Trim(),
                Micro = txtMicro.Text.Trim(),
                Disposicion = txtDisposicion.Text.Trim(),
                StArena = txtSTArena.Text.Trim(),
                Proteina = txtProteina.Text.Trim(),
                KilosSap = txtKilosSAP.Text.Trim(),
                LitrosSap = txtLitrosSAP.Text.Trim()
            };
            var resultado = ModelPagos.Agregar(pPagos);

            if (resultado > 0)
                MessageBox.Show(@"Pago Guardado Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Guardar El Pago", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Esta Seguro Que Desea Eliminar El Pago", @"Estas Seguro??",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (ModelPagos.Eliminar(ModelPagos.PagoSelec.IdPagos) > 0)
            {
                MessageBox.Show(@"Pago Eliminado Correctamente!", @"Pago Eliminado", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                MessageBox.Show(@"No Se Pudo Eliminar El Pago", @"Pago No Eliminado", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                limpiarp();
            }
            else
            {
                MessageBox.Show(@"Se Cancelo La Eliminacion", @"Eliminacion Cancelada", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripBtnBuscar_Click(object sender, EventArgs e)
        {
            dtgPagos.DataSource = ModelPagos.Buscar(txtIDPago.Text);
        }
    }
}