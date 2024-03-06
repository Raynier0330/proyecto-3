using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmVentas : Form
    {
        private Usuario _Usuario;
        public frmVentas(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;

            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cboTipoDocumento.DisplayMember = "Texto";
            cboTipoDocumento.ValueMember = "Valor";
            cboTipoDocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtIdProducto.Text = "0";

            txtPagocon.Text = "";
            txtCambio.Text = "";
            txtTotalPagar.Text = "0";

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var modal = new MD_Cliente())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtDocCliente.Text = modal._Cliente.Documento;
                    txtNombreCliente.Text = modal._Cliente.NombreCompleto;
                    txtCodProducto.Select();
                }
                else
                {
                    txtDocCliente.Select();
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new MD_Producto())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = modal._Producto.IdProducto.ToString();
                    txtCodProducto.Text = modal._Producto.Codigo;
                    txtProducto.Text = modal._Producto.Nombre;
                    txtPrecio.Text = modal._Producto.PrecioVenta.ToString();
                    txtStock.Text = modal._Producto.Stock.ToString();
                    txtCantidad.Select();
                }
                else
                {
                    txtCodProducto.Select();
                }
            }
        }

        private void txtCodProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto oProducto = new N_Producto().Listar().Where(p => p.Codigo == txtCodProducto.Text && p.Estado == true).FirstOrDefault();

                if (oProducto != null)
                {
                    txtIdProducto.Text = oProducto.IdProducto.ToString();
                    txtProducto.Text = oProducto.Nombre;
                    txtPrecio.Text = oProducto.PrecioVenta.ToString("0.00");
                    txtStock.Text = oProducto.Stock.ToString();
                    txtCantidad.Select();
                }
                else
                {
                    txtIdProducto.Text = "0";
                    txtProducto.Text = "";
                    txtPrecio.Text = "";
                    txtStock.Text = "";
                    txtCantidad.Value = 1;
                }

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            decimal precio = 0;


            if (string.IsNullOrEmpty(txtIdProducto.Text))
            {
                MessageBox.Show("Debe Seleccionar un Producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (!decimal.TryParse(txtPrecio.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out precio))
            {
                MessageBox.Show("Precio - Formato moneda Incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecio.Select();
                return;
            }

            if (Convert.ToInt32(txtStock.Text) < Convert.ToInt32(txtCantidad.Value.ToString()))
            {
                MessageBox.Show("La Cantidad no puede ser mayor al Stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            foreach (DataGridViewRow fila in dgvData.Rows)
            {
                var idProductoCell = fila.Cells["IdProducto"].Value;
                if (idProductoCell != null && idProductoCell.ToString() == txtIdProducto.Text)
                {
                    MessageBox.Show("El producto ya existe en la lista", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            decimal cantidad = txtCantidad.Value;
            decimal subtotal = precio * cantidad;

            dgvData.Rows.Add(new object[]
            {
                txtIdProducto.Text,
                txtProducto.Text,
                precio.ToString("0.00"),
                cantidad.ToString(),
                subtotal.ToString("0.00")
            });

            CalcularTotal();
            LimpiarProducto();
            txtCodProducto.Select();
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                var subtotalCellValue = row.Cells["SubTotal"].Value;

                if (subtotalCellValue != null && !string.IsNullOrEmpty(subtotalCellValue.ToString()))
                {
                    decimal subtotalValue;
                    if (decimal.TryParse(subtotalCellValue.ToString(), out subtotalValue))
                    {
                        total += subtotalValue;
                    }
                    else
                    {
                        // Manejar el caso en el que el valor no es convertible a decimal
                        // Puedes mostrar un mensaje de error o realizar otra acción apropiada
                        MessageBox.Show("Error en el formato de SubTotal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // o realiza alguna otra acción adecuada en caso de error
                    }
                }
            }

            txtTotalPagar.Text = total.ToString("0.00");
        }

        private void LimpiarProducto()
        {
            txtIdProducto.Text = "0";
            txtCodProducto.Clear();
            txtProducto.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtCantidad.Value = 1;
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.Icono_Eliminar20.Width;
                var h = Properties.Resources.Icono_Eliminar20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.Icono_Eliminar20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dgvData.Rows.RemoveAt(indice);
                    CalcularTotal();
                }
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtPagocon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPagocon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void CalcularCambio()
        {
            if(txtTotalPagar.Text.Trim() == "")
            {
                MessageBox.Show("No existen Productos en la Venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal pagacon;
            decimal total = Convert.ToDecimal(txtTotalPagar.Text);

            if(txtPagocon.Text.Trim() == "")
            {
                txtPagocon.Text = "0";
            }

            if(decimal.TryParse(txtPagocon.Text.Trim(), out pagacon))
            {
                if(pagacon < total)
                {
                    txtCambio.Text = "0.00";
                }
                else
                {
                    decimal cambio = pagacon - total;
                    txtCambio.Text = cambio.ToString("0.00");
                }
            }
        }

        private void txtPagocon_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                CalcularCambio();
            }
        }

        private void btnCrearVenta_Click(object sender, EventArgs e)
        {
            if (txtDocCliente.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Documento del Cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtNombreCliente.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Nombre del Cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("Debe Ingresasr Productos en la Venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalle_venta = new DataTable();

            detalle_venta.Columns.Add("IdProducto", typeof(int));
            detalle_venta.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_venta.Columns.Add("Cantidad", typeof(int));
            detalle_venta.Columns.Add("SubTotal", typeof(decimal));

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                // Verificar si las celdas contienen valores válidos antes de convertirlos
                if (row.Cells["IdProducto"].Value != null &&
                    row.Cells["Precio"].Value != null &&
                    row.Cells["Cantidad"].Value != null &&
                    row.Cells["SubTotal"].Value != null)
                {
                    // Convertir los valores solo si no son nulos o vacíos
                    if (!string.IsNullOrEmpty(row.Cells["IdProducto"].Value.ToString()) &&
                        !string.IsNullOrEmpty(row.Cells["Precio"].Value.ToString()) &&
                        !string.IsNullOrEmpty(row.Cells["Cantidad"].Value.ToString()) &&
                        !string.IsNullOrEmpty(row.Cells["SubTotal"].Value.ToString()))
                    {
                        detalle_venta.Rows.Add(
                            new object[]
                            {
                    Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                    Convert.ToDecimal(row.Cells["Precio"].Value.ToString()),
                    Convert.ToInt32(row.Cells["Cantidad"].Value.ToString()),
                    Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString())
                            });
                    }
                    else
                    {
                        // Manejar el caso de valores nulos o vacíos en las celdas
                        // Puedes mostrar un mensaje de error o realizar alguna acción apropiada
                        MessageBox.Show("Uno o más valores en las celdas están vacíos o no son válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                int idcorrelativo = new N_Venta().ObtenerCorrelativo();
                string numerodocumento = string.Format("{0:00000}", idcorrelativo);
                CalcularCambio();

                Venta oVenta = new Venta()
                {
                    objUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                    TipoDocumento = ((OpcionCombo)cboTipoDocumento.SelectedItem).Texto,
                    NumeroDocumento = numerodocumento,
                    DocumentoCliente = txtDocCliente.Text,
                    NombreCliente = txtNombreCliente.Text,
                    MontoPago = Convert.ToDecimal(txtPagocon.Text),
                    MontoCambio = Convert.ToDecimal(txtCambio.Text),
                    MontoTotal = Convert.ToDecimal(txtTotalPagar.Text)
                };

                string mensaje = string.Empty;
                bool respuesta = new N_Venta().Registrar(oVenta, detalle_venta, out mensaje);

                if (respuesta)
                {
                    var result = MessageBox.Show("Numero de Venta generado:\n" + numerodocumento + "\n\nDesea Copiar al Portapapeles?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        Clipboard.SetText(numerodocumento);

                        txtDocCliente.Clear();
                        txtNombreCliente.Clear();
                        dgvData.Rows.Clear();
                        CalcularTotal();
                        txtPagocon.Clear();
                        txtCambio.Clear();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
