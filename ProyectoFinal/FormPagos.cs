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
            //txtDisposicion.Clear();
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
                Kilos = txtKilos.Text.Trim(),
                Litros = txtLitros.Text.Trim(),
                Temperatura = txtTemperatura.Text.Trim(),
                Acidez = txtAcidez.Text.Trim(),
                Ph = txtpH.Text.Trim(),
                Crioscopia = txtCrioscopia.Text.Trim(),
                Grasa = txtGrasa.Text.Trim(),
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
                Disposicion = cmbDFinal.SelectedItem.ToString(),
                StArena = txtSTArena.Text.Trim(),
                Proteina = txtProteina.Text.Trim(),
                KilosSap = txtKilosSAP.Text.Trim(),
                LitrosSap = txtLitrosSAP.Text.Trim()
            };

            var resultado = ModelPagos.Agregar(pPagos);

            if (resultado > 0)
            {
                MessageBox.Show(@"Pago Guardado Con Exito!!", @"Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtgPagos.Rows.Clear();
                dtgPagos.Refresh();
                LlenarGridView();
            }
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
            var encontro = true;
            foreach (var item in ModelPagos.Buscar(txtIDPago.Text))
            {
                if (encontro)
                {
                    dtgPagos.Rows.Clear();
                    dtgPagos.Refresh();
                }
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
                encontro = false;
            }
        }

        private void dtgPagos_DoubleClick(object sender, EventArgs e)
        {
            if (dtgPagos.SelectedRows.Count == 1)
            {
                if (dtgPagos.CurrentRow != null)
                    ModelPagos.ObtenerPago(Convert.ToInt32(dtgPagos.CurrentRow.Cells[0].Value));

                txtKilos.Text = ModelPagos.PagoSelec.Kilos;
                txtLitros.Text = ModelPagos.PagoSelec.Litros;
                txtTemperatura.Text = ModelPagos.PagoSelec.Temperatura;
                txtAcidez.Text = ModelPagos.PagoSelec.Acidez;
                txtpH.Text = ModelPagos.PagoSelec.Ph;
                txtCrioscopia.Text = ModelPagos.PagoSelec.Crioscopia;
                txtGrasa.Text = ModelPagos.PagoSelec.Grasa;
                txtDensidad.Text = ModelPagos.PagoSelec.Densidad;
                txtSNG.Text = ModelPagos.PagoSelec.Sng;
                txtST.Text = ModelPagos.PagoSelec.St;
                cmbAlcohol.SelectedItem = ModelPagos.PagoSelec.Alcohol;
                cmbNeutralizantes.SelectedItem = ModelPagos.PagoSelec.Neutralizantes;
                cmbEbullicion.SelectedItem = ModelPagos.PagoSelec.Ebullicion;
                cmbInhibidores.SelectedItem = ModelPagos.PagoSelec.Inhibidores;
                txtOlor.Text = ModelPagos.PagoSelec.Sabor;
                txtTermofilicos.Text = ModelPagos.PagoSelec.Termofilicos;
                txtMicro.Text = ModelPagos.PagoSelec.Micro;
                cmbDFinal.SelectedItem = ModelPagos.PagoSelec.Disposicion;
                txtSTArena.Text = ModelPagos.PagoSelec.StArena;
                txtProteina.Text = ModelPagos.PagoSelec.Proteina;
                txtKilosSAP.Text = ModelPagos.PagoSelec.KilosSap;
                txtLitrosSAP.Text = ModelPagos.PagoSelec.LitrosSap;
            }
            else
            {
                MessageBox.Show(@"debe de seleccionar una fila");
            }
        }

        private void toolStripBtnActualizar_Click(object sender, EventArgs e)
        {
            var rTodo = new ModelPagos
            {
                IdPagos = ModelPagos.PagoSelec.IdPagos,
                Kilos = txtKilos.Text.Trim(),
                Litros = txtLitros.Text.Trim(),
                Temperatura = txtTemperatura.Text.Trim(),
                Acidez = txtAcidez.Text.Trim(),
                Ph = txtpH.Text.Trim(),
                Crioscopia = txtCrioscopia.Text.Trim(),
                Grasa = txtGrasa.Text.Trim(),
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
                Disposicion = cmbDFinal.SelectedItem.ToString(),
                StArena = txtSTArena.Text.Trim(),
                Proteina = txtProteina.Text.Trim(),
                KilosSap = txtKilosSAP.Text.Trim(),
                LitrosSap = txtLitrosSAP.Text.Trim()
            };
            if (ModelPagos.Actualizar(rTodo) > 0)
                MessageBox.Show(@"Captura Actualizada Con Exito!!", @"Guardado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(@"No Se Pudo Actualizar La Captura", @"Fallo!!", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ModelPagos.DisplayInExcell();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }
    }
}