using ProyectoNutrical.Models;
using System;
using System.Windows.Forms;

namespace ProyectoNutrical
{
    public partial class FormMilkoScan : Form
    {
        public FormMilkoScan()
        {
            InitializeComponent();
            LlenarGrid();
        }

        public void Limpiarm()
        {
            txtID.Clear();
            txtREP.Clear();
            txtGrasa.Clear();
            txtProteina.Clear();
            txtSNG.Clear();
            txtST.Clear();
            txtLactosa.Clear();
            txtCaseina.Clear();
            txtUrea.Clear();
            txtDensidad.Clear();
            txtpH.Clear();
            txtAcidez.Clear();
            txtCrioscopia.Clear();
            txtFFA.Clear();
            txtProteinaC.Clear();
            txtProteinaS.Clear();

        }

        public void LlenarGrid()
        {
            foreach (var item in ModelMilkoScan.Llenargrid())
            {
                var row = (DataGridViewRow)dtgMilkoScan.Rows[0].Clone();
                row.Cells[0].Value = item.Id;
                row.Cells[1].Value = item.Identificacion;
                row.Cells[2].Value = item.Rep;
                row.Cells[3].Value = item.Grasa;
                row.Cells[17].Value = item.Proteina;
                row.Cells[4].Value = item.Sng;
                row.Cells[5].Value = item.St;
                row.Cells[6].Value = item.Lactosa;
                row.Cells[7].Value = item.Caseina;
                row.Cells[8].Value = item.Urea;
                row.Cells[9].Value = item.Densidad;
                row.Cells[10].Value = item.Ph;
                row.Cells[11].Value = item.Acidez;
                row.Cells[12].Value = item.Crioscopia;
                row.Cells[13].Value = item.Ffa;
                row.Cells[14].Value = item.Fecha;
                row.Cells[15].Value = item.ProtCaseina;
                row.Cells[16].Value = item.ProtSuero;
                dtgMilkoScan.Rows.Add(row);
            }
        }

