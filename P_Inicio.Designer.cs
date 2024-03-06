namespace CapaPresentacion
{
    partial class P_Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_Inicio));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.MenuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuRegistrarVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuVerDetalleVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuRegistrarCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuVerDetalleCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuReporteCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuReporteVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUsuarios,
            this.MenuMantenimiento,
            this.MenuVentas,
            this.MenuCompras,
            this.MenuClientes,
            this.MenuProveedores,
            this.MenuReportes,
            this.MenuAcercaDe});
            this.menu.Location = new System.Drawing.Point(0, 58);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1047, 64);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // MenuUsuarios
            // 
            this.MenuUsuarios.AutoSize = false;
            this.MenuUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.MenuUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("MenuUsuarios.Image")));
            this.MenuUsuarios.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuUsuarios.Name = "MenuUsuarios";
            this.MenuUsuarios.Size = new System.Drawing.Size(80, 60);
            this.MenuUsuarios.Text = "Usuarios";
            this.MenuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuUsuarios.Click += new System.EventHandler(this.MenuUsuarios_Click);
            // 
            // MenuMantenimiento
            // 
            this.MenuMantenimiento.AutoSize = false;
            this.MenuMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuCategoria,
            this.SubMenuProducto});
            this.MenuMantenimiento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.MenuMantenimiento.Image = ((System.Drawing.Image)(resources.GetObject("MenuMantenimiento.Image")));
            this.MenuMantenimiento.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuMantenimiento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuMantenimiento.Name = "MenuMantenimiento";
            this.MenuMantenimiento.Size = new System.Drawing.Size(125, 60);
            this.MenuMantenimiento.Text = "Mantenimiento";
            this.MenuMantenimiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // SubMenuCategoria
            // 
            this.SubMenuCategoria.Name = "SubMenuCategoria";
            this.SubMenuCategoria.Size = new System.Drawing.Size(144, 24);
            this.SubMenuCategoria.Text = "Categoria";
            this.SubMenuCategoria.Click += new System.EventHandler(this.SubMenuCategoria_Click);
            // 
            // SubMenuProducto
            // 
            this.SubMenuProducto.Name = "SubMenuProducto";
            this.SubMenuProducto.Size = new System.Drawing.Size(144, 24);
            this.SubMenuProducto.Text = "Producto";
            this.SubMenuProducto.Click += new System.EventHandler(this.SubMenuProducto_Click);
            // 
            // MenuVentas
            // 
            this.MenuVentas.AutoSize = false;
            this.MenuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuRegistrarVenta,
            this.SubMenuVerDetalleVenta});
            this.MenuVentas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.MenuVentas.Image = ((System.Drawing.Image)(resources.GetObject("MenuVentas.Image")));
            this.MenuVentas.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuVentas.Name = "MenuVentas";
            this.MenuVentas.Size = new System.Drawing.Size(80, 60);
            this.MenuVentas.Text = "Ventas";
            this.MenuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // SubMenuRegistrarVenta
            // 
            this.SubMenuRegistrarVenta.Name = "SubMenuRegistrarVenta";
            this.SubMenuRegistrarVenta.Size = new System.Drawing.Size(151, 24);
            this.SubMenuRegistrarVenta.Text = "Registrar";
            this.SubMenuRegistrarVenta.Click += new System.EventHandler(this.SubMenuRegistrarVenta_Click);
            // 
            // SubMenuVerDetalleVenta
            // 
            this.SubMenuVerDetalleVenta.Name = "SubMenuVerDetalleVenta";
            this.SubMenuVerDetalleVenta.Size = new System.Drawing.Size(151, 24);
            this.SubMenuVerDetalleVenta.Text = "Ver Detalle";
            this.SubMenuVerDetalleVenta.Click += new System.EventHandler(this.SubMenuVerDetalleVenta_Click);
            // 
            // MenuCompras
            // 
            this.MenuCompras.AutoSize = false;
            this.MenuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuRegistrarCompra,
            this.SubMenuVerDetalleCompra});
            this.MenuCompras.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.MenuCompras.Image = ((System.Drawing.Image)(resources.GetObject("MenuCompras.Image")));
            this.MenuCompras.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuCompras.Name = "MenuCompras";
            this.MenuCompras.Size = new System.Drawing.Size(80, 60);
            this.MenuCompras.Text = "Compras";
            this.MenuCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // SubMenuRegistrarCompra
            // 
            this.SubMenuRegistrarCompra.Name = "SubMenuRegistrarCompra";
            this.SubMenuRegistrarCompra.Size = new System.Drawing.Size(151, 24);
            this.SubMenuRegistrarCompra.Text = "Registrar";
            this.SubMenuRegistrarCompra.Click += new System.EventHandler(this.SubMenuRegistrarCompra_Click);
            // 
            // SubMenuVerDetalleCompra
            // 
            this.SubMenuVerDetalleCompra.Name = "SubMenuVerDetalleCompra";
            this.SubMenuVerDetalleCompra.Size = new System.Drawing.Size(151, 24);
            this.SubMenuVerDetalleCompra.Text = "Ver Detalle";
            this.SubMenuVerDetalleCompra.Click += new System.EventHandler(this.SubMenuVerDetalleCompra_Click);
            // 
            // MenuClientes
            // 
            this.MenuClientes.AutoSize = false;
            this.MenuClientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.MenuClientes.Image = ((System.Drawing.Image)(resources.GetObject("MenuClientes.Image")));
            this.MenuClientes.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuClientes.Name = "MenuClientes";
            this.MenuClientes.Size = new System.Drawing.Size(80, 60);
            this.MenuClientes.Text = "Clientes";
            this.MenuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuClientes.Click += new System.EventHandler(this.MenuClientes_Click);
            // 
            // MenuProveedores
            // 
            this.MenuProveedores.AutoSize = false;
            this.MenuProveedores.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.MenuProveedores.Image = ((System.Drawing.Image)(resources.GetObject("MenuProveedores.Image")));
            this.MenuProveedores.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuProveedores.Name = "MenuProveedores";
            this.MenuProveedores.Size = new System.Drawing.Size(100, 60);
            this.MenuProveedores.Text = "Proveedores";
            this.MenuProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuProveedores.Click += new System.EventHandler(this.MenuProveedores_Click);
            // 
            // MenuReportes
            // 
            this.MenuReportes.AutoSize = false;
            this.MenuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuReporteCompras,
            this.SubMenuReporteVentas});
            this.MenuReportes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.MenuReportes.Image = ((System.Drawing.Image)(resources.GetObject("MenuReportes.Image")));
            this.MenuReportes.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MenuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuReportes.Name = "MenuReportes";
            this.MenuReportes.Size = new System.Drawing.Size(80, 60);
            this.MenuReportes.Text = "Reportes";
            this.MenuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // SubMenuReporteCompras
            // 
            this.SubMenuReporteCompras.Name = "SubMenuReporteCompras";
            this.SubMenuReporteCompras.Size = new System.Drawing.Size(196, 24);
            this.SubMenuReporteCompras.Text = "Reporte Compras";
            this.SubMenuReporteCompras.Click += new System.EventHandler(this.SubMenuReporteCompras_Click);
            // 
            // SubMenuReporteVentas
            // 
            this.SubMenuReporteVentas.Name = "SubMenuReporteVentas";
            this.SubMenuReporteVentas.Size = new System.Drawing.Size(196, 24);
            this.SubMenuReporteVentas.Text = "Reporte Ventas";
            this.SubMenuReporteVentas.Click += new System.EventHandler(this.SubMenuReporteVentas_Click);
            // 
            // MenuAcercaDe
            // 
            this.MenuAcercaDe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.MenuAcercaDe.Image = ((System.Drawing.Image)(resources.GetObject("MenuAcercaDe.Image")));
            this.MenuAcercaDe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuAcercaDe.Name = "MenuAcercaDe";
            this.MenuAcercaDe.Size = new System.Drawing.Size(89, 60);
            this.MenuAcercaDe.Text = "Acerca De";
            this.MenuAcercaDe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MenuAcercaDe.Click += new System.EventHandler(this.MenuAcercaDe_Click);
            // 
            // menuTitulo
            // 
            this.menuTitulo.AutoSize = false;
            this.menuTitulo.BackColor = System.Drawing.Color.DarkTurquoise;
            this.menuTitulo.Location = new System.Drawing.Point(0, 0);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuTitulo.Size = new System.Drawing.Size(1047, 58);
            this.menuTitulo.TabIndex = 1;
            this.menuTitulo.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema de Gestion de Inventario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 122);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(1047, 556);
            this.Contenedor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(705, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.DarkTurquoise;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(772, 26);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(19, 15);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "...";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(964, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(71, 49);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // P_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 678);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuTitulo);
            this.MainMenuStrip = this.menu;
            this.Name = "P_Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.P_Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menuTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem MenuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem MenuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem MenuVentas;
        private System.Windows.Forms.ToolStripMenuItem MenuCompras;
        private System.Windows.Forms.ToolStripMenuItem MenuClientes;
        private System.Windows.Forms.ToolStripMenuItem MenuProveedores;
        private System.Windows.Forms.ToolStripMenuItem MenuReportes;
        private System.Windows.Forms.Panel Contenedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ToolStripMenuItem SubMenuCategoria;
        private System.Windows.Forms.ToolStripMenuItem SubMenuProducto;
        private System.Windows.Forms.ToolStripMenuItem SubMenuRegistrarVenta;
        private System.Windows.Forms.ToolStripMenuItem SubMenuVerDetalleVenta;
        private System.Windows.Forms.ToolStripMenuItem SubMenuRegistrarCompra;
        private System.Windows.Forms.ToolStripMenuItem SubMenuVerDetalleCompra;
        private System.Windows.Forms.ToolStripMenuItem MenuAcercaDe;
        private System.Windows.Forms.ToolStripMenuItem SubMenuReporteCompras;
        private System.Windows.Forms.ToolStripMenuItem SubMenuReporteVentas;
        private System.Windows.Forms.Button btnSalir;
    }
}

