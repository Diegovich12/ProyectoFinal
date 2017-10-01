namespace ProyectoNutrical
{
    partial class FormRegistroProveedores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistroProveedores));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnBuscar = new System.Windows.Forms.ToolStripButton();
            this.dtgProveedores = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtRancho = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoPipa = new System.Windows.Forms.TextBox();
            this.id_proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rancho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPipa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnGuardar,
            this.toolStripBtnModificar,
            this.toolStripBtnEliminar,
            this.toolStripBtnBuscar});
            this.toolStrip1.Location = new System.Drawing.Point(970, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(64, 661);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnGuardar
            // 
            this.toolStripBtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnGuardar.Image")));
            this.toolStripBtnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnGuardar.Name = "toolStripBtnGuardar";
            this.toolStripBtnGuardar.Size = new System.Drawing.Size(61, 67);
            this.toolStripBtnGuardar.Text = "Guardar";
            this.toolStripBtnGuardar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripBtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnGuardar.Click += new System.EventHandler(this.toolStripBtnGuardar_Click);
            // 
            // toolStripBtnModificar
            // 
            this.toolStripBtnModificar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnModificar.Image")));
            this.toolStripBtnModificar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnModificar.Name = "toolStripBtnModificar";
            this.toolStripBtnModificar.Size = new System.Drawing.Size(61, 67);
            this.toolStripBtnModificar.Text = "Actualizar";
            this.toolStripBtnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnModificar.Click += new System.EventHandler(this.toolStripBtnModificar_Click);
            // 
            // toolStripBtnEliminar
            // 
            this.toolStripBtnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnEliminar.Image")));
            this.toolStripBtnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnEliminar.Name = "toolStripBtnEliminar";
            this.toolStripBtnEliminar.Size = new System.Drawing.Size(61, 67);
            this.toolStripBtnEliminar.Text = "Eliminar";
            this.toolStripBtnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnEliminar.Click += new System.EventHandler(this.toolStripBtnEliminar_Click);
            // 
            // toolStripBtnBuscar
            // 
            this.toolStripBtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnBuscar.Image")));
            this.toolStripBtnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnBuscar.Name = "toolStripBtnBuscar";
            this.toolStripBtnBuscar.Size = new System.Drawing.Size(61, 67);
            this.toolStripBtnBuscar.Text = "Buscar";
            this.toolStripBtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnBuscar.Click += new System.EventHandler(this.toolStripBtnBuscar_Click);
            // 
            // dtgProveedores
            // 
            this.dtgProveedores.AllowUserToOrderColumns = true;
            this.dtgProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_proveedor,
            this.Nombre,
            this.Proveedor,
            this.Matricula,
            this.Rancho,
            this.NoPipa});
            this.dtgProveedores.Location = new System.Drawing.Point(12, 443);
            this.dtgProveedores.Name = "dtgProveedores";
            this.dtgProveedores.Size = new System.Drawing.Size(543, 206);
            this.dtgProveedores.TabIndex = 13;
            this.dtgProveedores.DoubleClick += new System.EventHandler(this.dtgProveedores_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Proveedor";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(107, 86);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(210, 20);
            this.txtProveedor.TabIndex = 19;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(107, 39);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(210, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Matricula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Rancho";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(107, 132);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(210, 20);
            this.txtMatricula.TabIndex = 22;
            // 
            // txtRancho
            // 
            this.txtRancho.Location = new System.Drawing.Point(107, 172);
            this.txtRancho.Name = "txtRancho";
            this.txtRancho.Size = new System.Drawing.Size(210, 20);
            this.txtRancho.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "No. Pipa";
            // 
            // txtNoPipa
            // 
            this.txtNoPipa.Location = new System.Drawing.Point(107, 214);
            this.txtNoPipa.Name = "txtNoPipa";
            this.txtNoPipa.Size = new System.Drawing.Size(210, 20);
            this.txtNoPipa.TabIndex = 25;
            // 
            // id_proveedor
            // 
            this.id_proveedor.HeaderText = "id";
            this.id_proveedor.Name = "id_proveedor";
            this.id_proveedor.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Proveedor
            // 
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            // 
            // Matricula
            // 
            this.Matricula.HeaderText = "Matricula";
            this.Matricula.Name = "Matricula";
            // 
            // Rancho
            // 
            this.Rancho.HeaderText = "Rancho";
            this.Rancho.Name = "Rancho";
            // 
            // NoPipa
            // 
            this.NoPipa.HeaderText = "No Pipa";
            this.NoPipa.Name = "NoPipa";
            // 
            // FormRegistroProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProyectoNutrical.Properties.Resources.nutrical2;
            this.ClientSize = new System.Drawing.Size(1034, 661);
            this.Controls.Add(this.txtNoPipa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRancho);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dtgProveedores);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegistroProveedores";
            this.Text = "Proveedores";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnGuardar;
        private System.Windows.Forms.ToolStripButton toolStripBtnModificar;
        private System.Windows.Forms.ToolStripButton toolStripBtnEliminar;
        private System.Windows.Forms.ToolStripButton toolStripBtnBuscar;
        private System.Windows.Forms.DataGridView dtgProveedores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtRancho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNoPipa;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rancho;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPipa;
    }
}