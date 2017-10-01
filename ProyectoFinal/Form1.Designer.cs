namespace ProyectoNutrical
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Menu = new System.Windows.Forms.ToolStrip();
            this.BtnSalir = new System.Windows.Forms.ToolStripButton();
            this.BtnProveedores = new System.Windows.Forms.ToolStripDropDownButton();
            this.altaProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnAreas = new System.Windows.Forms.ToolStripDropDownButton();
            this.recepcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evaporadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secadorVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnFacturas = new System.Windows.Forms.ToolStripButton();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.ForestGreen;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnProveedores,
            this.BtnFacturas,
            this.BtnAreas,
            this.BtnSalir});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1184, 71);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "Menu";
            // 
            // BtnSalir
            // 
            this.BtnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("BtnSalir.Image")));
            this.BtnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(68, 68);
            this.BtnSalir.Text = "Salir";
            // 
            // BtnProveedores
            // 
            this.BtnProveedores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaProveedoresToolStripMenuItem,
            this.proveedoresToolStripMenuItem});
            this.BtnProveedores.Image = ((System.Drawing.Image)(resources.GetObject("BtnProveedores.Image")));
            this.BtnProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnProveedores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnProveedores.Name = "BtnProveedores";
            this.BtnProveedores.Size = new System.Drawing.Size(149, 68);
            this.BtnProveedores.Text = "Proveedores";
            // 
            // altaProveedoresToolStripMenuItem
            // 
            this.altaProveedoresToolStripMenuItem.Name = "altaProveedoresToolStripMenuItem";
            this.altaProveedoresToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.altaProveedoresToolStripMenuItem.Text = "Alta Proveedores";
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            // 
            // BtnAreas
            // 
            this.BtnAreas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recepcionToolStripMenuItem,
            this.evaporadorToolStripMenuItem,
            this.secadorVerticalToolStripMenuItem});
            this.BtnAreas.Image = ((System.Drawing.Image)(resources.GetObject("BtnAreas.Image")));
            this.BtnAreas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnAreas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAreas.Name = "BtnAreas";
            this.BtnAreas.Size = new System.Drawing.Size(113, 68);
            this.BtnAreas.Text = "Areas";
            // 
            // recepcionToolStripMenuItem
            // 
            this.recepcionToolStripMenuItem.Name = "recepcionToolStripMenuItem";
            this.recepcionToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.recepcionToolStripMenuItem.Text = "Recepcion ";
            // 
            // evaporadorToolStripMenuItem
            // 
            this.evaporadorToolStripMenuItem.Name = "evaporadorToolStripMenuItem";
            this.evaporadorToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.evaporadorToolStripMenuItem.Text = "Evaporador";
            // 
            // secadorVerticalToolStripMenuItem
            // 
            this.secadorVerticalToolStripMenuItem.Name = "secadorVerticalToolStripMenuItem";
            this.secadorVerticalToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.secadorVerticalToolStripMenuItem.Text = "Secador Vertical";
            // 
            // BtnFacturas
            // 
            this.BtnFacturas.Image = ((System.Drawing.Image)(resources.GetObject("BtnFacturas.Image")));
            this.BtnFacturas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnFacturas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnFacturas.Name = "BtnFacturas";
            this.BtnFacturas.Size = new System.Drawing.Size(107, 68);
            this.BtnFacturas.Text = "Pagos";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1184, 511);
            this.Controls.Add(this.Menu);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Nutrical S.A. de C.V.";
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu;
        private System.Windows.Forms.ToolStripButton BtnSalir;
        private System.Windows.Forms.ToolStripDropDownButton BtnProveedores;
        private System.Windows.Forms.ToolStripMenuItem altaProveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton BtnAreas;
        private System.Windows.Forms.ToolStripMenuItem recepcionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evaporadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secadorVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton BtnFacturas;
    }
}

