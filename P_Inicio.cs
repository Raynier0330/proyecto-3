using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;

namespace CapaPresentacion
{
    public partial class P_Inicio : Form
    {
        public static Usuario usuarioActual;
        private static ToolStripMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        public P_Inicio(Usuario objusuario = null)
        {
            if(objusuario == null)
                 usuarioActual = new Usuario() { NombreCompleto = "ADMIN PREDEFINIDO", IdUsuario = 1};
            else
            usuarioActual = objusuario;

            InitializeComponent();
        }

        private void P_Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new N_Permiso().Listar(usuarioActual.IdUsuario);

            foreach (ToolStripMenuItem stripmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == stripmenu.Name);

                if(encontrado == false)
                {
                    stripmenu.Visible = false;
                }
            }

            lblUsuario.Text = usuarioActual.NombreCompleto;
        }

        private void AbrirFormulario(ToolStripMenuItem menu, Form formulario)
        {
            if(MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.DarkTurquoise;

            Contenedor.Controls.Add(formulario);
            formulario.Show();
        }
        private void MenuUsuarios_Click(object sender, EventArgs e)
        {

            AbrirFormulario((ToolStripMenuItem)sender, new frmUsuarios());
            
        }

        private void SubMenuCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MenuMantenimiento, new frmCategoria());
        }

        private void SubMenuProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MenuMantenimiento, new frmProducto());
        }

        private void SubMenuRegistrarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MenuVentas, new frmVentas(usuarioActual));
        }

        private void SubMenuVerDetalleVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MenuVentas, new DetalleVenta());
        }

        private void SubMenuRegistrarCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MenuCompras, new frmCompras(usuarioActual));
        }

        private void SubMenuVerDetalleCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MenuCompras, new frmDetalleCompra());
        }

        private void MenuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((ToolStripMenuItem)sender, new frmClientes());
        }

        private void MenuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((ToolStripMenuItem)sender, new frmProveedores());
        }

        private void SubMenuReporteCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MenuReportes, new frmReporteCompras());
        }

        private void SubMenuReporteVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MenuReportes, new frmReporteVentas());
        }

        private void MenuAcercaDe_Click(object sender, EventArgs e)
        {
            MD_AcercaDe md = new MD_AcercaDe();
            md.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea Salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