        private void toolStripBtnGuardar_Click(object sender, EventArgs e)
        {
            var pMilko = new ModelMilkoScan
            {
                Identificacion = txtID.Text.Trim(),
                Rep = int.Parse(txtREP.Text),
                Grasa = double.Parse(txtGrasa.Text),
                Proteina = double.Parse(txtProteina.Text),
                Sng = double.Parse(txtSNG.Text),
                St = double.Parse(txtST.Text),
                Lactosa = double.Parse(txtLactosa.Text),
                Caseina = double.Parse(txtCaseina.Text),
                Urea = double.Parse(txtUrea.Text),
                Densidad = double.Parse(txtDensidad.Text),
                Ph = double.Parse(txtpH.Text),
                Acidez = double.Parse(txtAcidez.Text),
                Crioscopia = double.Parse(txtCrioscopia.Text),
                Ffa = double.Parse(txtFFA.Text),
                Fecha = dtpMilko.Value.Year + "/" + dtpMilko.Value.Month + "/" + dtpMilko.Value.Day + "/" +
                        dtpMilko.Value.Hour + "/" + dtpMilko.Value.Minute + "/" + dtpMilko.Value.Second,
                ProtCaseina = double.Parse(txtProteinaC.Text),
                ProtSuero = double.Parse(txtProteinaS.Text)
            };
            var resultado = ModelMilkoScan.Agregar(pMilko);

            if (resultado > 0)
            {
                MessageBox.Show(@"Captura Guardada Con Exitó!!", @"Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarGrid();
            }
            else
                MessageBox.Show(@"No Se Pudo Guardar La Captura", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void toolStripBtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Deseas Eliminar La Captura", @"Estas Seguro??",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (ModelMilkoScan.Eliminar(ModelMilkoScan.MilkoScanSelect.Id) > 0)
            {
                MessageBox.Show(@"Captura Eliminada Correctamente!", @"Captura Eliminada", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                MessageBox.Show(@"No Se Pudo Eliminar La Captura", @"Captura No Eliminada", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                Limpiarm();
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
            if (encontro)
            {
                dtgMilkoScan.Rows.Clear();
                dtgMilkoScan.Refresh();
            }
            foreach (var item in ModelMilkoScan.Buscar(txtID.Text))
            {
                var row = (DataGridViewRow)dtgMilkoScan.Rows[0].Clone();
                row.Cells[0].Value = item.Id;
                row.Cells[1].Value = item.Identificacion;
                row.Cells[2].Value = item.Rep;
                row.Cells[3].Value = item.Grasa;
                row.Cells[17].Value = item.Proteina;
                row.Cells[4].Value = item.Sng;
                row.Cells[5].Value = item.St;
                row.Cells[6].Value = item.Lactosa;
                row.Cells[7].Value = item.Caseina;
                row.Cells[8].Value = item.Urea;
                row.Cells[9].Value = item.Densidad;
                row.Cells[10].Value = item.Ph;
                row.Cells[11].Value = item.Acidez;
                row.Cells[12].Value = item.Crioscopia;
                row.Cells[13].Value = item.Ffa;
                row.Cells[14].Value = item.Fecha;
                row.Cells[15].Value = item.ProtCaseina;
                row.Cells[16].Value = item.ProtSuero;
                dtgMilkoScan.Rows.Add(row);
                encontro = false;
            }

        }

        private void toolStripBtnModificar_Click(object sender, EventArgs e)
        {
            var aTodo = new ModelMilkoScan
            {
                Id = ModelMilkoScan.MilkoScanSelect.Id,
                Identificacion = txtID.Text.Trim(),
                Rep = int.Parse(txtREP.Text),
                Grasa = double.Parse(txtGrasa.Text),
                Proteina = double.Parse(txtProteina.Text),
                Sng = double.Parse(txtSNG.Text),
                St = double.Parse(txtST.Text),
                Lactosa = double.Parse(txtLactosa.Text),
                Caseina = double.Parse(txtCaseina.Text),
                Urea = double.Parse(txtUrea.Text),
                Densidad = double.Parse(txtDensidad.Text),
                Ph = double.Parse(txtpH.Text),
                Acidez = double.Parse(txtAcidez.Text),
                Crioscopia = double.Parse(txtCrioscopia.Text),
                Ffa = double.Parse(txtFFA.Text),
                Fecha = dtpMilko.Value.Year + "/" + dtpMilko.Value.Month + "/" + dtpMilko.Value.Day + "/" +
                        dtpMilko.Value.Hour + "/" + dtpMilko.Value.Minute + "/" + dtpMilko.Value.Second,
                ProtCaseina = double.Parse(txtProteinaC.Text),
                ProtSuero = double.Parse(txtProteinaS.Text)


            };
            if (ModelMilkoScan.Actualizar(aTodo, 1) > 0)
            {
                MessageBox.Show(@"Captura Actualizada Con Exito!!", @"Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarGrid();
            }
            else
                MessageBox.Show(@"No Se Pudo Actualizar La Captura", @"Fallo!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ModelMilkoScan.DisplayInExcel();
            {
                MessageBox.Show(@"Exportación Realizada Con Exitó!!", @"Guardado en ", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
            }
        }

        private void dtgMilkoScan_DoubleClick(object sender, EventArgs e)
        {
            if (dtgMilkoScan.SelectedRows.Count == 1)
            {
                if (dtgMilkoScan.CurrentRow != null)
                    ModelMilkoScan.ObtenerMilko(Convert.ToInt32(dtgMilkoScan.CurrentRow.Cells[0].Value));

                txtID.Text = ModelMilkoScan.MilkoScanSelect.Identificacion;
                txtREP.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.Rep);
                txtGrasa.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.Grasa);
                txtProteina.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.Proteina);
                txtSNG.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.Sng);
                txtST.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.St);
                txtLactosa.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.Lactosa);
                txtCaseina.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.Caseina);
                txtUrea.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.Urea);
                txtDensidad.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.Densidad);
                txtpH.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.Ph);
                txtAcidez.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.Acidez);
                txtCrioscopia.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.Crioscopia);
                txtFFA.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.Ffa);
                dtpMilko.Text =ModelMilkoScan.MilkoScanSelect.Fecha;
                txtProteinaC.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.ProtCaseina);
                txtProteinaS.Text = Convert.ToString(ModelMilkoScan.MilkoScanSelect.ProtSuero);

            }
            else
            {
                MessageBox.Show(@"debe de seleccionar una fila");
            }
        }

        public void LimpiarGrid()
        {
            dtgMilkoScan.Rows.Clear();
            dtgMilkoScan.Refresh();
            LlenarGrid();
        }
    }
}