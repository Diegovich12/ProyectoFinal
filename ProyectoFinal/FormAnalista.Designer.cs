namespace ProyectoNutrical
{
    partial class FormAnalista
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnalista));
            this.Menu = new System.Windows.Forms.ToolStrip();
            this.BtnProveedores = new System.Windows.Forms.ToolStripDropDownButton();
            this.altaProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaTrabajadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnFacturas = new System.Windows.Forms.ToolStripDropDownButton();
            this.proveedoresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nutricalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnSalir = new System.Windows.Forms.ToolStripButton();
            this.recepcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evaporadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secadorVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.ForestGreen;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnProveedores,
            this.toolStripSeparator1,
            this.BtnFacturas,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.BtnSalir});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1034, 55);
            this.Menu.TabIndex = 0;
            // 
            // BtnProveedores
            // 
            this.BtnProveedores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaProveedoresToolStripMenuItem,
            this.altaTrabajadoresToolStripMenuItem});
            this.BtnProveedores.Image = ((System.Drawing.Image)(resources.GetObject("BtnProveedores.Image")));
            this.BtnProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnProveedores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnProveedores.Name = "BtnProveedores";
            this.BtnProveedores.Size = new System.Drawing.Size(111, 52);
            this.BtnProveedores.Text = "Registro";
            // 
            // altaProveedoresToolStripMenuItem
            // 
            this.altaProveedoresToolStripMenuItem.Name = "altaProveedoresToolStripMenuItem";
            this.altaProveedoresToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.altaProveedoresToolStripMenuItem.Text = "Proveedores";
            this.altaProveedoresToolStripMenuItem.Click += new System.EventHandler(this.altaProveedoresToolStripMenuItem_Click);
            // 
            // altaTrabajadoresToolStripMenuItem
            // 
            this.altaTrabajadoresToolStripMenuItem.Name = "altaTrabajadoresToolStripMenuItem";
            this.altaTrabajadoresToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.altaTrabajadoresToolStripMenuItem.Text = "Trabajadores";
            this.altaTrabajadoresToolStripMenuItem.Click += new System.EventHandler(this.altaTrabajadoresToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // BtnFacturas
            // 
            this.BtnFacturas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proveedoresToolStripMenuItem1,
            this.nutricalToolStripMenuItem});
            this.BtnFacturas.Image = ((System.Drawing.Image)(resources.GetObject("BtnFacturas.Image")));
            this.BtnFacturas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnFacturas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnFacturas.Name = "BtnFacturas";
            this.BtnFacturas.Size = new System.Drawing.Size(99, 52);
            this.BtnFacturas.Text = "Notas";
            // 
            // proveedoresToolStripMenuItem1
            // 
            this.proveedoresToolStripMenuItem1.Name = "proveedoresToolStripMenuItem1";
            this.proveedoresToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.proveedoresToolStripMenuItem1.Text = "Compras Proveedores";
            this.proveedoresToolStripMenuItem1.Click += new System.EventHandler(this.proveedoresToolStripMenuItem1_Click);
            // 
            // nutricalToolStripMenuItem
            // 
            this.nutricalToolStripMenuItem.Name = "nutricalToolStripMenuItem";
            this.nutricalToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.nutricalToolStripMenuItem.Text = "Pagos Proveedores";
            this.nutricalToolStripMenuItem.Click += new System.EventHandler(this.nutricalToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::ProyectoNutrical.Properties.Resources.if_3d_printer_102511;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(114, 52);
            this.toolStripButton1.Text = "MilkoScan";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // BtnSalir
            // 
            this.BtnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("BtnSalir.Image")));
            this.BtnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(52, 52);
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // recepcionToolStripMenuItem
            // 
            this.recepcionToolStripMenuItem.Name = "recepcionToolStripMenuItem";
            this.recepcionToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.recepcionToolStripMenuItem.Text = "FormRecepcion ";
            // 
            // evaporadorToolStripMenuItem
            // 
            this.evaporadorToolStripMenuItem.Name = "evaporadorToolStripMenuItem";
            this.evaporadorToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.evaporadorToolStripMenuItem.Text = "FormEvaporador";
            // 
            // secadorVerticalToolStripMenuItem
            // 
            this.secadorVerticalToolStripMenuItem.Name = "secadorVerticalToolStripMenuItem";
            this.secadorVerticalToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.secadorVerticalToolStripMenuItem.Text = "Secador Vertical";
            // 
            // FormAnalista
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1034, 461);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FormAnalista";
            this.Text = "Nutrical S.A. de C.V.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private new System.Windows.Forms.ToolStrip Menu;
        private System.Windows.Forms.ToolStripButton BtnSalir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton BtnProveedores;
        private System.Windows.Forms.ToolStripMenuItem altaProveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recepcionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evaporadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secadorVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaTrabajadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton BtnFacturas;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nutricalToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

