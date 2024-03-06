using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Obtener la conexión desde el objeto DataContext
            using (var context = new CapaPresentacion.DBGestion_InventarioEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection;
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_AuthenticateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NombreCompleto", txtNombreCompleto.Text);
                    command.Parameters.AddWithValue("@Clave", txtClave.Text);

                    SqlParameter idUsuarioParam = new SqlParameter
                    {
                        ParameterName = "@IdUsuario",
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(idUsuarioParam);

                    SqlParameter mensajeParam = new SqlParameter
                    {
                        ParameterName = "@Mensaje",
                        DbType = DbType.String,
                        Size = 500,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(mensajeParam);

                    command.ExecuteNonQuery();

                    int idUsuario = (int)idUsuarioParam.Value;
                    string mensaje = (string)mensajeParam.Value;

                    if (idUsuario > 0)
                    {
                        // Usuario autenticado correctamente
                        Usuario ousuario = new N_Usuario().Listar().FirstOrDefault(u => u.IdUsuario == idUsuario);
                        if (ousuario != null)
                        {
                            P_Inicio form = new P_Inicio(ousuario);
                            form.Show();
                            this.Hide();
                            form.FormClosing += frm_closing;
                        }
                    }
                    else
                    {
                        // Error en la autenticación
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }


        private void frm_closing(object sender,FormClosingEventArgs e)
        {
            txtNombreCompleto.Clear();
            txtClave.Clear();

            this.Show();
        }
    }
}
